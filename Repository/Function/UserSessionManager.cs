using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Function;
using System.Web;
using Repository.Helper;
using Repository.Businness.Security.UserModule;
using Repository.Businness.User;

namespace Repository.Function
{
   public class UserSessionManager
   {
       Crypt objCrypt = new Crypt();
       public static SessionUserInfo LoggedOnUser
       {
           get
           {
               SessionUserInfo user = null;

               if(HttpContext.Current.Session["LoggedOnUser"] !=null )
               {
                   user = (SessionUserInfo)HttpContext.Current.Session["LoggedOnUser"];

               }
               return user;
           }
       }

       public bool VerifyUser(string strUserName, string strPassword)
       {
           UserRepository userRepo = new UserRepository();
          
           string PasswordHash = objCrypt.Encrypt(strPassword);


           var Check = userRepo.LoginCheck(strUserName.Trim(), PasswordHash.Trim());
           if (Check != null)
           {
               CreateLoggedOnUser(strUserName);
               return true;
           }
           else
           {

               return false;
           }

       }

       public void CreateLoggedOnUser(String UserName)
       {
           DisplayUser objUser = new DisplayUser();
           objUser._UserInfo.username = UserName;
           objUser.Display();
           HttpContext.Current.Session["LoggedOnUser"] = new SessionUserInfo(objUser._UserInfo);
       }

       public void ChangePassword(string OldPassword,string NewPassword)
       {
           UserRepository userRepo = new UserRepository();
           string newHassPassword = objCrypt.Encrypt(NewPassword);
           string oldHassPassword = objCrypt.Encrypt(OldPassword);

           userRepo.ChangePassword(LoggedOnUser.Userinfo.username, oldHassPassword, newHassPassword);
           HttpContext.Current.Session["LoggedOnUser"] = new SessionUserInfo(userRepo.LoggedOnUser);
       }

       public static void DestroyedUserSession()
       {
           // update loggout ke server kalau diperlukan

           HttpContext.Current.Session["LoggedOnUser"] = null;
           HttpContext.Current.Session["menuDataSource"] = null;
           HttpContext.Current.Session.Clear();
       }

   }
}
