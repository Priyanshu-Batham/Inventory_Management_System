using DataAccessLayer;
using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_Main
{
    public partial class LoginForm : Form
    {
        public static string loggedInAs;
        Captcha captcha;
        public LoginForm()
        {
            InitializeComponent();
            captcha = SqlCaptcha.fetchRandomCaptcha(SqlCaptcha.fetchNoOfCaptchas());
            pictureBox1.Image = Image.FromFile(captcha.Path);
        }

        public void refreshForm()
        {
            captcha = SqlCaptcha.fetchRandomCaptcha(SqlCaptcha.fetchNoOfCaptchas());
            pictureBox1.Image = Image.FromFile(captcha.Path);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        //Admin Login
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                label8.Text = "Fill All Details First";
                label8.Visible = true;
                return;
            }

            string userCaptcha = textBox1.Text;
            if (userCaptcha != captcha.Text)
            {
                label8.Text = "Wrong Captcha Text";
                label8.Visible = true;
                refreshForm();
                return;
            }

            if (textBox2.Text != "admin" || textBox3.Text != "123")
            {
                label8.Text = "Wrong Credentials";
                label8.Visible = true;
                refreshForm();
                return;
            }

            Dashboard mainForm = new Dashboard("admin");
            loggedInAs = "admin";
            mainForm.ShowDialog();
            this.Close();
        }

        //Employee Login
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                label8.Text = "Fill All Details First";
                label8.Visible = true;
                return;
            }

            string userCaptcha = textBox1.Text;
            if (userCaptcha != captcha.Text)
            {
                label8.Text = "Wrong Captcha Text";
                label8.Visible = true;
                refreshForm();
                return;
            }

            List<Employee> employees = SqlEmployee.getAll();
            foreach (Employee employee in employees)
            {
                User user = SqlUser.getByEmployeeId(employee.id!);
                if(textBox5.Text == user.username)
                {
                    if(textBox4.Text == employee.passwordHash)
                    {
                        Dashboard mainForm = new Dashboard(employee.id!);
                        loggedInAs = employee.id!;
                        mainForm.ShowDialog();
                        this.Close();
                    }
                }
            }

            label8.Text = "Wrong Credentials";
            label8.Visible = true;
            refreshForm();
        }
    }
}
