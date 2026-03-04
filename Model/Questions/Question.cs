using ITI_Exam.Model.Answers;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;

namespace ITI_Exam.Model.Questions
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; } = new AnswerList();
        public Answer CorrectAnswer { get; set; }

        protected Question(string header, string body, int marks)
        {
            if (string.IsNullOrWhiteSpace(header)) throw new ArgumentException("Header can not be null or empty.");
            if (string.IsNullOrWhiteSpace(body)) throw new ArgumentException("Body can not be null or empty.");
            if (marks < 0) throw new ArgumentException("Marks should be a non-negative integer");
            Header = header;
            Body = body;
            Marks = marks;
        }

        public abstract void Display();

        public abstract bool CheckAnswer(Answer studentAnswer);

        public abstract Answer ReadAnswerFromUser();
        public override string ToString()
        {
            return $"Question {{ Type -> {this.GetType().Name} Head -> {Header}, Body -> {Body} }}";
        }

        public override bool Equals(object? obj)
        {
            if(obj is Question right)
            {
                return Header.Equals(right.Header) && Body.Equals(right.Body) && Marks.Equals(right
                    .Marks);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Header,Body,Marks);
        }


    }
}
