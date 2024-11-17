using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    
        class Employee
        {
            public int EmpId { get; set; }
            public string EmpName { get; set; }
            public string EmpCity { get; set; }
            public double EmpSalary { get; set; }
        }

        class Program
        {
            static void Main(string[] args)
            {
                List<Employee> employees = new List<Employee>();

                Console.Write("Enter the number of employees: ");
                int numberOfEmployees = int.Parse(Console.ReadLine());

                for (int i = 0; i < numberOfEmployees; i++)
                {
                    Console.WriteLine($"\nEnter details for employee {i + 1}:");
                    Console.Write("Enter Employee ID: ");
                    int empId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Employee Name: ");
                    string empName = Console.ReadLine();

                    Console.Write("Enter Employee City: ");
                    string empCity = Console.ReadLine();

                    Console.Write("Enter Employee Salary: ");
                    double empSalary = double.Parse(Console.ReadLine());

                employees.Add(new Employee
                {
                    EmpId = empId,
                    EmpName = empName,
                    EmpCity = empCity,
                    EmpSalary = empSalary
                });
                }

                while (true)
                {
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Display all employees");
                    Console.WriteLine("2. Display employees with salary greater than 45000");
                    Console.WriteLine("3. Display employees from Bangalore region");
                    Console.WriteLine("4. Display employees sorted by name in ascending order");
                    Console.WriteLine("5. Completed");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            DisplayAllEmployees(employees);
                            break;
                        case 2:
                            DisplayEmployeesBySalary(employees, 45000);
                            break;
                        case 3:
                            DisplayEmployeesByCity(employees, "Bangalore");
                            break;
                        case 4:
                            DisplayEmployeesSortedByName(employees);
                            break;
                        case 5:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }

            static void DisplayAllEmployees(List<Employee> employees)
            {
                Console.WriteLine("\nAll Employees:");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                }
            }

            static void DisplayEmployeesBySalary(List<Employee> employees, double salary)
            {
                Console.WriteLine($"\nEmployees with salary greater than {salary}:");
                var result = employees.Where(emp => emp.EmpSalary > salary).ToList();
                if (result.Any())
                {
                    foreach (var emp in result)
                    {
                        Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }
            }

            static void DisplayEmployeesByCity(List<Employee> employees, string city)
            {
                Console.WriteLine($"\nEmployees from {city}:");
                var result = employees.Where(emp => emp.EmpCity.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
                if (result.Any())
                {
                    foreach (var emp in result)
                    {
                        Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }
            }

            static void DisplayEmployeesSortedByName(List<Employee> employees)
            {
                Console.WriteLine("\nEmployees sorted by name in ascending order:");
                var result = employees.OrderBy(emp => emp.EmpName).ToList();
                foreach (var emp in result)
                {
                    Console.WriteLine($"ID: {emp.EmpId}, Name: {emp.EmpName}, City: {emp.EmpCity}, Salary: {emp.EmpSalary}");
                }
            }
        }
    }
   
