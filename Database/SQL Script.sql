CREATE TABLE Clients (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Gender CHAR(1) NOT NULL, -- 'M' for Male, 'F' for Female
    DateOfBirth DATE
);

GO

CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT NOT NULL,
    AddressType NVARCHAR(50) NOT NULL, -- e.g., Residential, Work, Postal
    AddressLine1 NVARCHAR(255) NOT NULL,
    AddressLine2 NVARCHAR(255),
    City NVARCHAR(100),
    State NVARCHAR(100),
    PostalCode NVARCHAR(20),
    FOREIGN KEY (ClientID) REFERENCES Clients(Id)
);

GO

CREATE TABLE Contacts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClientID INT NOT NULL,
    ContactType NVARCHAR(50) NOT NULL, -- e.g., Cell, Work, Home
    ContactValue NVARCHAR(100) NOT NULL,
    FOREIGN KEY (ClientID) REFERENCES Clients(Id)
);

GO
-- Insert 10 sample clients
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('John Doe', 'M', '1980-05-10');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('Jane Smith', 'F', '1990-07-15');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('Mark Johnson', 'M', '1985-09-20');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('Lucy Brown', 'F', '1995-12-01');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('William Garcia', 'M', '1975-03-25');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('Olivia Davis', 'F', '1982-08-10');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('James Wilson', 'M', '1992-11-30');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('Sophia Martinez', 'F', '1988-06-05');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('Michael Taylor', 'M', '1983-04-18');
INSERT INTO Clients (Name, Gender, DateOfBirth) VALUES ('Emma Anderson', 'F', '1997-02-14');

GO

-- Insert addresses for the clients
INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (1, 'Residential', '123 Main St', NULL, 'New York', 'NY', '10001');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (2, 'Work', '456 Park Ave', 'Suite 101', 'Los Angeles', 'CA', '90001');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (3, 'Postal', '789 Broadway', NULL, 'San Francisco', 'CA', '94101');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (4, 'Residential', '101 Oak Dr', NULL, 'Chicago', 'IL', '60601');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (5, 'Work', '202 Pine St', 'Floor 5', 'Miami', 'FL', '33101');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (6, 'Postal', '303 Cedar Blvd', NULL, 'Dallas', 'TX', '75201');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (7, 'Residential', '404 Elm St', NULL, 'Houston', 'TX', '77001');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (8, 'Work', '505 Maple Rd', 'Apt 9', 'Philadelphia', 'PA', '19101');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (9, 'Postal', '606 Birch Ln', NULL, 'Phoenix', 'AZ', '85001');

INSERT INTO Addresses (ClientID, AddressType, AddressLine1, AddressLine2, City, State, PostalCode) 
VALUES (10, 'Residential', '707 Cedar St', NULL, 'Seattle', 'WA', '98101');

GO

-- Insert contacts for the clients
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (1, 'Cell', '555-1234');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (1, 'Work', '555-5678');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (2, 'Cell', '555-2345');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (3, 'Cell', '555-3456');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (3, 'Home', '555-7890');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (4, 'Work', '555-4567');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (5, 'Cell', '555-5678');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (6, 'Cell', '555-6789');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (7, 'Home', '555-7890');
INSERT INTO Contacts (ClientID, ContactType, ContactValue) VALUES (8, 'Work', '555-8901');






