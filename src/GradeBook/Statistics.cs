using System.Collections.Generic;
using System;
namespace GradeBook
{
    public class Statistics
    {
        public Statistics(List<double> numbers)
        {
            High = double.MinValue;
            Low = double.MaxValue;
            this.numbers = numbers;
            sum = 0.0;
            count = 0;
        }
        public Statistics(List<string> stringNumbers){
            High = double.MinValue;
            Low = double.MaxValue;
            this.stringNumbers = stringNumbers;
            sum = 0.0;
            count = 0;
        }

        public void Add(double number)
        {
            sum += number;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
            count++;
        }
        public Statistics GetStatistics()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Add(numbers[i]);
            }
            return this;
        }

        public char SetLetterGrade(double number)
        {
            switch (number)
            {
                case double avg when avg >= 90.0:
                    return 'A';
                case double avg when avg >= 80.0:
                    return 'B';
                case double avg when avg >= 70.0:
                    return 'C';
                case double avg when avg >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
        }


        public double Average
        {
            get
            {
                return sum / count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                return SetLetterGrade(Average);
            }
        }
        private List<double> numbers;
        private List<string> stringNumbers;

        private double sum;
        private double count;

    }
}