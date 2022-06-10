using System.Collections.Generic;
using System;

namespace GradeBook
{
   public class InMemoryBook : Book, IBook
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} grade");
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics statistics = new Statistics(grades);
            return statistics.GetStatistics();
        }

        private List<double> grades;

        public override event GradeAddedDelegate GradeAdded;

        public const string CATEGORY = "Science";
    }

}