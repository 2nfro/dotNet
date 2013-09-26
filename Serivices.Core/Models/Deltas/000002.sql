USE [nfro]
CREATE TABLE tbApp(
	AppId INT PRIMARY KEY IDENTITY(1,1),
	AppName VARCHAR(255) NOT NULL UNIQUE,
	Active BIT DEFAULT 1
)

CREATE TABLE tbAppSettings(
	AppSettingsId INT PRIMARY KEY IDENTITY(1,1),
	AppId INT FOREIGN KEY REFERENCES tbApp(AppId),
	SettingName VARCHAR(255) NOT NULL,
	CONSTRAINT appSettingsIndex UNIQUE(AppId, SettingsName)
)

CREATE TABLE tbUserApp(
	UserAppId INT PRIMARY KEY IDENTITY(1,1),
	AppId INT FOREIGN KEY REFERENCES tbApp(AppId),
	UserId INT FOREIGN KEY REFERENCES tbUser(UserId),
)

CREATE TABLE tbAppToken(
	AppTokenId INT PRIMARY KEY IDENTITY(1,1),
	UserAppId INT FOREIGN KEY REFERENCES tbUserApp(UserAppId),
	TokenType VARCHAR(255) NOT NULL,
	TokenValue VARCHAR(255) NOT NULL,
	CONSTRAINT appTokenUserIndex UNIQUE(UserAppId, TokenType)
)

CREATE TABLE tbUserAppSettings(
	AppUserSettingsId INT PRIMARY KEY IDENTITY(1,1),
	UserAppId INT FOREIGN KEY REFERENCES tbUserApp(UserAppId),
	AppSettingsId INT NOT NULL FOREIGN KEY REFERENCES tbAppSettings(AppSettingsId),
	SettingsValue VARCHAR,
	CONSTRAINT userToAppSettingIndex UNIQUE(UserAppId, AppSettingsId)
)

INSERT INTO tbApp (AppName)
VALUES ('Google Plus'), ('Twitter'), ('Instagram');
