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
    }
}
