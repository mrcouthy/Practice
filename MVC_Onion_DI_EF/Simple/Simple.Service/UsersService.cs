using Simple.Domain;
using Simple.Interface.Service;
using Simple.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Service
{
    public class UsersService : IUsersService
    {
        UsersRepository usersRepository;
        public UsersService(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public Users GetUsers(string userID)
        {
            return usersRepository.GetUsers(userID);
        }

        public IEnumerable<Users> GetUsers()
        {
            return usersRepository.GetAllUsers();
        }
    }
}
