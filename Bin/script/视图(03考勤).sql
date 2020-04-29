IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQData') DROP VIEW VKQ_KQData
GO
CREATE VIEW VKQ_KQData WITH ENCRYPTION
AS
  SELECT b.EmpNo,b.EmpName,b.DepartID,b.DepartName,a.GUID,a.KQDate,dbo.GetTimeStrEx(a.KQTime) AS KQTime,
    a.IsSignIn,a.IsInvalid,b.CardNo10,b.CardNo81,b.CardNo82,a.OprtDate,c.OprtNo,c.OprtName,a.Remark,
    a.MacSN,a.KQDate+' '+dbo.GetTimeStrEx(a.KQTime) AS KQDateTime,a.VerifyModeName,d.InOutModeName,
    a.Temperature,a.TemperatureAlarm 
    FROM KQ_KQData a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
    LEFT OUTER JOIN SY_Oprt c ON c.OprtNo=a.OprtNo
    LEFT OUTER JOIN KQ_KQDataInOutMode d ON d.InOutModeID=a.InOutModeID
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_MJData') DROP VIEW VKQ_MJData
GO
CREATE VIEW VKQ_MJData WITH ENCRYPTION
AS
  SELECT a.GUID,d.EmpName,d.EmpNo, a.KQDate,dbo.GetTimeStrEx(a.KQTime) AS KQTime,a.OprtDate,c.OprtNo,c.OprtName,a.Remark,
    a.MacSN,e.MacDesc,a.KQDate+' '+dbo.GetTimeStrEx(a.KQTime) AS KQDateTime,a.VerifyModeName,a.InOutModeID,a.InOutModeName,
    a.DoorStauts,a.IsAlarm,a.Temperature,a.TemperatureAlarm 
    FROM KQ_MJData a
    LEFT OUTER JOIN SY_Oprt c ON c.OprtNo=a.OprtNo
     LEFT OUTER JOIN RS_Emp d ON d.EmpNo=a.FingerNo
      LEFT OUTER JOIN  DI_MacInfo e ON e.MacSN=a.MacSN
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_Rule') DROP VIEW VKQ_Rule
GO
CREATE VIEW VKQ_Rule WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,*
    FROM KQ_Rule
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_RuleCalc') DROP VIEW VKQ_RuleCalc
GO
CREATE VIEW VKQ_RuleCalc WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,*
    FROM KQ_RuleCalc
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_RuleEmp') DROP VIEW VKQ_RuleEmp
GO
CREATE VIEW VKQ_RuleEmp WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,a.EmpNo,a.EmpName,a.EmpSex,a.DepartID,b.DepartName,
    a.EmpHireDate,a.EmpCertNo,a.CardNo10,a.CardNo81,a.CardNo82,a.FingerNo,a.FingerPrivilege,
    a.IsAttend,a.RuleID AS EmpRuleID,c.RuleName AS EmpRuleName,a.EmpAddress,a.EmpPhoneNo,
    a.EmpMemo,'['+a.RuleID+']'+c.RuleName AS RuleIDName
    FROM RS_Emp a
    INNER JOIN RS_Depart b ON b.DepartID=a.DepartID
    INNER JOIN KQ_Rule c ON c.RuleID=a.RuleID
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_RuleDepart') DROP VIEW VKQ_RuleDepart
GO
CREATE VIEW VKQ_RuleDepart WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,a.DepartID,a.DepartName,a.RuleID,
    '['+a.RuleID+']'+b.RuleName AS RuleIDName
    FROM RS_Depart a
    INNER JOIN KQ_Rule b ON b.RuleID=a.RuleID
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_Shift') DROP VIEW VKQ_Shift
GO
CREATE VIEW VKQ_Shift WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,*
    FROM KQ_Shift
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_ShiftRule') DROP VIEW VKQ_ShiftRule
GO
CREATE VIEW VKQ_ShiftRule WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,*
    FROM KQ_ShiftRule
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_Holiday') DROP VIEW VKQ_Holiday
GO
CREATE VIEW VKQ_Holiday WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,*
    FROM KQ_Holiday
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_EmpDayOff') DROP VIEW VKQ_EmpDayOff
GO
CREATE VIEW VKQ_EmpDayOff WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,a.*,b.EmpName,b.DepartID,b.DepartName,
    '['+c.SortID+']'+c.SortName AS SortIDName,d.OprtName
    FROM KQ_EmpDayOff a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
    INNER JOIN KQ_RuleCalc c ON c.SortID=a.SortID
    LEFT OUTER JOIN SY_Oprt d ON d.OprtNo=a.OprtNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_EmpOtSure') DROP VIEW VKQ_EmpOtSure
