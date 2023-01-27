using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfToDoList.Classes;
using WpfToDoList.Core;

namespace WpfToDoList.ViewModel
{
    class TasksViewModel : BaseViewModel
    {
        public ObservableCollection<TasksClass> ListTasks { get; set; }

        public ICollectionView TasksCollectionView { get; }

        private TasksClass selectedTask;
        public TasksClass SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value; OnPropertyChanged(); }
        }

        private string taskFilter = string.Empty;
        public string TaskFilter
        {
            get { return taskFilter; }
            set
            {
                taskFilter = value;
                OnPropertyChanged();
                TasksCollectionView.Refresh();
            }
        }


        public TasksViewModel()
        {

            ListTasks = new ObservableCollection<TasksClass>();

            string fileName = "Tasks.xml";
            ListTasks = XmlClass.LoadInfoTasks(fileName);

            TasksCollectionView = CollectionViewSource.GetDefaultView(ListTasks);
            TasksCollectionView.Filter = FilterTasks;

            AddTask = new RelayCommand(o =>
            {
                TasksClass newTask = new TasksClass();
                newTask.Task = "Новая задача";
                newTask.SubTask = "Описание";
                ListTasks.Add(newTask);
                XmlClass.SaveInfo(ListTasks, fileName);
                SelectedTask = ListTasks[ListTasks.Count - 1];
            });

            RemoveTask = new RelayCommand(o =>
            {
                if (SelectedTask != null)
                {
                    bool? Result = new MessageBoxCustom("Удалить задачу? ", MessageType.Confirmation,
                        MessageButtons.YesNo).ShowDialog();
                    if (Result.Value)
                    {
                        ListTasks.Remove(SelectedTask);
                        XmlClass.SaveInfo(ListTasks, fileName);
                    }
                }
            });

            RemoveAllList = new RelayCommand(o =>
            {
                if (ListTasks.Count != 0)
                {
                    bool? Result = new MessageBoxCustom("Удалить весь список? ", MessageType.Confirmation,
                        MessageButtons.YesNo).ShowDialog();
                    if (Result.Value)
                    {
                        ListTasks.Clear();
                        XmlClass.SaveInfo(ListTasks, fileName);
                    }
                }
            });

            SaveList = new RelayCommand(o =>
            {
                for (int i = 0; i < ListTasks.Count; i++)
                {
                    if (ListTasks[i].Task == "" && ListTasks[i].SubTask == "")
                    {
                        ListTasks.Remove(ListTasks[i]);
                    }
                }
                XmlClass.SaveInfo(ListTasks, fileName);
            });
        }

        private bool FilterTasks(object obj)
        {
            if (obj is TasksClass tasksViewModel)
            {
                return tasksViewModel.Task.ToUpper().Contains(TaskFilter.ToUpper()) ||
                       tasksViewModel.SubTask.ToUpper().Contains(TaskFilter.ToUpper());
            }
            return false;
        }

        public RelayCommand AddTask { get; set; }
        public RelayCommand RemoveTask { get; set; }
        public RelayCommand RemoveAllList { get; set; }
        public RelayCommand SaveList { get; set; }
    }
}
