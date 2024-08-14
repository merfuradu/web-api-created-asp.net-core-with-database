﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI_week1;

#nullable disable

namespace WebAPI_week1.Migrations
{
    [DbContext(typeof(PersonsDB))]
    partial class TodoDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("WeatherId")
                        .HasColumnType("integer");

                    b.Property<float?>("app_temp")
                        .HasColumnType("real");

                    b.Property<float?>("clouds")
                        .HasColumnType("real");

                    b.Property<float?>("clouds_hi")
                        .HasColumnType("real");

                    b.Property<float?>("clouds_low")
                        .HasColumnType("real");

                    b.Property<float?>("clouds_mid")
                        .HasColumnType("real");

                    b.Property<string>("datetime")
                        .HasColumnType("text");

                    b.Property<float?>("dewpt")
                        .HasColumnType("real");

                    b.Property<float?>("dhi")
                        .HasColumnType("real");

                    b.Property<float?>("dni")
                        .HasColumnType("real");

                    b.Property<float?>("ghi")
                        .HasColumnType("real");

                    b.Property<float?>("ozone")
                        .HasColumnType("real");

                    b.Property<string>("pod")
                        .HasColumnType("text");

                    b.Property<float?>("pop")
                        .HasColumnType("real");

                    b.Property<float?>("precip")
                        .HasColumnType("real");

                    b.Property<float?>("pres")
                        .HasColumnType("real");

                    b.Property<float?>("rh")
                        .HasColumnType("real");

                    b.Property<float?>("slp")
                        .HasColumnType("real");

                    b.Property<float?>("snow")
                        .HasColumnType("real");

                    b.Property<float?>("snow_depth")
                        .HasColumnType("real");

                    b.Property<float?>("solar_rad")
                        .HasColumnType("real");

                    b.Property<float?>("temp")
                        .HasColumnType("real");

                    b.Property<DateTime?>("timestamp_local")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("timestamp_utc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("ts")
                        .HasColumnType("real");

                    b.Property<float?>("uv")
                        .HasColumnType("real");

                    b.Property<float?>("vis")
                        .HasColumnType("real");

                    b.Property<string>("wind_cdir")
                        .HasColumnType("text");

                    b.Property<string>("wind_cdir_full")
                        .HasColumnType("text");

                    b.Property<float?>("wind_dir")
                        .HasColumnType("real");

                    b.Property<float?>("wind_gust_spd")
                        .HasColumnType("real");

                    b.Property<float?>("wind_spd")
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

                    b.Property<string>("city_name")
                        .HasColumnType("text");

                    b.Property<string>("country_code")
                        .HasColumnType("text");

                    b.Property<float>("lat")
                        .HasColumnType("real");

                    b.Property<float>("lon")
                        .HasColumnType("real");

                    b.Property<string>("state_code")
                        .HasColumnType("text");

                    b.Property<string>("timezone")
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
