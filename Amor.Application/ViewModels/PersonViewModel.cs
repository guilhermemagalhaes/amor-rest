using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel(int Id, string Name, string Phone, IList<AddressViewModel> Address)
        {
            this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;
            this.Address = Address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public IList<AddressViewModel>  Address { get; set; }
    }
}
