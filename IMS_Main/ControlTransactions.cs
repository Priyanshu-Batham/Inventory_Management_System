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
    public partial class ControlTransactions : UserControl
    {
        private List<Order> orders;
        private Item? item = null; //this is the item selected from the list
        List<Item> items = SqlItem.getAll(); //initial list to show available items to users

        //binding list automatically updated UIs like listbox if its datasource is set to this bindinglist
        private BindingList<UserItem> userItems = new BindingList<UserItem>(); //this is displayed on listBox whatever user has added
        public ControlTransactions()
        {
            InitializeComponent();
        }

        public void ControlTransactions_Load(object sender, EventArgs e)
        {
            //fill comboboxes with values
            comboBox3.DataSource = Enum.GetValues(typeof(DataModels.Type));
            List<Item> items = SqlItem.getAll();
            comboBox1.Items.Clear();
            foreach (var item in items)
            {
                comboBox1.Items.Add(item.id!);
            }
            listBox1.DataSource = userItems;
            comboBox5.DataSource = SqlEmployee.getAll();

            //dataGridView filling
            refreshOrderData();
        }

        private void refreshOrderData()
        {
            // Set up columns for selective properties if not already done
            dataGridView1.Columns.Clear(); // Clear existing columns if needed

            // Add columns for selective properties
            dataGridView1.Columns.Add("order_id", "order_id");
            dataGridView1.Columns.Add("customer_id", "customer_id");
            dataGridView1.Columns.Add("type", "type");
            dataGridView1.Columns.Add("total", "total");
            dataGridView1.Columns.Add("shippingAddress", "shippingAddress");
            dataGridView1.Columns.Add("createdAt", "createdAt");

            orders = SqlOrder.getAll();
            foreach (Order order in orders)
            {
                User user = SqlUser.getById(order.user_id!);
                Payment payment = SqlPayment.getByOrderId(order.id!);
                ShippingAddress shippingAddress = SqlShippingAddress.getById(payment.shippingAddress_id);
                dataGridView1.Rows.Add(order.id, user.customer_id!, payment.type.ToString(), order.total, $"{shippingAddress.city}, {shippingAddress.state}, {shippingAddress.country}", payment.createdAt);
            }
        }

        //type In/Out
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "") return;
            if (comboBox3.Text == "In")
            {
                comboBox2.Text = "self";
                comboBox4.Text = "self";
                comboBox2.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (comboBox3.Text == "Out")
            {
                comboBox2.Enabled = true;
                comboBox4.Enabled = true;
                comboBox2.DataSource = SqlCustomer.getAll();
            }
        }

        //when customer is selected so show all his shipping addresses
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "") return;
            comboBox4.DataSource = SqlShippingAddress.getMany(comboBox2.Text[0].ToString());
        }

        //when item is selected then fetch its price
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") return;
            item = getItemFromMyItemList(comboBox1.Text);
            textBox2.Text = item.price.ToString();
        }

        //when add item button is clicked
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (item == null) return;
                int quantity = Convert.ToInt32(maskedTextBox1.Text);
                if (quantity > item!.quantity) throw new Exception("Not enough quantity in Inventory");

                UserItem userItem = new UserItem(item.product_id, item.id!, item.price.ToString(), maskedTextBox1.Text, textBox3.Text);
                userItems.Add(userItem);
                item.quantity -= quantity;
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        //when remove item is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            UserItem userItem = (UserItem)listBox1.SelectedItem;
            userItems.Remove(userItem);

            item = getItemFromMyItemList(userItem.item_id);
            item.quantity += Convert.ToInt32(userItem.quantity);
        }

        //when quantity is changed
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text == "")
                {
                    textBox3.Text = "";
                    return;
                }
                decimal quantity = Convert.ToDecimal(maskedTextBox1.Text);
                if (quantity <= 0) throw new Exception("Quanitiy should be at least 1");
                decimal price = Convert.ToDecimal(textBox2.Text);
                textBox3.Text = (quantity * price).ToString();
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }


        //extra utility function
        public Item getItemFromMyItemList(string id)
        {
            foreach (Item myItem in items)
            {
                if (myItem.id == id) return myItem;
            }
            return items[0]; //you will never know why I wrote this line XD (it will never even execute lol)
        }

        //Add Order
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count == 0 || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "") return;
                User user;
                Payment payment;
                Order order;
                if (comboBox3.Text == "In")
                {
                    user = SqlUser.getByCustomerId(SqlCustomer.getSelfId());
                    order = new Order(user.id!, comboBox5.Text[0].ToString(), (DataModels.Type)Enum.Parse(typeof(DataModels.Type), comboBox3.Text), Convert.ToDecimal(textBox3.Text), 0, Convert.ToDecimal(textBox3.Text));
                    order = SqlOrder.add(order);
                    payment = new Payment(user.id!, order.id!, SqlShippingAddress.getSelfId(), Mode.Online, Status.Finished, (DataModels.Type)Enum.Parse(typeof(DataModels.Type), comboBox3.Text));
                }
                else
                {
                    user = SqlUser.getByCustomerId(comboBox2.Text[0].ToString());
                    order = new Order(user.id!, comboBox5.Text[0].ToString(), (DataModels.Type)Enum.Parse(typeof(DataModels.Type), comboBox3.Text), Convert.ToDecimal(textBox3.Text), 0, Convert.ToDecimal(textBox3.Text));
                    order = SqlOrder.add(order);
                    payment = new Payment(user.id!, order.id!, comboBox4.Text[0].ToString(), Mode.Online, Status.Finished, (DataModels.Type)Enum.Parse(typeof(DataModels.Type), comboBox3.Text));

                }
                payment = SqlPayment.add(payment);

                foreach (UserItem item in userItems)
                {
                    Order_Item orderItem = new Order_Item(item.product_id, item.item_id, order.id!, Convert.ToDecimal(item.price), Convert.ToInt64(item.quantity), Convert.ToDecimal(item.totalPrice));
                    SqlOrder_Item.add(orderItem);
                    Item inventoryQuantityUpdate = SqlItem.getById(orderItem.item_id);

                    //if sold to customer then reduce quantity from inventory
                    if (comboBox3.Text == "Out")
                    {
                        inventoryQuantityUpdate.quantity -= orderItem.quantity;
                        SqlItem.update(inventoryQuantityUpdate);
                    }
                    //if bought from supplier then increase quantity in inventory
                    else
                    {
                        inventoryQuantityUpdate.quantity += orderItem.quantity;
                        SqlItem.update(inventoryQuantityUpdate);
                    }
                }
                refreshOrderData();
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }
    }


    //temporary class for showing items added by user in the list
    public class UserItem {
        public string product_id;
        public string item_id;
        public string price;
        public string quantity;
        public string totalPrice;

        public UserItem(string product_id, string item_id, string price, string quantity, string totalPrice)
        {
            this.product_id = product_id;
            this.item_id = item_id;
            this.price = price;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
        }

        override
        public string ToString()
        {
            Product product = SqlProduct.getById(product_id);
            return $"{item_id}) {product.title}: {totalPrice}";
        }
    }
}
