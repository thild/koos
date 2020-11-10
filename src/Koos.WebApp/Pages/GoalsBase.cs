using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koos.Application.Services;
using Koos.ViewModels;
using ReactiveUI.Blazor;

namespace Koos.WebApp
{
    public class GoalsBase : ReactiveComponentBase<GoalViewModel>
    {

        public GoalsBase(GoalServices goalServices)
        {
            GoalServices = goalServices;
        }

        protected override async Task OnInitializedAsync()
        {
            Goals = (await GoalServices.GetAllAsync()).ToList();
        }

        protected GoalServices GoalServices { get; }
        public List<GoalViewModel> Goals { get; set; }
        public GoalViewModel CurrentGoal { get; set; }
        public bool Updating { get; set; }

        protected async Task DeleteGoal(GoalViewModel goal)
        {
            System.Console.WriteLine($"Deleting goal {goal.Id}");
            await GoalServices.DeleteAsync(goal);
            await OnInitializedAsync();
        }

        protected void EditGoal(GoalViewModel goal)
        {
            System.Console.WriteLine($"Editing goal {goal.Id}");
            CurrentGoal = goal;
            Updating = true;
        }

        protected async Task SaveGoal()
        {
            System.Console.WriteLine($"Saving goal {CurrentGoal.Id.ToString()}");

            await GoalServices.SaveAsync(CurrentGoal, Updating);
            // Refresh list and reset the form
            Updating = false;
            CurrentGoal = new GoalViewModel();
            await OnInitializedAsync();
        }
    }
}