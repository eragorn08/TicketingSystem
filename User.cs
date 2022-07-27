using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_System
{
    public class user
    {
        private string uname;
        private string username;
        private string upassword;

        public string Name
        {
            get { return uname; }
            set { uname = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string UPassword
        {
            get { return upassword; }
            set { upassword = value; }
        }

    }
}
