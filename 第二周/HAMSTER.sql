USE HAMSTER;

CREATE TABLE  HAMSTER (
    HamsterID INT ,
    Name VARCHAR(50),
    Age INT,
    Color VARCHAR(50)
);
go
insert INTO HAMSTER (HamsterID,Name, Age, Color) VALUES
    (11,'bobo', 2, 'Brown'),
    (12,'hihi', 3, 'Gray'),
    (13,'nini', 1, 'White');