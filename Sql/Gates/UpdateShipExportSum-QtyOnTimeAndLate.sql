update shipexportsum set 
QtyShippedOnTime = (select  COALESCE(Sum(QtyShipped),0) from ShipExport s where  s.OrderNum=shipexportsum.OrderNum and s.Item = shipexportsum.Item and s.ReleaseBase=shipexportsum.Release and DATEDIFF(Day, ShipDate, DateRequest)  >= 0 ),
QtyShippedLate = (select  COALESCE(Sum(QtyShipped),0) from ShipExport s where  s.OrderNum=shipexportsum.OrderNum and s.Item = shipexportsum.Item and s.ReleaseBase=shipexportsum.Release and DATEDIFF(Day, ShipDate, DateRequest)  < 0)
where exists (select s.OrderNum from ShipExport s where  s.OrderNum=shipexportsum.OrderNum and s.Item = shipexportsum.Item and s.ReleaseBase=shipexportsum.Release)




select OrderNum, Item,Release,QtySHipped,ShipDate, DateRequest from ShipExport s where s.OrderNum=33698 and Item=1 and Release='FU1'
select OrderNum, Item,Release,s.QtyShippedOnTime,s.QtyShippedLate from ShipExportSum s where s.OrderNum=33698 and Item=1 and Release='FU1'