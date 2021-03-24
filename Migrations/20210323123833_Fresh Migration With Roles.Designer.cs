﻿// <auto-generated />
using System;
using InventorySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventorySystem.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    [Migration("20210323123833_Fresh Migration With Roles")]
    partial class FreshMigrationWithRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("InventorySystem.Models.Entities.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("InventorySystem.Models.Entities.EquipmentDistribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime");

                    b.Property<int?>("EquipmentsId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("EquipmentsId");

                    b.HasIndex("ManagerId");

                    b.ToTable("EquipmentDistribution");
                });

            modelBuilder.Entity("InventorySystem.Models.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(72)")
                        .HasMaxLength(72);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("InventorySystem.Models.Equipments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EquipmentGenereatedKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EquipmentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EquipmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("EquipmentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("InventorySystem.Models.ProjectRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("InventorySystem.Models.Entities.EquipmentDistribution", b =>
                {
                    b.HasOne("InventorySystem.Models.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventorySystem.Models.Equipments", "Equipments")
                        .WithMany()
                        .HasForeignKey("EquipmentsId");

                    b.HasOne("InventorySystem.Models.Entities.Manager", "Mamager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
