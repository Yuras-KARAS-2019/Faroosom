﻿// <auto-generated />
using System;
using Faroosom.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Faroosom.DAL.Migrations
{
    [DbContext(typeof(FaroosomContext))]
    partial class FaroosomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Faroosom.DAL.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedData")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Faroosom.DAL.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedData")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("SubscriberId", "PublisherId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedData = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 1,
                            SubscriberId = 2
                        },
                        new
                        {
                            Id = 2,
                            CreatedData = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 2,
                            SubscriberId = 1
                        });
                });

            modelBuilder.Entity("Faroosom.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedData")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Login");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 0,
                            CreatedData = new DateTime(2021, 12, 1, 0, 1, 8, 327, DateTimeKind.Local).AddTicks(9404),
                            LastName = "Durda",
                            Login = "Sniper2001",
                            Name = "Roma",
                            Password = "QWERTY1234"
                        },
                        new
                        {
                            Id = 2,
                            Age = 0,
                            CreatedData = new DateTime(2021, 12, 1, 0, 1, 8, 329, DateTimeKind.Local).AddTicks(8572),
                            LastName = "Durda",
                            Login = "Killer1995",
                            Name = "Nadia",
                            Password = "QWERTY1234"
                        });
                });

            modelBuilder.Entity("Faroosom.DAL.Entities.Message", b =>
                {
                    b.HasOne("Faroosom.DAL.Entities.User", "From")
                        .WithMany("MessagesFrom")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Faroosom.DAL.Entities.User", "To")
                        .WithMany("MessagesTo")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("Faroosom.DAL.Entities.Subscription", b =>
                {
                    b.HasOne("Faroosom.DAL.Entities.User", "Publisher")
                        .WithMany("SubscriptionsToUser")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Faroosom.DAL.Entities.User", "Subscriber")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Publisher");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("Faroosom.DAL.Entities.User", b =>
                {
                    b.Navigation("MessagesFrom");

                    b.Navigation("MessagesTo");

                    b.Navigation("Subscriptions");

                    b.Navigation("SubscriptionsToUser");
                });
#pragma warning restore 612, 618
        }
    }
}