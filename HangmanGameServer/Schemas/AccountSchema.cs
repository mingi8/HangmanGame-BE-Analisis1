using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Schemas
{
    public class AccountSchema
    {
        public int IdAccount { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}