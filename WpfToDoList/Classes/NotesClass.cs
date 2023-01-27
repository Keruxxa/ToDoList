namespace WpfToDoList.Classes
{
    public class NotesClass : Core.BaseViewModel
    {
        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged(); }
        }
    }
}
