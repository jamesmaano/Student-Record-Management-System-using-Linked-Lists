using StudentRecordDLL1.DataStructures;
using System;
using System.Xml.Linq;

namespace StudentRecordDLL1.Operations
{
    public class SearchStudent
    {
        public void Execute(DoublyLinkedList list, int id)
        {
            Node current = list.head;

            while (current != null)
            {
                if (current.Data.Id == id)
                {
                    Console.WriteLine("Student Found:");
                    current.Data.DisplayInfo();
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine("Student Not Found");
        }
    }
}