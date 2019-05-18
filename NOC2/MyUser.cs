using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOC2
{
    public static class MyUser
    {
        private static int _userId = 0;

        public static int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
}
