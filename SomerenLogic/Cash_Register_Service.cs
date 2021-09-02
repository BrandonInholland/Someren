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
    public class Cash_Register_Service
    {

        CashRegister_DAO cash_register_db = new CashRegister_DAO();


        public List<Drink> GetDrink()
        {
            try
            {
                List<Drink> drink = cash_register_db.Db_Get_All_Drinks();

                return drink;
            }
            catch (Exception)
            {

                throw new Exception("Someren couldn't connect to the database");
            }

        }
        public List<Student> GetTheStudents()
        {
            try
            {
                List<Student> student = cash_register_db.Db_Get_All_Students();
                return student;
            }
            catch (Exception)
            {

                throw new Exception("Someren couldn't connect to the database");
            }

        }
        public void UpdateDrinks(Stock stock)
        {
            cash_register_db.UpdateDrinks(stock);
        }

    }
}

