﻿// <auto-generated />
using System;
using Ecommerce.Api.Microservice.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ecommerce.Api.Microservice.Migrations
{
    [DbContext(typeof(ContextAuthor))]
    partial class ContextAuthorModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Ecommerce.Api.Microservice.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AuthorGuid")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FistName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Ecommerce.Api.Microservice.Models.GradeAcademic", b =>
                {
                    b.Property<int>("GradeAcademicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AcademicCenter")
                        .HasColumnType("text");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("GradeAcademicGuide")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("GradeAcademicId");

                    b.HasIndex("AuthorId");

                    b.ToTable("GradeAcademic");
                });

            modelBuilder.Entity("Ecommerce.Api.Microservice.Models.GradeAcademic", b =>
                {
                    b.HasOne("Ecommerce.Api.Microservice.Models.Author", "Author")
                        .WithMany("ListGradeAcademic")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
