using System;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace Koos.ViewModels
{
    public class GoalViewModel : ReactiveObject
    {
        public GoalViewModel() { }
        public GoalViewModel(int stars)
        {
            StarsToAchieve = stars;
        }
        public string _description;
        public string Description { get => _description; set => this.RaiseAndSetIfChanged(ref _description, value); }

        private string _reward;
        public string Reward { get => _reward; set => this.RaiseAndSetIfChanged(ref _reward, value); }

        private int _starsToAchieve;
        public int StarsToAchieve { get => _starsToAchieve; set => this.RaiseAndSetIfChanged(ref _starsToAchieve, value); }

        private int _starsEarned;
        public int StarsEarned { get => _starsEarned; set => this.RaiseAndSetIfChanged(ref _starsEarned, value); }

        private DateTime _startDate;
        public DateTime StartDate { get => _startDate; set => this.RaiseAndSetIfChanged(ref _startDate, value); }

        private DateTime _endtDate;
        public DateTime EndDate { get => _endtDate; set => this.RaiseAndSetIfChanged(ref _endtDate, value); }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public void GiveStar() => StarsEarned++;
        public void TakeStar() => StarsEarned--;

    }
}
