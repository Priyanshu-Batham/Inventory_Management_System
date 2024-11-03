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
    public partial class ControlDashboard : UserControl
    {
        public ControlDashboard()
        {
            InitializeComponent();
            refreshProfit();
            refreshBestCustomer();
            refreshUserCount();
            refreshBiggestOrderValue();
            refreshInventoryOnAlarmQuantity();
            refreshDate();
        }

        public void refreshProfit()
        {
            decimal profit = 0;
            List<Order> orders = SqlOrder.getAll();
            foreach (Order order in orders)
            {
                if(order.type == DataModels.Type.Out)
                {
                    profit += order.total;
                }
            }
            label3.Text = $"Rs {profit}";
        }

        public void refreshBestCustomer()
        {
            label7.Text = "Not Known Yet";
            List<Order> orders = SqlOrder.getAll();
            if (orders.Count > 0)
            {
                decimal value = 0;
                Order? biggestOrder = null;
                foreach (Order order in orders)
                {
                    if(order.type == DataModels.Type.Out && order.total > value)
                    {
                        biggestOrder = order;
                        value = order.total;
                    }
                }
                if (biggestOrder != null)
                {
                    User user = SqlUser.getById(biggestOrder.user_id);
                    label7.Text = $"{user.firstName} {user.lastName}";
                }
            }
        }

        public void refreshUserCount()
        {
            List<Customer> customers = SqlCustomer.getAll();
            List<Supplier> suppliers = SqlSupplier.getAll();
            List<Employee> employees = SqlEmployee.getAll();

            label11.Text = customers.Count.ToString();
            label12.Text = suppliers.Count.ToString();
            label13.Text = employees.Count.ToString();
        }

        public void refreshBiggestOrderValue()
        {
            label1.Text = "Rs 0";
            List<Order> orders = SqlOrder.getAll();
            if (orders.Count > 0)
            {
                decimal value = 0;
                Order? biggestOrder = null;
                foreach (Order order in orders)
                {
                    if (order.type == DataModels.Type.Out && order.total > value)
                    {
                        biggestOrder = order;
                        value = order.total;
                    }
                }
                if (biggestOrder != null)
                {
                    label1.Text = $"Rs {biggestOrder.total}";
                }
            }
        }

        public void refreshInventoryOnAlarmQuantity()
        {
            List<Item> items = SqlItem.getAll();
            List<Item> alarmList = new List<Item>();

            foreach (Item it in items)
            {
               if(it.quantity <= it.alarm_quantity)
                {
                    alarmList.Add(it);
                }
            }
            dataGridView1.DataSource = alarmList;
        }

        public void refreshDate()
        {
            DateTime today = DateTime.Today;
            label5.Text = today.ToString("d");
        }
    }
}
