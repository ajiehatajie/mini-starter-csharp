using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Repository.Base;
using Repository.Models;
using Repository.Helper;

namespace Repository.Businness.User
{
    public class UserRepository : BaseRepository
    {
        string sql;

        UserModel objUser = null;
        public UserModel LoggedOnUser { get { return objUser; } }
        public UserModel LoginCheck(string Username,string Password)
        {
            try
            {
                using (var conn = OpenDatabase())
                {
                    sql = "select * from users where username = ?user and password = ?password";

                    return conn.Query<UserModel>(sql, new { user = Username ,password = Password }).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserModel getData(string Username)
        {
            try
            {
                using (var conn = OpenDatabase())
                {
                    sql = "select * from users where username = ?user";
                    return conn.Query<UserModel>(sql, new { user = Username }).SingleOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ChangePassword(string Username,string oldPassword,string newPassword)
        {
            try
            {
                UserModel objUser = new UserModel();

                objUser.username = Username;
                objUser.password = oldPassword;
                objUser = getData(objUser.username);

                if(objUser != null )
                {

                    using (var conn = OpenDatabase())
                    {
                        sql = "update users set password ='" + newPassword + "' where user_id = ?userid";
                        conn.Query(sql, new { userid = objUser.user_id });
                       

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
