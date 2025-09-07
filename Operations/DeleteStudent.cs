using StudentRecordDLL1.DataStructures;
using System;
using System.Xml.Linq;

namespace StudentRecordDLL1.Operations
{
    public class DeleteStudent
    {
        public void Execute(DoublyLinkedList list, int id)
        {
            Node current = list.head;

            while (current != null)
            {
                if (current.Data.Id == id)
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        list.head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;

                    Console.WriteLine("Student Deleted Successfully");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine("Student Not Found");
        }
    }
}