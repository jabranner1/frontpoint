﻿// <auto-generated />
using System;
using Frontpoint.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Frontpoint.Infrastructure.Migrations
{
    [DbContext(typeof(FrontpointDbContext))]
    partial class FrontpointDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Frontpoint.Core.Entities.Individual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastUpdatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Prefix")
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Individuals");
                });
#pragma warning restore 612, 618
        }
    }
}