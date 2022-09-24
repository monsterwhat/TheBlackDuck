CREATE DATABASE  IF NOT EXISTS `tlp_database` /*!40100 DEFAULT CHARACTER SET utf8mb3 COLLATE utf8mb3_bin */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tlp_database`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: tlp_database
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `administradores`
--

DROP TABLE IF EXISTS `administradores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `administradores` (
  `idAdministrador` int NOT NULL AUTO_INCREMENT,
  `administradorescol` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `adminUsuario` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `adminContrasenna` varchar(20) COLLATE utf8mb3_bin NOT NULL,
  PRIMARY KEY (`idAdministrador`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administradores`
--

LOCK TABLES `administradores` WRITE;
/*!40000 ALTER TABLE `administradores` DISABLE KEYS */;
/*!40000 ALTER TABLE `administradores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `idCliente` int NOT NULL AUTO_INCREMENT,
  `clienteHijo` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `clientePadre` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `idClientePagos` int NOT NULL,
  `clienteNumero` int NOT NULL,
  `clienteContrasenna` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_bin NOT NULL,
  PRIMARY KEY (`idCliente`,`idClientePagos`),
  KEY `tblCliente_tblPagos_idx` (`idClientePagos`),
  CONSTRAINT `tblCliente_tblPagos` FOREIGN KEY (`idClientePagos`) REFERENCES `clientespagos` (`idClientePagos`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'ramon ramoin','ramon segundo',1,88888888,'123d1243');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientespagos`
--

DROP TABLE IF EXISTS `clientespagos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientespagos` (
  `idClientePagos` int NOT NULL AUTO_INCREMENT,
  `montoPagos` double NOT NULL,
  `fechaPago` date NOT NULL,
  `estadoPago` tinyint NOT NULL,
  PRIMARY KEY (`idClientePagos`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientespagos`
--

LOCK TABLES `clientespagos` WRITE;
/*!40000 ALTER TABLE `clientespagos` DISABLE KEYS */;
INSERT INTO `clientespagos` VALUES (1,245000,'2012-02-22',1);
/*!40000 ALTER TABLE `clientespagos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `superadministradores`
--

DROP TABLE IF EXISTS `superadministradores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `superadministradores` (
  `idSuperAdmin` int NOT NULL AUTO_INCREMENT,
  `superAdminUsuario` varchar(45) COLLATE utf8mb3_bin NOT NULL,
  `superAdminContrasenna` varchar(20) COLLATE utf8mb3_bin NOT NULL,
  PRIMARY KEY (`idSuperAdmin`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `superadministradores`
--

LOCK TABLES `superadministradores` WRITE;
/*!40000 ALTER TABLE `superadministradores` DISABLE KEYS */;
/*!40000 ALTER TABLE `superadministradores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'tlp_database'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-09-23 20:14:54
