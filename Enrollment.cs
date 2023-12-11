using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeEnrolmentSystem
{
    public class Enrollment
    {
        public DateTime DateEnrolled { get; set; }
        public string Grade { get; set; }
        public string Semester { get; set; }
        public Student _Student { get; set; }
        public Course _Course { get; set; }

        public Enrollment(DateTime dateEnrolled, string grade, string semester, Student student, Course course)
        {
            DateEnrolled = dateEnrolled;
            Grade = grade;
            Semester = semester;
            _Student = student;
            _Course = course;
        }

        public override string ToString()
        {
            return $"Enrolled: {DateEnrolled.ToShortDateString()}, Grade: {Grade}, Semester: {Semester}, Student: {_Student.ToString()}, Course: {_Course.ToString()}";
        }
    }
}