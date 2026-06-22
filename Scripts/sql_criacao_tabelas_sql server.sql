IF DB_ID ('HORTIFRUTI_DB') IS NULL
CREATE DATABASE hortifruti_db;

USE hortifruti_db;
SELECT * FROM information_schema.tables; --Mostra todas as tabelas do banco

CREATE TABLE Produto (
  idProduto INT NOT NULL IDENTITY,
  Nome VARCHAR(45) NULL,
  preço float,
  PRIMARY KEY(idProduto)
);

EXEC SP_RENAME 'Produto.Tipo',  'Tipo';

exec sp_RENAME 
          'Produto.Tipo',
          'Tipo';

SELECT * FROM Produto;

DELETE FROM PRODUTO;

DBCC CHECKIDENT('Produto', RESEED, 0); --resetando a contagem do identificador 

UPDATE produto SET nome = 'Pepino', tipo = 'Grande', preço = 1.25
WHERE idProduto = 1;

INSERT INTO produto
(Nome, Tipo, preço)
VALUES ('Carambola', 'Médio', 4.92);

INSERT INTO produto
(Nome, Tipo, preço)
VALUES ('Mandioquinha', 'Grande', 7.65);

SELECT * FROM Produto;

CREATE TABLE Cliente (
  Id_cliente INTEGER NOT NULL IDENTITY,
  Nome VARCHAR(45) NOT NULL,
  Endereco VARCHAR(50) NULL,
  Telefone VARCHAR(50) NULL,
  E_mail VARCHAR(60) NULL,
  PRIMARY KEY(Id_cliente)
);

DELETE FROM Cliente;
ALTER TABLE Cliente ALTER COLUMN Id_cliente INT NOT NULL;

SELECT * FROM Cliente;

CREATE TABLE Usuario (
   Nome varchar(45),
   Senha varchar(12),
   PRIMARY KEY(Nome)
);

EXEC SP_RENAME 'USUARIO',  'Usuario'; --Renomeando a tabela Usuario

INSERT INTO USUARIO VALUES ('admin', '359423');
UPDATE usuario
set Senha = '123'
WHERE Nome = 'admin';

SELECT * FROM USUARIO;

CREATE TABLE Compra (
  Id_compra INT NOT NULL IDENTITY,
  Data DATE NOT NULL,
  Nome_Produtor Varchar(40),
  Produto Varchar(30) NULL,
  Quantidade INT NULL,
  Valor_unitario FLOAT NULL,
  Valor_total FLOAT NOT NULL,
  Pagamento BIT not null,
  Data_Vencimento DATE NULL,
  Unidade VARCHAR(8) NULL,
  PRIMARY KEY(Id_compra)
);

EXEC sp_rename 'COMPRA.Pago', 'Pagamento';

INSERT INTO COMPRA VALUES (getdate(), 'Paulo', 'Alface', 3, 2.99, 8.97, 1);

SELECT * FROM Compra;

Delete from compra where Id_compra = 6;

CREATE TABLE Produtor (
  Id_produtor INT NOT NULL IDENTITY,
  Nome VARCHAR(45) NULL,
  Endereco VARCHAR(50) NULL,
  Telefone VARCHAR(11) NULL,
  PRIMARY KEY(Id_produtor)
);

ALTER TABLE Produtor
DROP COLUMN IdProduto;

ALTER TABLE Produtor
ADD E_mail Varchar(60);

SELECT * FROM PRODUTOR;

INSERT INTO Produtor VALUES ('Joao da Silva', 'Rua J, 112', '35999990102');

CREATE TABLE Vendas (
  Id_vendas INT NOT NULL IDENTITY,
  Nome_Produto VARCHAR(30) NOT NULL,
  Data DATE NOT NULL,
  Quantidade FLOAT NOT NULL,
  Unidade VARCHAR(8) NOT NULL,
  Preco_unitario FLOAT NULL,
  Preco_total FLOAT NOT NULL,
  Cliente VARCHAR(40) NOT NULL,
  Pagamento BIT NOT NULL,
  Data_Vencimento DATE NULL,
  Condicao VARCHAR(14) NULL,
  PRIMARY KEY(Id_vendas),
);

EXEC sp_rename 'Vendas.Produto', 'Nome_Produto';

ALTER TABLE Vendas
ADD Condicao VARCHAR(14) NULL;

SELECT * FROM Vendas;

EXEC sp_rename'Venda',  'Vendas'; --Renomeando a tabela vendas 

ALTER TABLE Vendas
ADD Cliente varchar(45);

ALTER TABLE Vendas
drop constraint fk_prodvendas; --Deletando a chave estrangeira

EXEC sp_rename 'Produto', 'NomeProduto';

ALTER TABLE Vendas
ADD Pago BIT NOT NULL;


INSERT INTO Vendas (Data, Quantidade, Preco_unitario, Preco_total, Cliente, NomeProduto, Pago)
VALUES ('2021-04-23', 2, 4.75, 9.50, 'André Valadão', 'Abóbora', 1);

