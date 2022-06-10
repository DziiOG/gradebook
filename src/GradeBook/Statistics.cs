using System.Collections.Generic;
using System;
namespace GradeBook
{
    public class Statistics
    {
        public Statistics(List<double> grades)
        {
            Average = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
            Grades = grades;
        }

        public Statistics GetStatistics()
        {
            double sum = 0.0;
            for (int i = 0; i < Grades.Count; i++)
            {
                High = Math.Max(Grades[i], High);
                Low = Math.Min(Grades[i], Low);
                sum += Grades[i];
            }
            Average = sum / Grades.Count;
            SetLetterGrade(Average);
            return this;
        }

        public void SetLetterGrade(double grade)
        {
            switch (grade)
            {
                case double avg when avg >= 90.0:
                    Letter = 'A';
                    break;
                case double avg when avg >= 80.0:
                    Letter = 'B';
                    break;
                case double avg when avg >= 70.0:
                    Letter = 'C';
                    break;
                case double avg when avg >= 60.0:
                    Letter = 'D';
                    break;
                default:
                    Letter = 'F';
                    break;
            }
        }


        public double Average;
        public double High;
        public double Low;
        public char Letter;
        public List<double> Grades;

        private double sum;

    }
}