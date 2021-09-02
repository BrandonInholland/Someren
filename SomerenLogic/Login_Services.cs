using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SomerenLogic
{
    public class Login_Services
    {
        //Creates ligistic layer between DAO and program
        UserLogin_DAO user_db = new UserLogin_DAO();
        // fills Users from the database into a list
        public List<User> GetUser()
        {
            
                List<User> user = user_db.Db_User_Login();
                return user;
            
            

                throw new Exception("Someren couldn't connect to the database");
            
        }
    }
}