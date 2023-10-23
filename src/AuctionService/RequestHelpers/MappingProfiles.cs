using AuctionService.DTO;
using AuctionService.Entities;
using AutoMapper;

namespace AuctionService.RequestHelpers
{
    // This class defines AutoMapper mapping profiles, specifying how objects of different types should be mapped to each other.
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateMap is used to configure mappings between different types.

            // Create a mapping from Auction to AuctionDTO and include members from the Item property.
            CreateMap<Auction, AuctionDTO>() // Define the mapping from Auction to AuctionDTO.
                .IncludeMembers(auction => auction.Item); // Include properties from the Item property of Auction.


            // Create a separate mapping from Item to AuctionDTO.
            CreateMap<Item, AuctionDTO>(); // Define the mapping from Item to AuctionDTO.


            // Create a mapping from CreateAuctionDTO to Auction and specify custom mapping for the Item property.
            CreateMap<CreateAuctionDTO, Auction>().ForMember(auction => auction.Item,
                member => member.MapFrom(createActionDto => createActionDto));

            /*
             * // Create a mapping from CreateAuctionDTO to Auction and specify custom mapping for the Item property.: This comment provides an overview of the code's purpose. It explains that this code is establishing a mapping from the CreateAuctionDTO class to the Auction class while also customizing the mapping specifically for the Item property.

               CreateMap<CreateAuctionDTO, Auction>(): This line initiates the configuration of an AutoMapper mapping. It tells AutoMapper to define how objects of type CreateAuctionDTO should be mapped to objects of type Auction.

               .ForMember(auction => auction.Item, member => member.MapFrom(createActionDto => createActionDto)): This line configures a custom mapping for the Item property of the Auction class.

               auction => auction.Item: This part specifies that the custom mapping applies to the Item property within the Auction class. It indicates that we are targeting the Item property.

               member => member.MapFrom(createActionDto => createActionDto): This part defines how the mapping for the Item property should be executed. It uses the MapFrom method to specify that the source of the mapping should be the createActionDto object, and the mapping should directly assign the value from the source (createActionDto) to the destination (auction.Item) without any additional transformations or calculations.
             */

            CreateMap<CreateAuctionDTO, Item>();
        }
    }
}