﻿// <auto-generated />
using System;
using System.Diagnostics.CodeAnalysis;

using GoodReads.Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoodReads.Infrastructure.EntityFramework.Migrations.Users
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(UsersContext))]
    [Migration("20240227132755_InitialUsersMigration")]
    partial class InitialUsersMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("users")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoodReads.Domain.UserAggregate.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Users", "users");
                });

            modelBuilder.Entity("GoodReads.Domain.UserAggregate.Entities.User", b =>
                {
                    b.OwnsMany("GoodReads.Domain.UserAggregate.ValueObjects.RatingId", "RatingIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("RatingId");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserRatingIds", "users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RatingIds");
                });
#pragma warning restore 612, 618
        }
    }
}
