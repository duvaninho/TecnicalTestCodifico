use StoreSample;
select customers.companyname CompanyName,
	MAX(orders.orderdate) LastOrderDate,
	dateadd(
		DAY,
		DATEDIFF(Day, MIN(orders.orderdate), MAX(orders.orderdate)) / COUNT(*),
		MAX(orders.orderdate)
	) NextPredictedOrder
from Sales.Orders orders
	inner join Sales.Customers customers on orders.custid = customers.custid
group by customers.companyname;