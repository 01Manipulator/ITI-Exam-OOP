
using ITI_Exam.Enum;
using ITI_Exam.Event;
using ITI_Exam.Interface;
using ITI_Exam.Model.Answers;
using ITI_Exam.Model.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITI_Exam.Model.Exams
{
    internal abstract class Exam : IExamBehavior,ICloneable, IComparable<Exam>
    {
        public int Time { get; set; }
        public int NumberOfQuestions => Questions.Count;
        public QuestionList Questions { get; set; }
        public Dictionary<Question, Answer> QuestionAnswerDictionary { get; set; } = new Dictionary<Question, Answer>();
        public Subject Subject { get; set; }
        public ExamMode Mode { get; private set; } = ExamMode.Queued;

        public event ExamStartedHandler ExamStarted;

        protected Exam(int time, Subject subject)
        {
            if (time <= 0) throw new ArgumentException("Time must be bigger than 0.");
            Time = time;
            Subject = subject;
            this.Questions = new QuestionList(this.GetType().Name);

        }

        protected void SetMode(ExamMode mode)
        {
            Mode = mode;
        }

        public abstract void ShowExam();

        public virtual void StartExam()
        {
            SetMode(ExamMode.Starting);
            ExamStarted?.Invoke(this, new ExamEventArgs(Subject, this));
            ShowExam();
        }

        public virtual void FinishExam()
        {
            SetMode(ExamMode.Finished);
            CorrectExam();
        }

        public void CorrectExam()
        {
            int total = 0, scored = 0;
            foreach (var q in Questions)
            {
                total += q.Marks;
                QuestionAnswerDictionary.TryGetValue(q, out Answer sa);
                if (q.CheckAnswer(sa)) scored += q.Marks;
            }
            Console.WriteLine($"\nGrade: {scored} / {total}");
        }


        public void RegisterStudentsToExam()
        {
            foreach (var s in Subject?.EnrolledStudents ??[])
            {
                ExamStarted += s.OnExamStarted;
            }
        }


        public object Clone() => MemberwiseClone();
        public int CompareTo(Exam other)
        {
            int c = Time.CompareTo(other.Time);
            return c != 0 ? c : NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }

        public override string ToString()
        {
            return $"{GetType().Name} | {Subject.Name} | Time:{Time}min | Qs:{NumberOfQuestions} | {Mode}";
        }
        public override bool Equals(object o)
        {
            return o is Exam e && e.Subject.Name == Subject.Name && e.Time == Time;
        }
        public override int GetHashCode()
        {
            return (Subject.Name + Time).GetHashCode();
        }
    }
}
