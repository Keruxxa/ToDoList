namespace WpfToDoList.Classes
{
    public class TasksClass : Core.BaseViewModel
    {

        private string task;
        public string Task
        {
            get { return task; }
            set { task = value; OnPropertyChanged(); }
        }

        private string subTask;
        public string SubTask
        {
            get { return subTask; }
            set { subTask = value; OnPropertyChanged(); }
        }
    }
}
