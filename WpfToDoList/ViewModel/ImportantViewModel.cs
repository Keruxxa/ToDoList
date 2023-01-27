using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfToDoList.Classes;
using WpfToDoList.Core;

namespace WpfToDoList.ViewModel
{
    class ImportantViewModel : BaseViewModel
    {
        public ObservableCollection<ImportantTasksClass> ListTasks { get; set; }

        public ICollectionView ImportantCollectionView { get; }

        private ImportantTasksClass selectedTask;
        public ImportantTasksClass SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value; OnPropertyChanged(); }
        }

        private string impTaskFilter = string.Empty;
        public string ImpTaskFilter
        {
            get { return impTaskFilter; }
            set
            {
                impTaskFilter = value;
                OnPropertyChanged();
                ImportantCollectionView.Refresh();
            }
        }

        public ImportantViewModel()
        {
            ListTasks = new ObservableCollection<ImportantTasksClass>();

            string fileName = "ImportantTasks.xml";
            ListTasks = XmlClass.LoadInfoImportantTasks(fileName);

            ImportantCollectionView = CollectionViewSource.GetDefaultView(ListTasks);
            ImportantCollectionView.Filter = ImpFilterTasks;

            AddTask = new RelayCommand(o =>
            {
                ImportantTasksClass newTask = new ImportantTasksClass();
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
                    bool? Result = new MessageBoxCustom("Удалить весь список? ", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
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
                    if (ListTasks[i].Task == string.Empty && ListTasks[i].SubTask == string.Empty)
                    {
                        ListTasks.Remove(ListTasks[i]);
                    }
                }
                XmlClass.SaveInfo(ListTasks, fileName);
            });
        }

        private bool ImpFilterTasks(object obj)
        {
            if (obj is ImportantTasksClass importantTasksVM)
            {
                return importantTasksVM.Task.ToUpper().Contains(ImpTaskFilter.ToUpper()) ||
                       importantTasksVM.SubTask.ToUpper().Contains(ImpTaskFilter.ToUpper());
            }
            return false;

        }

        public RelayCommand AddTask { get; set; }
        public RelayCommand RemoveTask { get; set; }
        public RelayCommand RemoveAllList { get; set; }
        public RelayCommand SaveList { get; set; }
    }
}
