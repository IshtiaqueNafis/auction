namespace AuctionService.Entities;


public enum Status
{
    // The auction is currently live and accepting bids.
    Live,

    // The auction has finished, and no more bids are accepted.
    Finished,

    // The reserved price was not met, and the auction did not result in a sale.
    ReservedNotMet,
}
