using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Xml.Serialization;
using WpfToDoList.ViewModel;

namespace WpfToDoList.Classes
{
    static class XmlClass
    {
        public static void SaveInfo<T>(T list, string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xml.Serialize(fs, list);
            }
        }

        public static ObservableCollection<TasksClass> LoadInfoTasks(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<TasksClass>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                ObservableCollection<TasksClass> returnList;
                returnList = (ObservableCollection<TasksClass>)xml.Deserialize(fs);
                return returnList;
            }
        }

        public static ObservableCollection<ImportantTasksClass> LoadInfoImportantTasks(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<ImportantTasksClass>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                ObservableCollection<ImportantTasksClass> returnList;
                returnList = (ObservableCollection<ImportantTasksClass>)xml.Deserialize(fs);
                return returnList;
            }
        }

        public static ObservableCollection<NotesClass> LoadInfoNotes(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<NotesClass>));

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                ObservableCollection<NotesClass> returnList = new ObservableCollection<NotesClass>();
                returnList = (ObservableCollection<NotesClass>)xml.Deserialize(fs);
                return returnList;
            }
        }
    }
}
