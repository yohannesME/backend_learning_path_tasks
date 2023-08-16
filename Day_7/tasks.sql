-- Exercise 1 - 175. Combining Two Tables
SELECT firstName, lastName, city, state FROM Person
LEFT JOIN Address ON Address.PersonId = Person.PersonId;

-- Exercise - 2 - 595. Big Countries
SELECT name, population, area FROM World
WHERE area >= 3000000 OR population >= 25000000;

-- Exercise - 3 - 182. Duplicate Emails
SELECT Email FROM Person 
GROUP BY Email
HAVING COUNT(Email) > 1;


-- Exercise - 4 - 183. Customer who never orders
SELECT name as Customers FROM Customers
WHERE id NOT IN ( SELECT customerid FROM Orders );

-- Exercise - 5 - 181. Employees Earning More Than Their Managers
SELECT e1.name AS Employee 
FROM Employee e1
WHERE e1.salary > (SELECT e2.salary FROM Employee e2 WHERE e2.id = e1.managerId);

-- Exercise - 6 - 180. Consecutive Numbers
SELECT DISTINCT l1.num AS ConsecutiveNums
FROM Logs l1
INNER JOIN Logs l2 ON l1.id = l2.id - 1
INNER JOIN Logs l3 ON l1.id = l3.id - 2
WHERE l1.num = l2.num AND l1.num = l3.num;

-- ALTERNATIVE APPROACH
SELECT DISTINCT
    l1.Num AS ConsecutiveNums
FROM
    Logs l1,
    Logs l2,
    Logs l3
WHERE
    l1.Id = l2.Id - 1
    AND l2.Id = l3.Id - 1
    AND l1.Num = l2.Num
    AND l2.Num = l3.Num


-- Exercise 7 - 184. Department Highest Salary
# Write your MySQL query statement below
SELECT 
    DEPT.name AS Department, 
    EMP.name AS Employee, 
    EMP.salary AS Salary 
FROM 
    Department DEPT, Employee EMP 
WHERE
    EMP.departmentId = DEPT.id AND (EMP.departmentId, salary) 
    IN(
        SELECT departmentId, MAX(salary) FROM Employee GROUP BY departmentId
    )