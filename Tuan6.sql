CREATE DATABASE University;

USE University;

CREATE TABLE Faculty (
    FacultyID INT PRIMARY KEY, 
    FacultyName NVARCHAR(255) NOT NULL
);

CREATE TABLE Student (
    StudentID INT PRIMARY KEY,
    FullName NVARCHAR(255) NOT NULL,
    AverageScore FLOAT CHECK (AverageScore BETWEEN 0 AND 10),
    FacultyID INT,
    FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID) ON DELETE CASCADE ON UPDATE CASCADE
);
insert into student values(123,'a',5,1)
insert into student values(110,'b',5,2)
select * from Faculty
select * from Student