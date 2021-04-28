using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class PersonPhoto : Base
    {
        protected PersonPhoto() { }
        public PersonPhoto(int photoId, int personId)
        {
            PhotoId = photoId;
            PersonId = personId;
        }
        public int PhotoId { get; private set; }
        public Photo Photo { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
    }
}
