using AutoMapper;
using Koos.Application.ViewModels;
using Koos.Domain.Models;

namespace Koos.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Goal, GoalViewModel>();
        }
    }
}
