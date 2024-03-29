﻿// <auto-generated />
using System;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ECommerceProjectWithWebAPIContext))]
    [Migration("20230215230502_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 2, 16, 2, 5, 2, 733, DateTimeKind.Local).AddTicks(7093));

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2")
                        .HasColumnName("DateOfBirth");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("bit")
                        .HasColumnName("Gender");

                    b.Property<DateTime?>("IUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IUpdatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDisplay")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Lüleburgaz",
                            CreatedDate = new DateTime(2023, 2, 16, 2, 5, 2, 733, DateTimeKind.Local).AddTicks(7670),
                            CreatedUserId = 1,
                            DateOfBirth = new DateTime(2001, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayOrder = 0,
                            Email = "sevvalacet@gmail.com",
                            FirstName = "Şevval",
                            Gender = true,
                            IUpdatedUserId = 0,
                            IsDisplay = false,
                            LastName = "Acet",
                            Password = "1234",
                            UserName = "svvlacet"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
