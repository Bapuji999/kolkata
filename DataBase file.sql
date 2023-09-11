create database customerProductData

CREATE TABLE CustomerData
(
	CustomerId INT,
	CustomerName varchar(250),
	Gender varchar(250),
	ContactNumber varchar(250)
)
CREATE TABLE Product
(
	ProductId INT,
	ProductName VARCHAR(250),
	Price INT,
	CustomerId INT,
	SaleDate VARCHAR(250),
)

create or alter procedure SaveProductCustomer
(
	@OutMessage varchar(250) OUTPUT,
	@CustomerId INT,
	@CustomerName varchar(250),
	@Gender varchar(250),
	@ContactNumber varchar(250),
	@ProductId INT,
	@ProductName varchar(250),
	@Price INT
)
AS
BEGIN
	INSERT INTO CustomerData 
	SELECT CustomerId = @CustomerId,
	CustomerName = @CustomerName,
	Gender = @Gender,
	ContactNumber = @ContactNumber;

	INSERT INTO Product 
	SELECT ProductId = @ProductId,
	ProductName = @ProductName,
	Price = @Price,
	CustomerId = @CustomerId,
	SaleDate = '';
	SET @OutMessage = 'Sucessfull';
	SELECT @OutMessage ;
END

exec  GetProductCustomer '', 1

create or alter procedure GetProductCustomer
(
	@OutMessage varchar(250) OUTPUT,
	@CustomerId INT
)
AS
BEGIN
	SELECT CustomerName, ProductName, Price  
	FROM CustomerData CD 
	INNER JOIN Product P ON CD.CustomerId = P.CustomerId
	WHERE CD.CustomerId = @CustomerId;
	SET @OutMessage = 'Sucessfull';
	SELECT @OutMessage ;
END

create or alter procedure SaveSaleDate
(
	@OutMessage varchar(250) OUTPUT,
	@CustomerId INT,
	@SaleDate varchar(250)
)
AS
BEGIN
	UPDATE Product SET SaleDate = @SaleDate 
	WHERE CustomerId = @CustomerId;
	SET @OutMessage = 'Sucessfull';
	SELECT @OutMessage ;
END


create or alter procedure ShowTable
(
	@OutMessage varchar(250) OUTPUT
)
AS
BEGIN
	SELECT CustomerName, ProductName, Price, SaleDate 
	FROM CustomerData CD 
	INNER JOIN Product P ON CD.CustomerId = P.CustomerId;
	SELECT @OutMessage ;
END