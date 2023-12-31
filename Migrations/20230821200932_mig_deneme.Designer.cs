﻿// <auto-generated />
using CoreProject_Departman.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreProject_Departman.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230821200932_mig_deneme")]
    partial class mig_deneme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreProject_Departman.Models.Birim", b =>
                {
                    b.Property<int>("BirimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirimAd")
                        .HasColumnType("int");

                    b.HasKey("BirimID");

                    b.ToTable("Birims");
                });

            modelBuilder.Entity("CoreProject_Departman.Models.Personel", b =>
                {
                    b.Property<int>("PersonelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirimID")
                        .HasColumnType("int");

                    b.Property<string>("PersonelAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonelSehir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonelSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonelID");

                    b.HasIndex("BirimID");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("CoreProject_Departman.Models.Personel", b =>
                {
                    b.HasOne("CoreProject_Departman.Models.Birim", "Birim")
                        .WithMany("Personels")
                        .HasForeignKey("BirimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Birim");
                });

            modelBuilder.Entity("CoreProject_Departman.Models.Birim", b =>
                {
                    b.Navigation("Personels");
                });
#pragma warning restore 612, 618
        }
    }
}
