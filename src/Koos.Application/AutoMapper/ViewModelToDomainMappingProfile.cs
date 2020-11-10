using AutoMapper;
using Koos.Application.ViewModels;
using Koos.Domain.Commands;

namespace Koos.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GoalViewModel, RegisterNewGoalCommand>()
                .ConstructUsing(c => new RegisterNewGoalCommand(c.Description, c.Reward, c.StarsToAchieve, c.StarsEarned,
                                                                c.StartDate, c.EndDate));
            CreateMap<GoalViewModel, UpdateGoalCommand>()
                .ConstructUsing(c => new UpdateGoalCommand(c.Id, c.Description, c.Reward, c.StarsToAchieve,
                                                           c.StarsEarned, c.StartDate, c.EndDate));
        }
    }
}
