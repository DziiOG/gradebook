using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Whitson's grade book");
            book.GradeAdded += OnGradeAdded;
            Statistics stats = book.GetUserInputAndGetStatistics();
            Console.WriteLine($"For the book name {book.Name}, Average: {stats.Average:N1}, Highest Grade : {stats.High:N1}, Lowest Grade : {stats.Low:N1} and Letter Grade : {stats.Letter}");
        }


        static void OnGradeAdded(object sender, EventArgs e){
          Console.WriteLine($"Grade was Added");
        }
    }
}
