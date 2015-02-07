using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Domain
{
    public class Users
    {
        public int Id { get;private set; }

        public string FirstName { get;private set; }

        public string LastName { get; private set; }

        public string Phone { get; private set; }

        public string UserId { get; private set; }
    }
}
