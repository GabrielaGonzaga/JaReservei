CREATE DATABASE Senai_Ofertas

USE Senai_Ofertas

CREATE TABLE Produto
(
	IdProduto			INT PRIMARY KEY IDENTITY
	,IdTipoProduto		INT FOREIGN KEY REFERENCES TipoProduto (IdTipoProduto)
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
	,NomeProduto		VARCHAR (200) NOT NULL
	,LinkProduto		VARCHAR (1000) NOT NULL
	,ImagemProduto		VARCHAR (1000) NOT NULL
	,Descricao			VARCHAR (300) NOT NULL
	,Quantidade			INT NOT NULL
	,Preco				INT NOT NULL
);



CREATE TABLE TipoProduto
(
	IdTipoProduto		INT PRIMARY KEY IDENTITY
	,NomeTipoProduto	VARCHAR (200) NOT NULL
);

CREATE TABLE Usuario
(
	IdUsuario			INT PRIMARY KEY IDENTITY
	,Nome				VARCHAR (200) NOT NULL
	,Senha				VARCHAR (200) NOT NULL
	,Email				VARCHAR (200) NOT NULL
	,Telefone			DECIMAL	(13)  NOT NULL
	,CPF				DECIMAL	(11)
	,CNPJ				DECIMAL	(14)
);


CREATE TABLE Reserva
(
	IdReserva			INT PRIMARY KEY IDENTITY
	,IdProduto			INT FOREIGN KEY REFERENCES Produto (IdProduto)
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
	,Quantidade			INT		NOT NULL
	,PrecoTotal			FLOAT	NOT NULL
);