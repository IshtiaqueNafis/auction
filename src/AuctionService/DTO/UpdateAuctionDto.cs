namespace AuctionService.DTO;

public class UpdateAuctionDto
{
    public string Make { get; set; }

    // Model or type of the item.
    public string Model { get; set; }

    // Year of manufacture or production of the item.
    public int? Year { get; set; }

    // Color of the item.
    public string Color { get; set; }

    // Mileage or distance traveled by the item.
    public int? Mileage { get; set; }
}