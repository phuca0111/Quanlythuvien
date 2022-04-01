using qltv.Models;
using qltv.Dtos;
using AutoMapper;

namespace qltv.Profiles
{
    public class NhaXbProfile : Profile
    {
        public NhaXbProfile()
        {
            CreateMap<NhaXbProfile, NhaXb>();
        }
    }
}
