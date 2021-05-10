using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PageProfileLink { get; set; }
        public string About { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<string> Photos { get; set; }
        public AddressViewModel EventAddress { get; set; }
    }
}
