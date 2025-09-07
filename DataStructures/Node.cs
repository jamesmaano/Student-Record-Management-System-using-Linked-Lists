using StudentRecordDLL1.model;

namespace StudentRecordDLL1.DataStructures
{
    public class Node
    {
        public Student Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(Student data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}