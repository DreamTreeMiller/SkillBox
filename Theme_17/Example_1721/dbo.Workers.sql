CREATE TABLE [dbo].[Workers] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [workerName]    NVARCHAR (50) NOT NULL,
    [idBoss]        INT           NOT NULL,
    [idDescription] INT           NOT NULL
);