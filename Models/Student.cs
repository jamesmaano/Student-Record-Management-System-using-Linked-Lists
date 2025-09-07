using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordDLL1.model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public int YearLevel { get; set; }
        public double GPA { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }

        public Student(int id, string firstName, string lastName, string course, int yearLevel, double gpa, string address, string phone, string birthDate, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Course = course;
            YearLevel = yearLevel;
            GPA = gpa;
            Address = address;
            Phone = phone;
            BirthDate = birthDate;
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Course: {Course}");
            Console.WriteLine($"Year Level: {YearLevel}");
            Console.WriteLine($"GPA: {GPA}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"Birthdate: {BirthDate}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine("====================================");
        }
    }
}