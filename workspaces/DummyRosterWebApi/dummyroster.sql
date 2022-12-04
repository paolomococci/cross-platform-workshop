-- dummyroster.sql for SQLite

-- drop tables if exists

DROP TABLE IF EXISTS "Employee";
DROP TABLE IF EXISTS "Customer";
DROP TABLE IF EXISTS "Supplier";
DROP TABLE IF EXISTS "Carrier";
DROP TABLE IF EXISTS "Address";
DROP TABLE IF EXISTS "Category";
DROP TABLE IF EXISTS "Product";
DROP TABLE IF EXISTS "Form";
DROP TABLE IF EXISTS "Invoice";

-- Employee table
CREATE TABLE "Employee" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Name" varchar(32) NOT NULL,
  "BirthDate" DATETIME NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "Role" varchar(32) NULL,
  "Location" INT NULL,
  CONSTRAINT "FK_Employee_Address" FOREIGN KEY ("Location") REFERENCES "Address" ("Id")
);
CREATE INDEX "IDX_EmployeeName" ON "Employee"("Name");

-- Customer table
CREATE TABLE "Customer" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Name" varchar(32) NOT NULL,
  "FoundationDate" DATETIME NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "Contact" INT NULL,
  "Location" INT NULL,
  CONSTRAINT "FK_Customer_Employee" FOREIGN KEY ("Contact") REFERENCES "Employee" ("Id"),
  CONSTRAINT "FK_Customer_Address" FOREIGN KEY ("Location") REFERENCES "Address" ("Id")
);
CREATE INDEX "IDX_CustomerName" ON "Customer"("Name");

-- Supplier table
CREATE TABLE "Supplier" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Name" varchar(32) NOT NULL,
  "FoundationDate" DATETIME NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "Contact" INT NULL,
  "Location" INT NULL,
  CONSTRAINT "FK_Supplier_Employee" FOREIGN KEY ("Contact") REFERENCES "Employee" ("Id"),
  CONSTRAINT "FK_Supplier_Address" FOREIGN KEY ("Location") REFERENCES "Address" ("Id")
);
CREATE INDEX "IDX_SupplierName" ON "Supplier"("Name");

-- Carrier table
CREATE TABLE "Carrier" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Name" varchar(32) NOT NULL,
  "FoundationDate" DATETIME NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "Contact" INT NULL,
  "Location" INT NULL,
  CONSTRAINT "FK_Carrier_Employee" FOREIGN KEY ("Contact") REFERENCES "Employee" ("Id"),
  CONSTRAINT "FK_Carrier_Address" FOREIGN KEY ("Location") REFERENCES "Address" ("Id")
);
CREATE INDEX "IDX_CarrierName" ON "Carrier"("Name");

-- Address table
CREATE TABLE "Address" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "StreetOrSquare" varchar(32) NULL,
  "Civic" varchar(16) NULL,
  "City" varchar(16) NULL,
  "District" varchar(16) NULL,
  "Postcode" varchar(8) NULL,
  "Country" varchar(16) NULL,
  "Email" varchar(48) NULL,
  "Phone" varchar(24) NULL,
  "Fax" varchar(24) NULL
);
CREATE INDEX "IDX_AddressCity" ON "Address"("City");
CREATE INDEX "IDX_AddressDistrict" ON "Address"("District");
CREATE INDEX "IDX_AddressPostcode" ON "Address"("Postcode");
CREATE INDEX "IDX_AddressCountry" ON "Address"("Country");

-- Category table
CREATE TABLE "Category" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Name" varchar(32) NOT NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL
);
CREATE INDEX "IDX_CategoryName" ON "Category"("Name");

