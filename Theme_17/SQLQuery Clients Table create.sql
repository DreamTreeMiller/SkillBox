USE GoodBank;

CREATE TABLE [dbo].[Clients] (
	[ID]		INT				IDENTITY (1, 1) NOT NULL,						
	[Telephone]	NVARCHAR (30),	
	[Email]		NVARCHAR (128),
	[Address]	NVARCHAR (256),
	
	[NumberOfCurrentAccounts]	INT	NOT NULL,
	[NumberOfDeposits]			INT	NOT NULL,		
	[NumberOfCredits]			INT	NOT NULL,			
	[NumberOfClosedAccounts]	INT	NOT NULL	
);

CREATE TABLE [dbo].[VIPclients] (
	[id]				INT				NOT NULL,
	[FirstName]			NVARCHAR (50)	NOT NULL,
	[MiddleName]		NVARCHAR (50)	NOT NULL,
	[LastName]			NVARCHAR (50)	NOT NULL,
	[PassportNumber]	NVARCHAR (11)	NOT NULL,
	[BirthDate]			DATE			NOT NULL
);

CREATE TABLE [dbo].[SIMclients] (
	[id]				INT				NOT NULL,
	[FirstName]			NVARCHAR (50)	NOT NULL,
	[MiddleName]		NVARCHAR (50)	NOT NULL,
	[LastName]			NVARCHAR (50)	NOT NULL,
	[PassportNumber]	NVARCHAR (11)	NOT NULL,
	[BirthDate]			DATE			NOT NULL
);

CREATE TABLE [dbo].[ORGclients] (
	[id]				INT				NOT NULL,
	[OrgName]			NVARCHAR (256)	NOT NULL,
	[DirectorFirstName]	NVARCHAR (50),
	[DirectorMiddleName]NVARCHAR (50),
	[DirectorLastName]	NVARCHAR (50),
	[TIN]				NVARCHAR (10)	NOT NULL,
	[RegistrationDate]	DATE			NOT NULL
);



