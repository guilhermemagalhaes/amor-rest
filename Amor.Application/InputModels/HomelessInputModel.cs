using Amor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Amor.Application.InputModels
{
    public class HomelessInputModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Needs { get; set; }
        public IList<string> Photos { get; set; }
        public AddressInputModel Address { get; set; }

        [JsonIgnore]
        public int personIdCadastro { get; set; }

        public int CounterNotFound { get; set; }
    }
}
