IF OBJECT_ID('dbo.Protokoly', 'U') IS NOT NULL 
DROP TABLE dbo.Protokoly; 
IF OBJECT_ID('dbo.Zlecenia', 'U') IS NOT NULL 
DROP TABLE dbo.Zlecenia; 
IF OBJECT_ID('dbo.Przedzial_czasu', 'U') IS NOT NULL 
DROP TABLE dbo.Przedzial_czasu;

IF OBJECT_ID('dbo.AspNetUserRoles', 'U') IS NOT NULL 
DROP TABLE dbo.AspNetUserRoles; 

IF OBJECT_ID('dbo.AspNetUsers', 'U') IS NOT NULL 
DROP TABLE dbo.AspNetUsers; 

IF OBJECT_ID('dbo.AspNetRoles', 'U') IS NOT NULL 
DROP TABLE dbo.AspNetRoles; 


CREATE TABLE AspNetRoles(
    Id INT IDENTITY PRIMARY KEY,
    Name varchar(50) NOT NULL
);

INSERT INTO AspNetRoles (Name) VALUES ('Koordynator');
INSERT INTO AspNetRoles (Name) VALUES ('Kierowca');



CREATE TABLE AspNetUsers(
    Id INT IDENTITY PRIMARY KEY,
    UserName varchar(50) NOT NULL,
    PhoneNumber INT,
    Email varchar(50) NOT NULL UNIQUE,
    PasswordHash varchar(255) NOT NULL
);

INSERT INTO AspNetUsers (UserName, PhoneNumber, Email, PasswordHash) VALUES ('Piotr Gruszynski', '500300400', 'piotr@gmail.com', 'AQAAAAEAACcQAAAAEJhdNr2aoRVcadNmXCGjlyCM6qCuaNpCFYgfi7ODWwQPrrewilG1PMpSDaPnd81psg==');
INSERT INTO AspNetUsers (UserName, PhoneNumber, Email, PasswordHash) VALUES ('Tomasz Maciwoda', '500300400', 'tomasz@gmail.com', 'AQAAAAEAACcQAAAAEJhdNr2aoRVcadNmXCGjlyCM6qCuaNpCFYgfi7ODWwQPrrewilG1PMpSDaPnd81psg==');
INSERT INTO AspNetUsers (UserName, PhoneNumber, Email, PasswordHash) VALUES ('Krzysztof Tester', '500300400', 'krzysztof@gmail.com', 'AQAAAAEAACcQAAAAEJhdNr2aoRVcadNmXCGjlyCM6qCuaNpCFYgfi7ODWwQPrrewilG1PMpSDaPnd81psg==');


CREATE TABLE AspNetUserRoles(
    UserID INT NOT NULL,
    RoleID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES AspNetUsers(Id),
    FOREIGN KEY (RoleID) REFERENCES AspNetRoles(Id)
);

INSERT INTO AspNetUserRoles (UserID, RoleID) VALUES (1,1);
INSERT INTO AspNetUserRoles (UserID, RoleID) VALUES (2,2);
INSERT INTO AspNetUserRoles (UserID, RoleID) VALUES (3,2);

CREATE TABLE Przedzial_czasu (
    ID_Przedzial INT IDENTITY PRIMARY KEY,
    Kierowca_ID INT NOT NULL,
    OD DATETIME NOT NULL,
    DO DATETIME NOT NULL,
    FOREIGN KEY (Kierowca_ID) REFERENCES AspNetUsers(Id)
);

INSERT INTO Przedzial_czasu (Kierowca_ID, OD, DO) VALUES (1, '2020-05-06 20:00', '2020-05-07 20:00');


CREATE TABLE Zlecenia (
    ID_Zlecenie INT IDENTITY PRIMARY KEY,
    Miejsce_odbioru varchar(50) NOT NULL,
    Czas_odbioru DATETIME NOT NULL,
    Miejsce_zdania varchar(50) NOT NULL,
    Czas_zdania DATETIME NOT NULL,
    Status_zlecenia varchar(255),
    Kierowca_ID INT,
    Koordynator_ID INT NOT NULL,
    FOREIGN KEY (Kierowca_ID) REFERENCES AspNetUsers(Id),
    FOREIGN KEY (Koordynator_ID) REFERENCES AspNetUsers(Id)
);

INSERT INTO Zlecenia (Miejsce_odbioru, Czas_odbioru, Miejsce_zdania, Czas_zdania, Status_zlecenia, Kierowca_ID, Koordynator_ID) VALUES ('Kamienna 13 Wroclaw', '2020-05-06 20:00', 'Powstancow 30 Warszawa', '2020-05-07 20:00', 'Wykonane', 1, 3);


CREATE TABLE Protokoly (
    ID_Protokol INT IDENTITY PRIMARY KEY,
    Zlecenie_ID INT NOT NULL,
    Plik varchar(100) NOT NULL,
    FOREIGN KEY (Zlecenie_ID) REFERENCES Zlecenia(ID_Zlecenie)
);

INSERT INTO Protokoly (Zlecenie_ID, Plik) VALUES (1,'sciezkadopliku');
INSERT INTO Protokoly (Zlecenie_ID, Plik) VALUES (1, 'sciezkadopliku');

SELECT
	ID_Zlecenie, Miejsce_odbioru, Czas_odbioru, Miejsce_zdania, Czas_zdania, Kierowca, Koordynator, Plik as Protokół, Status_zlecenia
FROM 
	Zlecenia 
JOIN 
	(select Id as Id_Kierowcy, UserName as Kierowca from AspNetUsers ) as foo
ON
	Zlecenia.Kierowca_ID = Id_Kierowcy
JOIN 
	(select Id as Id_Koordynatora, UserName as Koordynator from AspNetUsers) as foo2
ON
	Zlecenia.Koordynator_ID = Id_Koordynatora
LEFT JOIN Protokoly
ON
	Protokoly.Zlecenie_ID = ID_Zlecenie;