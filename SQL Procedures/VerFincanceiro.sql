USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[VerFinanceiro]    Script Date: 18/03/2021 17:42:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROC [dbo].[VerFinanceiro]
@SN nvarchar(350),
@DTGAR nvarchar(10) = ' ' output,
@DBTOS nvarchar(10) = ' ' output,
@ChkPremium nvarchar(10) = ' ' output,
@Ativo int = ' ' output

AS

SET @DBTOS = (SELECT TOP 1 SN FROM Devedores WHERE SN LIKE @SN)
IF(@DBTOS IS NOT NULL)
	SET @DBTOS = 1

ELSE
BEGIN
	SET @DBTOS = 0
	SET @DTGAR = (select TOP 1 AA3_DTGAR from [PROTHEUS_TESTE].[dbo].[AA3010] where AA3_NUMSER like @SN)
	SET @ChkPremium = (select TOP 1 VencCTO from Premium where SN like @SN)
	SET @Ativo = (select TOP 1 Ativo from Premium where SN like @SN)

	IF (@ChkPremium IS NULL)
		SET @ChkPremium = '0'
	
	IF (@DTGAR IS NULL)
		SET @DTGAR = 0
END