-- Product table
CREATE TABLE "Product" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Name" varchar(32) NOT NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "CategoryId" INT NULL,
  "SupplierId" INT NULL,
  "QuantityPerUnit" varchar(24) NULL,
  "UnitPrice" NUMERIC NULL CONSTRAINT "DF_Product_UnitPrice" DEFAULT (0),
  "UnitsInStock" SMALLINT NULL CONSTRAINT "DF_Product_UnitsInStock" DEFAULT (0),
  "UnitsOnOrder" SMALLINT NULL CONSTRAINT "DF_Product_UnitsOnOrder" DEFAULT (0),
  "ReorderLevel" SMALLINT NULL CONSTRAINT "DF_Product_ReorderLevel" DEFAULT (0),
  "Discontinued" BOOLEAN NOT NULL CONSTRAINT "DF_Product_Discontinued" DEFAULT (0),
  CONSTRAINT "FK_Product_Category" FOREIGN KEY ("CategoryId") REFERENCES "Category" ("Id"),
  CONSTRAINT "FK_Product_Supplier" FOREIGN KEY ("SupplierId") REFERENCES "Supplier" ("Id"),
  CONSTRAINT "CK_Product_UnitPrice" CHECK (UnitPrice >= 0),
  CONSTRAINT "CK_UnitsInStock" CHECK (UnitsInStock >= 0),
  CONSTRAINT "CK_UnitsOnOrder" CHECK (UnitsOnOrder >= 0),
  CONSTRAINT "CK_ReorderLevel" CHECK (ReorderLevel >= 0)
);
CREATE INDEX "IDX_ProductName" ON "Product"("Name");
CREATE INDEX "IDX_CategoryId" ON "Product"("CategoryId");
CREATE INDEX "IDX_ProductBelongingCategory" ON "Product"("CategoryId");
CREATE INDEX "IDX_SupplierId" ON "Product"("SupplierId");
CREATE INDEX "IDX_ProductSuppliedBy" ON "Product"("SupplierId");

-- Form table
CREATE TABLE "Form" (
  "Id" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Description" TEXT NULL,
  "CustomerId" INT NULL,
  "CarrierId" INT NULL,
  "EmployeeId" INT NULL,
  "FormDate" DATETIME NULL,
  "RequiredDate" DATETIME NULL,
  "PromisedDate" DATETIME NULL,
  "ShippingCost" NUMERIC NULL CONSTRAINT "DF_Form_ShippingCost" DEFAULT (0),
  CONSTRAINT "FK_Form_Customer" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("Id"),
  CONSTRAINT "FK_Form_Carrier" FOREIGN KEY ("CarrierId") REFERENCES "Carrier" ("Id"),
  CONSTRAINT "FK_Form_Employee" FOREIGN KEY ("EmployeeId") REFERENCES "Employee" ("Id")
);
CREATE INDEX "IDX_FormId" ON "Form"("Id");
CREATE INDEX "IDX_CustomerId" ON "Form"("CustomerId");
CREATE INDEX "IDX_CarrierId" ON "Form"("CarrierId");
CREATE INDEX "IDX_EmployeeId" ON "Form"("EmployeeId");
CREATE INDEX "IDX_FormDate" ON "Form"("FormDate");
CREATE INDEX "IDX_RequiredDate" ON "Form"("RequiredDate");
CREATE INDEX "IDX_PromisedDate" ON "Form"("PromisedDate");

-- Invoice table
CREATE TABLE "Invoice" (
  "Note" TEXT NULL,
  "FormId" INT NULL,
  "ProductId" INT NULL,
  "UnitPrice" NUMERIC NOT NULL CONSTRAINT "DF_Form_Details_UnitPrice" DEFAULT (0),
  "Quantity" SMALLINT NOT NULL CONSTRAINT "DF_Form_Details_Quantity" DEFAULT (1),
  "PriceCut" NUMERIC NOT NULL CONSTRAINT "DF_Form_Details_PriceCut" DEFAULT (0),
  CONSTRAINT "PK_Form_Details" PRIMARY KEY ("FormId", "ProductId"),
  CONSTRAINT "FK_Form_Details" FOREIGN KEY ("FormId") REFERENCES "Form" ("Id"),
  CONSTRAINT "FK_Product_Details" FOREIGN KEY ("ProductId") REFERENCES "Product" ("Id"),
  CONSTRAINT "CK_UnitPrice" CHECK (UnitPrice >= 0),
  CONSTRAINT "CK_Quantity" CHECK (Quantity > 0),
  CONSTRAINT "CK_PriceCut" CHECK (PriceCut >= 0 and PriceCut < 0.3)

);
CREATE INDEX "IDX_ProductId" ON "Invoice"("ProductId");
