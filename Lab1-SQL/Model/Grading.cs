using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_SQL.Model
{
    internal class Grading
    {
        public static void Get30DaysOldGrades()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Grades that are 30days and older...");
                Console.WriteLine("_________________________________________________________");
                Console.ResetColor();
                string sql = "SELECT FirstName, LastName, CourseName, Grade, GradeDate FROM FinalGrade " +
                    "JOIN Student ON Student.StudentId = FinalGrade.StudentId " +
                    "JOIN Course ON Course.CourseId = FinalGrade.CourseId " +
                    "JOIN Grading ON Grading.GradeId = FinalGrade.GradeId " +
                    "WHERE GradeDate <= DATEADD(month, -1, GETDATE())";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string courseName = reader.GetString(2);
                            int grade = reader.GetInt32(3);
                            DateTime gradeDate = reader.GetDateTime(reader.GetOrdinal("GradeDate"));

                            Console.WriteLine($"Name: {firstName} {lastName} \tCourse: {courseName} \tGrade: {grade} \tDate: {gradeDate.ToString("yyyy-MM-dd")}");
                        }
                    }
                }
            }
        }
        public static void AvgGrades()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Grades for every course...");
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("Average grade:");
            Console.ResetColor();
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlAvg = "select CourseName, AVG (Grade) as 'Avrage Grade' from FinalGrade " +
                    "join Student on Student.StudentId = FinalGrade.StudentId " +
                    "join Course on Course.CourseId = FinalGrade.CourseId " +
                    "join Grading on Grading.GradeId = FinalGrade.GradeId " +
                    "group by CourseName";
                using (SqlCommand command1 = new SqlCommand(sqlAvg, connection))
                {
                    using (SqlDataReader reader1 = command1.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            string courseName = reader1.GetString(0);
                            int avgGrade = reader1.GetInt32(1);

                            Console.WriteLine($"Course: {courseName} \t\tAvrage Grade: {avgGrade}");
                        }
                    }
                }

            }
        }
        public static void HighestGrades()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Highest grades:");
            Console.ResetColor();
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlMax = "select CourseName, Max (Grade) as 'Highest Grade' from FinalGrade " +
                    "join Student on Student.StudentId = FinalGrade.StudentId" +
                    " join Course on Course.CourseId = FinalGrade.CourseId " +
                    "join Grading on Grading.GradeId = FinalGrade.GradeId " +
                    "group by CourseName";
                using (SqlCommand command = new SqlCommand(sqlMax, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string courseName = reader.GetString(0);
                            int MaxGrade = reader.GetInt32(1);

                            Console.WriteLine($"Course: {courseName} \t\tHighest Grade: {MaxGrade}");
                        }
                    }
                }
            }
        }
        public static void LowestGrades()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lowest grades:");
            Console.ResetColor();
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlLowest = "select CourseName, Min (Grade) as 'Top Grade' from FinalGrade " +
                    "join Student on Student.StudentId = FinalGrade.StudentId" +
                    " join Course on Course.CourseId = FinalGrade.CourseId " +
                    "join Grading on Grading.GradeId = FinalGrade.GradeId " +
                    "group by CourseName";
                using (SqlCommand command = new SqlCommand(sqlLowest, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string courseName = reader.GetString(0);
                            int lowestGrade = reader.GetInt32(1);

                            Console.WriteLine($"Course: {courseName} \t\tLowest Grade: {lowestGrade}");
                        }
                    }
                }
            }
        }
    }
}
