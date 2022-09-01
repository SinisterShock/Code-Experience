Create table Location (
StreetAddress VARCHAR2(255) NOT NULL,
City VARCHAR2(255) NOT NULL,
State VARCHAR2(2) NOT NULL,
Zip VARCHAR2(9) NOT NULL,
CONSTRAINT PK_Location PRIMARY KEY (StreetAddress)
);

Create table Hotel (
HotelID VARCHAR2(10) NOT NULL,
Name VARCHAR2(25) NOT NULL,
Rating INT,
StreetAddress VARCHAR2(255) NOT NULL,
PRIMARY KEY (HotelID),
CONSTRAINT FK_StreetAddress FOREIGN KEY (StreetAddress) REFERENCES Location(StreetAddress)
);

Create Table Customer (
CustomerID VARCHAR2(10) NOT NULL,
FirstName VARCHAR2(25),
LastName VARCHAR(25),
IsPreffered NUMBER(1),
StreetAddress VARCHAR2(255) NOT NULL,
Primary Key (CustomerID),
CONSTRAINT FK_CustStreetAddress FOREIGN KEY (StreetAddress) REFERENCES Location(StreetAddress)
);

Create Table Room(
RoomNumber INT NOT NULL,
IsAccessible NUMBER(1),
Beds INT,
MaximumGuest INT,
HotelID VARCHAR2(10) NOT NULL,
CurrentCustomer VARCHAR2(10) NOT NULL,
CheckInDate Date,
CheckOutDate Date,
Primary Key (RoomNumber),
CONSTRAINT FK_RoomHotelID FOREIGN KEY (HotelID) REFERENCES Hotel(HotelID),
CONSTRAINT FK_RoomCustomerID FOREIGN KEY (CurrentCustomer) REFERENCES Customer(CustomerID)
);

Create Table Rate(
RateCode VARCHAR2(2) NOT NULL,
Amount DECIMAL(4,2),
Description VARCHAR2(255),
Condition VARCHAR2(255),
RoomNumber INT NOT NULL,
CONSTRAINT FK_RateRoom FOREIGN KEY (RoomNumber) REFERENCES Room(RoomNumber)
);