CREATE VIEW VKQ_KQData
AS
  SELECT b.EmpNo,b.EmpName,b.DepartID,b.DepartName,a.[GUID],a.IsSignIn,a.IsInvalid,b.CardNo10,b.CardNo81,
    b.CardNo82,a.OprtDate,a.OprtNo,a.Remark,a.MacSN,a.KQDateTime,a.KQDate,a.KQTime,
    (SELECT c.OprtName FROM SY_Oprt c WHERE c.OprtNo=a.OprtNo) AS OprtName,a.VerifyModeName,
    (SELECT d.InOutModeName FROM KQ_KQDataInOutMode d WHERE d.InOutModeID=a.InOutModeID) AS InOutModeName,
    a.Temperature,a.TemperatureAlarm 
    FROM KQ_KQData a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VKQ_MJData
AS
 SELECT b.EmpNo, b.EmpName, b.DepartID, b.DepartName, a.[GUID], b.CardNo10,
  b.CardNo81, b.CardNo82, a.OprtDate, a.OprtNo, a.Remark, a.MacSN, a.KQDateTime, a.KQDate, a.KQTime, 
  (SELECT c.OprtName FROM SY_Oprt c WHERE c.OprtNo=a.OprtNo) AS OprtName,a.VerifyModeID, a.VerifyModeName,
   a.InOutModeID,a.InOutModeName, 
   (SELECT e.MacDesc FROM DI_MacInfo e WHERE e.MacSN=a.MacSN) AS MacDesc,a.DoorStauts,a.IsAlarm,
   a.Temperature,a.TemperatureAlarm 
   FROM KQ_MJData a 
     LEFT OUTER JOIN VRS_Emp b ON b.EmpNo=a.FingerNo
GO

CREATE VIEW VKQ_Rule
AS
  SELECT CBool(0) AS SelectCheck,*
    FROM KQ_Rule
GO

CREATE VIEW VKQ_RuleCalc
AS
  SELECT CBool(0) AS SelectCheck,*
    FROM KQ_RuleCalc
GO

CREATE VIEW VKQ_RuleEmpA
AS
  SELECT CBool(0) AS SelectCheck,a.EmpNo,a.EmpName,a.EmpSex,a.DepartID,b.DepartName,a.EmpHireDate,
    a.EmpCertNo,a.CardNo10,a.CardNo81,a.CardNo82,a.FingerNo,a.FingerPrivilege,a.IsAttend,
    a.RuleID AS EmpRuleID,a.EmpAddress,a.EmpPhoneNo,a.EmpMemo
    FROM RS_Emp a
    INNER JOIN RS_Depart b ON b.DepartID=a.DepartID
GO

CREATE VIEW VKQ_RuleEmp
AS
  SELECT a.*,c.RuleName AS EmpRuleName,'['+a.EmpRuleID+']'+c.RuleName AS RuleIDName
    FROM VKQ_RuleEmpA a
    INNER JOIN KQ_Rule c ON c.RuleID=a.EmpRuleID
GO

CREATE VIEW VKQ_RuleDepart
AS
  SELECT CBool(0) AS SelectCheck,a.DepartID,a.DepartName,a.RuleID,
    '['+a.RuleID+']'+b.RuleName AS RuleIDName
    FROM RS_Depart a
    INNER JOIN KQ_Rule b ON b.RuleID=a.RuleID
GO

CREATE VIEW VKQ_Shift
AS
  SELECT CBool(0) AS SelectCheck,*
    FROM KQ_Shift
GO

CREATE VIEW VKQ_ShiftRule
AS
  SELECT CBool(0) AS SelectCheck,*
    FROM KQ_ShiftRule
GO

CREATE VIEW VKQ_Holiday
AS
  SELECT CBool(0) AS SelectCheck,*
    FROM KQ_Holiday
GO

CREATE VIEW VKQ_EmpDayOffA
AS
  SELECT CBool(0) AS SelectCheck,a.*,b.EmpName,b.DepartID,b.DepartName
    FROM KQ_EmpDayOff a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VKQ_EmpDayOffB
AS
  SELECT a.*,'['+c.SortID+']'+c.SortName AS SortIDName
    FROM VKQ_EmpDayOffA a
    INNER JOIN KQ_RuleCalc c ON c.SortID=a.SortID
GO

CREATE VIEW VKQ_EmpDayOff
AS
  SELECT a.*,d.OprtName
    FROM VKQ_EmpDayOffB a
    LEFT OUTER JOIN SY_Oprt d ON d.OprtNo=a.OprtNo
GO

CREATE VIEW VKQ_EmpOtSureA
AS
  SELECT CBool(0) AS SelectCheck,a.*,b.EmpName,b.DepartID,b.DepartName
    FROM KQ_EmpOtSure a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VKQ_EmpOtSureB
