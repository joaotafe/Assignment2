using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeEnrolmentSystem
{
    /// <summary>
    /// Provides static utility methods for sorting lists of any type that implements IComparable<T>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list, which must implement IComparable<T>.</typeparam>
    public class Utility
    {

        public interface IComparator<T>
        {
            int CompareTo(T other);
        }


        public static void DisplayInfo(Person person, Student student, Address address)
        {
            Console.WriteLine("Person Information:");
            Console.WriteLine(person.ToString());

            Console.WriteLine("\nStudent Information:");
            Console.WriteLine(student.ToString());

            Console.WriteLine("\nAddress Information:");
            Console.WriteLine(address.ToString());
        }

        public static void Main(string[] args)
        {


            //int[] numbersArray = { 2, 18, 21, 3, 20, 17, 125, 23, 188, 34 };
            List<int> intList = new List<int> { 5, 2, 8, 1, 3 };
            GenericSortUtility<int>.AscendingSort(intList);

            Console.WriteLine("\nAscending Sorted  of Integers:");
            foreach (var num in intList)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();

            // string[] city ={ "banana", "apple", "orange", "grape", "mango" };
            List<string> stringList = new List<string> { "banana", "apple", "orange", "grape", "mango" };
            GenericSortUtility<string>.DescendingSort(stringList);

            Console.WriteLine("\nDescending Sorted of Strings:");
            foreach (var str in stringList)
            {
                Console.Write(str + " ");
            }

            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();

            // Insert some elements
            linkedList.AddAtTail(1);
            linkedList.AddAtTail(2);
            linkedList.AddAtTail(3);
            linkedList.AddAtTail(4);
            linkedList.AddAtTail(5);

            Console.WriteLine("\nBefore Deletion:");
            linkedList.Traverse();

            // Delete a node (e.g., delete node with data 3)
            linkedList.DeleteNode(3);

            Console.WriteLine("\nAfter Deletion:");
            linkedList.Traverse();

            BinaryTree<string> binaryTree = new BinaryTree<string>();

            // Adding nodes to the binary tree
            binaryTree.Add("D");
            binaryTree.Add("B");
            binaryTree.Add("A");
            binaryTree.Add("C");
            binaryTree.Add("F");
            binaryTree.Add("E");
            binaryTree.Add("G");

            // InOrder Traversal
            Console.WriteLine("\nInOrder Traversal:");
            binaryTree.InOrderTraversal();


            // Example usage with Student objects// IMPLEMENTING THE BINARY SEARCH (THIS IS THE GENERIC ONE)
            List<Student> students = new List<Student>
            {
                new Student { StudentId = 101 },
                new Student { StudentId = 102 },
                new Student { StudentId = 103 },
                new Student { StudentId = 104 }
            };

            Student targetStudent = new Student { StudentId = 102 };

            //// Binary search on a sorted list
            //int binarySearchResult = BinarySearch(students, targetStudent);
            //Console.WriteLine($"\nBinary Search Result for StudentId-102: {binarySearchResult}");

            // Sequential search on an unsorted list
            int sequentialSearchResult = SequentialSearch(students, targetStudent);
            Console.WriteLine($"Sequential Search Result for StudentId-102: {sequentialSearchResult}");




            Student[] studentsArray = new Student[]
            {
            new Student { name = "John", StudentId = 101 },
            new Student { name = "Alice", StudentId = 102 },
            new Student { name = "Bob", StudentId = 103 },
           // Add more students as needed
            };
            List<Student> studentsList = studentsArray.ToList();

            // Example of using the LinearSearch method
            Student targetStudentLinear = new Student { name = "Alice", StudentId = 102 };
            int linearSearchResult = LinearSearch(studentsArray, targetStudentLinear);
            Console.WriteLine($"Linear Search Result: {linearSearchResult}");

            // Example of using the BinarySearch method
            Student targetStudentBinary = new Student { name = "Alice", StudentId = 102 };
            int binarySearchResult = BinarySearch(studentsArray, targetStudentBinary);
            Console.WriteLine($"Binary Search Result: {binarySearchResult}");

            // Example of using the BubbleSort method
            BubbleSort(studentsArray);

            // Display the sorted array
            Console.WriteLine("Sorted Students:");
            foreach (var student in studentsArray)
            {
                Console.WriteLine($"Name: {student.name}, StudentId: {student.StudentId}");
            }
        }


        public static int BinarySearch<T>(T[] array, T target) where T : IComparator<T>
        {
            List<T> list = array.ToList();
            return BinarySearch(list, target);
        }

        public static int SequentialSearch<T>(T[] array, T target) where T : IComparator<T>
        {
            List<T> list = array.ToList();
            return SequentialSearch(list, target);
        }



        //begin of student testing
        public static int LinearSearch(Student[] students, Student target)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Equals(target))
                {
                    return i; // Return the index if found
                }
            }
            return -1; // Return -1 if not found
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        //public static int BinarySearch(Student[] students, Student target)
        //{
        //    // Sort the array by Name before applying Binary Search
        //    //Array.Sort(students);

        //    int low = 0;
        //    int high = students.Length - 1;

        //    while (low <= high)
        //    {
        //        int mid = (low + high) / 2;

        //        int comparisonResult = string.Compare(students[mid].name, target.name, StringComparison.Ordinal);

        //        if (comparisonResult == 0)
        //        {
        //            return mid; // Target found
        //        }
        //        else if (comparisonResult < 0)
        //        {
        //            low = mid + 1; // Search the right half
        //        }
        //        else
        //        {
        //            high = mid - 1; // Search the left half
        //        }
        //    }
        //    return -1; // Target not found
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="students"></param>
        public static void BubbleSort(Student[] students)
        {
            int n = students.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Use the overloaded relational operators for comparison
                    if (students[j].CompareTo(students[j + 1]) > 0)
                    {
                        // Swap if out of order
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }
        //end of student test
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="list"></param>
        ///// <param name="target"></param>
        ///// <returns></returns>
        //public static int BinarySearch<T>(List<T> list, T target) where T : IComparator<T>
        //{
        //    if (list == null || list.Count == 0)
        //        return -1;

        //    int left = 0;
        //    int right = list.Count - 1;

        //    while (left <= right)
        //    {
        //        int mid = left + (right - left) / 2;

        //        int comparisonResult = list[mid].CompareTo(target);

        //        if (comparisonResult == 0)
        //            return mid; // Found the target at index 'mid'
        //        else if (comparisonResult < 0)
        //            left = mid + 1;
        //        else
        //            right = mid - 1;
        //    }

        //    return -1; // Target not found
        //}
        public static int BinarySearch<T>(List<T> collection, T target) where T : IComparator<T>
        {
            if (collection == null || !collection.Any())
                return -1;

            List<T> list = collection.ToList();
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                int comparisonResult = list[mid].CompareTo(target);

                if (comparisonResult == 0)
                    return mid; // Found the target at index 'mid'
                else if (comparisonResult < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1; // Target not found
        }
        public static int SequentialSearch<T>(IEnumerable<T> collection, T target) where T : IComparator<T>
        {
            if (collection == null || !collection.Any())
                return -1;

            List<T> list = collection.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(target) == 0)
                {
                    return i; // Found the target at index 'i'
                }
            }

            return -1; // Target not found
        }
        //public static int SequentialSearch<T>(List<T> list, T target) where T : IComparator<T>
        //{
        //    if (list == null || list.Count == 0)
        //        return -1;

        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].CompareTo(target) == 0)
        //        {
        //            return i; // Found the target at index 'i'
        //        }
        //    }

        //    return -1; // Target not found
        //}
        //convert Student[] to generic.List<int. fix in myTest class
        internal static int SequentialSearch(Student[] studentsArray, Student targetStudent)
        {
            throw new NotImplementedException();
        }

        internal static int BinarySearch(Student[] studentsArray, Student targetStudent)
        {
            throw new NotImplementedException();
        }

        public static int BinarySearch(Student[] studentsArray, int v)
        {
            throw new NotImplementedException();
        }

        public class Course : IComparator<Course>
        {
            public string CourseCode { get; set; }

            public int CompareTo(Course other)
            {
                // Implement the comparison logic
                return CourseCode.CompareTo(other.CourseCode);
            }
        }

        public class Student : IComparator<Student>
        {
            //public Student(string name, string email, string telNum, string _id, string _program, DateTime  now)

            //{
            //}

            public int StudentId { get; set; }
            public string name { get; internal set; }

            public int CompareTo(Student other)
            {
                // Implement the comparison logic
                return StudentId.CompareTo(other.StudentId);
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class GenericSortUtility<T> where T : IComparable<T>
        {
            // Sort in ascending order
            public static void AscendingSort(List<T> list)
            {
                if (list == null || list.Count <= 1)
                    return;

                // Using a simple Bubble Sort algorithm for demonstration
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = 0; j < list.Count - 1 - i; j++)
                    {
                        if (list[j].CompareTo(list[j + 1]) > 0)
                        {
                            // Swap elements
                            T temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
            }

            public static void DescendingSort(List<T> list)
            {
                if (list == null || list.Count <= 1)
                    return;

                // Using a simple Bubble Sort algorithm for demonstration
                for (int i = 0; i < list.Count - 1; i++)
                {
                    for (int j = 0; j < list.Count - 1 - i; j++)
                    {
                        if (list[j].CompareTo(list[j + 1]) < 0)
                        {
                            // Swap elements
                            T temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
            }
        }


    }
}
