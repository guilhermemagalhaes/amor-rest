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
        Task<SignInViewModel> SignIn(SignInInputModel signInInputModel);
        Task<UserSimpleViewModel> GetUserByPersonId(int personId);
        Task<bool> EmailExists(string email);
        Task<string> DocumentExists(string document);
    }
}
