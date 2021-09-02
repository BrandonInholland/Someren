namespace SomerenUI
{
    partial class RegisteringForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Register = new System.Windows.Forms.Panel();
            this.keyTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.emailTxtBox = new System.Windows.Forms.TextBox();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Panel();
            this.Password_TXT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Email_TXT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.Register.SuspendLayout();
            this.Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // Register
            // 
            this.Register.Controls.Add(this.keyTxtBox);
            this.Register.Controls.Add(this.label4);
            this.Register.Controls.Add(this.passwordTxtBox);
            this.Register.Controls.Add(this.emailTxtBox);
            this.Register.Controls.Add(this.nameTxtBox);
            this.Register.Controls.Add(this.label3);
            this.Register.Controls.Add(this.label2);
            this.Register.Controls.Add(this.label1);
            this.Register.Controls.Add(this.backBtn);
            this.Register.Controls.Add(this.registerBtn);
            this.Register.Location = new System.Drawing.Point(1, 1);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(418, 222);
            this.Register.TabIndex = 11;
            this.Register.Paint += new System.Windows.Forms.PaintEventHandler(this.Register_Paint);
            // 
            // keyTxtBox
            // 
            this.keyTxtBox.Location = new System.Drawing.Point(132, 124);
            this.keyTxtBox.Name = "keyTxtBox";
            this.keyTxtBox.Size = new System.Drawing.Size(242, 20);
            this.keyTxtBox.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "License Key";
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.Location = new System.Drawing.Point(132, 95);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.Size = new System.Drawing.Size(242, 20);
            this.passwordTxtBox.TabIndex = 18;
            // 
            // emailTxtBox
            // 
            this.emailTxtBox.Location = new System.Drawing.Point(132, 68);
            this.emailTxtBox.Name = "emailTxtBox";
            this.emailTxtBox.Size = new System.Drawing.Size(242, 20);
            this.emailTxtBox.TabIndex = 17;
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Location = new System.Drawing.Point(132, 38);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(242, 20);
            this.nameTxtBox.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "E-Mail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(268, 161);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(106, 23);
            this.backBtn.TabIndex = 12;
            this.backBtn.Text = "Back To Login";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(164, 161);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 11;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click_1);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(64, 107);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 21;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // Login
            // 
            this.Login.Controls.Add(this.Password_TXT);
            this.Login.Controls.Add(this.label6);
            this.Login.Controls.Add(this.Email_TXT);
            this.Login.Controls.Add(this.label5);
            this.Login.Controls.Add(this.signUpBtn);
            this.Login.Controls.Add(this.loginBtn);
            this.Login.Location = new System.Drawing.Point(43, 36);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(332, 148);
            this.Login.TabIndex = 22;
            this.Login.Paint += new System.Windows.Forms.PaintEventHandler(this.Login_Paint);
            // 
            // Password_TXT
            // 
            this.Password_TXT.Location = new System.Drawing.Point(90, 53);
            this.Password_TXT.Name = "Password_TXT";
            this.Password_TXT.PasswordChar = '*';
            this.Password_TXT.Size = new System.Drawing.Size(164, 20);
            this.Password_TXT.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Password";
            // 
            // Email_TXT
            // 
            this.Email_TXT.Location = new System.Drawing.Point(90, 16);
            this.Email_TXT.Name = "Email_TXT";
            this.Email_TXT.Size = new System.Drawing.Size(164, 20);
            this.Email_TXT.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "E-mail:";
            // 
            // signUpBtn
            // 
            this.signUpBtn.Location = new System.Drawing.Point(163, 107);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(75, 23);
            this.signUpBtn.TabIndex = 22;
            this.signUpBtn.Text = "Sign Up";
            this.signUpBtn.UseVisualStyleBackColor = true;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // RegisteringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 223);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Register);
            this.Name = "RegisteringForm";
            this.Text = "RegisteringForm";
            this.Register.ResumeLayout(false);
            this.Register.PerformLayout();
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Register;
        private System.Windows.Forms.TextBox keyTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.TextBox emailTxtBox;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Panel Login;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.TextBox Password_TXT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Email_TXT;
        private System.Windows.Forms.Label label5;
    }
}