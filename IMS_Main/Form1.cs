using DataModels;
using DataAccessLayer;

namespace IMS_Main
{
    public partial class Dashboard : Form
    {
        //"admin" means admin else there will be employee id in this variable
        public string loggedInAs;
        public Dashboard(string loggedInAs)
        {
            InitializeComponent();

            this.loggedInAs = loggedInAs;
            //first the dashboard should appear
            controlDashboard1.refreshProfit();
            controlDashboard1.refreshBestCustomer();
            controlDashboard1.refreshUserCount();
            controlDashboard1.refreshBiggestOrderValue();
            controlDashboard1.refreshInventoryOnAlarmQuantity();
            controlDashboard1.refreshDate();
            controlDashboard1.BringToFront();

            button4.Text = "Orders";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = "Dashboard";

            controlDashboard1.refreshProfit();
            controlDashboard1.refreshBestCustomer();
            controlDashboard1.refreshUserCount();
            controlDashboard1.refreshBiggestOrderValue();
            controlDashboard1.refreshInventoryOnAlarmQuantity();
            controlDashboard1.refreshDate();
            controlDashboard1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Inventory";

            controlinventory1.Controlinventory_Load(sender, e);
            controlinventory1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "Products";

            controlProducts1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "Users";

            controlUsers1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "Orders";
            controlTransactions1.ControlTransactions_Load(sender, e);
            controlTransactions1.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //setting the name of logged in Employee or Admin
            if(loggedInAs == "admin")
            {
                label3.Text = "Admin";
            }
            else
            {
                label3.Text = SqlUser.getByEmployeeId(loggedInAs).firstName;
            }

            //default self customer add
            List<Customer> customers = SqlCustomer.getAll();
            bool flag = false;
            foreach (Customer customer in customers)
            {
                if (customer.email == "self@gmail.com")
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                //else create one
                SqlCustomer.makeself();
                User user = SqlUser.add(new User(User_Type.Customer, "self", "self", "9999999999", "self@gmail.com", "self", customer_id: SqlCustomer.getSelfId()));
            }
            flag = false;

            //its shipping address also
            List<ShippingAddress> shippingAddresses = SqlShippingAddress.getAll();
            foreach (ShippingAddress shippingAddresse in shippingAddresses)
            {
                if (shippingAddresse.customer_id == SqlCustomer.getSelfId())
                {
                    flag = true;
                    break;
                }
            }
            if(flag == false)
            {
                SqlShippingAddress.makeSelf();
            }
        }
    }
}
