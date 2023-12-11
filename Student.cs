using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeEnrolmentSystem
{
    /// <summary>
    /// Represents a student, inheriting from the Person class.
    /// </summary>
    public class Student : Person, IComparable<Student>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the student.
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Gets or sets the program or course of study the student is enrolled in.
        /// </summary>
        public string Program { get; set; }

        /// <summary>
        /// Gets or sets the date when the student registered.
        /// </summary>
        public DateTime DateRegistered { get; set; }

        /// <summary>
        /// Initializes a new instance of the Student class with specified details.
        /// </summary>
        /// <param name="name">Name of the student.</param>
        /// <param name="email">Email of the student.</param>
        /// <param name="telNum">Telephone number of the student.</param>
        /// <param name="studentID">Unique identifier for the student.</param>
        /// <param name="program">Program or course the student is enrolled in.</param>
        /// <param name="dateRegistered">Date of student's registration.</param>
        public Student(string name, string email, string telNum, int studentID, string program, DateTime dateRegistered)
            : base(name, email, telNum) // Initialize base class properties
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null");
            }

            StudentID = studentID;
            Program = program;
            DateRegistered = dateRegistered;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current student.
        /// </summary>
        /// <param name="obj">The object to compare with the current student.</param>
        /// <returns>true if the specified object is equal to the current student; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            // Null and type checks for robust comparison
            var other = obj as Student;
            return other != null && this.StudentID == other.StudentID;
        }

        /// <summary>
        /// Compares this instance with a specified Student object and indicates whether this instance precedes, follows, or appears in the same position in the sort order.
        /// </summary>
        /// <param name="other">The student to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(Student other)
        {
            // Handle null comparison
            if (other == null) return 1;

            // Use StudentID for comparison
            return this.Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Returns a string that represents the current student.
        /// </summary>
        /// <returns>A string containing the student's details.</returns>
        public override string ToString()
        {
            // Construct and return a string representation of the student
            return $"{base.ToString()}, StudentID: {StudentID}, Program: {Program}, Date Registered: {DateRegistered.ToShortDateString()}";
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current student.</returns>
        public override int GetHashCode()
        {
            return StudentID.GetHashCode() ^ Program.GetHashCode();

        }
        public static bool operator >(Student a, Student b)
        {
            return a.Name.CompareTo(b.Name) > 0;
        }

        public static bool operator <(Student a, Student b)
        {
            return a.Name.CompareTo(b.Name) < 0;
        }

    }
}

