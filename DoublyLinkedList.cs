using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeEnrolmentSystem
{
    /// <summary>
    /// Represents a generic double linked list.
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
    public class DoubleLinkedList<T>
    {
        /// <summary>
        /// Gets the first node of the double linked list.
        /// </summary>
        public DoubleLinkedListNode<T> Head { get; private set; }

        /// <summary>
        /// Gets the last node of the double linked list.
        /// </summary>
        public DoubleLinkedListNode<T> Tail { get; private set; }

        /// <summary>
        /// Adds a new node containing the specified value at the end of the double linked list.
        /// </summary>
        /// <param name="value">The value to add at the end of the list.</param>
        public void Add(T value)
        {
            DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(value);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
        }

        /// <summary>
        /// Inserts a new node containing the specified value at the specified index of the double linked list.
        /// </summary>
        /// <param name="value">The value to insert in the list.</param>
        /// <param name="index">The zero-based index at which the value should be inserted.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the index is out of range.</exception>
        public void InsertAt(T value, int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            DoubleLinkedListNode<T> newNode = new DoubleLinkedListNode<T>(value);
            if (index == 0)
            {
                if (Head == null)
                {
                    Head = newNode;
                    Tail = newNode;
                }
                else
                {
                    newNode.Next = Head;
                    Head.Previous = newNode;
                    Head = newNode;
                }
            }
            else
            {
                var current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    if (current == null) throw new ArgumentOutOfRangeException(nameof(index));
                    current = current.Next;
                }

                if (current == Tail)
                {
                    Add(value);
                }
                else
                {
                    newNode.Next = current.Next;
                    newNode.Previous = current;
                    if (current.Next != null) current.Next.Previous = newNode;
                    current.Next = newNode;
                }
            }
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the double linked list.
        /// </summary>
        /// <param name="value">The value to remove from the list.</param>
        public void Remove(T value)
        {
            DoubleLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current == Head)
                    {
                        Head = Head.Next;
                        if (Head == null)
                            Tail = null;
                        else
                            Head.Previous = null;
                    }
                    else if (current == Tail)
                    {
                        Tail = Tail.Previous;
                        if (Tail != null) Tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        if (current.Next != null) current.Next.Previous = current.Previous;
                    }
                    break;
                }
                current = current.Next;
            }
        }

        /// <summary>
        /// Finds the first node containing the specified value.
        /// </summary>
        /// <param name="value">The value to locate in the double linked list.</param>
        /// <returns>The first node containing the specified value, if found; otherwise, null.</returns>
        public DoubleLinkedListNode<T> Find(T value)
        {
            DoubleLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
    }
}