ALTER TABLE KQ_Shift ADD ShiftCount tinyint NULL
GO
ALTER TABLE RS_Emp ADD IsDimission bit NULL
GO
ALTER TABLE RS_Emp ADD DimissionDate datetime NULL
GO
ALTER TABLE RS_Emp ADD DimissionReason varchar(255) NULL
GO
ALTER TABLE RS_Emp ADD DimissionOprt varchar(10) NULL
GO
ALTER TABLE RS_Emp ADD OprtNo varchar(10) NULL
GO
ALTER TABLE RS_Emp ADD OprtDate datetime NULL
GO
UPDATE RS_Emp SET IsDimission=0 WHERE IsDimission IS NULL
GO
ALTER TABLE DI_MacInfo ADD MacMANAGERS int NULL
GO
ALTER TABLE DI_MacInfo ADD MacUSERS int NULL
GO
ALTER TABLE DI_MacInfo ADD MacFPS int NULL
GO
ALTER TABLE DI_MacInfo ADD MacFaceS int NULL
GO
ALTER TABLE DI_MacInfo ADD MacPSWS int NULL
GO
ALTER TABLE DI_MacInfo ADD MacCARDS int NULL
GO
ALTER TABLE DI_MacInfo ADD MacGLOGS int NULL
GO
ALTER TABLE DI_MacInfo ADD MacAGLOGS int NULL
GO
ALTER TABLE DI_MacInfo ADD DoorState varchar(50) NULL
GO
ALTER TABLE RS_Emp ADD EmpGZ decimal(16, 2) NULL
GO
ALTER TABLE RS_Emp ADD GZRuleID int NULL
GO
ALTER TABLE RS_Depart ADD GZRuleID int NULL
GO
ALTER TABLE GZ_GZReport ADD EmpGZ decimal(8, 2) NULL
GO
UPDATE GZ_GZReport SET [SUM]=0 WHERE [SUM]='NoReport'
GO
ALTER TABLE GZ_GZReport ALTER COLUMN [SUM] decimal(8, 2) NULL
GO
ALTER TABLE RS_Emp ADD [PassWord] varchar(20) NULL
GO
ALTER TABLE KQ_KQData ADD VerifyModeID int NULL
GO
ALTER TABLE KQ_KQData ADD VerifyModeName varchar(50) NULL
GO
ALTER TABLE KQ_KQData ADD InOutModeID int NULL
GO
ALTER TABLE KQ_KQData ADD InOutModeName varchar(50) NULL
GO
DROP TABLE Temp_KQ_KQData
GO
DROP TABLE Temp_KQ_KQDataFilter
GO
CREATE TABLE KQ_MJData
(
  GUID varchar(36) NOT NULL,
  KQDate datetime NOT NULL,
  KQTime int NOT NULL,
  MacSN int NULL,
  VerifyModeID int NULL,
  VerifyModeName varchar(50) NULL,
  InOutModeID int NULL,
  InOutModeName varchar(50) NULL,
  OprtNo varchar(10) NULL,
  OprtDate datetime NULL,
  Remark text NULL,
  CONSTRAINT PK_KQ_MJData PRIMARY KEY(GUID),
  CONSTRAINT AK_KQ_MJData UNIQUE(KQDate,KQTime)
)
GO
CREATE TABLE KQ_MJDataPhoto
(
  GUID varchar(36) NOT NULL,
  Photo image NULL,
  CONSTRAINT PK_KQ_MJDataPhoto PRIMARY KEY(GUID)
)
GO
CREATE TABLE KQ_ReportRecords
(
  KQYM varchar(6) NOT NULL,
  EmpNo varchar(20) NOT NULL,
  EmpName varchar(50) NULL,
  DepartID varchar(20) NULL,
  DepartName varchar(50) NULL,
  CardTime01 text NULL,
  CardTime02 text NULL,
  CardTime03 text NULL,
  CardTime04 text NULL,
  CardTime05 text NULL,
  CardTime06 text NULL,
  CardTime07 text NULL,
  CardTime08 text NULL,
  CardTime09 text NULL,
  CardTime10 text NULL,
  CardTime11 text NULL,
  CardTime12 text NULL,
  CardTime13 text NULL,
  CardTime14 text NULL,
  CardTime15 text NULL,
  CardTime16 text NULL,
  CardTime17 text NULL,
  CardTime18 text NULL,
  CardTime19 text NULL,
  CardTime20 text NULL,
  CardTime21 text NULL,
  CardTime22 text NULL,
  CardTime23 text NULL,
  CardTime24 text NULL,
  CardTime25 text NULL,
  CardTime26 text NULL,
  CardTime27 text NULL,
  CardTime28 text NULL,
  CardTime29 text NULL,
  CardTime30 text NULL,
  CardTime31 text NULL,
  CONSTRAINT PK_KQ_ReportRecords PRIMARY KEY(KQYM,EmpNo)
)
GO
ALTER TABLE KQ_KQReportMonth ADD StartDate datetime NULL
GO
ALTER TABLE KQ_KQReportMonth ADD EndDate datetime NULL
GO
ALTER TABLE KQReportNotFound ADD StartDate datetime NULL
GO
ALTER TABLE KQReportNotFound ADD EndDate datetime NULL
GO
ALTER TABLE DI_MacInfo DROP CONSTRAINT PK_DI_MacInfo
GO
ALTER TABLE DI_MacInfo ALTER COLUMN MacSN varchar(50) NOT NULL
GO
ALTER TABLE DI_MacInfo ADD CONSTRAINT PK_DI_MacInfo UNIQUE(MacSN)
GO
ALTER TABLE DI_MacInfo ADD IsGPRS bit NULL
GO
ALTER TABLE DI_Power ALTER COLUMN MacSN varchar(50) NULL
GO
ALTER TABLE KQ_KQData ALTER COLUMN MacSN varchar(50) NULL
GO
ALTER TABLE KQ_KQDataFilter ALTER COLUMN MacSN varchar(50) NULL
GO
ALTER TABLE KQ_MJData ALTER COLUMN MacSN varchar(50) NULL
GO
ALTER TABLE RS_Emp ADD EmpFingerCount int NULL
GO
ALTER TABLE RS_Emp ADD EmpFaceCount int NULL
GO
ALTER TABLE RS_Emp ADD EmpPWCount int NULL
GO
ALTER TABLE RS_Emp ADD EmpCardCount int NULL
GO
ALTER TABLE RS_Emp ADD EmpPalmVeinCount int NULL
GO
ALTER TABLE KQ_EmpShift ALTER COLUMN EmpNo varchar(20) NOT NULL
GO
ALTER TABLE KQ_KQReportDay ALTER COLUMN ShiftID varchar(50)
GO
CREATE TABLE [KQ_ShiftFind]
(
  [ShiftID] varchar(10) NOT NULL,
  [LateMins] int NULL,
  [LeaveMins] int NULL,
  CONSTRAINT [PK_KQ_ShiftFind] PRIMARY KEY([ShiftID])
)
GO
ALTER TABLE KQ_MJData DROP CONSTRAINT AK_KQ_MJData
GO
ALTER TABLE KQ_MJData ADD CONSTRAINT AK_KQ_MJData UNIQUE(MacSN,KQDate,KQTime)
GO
ALTER TABLE KQ_KQReportDay ADD MustDays decimal(8, 2) NULL
GO
ALTER TABLE KQ_KQReportMonth ADD MustDaysM decimal(8, 2) NULL
GO
ALTER TABLE KQReportNotFound ADD MustDaysM decimal(8, 2) NULL
GO
ALTER TABLE DI_Power ADD StartDate datetime NULL
GO
ALTER TABLE DI_Power ADD EndDate datetime NULL
GO
CREATE TABLE [KQ_KQDataInOutMode]
(
  InOutModeID int NOT NULL,
  InOutModeName varchar(50) NULL,
  CONSTRAINT [PK_KQ_KQDataInOutMode] PRIMARY KEY(InOutModeID)
)
GO
ALTER TABLE DI_MacInfo ADD MacPALMVEINS int NULL
GO
ALTER TABLE KQ_MJData ADD FingerNo bigint NULL
GO
ALTER TABLE DI_MacInfo ADD IsDRecognition bit NULL
GO
CREATE TABLE DI_Dynamic
(
  [GUID] varchar(36) NOT NULL,
  EmpNo varchar(20) NOT NULL,
    T1S varchar(10) NULL,
    T1E varchar(10) NULL,
    T2S varchar(10) NULL,
    T2E varchar(10) NULL,
    T3S varchar(10) NULL,
    T3E varchar(10) NULL,
    OprtNo varchar(10) NULL,
    OprtDate datetime NULL,
    EndDate datetime NULL,
  CONSTRAINT PK_DI_Dynamic PRIMARY KEY([GUID])
)
GO
ALTER TABLE RS_Emp ADD EmpPhoto image NULL
GO
ALTER TABLE RS_Emp ADD EmpPhotoCount int NULL
GO
ALTER TABLE KQ_MJData ADD FingerNo bigint NULL
GO
ALTER TABLE KQ_MJData ADD DoorStauts varchar(20) NULL
GO
ALTER TABLE KQ_MJData ALTER COLUMN FingerNo varchar(50) NULL
GO
ALTER TABLE DI_MacInfo ADD IsOpenDoor bit NULL
GO
ALTER TABLE DI_MacInfo ADD MacPALMVEINS int NULL
GO
CREATE TABLE SY_MacParam
(
  [GUID] varchar(36) NOT NULL,
  MacSN varchar(20) NULL,
  Managers text NULL,
  Volume text NULL,
  ShowResultTime text NULL,
  GlogWarning text NULL,
  ReverifyTime text NULL,
  ScreensaversTime text NULL,
  SleepTime text NULL,
  DiMacNo text NULL,
  ServerIPAddress text NULL,
  ServerPort text NULL,
  ServerRequest text NULL,
  MutiUser text NULL,
  OpenDoorDelay text NULL,
  DoorMagneticType text NULL,
  DoorMagneticDelay text NULL,
  Antiback text NULL,
  UseAlarm text NULL,
  AlarmDelay text NULL,
  WiegandType text NULL,
  WiegandOutput text NULL,
  WiegandInput text NULL,
  CONSTRAINT PK_SY_MacParam PRIMARY KEY([GUID])
)
GO
ALTER TABLE KQ_MJData ADD IsAlarm bit NULL
GO
CREATE TABLE [MJ_TemporaryData]
(
  [GUID] varchar(36) NOT NULL,
  MJDateTime datetime NOT NULL,
  MacSN varchar(20) NULL,
  EmpNo varchar(50) NULL,
  EmpName varchar(50) NULL,
  CONSTRAINT [PK_MJ_TemporaryData] PRIMARY KEY([GUID])
)
GO
CREATE TABLE [MJ_OpenData]
(
  [GUID] varchar(36) NOT NULL,
  MJDateTime datetime NOT NULL,
  MacSN varchar(20) NULL,
  MacDesc varchar(50) NULL,
  InOutModeName varchar(20) NULL,
  EmpNoOne varchar(50) NULL,
  EmpNoTwo varchar(50) NULL,
  EmpNoTree varchar(50) NULL,
  CONSTRAINT [PK_MJ_OpenData] PRIMARY KEY([GUID])
)
GO

