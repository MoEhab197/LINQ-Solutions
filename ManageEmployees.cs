using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_LINQ
{
    internal class ManageEmployees
    {
        /// <summary>
        /// Retrieves all the employees in the data.txt file.
        /// </summary>
        /// <param name="dataFilePath"></param>
        /// <returns></returns>
        public static List<Employee> GetEmployees(string dataFilePath)
        {
            string[] lines = File.ReadAllLines(dataFilePath);

            // Splitting each line with comma followed by a space:
            string[][] employeesData = lines.Select(line => line.Split(new string[] { ", " }, StringSplitOptions.None)).ToArray();

            // Or:
            //string[][] employeesData = lines.Select(line => line.Split(',').Select(prop => prop.Trim()).ToArray()).ToArray();

            return employeesData.Select(empData => new Employee(empData)).ToList();
        }

        /// <summary>
        /// Prints all the data of the passed <paramref name="employees"/>.
        /// </summary>
        /// <param name="employees"></param>
        public static void Print(List<Employee> employees)
        {
            Console.WriteLine($"Number of Employees: {employees.Count}");
            Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");

            foreach (Employee emp in employees)
                Console.WriteLine($"{emp}\n");
        }

        /// <summary>
        /// Prints all the items in the passed list of <paramref name="data"/>, each in a line.
        /// </summary>
        /// <param name="data"></param>
        public static void Print(List<string> data)
        {
            foreach (string item in data)
                Console.WriteLine(item);
        }
        //Add a method to filter and print Data Scientists:
        public static void PrintDataScientists(List<Employee> employees)
        {
            var dataScientists = employees
                .Where(emp => emp.Position == "Data Scientist")
                .ToList();

            Console.WriteLine($"Number of Data Scientists: {dataScientists.Count}");
            Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");

            foreach (var dataScientist in dataScientists)
            {
                Console.WriteLine($"{dataScientist}\n");
            }
        }

        //Add a method to calculate and print the average salary of Software Development employees
        public static void PrintAverageSalaryInSoftwareDevelopment(List<Employee> employees)
        {
            var softwareDevPositions = new List<string>
            {
              "Software Engineer",
              "Frontend Developer",
              "Backend Developer",
              "Full Stack Developer",
              "Senior Software Engineer",
              "Software Architect"
            };

            var averageSalary = employees
                .Where(emp => softwareDevPositions.Contains(emp.Position))
                .Average(emp => emp.Salary);

            Console.WriteLine($"Average Salary for Software Development Department: {averageSalary:F2}");
        }

        //Add a method to find and print the data of the non-managerial female employee with the highest total income
        public static void PrintHighestPaidNonManagerFemale(List<Employee> employees)
        {
            var highestPaidEmployee = employees
                .Where(emp => !IsManagerialPosition(emp.Position) && !emp.IsMale) // Filtering non-managerial females
                .OrderByDescending(emp => emp.Salary + emp.Bonus) // Sorting by total compensation
                .FirstOrDefault(); // Getting the highest paid

            if (highestPaidEmployee != null)
            {
                Console.WriteLine("Non-Managerial Female Employee with Highest Salary (Including Bonus):");
                Console.WriteLine(highestPaidEmployee);
            }
            else
            {
                Console.WriteLine("No non-managerial female employees found.");
            }
        }

        // Helper method to check if a position is managerial
        private static bool IsManagerialPosition(string position)
        {
            var managerialKeywords = new List<string> { "Manager", "Director", "CEO" };
            return managerialKeywords.Any(keyword => position.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        //method to fetch HR and IT employees' nationalities:
        public static void PrintNationalitiesOfHrAndItEmployees(List<Employee> employees)
        {
            var validPositions = new List<string>
            {
              "HR Manager",
              "HR Specialist",
              "HR Coordinator",
              "IT Manager",
              "IT Specialist",
              "IT Support Specialist"
        // Include any other valid IT roles here if necessary
           };

            var hrAndItNationalities = employees
                .Where(emp => validPositions.Contains(emp.Position, StringComparer.OrdinalIgnoreCase))
                .Select(emp => emp.Nationality)
                .Distinct() // To avoid repeated nationalities
                .OrderBy(nationality => nationality) // Sorting alphabetically
                .ToList();
            // Print the number of nationalities found
            Console.WriteLine($"Number of distinct nationalities of HR and IT employees: {hrAndItNationalities.Count}");

            if (hrAndItNationalities.Any())
            {
                Console.WriteLine("Nationalities of HR and IT employees:");
                foreach (var nationality in hrAndItNationalities)
                {
                    Console.WriteLine(nationality);
                }
            }
            else
            {
                Console.WriteLine("No HR or IT employees found.");
            }
        }
        //Add a method to print first employed data analyst
        public static void PrintFirstEmployedDataAnalyst(List<Employee> employees)
        {
            var firstDataAnalyst = employees
                .Where(emp => emp.Position.Contains("Data Analyst")) // Check if the position contains "Data Analyst"
                .OrderBy(emp => emp.JoiningDate) // Order by joining date
                .FirstOrDefault(); // Get the first one

            if (firstDataAnalyst != null)
            {
                Console.WriteLine("First Employed Data Analyst:");
                Console.WriteLine($"Name: {firstDataAnalyst.Name}");
                Console.WriteLine($"Email: {firstDataAnalyst.Email}");
                Console.WriteLine($"Joining Date: {firstDataAnalyst.JoiningDate.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("No Data Analysts found.");
            }
        }
        //Add a method to print position of lowest salary
        public static void PrintPositionOfLowestSalary(List<Employee> employees)
        {
            var lowestSalaryEmployee = employees
                .OrderBy(emp => emp.Salary + emp.Bonus) // Order by total compensation
                .FirstOrDefault(); // Get the employee with the lowest total compensation

            if (lowestSalaryEmployee != null)
            {
                Console.WriteLine($"Position of the Employee with Lowest Salary (Including Bonus): {lowestSalaryEmployee.Position}");
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }
        //Add a method to print male managerial employees above 45
        public static void PrintMaleManagerialEmployeesAbove45(List<Employee> employees)
        {
            // Define managerial positions explicitly
            var managerialPositions = new[] { "Manager", "Director", "CEO", "Chief Financial Director", "IT Manager", "Operations Director", "Project Manager" };

            var result = employees
                .Where(emp => emp.IsMale &&
                              managerialPositions.Contains(emp.Position) &&
                              emp.Age > 45) // Filtering conditions
                .OrderBy(emp => emp.JoiningDate) // Sorting by joining date
                .ToList(); // Creating a list for further processing

            // Print the number of employees found
            Console.WriteLine($"Number of Male Managerial Employees (Age > 45): {result.Count}");

            if (result.Any())
            {
                Console.WriteLine("Male Managerial Employees (Age > 45):\n");

                foreach (var emp in result)
                {
                    Console.WriteLine(emp);
                    Console.WriteLine(new string('-', 50)); // Line separator
                }

                // Calculating the average salary including bonus
                double averageSalary = result.Average(emp => emp.Salary + emp.Bonus);
                Console.WriteLine($"\nAverage Salary (Including Bonus): {averageSalary}");
            }
            else
            {
                Console.WriteLine("No male managerial employees above 45 found.");
            }
        }
        //Add a method to print average bonus percentage for employees hired after 2011
        public static void PrintAverageBonusPercentageForEmployeesHiredAfter2011(List<Employee> employees)
        {
            var recentEmployees = employees
                .Where(emp => emp.JoiningDate.Year > 2011) // Filtering employees hired after 2011
                .ToList();

            if (recentEmployees.Any())
            {
                // Calculate the average bonus percentage
                double averageBonusPercentage = recentEmployees
                    .Average(emp => (emp.Bonus / emp.Salary) * 100); // Bonus as percentage of salary

                Console.WriteLine($"Average Bonus Percentage for Employees Hired After 2011: {averageBonusPercentage:F2}%");
            }
            else
            {
                Console.WriteLine("No employees hired after 2011 found.");
            }
        }
        //Add a method to print oldest and youngest employees
        public static void PrintOldestAndYoungestEmployees(List<Employee> employees)
        {
            var oldestEmployee = employees
                .OrderByDescending(emp => emp.Age) // Order by age descending
                .ThenBy(emp => emp.JoiningDate)    // Then order by joining date ascending
                .FirstOrDefault(); // Get the oldest employee

            var youngestEmployee = employees
                .OrderBy(emp => emp.Age)          // Order by age ascending
                .ThenBy(emp => emp.JoiningDate)   // Then order by joining date ascending
                .FirstOrDefault(); // Get the youngest employee

            Console.WriteLine("Oldest Employee:");
            if (oldestEmployee != null)
            {
                Console.WriteLine(oldestEmployee);
            }
            else
            {
                Console.WriteLine("No employees found.");
            }

            Console.WriteLine("\nYoungest Employee:");
            if (youngestEmployee != null)
            {
                Console.WriteLine(youngestEmployee);
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }

    }
}
