USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[SelGeralPremium]    Script Date: 18/03/2021 17:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROC [dbo].[SelGeralPremium]
@Pesquisa nvarchar(350)

AS
SELECT Cliente,Proposta,CTO,DataRegistro,VencCTO,Produto,SN,NFPS,Observações,ID FROM Premium 
WHERE Cliente like @Pesquisa or Proposta like @Pesquisa or CTO like @Pesquisa or SN like @Pesquisa or Observações like @Pesquisa or Produto like @Pesquisa or NFPS like @Pesquisa 
ORDER BY Cliente
