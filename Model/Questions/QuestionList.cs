using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace ITI_Exam.Model.Questions
{
    internal class QuestionList : List<Question>
    {
        private readonly string _fileName;

        public QuestionList(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("File name can not be null or empty.");
            _fileName = fileName;
        }

        public new void Add(Question question)
        {
            try
            {
                base.Add(question);

                using (StreamWriter sw = new StreamWriter(_fileName, append: true))
                {
                    sw.WriteLine(question.ToString());
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Permission denied while accessing the file.");
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("The specified directory was not found.");
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An I/O error occurred while writing to the file.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occurred.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
