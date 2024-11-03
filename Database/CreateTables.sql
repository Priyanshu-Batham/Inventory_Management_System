create database Inventory_Management_System;
use Inventory_Management_System;

create table captcha (
	id int primary key identity(1, 1),
	text nvarchar(10),
	path nvarchar(100)
);

insert into captcha(text, path)
values
('TXGAP', 'images\image1.png'),
('MLPSY', 'images\image2.png'),
('NQCLA', 'images\image3.png')

CREATE TABLE "item"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "product_id" BIGINT NOT NULL,
    "brand_id" BIGINT NOT NULL,
    "supplier_id" BIGINT NULL,
    "price" BIGINT NOT NULL,
    "discount" INT NOT NULL,
    "quantity" BIGINT NOT NULL,
    "stockValue" BIGINT NOT NULL,
    "alarm_quantity" BIGINT NOT NULL
);
ALTER TABLE
    "item" ADD CONSTRAINT "item_id_primary" PRIMARY KEY("id");
CREATE TABLE "payment"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "user_id" BIGINT NULL,
    "order_id" BIGINT NOT NULL,
    "shippintAddress_id" BIGINT NULL,
    "mode" NVARCHAR(255) CHECK
        ("mode" IN(N'Online', N'Cod')) NOT NULL,
        "status" NVARCHAR(255)
    CHECK
        (
            "status" IN(N'Pending', N'Finished', N'Failed')
        ) NOT NULL,
        "createdAt" DATETIME NOT NULL DEFAULT GETDATE(),
        "type" NVARCHAR(255)
    CHECK
        ("type" IN(N'In', N'Out')) NOT NULL
);
ALTER TABLE
    "payment" ADD CONSTRAINT "payment_id_primary" PRIMARY KEY("id");
CREATE TABLE "order"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "user_id" BIGINT NULL,
    "employee_id" BIGINT NULL,
    "type" NVARCHAR(255) CHECK
        ("type" IN(N'In', N'Out')) NOT NULL,
        "subTotal" BIGINT NOT NULL,
        "tax" BIGINT NOT NULL,
        "total" BIGINT NOT NULL
);
ALTER TABLE
    "order" ADD CONSTRAINT "order_id_primary" PRIMARY KEY("id");
CREATE TABLE "shippingAddress"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "customer_id" BIGINT NOT NULL,
    "city" NVARCHAR(255) NOT NULL,
    "state" NVARCHAR(255) NOT NULL,
    "country" NVARCHAR(255) NOT NULL,
    "more" NVARCHAR(255) NULL
);
ALTER TABLE
    "shippingAddress" ADD CONSTRAINT "shippingaddress_id_primary" PRIMARY KEY("id");
CREATE TABLE "product"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "title" NVARCHAR(255) NOT NULL,
    "description" NVARCHAR(255) NULL,
    "createdAt" DATETIME NOT NULL DEFAULT GETDATE()
);
ALTER TABLE
    "product" ADD CONSTRAINT "product_id_primary" PRIMARY KEY("id");
CREATE TABLE "customer"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "email" NVARCHAR(255) NOT NULL,
    "customer_type" NVARCHAR(255) CHECK
        (
            "customer_type" IN(N'Rich', N'Poor', N'Medium')
        ) NOT NULL
);
ALTER TABLE
    "customer" ADD CONSTRAINT "customer_id_primary" PRIMARY KEY("id");
CREATE UNIQUE INDEX "customer_email_unique" ON
    "customer"("email");
CREATE TABLE "brand"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "title" NVARCHAR(255) NOT NULL,
    "summary" NVARCHAR(255) NULL,
    "popularity" NVARCHAR(255) CHECK
        (
            "popularity" IN(N'Low', N'Medium', N'High')
        ) NOT NULL
);
insert into brand values('Samsung', 'Korean company', 'High');

ALTER TABLE
    "brand" ADD CONSTRAINT "brand_id_primary" PRIMARY KEY("id");
CREATE TABLE "employee"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "salary" BIGINT NOT NULL,
    "role" NVARCHAR(255) CHECK
        ("role" IN(N'Manager', N'Sales')) NOT NULL,
        "passwordHash" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "employee" ADD CONSTRAINT "employee_id_primary" PRIMARY KEY("id");
CREATE TABLE "order_item"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "product_id" BIGINT NULL,
    "item_id" BIGINT NULL,
    "order_id" BIGINT NOT NULL,
    "price" BIGINT NOT NULL,
    "quantitiy" BIGINT NOT NULL,
    "total_price" BIGINT NOT NULL
);
ALTER TABLE
    "order_item" ADD CONSTRAINT "order_item_id_primary" PRIMARY KEY("id");
CREATE TABLE "product_category"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "category_id" BIGINT NOT NULL,
    "product_id" BIGINT NOT NULL
);
ALTER TABLE
    "product_category" ADD CONSTRAINT "product_category_id_primary" PRIMARY KEY("id");
CREATE TABLE "supplier"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "email" NVARCHAR(255) NOT NULL,
    "supplier_type" NVARCHAR(255) CHECK
        (
            "supplier_type" IN(N'Trusted', N'New')
        ) NOT NULL
);
ALTER TABLE
    "supplier" ADD CONSTRAINT "supplier_id_primary" PRIMARY KEY("id");
