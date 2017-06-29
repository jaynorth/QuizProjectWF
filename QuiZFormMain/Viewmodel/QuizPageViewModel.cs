using QuiZFormMain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiZFormMain.Viewmodel
{
    public class QuizPageViewModel
    {

        public QuizPageViewModel()
        {
            QuizzDbEntities efconn = new QuizzDbEntities();
             _listQuestions = new List<Question>(efconn.Questions.ToList());
            _currentQuestion = _listQuestions.First();
            _questionChoicesList = CurrentQuestion.Question_choices.ToList();

        }

        private Question _currentQuestion;

        public Question CurrentQuestion
        {
            get { return _currentQuestion; }
            set { _currentQuestion = value; }
        }

        private List<Question> _listQuestions;

        public List<Question> ListQuestions
        {   
            get { return _listQuestions; }
            set { _listQuestions = value; }
        }

        private List<Question_choices> _questionChoicesList;

        public List<Question_choices> QuestionChoicesList
        {
            get { return _questionChoicesList; }
            set { _questionChoicesList = value; }
        }

        
        




    }
}
