USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[SelPremium]    Script Date: 18/03/2021 17:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROC [dbo].[SelPremium]
@Pesquisa nvarchar(200)

AS
SELECT TOP 1 * FROM Premium WHERE Cliente like @Pesquisa or Proposta like @Pesquisa or CTO like @Pesquisa or SN like @Pesquisa or Observações like @Pesquisa 
ORDER BY DataRegistro DESC
