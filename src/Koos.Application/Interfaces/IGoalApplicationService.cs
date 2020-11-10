using System;
using System.Collections.Generic;
using Koos.Application.EventSourcedNormalizers;
using Koos.Application.ViewModels;

namespace Koos.Application.Interfaces
{
    public interface IGoalApplicationService : IDisposable
    {
        void Register(GoalViewModel customerViewModel);
        IEnumerable<GoalViewModel> GetAll();
        GoalViewModel GetById(Guid id);
        void Update(GoalViewModel customerViewModel);
        void Remove(Guid id);
        IList<GoalHistoryData> GetAllHistory(Guid id);
    }
}
