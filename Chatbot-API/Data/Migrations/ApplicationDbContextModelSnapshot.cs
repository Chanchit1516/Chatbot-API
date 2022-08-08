﻿// <auto-generated />
using System;
using Chatbot_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chatbot_API.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Chatbot_API.Entities.CHAT_HISTORIE", b =>
                {
                    b.Property<int>("CHAT_HISTORIE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CHAT_HISTORIE_ID"), 1L, 1);

                    b.Property<int>("CREATED_BY")
                        .HasColumnType("int");

                    b.Property<DateTime>("CREATED_DATETIME")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IS_COMPLTE")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UPDATE_DATETIME")
                        .HasColumnType("datetime2");

                    b.Property<int>("USER_ID")
                        .HasColumnType("int");

                    b.Property<string>("USER_TYPE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CHAT_HISTORIE_ID");

                    b.ToTable("CHAT_HISTORIE");
                });

            modelBuilder.Entity("Chatbot_API.Entities.CHAT_HISTORIE_DETAIL", b =>
                {
                    b.Property<int>("CHAT_HISTORIE_DETAIL_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CHAT_HISTORIE_DETAIL_ID"), 1L, 1);

                    b.Property<int?>("BUTTON_ID")
                        .HasColumnType("int");

                    b.Property<int>("CHAT_HISTORIE_ID")
                        .HasColumnType("int");

                    b.Property<int>("CREATED_BY")
                        .HasColumnType("int");

                    b.Property<bool>("IS_TOPIC")
                        .HasColumnType("bit");

                    b.Property<string>("MESSAGES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TIME_STAMP")
                        .HasColumnType("datetime2");

                    b.Property<string>("TOPICS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USER_TYPE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CHAT_HISTORIE_DETAIL_ID");

                    b.HasIndex("CHAT_HISTORIE_ID");

                    b.ToTable("CHAT_HISTORIE_DETAIL");
                });

            modelBuilder.Entity("Chatbot_API.Entities.CHAT_HISTORIE_DETAIL", b =>
                {
                    b.HasOne("Chatbot_API.Entities.CHAT_HISTORIE", "CHAT_HISTORIE")
                        .WithMany("CHAT_HISTORIE_DETAILS")
                        .HasForeignKey("CHAT_HISTORIE_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CHAT_HISTORIE");
                });

            modelBuilder.Entity("Chatbot_API.Entities.CHAT_HISTORIE", b =>
                {
                    b.Navigation("CHAT_HISTORIE_DETAILS");
                });
#pragma warning restore 612, 618
        }
    }
}
