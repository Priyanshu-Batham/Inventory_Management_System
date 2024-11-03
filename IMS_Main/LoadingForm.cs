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
    public partial class LoadingForm : Form
    {
        bool flag = false;
        int value = 0;
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            value += 20;
            if(value <= 100) progressBar1.Value = value;
            if (value >= 120)
            {
                timer1.Enabled = false;
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
