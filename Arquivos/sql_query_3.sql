create database hortifruti_db;
USE hortifruti_db;

show tables;
CREATE TABLE CLIENTE (
  Id_cliente INTEGER NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(45) NULL,
  Endereco VARCHAR(50) NULL,
  Telefone VARCHAR(50) NULL,
  PRIMARY KEY(Id_cliente)
);

CREATE TABLE USUARIO (
   Nome varchar(45),
   Senha varchar(12),
   PRIMARY KEY(Nome)
);

select * from usuario;
select * from cliente;

INSERT INTO cliente (Nome, Endereco, Telefone)
VALUES ('Edson', 'Rua José Apolinário de Andrade, 674', '35999022614');

CREATE TABLE Compra (
  Id_compra INTEGER NOT NULL AUTO_INCREMENT,
  Id_produtor INTEGER NOT NULL,
  CLIENTE_Id_cliente INTEGER NOT NULL,
  Data_2 DATE NULL,
  Quantidade INTEGER NOT NULL,
  Valor_unitario INTEGER NULL,
  Valor_total INTEGER NULL,
  PRIMARY KEY(Id_compra, Id_produtor),
  INDEX Compra_FKIndex1(CLIENTE_Id_cliente)
);

ALTER TABLE COMPRA 
CHANGE CLIENTE_ID_CLIENTE COMPRA_ID_PRODUTOR INTEGER;

ALTER TABLE USUARIO
change Senha senha varchar(12);

SELECT * FROM Compra;
alter table Compra
modify Valor_total float;

INSERT INTO Compra (COMPRA_id_PRODUTOR, Data_2, Quantidade, Valor_unitario, Valor_total, id_produtor)
VALUES (3, '2021/01/08', 6, 7.32, 36.60, '3');

select * from compra inner join produtor
on compra.id_produtor = produtor.id_produtor;

DELETE FROM COMPRA WHERE ID_COMPRA = 4;
alter table compra modify Data_2 date;

INSERT INTO COMPRA SET DATA_2 = STR_TO_DATE( "31/05/2014", "%m/%d/%Y" );

INSERT INTO usr_idusuario SET evn_dtevento = STR_TO_DATE( "31/05/2014", "%m/%d/%Y" )

CREATE TABLE Produtor (
  Id_produtor INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(45) NULL,
  Endereco VARCHAR(50) NULL,
  Telefone VARCHAR(11) NULL,
  PRIMARY KEY(Id_produtor)
);
 SELECT * FROM PRODUTOR;
 
 INSERT into Produtor (Nome, Endereco, Telefone)
 values ('Lucas Maganhoto de Carvalho Ferreira', 'Rua José Apolinário de Andrade, 674', '35999022614');
	
 SELECT * FROM COMPRA;
 
 /* CREATE TABLE Produto_has_Vendas (
  Produto_idProduto INTEGER NOT NULL,
  Vendas_Codigo_produto INTEGER NOT NULL,
  Vendas_Id_vendas INTEGER NOT NULL,
  PRIMARY KEY(Produto_idProduto, Vendas_Codigo_produto, Vendas_Id_vendas),
  INDEX Produto_has_Vendas_FKIndex1(Produto_idProduto),
  INDEX Produto_has_Vendas_FKIndex2(Vendas_Id_vendas, Vendas_Codigo_produto)
);

select * FROM produto_has_Vendas; */

CREATE TABLE Vendas (
  Id_vendas INTEGER NOT NULL AUTO_INCREMENT,
  Codigo_produto INTEGER NOT NULL,
  Data_2 DATE NULL,
  Quantidade INTEGER NULL,
  Preco_unitario INTEGER NULL,
  Preco_total INTEGER NULL,
  PRIMARY KEY(Id_vendas, Codigo_produto)
);

SELECT * FROM VENDAS;

CREATE TABLE Produto (
  idProduto INTEGER NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(45) NULL,
  Tamanho VARCHAR(20) NULL,
  preço float,
  PRIMARY KEY(idProduto)
);

alter table produto change Tamanho tipo varchar(30);

select * from produto;

update produto set nome = 'pepi' where nome = 'pepino';

INSERT INTO produto
(Nome, Tamanho, preço)
VALUES ('Pepino', 'Médio', 3.49);

INSERT INTO produto
(Nome, Tamanho, preço)
VALUES ('Mandioquinha', 'Grande', 7.65); 


select * from compra;
alter table compra change data_2 data date;
