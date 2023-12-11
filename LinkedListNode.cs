using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeEnrolmentSystem
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }



    }
    public class DoublyLinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        public void AddAtHead(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
        }

        public void AddAtTail(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void InsertAtPosition(T value, int position)
        {
            // Implement logic to insert at a specific position
            // Ensure to handle cases where position is out of bounds
        }

        public void DeleteNode(T value)
        {
            LinkedListNode<T> current = head;

            // Find the node to delete
            while (current != null && !current.Value.Equals(value))
            {
                current = current.Next;
            }

            if (current == null)
            {
                // Node not found
                return;
            }

            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                tail = current.Previous;
            }
        }

        public void Traverse()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Other methods like finding a node can be implemented here
    }
}
