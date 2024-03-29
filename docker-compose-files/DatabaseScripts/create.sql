﻿CREATE DATABASE TEMPLATE;
GO;
CREATE TABLE USUARIO (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(255) NOT NULL,
	CREATION_USER VARCHAR(255) NOT NULL,
	CREATION_DATE DATETIME NOT NULL,
	MODIFIED_USER VARCHAR(255) NOT NULL,
	MODIFIED_DATE DATETIME NOT NULL,
	ACTIVE CHAR(1) DEFAULT 'A'
);
GO;
CREATE TABLE EXCEPTION_LOGS (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	STATUS_CODE INT NOT NULL,
	TRACE_ID VARCHAR(255) NOT NULL,
	MESSAGE VARCHAR(255) NOT NULL,
	SOURCE VARCHAR(255) NOT NULL,
	STACK_TRACE VARCHAR(MAX) NOT NULL,
	INNER_EXCEPTION VARCHAR(MAX) NULL,
	ERROR_TIME DATETIME NOT NULL
);