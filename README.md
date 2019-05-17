# KrillinStyles

Krillin Styles is a database test applicaiton to practice database calls and relational databases


## Installation

https://github.com/FluentZap/WordCounter
* Clone the repository and compile with a C# compiler. It uses .NET Core 2.2, ASP.NET and Entity Framework Core
* You must have access to a MYSQL database
* Set the setting in the Database.cs file to point to your MYSQL
* Unit tests have a custom option string in TestSetup() that point to the test database
* To have Entity Framework create the database for you run based on the connection string navigate to ```KrillinStyles/``` and run ```dotnet ef database update```
* To create the database and tables using SQL input the following commands below. The commands will also drop any tables if they already exist.

```sql
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Database: `todd_aden`
--

CREATE DATABASE IF NOT EXISTS `todd_aden` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `todd_aden`;

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  `StylistId` int(11) DEFAULT NULL,
  `Phone_number` text,
  `Alt_phone_number` text,
  PRIMARY KEY (`Id`),
  KEY `IX_Clients_StylistId` (`StylistId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `specialties`;
CREATE TABLE IF NOT EXISTS `specialties` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `stylists`;
CREATE TABLE IF NOT EXISTS `stylists` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Session_id` text,
  `Login_name` text,
  `Password` text,
  `Name` text,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

DROP TABLE IF EXISTS `stylistspecialties`;
CREATE TABLE IF NOT EXISTS `stylistspecialties` (
  `StylistId` int(11) NOT NULL,
  `SpecialtyId` int(11) NOT NULL,
  PRIMARY KEY (`StylistId`,`SpecialtyId`),
  KEY `IX_StylistSpecialties_SpecialtyId` (`SpecialtyId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

COMMIT;
```


## Support
If there are any issues or errors contact me

## License
[MIT](https://choosealicense.com/licenses/mit/)
