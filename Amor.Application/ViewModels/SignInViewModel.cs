using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel(string Token, PersonViewModel Person)
        {
            this.Token = Token;
            this.Person = Person;
        }

        public string Token { get; set; }
        public PersonViewModel Person { get; set; }
    }
}
