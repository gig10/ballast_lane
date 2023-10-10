CREATE DATABASE GameDatabase;
GO

USE GameDatabase;
GO

CREATE TABLE Users (Id INT IDENTITY(1,1) PRIMARY KEY,
					email varchar(100) not null unique,
					username varchar(50) not null,
					password_hash varchar(100) not null);

GO

CREATE TABLE Games (Id INT IDENTITY(1,1) PRIMARY KEY,
					title varchar(120) not null,
					description text,
					imageurl varchar(255));

GO