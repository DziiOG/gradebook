using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} grade");
            }
        }

        public Statistics GetStatistics()
        {
            Statistics stats = new Statistics();
            stats.Average = 0.0;
            stats.High = double.MinValue;
            stats.Low = double.MaxValue;
            double sum = 0.0;
            for (int i = 0; i < grades.Count; i++)
            {
                stats.High = Math.Max(grades[i], stats.High);
                stats.Low = Math.Min(grades[i], stats.Low);
                sum += grades[i];
            }
            stats.Average = sum / grades.Count;
            SetLetterGrade(stats);
            return stats;
        }

        public void SetLetterGrade(Statistics stats)
        {
            switch (stats.Average)
            {
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
        }
        public List<double> GetGrades()
        {
            return grades;
        }

        public Statistics GetUserInputAndGetStatistics()
        {
            string input;
            bool stop = false;
            do
            {
                Console.WriteLine("Please Ender a Grade or 'Q' or 'q' to quit");
                input = Console.ReadLine();
                if (String.Equals(input.ToLower(), "q"))
                {
                    stop = true;
                }
                else
                {
                    bool isValidDouble = Double.TryParse(input, out double result);
                    if (isValidDouble)
                    {
                        try
                        {
                            double grade = Double.Parse(input);
                            AddGrade(grade);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("**");
                        }

                    }
                }

            } while (!stop);

            Statistics statistics = GetStatistics();

            return statistics;
        }


        private List<double> grades;

        public string Name
        {
            get;
            set;
        }

        public const string CATEGORY = "Science";
    }
}