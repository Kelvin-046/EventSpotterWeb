namespace EventSpotterWeb.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        // One-to-One relationship with Reservation
        public Reservation? Reservation { get; set; }
    }
}
