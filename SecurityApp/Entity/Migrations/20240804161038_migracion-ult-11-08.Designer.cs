﻿// <auto-generated />
using System;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20240804161038_migracion-ult-11-08")]
    partial class migracionult1108
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Model.Security.Modulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_by")
                        .HasColumnType("datetime2");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_by")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("modules");
                });

            modelBuilder.Entity("Entity.Model.Security.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_by")
                        .HasColumnType("datetime2");

                    b.Property<string>("direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<string>("type_document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_by")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("Entity.Model.Security.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_by")
                        .HasColumnType("datetime2");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_by")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Entity.Model.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_by")
                        .HasColumnType("datetime2");

                    b.Property<string>("passsword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_by")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Entity.Model.Security.View", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_by")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idModule")
                        .HasColumnType("int");

                    b.Property<int>("moduleId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("route")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_by")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("moduleId");

                    b.ToTable("views");
                });

            modelBuilder.Entity("Entity.Model.Security.role_view", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ViewId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_by")
                        .HasColumnType("datetime2");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_by")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("ViewId");

                    b.ToTable("role_Views");
                });

            modelBuilder.Entity("Entity.Model.Security.user_role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("deleted_by")
                        .HasColumnType("datetime2");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_by")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("user_Roles");
                });

            modelBuilder.Entity("Entity.Model.Security.User", b =>
                {
                    b.HasOne("Entity.Model.Security.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Entity.Model.Security.View", b =>
                {
                    b.HasOne("Entity.Model.Security.Modulo", "module")
                        .WithMany()
                        .HasForeignKey("moduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("module");
                });

            modelBuilder.Entity("Entity.Model.Security.role_view", b =>
                {
                    b.HasOne("Entity.Model.Security.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.View", "View")
                        .WithMany()
                        .HasForeignKey("ViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("View");
                });

            modelBuilder.Entity("Entity.Model.Security.user_role", b =>
                {
                    b.HasOne("Entity.Model.Security.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
