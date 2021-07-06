using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
   
    public interface IMyList<T>
    {
        void AddToHead(T value);
        void AddToTail(T value);
        int Count { get; }
        bool Contains(T value);

     

    }
    class MyLinkedList<T> : IMyList<T>
    {
        private Node<T> head;
        public MyLinkedList()
        {

        }
        public MyLinkedList(params T[] value)
        {
            foreach (T temp in value)
            {
                AddToTail(temp);

            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                if (head != null)
                {
                    Node<T> temp = head;
                    while (temp != null)
                    {
                        count++;
                        temp = temp.Next;
                    }
                }
                return count;
            }
        }

        public void AddToHead(T value)
        {
            var newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
        }

        public void AddToTail(T value)
        {
            var newNode = new Node<T>(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }

        }

        public bool Contains(T value)
        {
            if (head != null)
            {
                Node<T> temp = head;
                while (temp != null)
                {
                    if (temp.Value.Equals(value))
                    {
                        return true;
                    }
                    temp = temp.Next;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            if (head != null)
            {
                Node<T> temp = head;
                while (temp != null)
                {
                    result += temp.Value;
                    if (temp.Next != null)
                        result += ',';
                    temp = temp.Next;
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> lst = new MyLinkedList<int>();
            Console.WriteLine(lst.Count);
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                lst.AddToTail(rd.Next(100));
            }
            lst.AddToHead(99999);
            lst.AddToTail(11111);
            Console.WriteLine(lst);
            Console.WriteLine(lst.Count);
            Console.WriteLine(lst.Contains(11111));
            MyLinkedList<int> list = new MyLinkedList<int>(1, 8, 9, 43, 22);
            Console.WriteLine(list);
        }

    }
}
