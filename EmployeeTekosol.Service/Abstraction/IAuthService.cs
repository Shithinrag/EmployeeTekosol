using EmployeeTekosol.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTekosol.Service.Abstraction
{
    public interface IAuthService
    {
        public string CreateToken(User user);
    }
}
