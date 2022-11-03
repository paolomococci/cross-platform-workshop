-- dummyroster.sql for SQLite

-- drop tables if exists

DROP TABLE IF EXISTS "Employee";
DROP TABLE IF EXISTS "Customer";
DROP TABLE IF EXISTS "Supplier";
DROP TABLE IF EXISTS "Carrier";
DROP TABLE IF EXISTS "Category";
DROP TABLE IF EXISTS "Product";
DROP TABLE IF EXISTS "Form";
DROP TABLE IF EXISTS "Invoice";

-- Employee table
CREATE TABLE "Employee" (
  "Id" BIGINT NOT NULL,
  "Name" varchar(32) NOT NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "Role" varchar(32) NULL,
  "Address" varchar(64) NULL,
  "City" varchar(16) NULL,
  "District" varchar(16) NULL,
  "Postcode" varchar(8) NULL,
  "Country" varchar(16) NULL,
  "Email" varchar(48) NULL,
  "Phone" varchar(24) NULL,
  "Fax" varchar(24) NULL,
  CONSTRAINT "PK_Employee" PRIMARY KEY ("Id")
);
CREATE INDEX "IDX_EmployeeName" ON "Employee"("Name");
CREATE INDEX "IDX_EmployeeCity" ON "Employee"("City");
CREATE INDEX "IDX_EmployeeDistrict" ON "Employee"("District");
CREATE INDEX "IDX_EmployeePostcode" ON "Employee"("Postcode");

-- Customer table
CREATE TABLE "Customer" (
  "Id" BIGINT NOT NULL,
  "Name" varchar(32) NOT NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "Contact" BIGINT NULL,
  "Address" varchar(64) NULL,
  "City" varchar(16) NULL,
  "District" varchar(16) NULL,
  "Postcode" varchar(8) NULL,
  "Country" varchar(16) NULL,
  "Email" varchar(48) NULL,
  "Phone" varchar(24) NULL,
  "Fax" varchar(24) NULL,
  CONSTRAINT "PK_Customer" PRIMARY KEY ("Id"),
  CONSTRAINT "FK_Customer_Employee" FOREIGN KEY ("Contact") REFERENCES "Employee" ("Id")
);
CREATE INDEX "IDX_CustomerName" ON "Customer"("Name");
CREATE INDEX "IDX_CustomerCity" ON "Customer"("City");
CREATE INDEX "IDX_CustomerDistrict" ON "Customer"("District");
CREATE INDEX "IDX_CustomerPostcode" ON "Customer"("Postcode");

-- Supplier table
CREATE TABLE "Supplier" (
  "Id" BIGINT NOT NULL,
  "Name" varchar(32) NOT NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "Contact" BIGINT NULL,
  "Address" varchar(64) NULL,
  "City" varchar(16) NULL,
  "District" varchar(16) NULL,
  "Postcode" varchar(8) NULL,
  "Country" varchar(16) NULL,
  "Email" varchar(48) NULL,
  "Phone" varchar(24) NULL,
  "Fax" varchar(24) NULL,
  CONSTRAINT "PK_Supplier" PRIMARY KEY ("Id"),
  CONSTRAINT "FK_Supplier_Employee" FOREIGN KEY ("Contact") REFERENCES "Employee" ("Id")
);
CREATE INDEX "IDX_SupplierName" ON "Supplier"("Name");
CREATE INDEX "IDX_SupplierCity" ON "Supplier"("City");
CREATE INDEX "IDX_SupplierDistrict" ON "Supplier"("District");
CREATE INDEX "IDX_SupplierPostcode" ON "Supplier"("Postcode");

