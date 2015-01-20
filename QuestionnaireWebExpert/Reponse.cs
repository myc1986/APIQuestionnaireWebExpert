using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionnaireWebExpert
{
    public class Reponse
    {
        protected string _idReponse;
        protected string _reponse;

        public Reponse(string reponse)
        {
            _idReponse = GestionnaireQuestionReponse.ConvertirReponseEnIdReponseOuQuestion(reponse);
            _reponse = reponse;
        }

        private Reponse(Reponse uneReponse)
        {
            _idReponse = uneReponse.Id;
            _reponse = uneReponse.ReponseString;
        }

        public string Id { get { return _idReponse; } }
        public string ReponseString { get { return _reponse; } }

        public Reponse Clone()
        {
            return new Reponse(this);
        }
    }
}
