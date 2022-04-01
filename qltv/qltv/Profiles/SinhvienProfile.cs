using qltv.Dtos;
using qltv.Models;
using AutoMapper;

namespace qltv.Profiles
{
    public class SinhvienProfile : Profile
    {
        public SinhvienProfile()
        {
            CreateMap<SinhvienProfile, Sinhvien>();
        }
    }
}
