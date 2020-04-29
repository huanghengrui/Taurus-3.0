DATAEXISTS SELECT * FROM DBVersion
  INSERT INTO DBVersion(DBVer,DBDate,AppVer) VALUES(1,'2014-07-01','')
GO

DATAEXISTS SELECT * FROM SY_Config WHERE [ID]='SystemRegister' AND [Key]='BasicName'
  INSERT INTO SY_Config([ID],[Key],[Value]) VALUES('SystemRegister','BasicName','355FFB2079')
GO

DATAEXISTS SELECT * FROM KQ_Rule
  INSERT INTO KQ_Rule(RuleID,RuleName,RuleLateIgnore,RuleLeaveIgnore,RuleDupLimit,RuleLateLeaveCalHrs,RuleLateHrs,RuleLeaveHrs,RuleAheadHrs,RuleAheadMins,
    RuleDeferHrs,RuleDeferMins,RuleSunday,RuleMonday,RuleTuesday,RuleWednesday,RuleThursday,RuleFriday,RuleSaturday,RuleNoRule,RuleRestDays,RuleReadLate,
    RuleReadLeave,RuleReadWorkHrs,RuleNSAllowTimeS,RuleNSAllowTimeL) VALUES('R0001','القواعد المنتظمة',5,5,10,30,120,120,0,30,0,30,1,1,1,1,1,1,1,0,0,0,0,0,'','')
GO

DATAEXISTS SELECT * FROM KQ_RuleCalc
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A001','حضور منتظم',0,'نوع منتظم',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A011','العمل الاضافي المنتظم',1,'نوع العمل الاضافي',1,'منتظم',0,0,0,1,1,1,1);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A012','عمل اضافي في عطل نهاية الاسبوع',1,'نوع العمل الاضافي',2,'عطلة نهاية الاسبوع',0,0,0,1,1,1,1);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A013','العمل الاضافي في العطل',1,'نوع العمل الاضافي',3,'العطل ',0,0,0,1,1,1,1);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A021','اجازة مرضية',2,'طلب نوع الاجازة',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A022','اجازة للاعمال',2,'طلب نوع الاجازة',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
GO

DATAEXISTS SELECT * FROM SY_IDName
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','AbsentDays','غياب');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','CalcHour','حساب ساعات العمل');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Days','يوم');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Error','خطأ');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Hour','ساعة');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoCard','بدون كرت');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoOffice','غير مسجل');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoPuchCard','غير موجود');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoRule','لايوجد قاعدة للحضور');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoShift','لايوجد جدول');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','OtHrs','عمل اضافي');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','OutHrs','اجازة');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','PubRest','عطلة');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','RegHrs','طلب اجازة');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Rest','استراحة');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','ShiftNotE','فترة العمل غير موجودة');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','WeekLast','عطلة نهاية الاسبوع');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Sunday','الاحد');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Monday','الاثنين');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Tuesday','الثلاثاء');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Wednesday','الاربعاء');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Thursday','الخميس');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Friday','الجمعة');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Saturday','السبت');
GO

DATAEXISTS SELECT * FROM RS_Depart
  INSERT INTO RS_Depart(DepartID,DepartName,DepartUpID,DepartMemo) VALUES('0001','الشركة','','')
GO

DATAEXISTS SELECT * FROM KQ_Shift
  INSERT INTO KQ_Shift(ShiftID,ShiftName,WorkHours,OverHours,IsAuto,ShiftAhead1,ShiftDefer1,SigninTime1,SignoutTime1,Signin1,Signout1,SortID1,Drift1,
    ShiftAhead2,ShiftDefer2,SigninTime2,SignoutTime2,Signin2,Signout2,SortID2,Drift2,ShiftAhead3,ShiftDefer3,SigninTime3,SignoutTime3,Signin3,Signout3,
    SortID3,Drift3,ShiftAhead4,ShiftDefer4,SigninTime4,SignoutTime4,Signin4,Signout4,SortID4,Drift4,ShiftAhead5,ShiftDefer5,SigninTime5,SignoutTime5,
    Signin5,Signout5,SortID5,Drift5) VALUES('001','فترة العمل الافتراضية',7.5,0,0,120,30,'08:30','12:00',1,1,'A001',0,30,360,'13:30','17:30',1,1,'A001',0,0,0,'',
    '',0,0,'',0,0,0,'','',0,0,'',0,0,0,'','',0,0,'',0);
  INSERT INTO KQ_ShiftDepart(ShiftID,DepartID) VALUES('001','0001');
GO

DATAEXISTS SELECT * FROM SY_Oprt
  INSERT INTO SY_Oprt(OprtNo,OprtName,OprtPWD,OprtDesc,OprtIsSys,OprtLastLoginTime) VALUES('المدير','مسؤول النظام','038CA14B7DEE0F710FD3B68AC45CFC46','',1,now())
GO

DATAEXISTS SELECT * FROM DI_MacInfo
  INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD,MacDesc,ParamInfo)
    VALUES(1,4,'','USB','','','','','');
  INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD,MacDesc,ParamInfo)
    VALUES(2,4,'','LAN','192.168.1.100','5005','','','');
GO
