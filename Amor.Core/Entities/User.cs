using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class User : Base
    {
        protected User() { }
        public User(string password, string profile, string facebookUniqueId, string email, int personId)
        {
            Password = password;
            Profile = profile;
            FacebookUniqueId = facebookUniqueId;
            Email = email;
            PersonId = personId;
        }

        public string Password { get; private set; }
        public string Profile { get; private set; }
        public string FacebookUniqueId { get; private set; }
        public string Email { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
    }
}
