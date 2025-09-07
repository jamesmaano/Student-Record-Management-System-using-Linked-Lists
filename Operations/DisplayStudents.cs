using StudentRecordDLL1.DataStructures;
using System;
using System.Xml.Linq;

namespace StudentRecordDLL1.Operations
{
    public class DisplayStudents
    {
        public void Execute(DoublyLinkedList list)
        {
            Node current = list.head;

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
                        Console.WriteLine("You are at the last record. Press Enter...");
                    Console.ReadKey();
                }
                else if (choice.Equals("P", StringComparison.OrdinalIgnoreCase))
                {
                    if (current.Prev != null)
                        current = current.Prev;
                    else
                        Console.WriteLine("You are at the first record. Press Enter...");
                    Console.ReadKey();
                }
                else if (choice.Equals("E", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option. Press Enter...");
                    Console.ReadKey();
                }
            }
        }
    }
}