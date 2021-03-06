USE [LicençasDB_teste]
GO
/****** Object:  StoredProcedure [dbo].[ExportaPremium]    Script Date: 18/03/2021 17:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[ExportaPremium]  
AS
BEGIN
SET NOCOUNT ON;

exec sp_configure 'show advanced options', 1;
RECONFIGURE;
exec sp_configure 'xp_cmdshell', 1;
RECONFIGURE;

--delete existing file
exec master..xp_cmdshell 'del C:\Premium\Premium.xlsx' 

--create new file from blank template
exec master..xp_cmdshell 'copy C:\Modelo.xlsx C:\Premium\Premium.xlsx' 

INSERT INTO OPENDATASOURCE('Microsoft.ACE.OLEDB.12.0','Data Source=C:\Premium\Premium.xlsx;Extended properties=Excel 8.0')...Plan1$
SELECT * FROM Premium where Ativo = 1

exec sp_configure 'xp_cmdshell', 0;
RECONFIGURE;
exec sp_configure 'show advanced options', 0;
RECONFIGURE;

END
