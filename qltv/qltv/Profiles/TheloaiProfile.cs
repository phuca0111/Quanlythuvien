using AutoMapper;
using qltv.Dtos;
using qltv.Models;

namespace qltv.Profiles
{
    public class TheloaiProfile : Profile
    {
        public TheloaiProfile()
        {
            CreateMap<TheloaiCreatedDto, TheLoai>();
        }
    }
}
