-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema rendevDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `rendevDB` DEFAULT CHARACTER SET utf8 ;
-- -----------------------------------------------------
-- Schema rendevdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema rendevdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `rendevdb` DEFAULT CHARACTER SET utf8 ;
USE `rendevDB` ;

-- -----------------------------------------------------
<<<<<<< HEAD
=======
-- Table `rendevDB`.`categorie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rendevDB`.`categorie` (
  `idCategorie` INT NOT NULL AUTO_INCREMENT,
  `nomCategorie` VARCHAR(45) NOT NULL,
  `ImageCategorie` VARCHAR(45) NULL,
  PRIMARY KEY (`idCategorie`),
  UNIQUE INDEX `idCategorie_UNIQUE` (`idCategorie` ASC) ,
  UNIQUE INDEX `nomCategorie_UNIQUE` (`nomCategorie` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rendevDB`.`position`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rendevDB`.`position` (
  `idPosition` INT NOT NULL AUTO_INCREMENT,
  `latitude` DOUBLE NULL,
  `longitude` DOUBLE NULL,
  PRIMARY KEY (`idPosition`))
ENGINE = InnoDB;


-- -----------------------------------------------------
>>>>>>> baadbce5d236a0c65675c9a575cc921260a8561a
-- Table `rendevDB`.`evenement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rendevDB`.`evenement` (
  `idEvenement` INT NOT NULL AUTO_INCREMENT,
  `nomEvenement` VARCHAR(45) NOT NULL,
  `descriptionEvenement` VARCHAR(100) NULL,
  `dateEvent` DATETIME NULL,
  `categorie_idCategorie` INT NOT NULL,
  `position_idPosition` INT NOT NULL,
  PRIMARY KEY (`idEvenement`, `position_idPosition`),
  INDEX `fk_evenement_categorie_idx` (`categorie_idCategorie` ASC) ,
  INDEX `fk_evenement_position1_idx` (`position_idPosition` ASC) ,
  CONSTRAINT `fk_evenement_categorie`
    FOREIGN KEY (`categorie_idCategorie`)
    REFERENCES `rendevDB`.`categorie` (`idCategorie`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_evenement_position1`
    FOREIGN KEY (`position_idPosition`)
    REFERENCES `rendevDB`.`position` (`idPosition`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `rendevdb` ;

-- -----------------------------------------------------
-- Table `rendevdb`.`categorie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rendevdb`.`categorie` (
  `idCategorie` INT NOT NULL AUTO_INCREMENT,
  `nomCategorie` VARCHAR(45) NOT NULL,
  `ImageCategorie` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idCategorie`),
  UNIQUE INDEX `idCategorie_UNIQUE` (`idCategorie` ASC) ,
  UNIQUE INDEX `nomCategorie_UNIQUE` (`nomCategorie` ASC) )
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `rendevdb`.`position`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rendevdb`.`position` (
  `idPosition` INT NOT NULL AUTO_INCREMENT,
  `latitude` DOUBLE NULL DEFAULT NULL,
  `longitude` DOUBLE NULL DEFAULT NULL,
  PRIMARY KEY (`idPosition`))
ENGINE = InnoDB
AUTO_INCREMENT = 23
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `rendevdb`.`evenement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rendevdb`.`evenement` (
  `idEvenement` INT NOT NULL AUTO_INCREMENT,
  `nomEvenement` VARCHAR(45) NOT NULL,
  `descriptionEvenement` VARCHAR(100) NULL DEFAULT NULL,
  `dateEvenement` DATETIME NULL DEFAULT NULL,
  `idCategorie` INT NOT NULL,
  `idPosition` INT NOT NULL,
  PRIMARY KEY (`idEvenement`, `idPosition`),
  INDEX `fk_evenement_categorie_idx` (`idCategorie` ASC) ,
  INDEX `fk_evenement_position1_idx` (`idPosition` ASC) ,
  CONSTRAINT `fk_evenement_categorie`
    FOREIGN KEY (`idCategorie`)
    REFERENCES `rendevdb`.`categorie` (`idCategorie`),
  CONSTRAINT `fk_evenement_position1`
    FOREIGN KEY (`idPosition`)
    REFERENCES `rendevdb`.`position` (`idPosition`))
ENGINE = InnoDB
AUTO_INCREMENT = 16
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `rendevDB`.`categorie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rendevDB`.`categorie` (
  `idCategorie` INT NOT NULL AUTO_INCREMENT,
  `nomCategorie` VARCHAR(45) NOT NULL,
  `ImageCategorie` VARCHAR(45) NULL,
  PRIMARY KEY (`idCategorie`),
  UNIQUE INDEX `idCategorie_UNIQUE` (`idCategorie` ASC) ,
  UNIQUE INDEX `nomCategorie_UNIQUE` (`nomCategorie` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `rendevDB`.`position`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rendevDB`.`position` (
  `idPosition` INT NOT NULL AUTO_INCREMENT,
  `latitude` DOUBLE NULL,
  `longitude` DOUBLE NULL,
  PRIMARY KEY (`idPosition`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
