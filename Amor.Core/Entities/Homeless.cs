using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Homeless : Base
    {
        protected Homeless() { }
        public Homeless(string needs, string about, int counterNotFound, Person person)
        {
            Needs = needs;
            About = about;
            CounterNotFound = counterNotFound;
            Person = person;            
        }

        public Homeless(string needs, string about)
        {
            Needs = needs;
            About = about;                        
        }

        public void Update(string needs, string about)
        {
            Needs = needs;
            About = about;
        }

        public string Needs { get; private set; }
        public string About { get; private set; }
        public int CounterNotFound { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
    }
}
