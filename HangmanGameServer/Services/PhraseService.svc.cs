using HangmanGameServer.Logic;
using HangmanGameServer.Schemas;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace HangmanGameServer.Services
{
    public class PhraseService : IPhraseService
    {
        public List<PhraseSchema> GetPhrases()
        {
            PhraseLogic phraseLogic = new PhraseLogic();

            try
            {
                return phraseLogic.GetPhrases();
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetPhrases: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public List<CategorySchema> GetCategories()
        {
            PhraseLogic phraseLogic = new PhraseLogic();

            try
            {
                return phraseLogic.GetCategories();
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetCategories: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public string GetPhrasePlayed(int idPhrase, int idLanguage)
        {
            PhraseLogic phraseLogic = new PhraseLogic();

            try
            {
                return phraseLogic.GetPhrasePlayed(idPhrase, idLanguage);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetPhrasePlayed: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public string GetHintOfPhrase(int idPhrase, int idLanguage)
        {
            PhraseLogic phraseLogic = new PhraseLogic();

            try
            {
                return phraseLogic.GetHintOfPhrase(idPhrase, idLanguage);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetHintOfPhrase: {e.Message}");
                throw new FaultException(e.Message);
            }
        }
    }
}
