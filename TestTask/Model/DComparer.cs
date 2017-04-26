using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace TestTask.Model
{
    //logic of comparing and storing information in directories
    class DComparer : INotifyPropertyChanged
    {
        #region Implement INotyfyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Properties

        private string path1;
        private string path2;
        private ObservableCollection<FInfo> files;

        public string Path1
        {
            set
            {
                if (path1 != value)
                {
                    path1 = value;
                    reload();
                    OnPropertyChanged("Path1");
                }
            }
            get { return path1; }
        }

        public string Path2
        {
            set
            {
                if (path2 != value)
                {
                    path2 = value;
                    reload();
                    OnPropertyChanged("Path2");
                }
            }
            get { return path2; }
        }

        public ObservableCollection<FInfo> Files
        {
            get { return files; }
            set
            {
                files = value;
                OnPropertyChanged("Files");
            }
        }

        #endregion

        #region Constructor
        public DComparer()
        {
            files = new ObservableCollection<FInfo>();
        }
        #endregion

        #region Methods
        //refresh information about directories
        private void reload()
        {
            Files.Clear();
            if (path1 != null)
            {
                checkFolder(path1);
            }
            if (path2 != null)
            {
                checkFolder(path2);
            }
        }

        private void checkFolder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] info = dirInfo.GetFiles("*.*");

            foreach (FileInfo inf in info)
            {
                var fInf = new FInfo();
                fInf.Name = inf.Name;
                fInf.Size = inf.Length;
                fInf.Date = inf.LastWriteTime;
                var fileInf = findInObservableCollection(files, fInf.Name);
                if (fileInf != null)
                {
                    if (fileInf.Size == inf.Length)
                    {
                        fileInf.State = stateType.SameSize;
                        fInf.State = stateType.SameSize;
                    }
                    else
                    {
                        fileInf.State = stateType.DifSize;
                        fInf.State = stateType.DifSize;
                    }
                }
                else
                {
                    fInf.State = path == path1 ? stateType.First : stateType.Second;
                }
                Files.Add(fInf);
            }
        }

        //searching in ObservableCollection for Finfo by name
        private FInfo findInObservableCollection(ObservableCollection<FInfo> f, string targetName)
        {
            foreach (var item in f)
            {
                if (item.Name == targetName)
                {
                    return item;
                }
            }
            return null;
        }
        #endregion  
    }
}
