using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Schemas
{
    public class PersonSchema
    {
        public int IdPerson { get; set; }
        public int IdAccount { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}