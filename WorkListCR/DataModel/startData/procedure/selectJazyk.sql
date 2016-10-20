USE [workSearсher]
GO

DROP PROCEDURE dbo.SelectJazyk;  
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create  PROCEDURE dbo.SelectJazyk
@jazyk INT                          

AS
BEGIN
if @jazyk=0
 BEGIN
   SELECT id,name,uroven FROM [workSearсher].[dbo].[jazyk] order by name
END
else
 BEGIN
   SELECT id,name,uroven FROM [workSearсher].[dbo].[jazyk] where id = @jazyk
 END
END
GO