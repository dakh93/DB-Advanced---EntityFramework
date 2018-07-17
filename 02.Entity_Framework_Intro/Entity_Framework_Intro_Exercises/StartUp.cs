using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Entity_Framework_Intro_Exercises.Data;
using Entity_Framework_Intro_Exercises.Data.Models;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Remotion.Linq.Clauses;

namespace Entity_Framework_Intro_Exercises
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniContext();

            ////P15.Remove Towns
            //using (db)
            //{
            //    string townToRemove = Console.ReadLine();

            //    var town = db.Towns
                    
            //        .FirstOrDefault(a => a.Name == townToRemove);
    

            //    var townId = -1;
            //    if (town != null)
            //    {
            //        townId = town.TownId;
            //    }
            //    else
            //    {
            //        throw new Exception($"Town with name - {townToRemove} does not exists!!! ");
                    
            //    }

            //    var addresses = db.Addresses
            //        .Where(a => a.TownId == townId);

            //    var addressesCnt = addresses.Count();
            //    if (addresses != null)
            //    {
            //        foreach (var a in addresses)
            //        {
            //            a.TownId = null;
            //        }
            //        db.SaveChanges();

            //    }

            //    foreach (var address in addresses)
            //    {
            //        db.Addresses.Remove(address);
            //    }

            //    db.Towns.Remove(town);
            //    db.SaveChanges();

            //    var isPluralAddress = String.Empty;
            //    if (addressesCnt > 1)
            //    {
            //        isPluralAddress = "addresses";
            //    }
            //    else
            //    {
            //        isPluralAddress = "address";
            //    }
            //    Console.WriteLine($"{addressesCnt} {isPluralAddress} in {town.Name} was deleted");
            //}

            ////P14.Delete Project by Id
            //using (db)
            //{
            //    var project = db.Projects.Find(2);

            //    db.EmployeesProjects.RemoveRange(db.EmployeesProjects.Where(e => e.ProjectId == 2));

            //    db.Projects.Remove(project);
            //    db.SaveChanges();

            //    var takenProjects = db.Projects.Take(10).Select(e => e.Name);

            //    foreach (var p in takenProjects)
            //    {
            //        Console.WriteLine(p);
            //    }
            //}

            ////P13.Find Employees by First Name Starting With "Sa"
            //using (db)
            //{
            //    var employees = db.Employees
            //        .Where(e => e.FirstName.StartsWith("Sa"))
            //        .OrderBy(e => e.FirstName)
            //        .ThenBy(e => e.LastName)
            //        .Select(e => new
            //        {
            //            Name = $"{e.FirstName} {e.LastName}",
            //            JobTitle = e.JobTitle,
            //            Salary = e.Salary
            //        });

            //    foreach (var e in employees)
            //    {
            //        Console.WriteLine($"{e.Name} - {e.JobTitle} - (${e.Salary:f2})");
            //    }
            //}

            ////P12.Increase Salaries
            //using (db)
            //{
            //    var dbUpdateQuery = db.Employees
            //        .Where(e => e.Department.Name == "Engineering" ||
            //                    e.Department.Name == "Tool Design" ||
            //                    e.Department.Name == "Marketing" ||
            //                    e.Department.Name == "Information Services")

            //        .ToList();

            //    foreach (var e in dbUpdateQuery)
            //    {
            //        e.Salary += (e.Salary * 12 / 100);
            //    }
            //    db.SaveChanges();

            //    var employeesIncreased = dbUpdateQuery
            //        .OrderBy(e => e.FirstName)
            //        .ThenBy(e => e.LastName)
            //        .Select(e => new
            //        {
            //            Name = $"{e.FirstName} {e.LastName}",
            //            Salary = e.Salary
            //        })
            //        .ToList(); ;

            //    foreach (var e in employeesIncreased)
            //    {
            //        Console.WriteLine($"{e.Name} (${e.Salary:f2})");
            //    }
            //}


            ////P11.Find Latest 10 Projects
            //using (db)
            //{
            //    var projects = db.Projects
            //        .OrderByDescending(p => p.StartDate)
            //        .Take(10)
            //        .Select(p => new
            //        {
            //            ProjectName = p.Name,
            //            Description = p.Description,
            //            StartDate = p.StartDate,

            //        })
            //        .OrderBy(p => p.ProjectName)
            //        .ToList();

            //    foreach (var p in projects)
            //    {
            //        string dateFormat = "M/d/yyyy h:mm:ss tt";
            //        Console.WriteLine(p.ProjectName);
            //        Console.WriteLine(p.Description);
            //        Console.WriteLine(p.StartDate.ToString(dateFormat, new CultureInfo("EN-gb")));
            //    }
            //}

            ////P10.Departments with More Than 5 Employees
            //using (db)
            //{
            //    var departments = db.Departments
            //        .Where(e => e.Employees.Count > 5)
            //        .OrderBy(e => e.Employees.Count)
            //        .ThenBy(d => d.Name)
            //        .Select(d => new
            //        {
            //            DepartmentName = d.Name,
            //            ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
            //            Employees = d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName)

            //        })
            //        .ToList();

            //    foreach (var d in departments)
            //    {
            //        Console.WriteLine($"{d.DepartmentName} - {d.ManagerName}");

            //        foreach (var e in d.Employees)
            //        {
            //            Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            //        }
            //        Console.WriteLine(new string('-', 10));
            //    }

            //}

            ////P09.Employee 147
            //using (db)
            //{
            //    var employeeById = db.Employees
            //        .Where(e => e.EmployeeId == 147)
            //        .Select(e => new
            //        {
            //            Name = $"{e.FirstName} {e.LastName}",
            //            JobTitle = e.JobTitle,
            //            ProjectsNames = e.EmployeesProjects.Where(ep => ep.EmployeeId == 147)
            //                .Select(ep => ep.Project.Name).ToList()
            //        })
            //        .ToList();

            //    foreach (var ep in employeeById)
            //    {
            //        Console.WriteLine($"{ep.Name} - {ep.JobTitle}");

            //        foreach (var project in ep.ProjectsNames.OrderBy(p => p))
            //        {
            //            Console.WriteLine(project);
            //        }
            //    }
            //}

            ////P08.Addresses by Town
            //using (db)
            //{


            //    var addresses = db.Addresses
            //        .OrderByDescending(e => e.Employees.Count)
            //        .ThenBy(e => e.Town.Name)
            //        .ThenBy(e => e.AddressText)
            //        .Select(e => new
            //        {
            //            EmployeesCount = e.Employees.Count,
            //            TownName = e.Town.Name,
            //            AddressText = e.AddressText
            //        })
            //        .Take(10)
            //        .ToList();

            //    foreach (var address in addresses)
            //    {
            //        Console.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");

            //    }
            //}


            ////P07.Employees and ProjectsNames
            //using (db)
            //{
            //    var employeesProjects = db.Employees
            //        .Where
            //        (
            //            e =>
            //                e.EmployeesProjects.Any(ep =>
            //                    ep.Project.StartDate.Year >= 2001 &&
            //                    ep.Project.StartDate.Year <= 2003)
            //        )
            //        .Take(30)
            //        .Select(e => new
            //        {
            //            FullName = $"{e.FirstName} {e.LastName}",
            //            ManagerNameFullName = $"{e.Manager.FirstName} {e.Manager.LastName}",
            //            ProjectsNames = e.EmployeesProjects.Select(ep => new
            //            {
            //                ep.Project.Name,
            //                ep.Project.StartDate,
            //                ep.Project.EndDate
            //            })
            //        });

            //    string dateFormat = "M/d/yyyy h:mm:ss tt";
            //    foreach (var ep in employeesProjects)
            //    {
            //        Console.WriteLine($"{ep.FullName} - Manager: {ep.ManagerNameFullName}");

            //        foreach (var project in ep.ProjectsNames)
            //        {
            //            Console.Write($"--{project.Name} - {project.StartDate.ToString(dateFormat, new CultureInfo("EN-gb"))} - ");
            //            Console.WriteLine(project.EndDate == null
            //                ? "not finished"
            //                : $"{project.EndDate.Value.ToString(dateFormat, new CultureInfo("EN-gb"))}");
            //        }
            //    }


            //}

            ////P06.Adding a New Address and Updating Employee
            //using (db)
            //{
            //    var address = new Address()
            //    {
            //        AddressText = "Vitoshka 15",
            //        TownId = 4
            //    };

            //    db.Addresses.Add(address);

            //    var employee = db.Employees
            //        .FirstOrDefault(e => e.LastName == "Nakov");

            //    employee.Address = address;

            //    db.SaveChanges();

            //    var addressTexts = db.Employees
            //        .OrderByDescending(e => e.AddressId)
            //        .Take(10)
            //        .Select(e => e.Address.AddressText)
            //        .ToList();

            //    foreach (var aText in addressTexts)
            //    {
            //        Console.WriteLine(aText);
            //    }


            //}

            ////P05. Employees From Research and Development department
            //using (db)
            //{
            //    var selectedEmployees = db.Employees
            //        .Where(e => e.Department.Name == "Research and Development")
            //        .OrderBy(e => e.Salary)
            //        .ThenByDescending(e => e.FirstName)
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            e.Department,
            //            e.Salary
            //        })
            //        .ToList();

            //    foreach (var e in selectedEmployees)
            //    {
            //        Console.WriteLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
            //    }
            //}

            //P04 Employees with Salary Over 50 000
            //using (db)
            //{
            //    var employees = db.Employees
            //            .Where(e => e.Salary > 50000)
            //            .OrderBy(e => e.FirstName)
            //            .Select(e => new
            //            {
            //                e.FirstName
            //            })
            //            .ToList();

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine(employee.FirstName);
            //    }
            //}

            //P03 Employees Full Information
            //using (db)
            //{
            //    var employees = db.Employees.ToList();

            //    foreach (var employee in employees.OrderBy(e => e.EmployeeId))
            //    {
            //        var firstName = employee.FirstName;
            //        var lastName = employee.LastName;
            //        var midName = employee.MiddleName;

            //        var jobTitle = employee.JobTitle;
            //        var salary = employee.Salary;

            //        Console.WriteLine($"{firstName} {lastName} {midName} {jobTitle} {salary:f2}");
            //    }
            //}


        }
    }
}
