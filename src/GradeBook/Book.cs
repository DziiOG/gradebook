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

        public void AddGrade(double grade){
            if(grade <= 100 && grade >= 0 ){
                grades.Add(grade);
            } else {
                Console.WriteLine("Invalid value");
            }
        }
        
        public Statistics GetStatistics(){
           Statistics stats = new Statistics();
           stats.Average = 0.0;
           stats.High =  double.MinValue;
           stats.Low = double.MaxValue;
           double sum = 0.0;
           for(int i = 0; i < grades.Count; i++ ) {
              stats.High = Math.Max(grades[i], stats.High);
              stats.Low  = Math.Min(grades[i], stats.Low);
              sum += grades[i];
           }
          stats.Average = sum / grades.Count;
          switch (stats.Average){
                case double averageGrade when averageGrade >= 90.0:
                    stats.Letter = 'A';
                    break; 
                case double averageGrade when averageGrade >= 80.0:
                    stats.Letter = 'B';
                    break; 
                case double averageGrade when averageGrade >= 70.0:
                    stats.Letter = 'C';
                    break; 
                case double averageGrade when averageGrade >= 60.0:
                    stats.Letter = 'D';
                    break; 
                default:
                    stats.Letter = 'F';
                    break; 
                
          }
          return stats;
        }

        public List<double> GetGrades(){
            return grades;
        }

        
        private List<double> grades;
        public string Name;

    }
}