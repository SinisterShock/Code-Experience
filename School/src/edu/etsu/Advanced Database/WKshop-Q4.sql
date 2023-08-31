/*question 4*/
select empid as employees_to_be_demoted from workshop where sales-salary < 0 and salary + (sales - salary) < 0;