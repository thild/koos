using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Koos.Domain.Core.Events;

namespace Koos.Application.EventSourcedNormalizers
{
    public class GoalHistory
    {
        public static IList<GoalHistoryData> HistoryData { get; set; }

        public static IList<GoalHistoryData> ToJavaScriptGoalHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<GoalHistoryData>();
            GoalHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<GoalHistoryData>();
            var last = new GoalHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new GoalHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Description = string.IsNullOrWhiteSpace(change.Description) || change.Description == last.Description
                        ? ""
                        : change.Description,
                    Reward = string.IsNullOrWhiteSpace(change.Reward) || change.Reward == last.Reward
                        ? ""
                        : change.Reward,
                    StarsToAchieve = string.IsNullOrWhiteSpace(change.StarsToAchieve) || change.StarsToAchieve == last.StarsToAchieve
                        ? ""
                        : change.StarsToAchieve,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void GoalHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new GoalHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "GoalRegisteredEvent":
                        values = JsonSerializer.Deserialize<dynamic>(e.Data);
                        slot.Description = values["Description"];
                        slot.EndDate = values["EndDate"];
                        slot.Id = values["Id"];
                        slot.Reward = values["Reward"];
                        slot.StarsEarned = values["StarsEarned"];
                        slot.StarsToAchieve = values["StarsToAchieve"];
                        slot.StartDate = values["StartDate"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "GoalUpdatedEvent":
                        values = JsonSerializer.Deserialize<dynamic>(e.Data);
                        slot.Description = values["Description"];
                        slot.EndDate = values["EndDate"];
                        slot.Id = values["Id"];
                        slot.Reward = values["Reward"];
                        slot.StarsEarned = values["StarsEarned"];
                        slot.StarsToAchieve = values["StarsToAchieve"];
                        slot.StartDate = values["StartDate"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "GoalRemovedEvent":
                        values = JsonSerializer.Deserialize<dynamic>(e.Data);
                        slot.Id = values["Id"];
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}