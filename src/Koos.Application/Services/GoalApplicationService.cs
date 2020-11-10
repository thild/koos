using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Koos.Application.EventSourcedNormalizers;
using Koos.Application.Interfaces;
using Koos.Application.ViewModels;
using Koos.Domain.Commands;
using Koos.Domain.Core.Bus;
using Koos.Domain.Interfaces;
using Koos.Infrastructure.Data.Repository.EventSourcing;

namespace Koos.Application.Services
{
    public class GoalApplicationService : IGoalApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IGoalRepository _goalRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public GoalApplicationService(IMapper mapper,
                                  IGoalRepository goalRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _goalRepository = goalRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<GoalViewModel> GetAll()
        {
            return _goalRepository.GetAll().ProjectTo<GoalViewModel>(_mapper.ConfigurationProvider);
        }

        public GoalViewModel GetById(Guid id)
        {
            return _mapper.Map<GoalViewModel>(_goalRepository.GetById(id));
        }

        public void Register(GoalViewModel goalViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewGoalCommand>(goalViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(GoalViewModel goalViewModel)
        {
            var updateCommand = _mapper.Map<UpdateGoalCommand>(goalViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveGoalCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<GoalHistoryData> GetAllHistory(Guid id)
        {
            return GoalHistory.ToJavaScriptGoalHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
