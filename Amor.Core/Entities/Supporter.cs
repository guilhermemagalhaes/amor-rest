using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Core.Entities
{
    public class Supporter : Base
    {
        protected Supporter() { }
        public Supporter(int ongId, int donationId)
        {
            OngId = ongId;
            DonationId = donationId;
        }

        public int OngId { get; private set; }
        public Ong Ong { get; private set; }
        public int DonationId { get; private set; }
        public Donation Donation { get; private set; }
    }
}
