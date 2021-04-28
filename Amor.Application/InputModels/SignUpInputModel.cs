using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.InputModels
{
    public class SignUpInputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Facebook_Unique_id { get; set; }
    }
}
