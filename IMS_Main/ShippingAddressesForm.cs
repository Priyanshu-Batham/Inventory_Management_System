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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IMS_Main
{
    public partial class ShippingAddressesForm : Form
    {
        string customer_id;
        public ShippingAddressesForm(string customer_id)
        {
            InitializeComponent();
            this.customer_id = customer_id;
        }

        private void ShippingAddressesForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SqlShippingAddress.getMany(customer_id);
            User user = SqlUser.getByCustomerId(customer_id);
            label6.Text = $"{user.firstName} {user.lastName}";
        }

        //Row is clicked
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the row index is valid (e.g., avoid header row clicks)
                if (e.RowIndex >= 0)
                {
                    // Get the clicked row
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                    textBox4.Text = selectedRow.Cells[0].Value.ToString()!; //id
                    textBox5.Text = selectedRow.Cells[1].Value.ToString()!; //customer_id
                    textBox1.Text = selectedRow.Cells[2].Value.ToString()!; //city
                    textBox2.Text = selectedRow.Cells[3].Value.ToString()!; //state
                    textBox3.Text = selectedRow.Cells[4].Value.ToString()!; //country
                    richTextBox1.Text = selectedRow.Cells[5].Value.ToString()!; //more
                }
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        //Add button is clicked
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") return;
                ShippingAddress shippingAddress = new ShippingAddress(customer_id, textBox1.Text, textBox2.Text, textBox3.Text, more: richTextBox1.Text);

                //add and refresh UI
                SqlShippingAddress.add(shippingAddress);
                dataGridView1.DataSource = SqlShippingAddress.getMany(customer_id);
                MessageBox.Show("Address Added Successfully");
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        //delete button is clicked
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "") return;

                //add and refresh UI
                SqlShippingAddress.delete(textBox4.Text);
                dataGridView1.DataSource = SqlShippingAddress.getMany(customer_id);
                MessageBox.Show("Address Deleted Successfully");
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        //update button is clicked
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "") return;
                ShippingAddress shippingAddress = new ShippingAddress(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, more: richTextBox1.Text);
                shippingAddress.id = textBox4.Text;

                //update and refresh UI
                SqlShippingAddress.update(shippingAddress);
                dataGridView1.DataSource = SqlShippingAddress.getMany(customer_id);
                MessageBox.Show("Address Updated Successfully");
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
