IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Relations'))
BEGIN
DROP TABLE Relations
DROP TABLE Categories
DROP TABLE Products
END

CREATE TABLE Categories (
    ID INT IDENTITY PRIMARY KEY,
  	Name VARCHAR(20) NOT NULL
)  

CREATE TABLE Products (
    ID INT IDENTITY PRIMARY KEY,
  	Name VARCHAR(20) NOT NULL,
)

CREATE TABLE Relations (
    Product_ID INT FOREIGN KEY REFERENCES Products(ID)
               on update no action
               on delete no action,

    Category_ID INT FOREIGN KEY REFERENCES Categories(ID)
               on update no action
               on delete no action,
);

INSERT INTO Products (Name) VALUES ('Banana')
INSERT INTO Products (Name) VALUES ('Burger')
INSERT INTO Products (Name) VALUES ('Cucumber')
INSERT INTO Products (Name) VALUES ('Mushrooms')
INSERT INTO Products (Name) VALUES ('Fish')

INSERT INTO Categories (Name) VALUES ('Fruits')
INSERT INTO Categories (Name) VALUES ('Meat')
INSERT INTO Categories (Name) VALUES ('Vegetables')
INSERT INTO Categories (Name) VALUES ('Junk Food')
INSERT INTO Categories (Name) VALUES ('Healthy Food')
INSERT INTO Categories (Name) VALUES ('Seafood')

INSERT INTO Relations (Product_ID, Category_ID) VALUES (1, 1);
INSERT INTO Relations (Product_ID, Category_ID) VALUES (1, 5);
INSERT INTO Relations (Product_ID, Category_ID) VALUES (2, 2);
INSERT INTO Relations (Product_ID, Category_ID) VALUES (2, 4);
INSERT INTO Relations (Product_ID, Category_ID) VALUES (3, 3);
INSERT INTO Relations (Product_ID, Category_ID) VALUES (3, 5);
INSERT INTO Relations (Product_ID, Category_ID) VALUES (5, 4);
INSERT INTO Relations (Product_ID, Category_ID) VALUES (5, 5);

SELECT * FROM Categories
SELECT * FROM Products
SELECT * FROM Relations

SELECT
    COALESCE(p.Name, '...') AS Product,
    COALESCE(c.Name, '...') AS Category
		FROM
			Products p
		LEFT JOIN
			Relations r ON p.ID = r.Product_ID
		LEFT JOIN
		    Categories c ON r.Category_ID = c.ID;