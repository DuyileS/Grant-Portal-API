using GMP.API.Data;
using GMP.API.Mappings;
using GMP.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using GMP.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "GMP API", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

//builder.Services.AddDbContext<GMPDbContext>(options => 
//options.UseSqlServer(builder.Configuration.GetConnectionString("GMPConnectionString"))
//);

builder.Services.AddDbContextPool<GMPDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Neon")
        , npgsqlOptions =>
        {
            npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3, // The maximum number of retry attempts.
                maxRetryDelay: TimeSpan.FromSeconds(30), // The maximum delay between retries.
                errorCodesToAdd: null); // You can add specific SQL error codes to retry on, but the default is good for connection errors.
        }
    )
);

builder.Services.AddDbContextPool<GMPAuthDbContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("Neon")));

builder.Services.AddScoped<IApplicantRepository, SQLApplicantRepository>();
builder.Services.AddScoped<IAwardeeRepository, SQLAwardeeRepository>();
builder.Services.AddScoped<IDocumentRepository, SQLDocumentRepository>();
builder.Services.AddScoped<IGrantRepository, SQLGrantRepository>();
builder.Services.AddScoped<ITaskRepository, SQLTaskRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

builder.Services.AddCors(options => options.AddPolicy("corspolicy", builder =>
{
    builder.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("GMP")
    .AddEntityFrameworkStores<GMPAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

//builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("corspolicy");



// Ensure Documents folder exists
var documentsPath = Path.Combine(Directory.GetCurrentDirectory(), "Documents");
if (!Directory.Exists(documentsPath))
{
    Directory.CreateDirectory(documentsPath);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(documentsPath),
    RequestPath = "/Documents"
});


app.MapControllers();

app.Run();
