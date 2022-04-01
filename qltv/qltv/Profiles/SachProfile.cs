using qltv.Dtos;
using qltv.Models;
using AutoMapper;

namespace qltv.Profiles
{
    public class SachProfile : Profile
    {
        public SachProfile()
        {
            CreateMap<SachProfile, Sach>();
        }
    }
}
