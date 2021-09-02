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
{//Made by Ivo
    public class CashRegister_DAO : Base
    {
        public List<Drink> Db_Get_All_Drinks()
        {
            // reads teacher values from database
            string query = "SELECT ID,[Name ],[Type ],Price,[Consumed by Teacher],[Consumed by Student],Stock_Records,TurnOver,VAT_CAL FROM Discobar";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadDrinks(ExecuteSelectQuery(query, sqlParameters));
        }
        private List<Drink> ReadDrinks(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    //Creates values for the table
                    ID = (int)dr["ID"],
                    Name = (String)(dr["Name "].ToString()),
                    price = (int)(dr["Price"]),
                    InStock = (int)(dr["Stock_Records"])

                };
                drinks.Add(drink);
            }
            return drinks;
        }
        public List<Student> Db_Get_All_Students()
        {
            // reads student values from database
            string query = "SELECT Student_Id,[First Name],[Family Name] FROM Students";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadStudent(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadStudent(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    //Creates values for the table
                    Id = (int)dr["Student_Id"],
                    FirstName = (String)(dr["First Name"].ToString()),
                    FamilyName = (String)(dr["Family Name"].ToString()),


                };
                students.Add(student);
            }
            return students;
        }
        
        
        public void UpdateDrinks(Stock stock)
        {
            string query = $"UPDATE [Discobar] SET [Consumed by] = {stock.Consumed_by_Student}";
            SqlParameter[] sqlparameters = new SqlParameter[0];
            ExecuteEditQuery(query, sqlparameters);
        }



    }

}
