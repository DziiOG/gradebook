using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {

        public Book (string name){
            grades = new List<double>();
            Name = name;
        }

        public List<double> AddGrade(double grade){
            grades.Add(grade);
            return grades;
        }

        public Statistics GetStatistics(){
           Statistics stats = new Statistics();
           stats.Average = 0.0;
           stats.High =  double.MinValue;
           stats.Low = double.MaxValue;
           double sum = 0.0;
           foreach (double grade in grades){
              stats.High = Math.Max(grade, stats.High);
              stats.Low  = Math.Min(grade, stats.Low);
              sum += grade;
           }
          stats.Average = sum / grades.Count;
          return stats;
        }

        
        private List<double> grades;
        public string Name;

    }
}