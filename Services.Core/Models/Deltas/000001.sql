﻿USE [nfro]
CREATE TABLE tbUser(
	UserId INT PRIMARY KEY IDENTITY(1,1),
	Email VARCHAR(255) NOT NULL UNIQUE,
	PW VARCHAR(255) NOT NULL,
	Name VARCHAR(255) NOT NULL,
	Active BIT NOT NULL,
)

CREATE TABLE tbUserCode(
	UserCodeId INT PRIMARY KEY IDENTITY(1,1),
	UserId INT NOT NULL UNIQUE FOREIGN KEY REFERENCES tbUser(UserId),
	UserCode VARCHAR(255) NOT NULL,
	DateExpires DATETIME NOT NULL,
	Attempts INT NOT NULL,
)

CREATE TABLE tbDevice(
	DeviceId INT PRIMARY KEY,
	DeviceName VARCHAR(100) NOT NULL
)

INSERT INTO tbDevice (DeviceId, DeviceName)
VALUES (0, 'None'), (1, 'Web'), (2, 'Desktop'), (3, 'iPhone'), (4, 'Android'), (5, 'Windows');

CREATE TABLE [tbToken](
	TokenId INT PRIMARY KEY IDENTITY(1,1),
	UserId INT NOT NULL FOREIGN KEY REFERENCES tbUser(UserId),
	Token VARCHAR(255) NOT NULL UNIQUE,
	DateCreated DATETIME NOT NULL,
	DateExpires DATETIME NOT NULL,
	DeviceId INT DEFAULT 0 FOREIGN KEY REFERENCES tbDevice(DeviceId),
	CONSTRAINT userDeviceTokenIndex UNIQUE(UserId, DeviceId)
)