using System.Collections.Generic;
using System.IO;

namespace TestTask
{
    //logic of comparing and storing information in directories
    class DComparer
    {
        private string path1;

        public string Path1
        {
            set
            {
                path1 = value;
                reload();
            }

            get
            {
                return path1;
            }
        }

        private string path2;

        public string Path2
        {
            set
            {
                path2 = value;
                reload();
            }

            get
            {
                return path2;
            }
        }

        public List<FInfo> Files { get; }

        public DComparer()
        {
            Files = new List<FInfo>();
        }

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
                var fileInf = Files.Find(f => f.Name == inf.Name);
                if (fileInf != null)
                {
                    if (fileInf.Size == inf.Length)
                    {
                        fileInf.State = state.SameSize;
                        fInf.State = state.SameSize;
                    }
                    else
                    {
                        fileInf.State = state.DifSize;
                        fInf.State = state.DifSize;
                    }
                }
                else
                {
                    fInf.State = path == path1 ? state.First : state.Second;
                }
                Files.Add(fInf);
            }
        }
    }
}
