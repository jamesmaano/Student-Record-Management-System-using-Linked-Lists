using StudentRecordDLL1.DataStructures;
using StudentRecordDLL1.model;
using System;

namespace StudentRecordDLL
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList studentList = new DoublyLinkedList();
            int choice;

            do
            {
                Console.WriteLine("\n===== Student Record Management System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Delete Student");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Display All Students");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        int id;
                        do
                        {
                            Console.Write("Enter ID: ");
                        } while (!int.TryParse(Console.ReadLine(), out id));

                        if (studentList.FindById(id) != null)
                        {
                            Console.WriteLine("A student with this ID already exists!");
                            break;
                        }

                        Console.Write("Enter First Name: ");
                        string firstName = ReadNonEmptyString("First Name");

                        Console.Write("Enter Last Name: ");
                        string lastName = ReadNonEmptyString("Last Name");

                        Console.Write("Enter Course: ");
                        string course = ReadNonEmptyString("Course");

                        int year;
                        do
                        {
                            Console.Write("Enter Year Level (1-4): ");
                        } while (!int.TryParse(Console.ReadLine(), out year) || year < 1 || year > 4);

                        double gpa;
                        do
                        {
                            Console.Write("Enter GPA (0.0 - 4.0): ");
                        } while (!double.TryParse(Console.ReadLine(), out gpa) || gpa < 0.0 || gpa > 4.0);

                        Console.Write("Enter Address: ");
                        string address = ReadNonEmptyString("Address");

                        Console.Write("Enter Phone: ");
                        string phone = ReadNonEmptyString("Phone");

                        Console.Write("Enter Birthdate: ");
                        string birthDate = ReadNonEmptyString("Birthdate");

                        int age;
                        do
                        {
                            Console.Write("Enter Age: ");
                        } while (!int.TryParse(Console.ReadLine(), out age) || age < 1 || age > 120);

                        Student newStudent = new Student(id, firstName, lastName, course, year, gpa, address, phone, birthDate, age);

                        // Ask user where to insert
                        Console.WriteLine("\nWhere do you want to add this student?");
                        Console.WriteLine("1. At the beginning");
                        Console.WriteLine("2. At the end");
                        Console.WriteLine("3. At specific position");
                        Console.Write("Choose option (1-3): ");

                        if (int.TryParse(Console.ReadLine(), out int insertChoice))
                        {
                            switch (insertChoice)
                            {
                                case 1:
                                    studentList.InsertAtBeginning(newStudent);
                                    break;
                                case 2:
                                    studentList.Insert(newStudent);
                                    break;
                                case 3:
                                    Console.Write("Enter position: ");
                                    if (int.TryParse(Console.ReadLine(), out int position))
                                    {
                                        studentList.InsertAtPosition(newStudent, position);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid position! Adding at end instead.");
                                        studentList.Insert(newStudent);
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice! Adding at end.");
                                    studentList.Insert(newStudent);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Adding at end.");
                            studentList.Insert(newStudent);
                        }
                        break;

                    case 2:
                        Console.Write("Enter ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int delId))
                        {
                            studentList.Delete(delId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case 3:
                        Console.Write("Enter ID to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchId))
                        {
                            studentList.Search(searchId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID!");
                        }
                        break;

                    case 4:
                        Console.Write("Enter ID to update: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Invalid ID!");
                            break;
                        }

                        if (studentList.FindById(updateId) == null)
                        {
                            Console.WriteLine("Student not found!");
                            break;
                        }

                        Console.Write("Enter New First Name: ");
                        string uFirst = ReadNonEmptyString("First Name");

                        Console.Write("Enter New Last Name: ");
                        string uLast = ReadNonEmptyString("Last Name");

                        Console.Write("Enter New Course: ");
                        string uCourse = ReadNonEmptyString("Course");

                        int uYear;
                        do
                        {
                            Console.Write("Enter New Year Level (1-4): ");
                        } while (!int.TryParse(Console.ReadLine(), out uYear) || uYear < 1 || uYear > 4);

                        double uGpa;
                        do
                        {
                            Console.Write("Enter New GPA (0.0 - 4.0): ");
                        } while (!double.TryParse(Console.ReadLine(), out uGpa) || uGpa < 0.0 || uGpa > 4.0);

                        Console.Write("Enter New Address: ");
                        string uAddress = ReadNonEmptyString("Address");

                        Console.Write("Enter New Phone: ");
                        string uPhone = ReadNonEmptyString("Phone");

                        Console.Write("Enter New Birthdate: ");
                        string uBirth = ReadNonEmptyString("Birthdate");

                        int uAge;
                        do
                        {
                            Console.Write("Enter New Age: ");
                        } while (!int.TryParse(Console.ReadLine(), out uAge) || uAge < 1 || uAge > 120);

                        studentList.Update(updateId, uFirst, uLast, uCourse, uYear, uGpa, uAddress, uPhone, uBirth, uAge);
                        break;

                    case 5:
                        studentList.DisplayStudents();
                        break;

                    case 6:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }

            } while (choice != 6);
        }

        static string ReadNonEmptyString(string fieldName)
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine($" {fieldName} cannot be empty. Try again:");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
    }
}