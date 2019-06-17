using Domain;
using Repository;
using System;
using System.Linq;
namespace Services

{
   public interface IUsersService
    {
        Users Login(string username, string password);
    }
}
