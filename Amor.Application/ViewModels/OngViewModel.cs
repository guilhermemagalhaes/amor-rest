using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Amor.Application.ViewModels
{
    public class OngViewModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string About { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public IList<string> Photos { get; set; }
        public AddressViewModel Address { get; set; }
        public IList<string> Supporters { get; set; }
    }
}
