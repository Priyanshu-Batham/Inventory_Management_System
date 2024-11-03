using DataAccessLayer;
using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_Main
{
    public partial class Controlinventory : UserControl
    {
        List<Item> items;
        Item? item;
        public Controlinventory()
        {
            InitializeComponent();
        }

        //initial fetch to load data
        public void Controlinventory_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            //comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            items = SqlItem.getAll();
            this.BackColor = Color.FromArgb(12, 0, 50); //had to do this coz it wasn't changing from ui settings
            dataGridView1.DataSource = items;
            List<Product> products = SqlProduct.getAll();
            //List<Brand> brands = SqlBrand.getAll();
            List<Supplier> suppliers = SqlSupplier.getAll();
            foreach (var item in products)
            {
                comboBox1.Items.Add(item.id!);
            }
            //foreach (var item in brands)
            //{
            //    comboBox2.Items.Add(item.id!);
            //}
            foreach (var item in suppliers)
            {
                comboBox3.Items.Add(item.id!);
            }
        }

        //when a row is selected
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the row index is valid (e.g., avoid header row clicks)
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells[0].Value.ToString(); // Value of the first cell
                comboBox1.Text = selectedRow.Cells[1].Value.ToString();
                //comboBox2.Text = selectedRow.Cells[2].Value.ToString();
                comboBox3.Text = selectedRow.Cells[3].Value.ToString();
                textBox8.Text = selectedRow.Cells[4].Value.ToString();
                textBox7.Text = selectedRow.Cells[5].Value.ToString();
                textBox6.Text = selectedRow.Cells[6].Value.ToString();
                textBox5.Text = selectedRow.Cells[7].Value.ToString();
                textBox9.Text = selectedRow.Cells[8].Value.ToString();
            }
        }

        //Delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "" || comboBox3.Text == "") return;
            try
            {
                SqlItem.delete(textBox1.Text);
                MessageBox.Show("Item deleted");
                //refresh grid
                items = SqlItem.getAll();
                dataGridView1.DataSource = items;
            }
            catch(Exception ex)
            {
                label10.Text = ex.Message;
            }
            
        }

        //Add
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            if (textBox8.Text == "" || comboBox1.Text == "" || comboBox3.Text == "") return;

            Item item = new Item(comboBox1.Text, "1", comboBox3.Text, Convert.ToDecimal(textBox8.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox6.Text), Convert.ToDecimal(textBox5.Text), Convert.ToInt64(textBox9.Text));

                SqlItem.add(item);
                Controlinventory_Load(sender, e); //reloads OR refreshes not working
                items = SqlItem.getAll();
                dataGridView1.DataSource = items;
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        //update
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "" || comboBox3.Text == "") return;

            Item item = new Item(comboBox1.Text, "1", comboBox3.Text, Convert.ToDecimal(textBox8.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox6.Text), Convert.ToDecimal(textBox5.Text), Convert.ToInt64(textBox9.Text));
            item.id = textBox1.Text;

            try
            {
                SqlItem.update(item);
                //refreshing
                items = SqlItem.getAll();
                dataGridView1.DataSource = items;
                MessageBox.Show("Item Updated Successfully");
            }
            catch (Exception ex)
            {
                label10.Text = ex.Message;
            }
        }
    }
}
