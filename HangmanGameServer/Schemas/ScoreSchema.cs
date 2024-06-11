using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Schemas
{
    public class ScoreSchema
    {
        public int IdScore { get; set; }
        public int IdPerson { get; set; }
        public int Score { get; set; }
    }
}