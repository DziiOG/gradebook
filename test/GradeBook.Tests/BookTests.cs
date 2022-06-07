using System.Collections.Generic;
using System;
using Xunit;

namespace GradeBook.Tests;

    public class BookTests
    {
        // [Fact]
        // public void ShouldNotAddGradeGreaterThan100(){
        //     Book book = new Book("Book 1");
        //     book.AddGrade(105);
        //     List<double> grades = book.GetGrades(); 
        //     Assert.NotEqual(105, grades[0]);
        // }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            Book book = new Book("Test's book grade");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            Statistics stats = book.GetStatistics();

            // assert
            Assert.Equal(85.6, stats.Average, 1);
            Assert.Equal(90.5, stats.High, 1);
            Assert.Equal(77.3, stats.Low, 1);

        }
    }
