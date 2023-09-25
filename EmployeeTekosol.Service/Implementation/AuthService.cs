using EmployeeTekosol.Repository.Abstraction;
using EmployeeTekosol.Repository.Models;
using EmployeeTekosol.Service.Abstraction;

namespace EmployeeTekosol.Service.Implementation
{
    public class AuthService : IAuthService
    { 
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public string CreateToken(User user)
        {
            return _authRepository.CreateToken(user);
        }
    }
}
