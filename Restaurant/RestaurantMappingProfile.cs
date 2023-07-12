using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile() 
        {
            //jeżeli zmienne z oryginalnej pokrywają się z Dto, to nie trzeba tego mapować, bo samo to się zrobi,
            //dlatego tutaj tylko z adresu 
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address, 
                    c => c.MapFrom(dto => new Address()
                        { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));

        }
    }
}
