-- using the correct database
USE StudentDB;

-- creating the students table
CREATE TABLE Students (
student_id INT PRIMARY KEY, 
name VARCHAR(100), 
age INT, 
gender VARCHAR(10), 
course_id INT
);

-- creating the courses table 
CREATE TABLE Courses (
course_id INT PRIMARY KEY,
course_name VARCHAR(100),
duration VARCHAR(50)
);

-- creating the Marks table 
CREATE TABLE Marks (
mark_id INT PRIMARY KEY, 
student_id INT, 
subject VARCHAR(100), 
score INT
);

-- modify students table and add a new email column
ALTER TABLE Students 
ADD COLUMN email VARCHAR(100);

-- dropping table Marks 
DROP TABLE Marks;

-- recreating Marks table 
CREATE TABLE Marks (
mark_id INT PRIMARY KEY, 
student_id INT, 
subject VARCHAR(100), 
score INT
);

-- inserting 5 records into Students table
INSERT INTO Students (student_id, name, age, gender, course_id, email) VALUES
(1, 'Harsh', 20, 'Male', 1, 'harsh@gmail.com'),
(2, 'Hitarth', 22, 'Male', 2, 'hitarth@gmail.com'),
(3, 'Khushi', 21, 'Female', 3, 'khushi@ymail.com'),
(4, 'Saksham', 23, 'Male', 1, 'saksham@outlook.com'),
(5, 'Ruchika', 20, 'Female', 2, 'ruchika@gmail.com');

-- inserting 5 records into Courses table
INSERT INTO Courses (course_id, course_name, duration) VALUES
(1, 'Mathematics', '3 months'),
(2, 'Physics', '4 months'),
(3, 'Chemistry', '3 months'),
(4, 'Biology', '5 months'),
(5, 'Computer Science', '6 months');

-- inserting 5 records into Marks table
INSERT INTO Marks (mark_id, student_id, subject, score) VALUES
(1, 1, 'Mathematics', 90),
(2, 2, 'Physics', 85),
(3, 3, 'Chemistry', 88),
(4, 4, 'Biology', 92),
(5, 5, 'Computer Science', 95);

-- check students
SELECT * FROM Students;

-- check courses
SELECT * FROM Courses;

-- check marks
SELECT * FROM Marks;

-- update one student’s course : Khushi (student_id = 3) from Chemistry (course_id = 3) to Computer Science (course_id = 5).
UPDATE Students 
SET course_id = 5 
WHERE student_id = 3;

-- check students
SELECT * FROM Students;

-- deleting a record from student table
DELETE FROM Students 
WHERE student_id = 5;

INSERT INTO Students (student_id, name, age, gender, course_id, email) VALUES
(5, 'Ruchika', 20, 'Female', 2, 'ruchika@gmail.com');

-- check students
SELECT * FROM Students;

-- students above the age of 20
SELECT * FROM Students 
WHERE age > 20;

-- student detail ordered alphabetically
-- SELECT * FROM Students
-- ORDER BY name DESC;

-- total number of students enrolled in each course
SELECT course_id, COUNT(*) 
FROM Students 
GROUP BY course_id;


-- courses that have 2 or more students
SELECT course_id, COUNT(*) 
FROM Students 
GROUP BY course_id
HAVING COUNT(*) >= 2
;

-- inner join
SELECT Students.student_id, Students.name, Courses.course_name
FROM Students
INNER JOIN Courses
ON Students.course_id = Courses.course_id;

-- adding 5 more entries to all the tables 
INSERT INTO Students (student_id, name, age, gender, course_id, email) VALUES
(6, 'Priya', 22, 'Female', 4, 'priya@gmail.com'),
(7, 'Aman', 21, 'Male', 2, 'aman@yahoo.com'),
(8, 'Neha', 23, 'Female', 5, 'neha@hotmail.com'),
(9, 'Rahul', 20, 'Male', 3, 'rahul@gmail.com'),
(10, 'Tanya', 22, 'Female', 1, 'tanya@outlook.com');

INSERT INTO Courses (course_id, course_name, duration) VALUES
(6, 'English', '2 months'),
(7, 'History', '3 months'),
(8, 'Geography', '4 months'),
(9, 'Economics', '5 months'),
(10, 'Political Science', '3 months');

INSERT INTO Marks (mark_id, student_id, subject, score) VALUES
(6, 6, 'Biology', 89),
(7, 7, 'Physics', 78),
(8, 8, 'Computer Science', 91),
(9, 9, 'Chemistry', 84),
(10, 10, 'Mathematics', 88);

-- all courses and their students right joinn
SELECT Courses.course_id, Courses.course_name, Students.name
FROM Students
RIGHT JOIN Courses
ON Students.course_id = Courses.course_id;

-- high, low, average marks per subject
SELECT subject, MAX(score), MIN(score), AVG(score)
FROM Marks
GROUP BY subject;

-- count how many male and female students
SELECT gender, COUNT(*)
FROM Students
GROUP BY gender;


SELECT * FROM Students;

SHOW ENGINES;

-- average arks of students having courses where duration is greather than 3
SELECT Students.name, Marks.score, Courses.duration, Courses.course_name, AVG(Marks.score)
FROM Students 
JOIN Courses ON Students.course_id = Courses.course_id
JOIN Marks ON Students.student_id = Marks.student_id
WHERE Courses.duration > 3
GROUP BY Marks.student_id
HAVING AVG(Marks.score) > 80;