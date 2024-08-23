using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using WorkersManager.Core.Models;
using WorkersManager.Core.Repositories;
using WorkersManager.Core.Services;

namespace ConsoleApp
{
    public class Program
    {
        private static IEmployeeService _employeeService;

        public static async Task Main(string[] args)
        {
            var mongoClient = new MongoClient("mongodb+srv://Puzzles:0JhnqCzn1toKhSTZ@cluster0.ubg9w.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            IEmployeeDB employeeDb = new EmployeeDB(mongoClient);
            _employeeService = new EmployeeService(employeeDb);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Employee Management System ---");
                Console.WriteLine("1. Add Office Employee");
                Console.WriteLine("2. Add Production Employee");
                Console.WriteLine("3. View All Office Employees");
                Console.WriteLine("4. View All Production Employees");
                Console.WriteLine("5. Update Office Employee");
                Console.WriteLine("6. Update Production Employee");
                Console.WriteLine("7. Delete Office Employee");
                Console.WriteLine("8. Delete Production Employee");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Enter age: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write("Enter department: ");
                        string department = Console.ReadLine();

                        var officeEmployee = new OfficeEmployee(name, lastName, age, department);
                        await _employeeService.AddOfficeEmployee(officeEmployee);
                        Console.WriteLine("Office Employee added successfully.");
                        break;
                    case "2":
                        Console.Write("Enter first name: ");
                        name = Console.ReadLine();

                        Console.Write("Enter last name: ");
                        lastName = Console.ReadLine();

                        Console.Write("Enter age: ");
                        age = int.Parse(Console.ReadLine());

                        Console.Write("Enter shift: ");
                        string shift = Console.ReadLine();

                        var productionEmployee = new ProductionEmployee(name, lastName, age, shift);
                        await _employeeService.AddProductionEmployee(productionEmployee);
                        Console.WriteLine("Production Employee added successfully.");
                        break;
                    case "3":
                        var officeEmployees = await _employeeService.GetAllOfficeEmployees();
                        Console.WriteLine("\n--- Office Employees ---");
                        foreach (var employee in officeEmployees)
                        {
                            Console.WriteLine($"ID: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}, Department: {employee.Department}");
                        }
                        break;
                    case "4":
                        var productionEmployees = await _employeeService.GetAllProductionEmployees();
                        Console.WriteLine("\n--- Production Employees ---");
                        foreach (var employee in productionEmployees)
                        {
                            Console.WriteLine($"ID: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Age: {employee.Age}, Shift: {employee.Shift}");
                        }
                        break;
                    case "5":
                        Console.Write("Enter Office Employee ID to Update: ");
                        int officeId = int.Parse(Console.ReadLine());

                        Console.Write("Enter New First Name: ");
                        name = Console.ReadLine();

                        Console.Write("Enter New Last Name: ");
                        lastName = Console.ReadLine();

                        Console.Write("Enter New Age: ");
                        age = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Department: ");
                        department = Console.ReadLine();

                        var updatedOfficeEmployee = new OfficeEmployee(name, lastName, age, department) { Id = officeId };
                        await _employeeService.ModifyOfficeEmployee(updatedOfficeEmployee);
                        Console.WriteLine("Office Employee updated successfully.");
                        break;
                    case "6":
                        Console.Write("Enter Production Employee ID to Update: ");
                        int productionId = int.Parse(Console.ReadLine());

                        Console.Write("Enter New First Name: ");
                        name = Console.ReadLine();

                        Console.Write("Enter New Last Name: ");
                        lastName = Console.ReadLine();

                        Console.Write("Enter New Age: ");
                        age = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Shift: ");
                        shift = Console.ReadLine();

                        var updatedProductionEmployee = new ProductionEmployee(name, lastName, age, shift) { Id = productionId };
                        await _employeeService.ModifyingProductionEmployee(updatedProductionEmployee);
                        Console.WriteLine("Production Employee updated successfully.");
                        break;
                    case "7":
                        Console.Write("Enter Office Employee ID to Delete: ");
                        officeId = int.Parse(Console.ReadLine());

                        await _employeeService.DeleteOfficeEmployee(officeId);
                        Console.WriteLine("Office Employee deleted successfully.");
                        break;
                    case "8":
                        Console.Write("Enter Production Employee ID to Delete: ");
                        productionId = int.Parse(Console.ReadLine());

                        await _employeeService.DeleteProductionEmployee(productionId);
                        Console.WriteLine("Production Employee deleted successfully.");
                        break;
                    case "9":
                        exit = true;
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}