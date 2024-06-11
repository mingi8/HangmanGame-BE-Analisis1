using HangmanGameServer.Model;
using HangmanGameServer.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HangmanGameServer.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPhraseService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPhraseService
    {
        [OperationContract]
        List<PhraseSchema> GetPhrases();
        [OperationContract]
        List<CategorySchema> GetCategories();
        [OperationContract]
        string GetPhrasePlayed(int idPhrase, int idLanguage);
        [OperationContract]
        string GetHintOfPhrase(int idPhrase, int idLanguage);
    }
}
