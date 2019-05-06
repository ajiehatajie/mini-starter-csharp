using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Repository.Function;

namespace CmsEbook.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        String strUserID;
        String strPassword;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginApp_Authenticate1(object sender, AuthenticateEventArgs e)
        {
            UserSessionManager userSession = new UserSessionManager();
            strUserID = LoginApp.UserName.Trim();
            strPassword = LoginApp.Password.Trim();

            if (userSession.VerifyUser(strUserID, strPassword))
            {
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(strUserID, LoginApp.RememberMeSet);
            }
            else
            {
                Session.Clear();


            }
        }

        protected void LoginApp_LoggedIn(object sender, EventArgs e)
        {

        }
    }
}