using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Amor.Application.InputModels
{
    public class PaymentInputModel
    {
        public double DonatedAmount { get; set; }        
        public bool AnonymousDonation { get; set; }
        public string ExternalPaymentId { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
        public int OngId { get; set; }
    }
}
