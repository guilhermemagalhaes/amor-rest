using Amor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class SearchOnMyLocationViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Needs { get; set; }
        public AddressViewModel Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Photos { get; set; }
        public List<string> Supporters { get; set; }        
    }
}