AS
  SELECT a.*,'['+c.SortID+']'+c.SortName AS SortIDName
    FROM VKQ_EmpOtSureA a
    INNER JOIN KQ_RuleCalc c ON c.SortID=a.SortID
GO

CREATE VIEW VKQ_EmpOtSure
AS
  SELECT a.*,d.OprtName
    FROM VKQ_EmpOtSureB a
    LEFT OUTER JOIN SY_Oprt d ON d.OprtNo=a.OprtNo
GO

CREATE VIEW VKQ_KQDataFilter
AS
  SELECT a.*,b.EmpName,b.DepartID,b.DepartName
    FROM KQ_KQDataFilter a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VKQ_KQDataFilterMark
AS
   SELECT a.[GUID],a.EmpNo,a.KQDate,(SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]=IIF(WeekDay(a.KQDate)=1,'Sunday',
     IIF(WeekDay(a.KQDate)=2,'Monday',IIF(WeekDay(a.KQDate)=3,'Tuesday',IIF(WeekDay(a.KQDate)=4,'Wednesday',
     IIF(WeekDay(a.KQDate)=5,'Thursday',IIF(WeekDay(a.KQDate)=6,'Friday',IIF(WeekDay(a.KQDate)=7,'Saturday','')))))))) AS KQWeek,
    IIF(a.T1<>'',1,0)+IIF(a.T2<>'',1,0)+IIF(a.T3<>'',1,0)+IIF(a.T4<>'',1,0)+IIF(a.T5<>'',1,0)+IIF(a.T6<>'',1,0)+IIF(a.T7<>'',1,0)+IIF(a.T8<>'',1,0)+IIF(a.T9<>'',1,0)+IIF(a.T10<>'',1,0) as RuleCount,
    a.T1 AS [1],a.T2 AS [2],a.T3 AS [3],a.T4 AS [4],a.T5 AS [5],a.T6 AS [6],
    a.T7 AS [7],a.T8 AS [8],a.T9 AS [9],a.T10 AS [10],b.EmpName,b.DepartID,b.DepartName
    FROM KQ_KQDataFilterMark a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VKQ_KQReportDay
AS
  SELECT a.*,b.EmpName,b.DepartID,b.DepartName,b.FingerNo,
    (SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]=IIF(WeekDay(a.KQDate)=1,'Sunday',
     IIF(WeekDay(a.KQDate)=2,'Monday',IIF(WeekDay(a.KQDate)=3,'Tuesday',IIF(WeekDay(a.KQDate)=4,'Wednesday',
     IIF(WeekDay(a.KQDate)=5,'Thursday',IIF(WeekDay(a.KQDate)=6,'Friday',IIF(WeekDay(a.KQDate)=7,'Saturday',''))))))))
    AS [WeekDay]
    FROM KQ_KQReportDay a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VKQ_KQReportMonth
AS
  SELECT a.*,b.EmpName,b.DepartID,b.DepartName,b.FingerNo
    FROM KQ_KQReportMonth a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VKQ_KQReportWeek
AS
  SELECT a.*,b.EmpName,b.DepartID,b.DepartName,b.FingerNo
    FROM KQ_KQReportWeek a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VKQ_KQReportTotal
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

CREATE VIEW VKQ_KQWeekReportTotal
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

CREATE VIEW VMJ_TemporaryData
AS
  SELECT a.* FROM MJ_TemporaryData a
GO

CREATE VIEW VMJ_OpenData
AS
  SELECT a.MacSN,b.MacDesc,a.GUID,a.InOutModeName,a.MJDateTime,a.EmpNoOne,a.EmpNoTwo,a.EmpNoTree,
  a.EmpNoFour,a.EmpNoFive FROM MJ_OpenData a
  LEFT OUTER JOIN  DI_MacInfo b ON b.MacSN=a.MacSN
GO

CREATE VIEW VMJ_AlarmData
AS
  SELECT a.[GUID], a.MacSN, a.KQDateTime AS AlarmTime, a.VerifyModeID,
   a.VerifyModeName AS AlarmMode,b.MacDesc
   FROM KQ_MJData a 
   LEFT OUTER JOIN  DI_MacInfo b ON b.MacSN=a.MacSN
   where a.VerifyModeID=5 OR a.VerifyModeID=6 OR a.VerifyModeID=7 OR a.VerifyModeID=8 OR a.VerifyModeID=10
GO

CREATE VIEW VKQ_KQReportMonthDetail
AS
  SELECT a.*, b.EmpName,b.DepartID,b.DepartName,b.FingerNo
    FROM KQ_KQReportMonthDetail a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VMJ_SeaPersonIDCard
AS
  SELECT a.*,b.MacDesc
   FROM MJ_SeaPersonIDCard a 
   LEFT OUTER JOIN  DI_MacInfo b ON b.MacSN=a.MacSN
GO

