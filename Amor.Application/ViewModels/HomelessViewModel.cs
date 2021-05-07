using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class HomelessViewModel
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Needs { get; set; }
        public AddressViewModel Address { get; set; }
        public IList<string> Photos { get; set; }
    }
}