SELECT * FROM Vendas;

Delete from Vendas where Id_vendas = 2009;

----------------------- SCRIPT CRIAÇÃO / ALTERAÇÃO TABELAS MYSQL: -----------------------------------------------


create database hortifruti_db;
USE hortifruti_db;

show tables;

CREATE TABLE CLIENTE (
  Id_cliente INT NOT NULL IDENTITY,
  Nome VARCHAR(45) NULL,
  Endereco VARCHAR(50) NULL,
  Telefone VARCHAR(50) NULL,
  PRIMARY KEY(Id_cliente)
);

ALTER TABLE cliente add e_mail varchar(40);
select * from cliente;


CREATE TABLE USUARIO (
   Nome varchar(45),
   Senha varchar(12),
   PRIMARY KEY(Nome)
);

ALTER TABLE USUARIO
change Senha senha varchar(12);

select * from usuario;

INSERT INTO cliente (Nome, Endereco, Telefone)
VALUES ('Edson', 'Rua José Apolinário de Andrade, 674', '35999022614');

select * from CLIENTE;

UPDATE usuario
SET senha = 123 where  nome ='admin';

CREATE TABLE Compra (
  Id_compra INT NOT NULL IDENTITY,
  Id_produtor INT NOT NULL,  
  Data_2 DATE NULL,
  Quantidade INT NOT NULL,
  Valor_unitario INT NULL,
  Valor_total INT NULL,
  PRIMARY KEY(Id_compra, Id_produtor),
  INDEX Compra_FKIndex1(CLIENTE_Id_cliente)
);

ALTER TABLE Compra
ADD Produto varchar(45);

ALTER TABLE COMPRA 
CHANGE CLIENTE_ID_CLIENTE COMPRA_ID_PRODUTOR INT;

ALTER TABLE Compra
DROP COMPRA_ID_PRODUTOR;

ALTER TABLE Compra
CHANGE Id_Produtor Nome_produtor varchar(45);

ALTER TABLE Compra
MODIFY Nome_produtor varchar(45);

SELECT * FROM Compra;

alter table Compra
modify Valor_total float;


select * from compra inner join produtor
on compra.id_produtor = produtor.id_produtor;

DELETE FROM COMPRA WHERE ID_COMPRA = 4;
alter table compra modify Data_2 date;

INSERT INTO COMPRA SET DATA_2 = STR_TO_DATE( "31/05/2014", "%m/%d/%Y" );

INSERT INTO usr_idusuario SET evn_dtevento = STR_TO_DATE( "31/05/2014", "%m/%d/%Y" )

CREATE TABLE Produtor (
  Id_produtor INT UNSIGNED NOT NULL IDENTITY,
  Nome VARCHAR(45) NULL,
  Endereco VARCHAR(50) NULL,
  Telefone VARCHAR(11) NULL,
  PRIMARY KEY(Id_produtor)
);
ALTER TABLE produtor add e_mail varchar(45);
ALTER TABLE produtor modify telefone varchar(13);
ALTER TABLE produtor add e_mail varchar(45);
ALTER TABLE produtor drop column IdProduto;

SELECT * FROM PRODUTOR;
 
 INSERT into Produtor (Nome, Endereco, Telefone)
 values ('Lucas Maganhoto de Carvalho Ferreira', 'Rua José Apolinário de Andrade, 674', '35999022614');
	
 SELECT * FROM COMPRA;
 
 CREATE TABLE Venda (
  Id_venda INT NOT NULL IDENTITY,
  Nome_produto INT NOT NULL,
  Data DATE NULL,
  Quantidade INT NULL,
  Preco_unitario FLOAT NULL,
  Preco_total FLOAT NULL,
  Nome_cliente varchar(45),
  PRIMARY KEY(Id_venda),
  INDEX Vendaa_FKIndex1(Nome_produto, Nome_cliente)
);

ALTER TABLE Venda
modify Nome_produto varchar(25); 

select * from venda;

INSERT INTO Venda (Nome_produto, Data, Quantidade, Preco_unitario, Preco_total, Nome_cliente)
VALUES ('Beterraba', '2021-03-04', 4, 3.99, 12.56, 'João da Silva');

CREATE TABLE Produto (
  idProduto INT NOT NULL IDENTITY,
  Nome VARCHAR(45) NULL,
  Tamanho VARCHAR(20) NULL,
  preço float,
  PRIMARY KEY(idProduto)
);

alter table produto change Tamanho tipo varchar(30);

select * from produto;
delete from produto where idproduto = 1;
select idProduto from produto where produto.nome = 'mandioquinha';

update produto set nome = 'pepino' where idProduto = 1;

INSERT INTO produto
(Nome, Tamanho, preço)
VALUES ('Pepino', 'Médio', 3.49);

INSERT INTO produto
(Nome, Tamanho, preço)
VALUES ('Mandioquinha', 'Grande', 7.65);


select * from compra;
alter table compra change data_2 data date;
