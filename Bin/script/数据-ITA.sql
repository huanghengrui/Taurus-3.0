IF NOT EXISTS(SELECT * FROM DBVersion)
BEGIN
  INSERT INTO DBVersion(DBVer,DBDate,AppVer) VALUES(1,'2014-07-01','')
END
GO

IF NOT EXISTS(SELECT * FROM SY_Config WHERE [ID]='SystemRegister' AND [Key]='BasicName')
BEGIN
  INSERT INTO SY_Config([ID],[Key],Value) VALUES('SystemRegister','BasicName','355FFB2079')
END
GO

IF NOT EXISTS(SELECT * FROM KQ_Rule)
BEGIN
  INSERT INTO KQ_Rule(RuleID,RuleName,RuleLateIgnore,RuleLeaveIgnore,RuleDupLimit,RuleLateLeaveCalHrs,RuleLateHrs,RuleLeaveHrs,RuleAheadHrs,RuleAheadMins,
    RuleDeferHrs,RuleDeferMins,RuleSunday,RuleMonday,RuleTuesday,RuleWednesday,RuleThursday,RuleFriday,RuleSaturday,RuleNoRule,RuleRestDays,RuleReadLate,
    RuleReadLeave,RuleReadWorkHrs,RuleNSAllowTimeS,RuleNSAllowTimeL) VALUES('R0001','普通规则',5,5,10,30,120,120,0,30,0,30,1,1,1,1,1,1,1,0,0,0,0,0,'','')
END
GO

IF NOT EXISTS(SELECT * FROM KQ_RuleCalc)
BEGIN
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A001','正常出勤',0,'普通类别',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A011','平时加班',1,'加班类别',1,'平时',30,15,30,1,1,1,1)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A012','周未加班',1,'加班类别',2,'周未',30,15,30,1,1,1,1)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A013','公休加班',1,'加班类别',3,'公休',30,15,30,1,1,1,1)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A021','病假',2,'请假类别',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A022','事假',2,'请假类别',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL)
END
GO

IF NOT EXISTS(SELECT * FROM SY_IDName)
BEGIN
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','AbsentDays','缺勤')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','CalcHour','计工时')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Days','天')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Error','错误')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Hour','小时')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoCard','免卡')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoOffice','未入职')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoPuchCard','未打卡')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoRule','考勤规则不存在')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoShift','未排班')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','OtHrs','加班')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','OutHrs','外出')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','PubRest','公休')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','RegHrs','请假')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Rest','休息')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','ShiftNotE','班次不存在')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','WeekLast','周末')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Sunday','日')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Monday','一')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Tuesday','二')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Wednesday','三')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Thursday','四')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Friday','五')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Saturday','六')
END
GO

IF NOT EXISTS(SELECT * FROM RS_Depart)
BEGIN
  INSERT INTO RS_Depart(DepartID,DepartName,DepartUpID,DepartMemo) VALUES('0001','公司','','')
END
GO

IF NOT EXISTS(SELECT * FROM KQ_Shift)
BEGIN
  INSERT INTO KQ_Shift(ShiftID,ShiftName,WorkHours,OverHours,IsAuto,ShiftAhead1,ShiftDefer1,SigninTime1,SignoutTime1,Signin1,Signout1,SortID1,Drift1,
    ShiftAhead2,ShiftDefer2,SigninTime2,SignoutTime2,Signin2,Signout2,SortID2,Drift2,ShiftAhead3,ShiftDefer3,SigninTime3,SignoutTime3,Signin3,Signout3,
    SortID3,Drift3,ShiftAhead4,ShiftDefer4,SigninTime4,SignoutTime4,Signin4,Signout4,SortID4,Drift4,ShiftAhead5,ShiftDefer5,SigninTime5,SignoutTime5,
    Signin5,Signout5,SortID5,Drift5) VALUES('001','默认班次',7.5,0,0,120,30,'08:30','12:00',1,1,'A001',0,30,360,'13:30','17:30',1,1,'A001',0,0,0,'',
    '',0,0,'',0,0,0,'','',0,0,'',0,0,0,'','',0,0,'',0)
  INSERT INTO KQ_ShiftDepart(ShiftID,DepartID) VALUES('001','0001')
END
GO

IF NOT EXISTS(SELECT * FROM SY_Oprt)
BEGIN
  INSERT INTO SY_Oprt(OprtNo,OprtName,OprtPWD,OprtDesc,OprtIsSys,OprtLastLoginTime) VALUES('ADMIN','系统管理员','','',1,getdate())
END
GO

IF NOT EXISTS(SELECT * FROM DI_MacInfo)
BEGIN
  INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD,MacDesc,ParamInfo)
    VALUES('1',4,'','USB','','','','','')
  INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD,MacDesc,ParamInfo)
    VALUES('2',4,'','LAN','192.168.1.100','5005','','','')
END
GO
