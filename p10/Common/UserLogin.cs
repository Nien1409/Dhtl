using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p10.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UsersID { get; set;}
        public string Name { get; set;}
    }
}