using GMP.API.Data;
using GMP.API.Mappings;
using GMP.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GMPDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("GMPConnectionString"))
);

builder.Services.AddScoped<IApplicantRepository, SQLApplicantRepository>();
builder.Services.AddScoped<IAwardeeRepository, SQLAwardeeRepository>();
builder.Services.AddScoped<IDocumentRepository, SQLDocumentRepository>();
builder.Services.AddScoped<IGrantRepository, SQLGrantRepository>();
builder.Services.AddScoped<ITaskRepository, SQLTaskRepository>();

builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
