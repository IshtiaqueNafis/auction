using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities
{
    // Definition of the Item entity.
    [Table("Items")]
    public class Item
    {
        // Unique identifier for the item.
        public Guid Id { get; set; }

        // Make or manufacturer of the item.
        public string Make { get; set; }

        // Model or type of the item.
        public string Model { get; set; }

        // Year of manufacture or production of the item.
        public int Year { get; set; }

        // Color of the item.
        public string Color { get; set; }

        // Mileage or distance traveled by the item.
        public int Mileage { get; set; }

        // URL of the image representing the item.
        public string ImageUrl { get; set; }

        // Navigation property representing the associated auction for this item.
        public Auction Auction { get; set; }

        // The unique identifier of the associated auction (foreign key).
        public Guid AuctionId { get; set; }
    }
}