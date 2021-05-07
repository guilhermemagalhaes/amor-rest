using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class PersonViewModelForSignIn
    {
        public PersonViewModelForSignIn(int Id, string Name, string Phone, AddressViewModel Address)
        {
            this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }        
    }
}
