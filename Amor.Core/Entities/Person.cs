using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Person : Base
    {
        protected Person() { }
        public Person(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public string Name { get; private set; }
        public string Phone { get; private set; }

        public virtual ICollection<PersonPhoto> PersonPhotos { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual LegalPerson LegalPerson { get; set; }
        public virtual PhysicalPerson PhysicalPerson { get; set; }
    }
}
