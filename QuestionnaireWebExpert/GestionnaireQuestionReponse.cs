using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace QuestionnaireWebExpert
{
    public static class GestionnaireQuestionReponse
    {
        private static IDictionary<string, Question> _mesQuestionsTraitees = null;
        private static IDictionary<string, Question> _mesQuestionsNonTraitees = null;
        private static IDictionary<string, Reponse> _mesReponses = null;

        public static IEnumerable<Question> Questions { get { return _mesQuestionsNonTraitees.Values; } }
        public static IEnumerable<Reponse> Reponses { get { return _mesReponses.Values; } }

        public static bool AjouterQuestion(string questionPose)
        {
            bool ajoutReussi = false;

            if (_mesQuestionsNonTraitees == null)
            {
                _mesQuestionsNonTraitees = new Dictionary<string, Question>();
            }

            if (_mesQuestionsTraitees == null)
            {
                _mesQuestionsTraitees = new Dictionary<string, Question>();
            }

            if (!_mesQuestionsTraitees.ContainsKey(GestionnaireQuestionReponse.GetIdReponseSucsception(questionPose)))
            {
                if (!_mesQuestionsNonTraitees.ContainsKey(GestionnaireQuestionReponse.GetIdReponseSucsception(questionPose)))
                {
                    _mesQuestionsNonTraitees.Add(questionPose, new Question(questionPose));
                    ajoutReussi = true;
                }
            }

            return ajoutReussi;
        }

        public static bool AjouterReponse(string idQuestion, string reponse)
        {
            bool ajoutReussie = false;

            if (_mesReponses == null)
            {
                _mesReponses = new Dictionary<string, Reponse>();
            }

            if (_mesQuestionsNonTraitees.ContainsKey(idQuestion))
            {
                if (!_mesReponses.ContainsKey(GetIdReponseSucsception(reponse)))
                {
                    _mesQuestionsNonTraitees[idQuestion].Répondre(reponse);
                    _mesReponses.Add(_mesQuestionsNonTraitees[idQuestion].GetReponse().Id, _mesQuestionsNonTraitees[idQuestion].GetReponse().Clone());
                    _mesQuestionsTraitees.Add(_mesQuestionsNonTraitees[idQuestion].Id, _mesQuestionsNonTraitees[idQuestion].Clone());
                    _mesQuestionsNonTraitees.Remove(idQuestion);
                    ajoutReussie = true;
                }
            }

            return ajoutReussie;
        }

        public static Question GetQuestion(string idQuestion)
        {
            Question uneQuestion = null;

            if (_mesQuestionsTraitees.ContainsKey(idQuestion))
            {
                uneQuestion = _mesQuestionsTraitees[idQuestion];
            }

            return uneQuestion;
        }

        public static Reponse GetReponse(string idReponse)
        {
            Reponse uneReponse = null;

            if (_mesReponses.ContainsKey(idReponse))
            {
                uneReponse = _mesReponses[idReponse];
            }

            return uneReponse;
        }

        public static string GetIdReponseSucsception(string reponse)
        {
            return ConvertirReponseEnIdReponseOuQuestion(reponse);
        }

        public static string ConvertirReponseEnIdReponseOuQuestion(string reponseOuQuestion)
        {
            return reponseOuQuestion.ToUpperInvariant();
        }

        public static void InitialiserGestionnaire()
        {
            _mesQuestionsNonTraitees = new Dictionary<string, Question>();
            _mesQuestionsTraitees = new Dictionary<string, Question>();
            _mesReponses = new Dictionary<string, Reponse>();
        }
    }
}
