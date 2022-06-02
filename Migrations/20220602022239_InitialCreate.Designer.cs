﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorZoo.Data;

#nullable disable

namespace RazorZoo.Migrations
{
    [DbContext(typeof(ZooContext))]
    [Migration("20220602022239_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("RazorZoo.Models.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CageID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeAnimal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CageID");

                    b.ToTable("Animal", (string)null);
                });

            modelBuilder.Entity("RazorZoo.Models.Cage", b =>
                {
                    b.Property<int>("CageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeAnimal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CageID");

                    b.ToTable("Cage", (string)null);
                });

            modelBuilder.Entity("RazorZoo.Models.Animal", b =>
                {
                    b.HasOne("RazorZoo.Models.Cage", "Cage")
                        .WithMany("Animals")
                        .HasForeignKey("CageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cage");
                });

            modelBuilder.Entity("RazorZoo.Models.Cage", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}