using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Team3.Services
{
    public interface IUserService
    {
        bool ValidateCredentials(string Username, string Password);
    }
}
