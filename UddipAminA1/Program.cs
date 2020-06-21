using System;
using System.Collections;
using System.Collections.Generic;

namespace UddipAminA1
{
    class Program
    {
        static int mainMenu()
        {
            Console.WriteLine("Welcome, please choose a command:");
            Console.WriteLine("Press 1 to modify employees");
            Console.WriteLine("Press 2 to add payroll");
            Console.WriteLine("Press 3 to view vacation days");
            Console.WriteLine("Press 4 to exit program");

            return int.Parse(Console.ReadLine());
        }

        static void employeeMenu()
        {
            int input;

            do
            {
                Console.WriteLine("Welcome, please choose a command:");
                Console.WriteLine("Press 1 to list all employees");
                Console.WriteLine("Press 2 to add new employee");
                Console.WriteLine("Press 3 to update employee");
                Console.WriteLine("Press 4 to delete employee");
                Console.WriteLine("Press 5 to return to main menu");

                input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (input)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Returning to main menu...");
                        break;
                }
            } while (input != 5);
        }

        static void payrollMenu()
        {
            int input;

            do
            {
                Console.WriteLine("Welcome, please choose a command:");
                Console.WriteLine("Press 1 to insert new payroll entry");
                Console.WriteLine("Press 2 to payroll hisory for an employee");
                Console.WriteLine("Press 3 to return to main menu");

                input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (input)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Returning to main menu...");
                        break;
                }
            } while (input != 3);
        }

        static void vacationMenu()
        {
            List<Employee> employees = new List<Employee>();
            List<Payroll> payrolls = new List<Payroll>();
            List<Vacation> vacations = new List<Vacation>();
            int input;

            employees.Add(new Employee());
            do
            {
                Console.WriteLine("Welcome, please choose a command:");
                Console.WriteLine("Press 1 to view vacation days");
                Console.WriteLine("Press 2 to book new vacation day");
                Console.WriteLine("Press 3 to update vacation day");
                Console.WriteLine("Press 4 to remove vacation day");
                Console.WriteLine("Press 5 to return to main menu");

                input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (input)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Returning to main menu...");
                        break;
                }
            } while (input != 3);
        }

        static void Main(string[] args)
        {
            
            int input;

            do
            {
                input = mainMenu();
                Console.WriteLine();

                switch (input)
                {
                    case 1:
                        employeeMenu();
                        break;
                    case 2:
                        payrollMenu();
                        input = 2;
                        break;
                    case 3:
                        vacationMenu();
                        input = 3;
                        break;
                    default:
                        Console.WriteLine("Exiting program...");
                        break;
                }

            } while (input != 4);
        }
    }
}
