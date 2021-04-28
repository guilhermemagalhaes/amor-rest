using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel(bool Ok)
        {
            this.Ok = Ok;
        }
        public bool Ok { get; private set; }
    }
}
