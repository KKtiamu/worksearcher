USE [workSearсher]
GO

DROP PROCEDURE dbo.SelectSmeny;  
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create  PROCEDURE dbo.SelectSmeny
@smeny INT                          

AS
BEGIN
if @smeny=0
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[smeny] order by name
END
else
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[smeny] where id = @smeny
 END
END
GO