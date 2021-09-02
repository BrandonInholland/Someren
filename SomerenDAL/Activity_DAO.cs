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
{//ivo
    //Method used to read from database table Activities
    public class Activity_DAO : Base
    {
        public List<Activities> Db_Get_All_Activities()
        {
            string query = "SELECT ID,Description,numberofSupervisors,numberofStudents FROM Activities";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        //Fills activity values into a list
        private List<Activities> ReadTables(DataTable dataTable)
        {
            List<Activities> activities = new List<Activities>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activities activity = new Activities()
                {
                    //Creates values for the table
                    ActivityID = (int)dr["ID"],
                    ActivityName = (string)(dr["Description"].ToString()),
                    NumberOfSupervisors = (int)dr["numberofSupervisors"],
                    NumberOfStudents = (int)dr["numberofStudents"],
                };
                activities.Add(activity);
            }
            return activities;
        }
        // saves activities inside the database
        public void Db_Save(Activities activity)
        {
            string query = $"INSERT INTO [Activities] VALUES ({activity.ActivityID}, '{activity.ActivityName}', {activity.NumberOfSupervisors},{activity.NumberOfStudents})";
            SqlParameter[] sqlparameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlparameters);
        }
        //edits activities inside the database
        public void Db_Edit(Activities activity)
        {
            string query = $"UPDATE [Activities] SET Description = '{activity.ActivityName}', numberofSupervisors = {activity.NumberOfSupervisors}, numberofStudents = {activity.NumberOfStudents} WHERE ID = {activity.ActivityID}";
            SqlParameter[] sqlparameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlparameters);
        }
        //deletes activities inside the database
        public void Db_Delete(Activities activity)
        {
            string query = $"DELETE FROM [Activities] WHERE ID = {activity.ActivityID}";
            SqlParameter[] sqlparameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlparameters);
        }


    }
}
