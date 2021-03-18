USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[UpdatePremium]    Script Date: 18/03/2021 17:42:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[UpdatePremium]
@Cliente nvarchar(100),
@CTO nvarchar(50),
@NFPS nvarchar(50),
@Produto nvarchar(350),
@SN nvarchar(350),
@DataRegistro date,
@Observações nvarchar(250),
@VencCTO nvarchar(50),
@Proposta nvarchar(50),
@Ativo int,
@IDp int
AS

update Premium SET 
Cliente=@Cliente,
CTO=@CTO,
NFPS=@NFPS,
Produto=@Produto,
SN=@SN,
DataRegistro=@DataRegistro,
Observações=@Observações,
VencCTO=@VencCTO,
Proposta=@Proposta,
Ativo=@Ativo

WHERE ID=@IDp
