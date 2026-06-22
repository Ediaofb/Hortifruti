SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `hortifruti_DB` DEFAULT CHARACTER SET utf8 COLLATE default collation;
USE `hortifruti_DB`;

-- -----------------------------------------------------
-- Table `hortifruti_DB`.`produtor`
-- -----------------------------------------------------
-- USE hortifruti_db;

--CREATE  TABLE produtor (
 -- idprodutor INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
--  nome VARCHAR(45) NOT NULL ,
 -- endereco VARCHAR(45) NULL ,
 -- telefone DECIMAL(11) NULL ,
 -- ); 



DROP TABLE IF EXISTS `hortifruti_DB`.`produtor` ;

CREATE  TABLE IF NOT EXISTS `hortifruti_DB`.`produtor` (
  `idprodutor` INT NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(45) NOT NULL ,
  `endereco` VARCHAR(45) NULL ,
  `telefone` DECIMAL(11) NULL ,
  PRIMARY KEY (`idprodutor`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = 'Tabela responsável por armazenar informações sobre os fornecedores de produtos.';


-- -----------------------------------------------------
-- Table `hortifruti_DB`.`produto`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `hortifruti_DB`.`produto` ;

CREATE  TABLE IF NOT EXISTS `hortifruti_DB`.`produto` (
  `idproduto` INT NOT NULL AUTO_INCREMENT ,
  `nome` VARCHAR(25) NOT NULL ,
  `tamanho` VARCHAR(10) NULL ,
  `produtor_idprodutor` INT NOT NULL ,
  PRIMARY KEY (`idproduto`) ,
  INDEX `fk_produto_produtor1` (`produtor_idprodutor` ASC) ,
  CONSTRAINT `fk_produto_produtor1`
    FOREIGN KEY (`produtor_idprodutor` )
    REFERENCES `hortifruti_DB`.`produtor` (`idprodutor` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = 'Tabela responsável por armazenar informações sobre os produtos.';


-- -----------------------------------------------------
-- Table `hortifruti_DB`.`compra`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `hortifruti_DB`.`compra` ;

CREATE  TABLE IF NOT EXISTS `hortifruti_DB`.`compra` (
  `idcompra` INT NOT NULL AUTO_INCREMENT ,
  `data` DATE NOT NULL ,
  `quantidade` DECIMAL(10,0) NOT NULL ,
  `valor_unitario` DECIMAL(5,2) NOT NULL ,
  `valor_total` DECIMAL(5,2) NULL ,
  `idprodutor` INT NOT NULL ,
  `idproduto` INT NOT NULL ,
  PRIMARY KEY (`idcompra`) ,
  INDEX `idprodutor` (`idprodutor` ASC, `idcompra` ASC) ,
  INDEX `idproduto` (`idcompra` ASC) ,
  CONSTRAINT `idprodutor`
    FOREIGN KEY (`idprodutor` , `idcompra` )
    REFERENCES `hortifruti_DB`.`produtor` (`idprodutor` , `idprodutor` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idproduto`
    FOREIGN KEY (`idcompra` )
    REFERENCES `hortifruti_DB`.`produto` (`idproduto` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = 'Tabela responsável por armazenar informações sobre as compras.';


-- -----------------------------------------------------
-- Table `hortifruti_DB`.`cliente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `hortifruti_DB`.`cliente` ;

CREATE  TABLE IF NOT EXISTS `hortifruti_DB`.`cliente` (
  `idcliente` INT NOT NULL ,
  `nome` VARCHAR(45) NOT NULL ,
  `telefone` DECIMAL(11) NOT NULL ,
  `endereco` VARCHAR(45) NULL ,
  PRIMARY KEY (`idcliente`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = 'Tabela responsável por armazenar informações sobre os clientes.';


-- -----------------------------------------------------
-- Table `hortifruti_DB`.`venda`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `hortifruti_DB`.`venda` ;

CREATE  TABLE IF NOT EXISTS `hortifruti_DB`.`venda` (
  `idvenda` INT NOT NULL AUTO_INCREMENT ,
  `data` DATE NOT NULL ,
  `quantidade` DECIMAL(10,0) NOT NULL ,
  `valor_unitario` DECIMAL(5,2) NOT NULL ,
  `valor_total` DECIMAL(5,2) NULL ,
  `id_produto` INT NOT NULL ,
  `id_cliente` INT NOT NULL ,
  PRIMARY KEY (`idvenda`) ,
  INDEX `idproduto` (`id_produto` ASC) ,
  INDEX `idcliente` (`id_cliente` ASC) ,
  CONSTRAINT `idproduto`
    FOREIGN KEY (`id_produto` )
    REFERENCES `hortifruti_DB`.`produto` (`idproduto` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idcliente`
    FOREIGN KEY (`id_cliente` )
    REFERENCES `hortifruti_DB`.`cliente` (`idcliente` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = 'Tabela responsável por armazenar informações sobre as vendas de produtos.';



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
