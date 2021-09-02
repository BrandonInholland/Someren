using SomerenLogic;
using SomerenModel;
using System;
using SomerenDAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {

        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }
       
        private void showPanel(string panelName)
        {
            
            if (panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_Stocks.Hide();
                pnl_Drinks.Hide();
                pnl_Supervisors.Hide();
                pnl_Activity.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                //Made by Brandon Palmer
                try
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Lecturers.Hide();
                    pnl_Stocks.Hide();
                    pnl_Drinks.Hide();
                    pnl_Supervisors.Hide();
                    pnl_Activity.Hide();

                    // show students
                    pnl_Students.Show();
                    // fill the students listview within the students panel with a list of students
                    SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                    List<Student> studentList = studService.GetStudents();
                    listViewStudents.Clear();
                    foreach (Student s in studentList)
                    {
                       //Creats items for the table 
                        ListViewItem li = new ListViewItem(s.Id.ToString());
                        //Add the items from the table
                        li.SubItems.Add(s.FirstName);
                        li.SubItems.Add(s.FamilyName);
                        //li.SubItems.Add(s.Room.ToString());
                        li.SubItems.Add(s.Activities_Id.ToString());
                        li.SubItems.Add(s.Course);
                        
                        listViewStudents.Items.Add(li);
                    }
                    //Adds the columns to the table
                    listViewStudents.View = View.Details;
                    listViewStudents.Columns.Add("Id", 100, HorizontalAlignment.Left);
                    listViewStudents.Columns.Add("First Name", 100, HorizontalAlignment.Left);
                    listViewStudents.Columns.Add("Family Name", 100, HorizontalAlignment.Left);
                    //listViewStudents.Columns.Add("Room", 100, HorizontalAlignment.Left);
                    listViewStudents.Columns.Add("Activities Id", 100, HorizontalAlignment.Left);
                    listViewStudents.Columns.Add("Course", 100, HorizontalAlignment.Left);
                    

                    // clear the listview before filling it again
                }
                //if runtime error occurs, display error box  and save it to a log file
                catch (Exception )
                {
                    DateTime TimeOfError = DateTime.Now;
                    string error = "Could not connect to the Student Database, please try again later.";
                    string filename = "error.txt";
                    StreamWriter errorlog = new StreamWriter(filename,true);

                    errorlog.WriteLine(error);
                    errorlog.WriteLine(TimeOfError);
                    errorlog.Close();

                    MessageBox.Show(error);

                }
            }
            else if (panelName == "Lecturers")
            {
                //Made by Ivo Nachev
                try
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Stocks.Hide();
                    pnl_Drinks.Hide();
                    pnl_Supervisors.Hide();
                    pnl_Activity.Hide();

                    // show teachers
                    pnl_Lecturers.Show();

                    // fill the students listview within the students panel with a list of students
                    SomerenLogic.Lecturer_Service teachService = new SomerenLogic.Lecturer_Service();
                    List<Teacher> teacherList = teachService.GetTeachers();
                    listViewTeachers.Clear();
                    foreach (Teacher t in teacherList)
                    {

                        ListViewItem li = new ListViewItem(t.Id.ToString());

                        li.SubItems.Add(t.FirstName);
                        li.SubItems.Add(t.LastName);
                        //li.SubItems.Add(t.Room.ToString());
                        li.SubItems.Add(t.Supervisor);

                        listViewTeachers.Items.Add(li);

                    }
                    listViewTeachers.View = View.Details;
                    listViewTeachers.Columns.Add("Id", 100, HorizontalAlignment.Left);
                    listViewTeachers.Columns.Add("First Name", 100, HorizontalAlignment.Left);
                    listViewTeachers.Columns.Add("Last Name", 100, HorizontalAlignment.Left);
                    listViewStudents.Columns.Add("Room", 100, HorizontalAlignment.Left);
                    listViewTeachers.Columns.Add("Supervisor", 100, HorizontalAlignment.Left);

                    // clear the listview before filling it again
                }
                catch (Exception)
                {
                    DateTime TimeOfError = DateTime.Now;
                    string error = "Could not connect to the Lecturers Database, please try again later.";
                    string filename = "error.txt";
                    StreamWriter errorlog = new StreamWriter(filename,true);
                    
                    errorlog.WriteLine(error);
                    errorlog.WriteLine(TimeOfError);
                    errorlog.Close();

                    MessageBox.Show(error);
                }
            }
            else if (panelName == "Stocks")
            {
                //Made by Brandon Palmer
                try
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Lecturers.Hide();
                    pnl_Drinks.Hide();
                    pnl_Supervisors.Hide();
                    pnl_Activity.Hide();

                    // show stock
                    pnl_Stocks.Show();

                    // fill the stock listview within the stock panel with a list of drinks
                    SomerenLogic.Stock_Service stockService = new SomerenLogic.Stock_Service();
                    List<Stock> stockList = stockService.GetStocks();
                    listViewStocks.Clear();
                    foreach (Stock s in stockList)
                    {
                        
                        ListViewItem li = new ListViewItem(s.Id.ToString());

                        li.SubItems.Add(s.Name);
                        li.SubItems.Add(s.Type);
                        li.SubItems.Add(s.Price.ToString());
                        li.SubItems.Add(s.Stocks.ToString());

                        li.Tag = s;

                        listViewStocks.Items.Add(li);

                    }
                    listViewStocks.View = View.Details;
                    listViewStocks.FullRowSelect = true;
                    listViewStocks.Columns.Add("ID", 100, HorizontalAlignment.Left);
                    listViewStocks.Columns.Add("Name", 100, HorizontalAlignment.Left);
                    listViewStocks.Columns.Add("Type", 100, HorizontalAlignment.Left);
                    listViewStocks.Columns.Add("Price", 100, HorizontalAlignment.Left);
                    listViewStocks.Columns.Add("Stock_Records", 100, HorizontalAlignment.Left);


                    // clear the listview before filling it again
                }
                catch (Exception)
                {
                    DateTime TimeOfError = DateTime.Now;
                    string error = "Could not connect to the Stocks Database, please try again later.";
                    string filename = "error.txt";
                    StreamWriter errorlog = new StreamWriter(filename, true);

                    errorlog.WriteLine(error);
                    errorlog.WriteLine(TimeOfError);
                    errorlog.Close();

                    MessageBox.Show(error);
                }
            }
            else if (panelName == "Discobar")
            {

                try
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Lecturers.Hide();
                    pnl_Stocks.Hide();
                    pnl_Supervisors.Hide();
                    pnl_Activity.Hide();

                    // show cash register panel 
                    pnl_Drinks.Show();

                    // fill the students and drinks listview within the students panel with a list of students
                    SomerenLogic.Cash_Register_Service studService = new SomerenLogic.Cash_Register_Service();
                    List<Student> studentList = studService.GetTheStudents();
                    SomerenLogic.Cash_Register_Service drinkService = new SomerenLogic.Cash_Register_Service();
                    List<Drink> drinksList = drinkService.GetDrink();

                    listViewCustomer.Clear();
                    foreach (Student s in studentList)
                    {
                        //Creats items for the table 
                        ListViewItem li = new ListViewItem(s.FirstName + " " + s.FamilyName);
                        //Add the items from the table

                        li.SubItems.Add(s.Id.ToString());
                        li.Tag = s;

                        listViewCustomer.Items.Add(li);

                    }
                    //Adds the columns to the table
                    listViewCustomer.View = View.Details;
                    listViewCustomer.Columns.Add("Name", 100, HorizontalAlignment.Left);
                    listViewCustomer.Columns.Add("Id", 100, HorizontalAlignment.Left);


                    // clear the listview before filling it again

                    listViewDrink.Clear();


                    foreach (Drink d in drinksList)
                    {
                        //Creats items for the table 
                        ListViewItem lis = new ListViewItem(d.ID.ToString());
                        //Add the items from the table
                        lis.SubItems.Add(d.Name);
                        lis.SubItems.Add(d.price.ToString());
                        lis.SubItems.Add(d.InStock.ToString());
                        lis.Tag = d;
                        listViewDrink.Items.Add(lis);

                    }

                    //Adds the columns to the table
                    listViewDrink.View = View.Details;
                    //listViewSelection.View = View.Details;
                    listViewDrink.Columns.Add("ID", 100, HorizontalAlignment.Left);
                    listViewDrink.Columns.Add("Name", 100, HorizontalAlignment.Left);
                    listViewDrink.Columns.Add("Price", 100, HorizontalAlignment.Left);
                    listViewDrink.Columns.Add("In stock", 100, HorizontalAlignment.Left);

                    // clear the listview before filling it again
                }
                catch (Exception)
                {
                    DateTime TimeOfError = DateTime.Now;
                    string error = "Could not connect to the Drinks Database, please try again later.";
                    string filename = "error.txt";
                    StreamWriter errorlog = new StreamWriter(filename, true);

                    errorlog.WriteLine(error);
                    errorlog.WriteLine(TimeOfError);
                    errorlog.Close();

                    MessageBox.Show(error);
                }
            }
            else if (panelName == "Supervisors")
            {
                try
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Lecturers.Hide();
                    pnl_Stocks.Hide();
                    pnl_Drinks.Hide();
                    pnl_Activity.Hide();

                    // show Supervisors panel
                    pnl_Supervisors.Show();
                    //for the drop down 
                    SomerenLogic.Lecturer_Service LecturerService = new SomerenLogic.Lecturer_Service();
                    List<Teacher> teachList = LecturerService.GetTeachers();
                    comboBoxLecturer.Items.Clear();
                    foreach (Teacher t in teachList)
                    {
                        comboBoxLecturer.Items.Add(t);
                        
                    }
                    
                    //for the listview of supervisors
                    SomerenLogic.Supervisor_Service supService = new SomerenLogic.Supervisor_Service();
                    List<Supervisor> supervisorList = supService.GetSupervisor();
                    listViewSupervisor.Clear();
                    foreach (Supervisor s in supervisorList)
                    {

                        ListViewItem li = new ListViewItem(s.Id.ToString());

                        li.SubItems.Add(s.FirstName);
                        li.SubItems.Add(s.LastName);


                        li.Tag = s;
                        listViewSupervisor.Items.Add(li);

                    }
                    listViewSupervisor.View = View.Details;
                    listViewSupervisor.FullRowSelect = true;
                    listViewSupervisor.Columns.Add("Id", 70, HorizontalAlignment.Left);
                    listViewSupervisor.Columns.Add("First Name", 80, HorizontalAlignment.Left);
                    listViewSupervisor.Columns.Add("Last Name", 80, HorizontalAlignment.Left);

                    SomerenLogic.Activities_Service activityService = new SomerenLogic.Activities_Service();
                    List<Activities> activityList = activityService.GetActivities();

                }
                catch (Exception)
                {
                    DateTime TimeOfError = DateTime.Now;
                    string error = "Could not connect to the Lecturer Database, please try again later.";
                    string filename = "error.txt";
                    StreamWriter errorlog = new StreamWriter(filename, true);

                    errorlog.WriteLine(error);
                    errorlog.WriteLine(TimeOfError);
                    errorlog.Close();

                    MessageBox.Show(error);
                }



            }
            else if (panelName == "Activity")
            {

                try
                {
                    // hide all other panels
                    pnl_Dashboard.Hide();
                    img_Dashboard.Hide();
                    pnl_Students.Hide();
                    pnl_Lecturers.Hide();
                    pnl_Stocks.Hide();
                    pnl_Drinks.Hide();
                    pnl_Supervisors.Hide();

                    // show cash register panel 
                    pnl_Activity.Show();

                    // fill the activities listview 
                    SomerenLogic.Activities_Service activityService = new SomerenLogic.Activities_Service();
                    List<Activities> activityList = activityService.GetActivities();


                    listViewActivities.Clear();
                    foreach (Activities a in activityList)
                    {
                        //Creats items for the table 
                        ListViewItem li = new ListViewItem(a.ActivityID.ToString());
                        //Add the items from the table

                        li.SubItems.Add(a.ActivityName);
                        li.SubItems.Add(a.NumberOfStudents.ToString());
                        li.SubItems.Add(a.NumberOfSupervisors.ToString());
                        li.Tag = a;
                        listViewActivities.Items.Add(li);
                    }
                    //Adds the columns to the table
                    listViewActivities.View = View.Details;
                    listViewActivities.Columns.Add("Activity ID", 100, HorizontalAlignment.Left);
                    listViewActivities.Columns.Add("Description", 100, HorizontalAlignment.Left);
                    listViewActivities.Columns.Add("Number of supervisors", 100, HorizontalAlignment.Left);
                    listViewActivities.Columns.Add("Number of students", 100, HorizontalAlignment.Left);

                }

                // clear the listview before filling it again
                catch (Exception)
                {
                    DateTime TimeOfError = DateTime.Now;
                    string error = "Could not connect to the  Database, please try again later.";
                    string filename = "error.txt";
                    StreamWriter errorlog = new StreamWriter(filename, true);

                    errorlog.WriteLine(error);
                    errorlog.WriteLine(TimeOfError);
                    errorlog.Close();

                    MessageBox.Show(error);
                }
            }
        }
    
        //add method for the button
        private void add(int Id, String Name, String Type, int Price, int Stock_Records )
        {
            String[] row = { Id.ToString(), Name, Type, Price.ToString(), Stock_Records.ToString() };

            ListViewItem item = new ListViewItem(row);

            listViewStocks.Items.Add(item);
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //displays the table panel
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //displays the table panel
            showPanel("Lecturers");
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dispalys the stock panel
            showPanel("Stocks");
        }
        private void discobarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Discobar");
        }
        private void supervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
            
        }
        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void activitiesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //dispalys the activities panel
            showPanel("Activity");
        }


        //made by Brandon Palmer
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Add Button
                add(int.Parse(idTxt.Text), nameTxt.Text, typeTxt.Text, int.Parse(priceTxt.Text), int.Parse(stockTxt.Text));


                Stock sto = new Stock()
                {
                    Id = int.Parse(idTxt.Text),
                    Name = nameTxt.Text,
                    Type = typeTxt.Text,
                    Price = int.Parse(priceTxt.Text),
                    Stocks = int.Parse(stockTxt.Text),
                    Consumed_by_Teacher = 20477, 
                    Consumed_by_Student = 616702,
                    TurnOver = 0,
                    VAT_CAL = 0,
                };

                Stock_Service s = new Stock_Service();
                s.saveStock(sto); 
            
                //clear txt's
                idTxt.Text = "";
                nameTxt.Text = "";
                typeTxt.Text = "";
                priceTxt.Text = "";
                stockTxt.Text = "";
            }
            catch (Exception)
            {

                MessageBox.Show("No Input");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Edit Button
            ListViewItem item = new ListViewItem();
            item = this.listViewStocks.SelectedItems[0];
            item.SubItems[0].Text = idTxt.Text;
            item.SubItems[1].Text = nameTxt.Text;
            item.SubItems[2].Text = typeTxt.Text;
            item.SubItems[3].Text = priceTxt.Text;
            item.SubItems[4].Text = stockTxt.Text;

            Stock sto = new Stock()
            {
                Id = int.Parse(idTxt.Text),
                Name = nameTxt.Text,
                Type = typeTxt.Text,
                Price = int.Parse(priceTxt.Text),
                Stocks = int.Parse(stockTxt.Text),
                Consumed_by_Teacher = 20477,
                Consumed_by_Student = 616702,
                TurnOver = 0,
                VAT_CAL = 0,
            };
            Stock_Service s = new Stock_Service();
            s.editStock(sto);
            }
            catch (Exception)
            {

                MessageBox.Show("No Drink Selected For Editing");
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
          

            try
            {  //Delete Button
            listViewStocks.SelectedItems[0].SubItems.Clear();
            Stock sto = new Stock()
            {
                Id = int.Parse(idTxt.Text),
                Name = nameTxt.Text,
                Type = typeTxt.Text,
                Price = int.Parse(priceTxt.Text),
                Stocks = int.Parse(stockTxt.Text),
                Consumed_by_Teacher = 20477,
                Consumed_by_Student = 616702,
                TurnOver = 0,
                VAT_CAL = 0,
            };
            Stock_Service s = new Stock_Service();
            s.deleteStock(sto);

            idTxt.Text = "";
            nameTxt.Text = "";
            typeTxt.Text = "";
            priceTxt.Text = "";
            stockTxt.Text = "";
            }
            catch (Exception)
            {

                MessageBox.Show("Select Deletion Target");
            }

           
        }
        // fills in text boxes with the selected stock
        private void listViewStocks_MouseClick(object sender, MouseEventArgs e)
        {
            String id = listViewStocks.SelectedItems[0].SubItems[0].Text;
            String name = listViewStocks.SelectedItems[0].SubItems[1].Text;
            String type = listViewStocks.SelectedItems[0].SubItems[2].Text;
            String price = listViewStocks.SelectedItems[0].SubItems[3].Text;
            String Stock = listViewStocks.SelectedItems[0].SubItems[4].Text;

            idTxt.Text = id;
            nameTxt.Text = name;
            typeTxt.Text = type;
            priceTxt.Text = price;
            stockTxt.Text = Stock;
        }



        private void listViewCustomer_MouseClick_1(object sender, MouseEventArgs e)
        {


        }

        //Ivo's parts


        private void button1_Click_3(object sender, EventArgs e)
        {
            //button
            int sum = int.Parse(Price.Text);
            sum += sum;
            string total = sum.ToString();

            Stock drinks = new Stock();
            drinks.Consumed_by_Student = int.Parse(lblReciept.Text + " ID " + lblStudentId.Text);
            SomerenLogic.Cash_Register_Service drinkService = new SomerenLogic.Cash_Register_Service();

            drinkService.UpdateDrinks(drinks);
            MessageBox.Show(total + " euro", lblReciept.Text + " ");
            lblReciept.Text = "?????";
            Price.Text = "????";
            lblStudentId.Text = "?????";


        }
        private void listViewDrink_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Sell_Click(object sender, EventArgs e)
        {
            try
            {
                //adding to db            
                salesService sellserv = new salesService();
                sellserv.Add(new Sales() { drinkId = int.Parse(drinkIdlbl.Text), studentId = int.Parse(lblStudentId.Text), Id = 0 });
                MessageBox.Show("Sale Made");
            }
            catch (Exception)
            {

                MessageBox.Show("Nothing Selected");
            }
               
        }

        private void listViewDrink_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //displaying selection of student
            int count = 0;

            if (listViewDrink.SelectedItems.Count == 0)
            {
                return;
            }

            Drink drink = new Drink();
            for (int i = 0; i < listViewDrink.SelectedItems.Count; i++)
            {
                count++;
                drink = (Drink)listViewDrink.SelectedItems[0].Tag;
                listViewDrink.SelectedItems[0].SubItems[2].Text = listViewDrink.SelectedItems[0].SubItems[2].Text;

            }
            Price.Text = listViewDrink.SelectedItems[0].SubItems[2].Text;
            drinkIdlbl.Text = listViewDrink.SelectedItems[0].SubItems[0].Text;
        }

        private void listViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Displaying selection of customer
            if (listViewCustomer.SelectedItems.Count == 0)
            {
                return;
            }
            lblReciept.Text = listViewCustomer.SelectedItems[0].SubItems[0].Text;
            lblStudentId.Text = listViewCustomer.SelectedItems[0].SubItems[1].Text;
        }

        private void pnl_Drinks_Paint(object sender, PaintEventArgs e)
        {

        }


        //Brandon's buttons

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
        // edits supervisors
        private void buttonEdit_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listViewSupervisor.SelectedItems.Count == 0)
                {
                    return;
                }


                Teacher teach = new Teacher()
                {
                    Id = int.Parse(listViewSupervisor.SelectedItems[0].SubItems[0].Text),
                    FirstName = textBoxFirst.Text,
                    LastName = textBoxSurname.Text,



                };
                Lecturer_Service t = new Lecturer_Service();
                t.editLectuerer(teach);
                showPanel("Supervisors");
            }
            catch (Exception)
            {

                MessageBox.Show("You need to select someone to edit");
            }
            
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            try
            {  //Delete Button

                DialogResult result = MessageBox.Show("Are you sure you want to remove this supervisor?", "Removing Supervisor",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Supervisor teach = new Supervisor()
                    {
                        Id = ((Supervisor)listViewSupervisor.SelectedItems[0].Tag).Id,
                        FirstName = textBoxFirst.Text,
                        LastName = textBoxSurname.Text,
                    };
                    Supervisor_Service s = new Supervisor_Service();
                    s.deleteSupervisor(teach);

                    textBoxFirst.Text = "";
                    textBoxSurname.Text = "";
                    listViewSupervisor.SelectedItems[0].SubItems.Clear();
                    showPanel("Supervisors");
                }



                
            }
            catch (Exception)
            {

                MessageBox.Show("Select Deletion Target");
            }

}
        // fills in supervisor
        private void listViewSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSupervisor.SelectedItems.Count == 0)
            {
                return;
            }
            String id = listViewSupervisor.SelectedItems[0].SubItems[0].Text;
            String firstname = listViewSupervisor.SelectedItems[0].SubItems[1].Text;
            String lastname = listViewSupervisor.SelectedItems[0].SubItems[2].Text;
            

            textBoxFirst.Text = firstname;
            textBoxSurname.Text = lastname;

            
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                Teacher super = (Teacher)comboBoxLecturer.SelectedItem;

                Supervisor_Service superserv = new Supervisor_Service();
                superserv.AddSupervisor(super);
                MessageBox.Show($"{super.FirstName} has become a Supervisor! Congrats!");
                showPanel("Supervisors");
            }
            catch (Exception)
            {

                MessageBox.Show("OH NO! You have made a invalid selection!");
            }
            
        }
        // adds activities from the textboxes into listview
        private void addActivity(int Id, String Desc, int numStudents, int numSupervisors)
        {
            String[] row = { Id.ToString(), Desc, numStudents.ToString(), numSupervisors.ToString() };

            ListViewItem item = new ListViewItem(row);

            listViewActivities.Items.Add(item);
        }

        // coppies activity values from the textboxes and adds them into listview and database
        private void btnAddActivity_Click(object sender, EventArgs e)
        {

            addActivity(int.Parse(ActivityIDtxt.Text), ActivityDESCtxt.Text, int.Parse(NumberOfStudentsTXT.Text), int.Parse(NumberOfSupervisorsTXT.Text));

            Activities a = new Activities()
            {
                ActivityID = int.Parse(ActivityIDtxt.Text),
                ActivityName = ActivityDESCtxt.Text.ToString(),
                NumberOfStudents = int.Parse(NumberOfStudentsTXT.Text),
                NumberOfSupervisors = int.Parse(NumberOfSupervisorsTXT.Text),

            };

            Activities_Service act = new Activities_Service();
            act.SaveActivity(a);

            //clear txt's
            ActivityIDtxt.Text = "";
            ActivityDESCtxt.Text = "";
            NumberOfStudentsTXT.Text = "";
            NumberOfSupervisorsTXT.Text = "";

        }


        private void pnl_Activity_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewStocks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // makes selected activity values from ListView be pasted into the textboxes
        private void listViewActivities_MouseClick(object sender, MouseEventArgs e)
        {
            string ID = listViewActivities.SelectedItems[0].SubItems[0].Text;
            string Description = listViewActivities.SelectedItems[0].SubItems[1].Text;
            string NumberOfStudents = listViewActivities.SelectedItems[0].SubItems[2].Text;
            string NumberOfSupervisors = listViewActivities.SelectedItems[0].SubItems[3].Text;


            ActivityIDtxt.Text = ID;
            ActivityDESCtxt.Text = Description;
            NumberOfStudentsTXT.Text = NumberOfStudents;
            NumberOfSupervisorsTXT.Text = NumberOfSupervisors;

        }
        //updates activity
        private void btnUpdateActivity_Click(object sender, EventArgs e)
        {

            try
            {
                ListViewItem item = new ListViewItem();
                item = this.listViewActivities.SelectedItems[0];

                item.SubItems[0].Text = ActivityIDtxt.Text;
                item.SubItems[1].Text = ActivityDESCtxt.Text;
                item.SubItems[2].Text = NumberOfStudentsTXT.Text;
                item.SubItems[3].Text = NumberOfSupervisorsTXT.Text;


                Activities a = new Activities()
                {
                    ActivityID = int.Parse(ActivityIDtxt.Text),
                    ActivityName = ActivityDESCtxt.Text,
                    NumberOfStudents = int.Parse(NumberOfStudentsTXT.Text),
                    NumberOfSupervisors = int.Parse(NumberOfSupervisorsTXT.Text),

                };
                Activities_Service act = new Activities_Service();
                act.editActivity(a);
            }
            catch (Exception)
            {
                MessageBox.Show("Choose an activity");
            }
        }


        private void btnUpdateActivity_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddActivity_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelActivity_Click_1(object sender, EventArgs e)
        {

        }
        //deletes activity after delete button is pressed
        private void btnDelActivity_MouseClick(object sender, MouseEventArgs e)
        {
            // displays messege box awith yes/no answer
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to remove this activity", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //deletes activity from database if yes 
                try
                {
                    listViewActivities.SelectedItems[0].SubItems.Clear();
                    Activities a = new Activities()
                    {
                        ActivityID = int.Parse(ActivityIDtxt.Text),
                        ActivityName = ActivityDESCtxt.Text,
                        NumberOfStudents = int.Parse(NumberOfStudentsTXT.Text),
                        NumberOfSupervisors = int.Parse(NumberOfSupervisorsTXT.Text),
                    };
                    listViewActivities.Refresh();
                    Activities_Service act = new Activities_Service();
                    act.deleteActivity(a);

                    idTxt.Text = "";
                    nameTxt.Text = "";
                    typeTxt.Text = "";
                    priceTxt.Text = "";
                    stockTxt.Text = "";
                }
                catch (Exception)
                {

                    MessageBox.Show("Please select a target.");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                listViewActivities.Refresh();
                Activities a = new Activities()
                {
                    ActivityID = int.Parse(ActivityIDtxt.Text),
                    ActivityName = ActivityDESCtxt.Text,
                    NumberOfStudents = int.Parse(NumberOfStudentsTXT.Text),
                    NumberOfSupervisors = int.Parse(NumberOfSupervisorsTXT.Text),
                };
            }

        }
        // updates activity after mouse clicjk
        private void btnUpdateActivity_MouseCaptureChanged(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = new ListViewItem();
                item = this.listViewActivities.SelectedItems[0];

                item.SubItems[0].Text = ActivityIDtxt.Text;
                item.SubItems[1].Text = ActivityDESCtxt.Text;
                item.SubItems[2].Text = NumberOfStudentsTXT.Text;
                item.SubItems[3].Text = NumberOfSupervisorsTXT.Text;


                Activities a = new Activities()
                {
                    ActivityID = int.Parse(ActivityIDtxt.Text),
                    ActivityName = ActivityDESCtxt.Text,
                    NumberOfStudents = int.Parse(NumberOfStudentsTXT.Text),
                    NumberOfSupervisors = int.Parse(NumberOfSupervisorsTXT.Text),

                };
                Activities_Service act = new Activities_Service();
                act.editActivity(a);
            }
            catch (Exception)
            {
                MessageBox.Show("Choose an activity");
            }
        }
        //Adds activity inside the database after button is pressed
        private void btnAddActivity_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                addActivity(int.Parse(ActivityIDtxt.Text), ActivityDESCtxt.Text, int.Parse(NumberOfStudentsTXT.Text), int.Parse(NumberOfSupervisorsTXT.Text));

                Activities a = new Activities()
                {
                    ActivityID = int.Parse(ActivityIDtxt.Text),
                    ActivityName = ActivityDESCtxt.Text.ToString(),
                    NumberOfStudents = int.Parse(NumberOfStudentsTXT.Text),
                    NumberOfSupervisors = int.Parse(NumberOfSupervisorsTXT.Text),

                };

                Activities_Service act = new Activities_Service();
                act.SaveActivity(a);

                //clear txt's
                ActivityIDtxt.Text = "";
                ActivityDESCtxt.Text = "";
                NumberOfStudentsTXT.Text = "";
                NumberOfSupervisorsTXT.Text = "";
            }
            catch (Exception)
            {

                MessageBox.Show("Please add values into the textboxes!");
            }
            
        }

        private void ActivityIDtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnl_Activity_Paint_1(object sender, PaintEventArgs e)
        {

        }
        // Disabbles all buttons for normal user in SomerenUI
        public void UserLogin()
        {
            btnAddActivity.Enabled = false;
            btnUpdateActivity.Enabled = false;
            btnDelActivity.Enabled = false;
            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonEdit.Enabled = false;
            addBtn.Enabled = false;
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
            Sell.Enabled = false;

        }

        private void pnl_Stocks_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
