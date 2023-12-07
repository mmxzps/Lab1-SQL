using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_SQL.Model
{
    internal class Staff
    {
        public static void ShowStaffMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Display Staff...");
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine("[1]-Show all staff\n[2]-Choose a specific catergory");
            Console.ResetColor();
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                switch (input)
                {
                    case 1:
                        ShowAll();
                        break;

                    case 2:
                        ChooseTitle();
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
        public static void AddStaff()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Adding new Staff...");
                Console.WriteLine("_________________________________________________________");
                Console.ResetColor();
                Console.Write("Enter first name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter title ID [1] for Teacher, [2] for Program Coordinator, [3] for Principal: ");
                int titleId;
                while (!int.TryParse(Console.ReadLine(), out titleId) || (titleId < 1 || titleId > 3))
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Enter ID 1-3.");
                    Console.ResetColor();
                }
                string sql = "INSERT INTO Staff(FirstName, LastName, TitleId) VALUES (@FirstName, @LastName, @TitleId)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@TitleId", titleId);

                    command.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{firstName} were added to Staff successfully.");
                    Console.ResetColor();
                }
            }
        }
        public static void ShowAll()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();
                using (SqlCommand command = new SqlCommand("select FirstName, LastName, Title from Staff join Title on Title.TitleId = Staff.TitleId", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string Title = reader.GetString(reader.GetOrdinal("Title"));

                            Console.WriteLine($"Name: {firstName} {lastName} \t\tTitle:{Title}");
                        }
                    }
                }
            }
        }
        public static void ChooseTitle()
        {
            string connectionString = @"Data Source=(localdb)\.;Initial Catalog=School;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Clear();
                connection.Open();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Which category do you want to see? \n-[Teacher]\n-[Program Coordinator]\n-[Principal]");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dont use number. Write the catergory!");
                Console.ResetColor();
                string chooseTitle = Console.ReadLine();

                using (SqlCommand command = new SqlCommand("select FirstName, LastName, Title from Staff join Title on Title.TitleId = Staff.TitleId where Title = @Title", connection))
                {
                    command.Parameters.AddWithValue("@Title", chooseTitle);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.Clear();
                        while (reader.Read())
                        {
                            string firstName = reader.GetString(0);
                            string lastName = reader.GetString(1);
                            string Title = reader.GetString(reader.GetOrdinal("Title"));

                            Console.WriteLine($"Name: {firstName} {lastName} \t\tTitle:{Title}");
                        }
                    }
                }
            }
        }
    }
}