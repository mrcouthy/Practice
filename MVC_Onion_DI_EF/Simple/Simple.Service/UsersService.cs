using Simple.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Service
{
    public class UsersService : IUsersService
    {
        Domain.Users IUsersService.GetUsers(string userID)
        {
            throw new NotImplementedException();
        }
    }
}
