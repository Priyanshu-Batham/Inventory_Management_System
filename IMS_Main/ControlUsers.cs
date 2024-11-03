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
    public partial class ControlUsers : UserControl
    {
        List<Employee> employees;
        List<Supplier> suppliers;
        List<Customer> customers;
        string currentUserType = "";
        public ControlUsers()
        {
            InitializeComponent();
            employees = SqlEmployee.getAll();
            suppliers = SqlSupplier.getAll();
            customers = SqlCustomer.getAll();
        }

        private void clearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            maskedTextBox1.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void refreshEmployeeData()
        {
            // Set up columns for selective properties if not already done
            dataGridView1.Columns.Clear(); // Clear existing columns if needed

            // Add columns for selective properties
            dataGridView1.Columns.Add("employee_id", "employee_id");
            dataGridView1.Columns.Add("firstName", "firstNameName");
            dataGridView1.Columns.Add("lastName", "lastName");
            dataGridView1.Columns.Add("username", "username");
            dataGridView1.Columns.Add("mobile", "mobile");
            dataGridView1.Columns.Add("email", "email");
            dataGridView1.Columns.Add("address", "address");
            dataGridView1.Columns.Add("registeredAt", "registeredAt");
            dataGridView1.Columns.Add("salary", "salary");
            dataGridView1.Columns.Add("role", "role");

            employees = SqlEmployee.getAll();
            foreach (Employee employee in employees)
            {
                User user = SqlUser.getByEmployeeId(employee.id!);
                dataGridView1.Rows.Add(employee.id, user.firstName, user.lastName, user.username, user.mobile, user.email, user.address, user.registeredAt, employee.salary, employee.role.ToString());
            }
        }

        //Employee button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginForm.loggedInAs != "admin")
                {
                    throw new Exception("Only for Admin");
                }

                clearFields();
                //showing extra fields of employee
                label10.Visible = true;
                label12.Visible = true;
                textBox10.Visible = true;
                textBox4.Visible = true;
                button7.Visible = false; //shipping address for only customer

                //filling type combobox with Customer types
                comboBox3.DataSource = Enum.GetValues(typeof(Role));

                currentUserType = "employee";
                refreshEmployeeData();
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        private void refreshSupplierData()
        {
            // Set up columns for selective properties if not already done
            dataGridView1.Columns.Clear(); // Clear existing columns if needed

            dataGridView1.Columns.Add("supplier_id", "supplier_id");
            dataGridView1.Columns.Add("firstName", "firstNameName");
            dataGridView1.Columns.Add("lastName", "lastName");
            dataGridView1.Columns.Add("username", "username");
            dataGridView1.Columns.Add("mobile", "mobile");
            dataGridView1.Columns.Add("email", "email");
            dataGridView1.Columns.Add("address", "address");
            dataGridView1.Columns.Add("registeredAt", "registeredAt");
            dataGridView1.Columns.Add("supplier_type", "supplier_type");

            suppliers = SqlSupplier.getAll();

            foreach (Supplier supplier in suppliers)
            {
                User user = SqlUser.getBySupplierId(supplier.id!);
                dataGridView1.Rows.Add(supplier.id, user.firstName, user.lastName, user.username, user.mobile, user.email, user.address, user.registeredAt, supplier.supplier_type.ToString());
            }
        }

        //Supplier button
        private void button2_Click(object sender, EventArgs e)
        {
            clearFields();
            //hiding extra fields of employee
            label10.Visible = false;
            label12.Visible = false;
            textBox10.Visible = false;
            textBox4.Visible = false;
            button7.Visible = false; //shipping address for only customer

            //filling type combobox with Customer types
            comboBox3.DataSource = Enum.GetValues(typeof(Supplier_Type));

            currentUserType = "supplier";
            refreshSupplierData();
        }

        private void refreshCustomerData()
        {
            // Set up columns for selective properties if not already done
            dataGridView1.Columns.Clear(); // Clear existing columns if needed

            dataGridView1.Columns.Add("customer_id", "customer_id");
            dataGridView1.Columns.Add("firstName", "firstNameName");
            dataGridView1.Columns.Add("lastName", "lastName");
            dataGridView1.Columns.Add("username", "username");
            dataGridView1.Columns.Add("mobile", "mobile");
            dataGridView1.Columns.Add("email", "email");
            dataGridView1.Columns.Add("address", "address");
            dataGridView1.Columns.Add("registeredAt", "registeredAt");
            dataGridView1.Columns.Add("customer_type", "customer_type");


            customers = SqlCustomer.getAll();
            foreach (Customer customer in customers)
            {
                User user = SqlUser.getByCustomerId(customer.id!);
                dataGridView1.Rows.Add(customer.id, user.firstName, user.lastName, user.username, user.mobile, user.email, user.address, user.registeredAt, customer.customer_type.ToString());
            }
        }

        //Customer button
        private void button1_Click(object sender, EventArgs e)
        {
            clearFields();
            //hiding extra fields of employee
            label10.Visible = false;
            label12.Visible = false;
            textBox10.Visible = false;
            textBox4.Visible = false;
            button7.Visible = true; //shipping address for only customer

            //filling type combobox with Customer types
            comboBox3.DataSource = Enum.GetValues(typeof(Customer_Type));


            currentUserType = "customer";
            refreshCustomerData();
        }

        //row is clicked
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if user is customer
                if (currentUserType == "customer")
                {
                    // Check if the row index is valid (e.g., avoid header row clicks)
                    if (e.RowIndex >= 0)
                    {
                        // Get the clicked row
                        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                        string id = selectedRow.Cells[0].Value.ToString()!; // Value of the first cell
                        Customer customer = SqlCustomer.getById(id);
                        User user = SqlUser.getByCustomerId(id);

                        textBox1.Text = customer.id;
                        textBox8.Text = user.firstName;
                        textBox2.Text = user.lastName;
                        textBox3.Text = user.username;
                        maskedTextBox1.Text = user.mobile;
                        textBox6.Text = user.email;
                        richTextBox1.Text = user.address;
                        textBox9.Text = user.registeredAt;
                        comboBox3.Text = customer.customer_type.ToString();
                    }
                }

                //if user is supplier
                else if (currentUserType == "supplier")
                {
                    // Check if the row index is valid (e.g., avoid header row clicks)
                    if (e.RowIndex >= 0)
                    {
                        // Get the clicked row
                        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                        string id = selectedRow.Cells[0].Value.ToString()!; // Value of the first cell
                        Supplier supplier = SqlSupplier.getById(id);
                        User user = SqlUser.getBySupplierId(id);

                        textBox1.Text = supplier.id;
                        textBox8.Text = user.firstName;
                        textBox2.Text = user.lastName;
                        textBox3.Text = user.username;
                        maskedTextBox1.Text = user.mobile;
                        textBox6.Text = user.email;
                        richTextBox1.Text = user.address;
                        textBox9.Text = user.registeredAt;
                        comboBox3.Text = supplier.supplier_type.ToString();
                    }
                }

                //if user is employee
                else if (currentUserType == "employee")
                {
                    // Check if the row index is valid (e.g., avoid header row clicks)
                    if (e.RowIndex >= 0)
                    {
                        // Get the clicked row
                        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                        string id = selectedRow.Cells[0].Value.ToString()!; // Value of the first cell
                        Employee employee = SqlEmployee.getById(id);
                        User user = SqlUser.getByEmployeeId(id);

                        textBox1.Text = employee.id;
                        textBox8.Text = user.firstName;
                        textBox2.Text = user.lastName;
                        textBox3.Text = user.username;
                        maskedTextBox1.Text = user.mobile;
                        textBox6.Text = user.email;
                        richTextBox1.Text = user.address;
                        textBox9.Text = user.registeredAt;
                        comboBox3.Text = employee.role.ToString();
                        textBox10.Text = employee.salary.ToString();
                        textBox4.Text = employee.passwordHash.ToString();
                    }
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
                if (currentUserType == "customer")
                {
                    if (textBox3.Text == "" || textBox6.Text == "" || maskedTextBox1.Text == "" || textBox8.Text == "" || richTextBox1.Text == "" || comboBox3.Text == "") throw new Exception("Fill all details");
                    Customer customer = new Customer(textBox6.Text, (Customer_Type)Enum.Parse(typeof(Customer_Type), comboBox3.Text));
                    customer = SqlCustomer.add(customer);

                    User user = new User(User_Type.Customer, textBox8.Text, textBox3.Text, maskedTextBox1.Text, textBox6.Text, richTextBox1.Text, customer_id: customer.id, lastName: textBox2.Text);
                    user = SqlUser.add(user);
                    MessageBox.Show($"Customer Added with ID: {customer.id}");
                    refreshCustomerData();
                }

                else if (currentUserType == "supplier")
                {
                    if (textBox3.Text == "" || textBox6.Text == "" || maskedTextBox1.Text == "" || textBox8.Text == "" || richTextBox1.Text == "" || comboBox3.Text == "") throw new Exception("Fill all details");
                    Supplier supplier = new Supplier(textBox6.Text, (Supplier_Type)Enum.Parse(typeof(Supplier_Type), comboBox3.Text));
                    supplier = SqlSupplier.add(supplier);

                    User user = new User(User_Type.Supplier, textBox8.Text, textBox3.Text, maskedTextBox1.Text, textBox6.Text, richTextBox1.Text, supplier_id: supplier.id, lastName: textBox2.Text);
                    user = SqlUser.add(user);
                    MessageBox.Show($"Supplier Added with ID: {supplier.id}");
                    refreshSupplierData();
                }

                else if (currentUserType == "employee")
                {
                    if (textBox3.Text == "" || textBox6.Text == "" || maskedTextBox1.Text == "" || textBox8.Text == "" || richTextBox1.Text == "" || comboBox3.Text == "" || textBox4.Text == "" || textBox10.Text == "") throw new Exception("Fill all details");
                    Employee employee = new Employee(Convert.ToDecimal(textBox10.Text), (Role)Enum.Parse(typeof(Role), comboBox3.Text), textBox4.Text);
                    employee = SqlEmployee.add(employee);

                    User user = new User(User_Type.Supplier, textBox8.Text, textBox3.Text, maskedTextBox1.Text, textBox6.Text, richTextBox1.Text, employee_id: employee.id, lastName: textBox2.Text);
                    user = SqlUser.add(user);
                    MessageBox.Show($"Employee Added with ID: {employee.id}");
                    refreshEmployeeData();
                }
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
                if (currentUserType == "customer")
                {
                    if (textBox1.Text == "") return;
                    SqlCustomer.delete(textBox1.Text);
                    refreshCustomerData();
                }

                else if (currentUserType == "supplier")
                {
                    if (textBox1.Text == "") return;
                    SqlSupplier.delete(textBox1.Text);
                    refreshSupplierData();
                }

                else if (currentUserType == "employee")
                {
                    if (textBox1.Text == "" || textBox4.Text == "" || textBox10.Text == "") throw new Exception("Fill all details");
                    SqlEmployee.delete(textBox1.Text);
                    refreshEmployeeData();
                }
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
                if (currentUserType == "customer")
                {
                    if (textBox1.Text == "") return;
                    Customer customer = new Customer(textBox6.Text, (Customer_Type)Enum.Parse(typeof(Customer_Type), comboBox3.Text));
                    customer.id = textBox1.Text;
                    SqlCustomer.update(customer);

                    User user = new User(User_Type.Customer, textBox8.Text, textBox3.Text, maskedTextBox1.Text, textBox6.Text, richTextBox1.Text, customer_id: textBox1.Text, lastName: textBox2.Text);
                    SqlUser.updateByCustomerId(user);

                    MessageBox.Show("Customer Updated");
                    refreshCustomerData();
                }

                else if (currentUserType == "supplier")
                {
                    if (textBox1.Text == "") return;
                    Supplier Supplier = new Supplier(textBox6.Text, (Supplier_Type)Enum.Parse(typeof(Supplier_Type), comboBox3.Text));
                    Supplier.id = textBox1.Text;
                    SqlSupplier.update(Supplier);

                    User user = new User(User_Type.Supplier, textBox8.Text, textBox3.Text, maskedTextBox1.Text, textBox6.Text, richTextBox1.Text, supplier_id: textBox1.Text, lastName: textBox2.Text);
                    SqlUser.updateBySupplierId(user);

                    MessageBox.Show("Supplier Updated");
                    refreshSupplierData();
                }

                else if (currentUserType == "employee")
                {
                    Employee Employee = new Employee(Convert.ToDecimal(textBox10.Text), (Role)Enum.Parse(typeof(Role), comboBox3.Text), textBox4.Text);
                    Employee.id = textBox1.Text;
                    SqlEmployee.update(Employee);

                    User user = new User(User_Type.Employee, textBox8.Text, textBox3.Text, maskedTextBox1.Text, textBox6.Text, richTextBox1.Text, employee_id: textBox1.Text, lastName: textBox2.Text);
                    SqlUser.updateByEmployeeId(user);

                    MessageBox.Show("Employee Updated");
                    refreshEmployeeData();
                }
            }
            catch (Exception ex)
            {
                label11.Text = ex.Message;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            ShippingAddressesForm shippingAddressesForm = new ShippingAddressesForm(textBox1.Text);
            shippingAddressesForm.ShowDialog();
        }
    }
}
