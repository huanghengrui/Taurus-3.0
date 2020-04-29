IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_KQData')
  CREATE TABLE KQ_KQData
  (
    GUID varchar(36) NOT NULL,
    EmpNo varchar(20) NULL,
    KQDate datetime NOT NULL,
    KQTime int NOT NULL,
    MacSN int NULL,
    IsSignIn bit NULL,
    IsInvalid bit NULL,
    OprtNo varchar(10) NULL,
    OprtDate datetime NULL,
    Remark text NULL,
    CONSTRAINT PK_KQ_KQData PRIMARY KEY(GUID),
    CONSTRAINT AK_KQ_KQData UNIQUE(EmpNo,KQDate,KQTime)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_KQDataPhoto')
  CREATE TABLE KQ_KQDataPhoto
  (
    GUID varchar(36) NOT NULL,
    Photo image NULL,
    CONSTRAINT PK_KQ_KQDataPhoto PRIMARY KEY(GUID)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_Rule')
  CREATE TABLE KQ_Rule
  (
    RuleID varchar(10) NOT NULL,
    RuleName varchar(50) NULL,
    RuleLateIgnore int NULL,
    RuleLeaveIgnore int NULL,
    RuleDupLimit int NULL,
    RuleLateLeaveCalHrs int NULL,
    RuleLateHrs int NULL,
    RuleLeaveHrs int NULL,
    RuleAheadHrs bit NULL,
    RuleAheadMins int NULL,
    RuleDeferHrs bit NULL,
    RuleDeferMins int NULL,
    RuleSunday bit NULL,
    RuleMonday bit NULL,
    RuleTuesday bit NULL,
    RuleWednesday bit NULL,
    RuleThursday bit NULL,
    RuleFriday bit NULL,
    RuleSaturday bit NULL,
    RuleNoRule bit NULL,
    RuleRestDays int NULL,
    RuleReadLate bit NULL,
    RuleReadLeave bit NULL,
    RuleReadWorkHrs bit NULL,
    RuleNSAllowTimeS varchar(5) NULL,
    RuleNSAllowTimeL varchar(5) NULL,
    CONSTRAINT PK_KQ_Rule PRIMARY KEY(RuleID)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_RuleCalc')
  CREATE TABLE [KQ_RuleCalc]
  (
    [SortID] [varchar](20) NOT NULL,
    [SortName] [varchar](50) NULL,
    [CalcTypeID] tinyint NULL,
    [CalcTypeName] [varchar](50) NULL,
    [OvertimeTypeID] tinyint NULL,
    [OvertimeTypeName] [varchar](50) NULL,
    [Start] [int] NULL,
    [Tune] [int] NULL,
    [Integer] [int] NULL,
    [WorkRate] [decimal](8,2) NULL,
    [AbsenceRate] [decimal](8,2) NULL,
    [OvertimeRate] [decimal](8,2) NULL,
    [LeaveRate] [decimal](8,2) NULL,
    CONSTRAINT [PK_KQ_RuleCalc] PRIMARY KEY([SortID])
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_Shift')
  CREATE TABLE [KQ_Shift]
  (
    [ShiftID] [varchar](10) NOT NULL,
    [ShiftName] [varchar](50) NULL,
    [WorkHours] [decimal](8,2) NULL,
    [OverHours] [decimal](8,2) NULL,
    [IsAuto] [bit] NULL,
    [ShiftAhead1] [int] NULL,
    [ShiftDefer1] [int] NULL,
    [SigninTime1] [varchar](5) NULL,
    [SignoutTime1] [varchar](5) NULL,
    [Signin1] [bit] NULL,
    [Signout1] [bit] NULL,
    [SortID1] [varchar](10) NULL,
    [Drift1] [bit] NULL,
    [ShiftAhead2] [int] NULL,
    [ShiftDefer2] [int] NULL,
    [SigninTime2] [varchar](5) NULL,
    [SignoutTime2] [varchar](5) NULL,
    [Signin2] [bit] NULL,
    [Signout2] [bit] NULL,
    [SortID2] [varchar](10) NULL,
    [Drift2] [bit] NULL,
    [ShiftAhead3] [int] NULL,
    [ShiftDefer3] [int] NULL,
    [SigninTime3] [varchar](5) NULL,
    [SignoutTime3] [varchar](5) NULL,
    [Signin3] [bit] NULL,
    [Signout3] [bit] NULL,
    [SortID3] [varchar](10) NULL,
    [Drift3] [bit] NULL,
    [ShiftAhead4] [int] NULL,
    [ShiftDefer4] [int] NULL,
    [SigninTime4] [varchar](5) NULL,
    [SignoutTime4] [varchar](5) NULL,
    [Signin4] [bit] NULL,
    [Signout4] [bit] NULL,
    [SortID4] [varchar](10) NULL,
    [Drift4] [bit] NULL,
    [ShiftAhead5] [int] NULL,
    [ShiftDefer5] [int] NULL,
    [SigninTime5] [varchar](5) NULL,
    [SignoutTime5] [varchar](5) NULL,
    [Signin5] [bit] NULL,
    [Signout5] [bit] NULL,
    [SortID5] [varchar](10) NULL,
    [Drift5] [bit] NULL,
    ShiftCount tinyint NULL,
    CONSTRAINT [PK_KQ_Shift] PRIMARY KEY([ShiftID])
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_ShiftDepart')
  CREATE TABLE KQ_ShiftDepart
  (
    ShiftID varchar(10) NOT NULL,
    DepartID varchar(20) NOT NULL,
    CONSTRAINT PK_KQ_ShiftDepart PRIMARY KEY(ShiftID,DepartID)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_ShiftRule')
  CREATE TABLE [KQ_ShiftRule]
  (
    [ShiftRuleID] [varchar](10) NOT NULL,
    [ShiftRuleName] [varchar](50) NULL,
    [ShiftRulecycID] [tinyint] NULL,
    [ShiftRulecycName] [varchar](50) NULL,
    [ShiftRulecyc] [tinyint] NULL,
    CONSTRAINT [PK_KQ_ShiftRule] PRIMARY KEY([ShiftRuleID])
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_ShiftRuleData')
  CREATE TABLE [KQ_ShiftRuleData]
  (
    [ShiftRuleID] [varchar](10) NOT NULL,
    [ShiftRulecycNo] [tinyint] NOT NULL,
    [ShiftID] [varchar](10) NULL,
    CONSTRAINT [PK_KQ_ShiftRuleData] PRIMARY KEY(ShiftRuleID,ShiftRulecycNo)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_Holiday')
  CREATE TABLE [KQ_Holiday]
  (
    [HolidayID] [varchar](36) NOT NULL,
    [HolidayName] [varchar](50) NULL,
    [HolidayBeginTime] [datetime] NOT NULL,
    [HolidayEndTime] [datetime] NOT NULL,
    CONSTRAINT PK_KQ_Holiday PRIMARY KEY(HolidayID),
    CONSTRAINT AK_KQ_Holiday UNIQUE(HolidayBeginTime,HolidayEndTime)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_EmpDayOff')
  CREATE TABLE [KQ_EmpDayOff]
  (
    [EmpDayOffID] [varchar](36) NOT NULL,
    [EmpNo] [varchar](20) NOT NULL,
    [SortID] [varchar](20) NULL,
    [BeginTime] [datetime] NULL,
    [EndTime] [datetime] NULL,
    [DayOffReason] [varchar](255) NULL,
    [OprtNo] [varchar](10) NULL,
    [OprtDate] [datetime] NULL,
    CONSTRAINT [PK_KQ_EmpDayOff] PRIMARY KEY(EmpDayOffID),
    CONSTRAINT AK_KQ_EmpDayOff UNIQUE(EmpNo,BeginTime,EndTime)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_EmpOtSure')
  CREATE TABLE [KQ_EmpOtSure]
(
    [EmpOtSureID] [varchar](36) NOT NULL,
    [EmpNo] [varchar](20) NULL,
    [SortID] [varchar](10) NULL,
    [BeginTime] [datetime] NULL,
    [EndTime] [datetime] NULL,
    [AheadHrs] [bit] NULL,
    [AheadMins] [int] NULL,
    [DeferHrs] [bit] NULL,
    [DeferMins] [int] NULL,
    [OtReason] [varchar](255) NULL,
    [OprtNo] [varchar](10) NULL,
    [OprtDate] [datetime] NULL,
    CONSTRAINT [PK_KQ_EmpOtSure] PRIMARY KEY(EmpOtSureID),
    CONSTRAINT [AK_KQ_EmpOtSure] UNIQUE(EmpNo,BeginTime,EndTime)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_EmpShift')
  CREATE TABLE KQ_EmpShift
  (
    GUID varchar(36) NOT NULL,
    EmpNo varchar(20) NOT NULL,
    EmpShiftDate datetime NOT NULL,
    ShiftNo varchar(10) NULL,
    CONSTRAINT PK_KQ_EmpShift PRIMARY KEY(GUID),
    CONSTRAINT AK_KQ_EmpShift UNIQUE(EmpNo,EmpShiftDate)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_DepShift')
  CREATE TABLE KQ_DepShift
  (
    GUID varchar(36) NOT NULL,
    DepartID varchar(20) NOT NULL,
    DepShiftDate datetime NOT NULL,
    ShiftNo varchar(10) NULL,
    CONSTRAINT PK_KQ_DepShift PRIMARY KEY(GUID),
    CONSTRAINT AK_KQ_DepShift UNIQUE(DepartID,DepShiftDate)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_KQDataFilter')
  CREATE TABLE KQ_KQDataFilter
  (
    GUID varchar(36) NOT NULL,
    EmpNo varchar(20) NOT NULL,
    KQDate datetime NOT NULL,
    KQTime int NOT NULL,
    MarkIndex int NULL,
    MacSN int NULL,
    IsInvalid bit NULL,
    [OprtNo] [varchar](10) NULL,
    [OprtDate] [datetime] NULL,
    CONSTRAINT PK_KQ_KQDataFilter PRIMARY KEY(GUID),
    CONSTRAINT AK_KQ_KQDataFilter UNIQUE(EmpNo,KQDate,KQTime)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_KQReportDay')
  CREATE TABLE KQ_KQReportDay
  (
    EmpNo varchar(20) NOT NULL,
    KQDate datetime NOT NULL,
    ShiftID varchar(20) NULL,
    TimeIn1 varchar(5) NULL,
    TimeOut1 varchar(5) NULL,
    TimeIn2 varchar(5) NULL,
    TimeOut2 varchar(5) NULL,
    TimeIn3 varchar(5) NULL,
    TimeOut3 varchar(5) NULL,
    TimeIn4 varchar(5) NULL,
    TimeOut4 varchar(5) NULL,
    TimeIn5 varchar(5) NULL,
    TimeOut5 varchar(5) NULL,
    WorkDays decimal(8,2) NULL,
    AbsentDays decimal(8,2) NULL,
    OutHrs decimal(8,2) NULL,
    LeaveDays decimal(8,2) NULL,
    WorkHrs decimal(8,2) NULL,
    OtHrs decimal(8,2) NULL,
    LateMins int NULL,
    LeaveMins int NULL,
    Remark varchar(255) NULL,
    CONSTRAINT PK_KQ_KQReportDay PRIMARY KEY(EmpNo,KQDate)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_KQReportMonth')
  CREATE TABLE KQ_KQReportMonth
  (
    KQYM varchar(6) NOT NULL,
    EmpNo varchar(20) NOT NULL,
    UpdateDate datetime NOT NULL,
    MonthDays decimal(8,2) NULL,
    SunDays decimal(8,2) NULL,
    HdDays decimal(8,2) NULL,
    WorkDays decimal(8,2) NULL,
    AbsentDays decimal(8,2) NULL,
    WorkHrs decimal(8,2) NULL,
    OtHrs decimal(8,2) NULL,
    SunHrs decimal(8,2) NULL,
    HdHrs decimal(8,2) NULL,
    LateMins int NULL,
    LateCount int NULL,
    LeaveMins int NULL,
    LeaveCount int NULL,
    NSCount int NULL,
    MidCount int NULL,
    Hrs10 decimal(8,2) NULL,
    Hrs11 decimal(8,2) NULL,
    Hrs12 decimal(8,2) NULL,
    Hrs13 decimal(8,2) NULL,
    Hrs14 decimal(8,2) NULL,
    Hrs15 decimal(8,2) NULL,
    Hrs16 decimal(8,2) NULL,
    Hrs17 decimal(8,2) NULL,
    Hrs18 decimal(8,2) NULL,
    Hrs19 decimal(8,2) NULL,
    CONSTRAINT PK_KQ_KQReportMonth PRIMARY KEY(KQYM,EmpNo)
  )
GO

IF NOT EXISTS(SELECT * FROM sysobjects WHERE name='KQ_KQReportWeek')
  CREATE TABLE KQ_KQReportWeek
  (
    KQYM varchar(8) NOT NULL,
    EmpNo varchar(20) NOT NULL,
    UpdateDate datetime NOT NULL,
    MonthDays decimal(8,2) NULL,
    SunDays decimal(8,2) NULL,
    HdDays decimal(8,2) NULL,
    WorkDays decimal(8,2) NULL,
    AbsentDays decimal(8,2) NULL,
    WorkHrs decimal(8,2) NULL,
    OtHrs decimal(8,2) NULL,
    SunHrs decimal(8,2) NULL,
    HdHrs decimal(8,2) NULL,
    LateMins int NULL,
    LateCount int NULL,
    LeaveMins int NULL,
    LeaveCount int NULL,
    NSCount int NULL,
    MidCount int NULL,
    Hrs10 decimal(8,2) NULL,
    Hrs11 decimal(8,2) NULL,
    Hrs12 decimal(8,2) NULL,
    Hrs13 decimal(8,2) NULL,
    Hrs14 decimal(8,2) NULL,
    Hrs15 decimal(8,2) NULL,
    Hrs16 decimal(8,2) NULL,
    Hrs17 decimal(8,2) NULL,
    Hrs18 decimal(8,2) NULL,
    Hrs19 decimal(8,2) NULL,
    StartDate datetime NOT NULL,
    EndDate datetime NOT NULL,
    MustDaysM decimal(8,2) NULL,
    CONSTRAINT PK_KQ_KQReportWeek PRIMARY KEY(KQYM,EmpNo)
  )
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='KQ_SuperData')
BEGIN
  CREATE TABLE KQ_SuperData(
    GUID varchar(36) NOT NULL,
    SEnrollNo bigint NULL,
    GEnrollNo bigint NULL,
    DevID smallint NULL ,
    ManID smallint NULL,
    ManName varchar(50) NULL,
    BakNo smallint NULL,
    BakName varchar(50) NULL,
    STime datetime NULL,
    OprtNo varchar(10) NULL,
    OprtDate datetime NULL,
    CONSTRAINT PK_KQ_SuperData PRIMARY KEY(GUID)
  )
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='KQ_KQReportMonthDetail')
CREATE TABLE KQ_KQReportMonthDetail
(
  KQYM varchar(6) NOT NULL,
  EmpNo varchar(20) NOT NULL,
  UpdateDate datetime NOT NULL,
  KQDate varchar(50) NULL,
  Day01 varchar(30) NULL,
  Day02 varchar(30) NULL,
  Day03 varchar(30) NULL,
  Day04 varchar(30) NULL,
  Day05 varchar(30) NULL,
  Day06 varchar(30) NULL,
  Day07 varchar(30) NULL,
  Day08 varchar(30) NULL,
  Day09 varchar(30) NULL,
  Day10 varchar(30) NULL,
  Day11 varchar(30) NULL,
  Day12 varchar(30) NULL,
  Day13 varchar(30) NULL,
  Day14 varchar(30) NULL,
  Day15 varchar(30) NULL,
  Day16 varchar(30) NULL,
  Day17 varchar(30) NULL,
  Day18 varchar(30) NULL,
  Day19 varchar(30) NULL,
  Day20 varchar(30) NULL,
  Day21 varchar(30) NULL,
  Day22 varchar(30) NULL,
  Day23 varchar(30) NULL,
  Day24 varchar(30) NULL,
  Day25 varchar(30) NULL,
  Day26 varchar(30) NULL,
  Day27 varchar(30) NULL,
  Day28 varchar(30) NULL,
  Day29 varchar(30) NULL,
  Day30 varchar(30) NULL,
  Day31 varchar(30) NULL,
  Time01 varchar(80) NULL,
  Time02 varchar(80) NULL,
  Time03 varchar(80) NULL,
  Time04 varchar(80) NULL,
  Time05 varchar(80) NULL,
  Time06 varchar(80) NULL,
  Time07 varchar(80) NULL,
  Time08 varchar(80) NULL,
  Time09 varchar(80) NULL,
  Time10 varchar(80) NULL,
  Time11 varchar(80) NULL,
  Time12 varchar(80) NULL,
  Time13 varchar(80) NULL,
  Time14 varchar(80) NULL,
  Time15 varchar(80) NULL,
  Time16 varchar(80) NULL,
  Time17 varchar(80) NULL,
  Time18 varchar(80) NULL,
  Time19 varchar(80) NULL,
  Time20 varchar(80) NULL,
  Time21 varchar(80) NULL,
  Time22 varchar(80) NULL,
  Time23 varchar(80) NULL,
  Time24 varchar(80) NULL,
  Time25 varchar(80) NULL,
  Time26 varchar(80) NULL,
  Time27 varchar(80) NULL,
  Time28 varchar(80) NULL,
  Time29 varchar(80) NULL,
  Time30 varchar(80) NULL,
  Time31 varchar(80) NULL,
  CONSTRAINT PK_KQ_KQReportMonthDetail PRIMARY KEY(KQYM,EmpNo)
)
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='MJ_SeaPersonIDCard')
CREATE TABLE MJ_SeaPersonIDCard
(
 [GUID] varchar(36) NOT NULL,
  EmpName varchar(50),
  KQDateTime datetime,
  MacSN varchar(50),
  Gender varchar(20),
  Birthday datetime,
  CardType varchar(20),
  EmpCertNo varchar(50),
  EmpAddress text,
  InOutModeID int,
  InOutModeName varchar(50),
  Temperature varchar(20) NULL,
  TemperatureAlarm bit NULL,
  Nation varchar(20),
  Remark text,
  CONSTRAINT PK_MJ_SeaPersonIDCard PRIMARY KEY([GUID]),
  CONSTRAINT AK_MJ_SeaPersonIDCard UNIQUE(MacSN,KQDateTime)
)
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='MJ_SeaPersonIDCardPhoto')
CREATE TABLE MJ_SeaPersonIDCardPhoto
(
 [GUID] varchar(36) NOT NULL,
 Photo image,
 CONSTRAINT PK_MJ_MJPeopleDocumentsPhoto PRIMARY KEY([GUID])
)
GO