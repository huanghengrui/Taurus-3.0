IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_MacInfo')
  CREATE TABLE DI_MacInfo
  (
    MacSN int NOT NULL,
    MacTypeID int NOT NULL,
    MacTypeName varchar(50) NOT NULL,
    MacConnType varchar(10) NOT NULL,
    MacIP varchar(50) NULL,
    MacPort varchar(10) NULL,
    MacConnPWD varchar(10) NULL,
    MacDesc varchar(100) NULL,
    ParamInfo text NULL,
    CONSTRAINT PK_DI_MacInfo PRIMARY KEY(MacSN)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_PsssTime')
  CREATE TABLE DI_PsssTime
  (
    PassTimeID tinyint NOT NULL,
    PassTimeName varchar(50) NULL,
    T1S varchar(5) NULL,
    T1E varchar(5) NULL,
    T2S varchar(5) NULL,
    T2E varchar(5) NULL,
    T3S varchar(5) NULL,
    T3E varchar(5) NULL,
    T4S varchar(5) NULL,
    T4E varchar(5) NULL,
    T5S varchar(5) NULL,
    T5E varchar(5) NULL,
    T6S varchar(5) NULL,
    T6E varchar(5) NULL,
    OprtNo varchar(10) NULL,
    OprtDate datetime NULL,
    CONSTRAINT PK_DI_PsssTime PRIMARY KEY(PassTimeID)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_Power')
  CREATE TABLE DI_Power
  (
    GUID varchar(36) NOT NULL,
    MacSN int NOT NULL,
    EmpNo varchar(20) NOT NULL,
    SunID tinyint NULL,
    MonID tinyint NULL,
    TueID tinyint NULL,
    WedID tinyint NULL,
    ThuID tinyint NULL,
    FriID tinyint NULL,
    SatID tinyint NULL,
    OprtNo varchar(10) NULL,
    OprtDate datetime NULL,
    CONSTRAINT PK_DI_Power PRIMARY KEY(GUID),
    CONSTRAINT AK_DI_Power UNIQUE(MacSN,EmpNo)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_SeaPower')
  CREATE TABLE DI_SeaPower
  (
    GUID varchar(36) NOT NULL,
    MacSN varchar(50) NOT NULL,
    EmpNo varchar(20) NOT NULL,
    OprtNo varchar(10) NULL,
    OprtDate datetime NULL,
    StartDate datetime NULL,
    EndDate datetime NULL,
    CONSTRAINT PK_DI_SeaPower PRIMARY KEY(GUID),
    CONSTRAINT AK_DI_SeaPower UNIQUE(MacSN,EmpNo)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_SeaSnapShots')
CREATE TABLE DI_SeaSnapShots
(
  [GUID] varchar(36) NOT NULL,
  MacSN varchar(50) NOT NULL,
  PictureType varchar(50) NULL,
  OprtDate datetime NULL,
  Photo image NULL,
  CONSTRAINT PK_DI_SeaSnapShots PRIMARY KEY([GUID]),
  CONSTRAINT AK_DI_SeaSnapShots UNIQUE(MacSN,OprtDate)
)
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_SeaSnapShotsPhoto')
CREATE TABLE DI_SeaSnapShotsPhoto
(
  [GUID] varchar(36) NOT NULL,
  Photo image NULL,
  CONSTRAINT PK_DI_SeaSnapShotsPhoto PRIMARY KEY([GUID])
)
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_StarParam')
CREATE TABLE DI_StarParam
(
  [MacSN] varchar(50) NOT NULL,
  [DevName] varchar(50) NULL,
  [WiegandType] varchar(50) NULL,
  [DevLanguage] varchar(50) NULL,
  [AntiPass] varchar(50) NULL,
  [OpenDoorDelay] int NULL,
  [TamperAlarm] varchar(50) NULL,
  [AlarmDelay] int NULL,
  [Volume] int NULL,
  [ReverifyTime] int NULL,
  [ScreensaversTime] int NULL,
  [SleepTime] int NULL,
  [ServerHost] varchar(50) NULL,
  [ServerPort] int NULL,
  [PushServerHost] varchar(50) NULL,
  [PushServerPort] int NULL,
  [Interval] int NULL,
  [pushEnable] varchar(50) NULL,
  [verifyMode] varchar(50) NULL,
  CONSTRAINT PK_DI_StarParam PRIMARY KEY(MacSN)
)
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_StarPower')
CREATE TABLE DI_StarPower
(
  [GUID] varchar(36) NOT NULL,
  [MacSN] varchar(50) NOT NULL,
  [EmpNo] varchar(20) NOT NULL,
  [OprtNo] varchar(10) NULL,
  [OprtDate] datetime NULL,
  [StartDate] datetime NULL,
  [EndDate] datetime NULL,
  CONSTRAINT PK_DI_StarPower PRIMARY KEY([GUID]),
  CONSTRAINT AK_DI_StarPower UNIQUE([MacSN],[EmpNo])
)
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_SeaSound')
CREATE TABLE DI_SeaSound
(
  [MacSN] varchar(50) NOT NULL,
  [VerifyFailAudio] int NULL,
  [VerifySuccAudio] int NULL,
  [RemoteCtrlAudio] int NULL,
  [VerifySuccGuiTip] int NULL,
  [UnregisteredGuiTip] int NULL,
  [VerifyFailGuiTip] int NULL,
  [Volume] int NULL,
  [IPHide] int NULL,
  [IsShowName] int NULL,
  [IsShowTitle] int NULL,
  [IsShowVersion] int NULL,
  [IsShowDate] int NULL,
  [IDCardNumHide] int NULL,
  [ICCardNumHide] int NULL,
  CONSTRAINT PK_DI_SeaSound PRIMARY KEY(MacSN)
)
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_SeaDoorCondition')
CREATE TABLE DI_SeaDoorCondition
(
  [MacSN] varchar(50) NOT NULL,
  [FaceThreshold] int NULL,
  [IDCardThreshold] int NULL,
  [OpendoorWay] int NULL,
  [VerifyMode] int NULL,
  [Wiegand] int NULL,
  [ControlType] int NULL,
  [PublicMjCardNo] varchar(20) NULL,
  [AutoMjCardBgnNo] varchar(20) NULL,
  [AutoMjCardEndNo] varchar(20) NULL,
  [IOStayTime] varchar(20) NULL,
  CONSTRAINT PK_DI_SeaDoorCondition PRIMARY KEY(MacSN)
)
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_SeaTemperature')
CREATE TABLE DI_SeaTemperature
(
  [MacSN] varchar(50) NOT NULL,
  [FaceMaskTPTMode] int NULL,
  [TemperatureCheck] decimal(10,2) NULL,
  [TemperatureHigh] decimal(10,2) NULL,
  [EnvTemperature] decimal(10,2) NULL,
  [EnvTemperatureCheck] decimal(10,2) NULL,
  [OpenLaser] int NULL,
  CONSTRAINT PK_DI_SeaTemperature PRIMARY KEY([MacSN])
)
GO
IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_SeaNetParam')
  CREATE TABLE DI_SeaNetParam
  (
    MacSN varchar(50) NOT NULL,
    IPAddr varchar(20) NULL,
    Submask varchar(20) NULL,
    Gateway varchar(20) NULL,
    ListenPort varchar(20) NULL,
    WebPort varchar(20) NULL,
    CONSTRAINT PK_DI_SeaNetParam PRIMARY KEY(MacSN)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='DI_DevGroup')
CREATE TABLE DI_DevGroup
(
  DevGroupID varchar(20) NOT NULL,
  DevGroupName varchar(20) NOT NULL,
  DevGroupUpID varchar(20)  NULL,
  DevGroupMemo text NULL,
  CONSTRAINT PK_DI_DevGroup PRIMARY KEY(DevGroupID)
)
GO