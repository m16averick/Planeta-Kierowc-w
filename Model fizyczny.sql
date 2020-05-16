drop table if exists Protokoly;
drop table if exists Zlecenia;
drop table if exists Przedzial_czasu;
drop table if exists Users;
drop table if exists Role;


CREATE TABLE Role(
    ID_Rola INT NOT NULL AUTO_INCREMENT,
    Nazwa varchar(50) NOT NULL,
    PRIMARY KEY (ID_Rola)
);

INSERT INTO Role (Nazwa) VALUES ('Koordynator');
INSERT INTO Role (Nazwa) VALUES ('Kierowca');
INSERT INTO Role (Nazwa) VALUES ('Klient');


CREATE TABLE Users (
    ID_User INT NOT NULL AUTO_INCREMENT,
    Imie_nazwisko varchar(50),
    Numer_tel INT,
    Rola_ID INT,
    PRIMARY KEY (ID_User),
    FOREIGN KEY (Rola_ID) REFERENCES Role(ID_Rola)
);

INSERT INTO Users (Imie_nazwisko, Numer_tel, Rola_ID) VALUES ('Piotr Gruszynski', '500300400', 1);
INSERT INTO Users (Imie_nazwisko, Numer_tel, Rola_ID) VALUES ('Tomasz Maciwoda', '500300400', 2);
INSERT INTO Users (Imie_nazwisko, Numer_tel, Rola_ID) VALUES ('Jan Kowalski', '500300400', 3);


CREATE TABLE Przedzial_czasu (
    ID_Przedzial INT unsigned NOT NULL AUTO_INCREMENT,
    Kierowca_ID INT NOT NULL,
    OD DATETIME NOT NULL,
    DO DATETIME NOT NULL,
    PRIMARY KEY (ID_Przedzial),
    FOREIGN KEY (Kierowca_ID) REFERENCES Users(ID_User)
);

INSERT INTO Przedzial_czasu (Kierowca_ID, OD, DO) VALUES (1, '2020-05-06 20:00', '2020-05-07 20:00');


CREATE TABLE Zlecenia (
    ID_Zlecenie INT NOT NULL AUTO_INCREMENT,
    Miejsce_odbioru varchar(50),
    Czas_odbioru DATETIME,
    Miejsce_zdania varchar(50),
    Czas_zdania DATETIME,
    Kierowca_ID INT,
    Koordynator_ID INT,
    PRIMARY KEY (ID_Zlecenie),
    FOREIGN KEY (Kierowca_ID) REFERENCES Users(ID_User),
    FOREIGN KEY (Koordynator_ID) REFERENCES Users(ID_User)
);

INSERT INTO Zlecenia (Miejsce_odbioru, Czas_odbioru, Miejsce_zdania, Czas_zdania, Kierowca_ID, Koordynator_ID) VALUES ('Kamienna 13 Wroclaw', '2020-05-06 20:00', 'Powstancow 30 Warszawa', '2020-05-07 20:00', 1, 2);


CREATE TABLE Protokoly (
    ID_Protokol INT unsigned NOT NULL AUTO_INCREMENT,
    Zlecenie_ID INT NOT NULL,
    Plik varchar(100),
    PRIMARY KEY (ID_Protokol),
    FOREIGN KEY (Zlecenie_ID) REFERENCES Zlecenia(ID_Zlecenie)
);

INSERT INTO Protokoly (Zlecenie_ID, Plik) VALUES (1, 'sciezkadopliku');

select ID_Zlecenie, Miejsce_odbioru, Czas_odbioru, Miejsce_zdania, Czas_zdania, Kierowca, Koordynator, Protokol from Zlecenia natural left join (select ID_User as Kierowca_ID, Imie_nazwisko as Kierowca from Users) as foo2 natural left join (select ID_User as Koordynator_ID, Imie_nazwisko as Koordynator from Users) as foo3 natural left join (select ID_Protokol as Protokol_ID, Plik as Protokol from Protokoly) as foo4 ;