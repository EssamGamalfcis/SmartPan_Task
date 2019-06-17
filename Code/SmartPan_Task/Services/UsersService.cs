using Domain;
using Repository;
using System;
using System.Linq;

namespace Services

{
    public class UsersService : IUsersService
    {
        public IGenericRepository<Users> iuserRepository;

        public UsersService(IGenericRepository<Users> _iuserRepository)
        {
            this.iuserRepository = _iuserRepository;
        }

      

        public Users Login(string username, string password)
        {
            return iuserRepository.FindBy(s => s.UserLoginName.Equals(username) && s.UserPassword.Equals(password)).FirstOrDefault();

        }
    }
}
