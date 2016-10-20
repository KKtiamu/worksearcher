USE [workSearсher]
GO

DROP PROCEDURE dbo.SelectVzdelani;  
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create  PROCEDURE dbo.SelectVzdelani
@vzdelani INT                          

AS
BEGIN
if @vzdelani=0
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[vzdelan] order by name
END
else
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[vzdelan] where id = @vzdelani
 END
END
GO