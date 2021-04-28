using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public interface IUserService
    {
        Task<SignUpViewModel> SignUp(SignUpInputModel signUpInputModel);
    }
}
