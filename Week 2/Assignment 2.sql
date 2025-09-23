
use StudentDB;


-- average score is 88, returns all details of students having score greater than 88
SELECT s.student_id, s.name, m.subject, m.score
FROM Students s
JOIN Marks m ON s.student_id = m.student_id
WHERE m.score > (SELECT AVG(score) FROM Marks);



-- try -max scorer
SELECT s.student_id, s.name, m.subject, m.score
FROM Students s
JOIN Marks m ON s.student_id = m.student_id
WHERE m.score = (SELECT MAX(score) FROM Marks);

-- students with the ame course id as that of saksham
EXPLAIN SELECT *
FROM Students s
WHERE s.course_id = (
    SELECT course_id 
    FROM Students 
    WHERE name = 'Saksham'
);

-- union
SELECT course_name 
FROM Courses
UNION
SELECT subject
FROM Marks;

SELECT course_name
FROM Courses
UNION ALL
SELECT subject
FROM Marks;

select * from Marks;




-- delete flow whether from child or parent, examples of before and after triggers
-- assignment 8

use StudentDB;


-- deone only if its not already a primary key
-- ALTER TABLE Students
-- ADD PRIMARY KEY (student_id);

-- adding index on email column
CREATE INDEX idx_students_email ON Students(email);

SELECT * FROM Students WHERE email = 'neha@hotmail.com';

EXPLAIN SELECT * FROM Students WHERE email = 'abc@example.com';

select * from Students;

EXPLAIN SELECT * FROM Students WHERE student_id = 9;


-- stored procedure - simple one with no input output
-- gets all students
DELIMITER //

CREATE PROCEDURE GetAllStudents()
BEGIN
    SELECT * FROM Students;
END //

DELIMITER ;

CALL GetAllStudents();


-- gts all courses
DELIMITER //

CREATE PROCEDURE GetAllCourses()
BEGIN
    SELECT * FROM Courses;
END //

DELIMITER ;

CALL GetAllCourses();

-- cursor, temporary table
-- gets male studenets
DELIMITER //

CREATE PROCEDURE GetMaleStudents()
BEGIN
    SELECT * FROM Students WHERE gender = 'Male';
END //

DELIMITER ;

CALL GetMaleStudents();


DROP FUNCTION IF EXISTS GetGrade;

DELIMITER //


CREATE FUNCTION GetGrade(score INT)
RETURNS VARCHAR(2)

BEGIN
    RETURN CASE 
        WHEN score >= 90 THEN 'A'
        WHEN score >= 80 THEN 'B'
        WHEN score >= 70 THEN 'C'
        WHEN score >= 60 THEN 'D'
        ELSE 'F'
    END;
END //

DELIMITER ;

SET GLOBAL log_bin_trust_function_creators = 1;

SELECT student_id, score, GetGrade(score) AS grade
FROM Marks;


SELECT GetGrade(87);




-- all students having A grade

DELIMITER //

CREATE PROCEDURE GetAStudents()
BEGIN
    SELECT s.student_id, s.name, s.age, s.gender, s.email, m.score, GetGrade(m.score) AS grade
    FROM Students s
    JOIN Marks m ON s.student_id = m.student_id
    WHERE GetGrade(m.score) = 'A';
END //

DELIMITER ;

call GetAStudents();


-- Checkimg database collation
SELECT SCHEMA_NAME, DEFAULT_CHARACTER_SET_NAME, DEFAULT_COLLATION_NAME
FROM information_schema.SCHEMATA
WHERE SCHEMA_NAME = 'StudentDB';
-- utf8mb4_0900_ai_ci which means , accent insensitive and case insensitive




-- checking table collation
SHOW TABLE STATUS WHERE Name = 'Students';
-- utf8mb4_0900_ai_ci which means , accent insensitive and case insensitive


-- triggers

CREATE TABLE IF NOT EXISTS DeletedStudents (
    student_id INT,
    name VARCHAR(100),
    age INT,
    gender VARCHAR(10),
    course_id INT,
    email VARCHAR(100),
    deleted_at DATETIME
);

DELIMITER //

CREATE TRIGGER LogDeletedStudent
BEFORE DELETE ON Students
FOR EACH ROW
BEGIN
    INSERT INTO DeletedStudents (student_id, name, age, gender, course_id, email, deleted_at)
    VALUES (OLD.student_id, OLD.name, OLD.age, OLD.gender, OLD.course_id, OLD.email, NOW());
END //

DELIMITER ;




-- delete a student's record
DELETE FROM Students WHERE student_id = 10;

-- Check DeletedStudents table
SELECT * FROM DeletedStudents;



-- delete a student's record
DELETE FROM Students WHERE student_id = 9;

-- Check DeletedStudents table
SELECT * FROM DeletedStudents;
