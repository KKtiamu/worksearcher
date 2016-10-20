USE [workSearсher]
GO

DROP PROCEDURE dbo.SelectProfByObor;  
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create  PROCEDURE dbo.SelectProfByObor
@obor INT                          

AS
BEGIN
if @obor>0
 BEGIN
   SELECT id,name FROM [workSearсher].[dbo].[prof] where idObor = @obor
 END
END
GO