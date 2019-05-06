using Repository.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CmsEbook
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "save_ok", "alert('Current Password must be filled.');", true);
                return;
            }
            if (txtNewPassword.Text.Trim() == "")
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "save_ok", "alert('New Password and Confirm New Password must be filled.');", true);
                return;
            }
            if (txtNewPassword.Text.Trim() != txtConfirmNewPassword.Text.Trim())
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "save_ok", "alert('Password and Confirm Password must match each other.');", true);
                return;
            }


            try
            {
                UserSessionManager objUserSessionMgr = new UserSessionManager();
                if (!objUserSessionMgr.VerifyUser(UserSessionManager.LoggedOnUser.Userinfo.username, txtCurrentPassword.Text.Trim()))
                {
                    ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "save_ok", "alert('Current Password is not correct.');", true);
                    return;
                }
                objUserSessionMgr.ChangePassword(txtCurrentPassword.Text.Trim(), txtNewPassword.Text.Trim());
                txtCurrentPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmNewPassword.Text = "";
                ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "save_ok", "alert('Save Success.');", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "save_ok", "alert('Error Update Password.');", true);
            }
        }
    }
}