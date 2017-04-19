using System;

namespace TestTask
{

    enum state { First, Second, SameSize, DifSize }

    class FInfo
    {
        public string Name { get; set; } //Name of the file
        public long Size { get; set; } //Size of the file
        public DateTime Date { get; set; } //Last time file was changed
        public state State { get; set; } //One of the states written below
        static string[] Description = { "First directory", "Second directory",
                    "In both directories with same size", "In both directories with diferent size" };

        public string StateDescription
        {
            get
            {
                return Description[(int)State];
            }
        }
    }
}
