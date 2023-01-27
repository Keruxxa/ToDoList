using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using WpfToDoList.Classes;
using WpfToDoList.Core;

namespace WpfToDoList.ViewModel
{
    class NotesViewModel : BaseViewModel
    {
        public ObservableCollection<NotesClass> Notes { get; set; }

        public ICollectionView NotesCollectionView { get; }

        private NotesClass selectedNote;
        public NotesClass SelectedNote
        {
            get { return selectedNote; }
            set { selectedNote = value; OnPropertyChanged(); }
        }

        private string notesFilter = string.Empty;
        public string NotesFilter
        {
            get { return notesFilter; }
            set
            {
                notesFilter = value;
                OnPropertyChanged();
                NotesCollectionView.Refresh();
            }
        }

        public NotesViewModel()
        {
            Notes = new ObservableCollection<NotesClass>();

            string fileName = "Notes.xml";
            Notes = XmlClass.LoadInfoNotes(fileName);

            NotesCollectionView = CollectionViewSource.GetDefaultView(Notes);
            NotesCollectionView.Filter = FilterNotes;

            AddNote = new RelayCommand(o =>
            {
                NotesClass newNote = new NotesClass();
                newNote.Note = "Новая заметка";
                Notes.Add(newNote);
                XmlClass.SaveInfo(Notes, fileName);
                SelectedNote = Notes[Notes.Count - 1];
            });

            RemoveNote = new RelayCommand(o =>
            {
                if (SelectedNote != null)
                {
                    bool? Result = new MessageBoxCustom("Удалить заметку?", MessageType.Confirmation,
                        MessageButtons.YesNo).ShowDialog();
                    if (Result.Value)
                    {
                        Notes.Remove(SelectedNote);
                        XmlClass.SaveInfo(Notes, fileName);
                    }
                }
            });

            RemoveAllList = new RelayCommand(o =>
            {
                if (Notes.Count != 0)
                {
                    bool? Result = new MessageBoxCustom("Удалить весь список?", MessageType.Confirmation,
                        MessageButtons.YesNo).ShowDialog();
                    if (Result.Value)
                    {
                        Notes.Clear();
                        XmlClass.SaveInfo(Notes, fileName);
                    }
                }
            });

            SaveList = new RelayCommand(o =>
            {
                for (int i = 0; i < Notes.Count; i++)
                {
                    if (Notes[i].Note == string.Empty)
                    {
                        Notes.Remove(Notes[i]);
                    }
                }
                XmlClass.SaveInfo(Notes, fileName);
            });
        }

        private bool FilterNotes(object obj)
        {
            if (obj is NotesClass notesViewModel)
            {
                return notesViewModel.Note.ToUpper().Contains(NotesFilter.ToUpper());
            }
            return false;
        }

        public RelayCommand AddNote { get; set; }
        public RelayCommand RemoveNote { get; set; }
        public RelayCommand RemoveAllList { get; set; }
        public RelayCommand SaveList { get; set; }
    }
}
