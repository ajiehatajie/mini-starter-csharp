using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Repository.Base
{
   
    public abstract class BaseRepository
    {

        protected static IDbConnection OpenDatabase()
        {
            IDbConnection Conn = new MySqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            return Conn;
        }
    }
}
