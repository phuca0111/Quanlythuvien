using AutoMapper;
using qltv.Dtos;
using qltv.Models;

namespace qltv.Profiles
{
    public class VitriProfile : Profile
    {
        public VitriProfile()
        {
            CreateMap<VitriCreatedDto, Vitri>();
        }
    }
}
