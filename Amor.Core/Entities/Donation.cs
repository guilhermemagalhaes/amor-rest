using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Donation : Base
    {
        protected Donation() { }
        public Donation(double donatedAmount, string status, bool anonymousDonation, string externalPaymentId, int personId)
        {
            DonatedAmount = donatedAmount;
            Status = status;
            AnonymousDonation = anonymousDonation;
            ExternalPaymentId = externalPaymentId;
            PersonId = personId;
        }

        public double DonatedAmount { get; private set; }
        public string Status { get; private set; }
        public bool AnonymousDonation { get; private set; }
        public string ExternalPaymentId { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
    }
}
