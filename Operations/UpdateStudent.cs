using StudentRecordDLL1.DataStructures;
using System;
using System.Xml.Linq;

namespace StudentRecordDLL1.Operations
{
    public class UpdateStudent
    {
        public void Execute(DoublyLinkedList list, int id,
                            string firstName, string lastName,
                            string course, int year, double gpa,
                            string address, string phone,
                            string birthDate, int age)
        {
            Node current = list.head;

            while (current != null)
            {
                if (current.Data.Id == id)
                {
                    current.Data.FirstName = firstName;
                    current.Data.LastName = lastName;
                    current.Data.Course = course;
                    current.Data.YearLevel = year;
                    current.Data.GPA = gpa;
                    current.Data.Address = address;
                    current.Data.Phone = phone;
                    current.Data.BirthDate = birthDate;
                    current.Data.Age = age;

                    Console.WriteLine("Student Updated Successfully");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine("Student Not Found");
        }
    }
}