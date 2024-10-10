using System;
using Microsoft.EntityFrameworkCore;
using EventSpotterWeb.Models;

namespace EventSpotterWeb.Data
{
    public class DatabaseEventSpotter : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TicketManagement> TicketManagements { get; set; }
        public DbSet<Payment> Payments { get; set; } // Vergeet deze niet toe te voegen
        public DbSet<Account> Accounts { get; set; }

        public DatabaseEventSpotter(DbContextOptions<DatabaseEventSpotter> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=. ;Initial Catalog=EventTestDB;integrated Security=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Event Configuratie
            modelBuilder.Entity<Event>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Event>()
                .Property(e => e.Cost)
                .HasColumnType("decimal(18,2)"); // Configureer de precisie en schaal

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.OrganizerID);

            // Participant Configuratie
            modelBuilder.Entity<Participant>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            // Reservation Configuratie
            modelBuilder.Entity<Reservation>()
                .Property(r => r.TotalPrice)
                .HasColumnType("decimal(18,2)"); // Configureer de precisie en schaal

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Reservations)
                .HasForeignKey(r => r.EventID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Participant)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.ParticipantID);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.ReservationID)
                .ValueGeneratedOnAdd(); // Zorg voor auto-increment

            // Ticket Configuratie
            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasKey(t => t.TicketID); // Stel de primaire sleutel in

                entity.Property(t => t.SeatNumber)
                    .IsRequired(); // Zet vereiste velden indien nodig

                // Many-to-One relatie met Reservation
                entity.HasOne(t => t.Reservation)
                    .WithMany(r => r.Tickets)
                    .HasForeignKey(t => t.ReservationID) // Dit moet correct zijn
                    .OnDelete(DeleteBehavior.Cascade); // Kies hier de delete behavior, indien nodig

                // One-to-One relatie met TicketManagement
                entity.HasOne(t => t.TicketManagement)
                    .WithOne(tm => tm.Ticket)
                    .HasForeignKey<TicketManagement>(tm => tm.TicketID);
            });

            // Ticket Management Configuratie
            modelBuilder.Entity<TicketManagement>()
                .HasKey(tm => tm.TicketManagementID); // Stel de primaire sleutel in

            modelBuilder.Entity<TicketManagement>()
                .HasOne(tm => tm.Ticket)
                .WithOne(t => t.TicketManagement)
                .HasForeignKey<TicketManagement>(tm => tm.TicketID); // Verbind de TicketID als de foreign key

            // Payment Configuratie
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)"); // Configureer de precisie en schaal

            // Seed Data (Event)
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventID = 1,
                Name = "Foodtruck Festival",
                Location = "Eindhoven",
                Date = new DateTime(2024, 06, 15),
                MaxParticipants = 100,
                AvailableSeats = 90,
                Cost = 25.00M,
                Description = "A fun day with food and trucks!",
                Image = "foodtruck.jpg",
                CategoryID = 1,
                OrganizerID = 1
            });

            modelBuilder.Entity<Account>().HasData(new Account
            {
                AccountID = 1, // Dit moet overeenkomen met de OrganizerID
                Username = "johnvanhetkamp",
                Password = "password123", // Vergeet niet hier hashing toe te passen
                Email = "johnvanhetkamp@example.com",
                Role = "Organizer"
            });

            // Seed Data (Organizer)
            modelBuilder.Entity<Organizer>().HasData(new Organizer
            {
                OrganizerID = 1,
                Name = "John van het Kamp",
                Email = "johnvanhetkamp@example.com",
                Password = "password123",
                AccountID = 1
            });

            // Seed Data (Category)
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryID = 1,
                CategoryName = "Festival"
            });

            modelBuilder.Entity<Account>().HasData(new Account
            {
                AccountID = 2, // Zorg ervoor dat dit uniek is
                Username = "sarahpieters",
                Password = "password456", // Vergeet niet hier hashing toe te passen
                Email = "sarahpieters@example.com",
                Role = "Participant"
            });

            // Seed Data (Participant)
            modelBuilder.Entity<Participant>().HasData(new Participant
            {
                ParticipantID = 1,
                Name = "Sarah Pieters",
                Email = "sarahpieters@example.com",
                Password = "password456",
                AccountID = 2
            });

            // Seed Data (Payment)
            modelBuilder.Entity<Payment>().HasData(new Payment
            {
                PaymentID = 1,
                Amount = 50.00M, // Dit moet overeenkomen met de TotalPrice in Reservation
                PaymentDate = DateTime.Now,
                PaymentMethod = "Credit Card", // Voeg een payment method toe
                PaymentStatus = "Completed"
            });

            // Seed Data (Reservation)
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                ReservationID = 1, // Voeg een ID toe die overeenkomt met PaymentID
                ReservationDate = DateTime.Now,
                NumTickets = 2,
                TotalPrice = 50.00M, // 2 tickets à 25.00M elk
                PaymentStatus = "Completed",
                ConfirmationOrder = "CONF12345",
                EventID = 1,
                ParticipantID = 1,
                PaymentID = 1 // Zorg ervoor dat dit overeenkomt met de Payment
            });

            // Seed Data (Ticket)
            modelBuilder.Entity<Tickets>().HasData(new Tickets
            {
                TicketID = 1,
                SeatNumber = "A1",
                ReservationID = 1
            });

            modelBuilder.Entity<Tickets>().HasData(new Tickets
            {
                TicketID = 2,
                SeatNumber = "A2",
                ReservationID = 1
            });

            // Seed Data (TicketManagement)
            modelBuilder.Entity<TicketManagement>().HasData(new TicketManagement
            {
                TicketManagementID = 1,
                TicketID = 1, // Zorg ervoor dat dit overeenkomt met een bestaand Ticket
                Status = "Confirmed"
            });
        }
    }
}