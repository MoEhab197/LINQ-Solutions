using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6_LINQ
{
    internal class Employee
    {
        public static string Company { get; set; } = "KAITECH";

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public string Nationality { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public DateTime JoiningDate { get; set; }
        public double Salary { get; set; }
        public double Bonus { get; set; }



        public Employee(string[] data)
        {
            Id = int.Parse(data[0]);
            Name = data[1];
            IsMale = data[2] == "Male";
            Nationality = data[3];
            Age = byte.Parse(data[4]);
            Email = data[5];
            Position = data[6];
            JoiningDate = DateTime.ParseExact(data[7], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Salary = double.Parse(data[8]);
            Bonus = double.Parse(data[9]);
        }



        public override string ToString()
        {
            return $"Company: {Company}\n" +
                $"Id: {Id}\n" +
                $"Name: {Name}\n" +
                $"{(IsMale ? "Male" : "Female")}\n" +
                $"Nationality: {Nationality}\n" +
                $"Age: {Age}\n" +
                $"Email: {Email}\n" +
                $"Position: {Position}\n" +
                $"Joining Date: {JoiningDate.ToShortDateString()}\n" +
                $"Salary: {Salary}\n" +
                $"Bonus: {Bonus}";
        }
    }
}
