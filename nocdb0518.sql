-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2019. Máj 18. 19:33
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
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

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
) ENGINE=MyISAM AUTO_INCREMENT=18 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `groupsmenus`
--

INSERT INTO `groupsmenus` (`id`, `group_id`, `menu_id`) VALUES
(15, 2, 3),
(14, 2, 2),
(13, 2, 1);

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
) ENGINE=MyISAM AUTO_INCREMENT=38 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `log`
--

INSERT INTO `log` (`logid`, `user_id`, `operation_id`, `record_id`, `inserttime`) VALUES
(1, 1, 1, 0, '2019-05-17 20:48:48'),
(2, 1, 1, 0, '2019-05-17 21:24:22'),
(3, 1, 1, 0, '2019-05-17 21:41:11'),
(4, 1, 1, 0, '2019-05-17 21:41:47'),
(5, 3, 1, 0, '2019-05-17 21:42:08'),
(6, 1, 1, 0, '2019-05-17 21:50:05'),
(7, 1, 1, 0, '2019-05-17 21:53:30'),
(8, 1, 1, 0, '2019-05-17 21:55:37'),
(9, 3, 1, 0, '2019-05-17 21:55:51'),
(10, 1, 1, 0, '2019-05-17 21:58:37'),
(11, 1, 1, 0, '2019-05-18 18:33:31'),
(12, 1, 1, 0, '2019-05-18 18:34:23'),
(13, 1, 1, 0, '2019-05-18 18:35:04'),
(14, 1, 1, 0, '2019-05-18 18:36:24'),
(15, 1, 1, 0, '2019-05-18 18:39:50'),
(16, 1, 1, 0, '2019-05-18 18:41:12'),
(17, 1, 1, 0, '2019-05-18 18:48:11'),
(18, 1, 1, 0, '2019-05-18 18:48:29'),
(19, 1, 1, 1, '2019-05-18 19:01:47'),
(20, 1, 1, 1, '2019-05-18 19:03:31'),
(21, 1, 1, 1, '2019-05-18 19:05:18'),
(22, 1, 1, 1, '2019-05-18 19:05:48'),
(23, 1, 1, 1, '2019-05-18 19:29:46'),
(24, 1, 1, 1, '2019-05-18 19:40:07'),
(25, 1, 1, 1, '2019-05-18 19:53:31'),
(26, 1, 1, 1, '2019-05-18 20:59:10'),
(27, 1, 1, 1, '2019-05-18 21:02:12'),
(28, 1, 1, 1, '2019-05-18 21:10:44'),
(29, 1, 1, 1, '2019-05-18 21:12:09'),
(30, 1, 1, 1, '2019-05-18 21:13:46'),
(31, 1, 1, 1, '2019-05-18 21:14:09'),
(32, 1, 1, 1, '2019-05-18 21:25:06'),
(33, 1, 1, 1, '2019-05-18 21:25:36'),
(34, 1, 1, 1, '2019-05-18 21:26:24'),
(35, 1, 1, 1, '2019-05-18 21:28:16'),
(36, 1, 1, 1, '2019-05-18 21:29:18'),
(37, 1, 1, 1, '2019-05-18 21:31:41');

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
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

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
(18, 'newToolStripMenuItem3', 16, 1);

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
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `operations`
--

INSERT INTO `operations` (`operationid`, `operationname`) VALUES
(1, 'Sikeres bejelentkezés');

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
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `servers`
--

INSERT INTO `servers` (`serverid`, `servername`, `servertype_id`, `serveractive`, `servermemory`, `serverdisk`, `servercpu`, `serveropsystem`) VALUES
(1, 'Szerver 1. teszt', 1, 1, 1024, '512', 'Core I5', 'Linux'),
(2, 'Új szerver', 2, 1, 256, '1', 'P4', 'Windows Xp'),
(3, 'dasdasd', 1, 0, 102, '012', 'das', 'asasda');

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
(5, 'SQL');

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
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`userid`, `username`, `password`, `group_id`, `server_id`) VALUES
(1, 'admin', 'd033e22ae348aeb5660fc2140aec35850c4da997', 1, 1),
(3, 'letesztelem', '6241732a2b29883c46c48d55ffef215a60eb4988', 2, 2);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
