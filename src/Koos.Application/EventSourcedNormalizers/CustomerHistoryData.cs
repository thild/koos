using System;

namespace Koos.Application.EventSourcedNormalizers
{
    public class GoalHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public string StarsToAchieve { get; set; }
        public string StarsEarned { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}