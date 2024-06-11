using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Schemas
{
    public class PhraseSchema
    {
        public int IdPhrase { get; set; }
        public int IdCategory { get; set; }
        public string PhraseSpanish { get; set; }
        public string PhraseEnglish { get; set; }
        public string HintSpanish { get; set; }
        public string HintEnglish { get; set; }
    }
}