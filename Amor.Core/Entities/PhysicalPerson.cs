using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amor.Core.Entities
{
    public class PhysicalPerson
    {
        protected PhysicalPerson() { }
        public PhysicalPerson(string CPF, int personId)
        {
            this.CPF = CPF;
            PersonId = personId;
        }


        [Key]
        public string CPF { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
    }
}
