using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel(string Token, DateTime Expiration, PersonViewModel Person, AddressViewModel Address)
        {
            this.Token = Token;
            this.Expiration = Expiration;
            this.Person = Person;
            this.Address = Address;
        }

        public SignInViewModel(string Token, DateTime Expiration, PersonViewModel Person)
        {
            this.Token = Token;
            this.Expiration = Expiration;
            this.Person = Person;            
        }

        public string Token { get; private set; }
        public DateTime Expiration { get; private set; }
        public PersonViewModel Person { get; private set; }
        public AddressViewModel Address { get; set; }
    }
}
