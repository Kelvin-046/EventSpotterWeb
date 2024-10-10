
namespace EventSpotterWeb.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // One-to-Many relationship: A Category can have multiple Events
        public ICollection<Event>? Events { get; set; }

    }
}
