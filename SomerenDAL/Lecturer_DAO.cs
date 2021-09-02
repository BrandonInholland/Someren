using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.ObjectModel;
using SomerenModel;


namespace SomerenDAL
{
    public class Lecturer_DAO : Base
    {
        //Created by Ivo Nachev
      
        public List<Teacher> Db_Get_All_Teachers()
        {
            string query = "SELECT Teacher_Id,[First name],[Last name],Supervisor FROM Teacher";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> lecturers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    //Creates values for the table
                    Id = (int)dr["Teacher_Id"],
                    FirstName = (String)(dr["First name"].ToString()),
                    LastName = (String)(dr["Last name"].ToString()),
                    //Room = (int)dr["Room"],
                     Supervisor = (String)(dr["Supervisor"].ToString()),
                };
                lecturers.Add(teacher);
            }
            return lecturers;
        }

        
        public void Db_Edit(Teacher teach)
        {
            string query = $"UPDATE [Teacher] SET [First Name] = '{teach.FirstName}', [Last Name] = '{teach.LastName}' WHERE Teacher_Id = {teach.Id}";
            SqlParameter[] sqlparameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlparameters);
        }
        
    }
}
