﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI_week1;

#nullable disable

namespace WebAPI_week1.Migrations
{
    [DbContext(typeof(PersonsDB))]
    [Migration("20240813102148_ChangeIDs")]
    partial class ChangeIDs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAPI_week1.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<int?>("PersonalDataId")
                        .HasColumnType("integer");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PersonalDataId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WebAPI_week1.Models.Datum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float?>("AppTemp")
                        .HasColumnType("real");

                    b.Property<float?>("Clouds")
                        .HasColumnType("real");

                    b.Property<float?>("CloudsHi")
                        .HasColumnType("real");

                    b.Property<float?>("CloudsLow")
                        .HasColumnType("real");

                    b.Property<float?>("CloudsMid")
                        .HasColumnType("real");

                    b.Property<string>("Datetime")
                        .HasColumnType("text");

                    b.Property<float?>("Dewpt")
                        .HasColumnType("real");

                    b.Property<float?>("Dhi")
                        .HasColumnType("real");

                    b.Property<float?>("Dni")
                        .HasColumnType("real");

                    b.Property<float?>("Ghi")
                        .HasColumnType("real");

                    b.Property<float?>("Ozone")
                        .HasColumnType("real");

                    b.Property<string>("Pod")
                        .HasColumnType("text");

                    b.Property<float?>("Pop")
                        .HasColumnType("real");

                    b.Property<float?>("Precip")
                        .HasColumnType("real");

                    b.Property<float?>("Pres")
                        .HasColumnType("real");

                    b.Property<float?>("Rh")
                        .HasColumnType("real");

                    b.Property<float?>("Slp")
                        .HasColumnType("real");

                    b.Property<float?>("Snow")
                        .HasColumnType("real");

                    b.Property<float?>("SnowDepth")
                        .HasColumnType("real");

                    b.Property<float?>("SolarRad")
                        .HasColumnType("real");

                    b.Property<float?>("Temp")
                        .HasColumnType("real");

                    b.Property<DateTime?>("TimestampLocal")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("TimestampUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("Ts")
                        .HasColumnType("real");

                    b.Property<float?>("Uv")
                        .HasColumnType("real");

                    b.Property<float?>("Vis")
                        .HasColumnType("real");

                    b.Property<int>("WeatherId")
                        .HasColumnType("integer");

                    b.Property<string>("WindCdir")
                        .HasColumnType("text");

                    b.Property<string>("WindCdirFull")
                        .HasColumnType("text");

                    b.Property<float?>("WindDir")
                        .HasColumnType("real");

                    b.Property<float?>("WindGustSpd")
                        .HasColumnType("real");

                    b.Property<float?>("WindSpd")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("WeatherId");

                    b.ToTable("DataPoints");
                });

            modelBuilder.Entity("WebAPI_week1.Models.PersonalData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PersonalData");
                });

            modelBuilder.Entity("WebAPI_week1.Models.Weather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.Property<string>("StateCode")
                        .HasColumnType("text");

                    b.Property<string>("Timezone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("WebAPI_week1.Models.Address", b =>
                {
                    b.HasOne("WebAPI_week1.Models.PersonalData", "PersonalData")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonalDataId");

                    b.Navigation("PersonalData");
                });

            modelBuilder.Entity("WebAPI_week1.Models.Datum", b =>
                {
                    b.HasOne("WebAPI_week1.Models.Weather", "Weather")
                        .WithMany("DataPoints")
                        .HasForeignKey("WeatherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Weather");
                });

            modelBuilder.Entity("WebAPI_week1.Models.PersonalData", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("WebAPI_week1.Models.Weather", b =>
                {
                    b.Navigation("DataPoints");
                });
#pragma warning restore 612, 618
        }
    }
}