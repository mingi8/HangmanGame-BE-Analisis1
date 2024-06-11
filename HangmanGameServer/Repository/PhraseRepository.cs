using HangmanGameServer.Model;
using HangmanGameServer.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Repository
{
    public class PhraseRepository
    {
        public List<Phrase> GetPhrases()
        {
            List<Phrase> phrases;
            using (var context = new HangmanGameDBEntities())
            {
                phrases = context.Phrase.ToList();
            }
            return phrases;
        }
        public List<Category> GetCategories()
        {
            List<Category> categories;
            using (var context = new HangmanGameDBEntities())
            {
                categories = context.Category.ToList();
            }
            return categories;
        }

        public string GetPhrasePlayed(int idPhrase, int idLanguage)
        {
            using (var context = new HangmanGameDBEntities())
            {
                var phrase = context.Phrase
                    .Where(p => p.id_phrase == idPhrase)
                    .Select(p => idLanguage == 1 ? p.phrase_english : p.phrase_spanish)
                    .FirstOrDefault();

                return phrase;
            }
        }

        public string GetHintOfPhrase(int idPhrase, int idLanguage)
        {
            using (var context = new HangmanGameDBEntities())
            {
                var phrase = context.Phrase
                    .Where(p => p.id_phrase == idPhrase)
                    .Select(p => idLanguage == 1 ? p.hint_english : p.hint_spanish)
                    .FirstOrDefault();

                return phrase;
            }
        }
    }
}