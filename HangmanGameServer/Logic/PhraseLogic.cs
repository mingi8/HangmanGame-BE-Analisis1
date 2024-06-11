using HangmanGameServer.Model;
using HangmanGameServer.Repository;
using HangmanGameServer.Schemas;
using HangmanGameServer.Utilities.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Web;

namespace HangmanGameServer.Logic
{
    public class PhraseLogic
    {
        public List<PhraseSchema> GetPhrases()
        {
            List<PhraseSchema> phrasesSchema = new List<PhraseSchema>();

            PhraseRepository phraseRepository = new PhraseRepository();
            List<Phrase> phrases = phraseRepository.GetPhrases();

            foreach(Phrase phrase in phrases)
            {
                phrasesSchema.Add(EntityToSchemaConverter.ConverterPhraseEntityToPhraseSchema(phrase));
            }

            return phrasesSchema;
        }

        public List<CategorySchema> GetCategories()
        {
            List<CategorySchema> categoriesSchema = new List<CategorySchema>();

            PhraseRepository phraseRepository = new PhraseRepository();
            List<Category> categories = phraseRepository.GetCategories();

            foreach (Category category in categories)
            {
                categoriesSchema.Add(EntityToSchemaConverter.ConverterCategoryEntityToCategorySchema(category));
            }

            return categoriesSchema;
        }

        public string GetPhrasePlayed(int idPhrase, int idLanguage)
        {
            PhraseRepository phraseRepository = new PhraseRepository();
            return phraseRepository.GetPhrasePlayed(idPhrase, idLanguage);
        }

        public string GetHintOfPhrase(int idPhrase, int idLanguage)
        {
            PhraseRepository phraseRepository = new PhraseRepository();
            return phraseRepository.GetHintOfPhrase(idPhrase, idLanguage);
        }

    }
}