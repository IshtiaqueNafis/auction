using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities;

[Table("Auctions")]
public class Auction
{
    // Unique identifier for the auction.
    public Guid Id { get; set; }

    // The minimum price at which the item can be sold.
    public int ReservedPrice { get; set; } = 0;

    // The seller's name or identifier.
    public string Seller { get; set; }

    // The name or identifier of the auction winner.
    public string Winner { get; set; }

    // The final amount at which the item was sold (nullable).
    public int? SoldAmount { get; set; }

    // The current highest bid amount (nullable).
    public int? CurrentHighestBidAmount { get; set; }

    // The date and time when the auction was created, set to current UTC time by default.
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // The date and time when the auction was last updated, set to current UTC time by default.
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // The date and time when the auction is scheduled to end.
    public DateTime AuctionEnd { get; set; }

    // The status of the auction (e.g., open, closed, etc.).
    public Status Status { get; set; }

    // The item being auctioned.
    public Item Item { get; set; }
}