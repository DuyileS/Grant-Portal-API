﻿// <auto-generated />
using System;
using GMP.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GMP.API.Migrations
{
    [DbContext(typeof(GMPDbContext))]
    [Migration("20240225080626_New GMP MMigration")]
    partial class NewGMPMMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GMP.API.Models.Domain.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicantId"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsStaffMember")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicantId");

                    b.HasIndex("DocumentId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Awardees", b =>
                {
                    b.Property<int>("AwardeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AwardeeId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("AreaOfSpecialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AwardeeId");

                    b.HasIndex("DocumentId");

                    b.ToTable("Awardees");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocumentId"));

                    b.Property<DateTimeOffset>("DateUploaded")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Grant", b =>
                {
                    b.Property<Guid>("GrantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Criteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Deadline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GrantId");

                    b.ToTable("Grants");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.GrantApplicant", b =>
                {
                    b.Property<Guid>("GrantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.HasKey("GrantId", "ApplicantId");

                    b.HasIndex("ApplicantId");

                    b.ToTable("GrantApplicants");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<string>("AssignedFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignedTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Applicant", b =>
                {
                    b.HasOne("GMP.API.Models.Domain.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Awardees", b =>
                {
                    b.HasOne("GMP.API.Models.Domain.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.GrantApplicant", b =>
                {
                    b.HasOne("GMP.API.Models.Domain.Applicant", "Applicant")
                        .WithMany("GrantApplicants")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMP.API.Models.Domain.Grant", "Grant")
                        .WithMany("GrantApplicants")
                        .HasForeignKey("GrantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Grant");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Applicant", b =>
                {
                    b.Navigation("GrantApplicants");
                });

            modelBuilder.Entity("GMP.API.Models.Domain.Grant", b =>
                {
                    b.Navigation("GrantApplicants");
                });
#pragma warning restore 612, 618
        }
    }
}
