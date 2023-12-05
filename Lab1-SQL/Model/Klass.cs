using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_SQL.Model
{
    internal class Klass
    {
        //Show all classes
        public static void GetAllClass()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Display students in a specifik class...");
                Console.WriteLine("_________________________________________________________");
                Console.ResetColor();
                connection.Open();
                int count = 1;
                using (SqlCommand command = new SqlCommand("select * from Klass", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string className = reader.GetString(1);

                            Console.WriteLine($"[{count}]Class: {className}");
                            count++;

                        }
                    }
                }
            }
        }
        //Get specifik class
        public static void GetClass()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Choose the class by their number:");
            Console.ResetColor();
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        NETMenu();
                        break;
                    case 2:
                        UXKMenu();
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
            }

        }

        //Menu for ASC DESC NET23
        public static void NETMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Display students...");
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("Choose one of the following to sort the output:");
            Console.WriteLine("\n[1]-Sort by first name (ASC)\n[2]-Sort by first name (DESC)\n[3]-Sort by last name (ASC)\n[4]-Sort by last name (DESC)");
            Console.ResetColor();
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        GetNETFirstNameASC();
                        break;
                    case 2:
                        GetNETFirstNameDESC();
                        break;
                    case 3:
                        GetNETLastNameASC();
                        break;
                    case 4:
                        GetNETLastNameDESC();
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
            }
        }

        //Menu for ASC DESC UXK23
        public static void UXKMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Display students...");
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("Choose one of the following to sort the output:");
            Console.WriteLine("\n[1]-Sort by first name (ASC)\n[2]-Sort by first name (DESC)\n[3]-Sort by last name (ASC)\n[4]-Sort by last name (DESC)");
            Console.ResetColor();
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        GetUXKFirstNameASC();
                        break;
                    case 2:
                        GetUXKFirstNameDESC();
                        break;
                    case 3:
                        GetUXKLastNameASC();
                        break;
                    case 4:
                        GetUXKLastNameDESC();
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



        //Get UXK23
        public static void GetUXK()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'UXK23'", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
        //Get UXK23 firstname ascending
        public static void GetUXKFirstNameASC()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'UXK23' order by FirstName", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
        //Get UXK23 firstname Descending
        public static void GetUXKFirstNameDESC()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'UXK23' order by FirstName DESC", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
        //Get UXK23 LastName ascending
        public static void GetUXKLastNameASC()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'UXK23' order by LastName", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
        //Get UXK23 LastName Descending
        public static void GetUXKLastNameDESC()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'UXK23' order by LastName DESC", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }

        //Get NET23
        public static void GetNET()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'NET23'", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
        //Get NET23 firstname ascending
        public static void GetNETFirstNameASC()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'NET23' order by FirstName", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
        //Get NET23 firstname Descending
        public static void GetNETFirstNameDESC()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'NET23' order by FirstName DESC", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
        //Get NET23 lastname ascending
        public static void GetNETLastNameASC()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'NET23' order by LastName", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
        //Get NET23 lastname Descending
        public static void GetNETLastNameDESC()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, KLassName from Student join Klass on Klass.KlassID = Student.KlassID where KlassName = 'NET23' order by LastName DESC", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string className = reader.GetString(2);

                            Console.WriteLine($"Name: {firstName} {lastName}, Class: {className}");

                        }
                    }
                }
            }
        }
    }
}
