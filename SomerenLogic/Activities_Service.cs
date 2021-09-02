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
{//ivo
    public class Activities_Service
    {
        //Creates ligistic layer between DAO and program
        Activity_DAO Activity_db = new Activity_DAO();
        //Creates connection between DAO and the UI for reading from database values
        public List<Activities> GetActivities()
        {
            try
            {
                List<Activities> activity = Activity_db.Db_Get_All_Activities();
                return activity;
            }
            catch (Exception)
            {
                //something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                //List<Activities> activity = new List<Activities>();
                //Activities a = new Activities();
                //a.ActivityID = 6;
                //a.ActivityName = "None";
                //a.NumberOfStudents = 7;
                //a.NumberOfSupervisors = 1;

                //activity.Add(a);
                //Activities b = new Activities();
                //b.ActivityID = 7;
                //b.ActivityName = "None";
                //b.NumberOfStudents = 6;
                //b.NumberOfSupervisors = 2;

                //activity.Add(b);
                //return activity;
                throw new Exception("Someren couldn't connect to the database");
            }

        }
        //Logistic layers that connect the program with the database either to add, edit or delete activity
        public void SaveActivity(Activities activity)
        {
            Activity_db.Db_Save(activity);
        }
        public void editActivity(Activities activity)
        {
            Activity_db.Db_Edit(activity);
        }
        public void deleteActivity(Activities activity)
        {
            Activity_db.Db_Delete(activity);
        }
    }
}