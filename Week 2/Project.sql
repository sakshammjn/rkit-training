create database payroll_db;
use payroll_db;

create table Departments (
	dept_id INT PRIMARY KEY,
	dept_name VARCHAR(100)
);

create table Employees (
	emp_id INT PRIMARY KEY,
	name VARCHAR(100),
    dept_id INT,
    salary DECIMAL(10,2),
    FOREIGN KEY (dept_id) REFERENCES Departments(dept_id)
);

create table Salaries (
	emp_id INT,
	month VARCHAR(20),
    amount DECIMAL(10,2),
    FOREIGN KEY (emp_id) REFERENCES Employees(emp_id)
);

INSERT INTO Departments VALUES
(1, 'HR'),
(2, 'Engineering'),
(3, 'Sales');

INSERT INTO Employees VALUES
(1, 'Aman', 2, 60000),
(2, 'Saksham', 2, 75000),
(3, 'Priya', 3, 50000),
(4, 'Rohit', 1, 45000);

INSERT INTO Salaries VALUES
(1, 'Jan', 60000),
(1, 'Feb', 60000),
(2, 'Jan', 75000),
(2, 'Feb', 75000),
(3, 'Jan', 50000),
(4, 'Jan', 45000);

select * from Departments;
select * from Employees;
select * from Salaries;

SELECT e.emp_id, e.name, d.dept_name, s.month, s.amount
FROM Employees e
JOIN Departments d ON e.dept_id = d.dept_id
JOIN Salaries s ON e.emp_id = s.emp_id;

SELECT name, dept_id, salary
FROM Employees e
WHERE salary > (
    SELECT AVG(salary)
    FROM Employees
    WHERE dept_id = e.dept_id
);


DELIMITER //

CREATE PROCEDURE GetYearlySalary()
BEGIN
    SELECT e.emp_id, e.name, SUM(s.amount) AS yearly_salary
    FROM Employees e
    JOIN Salaries s ON e.emp_id = s.emp_id
    GROUP BY e.emp_id, e.name;
END //

DELIMITER ;

CALL GetYearlySalary();


CREATE TABLE SalaryLog (
    log_id INT AUTO_INCREMENT PRIMARY KEY,
    emp_id INT,
    month VARCHAR(20),
    amount DECIMAL(10,2),
    log_time TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

DELIMITER //

CREATE TRIGGER after_salary_insert
AFTER INSERT ON Salaries
FOR EACH ROW
BEGIN
    INSERT INTO SalaryLog (emp_id, month, amount)
    VALUES (NEW.emp_id, NEW.month, NEW.amount);
END //

DELIMITER ;

CREATE VIEW EmployeeSalarySummary AS
SELECT e.emp_id, e.name, d.dept_name, SUM(s.amount) AS total_salary
FROM Employees e
JOIN Departments d ON e.dept_id = d.dept_id
JOIN Salaries s ON e.emp_id = s.emp_id
GROUP BY e.emp_id, e.name, d.dept_name;

SELECT * FROM EmployeeSalarySummary;
