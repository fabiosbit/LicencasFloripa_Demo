USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[SelGeralLicenças]    Script Date: 18/03/2021 17:42:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROC [dbo].[SelGeralLicenças]
@Pesquisa nvarchar(200)

AS
SELECT * FROM Equipamentos WHERE Cliente like @Pesquisa or Contato like @Pesquisa or Email like @Pesquisa or ContraSenha like @Pesquisa or ValorDongle like @Pesquisa 
or Licença like @Pesquisa or DataRegistro like @Pesquisa or Tipo like @Pesquisa or Funcionário like @Pesquisa or FloripaSec like @Pesquisa or Observações like @Pesquisa 
or SN like @Pesquisa or Produto like @Pesquisa or NomeComputador like @Pesquisa or MacAddress like @Pesquisa or Placa like @Pesquisa 
ORDER BY Cliente
