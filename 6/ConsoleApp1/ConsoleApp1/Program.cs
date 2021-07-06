using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace LinkedList
{
    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }

        public Node(object Data, Node Next = null)
        {
            this.Data = Data;
            this.Next = Next;
        }
    }

    public class LinkedList
    {
        private Node Head;
        public Node First
        {
            get => Head;
            set
            {
                First.Data = value.Data;
                First.Next = value.Next;
            }
        }

        public Node Last
        {
            get
            {
                Node p = Head;               
                while (p.Next != null)
                    p = p.Next;
                return p;
            }
            set
            {
                Last.Data = value.Data;
                Last.Next = value.Next;
            }
        }


        public void AddLast(Object data)
        {
            Last.Next = new Node(data);
           
        }

        public void AddBefore(Node node, object data, bool verbose = true)
        {
            Node temp = new Node(data);

            Node p = Head;

            while (p.Next != node) //Finding the node before
            {
                p = p.Next;
            }

            temp.Next = p.Next; //same as  = node
            p.Next = temp;

            if (verbose) Print();
        }

        public Node Find(object data)
        {
            Node p = Head;

            while (p != null)
            {
                if (p.Data == data)
                    return p;

                p = p.Next;
            }
            return null;
        }

      

        public void Print()
        {
            Node p = Head;
            while (p != null) //LinkedList iterator
            {
                Console.Write(p.Data + " ");
                p = p.Next; //traverse the list until p is the last node.The last node always points to NULL.
            }
            Console.WriteLine();
        }
    }


    static class Program
    {
        static void Main(string[] args)
        {
            var tune = new LinkedList();

            tune.AddLast("so"); 
            tune.AddBefore(tune.Last, "fa");

            
           

        }
    }
}
