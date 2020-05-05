CREATE TABLE Zlecenia (
    ID INT,
    Miejsce_odbioru varchar(50),
    Czas_odbioru DATETIME,
    Mijesce_zdania varchar(50),
    Czas_zdania DATETIME,
    Kierowca_ID INT,
    Koordynator_ID INT,
    Klient_ID INT,
    Protokol_ID varchar(5)
);

CREATE TABLE Users (
    ID INT,
    Imie_nazwisko varchar(50),
    Numer_tel INT,
    Rola_ID varchar(50)
);

CREATE TABLE Dostepnosc (
    ID INT,
    Kierowca_ID INT,
    OD DATETIME,
    DO DATETIME
);

CREATE TABLE Role (
    ID INT,
    Nazwa varchar(50)
);

CREATE TABLE Protokoly (
    ID INT,
    Plik varchar(100)
);

INSERT INTO Zlecenia VALUES (1, 'Kamienna 13 Wroclaw', '2020-05-06 20:00', 'Powstancow 30 Warszawa', '2020-05-07 20:00', 1, 1, 1, 1);
INSERT INTO Users VALUES (1, 'Tomasz Maciwoda', '531772063', 1);
INSERT INTO Dostepnosc VALUES (1, 1, '2020-05-06 20:00', '2020-05-07 20:00');
INSERT INTO Role VALUES (1, 'Koordynator');
INSERT INTO Role VALUES (2, 'Kierowca');
INSERT INTO Role VALUES (3, 'Klient');

INSERT INTO Protokoly VALUES (1, 'sciezkadopliku');