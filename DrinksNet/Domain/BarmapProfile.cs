using AutoMapper;
using DrinksNet.AuxApi.Dtos;
using DrinksNet.Domain.Dtos;

namespace DrinksNet.Domain
{
    public class BarmapProfile : Profile
    {
        public BarmapProfile()
        {
            CreateMap<UserDto, User>()
                .ForSourceMember(userDto => userDto.Id, opt => opt.DoNotValidate()).ReverseMap();
            CreateMap<DrinkDetailsResponseDto, Drink>().ForMember(drink => drink.Path, opt
                    => opt.MapFrom(drinkDto => "/"+drinkDto.IdDrink))
                .ForMember(drink => drink.Ingredients, opt => opt.Ignore())
                .ForMember(drink => drink.Measures, opt => opt.Ignore());

            CreateMap<Drink, DrinkListItem>();

            CreateMap<DrinkListByIngredientDto, DrinkListItem>();
            CreateMap<UserDrinkDto, UserDrink>()
                .ForSourceMember(userDto => userDto.Id, opt => opt.DoNotValidate());
        }
    }
}