-- Carrier table
CREATE TABLE "Carrier" (
  "Id" BIGINT NOT NULL,
  "Name" varchar(32) NOT NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "Contact" BIGINT NULL,
  "Address" varchar(64) NULL,
  "City" varchar(16) NULL,
  "District" varchar(16) NULL,
  "Postcode" varchar(8) NULL,
  "Country" varchar(16) NULL,
  "Email" varchar(48) NULL,
  "Phone" varchar(24) NULL,
  "Fax" varchar(24) NULL,
  CONSTRAINT "PK_Carrier" PRIMARY KEY ("Id"),
  CONSTRAINT "FK_Carrier_Employee" FOREIGN KEY ("Contact") REFERENCES "Employee" ("Id")
);
CREATE INDEX "IDX_CarrierName" ON "Carrier"("Name");
CREATE INDEX "IDX_CarrierCity" ON "Carrier"("City");
CREATE INDEX "IDX_CarrierDistrict" ON "Carrier"("District");
CREATE INDEX "IDX_CarrierPostcode" ON "Carrier"("Postcode");

-- Category table
CREATE TABLE "Category" (
  "Id" BIGINT NOT NULL,
  "Name" varchar(32) NOT NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  CONSTRAINT "PK_Category" PRIMARY KEY ("Id")
);
CREATE INDEX "IDX_CategoryName" ON "Category"("Name");

-- Product table
CREATE TABLE "Product" (
  "Id" BIGINT NOT NULL,
  "Name" varchar(32) NOT NULL,
  "Description" TEXT NULL,
  "Picture" BLOB NULL,
  "CategoryId" BIGINT NULL,
  "SupplierId" BIGINT NULL,
  "QuantityPerUnit" varchar(24) NULL,
  "UnitPrice" REAL NULL CONSTRAINT "DF_Product_UnitPrice" DEFAULT (0),
  "UnitsInStock" SMALLINT NULL CONSTRAINT "DF_Product_UnitsInStock" DEFAULT (0),
  "UnitsOnOrder" SMALLINT NULL CONSTRAINT "DF_Product_UnitsOnOrder" DEFAULT (0),
  "ReorderLevel" SMALLINT NULL CONSTRAINT "DF_Product_ReorderLevel" DEFAULT (0),
  "Discontinued" TINYINT NOT NULL CONSTRAINT "DF_Product_Discontinued" DEFAULT (0),
  CONSTRAINT "PK_Product" PRIMARY KEY ("Id"),
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
  "Id" BIGINT NOT NULL,
  "Description" TEXT NULL,
  "CustomerId" BIGINT NULL,
  "CarrierId" BIGINT NULL,
  "EmployeeId" BIGINT NULL,
  "FormDate" DATETIME NULL,
  "RequiredDate" DATETIME NULL,
  "PromisedDate" DATETIME NULL,
  "ShippingCost" REAL NULL CONSTRAINT "DF_Form_ShippingCost" DEFAULT (0),
  CONSTRAINT "PK_Form" PRIMARY KEY ("Id"),
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
  "FormId" BIGINT NULL,
  "ProductId" BIGINT NULL,
  "UnitPrice" REAL NOT NULL CONSTRAINT "DF_Form_Details_UnitPrice" DEFAULT (0),
  "Quantity" SMALLINT NOT NULL CONSTRAINT "DF_Form_Details_Quantity" DEFAULT (1),
  "PriceCut" REAL NOT NULL CONSTRAINT "DF_Form_Details_PriceCut" DEFAULT (0),
  CONSTRAINT "PK_Form_Details" PRIMARY KEY ("FormId", "ProductId"),
  CONSTRAINT "FK_Form_Details" FOREIGN KEY ("FormId") REFERENCES "Form" ("Id"),
  CONSTRAINT "FK_Product_Details" FOREIGN KEY ("ProductId") REFERENCES "Product" ("Id"),
  CONSTRAINT "CK_UnitPrice" CHECK (UnitPrice >= 0),
  CONSTRAINT "CK_Quantity" CHECK (Quantity > 0),
  CONSTRAINT "CK_PriceCut" CHECK (PriceCut >= 0 and PriceCut < 0.3)

);
CREATE INDEX "IDX_FormId" ON "Invoice"("FormId");
CREATE INDEX "IDX_ProductId" ON "Invoice"("ProductId");
