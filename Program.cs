using ITI_Exam.Model;
using ITI_Exam.Model.Answers;
using ITI_Exam.Model.Exams;
using ITI_Exam.Model.Questions;

namespace ITI_Exam
{
    internal class Program
    {
        static void Main()
        {

            Subject ComputerScience = new Subject(1,"Computer Science");


            Student st1 = new Student(1, "Youssef Ahmed");
            Student st2 = new Student(2, "Mohamed Ahmed");
            ComputerScience.Enroll(st1);
            ComputerScience.Enroll(st2);


            PracticeExam practice = new PracticeExam(30, ComputerScience);
            FinalExam final = new FinalExam(60, ComputerScience);


            QuestionList practiceQs = new QuestionList("practice.txt");
            QuestionList finalQs = new QuestionList("final.txt");

            // True / False Question
            TrueFalseQuestion q1 = new TrueFalseQuestion(
                "Q1",
                "Is C# a statically typed programming language?",
                2,
                new Answer(1, "True")
            );

            practiceQs.Add(q1);
            finalQs.Add(q1);

            // Choose One Question
            AnswerList q2Answers = new AnswerList();
            q2Answers.Add(new Answer(1, "O(n)"));
            q2Answers.Add(new Answer(2, "O(1)"));
            q2Answers.Add(new Answer(3, "O(log n)"));

            Answer? q2CorrectAnswer = q2Answers.GetById(2);

            ChooseOneQuestion q2 = new ChooseOneQuestion(
                "Q2",
                "What is the time complexity of accessing an element in an array by index?",
                3,
                q2Answers,
                q2CorrectAnswer
            );

            practiceQs.Add(q2);
            finalQs.Add(q2);


            // Choose All Question
            AnswerList q3Answers = new AnswerList();
            AnswerList q3CorrectAnswers = new AnswerList();

            q3Answers.Add(new Answer(1, "Stack"));
            q3Answers.Add(new Answer(2, "Queue"));
            q3Answers.Add(new Answer(3, "Dictionary"));
            q3Answers.Add(new Answer(4, "List"));

            q3CorrectAnswers.Add(q3Answers.GetById(1));
            q3CorrectAnswers.Add(q3Answers.GetById(2));

            ChooseAllQuestion q3 = new ChooseAllQuestion(
                "Q3",
                "Which of the following data structures follow FIFO or LIFO principles?",
                4,
                q3Answers,
                q3CorrectAnswers
            );

            practiceQs.Add(q3);
            finalQs.Add(q3);

            practice.Questions = practiceQs;
            final.Questions = finalQs;

            practice.RegisterStudentsToExam();
            final.RegisterStudentsToExam();


            Console.WriteLine("=== ITI Examination System ===");
            Console.WriteLine("Please Select Your Exam :");
            Console.WriteLine("  1 => Practice");
            Console.WriteLine("  2 => Final");
            Console.Write("Your Input: ");
            string choice = Console.ReadLine();

            Exam selected = (choice == "1") ? (Exam)practice : final;

            selected.StartExam();

            Console.WriteLine("\nPress Any Key To Submit Please");
            Console.ReadLine();

            selected.FinishExam();

            Console.WriteLine("Press Any Key To Exit");
            Console.ReadLine();
        }
    }
}
