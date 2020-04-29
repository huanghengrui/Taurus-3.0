CREATE TABLE DBVersion
(
  DBVer int NULL,
  DBDate datetime NULL,
  AppVer varchar(50) NULL
)
GO

CREATE TABLE SY_Config
(
  [ID] varchar(50) NOT NULL,
  [Key] varchar(50) NOT NULL,
  [Value] text NULL,
  CONSTRAINT PK_SY_Config PRIMARY KEY([ID],[Key])
)
GO

CREATE TABLE SY_Log
(
  OprtTime datetime NULL,
  OprtModule varchar(50) NULL,
  OprtTool varchar(50) NULL,
  OprtDetail text NULL,
  OprtNoName varchar(200) NULL,
  OprtComputerName varchar(200) NULL
)
GO

CREATE TABLE SY_Oprt
(
  OprtNo varchar(10) NOT NULL,
  OprtName varchar(50) NULL,
  OprtPWD varchar(100) NULL,
  OprtDesc text NULL,
  OprtIsSys tinyint NULL,
  OprtLastLoginTime datetime NULL,
  CONSTRAINT PK_SY_Oprt PRIMARY KEY(OprtNo)
)
GO

CREATE TABLE SY_OprtPower
(
  OprtNo varchar(10) NOT NULL,
  ModuleID varchar(50) NOT NULL,
  SubID varchar(50) NOT NULL,
  CONSTRAINT PK_SY_OprtPower PRIMARY KEY(OprtNo,ModuleID,SubID)
)
GO

CREATE TABLE SY_Wizard
(
  OprtNo varchar(10) NOT NULL,
  [ModuleType] int NOT NULL,
  ModuleID varchar(50) NOT NULL,
  SubID varchar(50) NOT NULL,
  [No] int NULL,
  [vis] bit NULL,
  CONSTRAINT PK_SY_Wizard PRIMARY KEY(OprtNo,ModuleType,ModuleID,SubID)
)
GO

CREATE TABLE SY_IDName
(
  Class varchar(10) NOT NULL,
  [ID] varchar(10) NOT NULL,
  [Name] varchar(50) NOT NULL,
  CONSTRAINT PK_SY_IDName PRIMARY KEY(Class,[ID])
)
GO
