-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2019. Máj 24. 18:27
-- Kiszolgáló verziója: 5.7.24
-- PHP verzió: 7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `noc`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `groups`
--

DROP TABLE IF EXISTS `groups`;
CREATE TABLE IF NOT EXISTS `groups` (
  `groupid` int(11) NOT NULL AUTO_INCREMENT,
  `groupName` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`groupid`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `groups`
--

INSERT INTO `groups` (`groupid`, `groupName`) VALUES
(1, 'Administrator'),
(2, 'User'),
(3, 'Test csoport');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `groupsmenus`
--

DROP TABLE IF EXISTS `groupsmenus`;
CREATE TABLE IF NOT EXISTS `groupsmenus` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `group_id` int(11) NOT NULL,
  `menu_id` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `groupsmenus`
--

INSERT INTO `groupsmenus` (`id`, `group_id`, `menu_id`) VALUES
(1, 2, 3),
(2, 2, 2),
(3, 2, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `log`
--

DROP TABLE IF EXISTS `log`;
CREATE TABLE IF NOT EXISTS `log` (
  `logid` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `operation_id` int(11) NOT NULL,
  `record_id` int(11) NOT NULL,
  `inserttime` datetime NOT NULL,
  PRIMARY KEY (`logid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `mainmenus`
--

DROP TABLE IF EXISTS `mainmenus`;
CREATE TABLE IF NOT EXISTS `mainmenus` (
  `menuId` int(11) NOT NULL AUTO_INCREMENT,
  `menuName` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  `parentId` int(11) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`menuId`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `mainmenus`
--

INSERT INTO `mainmenus` (`menuId`, `menuName`, `parentId`, `active`) VALUES
(1, 'mainSystem', 0, 1),
(2, 'systemUsers', 1, 1),
(3, 'userList', 2, 1),
(4, 'userNew', 2, 1),
(5, 'systemGroups', 1, 1),
(6, 'GroupList', 5, 1),
(7, 'groupNew', 5, 1),
(8, 'menusToolStripMenuItem', 1, 1),
(9, 'listToolStripMenuItem', 8, 1),
(10, 'serversToolStripMenuItem', 1, 1),
(11, 'listToolStripMenuItem1', 10, 1),
(12, 'newToolStripMenuItem1', 10, 1),
(13, 'servertypesToolStripMenuItem', 10, 1),
(14, 'listToolStripMenuItem2', 13, 1),
(15, 'newToolStripMenuItem2', 13, 1),
(16, 'systemparametersToolStripMenuItem', 1, 1),
(17, 'listToolStripMenuItem3', 16, 1),
(18, 'newToolStripMenuItem3', 16, 1),
(19, 'logToolStripMenuItem', 1, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `operations`
--

DROP TABLE IF EXISTS `operations`;
CREATE TABLE IF NOT EXISTS `operations` (
  `operationid` int(11) NOT NULL AUTO_INCREMENT,
  `operationname` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`operationid`),
  UNIQUE KEY `operationid` (`operationid`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `operations`
--

INSERT INTO `operations` (`operationid`, `operationname`) VALUES
(1, 'Sikeres bejelentkezés'),
(2, 'Sikeres szervertípus frissítés'),
(3, 'Sikertelen szervertípus frissítés'),
(4, 'Sikeres rendszerparaméter szerkesztés'),
(5, 'Sikertelen rendszerparaméter szerkesztés'),
(6, 'Sikeres felhasználó frissítés'),
(7, 'Sikertelen felhasználó frissítés'),
(8, 'Sikeres jogosultsági csoport feltöltés'),
(9, 'Sikertelen jogosultsági csoport feltöltés'),
(10, 'Sikeres menü feltöltés'),
(11, 'Sikertelen menü feltöltés'),
(12, 'Sikeres szerver feltöltés'),
(13, 'Sikertelen szerver feltöltés'),
(14, 'Sikeres szervertípus feltöltés'),
(15, 'Sikertelen szervertípus feltöltés'),
(16, 'Sikeres rendszerparaméter feltöltés'),
(17, 'Sikertelen rendszerparaméter feltöltés'),
(18, 'Sikeres felhasználó létrehozás'),
(19, 'Sikertelen felhasználó létrehozás'),
(20, 'Sikeres jogosultsági csoport frissítés'),
(21, 'Sikertelen jogosultsági csoport frissítés'),
(22, 'Sikeres szerver frissítés'),
(23, 'Sikertelen szerver frissítés'),
(24, 'Felhasználó törölve'),
(25, 'Szervertípus törölve'),
(26, 'Jogosultsági csoport törölve'),
(27, 'Menü törölve'),
(28, 'Szerver törölve');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `servers`
--

DROP TABLE IF EXISTS `servers`;
CREATE TABLE IF NOT EXISTS `servers` (
  `serverid` int(11) NOT NULL AUTO_INCREMENT,
  `servername` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  `servertype_id` int(11) NOT NULL,
  `serveractive` tinyint(1) NOT NULL,
  `servermemory` int(11) NOT NULL,
  `serverdisk` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  `servercpu` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  `serveropsystem` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`serverid`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `servers`
--

INSERT INTO `servers` (`serverid`, `servername`, `servertype_id`, `serveractive`, `servermemory`, `serverdisk`, `servercpu`, `serveropsystem`) VALUES
(1, 'Szerver 1. teszt', 1, 1, 1024, '512', 'Core I5', 'Linux'),
(2, 'Új szerver', 2, 1, 256, '1', 'P4', 'Windows Xp'),
(3, 'Teszt', 1, 0, 102, '012', 'das', 'asasda');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `servertypes`
--

DROP TABLE IF EXISTS `servertypes`;
CREATE TABLE IF NOT EXISTS `servertypes` (
  `servertypeid` int(11) NOT NULL AUTO_INCREMENT,
  `servertypename` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`servertypeid`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `servertypes`
--

INSERT INTO `servertypes` (`servertypeid`, `servertypename`) VALUES
(1, 'Helyi azonosítás'),
(2, 'LDAP (Microsoft AD)'),
(4, 'Radius'),
(5, 'SQL teszt');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `systemparams`
--

DROP TABLE IF EXISTS `systemparams`;
CREATE TABLE IF NOT EXISTS `systemparams` (
  `sysparamid` int(11) NOT NULL AUTO_INCREMENT,
  `syskey` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  `sysvalue` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`sysparamid`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `systemparams`
--

INSERT INTO `systemparams` (`sysparamid`, `syskey`, `sysvalue`) VALUES
(1, 'gombHatterszin', 'Blue'),
(2, 'gombSzovegszin', 'White'),
(3, 'teszt', 'teszt');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  `group_id` int(11) NOT NULL,
  `server_id` int(11) NOT NULL,
  PRIMARY KEY (`userid`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`userid`, `username`, `password`, `group_id`, `server_id`) VALUES
(1, 'admin', 'd033e22ae348aeb5660fc2140aec35850c4da997', 1, 1),
(3, 'letesztelem', '6241732a2b29883c46c48d55ffef215a60eb4988', 2, 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
