using Amor.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public interface IPaymentService
    {
        Task<bool> Add(PaymentInputModel paymentInputModel);
    }
}
