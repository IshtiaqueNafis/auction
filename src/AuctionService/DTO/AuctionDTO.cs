namespace AuctionService.DTO;

public class AuctionDTO
{
    public Guid Id { get; set; }

    // The minimum price at which the item can be sold.
    public int ReservedPrice { get; set; } = 0;

    // The seller's name or identifier.
    public string Seller { get; set; }

    // The name or identifier of the auction winner.
    public string Winner { get; set; }

    // The final amount at which the item was sold (nullable).
    public int SoldAmount { get; set; }

    // The current highest bid amount (nullable).
    public int CurrentHighestBidAmount { get; set; }

    // The date and time when the auction was created, set to current UTC time by default.
    public DateTime CreatedAt { get; set; }

    // The date and time when the auction was last updated, set to current UTC time by default.
    public DateTime UpdatedAt { get; set; }

    // The date and time when the auction is scheduled to end.
    public DateTime AuctionEnd { get; set; }

    // The status of the auction (e.g., open, closed, etc.).
    public string Status { get; set; }

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
}