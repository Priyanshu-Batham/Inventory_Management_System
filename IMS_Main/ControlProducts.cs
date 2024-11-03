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
    public partial class ControlProducts : UserControl
    {
        List<Product> products;
        public ControlProducts()
        {
            InitializeComponent();
            products = SqlProduct.getAll();
        }

        private void ControlProducts_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = products;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the row index is valid (e.g., avoid header row clicks)
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells[0].Value.ToString(); // Value of the first cell
                textBox8.Text = selectedRow.Cells[1].Value.ToString();
                richTextBox1.Text = selectedRow.Cells[2].Value.ToString();
                richTextBox2.Text = selectedRow.Cells[3].Value.ToString();
            }
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "") return;

            Product product = new Product(textBox8.Text, richTextBox1.Text);

            try
            {
                product = SqlProduct.add(product);
                products = SqlProduct.getAll();
                dataGridView1.DataSource = products;
                MessageBox.Show($"Product added with id: {product.id}");
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        //Delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            try
            {
                SqlProduct.delete(textBox1.Text);
                MessageBox.Show("Item deleted");
                //refresh grid
                products = SqlProduct.getAll();
                dataGridView1.DataSource = products;
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        //update
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;

            Product product = new Product(textBox8.Text, richTextBox1.Text);
            product.id = textBox1.Text;

            try
            {
                SqlProduct.update(product);
                //refreshing
                products = SqlProduct.getAll();
                dataGridView1.DataSource = products;
                MessageBox.Show("Item Updated Successfully");
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }
    }
}
