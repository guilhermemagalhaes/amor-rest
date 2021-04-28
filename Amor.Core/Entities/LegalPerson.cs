using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amor.Core.Entities
{
    public class LegalPerson
    {
        protected LegalPerson() { }
        public LegalPerson(string CNPJ, int personId)
        {
            this.CNPJ = CNPJ;
            PersonId = personId;
        }


        [Key]
        public string CNPJ { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
    }
}
