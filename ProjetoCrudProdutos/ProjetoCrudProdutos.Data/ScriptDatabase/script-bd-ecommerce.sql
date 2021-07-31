CREATE DATABASE ecommerce;

USE ecommerce;

CREATE TABLE produtos(
	Id bigint IDENTITY(1,1) NOT NULL,
	Nome nvarchar(100) NOT NULL,
	Estoque int NOT NULL,
	Valor decimal(10,2) NOT NULL,
	DataCadastro datetime NULL,
	DataAtualizacao datetime NULL,
	PRIMARY KEY (Id)
);

SELECT * FROM produtos;