USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEquipamento]    Script Date: 18/03/2021 17:42:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





ALTER PROC [dbo].[UpdateEquipamento]
@Cliente nvarchar(100),
@Contato nvarchar(50),
@Email nvarchar(50),
@Produto nvarchar(20),
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

update Equipamentos SET 
Cliente=@Cliente,
Contato=@Contato,
Email=@Email,
Produto=@Produto,
SN=@SN,
ValorDongle=@ValorDongle,
ContraSenha=@ContraSenha,
Licença=@Licença,
Tipo=@Tipo,
DataRegistro=@DataRegistro,
NomeComputador=@NomeComputador,
Placa=@Placa,
FloripaSec=@FloripaSec,
MacAddress=@MacAddress,
Funcionário=@Funcionário,
Observações=@Observações,
Negócio=@Negócio,
DataLicença=@DataLicença

WHERE ContraSenha=@ContraSenha

