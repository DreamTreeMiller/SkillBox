USE MyDB;

SELECT MainID, [ClientType], [Name], [Telephone], [Email], [Address]
FROM	(SELECT
			 Clients.id AS MainID,
			 'VIP' AS [ClientType],
			 FirstName + ' ' + LastName AS [Name],
			 [Telephone],
			 [Email],
			 [Address]
		FROM	VIPclients, Clients
		WHERE	Clients.id = VIPclients.id 
		) AS vip
UNION SELECT
		Clients.id AS MainID,
		'Simple' AS [ClientType],
		FirstName + ' ' + LastName AS [Name],
		[Telephone],
		[Email],
		[Address]
FROM	SIMclients, Clients
WHERE	Clients.id = SIMclients.id
UNION SELECT
		Clients.id AS MainID,
		'Organization' AS [ClientType],
		OrgName AS [Name],
		[Telephone],
		[Email],
		[Address]
FROM	ORGclients, Clients
WHERE	Clients.id = ORGclients.id
ORDER BY [ClientType] DESC


