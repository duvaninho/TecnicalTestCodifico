use StoreSample;
select relations.CompanyName,
	sum(
		CASE
			WHEN relations.rn = 1 THEN relations.freight
			ELSE 0
		END
	) TotalFreight,
	Sum(relations.unitprice * relations.qty) TotalCostShipped,
	Sum(relations.qty) TotalItemsShipped
from (
		select shipper.companyname CompanyName,
			(
				ROW_NUMBER() OVER (
					PARTITION BY orders.orderid
					ORDER BY orders.orderid
				)
			) rn,
			orders.freight,
			orderDetails.unitprice,
			orderDetails.qty
		from StoreSample.Sales.Shippers shipper
			inner join Sales.Orders orders on orders.shipperid = shipper.shipperid
			inner join Sales.OrderDetails orderDetails on orderDetails.orderid = orders.orderid
	) as relations
group by relations.CompanyName
order by relations.CompanyName;