GO
CREATE VIEW VKQ_EmpOtSure WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,a.*,b.EmpName,b.DepartID,b.DepartName,
    '['+c.SortID+']'+c.SortName AS SortIDName,d.OprtName
    FROM KQ_EmpOtSure a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
    INNER JOIN KQ_RuleCalc c ON c.SortID=a.SortID
    LEFT OUTER JOIN SY_Oprt d ON d.OprtNo=a.OprtNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQDataFilter') DROP VIEW VKQ_KQDataFilter
GO
CREATE VIEW VKQ_KQDataFilter WITH ENCRYPTION
AS
  SELECT a.*,b.EmpName,b.DepartID,b.DepartName
    FROM KQ_KQDataFilter a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQDataFilterMark') DROP VIEW VKQ_KQDataFilterMark
GO
CREATE VIEW VKQ_KQDataFilterMark WITH ENCRYPTION
AS
   SELECT EmpNo,EmpName,DepartID,DepartName,KQDate, CASE DATEPART(w,KQDate)
      WHEN 1 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Sunday')
      WHEN 2 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Monday')
      WHEN 3 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Tuesday')
      WHEN 4 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Wednesday')
      WHEN 5 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Thursday')
      WHEN 6 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Friday')
      WHEN 7 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Saturday')
    END AS KQWeek,MAX(MarkIndex) AS RuleCount,
    MAX(CASE MarkIndex WHEN 1 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [1], 
    MAX(CASE MarkIndex WHEN 2 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [2], 
    MAX(CASE MarkIndex WHEN 3 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [3], 
    MAX(CASE MarkIndex WHEN 4 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [4], 
    MAX(CASE MarkIndex WHEN 5 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [5], 
    MAX(CASE MarkIndex WHEN 6 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [6],
    MAX(CASE MarkIndex WHEN 7 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [7],
    MAX(CASE MarkIndex WHEN 8 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [8],
    MAX(CASE MarkIndex WHEN 9 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [9],
    MAX(CASE MarkIndex WHEN 10 THEN dbo.GetTimeStr(KQTime) ELSE '' END) AS [10]
    FROM VKQ_KQDataFilter
    WHERE (MarkIndex<=10)
    GROUP BY EmpNo,EmpName,DepartID,DepartName,KQDate
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQReportDay') DROP VIEW VKQ_KQReportDay
GO
CREATE VIEW VKQ_KQReportDay WITH ENCRYPTION
AS
  SELECT a.*, b.EmpName,b.DepartID,b.DepartName,b.FingerNo,
    CASE DATEPART(w,a.KQDate)
      WHEN 1 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Sunday')
      WHEN 2 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Monday')
      WHEN 3 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Tuesday')
      WHEN 4 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Wednesday')
      WHEN 5 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Thursday')
      WHEN 6 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Friday')
      WHEN 7 THEN (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Saturday')
    END AS [WeekDay]
    FROM KQ_KQReportDay a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQReportMonth') DROP VIEW VKQ_KQReportMonth
GO
CREATE VIEW VKQ_KQReportMonth WITH ENCRYPTION
AS
  SELECT a.*,b.EmpName,b.DepartID,b.DepartName,b.FingerNo
    FROM KQ_KQReportMonth a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQReportWeek') DROP VIEW VKQ_KQReportWeek
GO
CREATE VIEW VKQ_KQReportWeek WITH ENCRYPTION
AS
  SELECT a.*,b.EmpName,b.DepartID,b.DepartName,b.FingerNo
    FROM KQ_KQReportWeek a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO


IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQReportTotal') DROP VIEW VKQ_KQReportTotal
GO
CREATE VIEW VKQ_KQReportTotal WITH ENCRYPTION
AS
  SELECT a.EmpNo,a.EmpName,a.FingerNo,a.DepartID,a.DepartName,a.KQDate,a.[WeekDay],a.ShiftID,
    a.TimeIn1+' '+a.TimeOut1+' '+a.TimeIn2+' '+a.TimeOut2+' '+a.TimeIn3+' '+a.TimeOut3+' '+
    a.TimeIn4+' '+a.TimeOut4+' '+a.TimeIn5+' '+a.TimeOut5 AS KQTime,a.WorkDays,a.AbsentDays,
    a.OutHrs,a.LeaveDays,a.WorkHrs,a.OtHrs,a.LateMins,a.LeaveMins,a.Remark,b.KQYM,
    b.MonthDays AS MonthDaysT,b.SunDays AS SunDaysT,b.HdDays AS HdDaysT,b.WorkDays AS WorkDaysT,
    b.AbsentDays AS AbsentDaysT,b.WorkHrs AS WorkHrsT,b.OtHrs AS OtHrsT,b.SunHrs AS SunHrsT,
    b.HdHrs AS HdHrsT,b.LateMins AS LateMinsT,b.LateCount AS LateCountT,b.LeaveMins AS LeaveMinsT,
    b.LeaveCount AS LeaveCountT,b.NSCount AS NSCountT,b.MidCount AS MidCountT,b.Hrs10,b.Hrs11,
    b.Hrs12,b.Hrs13,b.Hrs14,b.Hrs15,b.Hrs16,b.Hrs17,b.Hrs18,b.Hrs19,b.StartDate,b.EndDate,b.MustDaysM
    FROM VKQ_KQReportDay a
    INNER JOIN KQ_KQReportMonth b ON b.EmpNo=a.EmpNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQWeekReportTotal') DROP VIEW VKQ_KQWeekReportTotal
GO
CREATE VIEW VKQ_KQWeekReportTotal WITH ENCRYPTION
AS
  SELECT a.EmpNo,a.EmpName,a.FingerNo,a.DepartID,a.DepartName,a.KQDate,a.[WeekDay],a.ShiftID,
    a.TimeIn1+' '+a.TimeOut1+' '+a.TimeIn2+' '+a.TimeOut2+' '+a.TimeIn3+' '+a.TimeOut3+' '+
    a.TimeIn4+' '+a.TimeOut4+' '+a.TimeIn5+' '+a.TimeOut5 AS KQTime,a.WorkDays,a.AbsentDays,
    a.OutHrs,a.LeaveDays,a.WorkHrs,a.OtHrs,a.LateMins,a.LeaveMins,a.Remark,b.KQYM,
    b.MonthDays AS MonthDaysT,b.SunDays AS SunDaysT,b.HdDays AS HdDaysT,b.WorkDays AS WorkDaysT,
    b.AbsentDays AS AbsentDaysT,b.WorkHrs AS WorkHrsT,b.OtHrs AS OtHrsT,b.SunHrs AS SunHrsT,
    b.HdHrs AS HdHrsT,b.LateMins AS LateMinsT,b.LateCount AS LateCountT,b.LeaveMins AS LeaveMinsT,
    b.LeaveCount AS LeaveCountT,b.NSCount AS NSCountT,b.MidCount AS MidCountT,b.Hrs10,b.Hrs11,
    b.Hrs12,b.Hrs13,b.Hrs14,b.Hrs15,b.Hrs16,b.Hrs17,b.Hrs18,b.Hrs19,b.StartDate,b.EndDate,b.MustDaysM
    FROM VKQ_KQReportDay a
    INNER JOIN KQ_KQReportWeek b ON b.EmpNo=a.EmpNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VMJ_TemporaryData') DROP VIEW VMJ_TemporaryData
GO
CREATE VIEW VMJ_TemporaryData WITH ENCRYPTION
AS
  SELECT * FROM MJ_TemporaryData
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VMJ_OpenData') DROP VIEW VMJ_OpenData
GO
CREATE VIEW VMJ_OpenData WITH ENCRYPTION
AS
SELECT a.MacSN,b.MacDesc,a.GUID,a.InOutModeName, Convert(varchar(100),a.MJDateTime,23) AS KQDate,
case when a.KQTime is Not Null then dbo.GetTimeStrEx(a.KQTime) else Convert(varchar(100),a.MJDateTime,24) end AS KQTime, 
case when a.KQTime is Not Null then a.MJDateTime+' '+dbo.GetTimeStrEx(a.KQTime) else a.MJDateTime  end AS MJDateTime
 ,a.EmpNoOne,a.EmpNoTwo,a.EmpNoTree,a.EmpNoFour,a.EmpNoFive FROM MJ_OpenData a
  LEFT OUTER JOIN  DI_MacInfo b ON b.MacSN=a.MacSN
GO
IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VMJ_AlarmData') DROP VIEW VMJ_AlarmData
GO
CREATE VIEW VMJ_AlarmData WITH ENCRYPTION
AS
 SELECT a.GUID, a.MacSN, a.KQDate+' '+dbo.GetTimeStrEx(a.KQTime) AS AlarmTime, a.VerifyModeID,
   a.VerifyModeName AS AlarmMode,b.MacDesc
   FROM KQ_MJData a 
   LEFT OUTER JOIN  DI_MacInfo b ON b.MacSN=a.MacSN
   where a.VerifyModeID=5 OR a.VerifyModeID=6 OR a.VerifyModeID=7 OR a.VerifyModeID=8 OR a.VerifyModeID=10
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VKQ_KQReportMonthDetail') DROP VIEW VKQ_KQReportMonthDetail
GO
CREATE VIEW VKQ_KQReportMonthDetail WITH ENCRYPTION
AS
  SELECT a.*, b.EmpName,b.DepartID,b.DepartName,b.FingerNo
    FROM KQ_KQReportMonthDetail a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VMJ_SeaPersonIDCard') DROP VIEW VMJ_SeaPersonIDCard
GO
CREATE VIEW VMJ_SeaPersonIDCard WITH ENCRYPTION
AS
  SELECT a.*,b.MacDesc
   FROM MJ_SeaPersonIDCard a 
   LEFT OUTER JOIN  DI_MacInfo b ON b.MacSN=a.MacSN
GO
