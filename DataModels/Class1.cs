/*This library contains all the Db-Tables equivalent classes 
 * so that the data returned by SQL queries can be managed easily
 * in the codebase.
 */

namespace DataModels
{
    public class Captcha
    {
        public string id;
        public string Text;
        public string Path;

        public Captcha(string id, string text, string path)
        {
            this.id = id;
            this.Text = text;
            this.Path = path;
        }
    }

    public class ShippingAddress{
        public string? id { get; set; }
        public string customer_id {  get; set; }
        public string city { get; set; }
        public string state {  get; set; }
        public string country { get; set; }
        public string? more { get; set; }

        public ShippingAddress(string customer_id, string city, string state, string country, string more = "") {
            this.customer_id = customer_id;
            this.city = city;
            this.state = state;
            this.country = country;
            this.more = more;
        }

        override
        public string ToString()
        {
            return $"{id}) {city}, {state}, {country}";
        }
    }

    public class LoginSession { 
        public string? id { get; set; }
        public string employee_id { get; set; }
        public string? loggedInAt { get; set; } 
        public LoginSession(string employee_id)
        {
            this.employee_id = employee_id;
        }
    }

    public class Employee
    {
        public string? id { get; set; }
        public decimal salary { get; set; }
        public Role role { get; set; }
        public string passwordHash { get; set; }

        public Employee(decimal salary, Role role, string passwordHash)
        {
            this.salary = salary;
            this.role = role;
            this.passwordHash = passwordHash;
        }

        override
        public string ToString()
        {
            return $"{id}) {role}";
        }
    }

    public class Supplier
    {
        public string? id { get; set; }
        public string email { get; set; }
        public Supplier_Type supplier_type { get; set; }

        public Supplier(string email, Supplier_Type supplier_type)
        {
            this.email = email;
            this.supplier_type = supplier_type;
        }
    }

    public class Customer
    {
        public string? id { get; set; }
        public string? supplier { get; set; }
        public string email { get; set; }
        public Customer_Type customer_type { get; set; }

        public Customer(string email, Customer_Type customer_type)
        {
            this.email = email;
            this.customer_type = customer_type;
        }

        override
        public string ToString()
        {
            return $"{id}) {email}";
        }
    }

    public class Brand
    {
        public string? id { get; set; }
        public string title { get; set; }
        public string? summary { get; set; }
        public Popularity popularity { get; set; }

        public Brand(string title, Popularity popularity, string? summary = null)
        {
            this.title = title;
            this.summary = summary;
            this.popularity = popularity;
        }

        override
        public string ToString()
        {
            return $"{id}) {title}";
        }
    }

    public class Payment
    {
        public string? id { get; set; }
        public string user_id { get; set; }
        public string order_id { get; set; }
        public string shippingAddress_id{ get; set; }
        public Mode mode{ get; set; }
        public Status status { get; set; }
        public string? createdAt { get; set; }
        public Type type { get; set; }

        public Payment(string user_id, string order_id, string shippingAddress_id, Mode mode, Status status, Type type, string? createdAt = "")
        {
            this.user_id = user_id;
            this.order_id = order_id;
            this.shippingAddress_id = shippingAddress_id;
            this.mode = mode;
            this.status = status;
            this.createdAt = createdAt;
            this.type = type;
        }
    }

    public class Order_Item
    {
        public string? id { get; set; }
        public string product_id { get; set; }
        public string item_id { get; set; }
        public string order_id { get; set; }
        public decimal price { get; set; }
        public long quantity { get; set; }
        public decimal total_price { get; set; }

        public Order_Item(string product_id, string item_id, string order_id, decimal price, long quantity, decimal total_price)
        {
            this.product_id = product_id;
            this.item_id = item_id;
            this.order_id = order_id;
            this.price = price;
            this.quantity = quantity;
            this.total_price = total_price;
        }
    }

    public class Item
    {
        public string? id { get; set; }
        public string product_id { get; set; }
        public string brand_id { get; set; }
        public string supplier_id { get; set; }
        public decimal price { get; set; }
        public int discount { get; set; }
        public long quantity { get; set; }
        public decimal stockValue { get; set; }
        public long alarm_quantity{ get; set; }

        public Item(string product_id, string brand_id, string supplier_id, decimal price, int discount, long quantity, decimal stockValue, long alarm_quantity) { 
            this.product_id= product_id;
            this.brand_id= brand_id;
            this.supplier_id= supplier_id;
            this.price = price;
            this.discount = discount;
            this.quantity = quantity;
            this.stockValue = stockValue;
            this.alarm_quantity = alarm_quantity;
        }

        
    }

    public class Order
    {
        public string? id { get; set; }
        public string user_id { get; set; }
        public string employee_id { get; set; }
        public Type type { get; set; }
        public decimal subTotal { get; set; }
        public decimal tax { get; set; }
        public decimal total { get; set; }

        public Order(string user_id, string employee_id, Type type, decimal subTotal, decimal tax, decimal total)
        {
            this.user_id = user_id;
            this.employee_id = employee_id;
            this.type = type;
            this.subTotal = subTotal;
            this.tax = tax;
            this.total = total;
        }
    }

    public class User
    {
        public string? id { get; set; }
        public string? supplier_id { get; set; }
        public string? customer_id { get; set; }
        public string? employee_id { get; set; }
        public User_Type user_type { get; set; }
        public string firstName { get; set; }
        public string? lastName{ get; set; }
        public string username{ get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string? registeredAt { get; set; }

        public User(User_Type user_type, string firstName, string username, string mobile, string email, string address, string? supplier_id = null, string? customer_id = null, string? employee_id = null, string lastName = "", string registeredAt = "")
        {
            this.supplier_id = supplier_id;
            this.customer_id = customer_id;
            this.employee_id = employee_id;
            this.user_type = user_type;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.mobile = mobile;
            this.email = email;
            this.address = address;
            this.registeredAt = registeredAt;
        }
    }

    public class Product_Category
    {
        public string? id { get; set; }
        public string category_id { get; set; }
        public string product_id { get; set; }

        public Product_Category(string category_id, string product_id)
        {
            this.category_id = category_id;
            this.product_id = product_id;
        }
    }
    public class Category
    {
        public string? id { get; set; }
        public string title { get; set; }
        public string? description { get; set; }

        public Category(string title, string? description = null)
        {
            this.title = title;
            this.description = description;
        }
    }
    public class Product
    {
        public string? id { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public string? createdAt { get; set; }

        public Product(string title, string? description = null)
        {
            this.title = title;
            this.description = description;
        }

        override
        public string ToString()
        {
            return $"{id}) {title}";
        }
    }


    //Enumerations for Consistency
    public enum Role
    {
        Manager,
        Sales
    }

    public enum Supplier_Type
    {
        Trusted,
        New
    }

    public enum Customer_Type
    {
        Rich,
        Poor,
        Medium
    }

    public enum Popularity { 
        Low,
        Medium,
        High
    }

    public enum Mode
    {
        Online,
        Cod
    }

    public enum Status
    {
        Pending,
        Finished,
        Failed
    }

    public enum Type 
    { 
        In,
        Out
    }

    public enum User_Type
    {
        Customer,
        Supplier,
        Employee
    }
}
