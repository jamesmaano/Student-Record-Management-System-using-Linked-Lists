using StudentRecordDLL1.model;
using System;
using System.Xml.Linq;

namespace StudentRecordDLL1.DataStructures
{
    public class DoublyLinkedList
    {
        public Node head { get; set; }

        // Helper method to find the last node
        private Node GetLastNode()
        {
            if (head == null) return null;

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }

        public void Insert(Student student)
        {
            Node newNode = new Node(student);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node lastNode = GetLastNode();
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
            }
            Console.WriteLine(" Student Added Successfully (at End)");
        }

        public void InsertAtBeginning(Student student)
        {
            Node newNode = new Node(student);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            Console.WriteLine("Student Added Successfully (at Beginning)");
        }

        public void InsertAtPosition(Student student, int position)
        {
            if (position <= 1)
            {
                InsertAtBeginning(student);
                return;
            }

            Node current = head;
            int index = 1;

            while (current != null && index < position - 1)
            {
                current = current.Next;
                index++;
            }

            if (current == null || current.Next == null)
            {
                Insert(student);
                return;
            }

            Node newNode = new Node(student);
            newNode.Next = current.Next;
            newNode.Prev = current;

            current.Next.Prev = newNode;
            current.Next = newNode;

            Console.WriteLine($"Student Added Successfully (at Position {position})");
        }

        public void Delete(int id)
        {
            Node current = FindById(id);
            if (current != null)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;

                Console.WriteLine("Student Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
        }

        public void Search(int id)
        {
            Node current = FindById(id);
            if (current != null)
            {
                Console.WriteLine("Student Found:");
                current.Data.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
        }

        public void Update(int id, string firstName, string lastName,
                           string course, int year, double gpa,
                           string address, string phone,
                           string birthDate, int age)
        {
            Node current = FindById(id);
            if (current != null)
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
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
        }

        public void DisplayStudents()
        {
            Node current = head;

            if (current == null)
            {
                Console.WriteLine("No Records Found");
                return;
            }

            while (true)
            {
                Console.Clear();
                current.Data.DisplayInfo();
                Console.WriteLine("[N] Next | [P] Previous | [E] Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    if (current.Next != null)
                        current = current.Next;
                    else
                        Console.WriteLine("You are at the last record. Press Enter to continue...");
                    Console.ReadKey();
                }
                else if (choice.Equals("P", StringComparison.OrdinalIgnoreCase))
                {
                    if (current.Prev != null)
                        current = current.Prev;
                    else
                        Console.WriteLine("You are at the first record. Press Enter to continue...");
                    Console.ReadKey();
                }
                else if (choice.Equals("E", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option. Press Enter to try again...");
                    Console.ReadKey();
                }
            }
        }

        public Node FindById(int id)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Id == id)
                    return current;
                current = current.Next;
            }
            return null;
        }
    }
}