using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public string PageProfileLink { get; set; }
        public string About { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IList<string> Photos { get; set; }
        public AddressViewModel EventAddress { get; set; }
    }
}
