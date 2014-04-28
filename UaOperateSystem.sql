
SET NAMES utf8;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
--  Table structure for `UaOperateSystem`
-- ----------------------------
DROP TABLE IF EXISTS `UaOperateSystem`;
CREATE TABLE `UaOperateSystem` (
  `OSName` varchar(50) NOT NULL,
  `Expression` varchar(50) NOT NULL,
  `Flag` bit(1) NOT NULL,
  PRIMARY KEY (`OSName`,`Expression`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

SET FOREIGN_KEY_CHECKS = 1;
