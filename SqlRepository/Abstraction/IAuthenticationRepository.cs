using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace SqlRepository.Abstraction
{
    public interface IAuthenticationRepository
    {
        Task<Response> Register(UserRegister userDetails);
        Task<Response> AdminRegister(UserRegister userDetails);
        Task<Response> Login(UserLogin userLoginDetails);
    }
}
