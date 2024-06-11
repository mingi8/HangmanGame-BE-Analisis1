using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Schemas
{
    public class CategorySchema
    {
        public int IdCategory { get; set; }
        public string CategoryNameSpanish { get; set; }
        public string CategoryNameEnglish { get; set; }
    }
}