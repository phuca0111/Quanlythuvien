using AutoMapper;
using qltv.Dtos;
using qltv.Models;

namespace qltv.Profiles
{
    public class TacgiaProfile : Profile
    {
        public TacgiaProfile()
        {
            CreateMap<TacgiaCreatedDto, Tacgia>();
        }
    }
}
