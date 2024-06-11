using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Schemas
{
    public class GameSchema
    {
        public int IdGame { get; set; }
        public int IdInitiator { get; set; }
        public int? IdChallenger { get; set; }
        public int Phrase { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Winner { get; set; }
        public int GameStatus { get; set; }
        public int GameLanguage { get; set; }
    }
}