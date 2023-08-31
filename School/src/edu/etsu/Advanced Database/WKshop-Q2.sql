/*question 2*/
select empid, (sales - salary) as revenue, (sales-salary)*.1 as promotion_amount, (sales-salary)*1.1 as promotion_total from workshop where sales-salary > 0;

