namespace WpfToDoList.ViewModel
{
    internal class MainViewModel : Core.BaseViewModel
    {
        public RelayCommand ShowTasksView { get; set; }
        public RelayCommand ShowImportantView { get; set; }
        public RelayCommand ShowNotesView { get; set; }

        public TasksViewModel TasksVM { get; set; } = new TasksViewModel();
        public ImportantViewModel ImportantVM { get; set; } = new ImportantViewModel();
        public NotesViewModel NotesVM { get; set; } = new NotesViewModel();

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ShowTasksView = new RelayCommand(o => { CurrentView = TasksVM; });
            ShowImportantView = new RelayCommand(o => { CurrentView = ImportantVM; });
            ShowNotesView = new RelayCommand(o => { CurrentView = NotesVM; });

            CurrentView = TasksVM;
        }
    }
}
