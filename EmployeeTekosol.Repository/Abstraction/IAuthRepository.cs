using EmployeeTekosol.Repository.Models;

namespace EmployeeTekosol.Repository.Abstraction
{
    public interface IAuthRepository
    {
        public string CreateToken(User user);
    }
}
