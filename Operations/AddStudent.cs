using StudentRecordDLL1.DataStructures;
using StudentRecordDLL1.model;
using System;

namespace StudentRecordDLL1.Operations
{
    public class AddStudent
    {
        // Helper method to find the last node
        private Node GetLastNode(DoublyLinkedList list)
        {
            if (list.head == null) return null;

            Node current = list.head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }

        public void Execute(DoublyLinkedList list, Student student)
        {
            if (list.FindById(student.Id) != null)
            {
                Console.WriteLine("Cannot add student. A student with this ID already exists.");
                return;
            }

            Node newNode = new Node(student);

            if (list.head == null)
            {
                list.head = newNode;
            }
            else
            {
                Node lastNode = GetLastNode(list);
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
            }

            Console.WriteLine("Student Added Successfully");
        }
    }
}