CREATE UNIQUE INDEX "supplier_email_unique" ON
    "supplier"("email");
CREATE TABLE "category"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "title" NVARCHAR(255) NOT NULL,
    "description" NVARCHAR(255) NULL
);
ALTER TABLE
    "category" ADD CONSTRAINT "category_id_primary" PRIMARY KEY("id");
CREATE TABLE "loginSession"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "employee_id" BIGINT NOT NULL,
    "loggedInAt" DATETIME NOT NULL DEFAULT GETDATE()
);
ALTER TABLE
    "loginSession" ADD CONSTRAINT "loginsession_id_primary" PRIMARY KEY("id");
CREATE TABLE "user"(
    "id" BIGINT NOT NULL IDENTITY(1, 1),
    "supplier_id" BIGINT NULL,
    "customer_id" BIGINT NULL,
    "employee_id" BIGINT NULL,
    "user_type" NVARCHAR(255) CHECK
        (
            "user_type" IN(
                N'Customer',
                N'Supplier',
                N'Employee'
            )
        ) NOT NULL,
        "firstName" NVARCHAR(255) NOT NULL,
        "lastName" NVARCHAR(255) NULL,
        "username" NVARCHAR(255) NOT NULL,
        "mobile" BIGINT NOT NULL,
        "email" NVARCHAR(255) NOT NULL,
        "address" NVARCHAR(255) NOT NULL,
        "registeredAt" DATETIME NOT NULL DEFAULT GETDATE()
);
ALTER TABLE
    "user" ADD CONSTRAINT "user_id_primary" PRIMARY KEY("id");
CREATE UNIQUE INDEX "user_username_unique" ON
    "user"("username");
CREATE UNIQUE INDEX "user_mobile_unique" ON
    "user"("mobile");
CREATE UNIQUE INDEX "user_email_unique" ON
    "user"("email");
ALTER TABLE
    "order_item" ADD CONSTRAINT "order_item_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "product"("id") ON DELETE NO ACTION;
ALTER TABLE
    "item" ADD CONSTRAINT "item_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "product"("id") ON DELETE CASCADE;
ALTER TABLE
    "user" ADD CONSTRAINT "user_supplier_id_foreign" FOREIGN KEY("supplier_id") REFERENCES "supplier"("id") ON DELETE CASCADE;
ALTER TABLE
    "item" ADD CONSTRAINT "item_supplier_id_foreign" FOREIGN KEY("supplier_id") REFERENCES "supplier"("id") ON DELETE SET NULL;
ALTER TABLE
    "payment" ADD CONSTRAINT "payment_user_id_foreign" FOREIGN KEY("user_id") REFERENCES "user"("id") ON DELETE SET NULL;
ALTER TABLE
    "product_category" ADD CONSTRAINT "product_category_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "product"("id") ON DELETE CASCADE;
ALTER TABLE
    "payment" ADD CONSTRAINT "payment_order_id_foreign" FOREIGN KEY("order_id") REFERENCES "order"("id");
ALTER TABLE
    "item" ADD CONSTRAINT "item_brand_id_foreign" FOREIGN KEY("brand_id") REFERENCES "brand"("id");
ALTER TABLE
    "payment" ADD CONSTRAINT "payment_shippintaddress_id_foreign" FOREIGN KEY("shippintAddress_id") REFERENCES "shippingAddress"("id") ON DELETE SET NULL;
ALTER TABLE
    "order_item" ADD CONSTRAINT "order_item_item_id_foreign" FOREIGN KEY("item_id") REFERENCES "item"("id") ON DELETE SET NULL;
ALTER TABLE
    "product_category" ADD CONSTRAINT "product_category_category_id_foreign" FOREIGN KEY("category_id") REFERENCES "category"("id");
ALTER TABLE
    "order_item" ADD CONSTRAINT "order_item_order_id_foreign" FOREIGN KEY("order_id") REFERENCES "order"("id");
ALTER TABLE
    "order" ADD CONSTRAINT "order_employee_id_foreign" FOREIGN KEY("employee_id") REFERENCES "employee"("id") ON DELETE SET NULL;
ALTER TABLE
    "loginSession" ADD CONSTRAINT "loginsession_employee_id_foreign" FOREIGN KEY("employee_id") REFERENCES "employee"("id") ON DELETE CASCADE;
ALTER TABLE
    "user" ADD CONSTRAINT "user_employee_id_foreign" FOREIGN KEY("employee_id") REFERENCES "employee"("id") ON DELETE CASCADE;
ALTER TABLE
    "order" ADD CONSTRAINT "order_user_id_foreign" FOREIGN KEY("user_id") REFERENCES "user"("id") ON DELETE NO ACTION;
ALTER TABLE
    "user" ADD CONSTRAINT "user_customer_id_foreign" FOREIGN KEY("customer_id") REFERENCES "customer"("id") ON DELETE CASCADE;
ALTER TABLE
    "shippingAddress" ADD CONSTRAINT "shippingaddress_customer_id_foreign" FOREIGN KEY("customer_id") REFERENCES "customer"("id") ON DELETE NO ACTION;