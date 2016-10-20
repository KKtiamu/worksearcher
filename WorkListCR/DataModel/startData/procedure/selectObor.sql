USE [workSearсher]
GO

DROP PROCEDURE dbo.SelectObor;  
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create  PROCEDURE dbo.SelectObor
@obor INT                          

AS
BEGIN
if @obor=0
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[obor] order by name
END
else
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[obor] where id = @obor
 END
END
GO