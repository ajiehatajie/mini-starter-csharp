using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Businness.User;


namespace Repository.Businness.Security.UserModule
{
    public class DisplayUser
    {
        public UserModel _UserInfo { get; set; }

        public DisplayUser()
        {
            _UserInfo = new UserModel();
        }


        public void Display()
        {
            UserRepository user = new UserRepository();
            _UserInfo = user.getData(_UserInfo.username);

        }
    }
}
