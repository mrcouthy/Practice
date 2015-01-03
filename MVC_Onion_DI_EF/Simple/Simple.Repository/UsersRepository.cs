using Simple.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string configuration;
        public UsersRepository(string configuration)
        {
            this.configuration = configuration;
        }
        public Domain.Users GetUsers(string userID)
        {
            throw new NotImplementedException();
        }
    }
}
