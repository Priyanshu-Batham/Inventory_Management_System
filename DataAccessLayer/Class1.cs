using DataModels;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DataAccessLayer
{

    //Parent class for holding the connection object
    public class SqlHelper
    {
        //private as there's no need to access it from anywhere
        private static string _connString = "Data Source=PRIYANSHU\\SQLEXPRESS;Initial Catalog=Inventory_Management_System;Integrated Security=True;TrustServerCertificate=True";

        //protected coz i'll use conn in the child classes
        protected static SqlConnection conn = new SqlConnection(_connString);
    }


    //Captcha---------------------->>>>
    public class SqlCaptcha : SqlHelper {
        public static int fetchNoOfCaptchas()
        {
            try
            {
                string query = "select COUNT(*) from captcha;";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                cmd.Dispose();
                return count;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }

        }

        public static Captcha fetchRandomCaptcha(int noOfCaptchas)
        {
            try
            {
                Random random = new Random();
                int id = random.Next(noOfCaptchas) + 1; //+1 coz I don't want zero index;

                string query = $"select * from captcha where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                string text = reader["text"].ToString()!;
                string path = reader["path"].ToString()!;

                Captcha captcha = new Captcha(id.ToString(), text, path);
                conn.Close();
                cmd.Dispose();

                return captcha;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }



    //ShippingAddress----------------->>>>
    public class SqlShippingAddress : SqlHelper
    {
        //returns all shipping addresses of a customer
        public static List<ShippingAddress> getMany(string customer_id)
        {
            try
            {
                List<ShippingAddress> list = new List<ShippingAddress>();
                string query = $"select * from shippingAddress where customer_id = {customer_id}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShippingAddress shippingAddress = new ShippingAddress(reader["customer_id"].ToString()!, reader["city"].ToString()!, reader["state"].ToString()!, reader["country"].ToString()!, reader["more"].ToString()!);
                    shippingAddress.id = reader["id"].ToString();
                    list.Add(shippingAddress);
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();

                return list;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getById
        public static ShippingAddress getById(string id)
        {
            try
            {
                string query = $"select * from shippingAddress where id = {id}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                ShippingAddress shippingAddress = new ShippingAddress(reader["customer_id"].ToString()!, reader["city"].ToString()!, reader["state"].ToString()!, reader["country"].ToString()!, reader["more"].ToString()!);
                shippingAddress.id = reader["id"].ToString();

                reader.Close();
                cmd.Dispose();
                conn.Close();

                return shippingAddress;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //adds a new shippingAddress of a customer and returns shippingAddress object with the id
        public static ShippingAddress add(ShippingAddress shippingAddress)
        {
            try
            {
                string query = $"insert into shippingAddress (customer_id, city, state, country, more) values (@customer_id, @city, @state, @country, @more); select SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(query, conn);

                //if the members of object are null then equivalent Db null is added in Sql
                cmd.Parameters.AddWithValue("@customer_id", shippingAddress.customer_id);
                cmd.Parameters.AddWithValue("@city", shippingAddress.city);
                cmd.Parameters.AddWithValue("@state", shippingAddress.state);
                cmd.Parameters.AddWithValue("@country", shippingAddress.country);
                cmd.Parameters.AddWithValue("@more", shippingAddress.more ?? (object)DBNull.Value);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;

                shippingAddress.id = id;

                cmd.Dispose();
                conn.Close();

                return shippingAddress;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);

            }
        }

        //delete
        public static void delete(string id)
        {
            try
            {
                string query = $"delete from shippingAddress where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //update
        public static void update(ShippingAddress shippingAddress)
        {
            try
            {
                string query = $"update shippingAddress set city = @city, state = @state, country = @country, more = @more where id = @id;";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Adding parameters with null checks
                cmd.Parameters.AddWithValue("@city", shippingAddress.city);
                cmd.Parameters.AddWithValue("@state", shippingAddress.state);
                cmd.Parameters.AddWithValue("@country", shippingAddress.country);
                cmd.Parameters.AddWithValue("@more", shippingAddress.more ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", shippingAddress.id);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getAll
        public static List<ShippingAddress> getAll()
        {
            try
            {
                List<ShippingAddress> list = new List<ShippingAddress>();
                string query = $"select * from shippingAddress;";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ShippingAddress shippingAddress = new ShippingAddress(reader["customer_id"].ToString()!, reader["city"].ToString()!, reader["state"].ToString()!, reader["country"].ToString()!, reader["more"].ToString()!);
                    shippingAddress.id = reader["id"].ToString();
                    list.Add(shippingAddress);
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();

                return list;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //makeSelf
        public static void makeSelf()
        {
            try
            {
                string query = $"insert into shippingAddress (customer_id, city, state, country, more) values (@customer_id, @city, @state, @country, @more); select SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(query, conn);

                //if the members of object are null then equivalent Db null is added in Sql
                cmd.Parameters.AddWithValue("@customer_id", SqlCustomer.getSelfId());
                cmd.Parameters.AddWithValue("@city", "self");
                cmd.Parameters.AddWithValue("@state", "self");
                cmd.Parameters.AddWithValue("@country", "self");
                cmd.Parameters.AddWithValue("@more", "self" ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        public static string getSelfId()
        {
            try
            {
                string query = $"select id from shippingAddress where customer_id = @customer_id;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@customer_id", SqlCustomer.getSelfId());

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string id = reader["id"].ToString()!;

                cmd.Dispose();
                conn.Close();
                return id;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }


    //LoginSession----------------->>>>
    public class SqlLoginSession: SqlHelper
    {
        //returns all Login Sessions of an employee
        public static List<LoginSession> getMany(Employee employee)
        {
            try
            {
                List<LoginSession> list = new List<LoginSession>();
                string query = $"select * from loginSession where employee_id = {employee.id}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LoginSession loginSession = new LoginSession(employee.id!);
                    loginSession.id = reader["id"].ToString();
                    loginSession.loggedInAt = reader["loggedInAt"].ToString();
                    list.Add(loginSession);
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();

                return list;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //creates a loginSession for an employee and returns loginSession object with id and loggedInAt values
        public static LoginSession add(Employee employee)
        {
            try
            {
                LoginSession loginSession = new LoginSession(employee.id!);
                string query = $"insert into loginSession (employee_id) values (@employee_id); select SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(query, conn);

                //if the members of object are null then equivalent Db null is added in Sql
                cmd.Parameters.AddWithValue("@employee_id", employee.id);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                loginSession.id = id;
                cmd.Dispose();

                //this additional part is for getting the loggedInAt value generated automatically in sql
                query = $"select loggedInAt from loginSession where id = {loginSession.id}";
                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                loginSession.loggedInAt = reader["loggedInAt"].ToString()!;

                reader.Close();
                cmd.Dispose();
                conn.Close();

                return loginSession;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }


    //Employee----------------->>>>
    public class SqlEmployee: SqlHelper
    {
        //adds a new Employee and returns Employee object with the id
        public static Employee add(Employee employee)
        {
            try
            {
                string query = $"insert into employee (salary, role, passwordHash) values (@salary, @role, @passwordHash); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@role", employee.role.ToString());
                cmd.Parameters.AddWithValue("@passwordHash", employee.passwordHash);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                employee.id = id;
                cmd.Dispose();
                conn.Close();

                return employee;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getAll
        public static List<Employee> getAll()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                string query = $"select * from employee;";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee(Convert.ToDecimal(reader["salary"].ToString()), (Role)Enum.Parse(typeof(Role), reader["role"].ToString()!), reader["passwordHash"].ToString()!);
                    employee.id = reader["id"].ToString()!;
                    employees.Add(employee);
                }
                cmd.Dispose();
                conn.Close();

                return employees;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getById
        public static Employee getById(string id)
        {
            try
            {
                string query = $"select * from employee where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Employee employee = new Employee(Convert.ToDecimal(reader["salary"].ToString()), (Role)Enum.Parse(typeof(Role), reader["role"].ToString()!), reader["passwordHash"].ToString()!);
                employee.id = reader["id"].ToString()!;

                cmd.Dispose();
                conn.Close();

                return employee;
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //delete
        public static void delete(string id)
        {
            try
            {
                string query = $"delete from employee where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //update
        public static void update(Employee employee)
        {
            try
            {
                string query = $"update employee set salary = @salary, role = @role, passwordHash = @passwordHash where id = @id;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", employee.id);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@role", employee.role.ToString());
                cmd.Parameters.AddWithValue("@passwordHash", employee.passwordHash);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }
    
    
    //Supplier----------------->>>>
    public class SqlSupplier: SqlHelper
    {
        //adds a new Supplier and returns Supplier object with the id
        public static Supplier add(Supplier supplier)
        {
            try
            {
                string query = $"insert into supplier (email, supplier_type) values (@email, @supplier_type); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", supplier.email);
                cmd.Parameters.AddWithValue("@supplier_type", supplier.supplier_type.ToString());

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                supplier.id = id;
                cmd.Dispose();
                conn.Close();

                return supplier;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        public static List<Supplier> getAll()
        {
            try
            {
                List<Supplier> list = new List<Supplier>();
                string query = $"select * from supplier;";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Supplier supplier = new Supplier(reader["email"].ToString()!, (Supplier_Type)Enum.Parse(typeof(Supplier_Type), reader["supplier_type"].ToString()!));
                    supplier.id = reader["id"].ToString()!;
                    list.Add(supplier);
                }

                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getById
        public static Supplier getById(string id)
        {
            try
            {
                string query = $"select * from supplier where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Supplier supplier = new Supplier(reader["email"].ToString()!, (Supplier_Type)Enum.Parse(typeof(Supplier_Type), reader["supplier_type"].ToString()!));
                supplier.id = reader["id"].ToString()!;

                cmd.Dispose();
                conn.Close();

                return supplier;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //delete
        public static void delete(string id)
        {
            try
            {
                string query = $"delete from supplier where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //update
        public static void update(Supplier supplier)
        {
            try
            {
                string query = $"update supplier set email = @email, supplier_type = @supplier_type where id = @id;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", supplier.id);
                cmd.Parameters.AddWithValue("@email", supplier.email);
                cmd.Parameters.AddWithValue("@customer_type", supplier.supplier_type.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }
    
    
    //Customer----------------->>>>
    public class SqlCustomer : SqlHelper
    {
        //adds a new Customer and returns Customer object with the id
        public static Customer add(Customer customer)
        {
            try
            {
                string query = $"insert into customer (email, customer_type) values (@email, @customer_type); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", customer.email);
                cmd.Parameters.AddWithValue("@customer_type", customer.customer_type.ToString());

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                customer.id = id;
                cmd.Dispose();
                conn.Close();

                return customer;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getAll
        public static List<Customer> getAll()
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                string query = $"select * from customer;";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer(reader["email"].ToString()!, (Customer_Type)Enum.Parse(typeof(Customer_Type), reader["customer_type"].ToString()!));
                    customer.id = reader["id"].ToString()!;
                    customers.Add(customer);
                }
                cmd.Dispose();
                conn.Close();

                return customers;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getById
        public static Customer getById(string id)
        {
            try
            {
                string query = $"select * from customer where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Customer customer = new Customer(reader["email"].ToString()!, (Customer_Type)Enum.Parse(typeof(Customer_Type), reader["customer_type"].ToString()!));
                customer.id = reader["id"].ToString()!;

                cmd.Dispose();
                conn.Close();

                return customer;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //delete
        public static void delete(string id)
        {
            try
            {
                string query = $"delete from customer where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //update
        public static void update(Customer customer)
        {
            try
            {
                string query = $"update customer set email = @email, customer_type = @customer_type where id = @id;";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customer.id);
                cmd.Parameters.AddWithValue("@email", customer.email);
                cmd.Parameters.AddWithValue("@customer_type", customer.customer_type.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }


        // make self customer
        public static void makeself()
        {
            try
            {
                string query = $"insert into customer (email, customer_type) values (@email, @customer_type);";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", "self@gmail.com");
                cmd.Parameters.AddWithValue("@customer_type", Customer_Type.Rich.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        public static string getSelfId()
        {
            try
            {
                string query = $"select id from customer where email = 'self@gmail.com';";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string id = reader["id"].ToString()!;
                cmd.Dispose();
                conn.Close();

                return id;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }


    //Brand----------------->>>>
    public class SqlBrand: SqlHelper
    {
        //adds a new Brand and returns Brand object with the id
        public static Brand add(Brand brand)
        {
            try
            {
                string query = $"insert into brand (title, summary, popularity) values (@title, @summary, @popularity); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", brand.title);
                cmd.Parameters.AddWithValue("@summary", brand.summary ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@popularity", brand.popularity.ToString());

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                brand.id = id;
                cmd.Dispose();
                conn.Close();

                return brand;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        public static List<Brand> getAll()
        {
            try
            {
                List<Brand> list = new List<Brand>();
                string query = $"select * from brand;";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Brand brand = new Brand(reader["title"].ToString()!, (Popularity)Enum.Parse(typeof(Popularity), reader["popularity"].ToString()!), reader["summary"].ToString());
                    brand.id = reader["id"].ToString()!;
                    list.Add(brand);
                }

                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }


    //User----------------->>>>
    public class SqlUser : SqlHelper
    {
        //adds a new User and returns User object with the id
        //1)remember to pass the appropriate employee OR customer OR supplier id. One of these is mandatory !!!!
        //2) firstly an employee, customer OR supplier will be added then using its id this user will be created
        public static User add(User user)
        {
            //user is reserved word in sqlserver so we have to write it in [user] like this
            string query = $"insert into [user] (user_type, firstName, lastName, username, mobile, email, address, supplier_id, customer_id, employee_id) values (@user_type, @firstName, @lastName, @username, @mobile, @email, @address, @supplier_id, @customer_id, @employee_id); select SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user_type", user.user_type.ToString());
            cmd.Parameters.AddWithValue("@firstName", user.firstName);
            cmd.Parameters.AddWithValue("@lastName", user.lastName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@mobile", user.mobile);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@address", user.address);
            cmd.Parameters.AddWithValue("@supplier_id", user.supplier_id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@customer_id", user.customer_id ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@employee_id", user.employee_id ?? (object)DBNull.Value);

            try
            {
                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                user.id = id;
                cmd.Dispose();

                //this extra work to refetch the record we added and pull the registeredAt field
                query = $"select registeredAt from [user] where id = {id}";
                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                user.registeredAt = reader["registeredAt"].ToString()!;
                reader.Close();

                conn.Close();

                return user;
            }
            catch (Exception ex)
            {
                //also now delete the supplier/customer/employee created before this fun was called
                conn.Close();
                if(user.customer_id != null)
                {
                    SqlCustomer.delete(user.customer_id);
                }
                else if(user.supplier_id != null)
                {
                    SqlSupplier.delete(user.supplier_id); 
                }
                else if (user.employee_id!= null)
                {
                    SqlSupplier.delete(user.employee_id);
                }
                throw new Exception(ex.Message);
            }
        }

        //get user by employee id
        public static User getByEmployeeId(string id)
        {
            try
            {
                string query = $"select * from [user] where employee_id = {id};";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                User user = new User(User_Type.Employee, reader["firstName"].ToString()!, reader["username"].ToString()!, reader["mobile"].ToString()!, reader["email"].ToString()!, reader["address"].ToString()!, employee_id: id, lastName: reader["lastName"].ToString()!, registeredAt: reader["registeredAt"].ToString()!);
                user.id = reader["id"].ToString()!;

                conn.Close();
                return user;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //get user by customer id
        public static User getByCustomerId(string id)
        {
            try
            {
                string query = $"select * from [user] where customer_id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                User user = new User(User_Type.Customer, reader["firstName"].ToString()!, reader["username"].ToString()!, reader["mobile"].ToString()!, reader["email"].ToString()!, reader["address"].ToString()!, employee_id: id, lastName: reader["lastName"].ToString()!, registeredAt: reader["registeredAt"].ToString()!);
                user.id = reader["id"].ToString()!;

                conn.Close();
                return user;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }


        //get user by supplier id
        public static User getBySupplierId(string id)
        {
            try
            {
                string query = $"select * from [user] where supplier_id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                User user = new User(User_Type.Supplier, reader["firstName"].ToString()!, reader["username"].ToString()!, reader["mobile"].ToString()!, reader["email"].ToString()!, reader["address"].ToString()!, employee_id: id, lastName: reader["lastName"].ToString()!, registeredAt: reader["registeredAt"].ToString()!);
                user.id = reader["id"].ToString()!;

                conn.Close();
                return user;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //get user by id
        public static User getById(string id)
        {
            try
            {
                string query = $"select * from [user] where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                User user = new User(User_Type.Supplier, reader["firstName"].ToString()!, reader["username"].ToString()!, reader["mobile"].ToString()!, reader["email"].ToString()!, reader["address"].ToString()!, customer_id: reader["customer_id"].ToString(), lastName: reader["lastName"].ToString()!, registeredAt: reader["registeredAt"].ToString()!);
                user.id = reader["id"].ToString()!;

                conn.Close();
                return user;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //updateByCustomerId
        public static void updateByCustomerId(User user)
        {
            try
            {
                // user is a reserved keyword in SQL Server, so using [user] to avoid syntax issues
                string query = $"update [user] set user_type = @user_type, firstName = @firstName, lastName = @lastName, username = @username, mobile = @mobile, email = @email, address = @address where customer_id = @customer_id;";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@user_type", user.user_type.ToString());
                cmd.Parameters.AddWithValue("@firstName", user.firstName);
                cmd.Parameters.AddWithValue("@lastName", user.lastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@mobile", user.mobile);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@customer_id", user.customer_id);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //updateByEmployeeId
        public static void updateByEmployeeId(User user)
        {
            try
            {
                // user is a reserved keyword in SQL Server, so using [user] to avoid syntax issues
                string query = $"update [user] set user_type = @user_type, firstName = @firstName, lastName = @lastName, username = @username, mobile = @mobile, email = @email, address = @address where employee_id = @employee_id;";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@user_type", user.user_type.ToString());
                cmd.Parameters.AddWithValue("@firstName", user.firstName);
                cmd.Parameters.AddWithValue("@lastName", user.lastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@mobile", user.mobile);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@employee_id", user.employee_id);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }


        //updateBySupplierId
        public static void updateBySupplierId(User user)
        {
            try
            {
                // user is a reserved keyword in SQL Server, so using [user] to avoid syntax issues
                string query = $"update [user] set user_type = @user_type, firstName = @firstName, lastName = @lastName, username = @username, mobile = @mobile, email = @email, address = @address where supplier_id = @supplier_id;";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@user_type", user.user_type.ToString());
                cmd.Parameters.AddWithValue("@firstName", user.firstName);
                cmd.Parameters.AddWithValue("@lastName", user.lastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@mobile", user.mobile);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@address", user.address);
                cmd.Parameters.AddWithValue("@supplier_id ", user.supplier_id);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }

    //Order----------------->>>>
    public class SqlOrder : SqlHelper
    {
        //adds a new Order and returns Order object with the id
        //1) A user (customer (selling to)/supplier (buying from)) AND an employee (who is processing the order) AND type(in/out) are needed for Order
        public static Order add(Order order)
        {
            try
            {
                //user is reserved word in sqlserver so we have to write it in [user] like this
                string query = $"insert into [order] (user_id, employee_id, type, subTotal, tax, total) values (@user_id, @employee_id, @type, @subTotal, @tax, @total); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user_id", order.user_id);
                cmd.Parameters.AddWithValue("@employee_id", order.employee_id);
                cmd.Parameters.AddWithValue("@type", order.type.ToString());
                cmd.Parameters.AddWithValue("@subTotal", order.subTotal);
                cmd.Parameters.AddWithValue("@tax", order.tax);
                cmd.Parameters.AddWithValue("@total", order.total);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                order.id = id;
                cmd.Dispose();
                conn.Close();

                return order;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getAll
        public static List<Order> getAll()
        {
            try
            {
                List<Order> list = new List<Order>();
                string query = $"select * from [order];";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new Order(reader["user_id"].ToString()!, reader["employee_id"].ToString()!, (DataModels.Type)Enum.Parse(typeof(DataModels.Type), reader["type"].ToString()!), Convert.ToDecimal(reader["subTotal"].ToString()), Convert.ToDecimal(reader["tax"].ToString()), Convert.ToDecimal(reader["total"].ToString()));
                    order.id = reader["id"].ToString()!;
                    list.Add(order);
                }

                cmd.Dispose();
                conn.Close();

                return list;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }
    
    
    //Payment----------------->>>>
    public class SqlPayment : SqlHelper
    {
        //adds a new Payment and returns Payment object with the id and createdAt
        //1) A Order, User and ShippingAddress is needed for Payment object
        public static Payment add(Payment payment)
        {
            try
            {
                string query = $"insert into payment (user_id, order_id, shippintAddress_id, mode, status, type) values (@user_id, @order_id, @shippintAddress_id, @mode, @status, @type); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user_id", payment.user_id);
                cmd.Parameters.AddWithValue("@order_id", payment.order_id);
                cmd.Parameters.AddWithValue("@shippintAddress_id", payment.shippingAddress_id);
                cmd.Parameters.AddWithValue("@mode", payment.mode.ToString());
                cmd.Parameters.AddWithValue("@status", payment.status.ToString());
                cmd.Parameters.AddWithValue("@type", payment.type.ToString());

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                payment.id = id;

                //this extra work to refetch the record we added and pull the createdAt field
                query = $"select createdAt from payment where id = {id}";
                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                payment.createdAt = reader["createdAt"].ToString()!;

                reader.Close();
                conn.Close();

                return payment;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }


        //Update
        public static Payment update(Payment payment)
        {
            try
            {
                string query = "update payment set user_id = @user_id, order_id = @order_id, shippingAddress_id = @shippingAddress_id, mode = @mode, status = @status, type = @type where id = @id;";
                SqlCommand cmd = new SqlCommand(query, conn);

                // Set up parameters for the SQL command
                cmd.Parameters.AddWithValue("@user_id", payment.user_id);
                cmd.Parameters.AddWithValue("@order_id", payment.order_id);
                cmd.Parameters.AddWithValue("@shippingAddress_id", payment.shippingAddress_id);
                cmd.Parameters.AddWithValue("@mode", payment.mode);
                cmd.Parameters.AddWithValue("@status", payment.status);
                cmd.Parameters.AddWithValue("@type", payment.type);
                cmd.Parameters.AddWithValue("@id", payment.id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                // Re-fetch the updated record's createdAt field, in case it was modified or for consistency
                query = "select createdAt from payment where id = @id";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", payment.id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    payment.createdAt = reader["createdAt"].ToString()!;
                }

                reader.Close();
                conn.Close();

                return payment;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        public static Payment getByOrderId(string order_id)
        {
            try
            {
                string query = $"select * from payment where order_id = {order_id};";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Payment payment = new Payment(reader["user_id"].ToString()!, reader["order_id"].ToString()!, reader["shippintAddress_id"].ToString()!, (Mode)Enum.Parse(typeof(Mode), reader["mode"].ToString()!), (Status)Enum.Parse(typeof(Status), reader["status"].ToString()!), (DataModels.Type)Enum.Parse(typeof(DataModels.Type), reader["type"].ToString()!), createdAt: reader["createdAt"].ToString());
                payment.id = reader["id"].ToString()!;

                reader.Close();
                conn.Close();

                return payment;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }


    //Product----------------->>>>
    public class SqlProduct : SqlHelper
    {
        //adds a new Product and returns Product object with the id and createdAt
        public static Product add(Product product)
        {
            try
            {
                string query = $"insert into product (title, description) values (@title, @description); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", product.title);
                cmd.Parameters.AddWithValue("@description", product.description ?? (object)DBNull.Value);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                product.id = id;

                //this extra work to refetch the record we added and pull the createdAt field
                query = $"select createdAt from product where id = {id}";
                cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                product.createdAt = reader["createdAt"].ToString()!;

                reader.Close();
                conn.Close();

                return product;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getAll
        public static List<Product> getAll()
        {
            try
            {
                List<Product> list = new List<Product>();
                string query = $"select * from product;";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product(reader["title"].ToString()!, reader["description"].ToString()!);
                    product.createdAt = reader["createdAt"].ToString();
                    product.id = reader["id"].ToString()!;
                    list.Add(product);
                }

                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getById
        public static Product getById(string id)
        {
            try
            {
                string query = $"select * from product where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Product product = new Product(reader["title"].ToString()!, reader["description"].ToString()!);
                product.createdAt = reader["createdAt"].ToString();
                product.id = reader["id"].ToString()!;

                conn.Close();
                return product;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //delete
        public static void delete(string id)
        {
            try
            {
                string query = $"delete from product where id = {id}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //update
        public static void update(Product product)
        {
            try
            {
                string query = $"update product set title = @title, description = @description where id = @id;";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", product.title);
                cmd.Parameters.AddWithValue("@description", product.description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", product.id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message); 
            }

        }
    }


    //Order_Item----------------->>>>
    public class SqlOrder_Item : SqlHelper
    {
        //adds a new Order_Item and returns Order_Item object with the id
        //product, Item and order are needed for this
        public static Order_Item add(Order_Item order_Item)
        {
            try
            {
                string query = $"insert into order_item (product_id, item_id, order_id, price, quantitiy, total_price) values (@product_id, @item_id, @order_id, @price, @quantitiy, @total_price); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@product_id", order_Item.product_id);
                cmd.Parameters.AddWithValue("@item_id", order_Item.item_id);
                cmd.Parameters.AddWithValue("@order_id", order_Item.order_id);
                cmd.Parameters.AddWithValue("@price", order_Item.price);
                cmd.Parameters.AddWithValue("@quantitiy", order_Item.quantity);
                cmd.Parameters.AddWithValue("@total_price", order_Item.total_price);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                order_Item.id = id;
                conn.Close();

                return order_Item;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message); 
            }
        }
    }


    //Product_Category----------------->>>>
    public class SqlProduct_Category : SqlHelper
    {
        //adds a new Product_Category and returns Product_Category object with the id
        //category and product are needed for this
        public static Product_Category add(Product_Category product_Category)
        {
            try
            {
                string query = $"insert into product_category (category_id, product_id) values (@category_id, @product_id); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@category_id", product_Category.category_id);
                cmd.Parameters.AddWithValue("@product_id", product_Category.product_id);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                product_Category.id = id;
                conn.Close();

                return product_Category;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }


    //Category----------------->>>>
    public class SqlCategory : SqlHelper
    {
        //adds a new Category and returns Category object with the id
        public static Category add(Category category)
        {
            try
            {
                string query = $"insert into category (title, description) values (@title, @description); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", category.title);
                cmd.Parameters.AddWithValue("@description", category.description);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                category.id = id;
                conn.Close();

                return category;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }


    //Item----------------->>>>
    public class SqlItem : SqlHelper
    {
        //adds a new Item and returns Item object with the id
        public static Item add(Item item)
        {
            try
            {
                string query = $"insert into item (product_id, brand_id, supplier_id, price, discount, quantity, stockValue, alarm_quantity) values (@product_id, @brand_id, @supplier_id, @price, @discount, @quantity, @stockValue, @alarm_quantity); select SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@product_id", item.product_id);
                cmd.Parameters.AddWithValue("@brand_id", item.brand_id);
                cmd.Parameters.AddWithValue("@supplier_id", item.supplier_id);
                cmd.Parameters.AddWithValue("@price", item.price);
                cmd.Parameters.AddWithValue("@discount", item.discount);
                cmd.Parameters.AddWithValue("@quantity", item.quantity);
                cmd.Parameters.AddWithValue("@stockValue", item.stockValue);
                cmd.Parameters.AddWithValue("@alarm_quantity", item.alarm_quantity);

                conn.Open();
                string id = cmd.ExecuteScalar().ToString()!;
                item.id = id;
                conn.Close();

                return item;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //getAll
        public static List<Item> getAll()
        {
            try
            {
                List<Item> list = new List<Item>();
                string query = $"select * from item;";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item(reader["product_id"].ToString()!, reader["brand_id"].ToString()!, reader["supplier_id"].ToString()!, Convert.ToDecimal(reader["price"].ToString()), Convert.ToInt32(reader["discount"].ToString()), Convert.ToInt32(reader["quantity"].ToString()), Convert.ToDecimal(reader["stockValue"].ToString()), Convert.ToInt64(reader["alarm_quantity"].ToString()));
                    item.id = reader["id"].ToString()!;
                    list.Add(item);
                }

                conn.Close();
                return list;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        public static Item getById(string id)
        {
            try
            {
                string query = $"select * from item where id = {id};";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                Item item = new Item(reader["product_id"].ToString()!, reader["brand_id"].ToString()!, reader["supplier_id"].ToString()!, Convert.ToDecimal(reader["price"].ToString()), Convert.ToInt32(reader["discount"].ToString()), Convert.ToInt32(reader["quantity"].ToString()), Convert.ToDecimal(reader["stockValue"].ToString()), Convert.ToInt64(reader["alarm_quantity"].ToString()));
                item.id = reader["id"].ToString()!;

                conn.Close();
                return item;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //delete
        public static void delete(string id)
        {
            try
            {
                string query = $"delete from item where id = {id}";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }

        //update
        public static void update(Item item)
        {
            try
            {
                string query = @"update item 
                     set product_id = @product_id, 
                         brand_id = @brand_id, 
                         supplier_id = @supplier_id, 
                         price = @price, 
                         discount = @discount, 
                         quantity = @quantity, 
                         stockValue = @stockValue, 
                         alarm_quantity = @alarm_quantity 
                     where id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@product_id", item.product_id);
                cmd.Parameters.AddWithValue("@brand_id", item.brand_id);
                cmd.Parameters.AddWithValue("@supplier_id", item.supplier_id);
                cmd.Parameters.AddWithValue("@price", item.price);
                cmd.Parameters.AddWithValue("@discount", item.discount);
                cmd.Parameters.AddWithValue("@quantity", item.quantity);
                cmd.Parameters.AddWithValue("@stockValue", item.stockValue);
                cmd.Parameters.AddWithValue("@alarm_quantity", item.alarm_quantity);
                cmd.Parameters.AddWithValue("@id", item.id);  // Make sure item.id has the correct ID for the update

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
        }
    }
}
