using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model
{
    internal class Subject
    {
        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<Student> EnrolledStudents { get; } = [];

        public void Enroll(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("Student can not be null.");
            EnrolledStudents.Add(student);
        }

        public void UnEnroll(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("Student can not be null.");
            EnrolledStudents.Remove(student);
        }



        public override string ToString()
        {
            return $"Subject {{ Id -> {Id}, Name -> {Name} }}";
        }
    }
}
