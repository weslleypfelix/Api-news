using Api_newss.Entities;
using Api_newss.Entities.ViewModels;
using AutoMapper;

namespace Api_newss.Mappers
{
    public class EntityToViewModelMapping : Profile
    {
        public EntityToViewModelMapping()
        {
            CreateMap<News, NewsViewModel>();
        }
    }
}
