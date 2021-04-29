using Amor.Application.InputModels;
using Amor.Application.ViewModels;
using Amor.Core.Entities;
using Amor.Core.Enums;
using Amor.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amor.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<SignInViewModel> SignIn(SignInInputModel signInInputModel)
        {
            SignInViewModel ret = null;
            var user = await _userRepository.SignIn(signInInputModel.Email, signInInputModel.Password);

            if (user != null)
            {                
                ret = new SignInViewModel(null, DateTime.Now, _mapper.Map<Person, PersonViewModel>(user.Person));
            }
            return ret;
        }

        public async Task<SignUpViewModel> SignUp(SignUpInputModel signUpInputModel)
        {
            bool isOng = signUpInputModel.Document.Length > 11;
            string profile = isOng ? UserProfileEnum.ONG.ToString() : UserProfileEnum.VOLUNTARY.ToString();

            int personId = await _personRepository.AddPerson(new Person(signUpInputModel.Name, signUpInputModel.Phone));
            if (personId > 0)
            {
                if (isOng)
                    await _personRepository.AddLegalPerson(new LegalPerson(signUpInputModel.Document, personId));
                else
                    await _personRepository.AddPhysicalPerson(new PhysicalPerson(signUpInputModel.Document, personId));
            }

            int userId = await _userRepository.Add(new User(signUpInputModel.Password, profile, signUpInputModel.Facebook_Unique_id, signUpInputModel.Email, personId));

            return new SignUpViewModel(userId > 0);
        }
    }
}
