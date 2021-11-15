﻿// <auto-generated />
using System;
using EventAppPage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventAppPage.Migrations
{
    [DbContext(typeof(EventAppPageContext))]
    partial class EventAppPageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventAppPage.Models.EventObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventObject");
                });

            modelBuilder.Entity("EventAppPage.Models.StringContainer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventObjectId")
                        .HasColumnType("int");

                    b.Property<int?>("EventObjectId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventObjectId");

                    b.HasIndex("EventObjectId1");

                    b.ToTable("StringContainer");
                });

            modelBuilder.Entity("EventAppPage.Models.StringContainer", b =>
                {
                    b.HasOne("EventAppPage.Models.EventObject", null)
                        .WithMany("Attendees")
                        .HasForeignKey("EventObjectId");

                    b.HasOne("EventAppPage.Models.EventObject", null)
                        .WithMany("Tags")
                        .HasForeignKey("EventObjectId1");
                });

            modelBuilder.Entity("EventAppPage.Models.EventObject", b =>
                {
                    b.Navigation("Attendees");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
