CREATE TABLE EmployeeETL (
  EmployeeID INT PRIMARY KEY,
  FirstName VARCHAR2(50),
  LastName VARCHAR2(50),
  Email VARCHAR2(255)
);

CREATE TABLE HiddenInfo (
  EmployeeID INT,
  SSN VARCHAR(20),
  Salary INT,
  CONSTRAINT EmployeeID 
  FOREIGN KEY (EmployeeID)
  REFERENCES EmployeeETL(EmployeeID)
);

