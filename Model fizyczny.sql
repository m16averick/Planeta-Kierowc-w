drop table Zlecenia;
drop table Dostepnosc;
drop table Users;
drop table Role;


drop table Protokoly;







CREATE TABLE If not exists Role (
    ID INT,
    Nazwa varchar(50),
    PRIMARY KEY (ID)
);

CREATE TABLE If not exists Users (
    ID INT,
    Imie_nazwisko varchar(50),
    Numer_tel INT,
    Rola_ID INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (Rola_ID) REFERENCES Role(ID)
);

CREATE TABLE If not exists Dostepnosc (
    ID INT,
    Kierowca_ID INT,
    OD DATETIME,
    DO DATETIME,
    PRIMARY KEY (ID),
    FOREIGN KEY (Kierowca_ID) REFERENCES Users(ID)
);



CREATE TABLE If not exists Protokoly (
    ID INT,
    Plik varchar(100),
    PRIMARY KEY (ID)
);


CREATE TABLE If not exists Zlecenia (
    ID INT,
    Miejsce_odbioru varchar(50),
    Czas_odbioru DATETIME,
    Miejsce_zdania varchar(50),
    Czas_zdania DATETIME,
    Kierowca_ID INT,
    Koordynator_ID INT,
    Klient_ID INT,
    Protokol_ID INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (Kierowca_ID) REFERENCES Users(ID),
    FOREIGN KEY (Koordynator_ID) REFERENCES Users(ID),
    FOREIGN KEY (Klient_ID) REFERENCES Users(ID),
    FOREIGN KEY (Protokol_ID) REFERENCES Protokoly(ID)
);

INSERT INTO Role VALUES (1, 'Koordynator');
INSERT INTO Role VALUES (2, 'Kierowca');
INSERT INTO Role VALUES (3, 'Klient');

INSERT INTO Users VALUES (1, 'Piotr Gruszynski', '500300400', 1);
INSERT INTO Users VALUES (2, 'Tomasz Maciwoda', '500300400', 2);
INSERT INTO Users VALUES (3, 'Jan Kowalski', '500300400', 3);
INSERT INTO Dostepnosc VALUES (1, 1, '2020-05-06 20:00', '2020-05-07 20:00');


INSERT INTO Protokoly VALUES (1, 'sciezkadopliku');
INSERT INTO Zlecenia VALUES (1, 'Kamienna 13 Wroclaw', '2020-05-06 20:00', 'Powstancow 30 Warszawa', '2020-05-07 20:00', 1, 2, 3, 1);


select ID, Miejsce_odbioru, Czas_odbioru, Miejsce_zdania, Czas_zdania, Kierowca, Koordynator, Klient, Protokol from Zlecenia natural left join (select ID as Kierowca_ID, Imie_nazwisko as Kierowca from Users) as foo2 natural left join (select ID as Koordynator_ID, Imie_nazwisko as Koordynator from Users) as foo3 natural left join (select ID as Klient_ID, Imie_nazwisko as Klient from Users) as foo4 natural left join (select ID as Protokol_ID, Plik as Protokol from Protokoly) as foo5 ;