using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace UddipAminA1
{
    class Program
    {
        static void employeeMenu(List<Employee> employees, List<Vacation> vacations)
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
                        addEmployee(employees, vacations);
                        break;
                    case 3:
                        updateEmployee(employees);
                        break;
                    case 4:
                        deleteEmployee(employees);
                        break;
                    default:
                        Console.WriteLine("Returning to main menu...");
                        break;
                }
            } while (input != 5);
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
                Console.WriteLine($"{"Name",-15} {"Role",-20} {"ID",-13} {"Email",-30} {"Phone",-15} {"Address",-20}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

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

        /*
         * Asks user for new employee information, then attempts to add them to the list.
         * If employee ID is NOT 9 digits, ouputs an error message and returns.
         * If phone # is NOT 10 digit outputs an error message and returns.
         * If employee with the same ID and phone # exists, prompts user to try again after updating information and returns.
         */
        static void addEmployee(List<Employee> employees, List<Vacation> vacations)
        {
            Console.WriteLine("Please enter the employee's details.");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Role: ");
            string role = Console.ReadLine();

            Console.Write("ID (9 Digits): ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone #: ");
            long phone = long.Parse(Console.ReadLine());

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.WriteLine();

            if (id.ToString().Length != 9)
            {
                Console.WriteLine("Plsease make sure the employee ID is 9 digits long.");
                Console.WriteLine();
                return;
            }

            if (phone.ToString().Length != 10)
            {
                Console.WriteLine("Plsease make sure the phone # is 10 digits long.");
                Console.WriteLine();
                return;
            }

            var exists = from emp in employees
                         where emp.Id == id || emp.Phone == phone || emp.Email.ToLower().Equals(email.ToLower())
                         select emp;
            if (exists.Any())
            {
                Console.WriteLine("That Employee already exists, please update information and try again.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Adding new employee...");
            employees.Add(new Employee(id, phone, name, address, email, role));
            Console.WriteLine("Successfully added");
            Console.WriteLine();

            long vacID;
            do
            {
                Console.Write("Enter Vacation ID for new employee (9 Digits Long): ");
                vacID = long.Parse(Console.ReadLine());

                if (vacID.ToString().Length != 9)
                {
                    Console.WriteLine("Please make sure the Vacation ID is 9 digits long.");
                }
            } while (vacID.ToString().Length != 9);

            vacations.Add(new Vacation(vacID, id, 14));
        }


        /*
         * Asks user for name and ID of employee they wish to update.
         * Looks to see if employee exists.
         * If employee exists, the user must enter all the data they wish to update, while entering data they wish to keep the same.
         * If correct formats aren't used, changes are denied and error message is shown.
         * If a new ID, email or phone # matches an existing employee's, changes are denied.
         * Once all the checks are passed, changes are made, new changes for the employee are displayed.
         */
        static void updateEmployee(List<Employee> employees)
        {
            Console.WriteLine("Search via name and ID.");
            Console.Write("Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            var exists = from emp in employees
                         where emp.Name.ToLower().Equals(name.ToLower()) && emp.Id == id
                         select emp;
            Console.WriteLine();

            if (exists.Any())
            {
                int index = employees.IndexOf(exists.First());

                Console.WriteLine("Employee found...");
                Console.WriteLine("Enter new employee details");
                Console.Write("Name: ");
                string nameNew = Console.ReadLine();

                Console.Write("Role: ");
                string roleNew = Console.ReadLine();

                Console.Write("ID (9 Digits): ");
                int idNew = int.Parse(Console.ReadLine());

                Console.Write("Email: ");
                string emailNew = Console.ReadLine();

                Console.Write("Phone #: ");
                long phoneNew = long.Parse(Console.ReadLine());

                Console.Write("Address: ");
                string addressNew = Console.ReadLine();

                if (idNew.ToString().Length != 9)
                {
                    Console.WriteLine("Plsease make sure the employee ID is 9 digits long.");
                    Console.WriteLine();
                    return;
                }

                if (phoneNew.ToString().Length != 10)
                {
                    Console.WriteLine("Plsease make sure the phone # is 10 digits long.");
                    Console.WriteLine();
                    return;
                }

                var conflict = from emp in employees
                               where emp.Id == idNew || emp.Phone == phoneNew || emp.Email.ToLower().Equals(emailNew.ToLower())
                               select emp;

                if (conflict.Any())
                {
                    Console.WriteLine("There appears to be a conflict, the ID, phone # or email already belongs to another employee");
                }
                else
                {
                    Console.WriteLine("Updating employee...");
                    employees[index].Name = nameNew;
                    employees[index].Role = roleNew;
                    employees[index].Id = idNew;
                    employees[index].Email = emailNew;
                    employees[index].Phone = phoneNew;
                    employees[index].Address = addressNew;
                    Console.WriteLine("Changes have been applied");
                    Console.WriteLine(employees[index].ToString());
                }
            }
            else
            {
                Console.WriteLine("That employee does not exist.");
            }
            Console.WriteLine();
        }

        /*
         * Asks user for name and ID of employee to be deleted.
         * Checks to see if any employee with name and ID exist.
         * If found, displays employee and doublchecks if user wishes to delete.
         * If yes...employee is deleted from list
         * If no....return from method
         */
        static void deleteEmployee(List<Employee> employees)
        {
            Console.WriteLine("Search via name and ID.");
            Console.Write("Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            var exists = from emp in employees
                         where emp.Name.ToLower().Equals(name.ToLower()) && emp.Id == id
                         select emp;
            Console.WriteLine();

            if (exists.Any())
            {
                Console.WriteLine("Employee found...");
                Console.WriteLine(exists.First().ToString());
                Console.WriteLine();
                Console.Write("Are you sure you want to remove employee (Y/N): ");
                string input = Console.ReadLine();

                if (input.ToUpper().Equals("Y"))
                {
                    Console.WriteLine("Removing employee...");
                    employees.Remove(exists.First());
                    Console.WriteLine("Successfully removed");
                }

            }
            else
            {
                Console.WriteLine("That employee does not exist.");
            }
            Console.WriteLine();
        }

        static void payrollMenu(List<Payroll> payrolls, List<Employee> employees, List<Vacation> vacations)
        {
            int input;

            do
            {
                Console.WriteLine("Welcome, please choose a command:");
                Console.WriteLine("Press 1 to insert new payroll entry");
                Console.WriteLine("Press 2 to payroll hisory for an employee");
                Console.WriteLine("Press 3 to search for a payroll");
                Console.WriteLine("Press 4 to return to main menu");

                input = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (input)
                {
                    case 1:
                        addPayroll(payrolls, employees, vacations);
                        break;
                    case 2:
                        payrollHistory(payrolls, employees);
                        break;
                    case 3:
                        searchPayroll(payrolls);
                        break;
                    default:
                        Console.WriteLine("Returning to main menu...");
                        break;
                }
            } while (input != 4);
        }
        
        /*
         * Asks the user for details included in a payroll.
         * If all checks are passed, new payroll is added.
         */        
        static void addPayroll(List<Payroll> payrolls, List<Employee> employees, List<Vacation> vacations)
        {
            Console.WriteLine("Enter payroll details");
            Console.Write("ID: ");
            long id = long.Parse(Console.ReadLine());

            Console.Write("Employee ID: ");
            int empID = int.Parse(Console.ReadLine());

            Console.Write("Hours Worked: ");
            double hoursWorked = double.Parse(Console.ReadLine());

            Console.Write("Hourly Rate: ");
            double rate = double.Parse(Console.ReadLine());

            Console.Write("Date: ");
            string date = Console.ReadLine();
            Console.WriteLine();

            if (id.ToString().Length != 11)
            {
                Console.WriteLine("Payroll ID must be 11 digits long.");
                Console.WriteLine();
                return;
            }

            if (empID.ToString().Length != 9)
            {
                Console.WriteLine("Employee ID must be 9 digits long.");
                Console.WriteLine();
                return;
            }

            var conflict = from pay in payrolls
                           where pay.Id == id
                           select pay;

            if (conflict.Any())
            {
                Console.WriteLine("Payroll with that ID already exists");
                Console.WriteLine();
                return;
            }

            var existingEmp = from emp in employees
                              where emp.Id == empID
                              select emp;

            if (!existingEmp.Any())
            {
                Console.WriteLine("That employee ID does not exist.");
                Console.WriteLine();
                return;
            }

            var vacation = from vac in vacations
                           where vac.EmployeeID == empID
                           select vac;

            payrolls.Add(new Payroll(id, hoursWorked, rate, empID, date));
            vacations[vacations.IndexOf(vacation.First())].NumDays += 1;
            Console.WriteLine("Following payroll was added.");
            Console.WriteLine(payrolls.Last().ToString());
            Console.WriteLine();
        }

        /*
         * Asks user for employee ID to see payroll history
         * If Employee ID exists AND if there are any payrolls for the employee, all payrolls for that employee ID will be displayed
         */
        static void payrollHistory(List<Payroll> payrolls, List<Employee> employees)
        {
            Console.WriteLine("Enter employee ID for whome you want to see payroll history");
            Console.Write("Employee ID: ");
            int empID = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (empID.ToString().Length != 9)
            {
                Console.WriteLine("Employee ID must be 9 digits long.");
                Console.WriteLine();
                return;
            }

            var existingEmp = from emp in employees
                              where emp.Id == empID
                              select emp;

            if (!existingEmp.Any())
            {
                Console.WriteLine("That employee ID does not exist.");
                Console.WriteLine();
                return;
            }

            var history = from payroll in payrolls
                          where payroll.EmployeeID == empID
                          orderby payroll.Date
                          select payroll;

            foreach (var item in history)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        /*
         * Asks user for payroll ID to search for payroll
         * If payroll ID exists, it will be displayed
         */
        static void searchPayroll(List<Payroll> payrolls)
        {
            Console.WriteLine("Enter payroll ID to search for");
            Console.Write("Payroll ID: ");
            long iD = long.Parse(Console.ReadLine());

            Console.WriteLine();

            if (iD.ToString().Length != 11)
            {
                Console.WriteLine("Payroll ID must be 11 digits long.");
                Console.WriteLine();
                return;
            }

            var existing = from payroll in payrolls
                              where payroll.Id == iD
                              select payroll;

            if (!existing.Any())
            {
                Console.WriteLine("That payroll ID does not exist.");
                Console.WriteLine();
                return;
            }

            foreach (var item in existing)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        static void vacationMenu(List<Vacation> vacations, List<Employee> employees)
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
                        viewVacations(vacations);
                        break;
                    case 2:
                        bookVacation(vacations, employees);
                        break;
                    case 3:
                        updateVacation(vacations);
                        break;
                    case 4:
                        removeVacation(vacations);
                        break;
                    default:
                        Console.WriteLine("Returning to main menu...");
                        break;
                }
            } while (input != 3);
        }

        /*
         * Prints out all vacations
         */
        static void viewVacations(List<Vacation> vacations)
        {
            var vacationDays = from vacation in vacations
                               orderby vacation.EmployeeID
                               select vacation;
            if (!vacationDays.Any())
            {
                Console.WriteLine("There are no vacation days");
                Console.WriteLine();
                return;
            }

            Console.WriteLine($"{"Vacation ID",-15} {"Employee ID",-15} {"Vacation Days",-5}");
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (var item in vacationDays)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        /*
         * Asks user for all details to book vacation.
         * Once all checks are passed adds the booking to the system.
         * Displays added booking.
         */
        static void bookVacation(List<Vacation> vacations, List<Employee> employees)
        {
            Console.WriteLine("Enter booking details for vacation days");
            Console.Write("ID: ");
            long id = long.Parse(Console.ReadLine());

            Console.Write("Employee ID: ");
            int empId = int.Parse(Console.ReadLine());

            Console.Write("Vacation Days: ");
            int numDays = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (id.ToString().Length != 9)
            {
                Console.WriteLine("Vacation ID must be 9 digits long.");
                Console.WriteLine();
                return;
            }

            if (empId.ToString().Length != 9)
            {
                Console.WriteLine("Employee ID must be 9 digits long.");
                Console.WriteLine();
                return;
            }

            var exists = from vac in vacations
                         where vac.Id == id
                         select vac;

            if (exists.Any())
            {
                Console.WriteLine("That vacation ID already exists.");
                Console.WriteLine();
                return;
            }

            var employeeExist = from emp in employees
                                where emp.Id == empId
                                select emp;

            if (!employeeExist.Any())
            {
                Console.WriteLine("That employee does not exist.");
                Console.WriteLine();
                return;
            }

            vacations.Add(new Vacation(id, empId, numDays));
            Console.WriteLine("Following vacation entry added");
            Console.WriteLine($"{"Vacation ID",-15} {"Employee ID",-15} {"Vacation Days",-5}");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine(vacations.Last().ToString());
            Console.WriteLine();
        }

        /*
         * Asks user for vaction ID to update.
         * If not found then returns.
         * If found prompts user to enter new number of vacation days.
         * Updates and displays vacation entry.
         */
        static void updateVacation(List<Vacation> vacations)
        {
            Console.WriteLine("Enter Vacation ID ");
            Console.Write("ID: ");
            long id = long.Parse(Console.ReadLine());

            Console.WriteLine();

            if (id.ToString().Length != 9)
            {
                Console.WriteLine("Vacation ID must be 9 digits long.");
                Console.WriteLine();
                return;
            }

            var exists = from vac in vacations
                         where vac.Id == id
                         select vac;

            if (!exists.Any())
            {
                Console.WriteLine("That vacation ID does not exist.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Enter the number of days you wish to update to");
            Console.Write("Vacation Days: ");
            int numDays = int.Parse(Console.ReadLine());

            vacations[vacations.IndexOf(exists.First())].NumDays = numDays;
            Console.WriteLine("Following vacation days have been updated");
            Console.WriteLine($"{"Vacation ID",-15} {"Employee ID",-15} {"Vacation Days",-5}");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine(vacations[vacations.IndexOf(exists.First())].ToString());
            Console.WriteLine();
        }

        /*
         * Asks user for vacation ID to be removed.
         * If not found then returns.
         * If found displays and asks user if they wish to remove.
         * If no....returns.
         * If yes...removes vacation entry.
         */
        static void removeVacation(List<Vacation> vacations)
        {
            Console.WriteLine("Enter Vacation ID ");
            Console.Write("ID: ");
            long id = long.Parse(Console.ReadLine());

            Console.WriteLine();

            if (id.ToString().Length != 9)
            {
                Console.WriteLine("Vacation ID must be 9 digits long.");
                Console.WriteLine();
                return;
            }

            var exists = from vac in vacations
                         where vac.Id == id
                         select vac;

            if (!exists.Any())
            {
                Console.WriteLine("That vacation ID does not exist.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Following vacation ID was found");
            Console.WriteLine($"{"Vacation ID",-15} {"Employee ID",-15} {"Vacation Days",-5}");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine(vacations[vacations.IndexOf(exists.First())].ToString());

            Console.WriteLine("Do you wish to remove it (Y/N?");
            string input = Console.ReadLine();

            if (input.ToUpper().Equals("N"))
            {
                Console.WriteLine("Returning to vacations menu...");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Removing selected vacation ID...");
            vacations.Remove(exists.First());

            Console.WriteLine("Successfully removed");
            Console.WriteLine();
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
                        employeeMenu(employees, vacations);
                        break;
                    case 2:
                        payrollMenu(payrolls, employees, vacations);
                        input = 2;
                        break;
                    case 3:
                        vacationMenu(vacations, employees);
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
