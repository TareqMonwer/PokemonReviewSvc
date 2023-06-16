using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>()
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews));
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.Reviewer, opt => opt.MapFrom(src => src.Reviewer));
            CreateMap<Reviewer, ReviewerDto>();

            CreateMap<Category, CategoryDto>();
        }
    }
}
