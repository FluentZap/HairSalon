# KrillinStyles

Krillin Styles is a database test applicaiton to practice database calls and relational databases


## Installation

https://github.com/FluentZap/WordCounter
* Clone the repository and compile with a C# compiler. It uses .NET Core 2.2 & ASP.NET
* You must have access to a MYSQL database.
* Set the setting in the Database.cs file to point to your MYSQL
* Create the database and tables using the following commands. The commands will also drop any tables if they already exsist.
```sql
DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stylist_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `phone_number` varchar(255) NOT NULL,
  `alt_phone_number` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `stylist`;
CREATE TABLE IF NOT EXISTS `stylist` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `session_id` varchar(255) NOT NULL,
  `login_name` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

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
```


## Support
If there are any issues or errors contact me

## License
[MIT](https://choosealicense.com/licenses/mit/)
