using Amor.Application.InputModels;
using Amor.Core.Entities;
using Amor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IDonationRepository _donationRepository;
        private readonly ISupporterRepository _supporterRepository;
        public PaymentService(IDonationRepository donationRepository, ISupporterRepository supporterRepository)
        {
            _donationRepository = donationRepository;
            _supporterRepository = supporterRepository;
        }

        public async Task<bool> Add(PaymentInputModel paymentInputModel)
        {
            var donation = await _donationRepository.Add(new Donation(paymentInputModel.DonatedAmount,
                                                                      "OK",
                                                                      paymentInputModel.AnonymousDonation,
                                                                      "INTEGRACAO",
                                                                      paymentInputModel.PersonId));

            if (donation > 0)
                await _supporterRepository.Add(new Supporter(paymentInputModel.OngId, donation));

            return donation > 0;
        }
    }
}