CREATE TABLE [MJ_AlarmData]
(
  [GUID] varchar(36) NOT NULL,
  AlarmTime datetime NOT NULL,
  MacSN varchar(20) NULL,
  MacDesc varchar(50) NULL,
  AlarmMode varchar(50) NULL,
  CONSTRAINT [PK_MJ_AlarmData] PRIMARY KEY([GUID])
)
GO
ALTER TABLE DI_MacInfo ADD MacConnectState varchar(50) NULL
GO
ALTER TABLE DI_MacInfo ADD MacDefenseState varchar(50) NULL
GO
ALTER TABLE DI_MacInfo ADD OpenState varchar(10) NULL
GO
ALTER TABLE KQ_MJData DROP CONSTRAINT AK_KQ_MJData
GO
ALTER TABLE KQ_MJData ADD CONSTRAINT AK_KQ_MJData UNIQUE (MacSN,VerifyModeID,KQDate,KQTime)
GO
ALTER TABLE DI_Power DROP CONSTRAINT AK_DI_Power
GO
ALTER TABLE DI_Power ALTER COLUMN MacSN varchar(50) NOT NULL
GO
ALTER TABLE DI_Power ADD CONSTRAINT AK_DI_Power UNIQUE (MacSN,EmpNo)
GO
ALTER TABLE KQ_KQDataFilterMark ADD KQWeek varchar(50) NULL
GO
ALTER TABLE KQ_KQDataFilterMark ADD RuleCount int NULL
GO
ALTER TABLE DI_MacInfo ADD SetTimer time NULL
GO
ALTER TABLE DI_MacInfo ADD IsTimerOpen int NULL
GO
ALTER TABLE MJ_OpenData ADD EmpNoFour varchar(50) NULL
GO
ALTER TABLE MJ_OpenData ADD EmpNoFive varchar(50) NULL
GO
ALTER TABLE DI_MacInfo ALTER COLUMN MMacConnectState varchar(50) NULL
GO
ALTER TABLE DI_MacInfo ALTER COLUMN MacDefenseState varchar(50) NULL
GO
ALTER TABLE MJ_OpenData ADD KQTime int NULL
GO
INSERT INTO DI_PsssTime(PassTimeID,PassTimeName,T1S,T1E,T2S,T2E,T3S,T3E,T4S,T4E,T5S,T5E,
                              T6S,T6E,OprtNo,OprtDate) VALUES(1,'','00:00','23:59','00:00','00:00','00:00','00:00','00:00',
                              '00:00','00:00','00:00','00:00','00:00','ADMIN',getdate())
