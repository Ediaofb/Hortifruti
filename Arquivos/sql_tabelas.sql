CREATE TABLE CLIENTE (
  Id_cliente INTEGER NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(45) NULL,
  Endereco VARCHAR(50) NULL,
  Telefone VARCHAR(50) NULL,
  PRIMARY KEY(Id_cliente)
);
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
alter table Compra
modify Valor_total float;

INSERT INTO Compra (Cliente_id_cliente, Data_2, Quantidade, Valor_unitario, Valor_total, id_produtor)
VALUES (2, Data_2 = str_to_date('22/09/1996', "%d%m%Y"), 5, 7.32, 36.60, '2');

CREATE TABLE Produto (
  idProduto INTEGER NOT NULL AUTO_INCREMENT,
  Compra_Id_produtor INTEGER NOT NULL,
  Compra_Id_compra INTEGER NOT NULL,
  Produtor_Id_produto INTEGER UNSIGNED NOT NULL,
  Nome VARCHAR(45) NULL,
  Tamanho VARCHAR(20) NULL,
  PRIMARY KEY(idProduto),
  INDEX Produto_FKIndex1(Produtor_Id_produto),
  INDEX Produto_FKIndex2(Compra_Id_compra, Compra_Id_produtor)
);
ALTER TABLE produto MODIFY nome varchar(45) NOT NULL;
ALTER TABLE produto MODIFY Tamanho varchar(20) NOT NULL;

CREATE TABLE Produtor (
  Id_produtor INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(45) NULL,
  Endereco VARCHAR(50) NULL,
  Telefone VARCHAR(11) NULL,
  PRIMARY KEY(Id_produtor)
);
INSERT into Produtor (Nome, Endereco, Telefone)
 values ('Daniel Maganhoto de Carvalho Ferreira', 'Rua José Apolinário de Andrade, 674', '35999979570');

CREATE TABLE Produto_has_Vendas (
  Produto_idProduto INTEGER NOT NULL,
  Vendas_Codigo_produto INTEGER NOT NULL,
  Vendas_Id_vendas INTEGER NOT NULL,
  PRIMARY KEY(Produto_idProduto, Vendas_Codigo_produto, Vendas_Id_vendas),
  INDEX Produto_has_Vendas_FKIndex1(Produto_idProduto),
  INDEX Produto_has_Vendas_FKIndex2(Vendas_Id_vendas, Vendas_Codigo_produto)
);

CREATE TABLE Vendas (
  Id_vendas INTEGER NOT NULL AUTO_INCREMENT,
  Codigo_produto INTEGER NOT NULL,
  Data_2 DATE NULL,
  Quantidade INTEGER NULL,
  Preco_unitario INTEGER NULL,
  Preco_total INTEGER NULL,
  PRIMARY KEY(Id_vendas, Codigo_produto)
);

insert into produto (Nome, Tamanho, Compra_Id_Produtor, Compra_Id_compra, produtor_id_produto)
values ('Cenoura', 'Grande', 2, 3, 14);


