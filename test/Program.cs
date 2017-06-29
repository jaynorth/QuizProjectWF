using QuiZFormMain.Entity;
using QuiZFormMain.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            QuizPageViewModel qpt = new QuizPageViewModel();

            foreach (var item in qpt.ListQuestions.OrderBy(t => t.Question1))
            {
                Console.WriteLine(item);
                foreach (Question_choices qc in item.Question_choices)
                {
                    Console.WriteLine(qc);
                }
                
            }

            Console.WriteLine("current :" +qpt.CurrentQuestion);
            foreach (var choice in qpt.CurrentQuestion.Question_choices)
            {
                Console.WriteLine("choice : " +choice);
            }



        }
    }
}
