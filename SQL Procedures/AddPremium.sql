USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[AddPremium]    Script Date: 18/03/2021 17:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROC [dbo].[AddPremium]
@Cliente nvarchar(100),
@CTO nvarchar(50),
@NFPS nvarchar(50),
@Produto nvarchar(350),
@SN nvarchar(350),
@DataRegistro date,
@Observações nvarchar(250),
@VencCTO nvarchar(50),
@Proposta nvarchar(50),
@Ativo int
AS
	INSERT INTO Premium(Cliente,CTO,NFPS,Produto,SN,DataRegistro,Observações,VencCTO,Proposta,Ativo)
	VALUES (@Cliente,@CTO,@NFPS,@Produto,@SN,@DataRegistro,@Observações,@VencCTO,@Proposta,@Ativo)
