using AutoMapper;
using api.ViewModel;

namespace api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Mail,MailViewModel>();
        }
    }
}