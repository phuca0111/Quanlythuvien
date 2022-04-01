using qltv.Models;
using qltv.Dtos;
using AutoMapper;

namespace qltv.Profiles
{
    public class MuonProfile : Profile
    {
        public MuonProfile()
        {
            CreateMap<MuonProfile, Muon>();
        }
    }
}
