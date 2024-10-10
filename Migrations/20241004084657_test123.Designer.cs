﻿// <auto-generated />
using System;
using EventSpotterWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventSpotterWeb.Migrations
{
    [DbContext(typeof(DatabaseEventSpotter))]
    [Migration("20241004084657_test123")]
    partial class test123
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventSpotterWeb.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Festival"
                        });
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventID"));

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxParticipants")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrganizerID")
                        .HasColumnType("int");

                    b.HasKey("EventID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("OrganizerID");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventID = 1,
                            AvailableSeats = 90,
                            CategoryID = 1,
                            Cost = 25.00m,
                            Date = new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A fun day with food and trucks!",
                            Image = "foodtruck.jpg",
                            Location = "Eindhoven",
                            MaxParticipants = 100,
                            Name = "Foodtruck Festival",
                            OrganizerID = 1
                        });
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Organizer", b =>
                {
                    b.Property<int>("OrganizerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizerID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizerID");

                    b.ToTable("Organizers");

                    b.HasData(
                        new
                        {
                            OrganizerID = 1,
                            Email = "johnvanhetkamp@example.com",
                            Name = "John van het Kamp",
                            Password = "password123"
                        });
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Participant", b =>
                {
                    b.Property<int>("ParticipantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParticipantID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipantID");

                    b.ToTable("Participants");

                    b.HasData(
                        new
                        {
                            ParticipantID = 1,
                            Email = "sarahpieters@example.com",
                            Name = "Sarah Pieters",
                            Password = "password456"
                        });
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentID");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            PaymentID = 1,
                            Amount = 50.00m,
                            PaymentDate = new DateTime(2024, 10, 4, 10, 46, 56, 761, DateTimeKind.Local).AddTicks(4923),
                            PaymentMethod = "Credit Card",
                            PaymentStatus = "Completed"
                        });
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<string>("ConfirmationOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("NumTickets")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantID")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentID")
                        .HasColumnType("int");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReservationID");

                    b.HasIndex("EventID");

                    b.HasIndex("ParticipantID");

                    b.HasIndex("PaymentID")
                        .IsUnique()
                        .HasFilter("[PaymentID] IS NOT NULL");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationID = 1,
                            ConfirmationOrder = "CONF12345",
                            EventID = 1,
                            NumTickets = 2,
                            ParticipantID = 1,
                            PaymentID = 1,
                            PaymentStatus = "Completed",
                            ReservationDate = new DateTime(2024, 10, 4, 10, 46, 56, 761, DateTimeKind.Local).AddTicks(4999),
                            TotalPrice = 50.00m
                        });
                });

            modelBuilder.Entity("EventSpotterWeb.Models.TicketManagement", b =>
                {
                    b.Property<int?>("TicketManagementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("TicketManagementID"));

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketID")
                        .HasColumnType("int");

                    b.HasKey("TicketManagementID");

                    b.HasIndex("TicketID")
                        .IsUnique()
                        .HasFilter("[TicketID] IS NOT NULL");

                    b.ToTable("TicketManagements");

                    b.HasData(
                        new
                        {
                            TicketManagementID = 1,
                            Status = "Confirmed",
                            TicketID = 1
                        });
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Tickets", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketID"));

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationID")
                        .HasColumnType("int");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketID");

                    b.HasIndex("ReservationID");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketID = 1,
                            ReservationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationID = 1,
                            SeatNumber = "A1"
                        },
                        new
                        {
                            TicketID = 2,
                            ReservationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReservationID = 1,
                            SeatNumber = "A2"
                        });
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Event", b =>
                {
                    b.HasOne("EventSpotterWeb.Models.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventSpotterWeb.Models.Organizer", "Organizer")
                        .WithMany("Events")
                        .HasForeignKey("OrganizerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Reservation", b =>
                {
                    b.HasOne("EventSpotterWeb.Models.Event", "Event")
                        .WithMany("Reservations")
                        .HasForeignKey("EventID");

                    b.HasOne("EventSpotterWeb.Models.Participant", "Participant")
                        .WithMany("Reservations")
                        .HasForeignKey("ParticipantID");

                    b.HasOne("EventSpotterWeb.Models.Payment", "Payment")
                        .WithOne("Reservation")
                        .HasForeignKey("EventSpotterWeb.Models.Reservation", "PaymentID");

                    b.Navigation("Event");

                    b.Navigation("Participant");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.TicketManagement", b =>
                {
                    b.HasOne("EventSpotterWeb.Models.Tickets", "Ticket")
                        .WithOne("TicketManagement")
                        .HasForeignKey("EventSpotterWeb.Models.TicketManagement", "TicketID");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Tickets", b =>
                {
                    b.HasOne("EventSpotterWeb.Models.Reservation", "Reservation")
                        .WithMany("Tickets")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Event", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Organizer", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Participant", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Payment", b =>
                {
                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Reservation", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventSpotterWeb.Models.Tickets", b =>
                {
                    b.Navigation("TicketManagement");
                });
#pragma warning restore 612, 618
        }
    }
}
