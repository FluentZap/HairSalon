-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 11, 2019 at 03:26 AM
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
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stylist_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `phone_number` varchar(255) NOT NULL,
  `alt_phone_number` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`id`, `stylist_id`, `name`, `phone_number`, `alt_phone_number`) VALUES
(1, 3, 'Goldman', '5555555555', NULL),
(2, 2, 'Guuuoop', '45787823', '74453245'),
(3, 4, 'GogogogoMan', '4236346', '13423536'),
(4, 4, 'PutPutin', '4234', '55');

-- --------------------------------------------------------

--
-- Table structure for table `stylist`
--

DROP TABLE IF EXISTS `stylist`;
CREATE TABLE IF NOT EXISTS `stylist` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `session_id` varchar(255) NOT NULL,
  `login_name` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylist`
--

INSERT INTO `stylist` (`id`, `session_id`, `login_name`, `name`, `password`) VALUES
(2, '820add4c-793b-c1b1-611c-bbbe5255d64b', 'toad', 'Mr Froggie', 'root'),
(3, 'fd467a4c-f4ea-dad9-93b9-93db04e90a97', 'badass', 'Mr Clean', 'root'),
(4, 'd7e0084a-cc33-1ece-1382-ff2d62da2c21', 'OldGuy22', 'Roshi', 'root'),
(5, '62145b09-15f1-9722-760f-a66448d00f2e', 'Wasda', 'Mr Wasda', 'root'),
(6, 'ca1837ff-b0d4-c993-77ba-8d15f622eaf0', 'asd', 'Mr aaaaa', 'root');

-- --------------------------------------------------------

--
-- Table structure for table `visit`
--

DROP TABLE IF EXISTS `visit`;
CREATE TABLE IF NOT EXISTS `visit` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `notes` varchar(255) NOT NULL,
  `bill` float NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
