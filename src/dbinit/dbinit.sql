CREATE DATABASE GameDatabase;
GO

USE GameDatabase;
GO

CREATE TABLE Users (Id INT IDENTITY(1,1) PRIMARY KEY,
					email varchar(100) not null unique,
					username varchar(100) not null,
					password_hash varchar(255) not null);

GO