-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 19, 2019 at 05:26 AM
-- Server version: 5.7.24
-- PHP Version: 7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `todd_aden`
--

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  `StylistId` int(11) DEFAULT NULL,
  `Phone_number` text,
  `Alt_phone_number` text,
  PRIMARY KEY (`Id`),
  KEY `IX_Clients_StylistId` (`StylistId`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`Id`, `Name`, `StylistId`, `Phone_number`, `Alt_phone_number`) VALUES
(1, 'Goldman', 2, '564465', NULL),
(2, 'GogogogoMan', 2, '34645', NULL),
(3, 'PutPutin', 1, '6456', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

DROP TABLE IF EXISTS `specialties`;
CREATE TABLE IF NOT EXISTS `specialties` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`Id`, `Name`) VALUES
(1, 'Crazy Blue Flow'),
(3, 'Super Top'),
(4, 'Crazy'),
(5, 'The great Stuff');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

DROP TABLE IF EXISTS `stylists`;
CREATE TABLE IF NOT EXISTS `stylists` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Session_id` text,
  `Login_name` text,
  `Password` text,
  `Name` text,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`Id`, `Session_id`, `Login_name`, `Password`, `Name`) VALUES
(1, '', 'toad', 'root', 'Mr Froggie'),
(2, '', 'badass2', 'root', 'Mr Clean Living Days'),
(3, '', 'oldguy22', 'root', 'Roshi');

-- --------------------------------------------------------

--
-- Table structure for table `stylistspecialties`
--

DROP TABLE IF EXISTS `stylistspecialties`;
CREATE TABLE IF NOT EXISTS `stylistspecialties` (
  `StylistId` int(11) NOT NULL,
  `SpecialtyId` int(11) NOT NULL,
  PRIMARY KEY (`StylistId`,`SpecialtyId`),
  KEY `IX_StylistSpecialties_SpecialtyId` (`SpecialtyId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `stylistspecialties`
--

INSERT INTO `stylistspecialties` (`StylistId`, `SpecialtyId`) VALUES
(1, 1),
(1, 2),
(2, 1),
(2, 4),
(3, 5);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20190518173905_InitialCreate', '2.2.4-servicing-10062');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
