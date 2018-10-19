﻿// <auto-generated />
using CompanyOnline.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyOnline.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181018215722_CompanyOnline.API.Models.ApplicationContext")]
    partial class CompanyOnlineAPIModelsApplicationContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyOnline.API.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<string>("Phone_Number");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}