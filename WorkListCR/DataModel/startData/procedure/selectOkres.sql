USE [workSearсher]
GO

DROP PROCEDURE dbo.SelectOkres;  
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create  PROCEDURE dbo.SelectOkres
@okres INT                          

AS
BEGIN
if @okres=0
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[okres] order by name
END
else
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[okres] where id = @okres
 END
END
GO