USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[AddDevedor]    Script Date: 18/03/2021 17:41:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




ALTER PROC [dbo].[AddDevedor]
@Cliente nvarchar(150),
@Fantasia nvarchar(150),
@Código nvarchar(10),
@Nota nvarchar(10),
@SN nvarchar(30),
@Produto nvarchar(150),
@DataRegistro date

AS
	INSERT INTO Devedores(Cliente,Fantasia,Código,Nota,SN,Produto,DataRegistro)
	VALUES (@Cliente,@Fantasia,@Código,@Nota,@SN,@Produto,@DataRegistro)
