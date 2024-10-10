using System;
using System.Collections.Generic;

namespace EventSpotterWeb.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; } // Auto-increment
        public DateTime ReservationDate { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string ConfirmationOrder { get; set; }

        // Many-to-One relationship with Event
        public int EventID { get; set; } // Dit moet een nullable int zijn om geen verplichting te hebben om een Event te hebben
        public Event Event { get; set; }

        // Many-to-One relationship with Participant
        public int? ParticipantID { get; set; } // Dit moet een nullable int zijn om geen verplichting te hebben om een Participant te hebben
        public Participant Participant { get; set; }

        // One-to-One relationship with Payment
        public int? PaymentID { get; set; } // Dit moet ook nullable zijn om compatibiliteit met niet-betaalde reserveringen toe te staan
        public Payment? Payment { get; set; }

        // One-to-Many relationship: A Reservation can have multiple Tickets
        public ICollection<Tickets>? Tickets { get; set; }

       
        
    }
}
