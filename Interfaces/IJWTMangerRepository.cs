using EcommerceApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Interfaces
{
    public interface IJWTMangerRepository
    {
        Tokens Authenicate(LoginViewModel users, bool IsRegister);
    }
}