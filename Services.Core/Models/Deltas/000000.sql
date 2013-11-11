USE [master]

IF EXISTS(
	SELECT * FROM sys.databases
	WHERE name = N'nfro'
)
BEGIN
	DROP DATABASE [nfro]
END

CREATE DATABASE [nfro]