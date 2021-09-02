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
    public partial class RegisteringForm : Form
    {
        public RegisteringForm()
        {
            InitializeComponent();
        }
        // Shows Login panel after loading the program
        private void RegisteringForm_Load(object sender, EventArgs e)
        {
            showPanel("Login");
            Register.Hide();
        }

        private void showPanel(string panelName)
        {
            if (panelName == "Login")
            {
                // hide all other panels
                Register.Hide();

                // show dashboard
                Login.Show();
            }
            else if (panelName == "Back")
            {
                // hide all other panels
                Register.Hide();

                // show dashboard
                Login.Show();
            }
            else if (panelName == "Register")
            {

                // hide all other panels
                Login.Hide();

                // show dashboard
                Register.Show();
                
            }
        }


        private void registerBtn_Click_1(object sender, EventArgs e)
        {
            string key = "XsZAbtgz3PsDqYh69unWQCEx";
            try
            {
                if ((nameTxtBox.Text == "") || (emailTxtBox.Text == "") || (passwordTxtBox.Text == "") || (keyTxtBox.Text == ""))
            {
                MessageBox.Show("You forgot to fill in a field!!!!");
            }
            else if (keyTxtBox.Text != key)
            {
                MessageBox.Show("INCORRECT KEY!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Would you like to send a request to a Admin to upgrade?", "Creating User", MessageBoxButtons.YesNo);
                UserStatus user;
                if (result == DialogResult.Yes)
                {
                    user = UserStatus.Request;
                }
                else
                {
                    user = UserStatus.User;
                    MessageBox.Show("Thank you for signing up!");
                }
                Register reg = new Register()
                {

                    Name = nameTxtBox.Text,
                    Email = emailTxtBox.Text,
                    Password = passwordTxtBox.Text,
                    Admin_Status = user

                };
                SomerenLogic.Register_Service ree = new SomerenLogic.Register_Service();
                ree.saveRegister(reg);

                //Register_Service r = new Register_Service();
                //r.saveRegister(reg);

                //clear txt's

                nameTxtBox.Text = "";
                emailTxtBox.Text = "";
                passwordTxtBox.Text = "";
                keyTxtBox.Text = "";
            }




            }
            catch (Exception)
            {

                MessageBox.Show("ERROR");
            }

        }
        private void registerBtn_Click(object sender, EventArgs e)
        {
           
        }
        // Shows panel Register
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            showPanel("Register");

        }
        // login butt0n opens SomerenUI window after user inputs correct password and checks if user is normal user user or administrator admin
        private void loginBtn_Click(object sender, EventArgs e)
        {
            SomerenLogic.Login_Services login = new SomerenLogic.Login_Services();
            List<User> users = login.GetUser();
            SomerenUI someren = new SomerenUI();
            someren.Hide();
            foreach (User u in users)
            {
                try
                {
                    if (u.EMail == Email_TXT.Text && u.Password == Password_TXT.Text)
                    {
                        
                        if (CheckUser(u))
                        {
                            someren.UserLogin();
                        }
                        someren.Show();
                        this.Hide();

                        if (u.Admin_Status == UserStatus.Admin )
                        {
                            Register_Service regReq = new Register_Service();
                            List<Register> requests = regReq.getAllRequests();

                            string text = "";


                            foreach (Register person in requests)
                            {


                                text += person.Name + "\n";
                                
                            }
                            MessageBox.Show($"{text} is requesting Admin Status");

                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            showPanel("Back");

        }

        private void Register_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {

        }
        // checks if user is of type user (normal user)
        public bool CheckUser(User user)
        {
            bool check = false;
            if (user.Admin_Status== UserStatus.User)
            {
                check =true;
            }
            return check;
        }
    }
}
