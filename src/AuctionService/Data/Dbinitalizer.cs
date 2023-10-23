using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data
{
    // This class is responsible for initializing the database and seeding it with initial data.
    public class Dbinitalizer
    {
        // Initializes the database using the provided WebApplication.
        public static void InitDB(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            SeedData(scope.ServiceProvider.GetRequiredService<AuctionDbContext>());
        }

        // Seeds the database with initial auction data if it's not already populated.
        private static void SeedData(AuctionDbContext context)
        {
            // Apply any pending database migrations.
            context.Database.Migrate();

            // Check if there are any auctions already in the database.
            if (context.Auctions.Any())
            {
                Console.WriteLine("Database already seeded");
                return;
            }

            // Create a list of initial auction objects.
            var auctions = new List<Auction>()
            {
                // Auction 1: Ford GT
                new Auction
                {
                    Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                    Status = Status.Live,
                    ReservedPrice = 20000,
                    Seller = "bob",
                    AuctionEnd = DateTime.UtcNow.AddDays(10),
                    Item = new Item
                    {
                        Make = "Ford",
                        Model = "GT",
                        Color = "White",
                        Mileage = 50000,
                        Year = 2020,
                        ImageUrl = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg"
                    }
                },
                // ... (similar entries for other auctions)
            };

            // Add the auctions to the database context.
            context.AddRange(auctions);

            // Save changes to persist the data in the database.
            context.SaveChanges();
        }
    }
}
