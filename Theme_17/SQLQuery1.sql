SELECT 
Workers.id as 'ID',
Workers.workerName as 'Имя сотрудника',
Bosses.workerName as 'Имя начальника',
Bosses.departmentName as 'Имя отдела',
[Description].[value] as 'Замечание'
FROM Bosses, [Description],Workers
WHERE Workers.idBoss = Bosses.id and Workers.idDescription = [Description].id
