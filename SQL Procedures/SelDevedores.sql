USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[SelDevedores]    Script Date: 18/03/2021 17:42:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROC [dbo].[SelDevedores]

AS
SELECT * FROM Devedores 
ORDER BY Cliente
