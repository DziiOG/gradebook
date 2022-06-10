using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
            List<double> grades = ReadGradesFromFile();
            Statistics statistics = new Statistics(grades);
            return statistics.GetStatistics();
        }

        private List<double> ReadGradesFromFile(){
            string fileContent = File.ReadAllText($"{Name}.txt");
            string[] arrayString = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> listString = new List<string>(arrayString);
            List<double> grades = listString.Select(str => Double.Parse(str)).ToList();
            return grades;
        }

        public override event GradeAddedDelegate GradeAdded;
    }
}