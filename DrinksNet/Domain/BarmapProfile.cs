using AutoMapper;
using DrinksNet.AuxApi.Dtos;

namespace DrinksNet.Domain
{
    public class BarmapProfile : Profile
    {
        public BarmapProfile()
        {
            CreateMap<UserDto, User>().ForMember(user => user.UserId, opt => opt.MapFrom(userDto => userDto.userId))
                .ForSourceMember(userDto => userDto.Id,opt=>opt.DoNotValidate()).ReverseMap();

        }
    }
}
