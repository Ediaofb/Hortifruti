CREATE DATABASE hortifruti_db;
USE hortifruti_DB;

CREATE  TABLE hortifruti_db.produtor (
  idprodutor INT NOT NULL,
  nome VARCHAR(45) NOT NULL ,
  endereco VARCHAR(45) NULL ,
  telefone DECIMAL(11) NULL ,
  PRIMARY KEY (idprodutor) );
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = 'Tabela responsável por armazenar informações sobre os fornecedores de produtos.';


