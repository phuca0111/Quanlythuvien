using AutoMapper;
using qltv.Dtos;
using qltv.Models;

namespace qltv.Profiles
{
    public class ThuthuProfile : Profile
    {
        public ThuthuProfile()
        {
            CreateMap<ThuthuProfile, Thuthu>();
        }
    }
}
