CREATE DATABASE `lib`;
use lib;
CREATE TABLE `books` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text NOT NULL,
  `Publication` text NOT NULL,
  `ISBN` varchar(20) NOT NULL,
  `Edition` int(11) NOT NULL,
  `Left` int(11) NOT NULL,
  `Copies` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
CREATE TABLE `users` (
  `Name` varchar(45) NOT NULL,
  `Username` varchar(45) NOT NULL,
  `Pass` varchar(128) NOT NULL,
  `Salt` varchar(11) NOT NULL,
  `AccType` varchar(7) NOT NULL,
  `IssuedBooks` varchar(256) DEFAULT NULL,
  `NoOfBooks` int(2) DEFAULT '0',
  `Due` int(11) unsigned DEFAULT '0',
  `Confirmed` varchar(3) DEFAULT 'No',
  PRIMARY KEY (`Username`),
  UNIQUE KEY `Username_UNIQUE` (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
