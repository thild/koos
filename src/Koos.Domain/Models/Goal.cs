using System;
using System.ComponentModel.DataAnnotations;
using Koos.Domain.Core.Models;

namespace Koos.Domain.Models
{
    public class Goal : Entity
    {
        public Goal() {}
        public Goal(string description,
                    string reward,
                    int starsToAchieve,
                    int starsEarned,
                    DateTime startDate,
                    DateTime endDate)
        {
            Description = description;
            Reward = reward;
            StarsToAchieve = starsToAchieve;
            StarsEarned = starsEarned;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string Description { get; private set; }
        public string Reward { get; private set; }
        public int StarsToAchieve { get; private set; }
        public int StarsEarned { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public void GiveStar() => StarsEarned++;
        public void TakeStar() => StarsEarned--;

    }
}
