using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_SQL.Model
{
    internal class Menu
    {
        public static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Main Menu:");
                Console.WriteLine("_________________________________________________________");
                Console.WriteLine("1. Get all students");
                Console.WriteLine("2. Get all students in a specific class");
                Console.WriteLine("3. Add new staff");
                Console.WriteLine("4. Get staff");
                Console.WriteLine("5. Grades from the last month");
                Console.WriteLine("6. Average grade/course");
                Console.WriteLine("7. Add new students");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                Console.ResetColor();
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.ResetColor();
                            Students.GetStudentsMenu();
                            break;
                        case 2:
                            Console.Clear();
                            Klass.GetAllClass();
                            Klass.GetClass();

                            break;
                        case 3:
                            Console.Clear();
                            Staff.AddStaff();
                            break;
                        case 4:
                            Console.Clear();
                            Staff.ShowStaffMenu();
                            break;
                        case 5:
                            Console.Clear();
                            Grading.Get30DaysOldGrades();
                            break;
                        case 6:
                            Console.Clear();
                            Grading.AvgGrades();
                            Grading.HighestGrades();
                            Grading.LowestGrades();
                            break;
                        case 7:
                            Console.Clear();
                            Students.AddStudent();
                            break;
                        case 0:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Program shuting down! See ya later, aligator!");
                            Console.ResetColor();
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again.");
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
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press [Enter] to return to main menu");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}
