﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Whitson's grade book");
            Statistics stats = book.GetUserInputAndGetStatistics();
            Console.WriteLine($"Average: {stats.Average:N1}, Highest Grade : {stats.High:N1}, Lowest Grade : {stats.Low:N1} and Letter Grade : {stats.Letter}");
        }
    }
}
