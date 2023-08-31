/*question 3*/
select empid, (sales - salary) as revenue, salary as old_salary, salary + (sales - salary) as salary_adjustment from workshop where sales-salary < 0;