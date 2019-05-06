using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Function
{
    public class SessionUserInfo
    {

        private UserModel _userInfo;

        public SessionUserInfo(UserModel objUser)
        {
            this._userInfo = objUser;
        }

        public UserModel Userinfo
        {
            get
            {
                return _userInfo;
            }
        }
    }
}
