using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Schemas
{
    public class TurnSchema
    {
        public int IdTurn { get; set; }
        public int IdGame { get; set; }
        public string Word { get; set; }
        public int RemainingAttempts { get; set; }
    }
}