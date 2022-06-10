using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book, IBook
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override void AddGrade(double grade)
        {
            using (StreamWriter writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public override event GradeAddedDelegate GradeAdded;
    }
}