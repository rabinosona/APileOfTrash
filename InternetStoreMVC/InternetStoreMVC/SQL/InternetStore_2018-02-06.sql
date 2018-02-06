# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.7.21)
# Database: InternetStore
# Generation Time: 2018-02-06 09:24:40 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table Customer
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Customer`;

CREATE TABLE `Customer` (
  `ID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `NAME` varchar(255) NOT NULL DEFAULT '',
  `CODE` varchar(10) NOT NULL DEFAULT '',
  `ADDRESS` varchar(255) DEFAULT NULL,
  `DISCOUNT` int(3) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table Order
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Order`;

CREATE TABLE `Order` (
  `ID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `CUSTOMER_ID` int(11) unsigned NOT NULL,
  `ORDER_DATE` date NOT NULL,
  `SHIPMENT_DATE` datetime DEFAULT NULL,
  `ORDER_NUMBER` int(50) DEFAULT NULL,
  `STATUS` varchar(20) DEFAULT '',
  PRIMARY KEY (`ID`),
  KEY `ClientID` (`CUSTOMER_ID`),
  CONSTRAINT `ClientID` FOREIGN KEY (`CUSTOMER_ID`) REFERENCES `Customer` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table OrderElement
# ------------------------------------------------------------

DROP TABLE IF EXISTS `OrderElement`;

CREATE TABLE `OrderElement` (
  `ID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `ORDER_ID` int(11) unsigned NOT NULL,
  `ITEM_ID` int(11) unsigned NOT NULL,
  `ITEMS_COUNT` int(11) unsigned NOT NULL,
  `ITEM_PRICE` int(11) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `OrderID` (`ORDER_ID`),
  KEY `ProductID` (`ITEM_ID`),
  CONSTRAINT `OrderID` FOREIGN KEY (`ORDER_ID`) REFERENCES `Order` (`ID`),
  CONSTRAINT `ProductID` FOREIGN KEY (`ITEM_ID`) REFERENCES `Product` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table Product
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Product`;

CREATE TABLE `Product` (
  `ID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `CODE` varchar(11) NOT NULL DEFAULT '',
  `NAME` varchar(255) DEFAULT NULL,
  `PRICE` int(11) DEFAULT NULL,
  `CATEGORY` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;




/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
