using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Photo : Base
    {
        protected Photo() { }
        public Photo(string URL)
        {
            this.URL = URL;
        }
        public string URL { get; private set; }
    }
}
