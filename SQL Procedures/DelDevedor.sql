USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[DelDevedor]    Script Date: 18/03/2021 17:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROC [dbo].[DelDevedor]
@snR nvarchar(30)

AS
DELETE FROM Devedores WHERE SN = @snR
