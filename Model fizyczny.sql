IF OBJECT_ID('dbo.Protokoly', 'U') IS NOT NULL 
DROP TABLE dbo.Protokoly; 
IF OBJECT_ID('dbo.Zlecenia', 'U') IS NOT NULL 
DROP TABLE dbo.Zlecenia; 
IF OBJECT_ID('dbo.Przedzial_czasu', 'U') IS NOT NULL 
DROP TABLE dbo.Przedzial_czasu;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL 
DROP TABLE dbo.Users; 

IF OBJECT_ID('dbo.Role', 'U') IS NOT NULL 
DROP TABLE dbo.Role; 



CREATE TABLE Role(
    ID_Rola INT IDENTITY PRIMARY KEY,
    Nazwa varchar(50) NOT NULL,
);

INSERT INTO Role (Nazwa) VALUES ('Koordynator');
INSERT INTO Role (Nazwa) VALUES ('Kierowca');



CREATE TABLE Users(
    ID_User INT IDENTITY PRIMARY KEY,
    Imie_nazwisko varchar(50) NOT NULL,
    Numer_tel INT,
    Rola_ID INT NOT NULL,
    FOREIGN KEY (Rola_ID) REFERENCES Role(ID_Rola)
);

INSERT INTO Users (Imie_nazwisko, Numer_tel, Rola_ID) VALUES ('Piotr Gruszynski', '500300400', 1);
INSERT INTO Users (Imie_nazwisko, Numer_tel, Rola_ID) VALUES ('Tomasz Maciwoda', '500300400', 2);


CREATE TABLE Przedzial_czasu (
    ID_Przedzial INT IDENTITY PRIMARY KEY,
    Kierowca_ID INT NOT NULL,
    OD DATETIME NOT NULL,
    DO DATETIME NOT NULL,
    FOREIGN KEY (Kierowca_ID) REFERENCES Users(ID_User)
);

INSERT INTO Przedzial_czasu (Kierowca_ID, OD, DO) VALUES (1, '2020-05-06 20:00', '2020-05-07 20:00');


CREATE TABLE Zlecenia (
    ID_Zlecenie INT IDENTITY PRIMARY KEY,
    Miejsce_odbioru varchar(50),
    Czas_odbioru DATETIME,
    Miejsce_zdania varchar(50),
    Czas_zdania DATETIME,
    Kierowca_ID INT,
    Koordynator_ID INT,
    FOREIGN KEY (Kierowca_ID) REFERENCES Users(ID_User),
    FOREIGN KEY (Koordynator_ID) REFERENCES Users(ID_User)
);

INSERT INTO Zlecenia (Miejsce_odbioru, Czas_odbioru, Miejsce_zdania, Czas_zdania, Kierowca_ID, Koordynator_ID) VALUES ('Kamienna 13 Wroclaw', '2020-05-06 20:00', 'Powstancow 30 Warszawa', '2020-05-07 20:00', 1, 2);


CREATE TABLE Protokoly (
    ID_Protokol INT IDENTITY PRIMARY KEY,
    Zlecenie_ID INT NOT NULL,
    Plik varchar(100) NOT NULL,
    FOREIGN KEY (Zlecenie_ID) REFERENCES Zlecenia(ID_Zlecenie)
);

INSERT INTO Protokoly (Zlecenie_ID, Plik) VALUES (1,'sciezkadopliku');
INSERT INTO Protokoly (Zlecenie_ID, Plik) VALUES (1, 'sciezkadopliku');

SELECT
	ID_Zlecenie, Miejsce_odbioru, Czas_odbioru, Miejsce_zdania, Czas_zdania, Kierowca, Koordynator, Plik as Protokół
FROM 
	Zlecenia 
FULL JOIN 
	(select ID_User, Imie_nazwisko as Kierowca from Users WHERE Rola_ID=1) as foo
ON
	Zlecenia.Kierowca_ID = ID_User
FULL JOIN 
	(select ID_User as ID_K, Imie_nazwisko as Koordynator from Users WHERE Rola_ID=2) as foo2
ON
	Zlecenia.Koordynator_ID = ID_K
LEFT JOIN Protokoly
ON
	Protokoly.Zlecenie_ID = ID_Zlecenie