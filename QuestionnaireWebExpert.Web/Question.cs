using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionnaireWebExpert
{
    public class Question
    {
        protected string _idQuestion;
        protected string _question;
        protected Reponse _maReponse;

        public Question(string uneQuestionPose)
        {
            _idQuestion = GestionnaireQuestionReponse.ConvertirReponseEnIdReponseOuQuestion(uneQuestionPose);
            _question = uneQuestionPose;
        }

        private Question(Question uneQuestion)
        {
            _idQuestion = uneQuestion.Id;
            _question = uneQuestion.QuestionString;
            _maReponse = uneQuestion.GetReponse().Clone();
        }

        public string Id { get { return _idQuestion; } }
        public string QuestionString { get { return _question; } }

        public Reponse GetReponse()
        {
            return _maReponse;
        }

        public bool Repondu
        {
            get
            {
                bool rep = false;

                if (_maReponse != null)
                {
                    rep = true;
                }

                return rep;
            }
        }

        public void Répondre(string reponse)
        {
            _maReponse = new Reponse(reponse);
        }

        public Question Clone()
        {
            return new Question(this);
        }
    }
}
