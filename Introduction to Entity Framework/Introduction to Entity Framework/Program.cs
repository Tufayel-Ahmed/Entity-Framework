using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_to_Entity_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (EF_DBEntities eF_DBEntities = new EF_DBEntities())
            {
                //Print Department Details
                List<Department> departments= eF_DBEntities.Departments.ToList();
                Console.WriteLine("Department Details");
                foreach (var department in departments)
                {
                    Console.WriteLine($"Department = {department.Name}, Location = {department.Location}");
                }
                Console.WriteLine();

                //Print Employee Details
                List<Employee> employees = eF_DBEntities.Employees.ToList();
                Console.WriteLine("Employee Details");
                foreach (var employee in employees)
                {                   
                        Console.WriteLine($"Name = {employee.Name}, Email = {employee.Email}, Gender = {employee.Gender}, Salary = {employee.Salary}");
                }
                Console.WriteLine();

                //Print Employee Details By Department
                List<Department> employeeByDepartments = eF_DBEntities.Departments.ToList();
                Console.WriteLine("Employee Details By Department");
                Console.WriteLine();
                foreach (var employeeByDepartment in employeeByDepartments)
                {
                    Console.WriteLine($"Department = {employeeByDepartment.Name}, Location = {employeeByDepartment.Location}");
                    foreach (Employee employeedetails in employeeByDepartment.Employees)
                    {
                        Console.WriteLine($"Name = {employeedetails.Name}, Email = {employeedetails.Email}, Gender = {employeedetails.Gender}, Salary = {employeedetails.Salary}");
                    }
                    Console.WriteLine();
                }

                Console.ReadKey();
            }
        }
    }
}
