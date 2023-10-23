using AuctionService.Data;
using AuctionService.DTO;
using AuctionService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers
{
    // This controller handles HTTP requests related to auctions.
    [ApiController]
    [Route("api/auctions")]
    public class AuctionController : ControllerBase
    {
        private readonly AuctionDbContext _context;
        private readonly IMapper _mapper;

        // Constructor to inject dependencies (AuctionDbContext and IMapper).
        public AuctionController(AuctionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // HTTP GET endpoint to retrieve all auctions.
        [HttpGet]
        public async Task<ActionResult<List<AuctionDTO>>> GetAllAuctions()
        {
            // Retrieve all auctions from the database, including associated item details, and order them by make.
            var auctions = await _context.Auctions.Include(auction => auction.Item)
                .OrderBy(auction => auction.Item.Make)
                .ToListAsync();

            // Map the retrieved auctions to AuctionDTOs and return as a response.
            return _mapper.Map<List<AuctionDTO>>(auctions);
        }

        // HTTP GET endpoint to retrieve an auction by its ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDTO>> GetAuctionById(Guid id)
        {
            // Retrieve an auction by its ID from the database, including associated item details.
            var auction = await _context.Auctions.Include(auction => auction.Item)
                .FirstOrDefaultAsync(auction => auction.Id == id);

            // If the auction is not found, return a 404 Not Found response.
            if (auction == null) return NotFound();

            // Map the retrieved auction to an AuctionDTO and return as a response.
            return _mapper.Map<AuctionDTO>(auction);
        }

        // HTTP POST endpoint to create a new auction.
        [HttpPost]
        public async Task<ActionResult<AuctionDTO>> CreateAuction(CreateAuctionDTO auctionDTO)
        {
            // Map the provided AuctionDTO to an Auction entity.
            var auction = _mapper.Map<Auction>(auctionDTO);

            // Set the seller (for demonstration purposes; replace with actual logic).
            auction.Seller = "test";

            // Add the auction to the database and save changes.
            _context.Auctions.Add(auction);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
            {
                return BadRequest("could not save changes");
            }

            // Return an HTTP 201 (Created) response along with a URI to the newly created resource.

            // The nameof(GetAuctionById) specifies the name of the action method that can be used to retrieve the newly created resource.
            // In this case, it refers to the GetAuctionById action method within the same controller.

            // The new { id = auction.Id } is an anonymous object that contains the route values required to generate the URL for accessing the newly created resource.
            // It includes a single route parameter 'id' with the value being the Id property of the newly created 'auction' object.

            // The 'auctionDTO' represents the payload or data returned as part of the response body, providing information about the newly created auction in a format suitable for the client.
            return CreatedAtAction(nameof(GetAuctionById), new { id = auction.Id }, _mapper.Map<AuctionDTO>(auction));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<AuctionDTO>> UpdateAuction(Guid id, UpdateAuctionDto auctionDTO)
        {
            var auction = await _context.Auctions.Include(auction => auction.Item)
                .FirstOrDefaultAsync(auction => auction.Id == id);
            if (auction == null)
            {
                return NotFound();
            }

            auction.Item.Make = auctionDTO.Make ?? auction.Item.Make;
            auction.Item.Model = auctionDTO.Model ?? auction.Item.Model;
            auction.Item.Color = auctionDTO.Color ?? auction.Item.Color;
            auction.Item.Color = auctionDTO.Color ?? auction.Item.Color;
            auction.Item.Mileage = auctionDTO.Mileage ?? auction.Item.Mileage;
            auction.Item.Year = auctionDTO.Year ?? auction.Item.Year;


            _context.Auctions.Update(auction);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
            {
                return BadRequest("could not save changes");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AuctionDTO>> DeleteAuction(Guid id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null) return NotFound();
            _context.Auctions.Remove(auction);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
            {
                return BadRequest("could not save changes");
            }

            return Ok();
        }
    }
}