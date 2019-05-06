using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repository.Helper;
using System.Web.Security;
using Repository.Function;

namespace CmsEbook
{
    public partial class Web : System.Web.UI.MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            GlobalHelpers.DisablePageCaching();
            if (!Page.Request.IsAuthenticated || UserSessionManager.LoggedOnUser == null)
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
            }

            if (UserSessionManager.LoggedOnUser == null)
            {
                FormsAuthentication.SignOut();
                UserSessionManager.DestroyedUserSession();
                Response.Redirect(FormsAuthentication.LoginUrl);
                Response.End();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.Now.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        protected void lnlLogout_Click(object sender, EventArgs e)
        {
            UserSessionManager.DestroyedUserSession();
            FormsAuthentication.RedirectToLoginPage();


        }
    }
}