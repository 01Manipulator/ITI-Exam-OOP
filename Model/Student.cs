using ITI_Exam.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model
{
    internal class Student
    {
        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine(
                $"{{Student -> {Name} , Exam -> {e.Subject.Name}  Started}}"
            );
        }



        public override string ToString()
        {
            return $"Student {{ Id -> {Id}, Name -> {Name} }}";
        }
    }
}
