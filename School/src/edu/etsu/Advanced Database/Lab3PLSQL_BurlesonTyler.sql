SET SERVEROUTPUT ON;
DECLARE
CURSOR Emp_Cursor IS
select FIRST_NAME, LAST_NAME, SALARY 
from employees;
employee_rec Emp_Cursor%ROWTYPE;
--Create Cursor to hold employee fname, lnama, and salary
BEGIN
OPEN Emp_Cursor;

LOOP
    FETCH Emp_Cursor INTO employee_rec;
    EXIT WHEN Emp_Cursor%NOTFOUND;
    IF employee_rec.SALARY < 5000 THEN
    dbms_output.put_line(employee_rec.FIRST_NAME || ' ' || employee_rec.LAST_NAME || '-PROMOTION LEVEL 1');
    ELSIF employee_rec.SALARY > 5000 and employee_rec.SALARY < 10000 THEN
    dbms_output.put_line(employee_rec.FIRST_NAME || ' ' || employee_rec.LAST_NAME || '-PROMOTION LEVEL 2');
    ELSE
    dbms_output.put_line(employee_rec.FIRST_NAME || ' ' || employee_rec.LAST_NAME || '-PROMOTION LEVEL 3');
    END IF;
END LOOP;
CLOSE Emp_Cursor;
-- fill cursor
-- if salary < 5000 promo lvl 1
-- if sal < 10000 promo lvl 2 
-- sal > 10000 promo lv 3
EXCEPTION
WHEN others THEN
dbms_output.put_line('Something failed in this block');
-- exception something went wrong

END;