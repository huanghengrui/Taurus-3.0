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
    RuleReadLeave,RuleReadWorkHrs,RuleNSAllowTimeS,RuleNSAllowTimeL) VALUES('R0001','Reglas regualres',5,10,10,30,30,30,1,30,1,30,0,1,1,1,1,1,1,0,0,0,0,0,'','')
END
GO

IF NOT EXISTS(SELECT * FROM KQ_RuleCalc)
BEGIN
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A001','Asistencia Regular',0,'Regulars',NULL,'',30,15,30,1,1,1,1)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A011','Regular Overtime',1,'OT Type',1,'Regular',30,15,30,1,1,1,1)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A012','Weekend Overtime',1,'OT Type',2,'Weekend',30,15,30,1,1,1,1)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A013','Holiday Overtime',1,'OT Type',3,'Holiday',30,15,30,1,1,1,1)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A021','Sick Leave',2,'Leaves',NULL,'',30,15,30,1,1,1,1)
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A022','Personal Leave',2,'Leaves',NULL,'',30,15,30,1,1,1,1)
END
GO

IF NOT EXISTS(SELECT * FROM SY_IDName)
BEGIN
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','AbsentDays','Abset')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','CalcHour','Work Hrs Calculation')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Days','Day')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Error','Error')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Hour','Hour')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoCard','Punch Free')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoOffice','Not Enrolled')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoPuchCard','Absent')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoRule','Attendance Rule Not Exist')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoShift','No chedule')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','OtHrs','Overtime')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','OutHrs','Leave')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','PubRest','Holiday')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','RegHrs','Leave')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Rest','Off')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','ShiftNotE','Shift not exist')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','WeekLast','Weekend')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Sunday','Sunday')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Monday','Monday')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Tuesday','Tuesday')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Wednesday','Wednesday')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Thursday','Thursday')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Friday','Friday')
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Saturday','Saturday')
END
GO

IF NOT EXISTS(SELECT * FROM RS_Depart)
BEGIN
  INSERT INTO RS_Depart(DepartID,DepartName,DepartUpID,DepartMemo) VALUES('0001','Company','','')
END
GO

IF NOT EXISTS(SELECT * FROM KQ_Shift)
BEGIN
  INSERT INTO KQ_Shift(ShiftID,ShiftName,WorkHours,OverHours,IsAuto,ShiftAhead1,ShiftDefer1,SigninTime1,SignoutTime1,Signin1,Signout1,SortID1,Drift1,
    ShiftAhead2,ShiftDefer2,SigninTime2,SignoutTime2,Signin2,Signout2,SortID2,Drift2,ShiftAhead3,ShiftDefer3,SigninTime3,SignoutTime3,Signin3,Signout3,
    SortID3,Drift3,ShiftAhead4,ShiftDefer4,SigninTime4,SignoutTime4,Signin4,Signout4,SortID4,Drift4,ShiftAhead5,ShiftDefer5,SigninTime5,SignoutTime5,
    Signin5,Signout5,SortID5,Drift5) VALUES('001','Default Shift',7.5,0,0,120,30,'08:30','12:00',1,1,'A001',0,30,360,'13:30','17:30',1,1,'A001',0,0,0,'',
    '',0,0,'',0,0,0,'','',0,0,'',0,0,0,'','',0,0,'',0)
  INSERT INTO KQ_ShiftDepart(ShiftID,DepartID) VALUES('001','0001')
END
GO

IF NOT EXISTS(SELECT * FROM SY_Oprt)
BEGIN
  INSERT INTO SY_Oprt(OprtNo,OprtName,OprtPWD,OprtDesc,OprtIsSys,OprtLastLoginTime) VALUES('ADMIN','Admin','','',1,getdate())
END
GO

IF NOT EXISTS(SELECT * FROM DI_MacInfo)
BEGIN
  INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD,MacDesc,ParamInfo)
    VALUES(1,4,'','USB','','','','','')
  INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD,MacDesc,ParamInfo)
    VALUES(2,4,'','LAN','192.168.1.100','5005','','','')
END
GO
