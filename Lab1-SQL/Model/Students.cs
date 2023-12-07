using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_SQL.Model
{
    internal class Students
    {
        public static void GetStudentsMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Display students...");
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("Choose one of the following");
            Console.WriteLine("Sort by first name: \n[1]-ASC \n[2]-DESC \n\nSort by last name: \n[3]-ASC \n[4]-DESC");
            Console.ResetColor();
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        GetFirstNameAsc();
                        break;
                    case 2:
                        GetFirstNameDesc();
                        break;
                    case 3:
                        GetLastNameAsc();
                        break;
                    case 4:
                        GetLastNameDesc();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input!");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ResetColor();
            };
        }
        public static void GetFirstNameAsc()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT FirstName, LastName, KlassName FROM Student JOIN Klass ON Klass.KlassID = Student.KlassID ORDER BY FirstName", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName} \t\tClass: {className}");

                        }
                    }
                }
            }
        }
        public static void GetFirstNameDesc()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT FirstName, LastName, KlassName FROM Student JOIN Klass ON Klass.KlassID = Student.KlassID ORDER BY FirstName DESC", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName} \t\tClass: {className}");
                        }
                    }
                }
            }
        }
        public static void GetLastNameAsc()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT FirstName, LastName, KlassName FROM Student JOIN Klass ON Klass.KlassID = Student.KlassID ORDER BY LastName", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName} \t\tClass: {className}");
                        }
                    }
                }
            }
        }
        public static void GetLastNameDesc()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT FirstName, LastName, KlassName FROM Student JOIN Klass ON Klass.KlassID = Student.KlassID ORDER BY LastName DESC", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName} \t\tClass: {className}");
                        }
                    }
                }
            }
        }
        public static void AddStudent()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Adding new students...");
                Console.WriteLine("_________________________________________________________");
                Console.ResetColor();
                Console.Write("Enter first name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter klassID (1 for NET23, 2 for UXK23): ");
                int KlassID;
                while (!int.TryParse(Console.ReadLine(), out KlassID) || (KlassID > 2) || (KlassID == 0))
                {
                    Console.WriteLine("Invalid input. Enter ID 1-2.");
                }
                string sql = "INSERT INTO Student(FirstName, LastName, KlassID) VALUES (@FirstName, @LastName, @KlassID)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@KlassID", KlassID);

                    command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{firstName} were added to Student successfully.");
                    Console.ResetColor();
                }
            }
        }
    }
}
