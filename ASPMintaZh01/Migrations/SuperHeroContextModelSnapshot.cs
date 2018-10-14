﻿// <auto-generated />
using System;
using ASPMintaZh01.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASPMintaZh01.Migrations
{
    [DbContext(typeof(SuperHeroContext))]
    partial class SuperHeroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASPMintaZh01.Models.SuperHeroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType");

                    b.Property<int>("Health");

                    b.Property<byte[]>("Image");

                    b.Property<int>("Magic");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Power");

                    b.Property<string>("Side")
                        .IsRequired();

                    b.Property<int>("Speed");

                    b.HasKey("Id");

                    b.ToTable("SuperHeroes");
                });
#pragma warning restore 612, 618
        }
    }
}