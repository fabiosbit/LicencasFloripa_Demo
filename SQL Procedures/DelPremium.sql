USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[DelPremium]    Script Date: 18/03/2021 17:41:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROC [dbo].[DelPremium]
@drID nvarchar(30)

AS
DELETE FROM Premium WHERE ID = @drID
