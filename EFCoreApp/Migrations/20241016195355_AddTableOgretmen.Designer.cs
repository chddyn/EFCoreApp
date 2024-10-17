﻿// <auto-generated />
using System;
using EFCoreApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241016195355_AddTableOgretmen")]
    partial class AddTableOgretmen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("EFCoreApp.Data.Kurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Baslik")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ogretmenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ogretmenId");

                    b.ToTable("Kurslar");
                });

            modelBuilder.Entity("EFCoreApp.Data.KursKayit", b =>
                {
                    b.Property<int>("KayitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("KursId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KayitId");

                    b.HasIndex("KursId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("KursKayitlari");
                });

            modelBuilder.Entity("EFCoreApp.Data.Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciSoyad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("EFCoreApp.Data.Ogretmen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("ogretmenAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("ogretmenMail")
                        .HasColumnType("TEXT");

                    b.Property<string>("ogretmenSoyd")
                        .HasColumnType("TEXT");

                    b.Property<string>("ogretmenTel")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("EFCoreApp.Data.Kurs", b =>
                {
                    b.HasOne("EFCoreApp.Data.Ogretmen", "Ogretmen")
                        .WithMany("Kurslar")
                        .HasForeignKey("ogretmenId");

                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("EFCoreApp.Data.KursKayit", b =>
                {
                    b.HasOne("EFCoreApp.Data.Kurs", "Kurs")
                        .WithMany("kursKayitlari")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreApp.Data.Ogrenci", "Ogrenci")
                        .WithMany("kursKayitlari")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("EFCoreApp.Data.Kurs", b =>
                {
                    b.Navigation("kursKayitlari");
                });

            modelBuilder.Entity("EFCoreApp.Data.Ogrenci", b =>
                {
                    b.Navigation("kursKayitlari");
                });

            modelBuilder.Entity("EFCoreApp.Data.Ogretmen", b =>
                {
                    b.Navigation("Kurslar");
                });
#pragma warning restore 612, 618
        }
    }
}
