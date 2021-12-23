﻿// <auto-generated />
using BagLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BagLib.Migrations
{
    [DbContext(typeof(BagContext))]
    [Migration("20211213151618_04_Currencies")]
    partial class _04_Currencies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BagLib.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("BagLib.Models.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("BagLib.Models.Market", b =>
                {
                    b.Property<int>("MarketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("TimeZone")
                        .HasColumnType("smallint");

                    b.HasKey("MarketId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("BagLib.Models.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MarketId")
                        .HasColumnType("int");

                    b.Property<double>("MarketOpenShare")
                        .HasColumnType("float");

                    b.Property<double>("MarketShare")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ticket")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StockId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("CountryCurrency", b =>
                {
                    b.Property<int>("CountriesCountryId")
                        .HasColumnType("int");

                    b.Property<int>("CurrenciesCurrencyId")
                        .HasColumnType("int");

                    b.HasKey("CountriesCountryId", "CurrenciesCurrencyId");

                    b.HasIndex("CurrenciesCurrencyId");

                    b.ToTable("CountryCurrency");
                });

            modelBuilder.Entity("BagLib.Models.Market", b =>
                {
                    b.HasOne("BagLib.Models.Country", null)
                        .WithMany("Markets")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BagLib.Models.Currency", null)
                        .WithMany("Markets")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CountryCurrency", b =>
                {
                    b.HasOne("BagLib.Models.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BagLib.Models.Currency", null)
                        .WithMany()
                        .HasForeignKey("CurrenciesCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BagLib.Models.Country", b =>
                {
                    b.Navigation("Markets");
                });

            modelBuilder.Entity("BagLib.Models.Currency", b =>
                {
                    b.Navigation("Markets");
                });
#pragma warning restore 612, 618
        }
    }
}