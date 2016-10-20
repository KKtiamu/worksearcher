USE [workSearсher]
GO
DROP PROCEDURE dbo.SelectVM;  
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create  PROCEDURE dbo.SelectVM
@VM INT                          

AS
BEGIN
if @VM=0
 BEGIN
   SELECT * FROM [workSearсher].[dbo].[VM] order by id
END
else
 BEGIN
   SELECT * FROM [workSearсher].[dbo].[VM] where id = @VM
 END
END
GO