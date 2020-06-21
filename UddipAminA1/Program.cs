using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UddipAminA1
{
    class Program
    {
        //Modify to use for all
        public void addEmployee(Employee employee)
        {

        }

        //Modify to use for all
        public void deleteEmployee()
        {

        }

        //Modify to use for all
        public void updateEmployee()
        {

        }

        /*
         * View a list of all employees ordered by name
         */
        static void viewEmployees(List<Employee> employees)
        {
            var nameSorted = from emp in employees
                             orderby emp.Name
                             select emp;
            if (nameSorted.Any())
            {
                Console.WriteLine($"{"Name",-15} {"Role",-20} {"ID",-13} {"Email",-30} {"Phone",-15}");
                Console.WriteLine("----------------------------------------------------------------------------------------------");

                foreach (var item in nameSorted)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{"N/A",-15} {"N/A",-20} {"N/A",-13} {"N/A",-25} {"N/A",-15}");
            }
        }

        static int mainMenu()
        {
            Console.WriteLine("Welcome, please choose a command:");
            Console.WriteLine("Press 1 to modify employees");
            Console.WriteLine("Press 2 to add payroll");
            Console.WriteLine("Press 3 to view vacation days");
            Console.WriteLine("Press 4 to exit program");

            return int.Parse(Console.ReadLine());
        }

        static void employeeMenu(List<Employee> employees)
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
                        viewEmployees(employees);
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
            int input;

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

        /*
         * Initializes the collections 
         */
        static void initCollections(List<Employee> emp, List<Payroll> pay, List<Vacation> vac)
        {
            emp.Add(new Employee(123456789, 4167834561, "John Doe", "2121 Bruce St.", "john.doe@gmail.com", "President"));
            emp.Add(new Employee(789456123, 4167539518, "Steven King", "800 Main St.", "steven.king@gmail.com", "Vice President"));
            emp.Add(new Employee(456789123, 2894567897, "Kathrine Gell", "55 Walker Cresent", "kathrine.gell@gmail.com", "Accounting Manager"));
            emp.Add(new Employee(159753456, 5198461358, "Sussy Lee", "55-Unit 1 Downy Rd.", "sussy.lee@gmail.com", "Sales Manager"));
            emp.Add(new Employee(951753852, 2898354875, "Jake Doyle", "4568 Hamline Ave.", "jake.doyle@gmail.com", "Bussiness Analyst"));

            pay.Add(new Payroll(10258974635, 80, 70, 123456789, "January 17, 2020"));
            pay.Add(new Payroll(45681235074, 65, 60, 789456123, "January 17, 2020"));
            pay.Add(new Payroll(51236807462, 50, 45, 456789123, "January 17, 2020"));
            pay.Add(new Payroll(32054689501, 45, 40, 159753456, "January 17, 2020"));
            pay.Add(new Payroll(90250468732, 55, 50, 951753852, "January 17, 2020"));

            vac.Add(new Vacation(102546835, 123456789, 21));
            vac.Add(new Vacation(456823241, 789456123, 21));
            vac.Add(new Vacation(580260351, 456789123, 18));
            vac.Add(new Vacation(908746513, 159753456, 14));
            vac.Add(new Vacation(654813549, 951753852, 16));
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Payroll> payrolls = new List<Payroll>();
            List<Vacation> vacations = new List<Vacation>();

            int input;

            initCollections(employees, payrolls, vacations);

            do
            {
                input = mainMenu();
                Console.WriteLine();

                switch (input)
                {
                    case 1:
                        employeeMenu(employees);
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
