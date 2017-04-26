using System;

namespace TestTask.Model
{
    enum stateType { First, Second, SameSize, DifSize }

    class FInfo
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime Date { get; set; }
        public stateType State { get; set; }

        static string[] Description = { "First directory", "Second directory",
                    "In both directories with same size", "In both directories with diferent size" };

        public string StateDescription
        {
            get { return Description[(int)State]; }
        }
    }
}
