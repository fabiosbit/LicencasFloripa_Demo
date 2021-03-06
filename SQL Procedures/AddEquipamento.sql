USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[AddEquipamento]    Script Date: 18/03/2021 17:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROC [dbo].[AddEquipamento]
@Cliente nvarchar(100),
@Contato nvarchar(50),
@Email nvarchar(50),
@Produto nvarchar(50),
@SN nvarchar(50),
@ValorDongle nvarchar(9),
@ContraSenha nvarchar(17),
@Licença nvarchar(33),
@Tipo nvarchar(20),
@DataRegistro date,
@NomeComputador nvarchar(50),
@Placa nvarchar(50),
@FloripaSec nvarchar(20),
@MacAddress nvarchar(30),
@Funcionário nvarchar(20),
@Observações nvarchar(255),
@Negócio nvarchar(8),
@DataLicença date

AS
	INSERT INTO Equipamentos(Cliente,Contato,Email,Produto,SN,ValorDongle,ContraSenha,Licença,Tipo,DataRegistro,NomeComputador,Placa,FloripaSec,MacAddress,Funcionário,Observações,Negócio,DataLicença)
	VALUES (@Cliente,@Contato,@Email,@Produto,@SN,@ValorDongle,@ContraSenha,@Licença,@Tipo,@DataRegistro,@NomeComputador,@Placa,@FloripaSec,@MacAddress,@Funcionário,@Observações,@Negócio,@DataLicença)
