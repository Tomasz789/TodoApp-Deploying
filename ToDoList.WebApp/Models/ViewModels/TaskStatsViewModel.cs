namespace ToDoList.WebApp.Models.ViewModels
{
    public class TaskStatsViewModel
    {
        public int TasksCount { get; set; }

        public int TasksDoneCount { get; set; }

        public int TasksNotStarted { get; set; }

        public int TasksInProgressCount { get; set; }
    }
}
