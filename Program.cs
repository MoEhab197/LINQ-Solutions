using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace A6_LINQ
{
    internal class Program
    {
        private static string _dataFilePath = @"D:\000-KADD\05-10-2024\Data\Data.txt";
        private static List<Employee> _employees;



        static void Main(string[] args)
        {
            _employees = ManageEmployees.GetEmployees(_dataFilePath);
            //T1();
            //T2();
            //T3(); // the number is different for the one in the PDF, I revised it manually and the result in code is correct, please advice.
            //T4();
            //T5();
            //T6();
            //T7();
            //T8();
            //T9();
            //T10();
        }



        /// <summary>
        /// What positions are there at KAITECH? How many are there in total?
        /// </summary>
        static void T1()
        {
            var positions = _employees
         .Select(emp => emp.Position)  // Select the Position property
         .Distinct()                    // Get unique positions
         .OrderBy(position => position) // Sort positions alphabetically
         .ToList();                    // Convert to a list

            // Print positions and count
            Console.WriteLine($"Total number of unique positions: {positions.Count}\n");

            Console.WriteLine("Positions at KAITECH (sorted alphabetically):");
            foreach (var position in positions)
            {
                Console.WriteLine(position);
            }
        }

        /// <summary>
        /// Show all the data of the data Scientists in the company?
        /// </summary>
        static void T2()
        {
            // Call the method to print Data Scientists
            ManageEmployees.PrintDataScientists(_employees);
        }

        /// <summary>
        /// What is the average main salary for employees in the Software Development Department?
        /// </summary>
        static void T3()
        {
            // Call the new method to print average salary in Software Development
            ManageEmployees.PrintAverageSalaryInSoftwareDevelopment(_employees);
        }

        /// <summary>
        /// Show all data of the non-managerial female employee with the highest salary (including bonus)?
        /// </summary>
        static void T4()
        {
            // Call the new method to print highest paid non-managerial female employee (including bonus)
            ManageEmployees.PrintHighestPaidNonManagerFemale(_employees);

        }

        /// <summary>
        /// What are the Nationalities of the HR and IT employees in the company?
        /// </summary>
        static void T5()
        {
            // Call the method to print nationalities of HR and IT employees
            ManageEmployees.PrintNationalitiesOfHrAndItEmployees(_employees);

        }

        /// <summary>
        /// What is the name of the first employed Data Analyst in the company? And when?
        /// </summary>
        static void T6()
        {
            // Call the method to print the name of the first employed Data Analyst in the company? And when?
            ManageEmployees.PrintFirstEmployedDataAnalyst(_employees);
        }

        /// <summary>
        /// What is the position of the lowest salary in the company (including bonus)?
        /// </summary>
        static void T7()
        {
            // Call the method to print the position of the lowest salary in the company (including bonus)
            ManageEmployees.PrintPositionOfLowestSalary(_employees);
        }

        /// <summary>
        /// Show all data of the male employees in managerial positions in the company with age above 45 years,
        /// <br> sort them by the date they joined the company, and calculate their average salary (including bonus). </br>
        /// </summary>
        static void T8()
        {
            // Call the method to print all data of the male employees in managerial positions in the company with age above 45 years,sort them by the date they joined the company, and calculate their average salary (including bonus).
            ManageEmployees.PrintMaleManagerialEmployeesAbove45(_employees);
        }

        /// <summary>
        /// What is the average bonus (in percentage, relative to the main salary) of the all employees that are hired after 2011 in the company?
        /// </summary>
        static void T9()
        {
            // Call the method to print the average bonus (in percentage, relative to the main salary) of the all employees that are hired after 2011 in the company
            ManageEmployees.PrintAverageBonusPercentageForEmployeesHiredAfter2011(_employees);
        }

        /// <summary>
        /// Show all the data of the oldest employee and the youngest one in the company.
        /// <br> If there’s more than one employee with the same age, take the one who joined the company first. </br>
        /// </summary>
        static void T10()
        {
            // Call the method to print all the data of the oldest employee and the youngest one in the company.
            ManageEmployees.PrintOldestAndYoungestEmployees(_employees);
        }
    }
}
