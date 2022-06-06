using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
          Book book = new Book("Whitson's grade book");
          book.AddGrade(89.1);
          book.AddGrade(90.5);
          book.AddGrade(77.5);
          Statistics stats = book.GetStatistics();
          Console.WriteLine($"Average: {stats.Average:N1}, Highest Grade : {stats.High:N1} and Lowest Grade : {stats.Low:N1}");
        }
    } 
}