GO
DECLARE @i INT
SET @i=2
WHILE @i<256
BEGIN
INSERT INTO DI_PsssTime(PassTimeID,PassTimeName,T1S,T1E,T2S,T2E,T3S,T3E,T4S,T4E,T5S,T5E,
                              T6S,T6E,OprtNo,OprtDate) VALUES(@i,'','00:00','00:00','00:00','00:00','00:00','00:00','00:00',
                              '00:00','00:00','00:00','00:00','00:00','ADMIN',getdate())
SET @i=@i+1
END 
GO
ALTER TABLE RS_Emp ALTER COLUMN EmpGZ decimal(16,2) NULL
GO
ALTER TABLE GZ_Rule ALTER COLUMN RuleCash decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN RuleCash decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN EmpGZ decimal(16, 2) NOT NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In1 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In2 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN In3 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In4 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In5 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In6 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In7 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In8 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In9 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In10 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In11 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In12 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In13 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In14 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In15 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In16 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In17 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In18 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In19 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  In20 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out1 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out2 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out3 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out4 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out5 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out6 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out7 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out8 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out9 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out10 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out11 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out12 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out13 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out14 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out15 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out16 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out17 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out18 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out19 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  Out20 decimal(16,2) NULL
GO
ALTER TABLE GZ_GZReport ALTER COLUMN  [SUM] decimal(16,2) NULL
GO
ALTER TABLE DI_MacInfo ADD MacSeriesTypeId int NULL
GO
ALTER TABLE DI_MacInfo ADD MacSeriesTypeName varchar(50) NULL
GO
ALTER TABLE DI_MacInfo ALTER COLUMN  MacConnPWD varchar(50) NULL
GO
ALTER TABLE DI_MacInfo ADD MacSeriesUserName varchar(50) NULL
GO
ALTER TABLE DI_MacInfo ADD InOutMode varchar(30) NULL
GO
ALTER TABLE RS_Emp ADD EmpFingerCount_Star int NULL
GO
ALTER TABLE RS_Emp ADD EmpFaceCount_Star int NULL
GO
ALTER TABLE RS_Emp ADD EmpPalmVeinCount_Star int NULL
GO
ALTER TABLE RS_Emp ADD [StartDate] datetime NULL
GO
ALTER TABLE RS_Emp ADD [EndDate] datetime NULL
GO
ALTER TABLE KQ_MJData ADD Temperature varchar(20) NULL
GO
ALTER TABLE KQ_MJData ADD TemperatureAlarm bit NULL
GO
ALTER TABLE DI_SeaSnapShots ADD Temperature varchar(20) NULL
GO
ALTER TABLE DI_SeaSnapShots ADD TemperatureAlarm bit NULL
GO
ALTER TABLE KQ_KQData ADD Temperature varchar(20) NULL
GO
ALTER TABLE KQ_KQData ADD TemperatureAlarm bit NULL
GO
ALTER TABLE KQ_Rule ADD RuleHeadAndTail bit NULL
GO
ALTER TABLE DI_MacInfo ADD DevGroupID varchar(20) NULL
GO
ALTER TABLE DI_MacInfo ADD DevGroupName varchar(20) NULL
GO
ALTER TABLE DI_MacInfo ADD DevModeID int NULL
GO
ALTER TABLE KQ_Rule ADD RuleLeaveOvertime bit NULL
GO
  