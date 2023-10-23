using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTO;

public class CreateAuctionDTO
{
    [Required] public string Make { get; set; }

    [Required]
    // Model or type of the item.
    public string Model { get; set; }

    [Required]
    // Year of manufacture or production of the item.
    public int Year { get; set; }

    [Required]
    // Color of the item.
    public string Color { get; set; }

    [Required]
    // Mileage or distance traveled by the item.
    public int Mileage { get; set; }

    [Required]
    // URL of the image representing the item.
    public string ImageUrl { get; set; }

    [Required] public int ReservedPrice { get; set; }
    [Required] public DateTime AuctionEnd { get; set; }
}