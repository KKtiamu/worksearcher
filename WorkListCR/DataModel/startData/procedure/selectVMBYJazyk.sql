USE [workSearсher]
GO

DROP PROCEDURE dbo.SelectVMByJazyk;  
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create  PROCEDURE dbo.SelectVMByJazyk
@jazyk INT                          

AS
BEGIN
if @jazyk>0
 BEGIN
   SELECT idVM FROM [workSearсher].[dbo].[relVmJazyk] where idJazyk = @jazyk
 END
END
GO