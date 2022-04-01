using AutoMapper;
using qltv.Dtos;
using qltv.Models;

namespace qltv.Profiles
{
    public class TraProfile : Profile
    {
        public TraProfile()
        {
            CreateMap<TraProfile, Tra>();
        }
    }
}
