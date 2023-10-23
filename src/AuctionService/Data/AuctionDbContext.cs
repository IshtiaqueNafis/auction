using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data
{
    // This class represents the database context for the application, providing access to the data tables (DbSet) in the database.
    public class AuctionDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions to configure the database context.
        public AuctionDbContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet for the 'Auctions' table, allowing access to auction-related data.
        public DbSet<Auction> Auctions { get; set; }

        // DbSet for the 'Items' table, allowing access to item-related data.
        public DbSet<Item> Items { get; set; }
    }
}