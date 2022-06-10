using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Whitson's grade book");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
            Statistics stats = book.GetStatistics();
            Console.WriteLine($"For the book name {book.Name}, Average: {stats.Average:N1}, Highest Grade : {stats.High:N1}, Lowest Grade : {stats.Low:N1} Letter Grade : {stats.Letter}");
        }

        public static void EnterGrades(IBook book)
        {
            bool stop = false;
            do
            {
                Console.WriteLine("Please Ender a Grade or 'Q' or 'q' to quit");
                string input = Console.ReadLine();
                if (String.Equals(input.ToLower(), "q"))
                {
                    stop = true;
                }
                else
                {
                    bool isValidDouble = Double.TryParse(input, out double result);
                    if (isValidDouble)
                    {
                        ParseAndAddGrade(book, input);
                    }
                }

            } while (!stop);

        }

        public static void ParseAndAddGrade(IBook book, string input)
        {
            try
            {
                double grade = Double.Parse(input);
                book.AddGrade(grade);
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
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"Grade was Added");
        }
    }
}
