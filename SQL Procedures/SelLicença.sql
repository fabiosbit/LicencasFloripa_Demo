USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[SelLicença]    Script Date: 18/03/2021 17:42:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROC [dbo].[SelLicença]
@Pesquisa nvarchar(200)

AS
SELECT TOP 1 * FROM Equipamentos WHERE ContraSenha like @Pesquisa or ValorDongle like @Pesquisa or Licença like @Pesquisa or SN like @Pesquisa or Cliente like @Pesquisa 
ORDER BY DataRegistro DESC
