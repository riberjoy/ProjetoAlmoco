--CREATE DATABASE [db_ProjetoAlmoco]

USE db_ProjetoAlmoco

CREATE TABLE Cliente(
	Num_IDCliente	int				identity,
	Nom_Cliente		varchar(150)	NOT NULL,
	Nom_Usuario		varchar(10)		NOT NULL unique,
	Num_Senha		varchar(20)		NOT NULL

	CONSTRAINT PK_Num_IDCliente PRIMARY KEY (Num_IDCliente)
)


CREATE TABLE Categoria(
	Num_IDCategoria		int				identity,
	Nom_Categoria		varchar(150)	NOT NULL

	CONSTRAINT PK_Num_IDCategoria PRIMARY KEY (Num_IDCategoria)
)


CREATE TABLE Alimento(
	Num_IDAlimento		int				identity,
	Nom_Alimento		varchar(150)	NOT NULL,
	Num_IDCategoria		int				NOT NULL,
	Ind_Ativo			char(1)			NOT NULL

	CONSTRAINT PK_Num_IDAlimento PRIMARY KEY (Num_IDAlimento),
	CONSTRAINT FK_Num_IDCategoria FOREIGN KEY (Num_IDCategoria) REFERENCES Categoria(Num_IDCategoria) ON DELETE CASCADE
)


CREATE TABLE Pedido(
	Num_IDPedido		int		identity,
	Dat_DataPedido		date	NOT NULL,
	Num_IDCliente		int		NOT NULL,
	Num_IDAlimento		int		NOT NULL

	CONSTRAINT PK_Num_IDPedido PRIMARY KEY (Num_IDPedido),
	CONSTRAINT FK_Num_IDCliente FOREIGN KEY (Num_IDCliente) REFERENCES Cliente(Num_IDCliente) ON DELETE CASCADE,
	CONSTRAINT FK_Num_IDAlimento FOREIGN KEY (Num_IDAlimento) REFERENCES Alimento(Num_IDAlimento) ON DELETE CASCADE
)
