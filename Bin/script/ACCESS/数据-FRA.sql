DATAEXISTS SELECT * FROM DBVersion
  INSERT INTO DBVersion(DBVer,DBDate,AppVer) VALUES(1,'2014-07-01','')
GO

DATAEXISTS SELECT * FROM SY_Config WHERE [ID]='SystemRegister' AND [Key]='BasicName'
  INSERT INTO SY_Config([ID],[Key],[Value]) VALUES('SystemRegister','BasicName','355FFB2079')
GO

DATAEXISTS SELECT * FROM KQ_Rule
  INSERT INTO KQ_Rule(RuleID,RuleName,RuleLateIgnore,RuleLeaveIgnore,RuleDupLimit,RuleLateLeaveCalHrs,RuleLateHrs,RuleLeaveHrs,RuleAheadHrs,RuleAheadMins,
    RuleDeferHrs,RuleDeferMins,RuleSunday,RuleMonday,RuleTuesday,RuleWednesday,RuleThursday,RuleFriday,RuleSaturday,RuleNoRule,RuleRestDays,RuleReadLate,
    RuleReadLeave,RuleReadWorkHrs,RuleNSAllowTimeS,RuleNSAllowTimeL) VALUES('R0001','R¨¨gles r¨¦guli¨¨res',5,5,10,30,120,120,0,30,0,30,1,1,1,1,1,1,1,0,0,0,0,0,'','')
GO

DATAEXISTS SELECT * FROM KQ_RuleCalc
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A001','Pr¨¦sence r¨¦guli¨¨re',0,'R¨¦guliers',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A011','H S r¨¦guli¨¨res',1,'Type H S',1,'r¨¦guli¨¨res',30,15,30,1,1,1,1);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A012','Weekend H S',1,'Type H S',2,'Weekend',30,15,30,1,1,1,1);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A013','Vacances H S',1,'Type H S',3,'Vacances',30,15,30,1,1,1,1);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A021','Cong¨¦ de maladie',2,'Cong¨¦s',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
  INSERT INTO KQ_RuleCalc(SortID,SortName,CalcTypeID,CalcTypeName,OvertimeTypeID,OvertimeTypeName,Start,Tune,[Integer],WorkRate,OvertimeRate,LeaveRate,
    AbsenceRate) VALUES('A022','Cong¨¦ personnel',2,'Cong¨¦s',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL);
GO

DATAEXISTS SELECT * FROM SY_IDName
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','AbsentDays','Absent');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','CalcHour','Calcul hrs de travail');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Days','Jour');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Error','Erreur');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Hour','Heure');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoCard','Punch Free');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoOffice','Pas inscrit');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoPuchCard','Absent');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoRule','La r¨¨gle de pr¨¦sence n''existe pas');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','NoShift','Pas d''horaire');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','OtHrs','Heures suppl¨¦mentaires');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','OutHrs','Sortie');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','PubRest','Vacances');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','RegHrs','Cong¨¦');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Rest','Cong¨¦');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','ShiftNotE','Le poste n''existe pas');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','WeekLast','Weekend');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Sunday','Dimanche');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Monday','Lundi');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Tuesday','Mardi');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Wednesday','Mercredi');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Thursday','Thursday');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Friday','Vendredi');
  INSERT INTO SY_IDName([Class],[ID],[Name]) VALUES('KQ','Saturday','Samedi');
GO

DATAEXISTS SELECT * FROM RS_Depart
  INSERT INTO RS_Depart(DepartID,DepartName,DepartUpID,DepartMemo) VALUES('0001','Soci¨¦t¨¦','','')
GO

DATAEXISTS SELECT * FROM KQ_Shift
  INSERT INTO KQ_Shift(ShiftID,ShiftName,WorkHours,OverHours,IsAuto,ShiftAhead1,ShiftDefer1,SigninTime1,SignoutTime1,Signin1,Signout1,SortID1,Drift1,
    ShiftAhead2,ShiftDefer2,SigninTime2,SignoutTime2,Signin2,Signout2,SortID2,Drift2,ShiftAhead3,ShiftDefer3,SigninTime3,SignoutTime3,Signin3,Signout3,
    SortID3,Drift3,ShiftAhead4,ShiftDefer4,SigninTime4,SignoutTime4,Signin4,Signout4,SortID4,Drift4,ShiftAhead5,ShiftDefer5,SigninTime5,SignoutTime5,
    Signin5,Signout5,SortID5,Drift5) VALUES('001','D¨¦faut Majuscule ',7.5,0,0,120,30,'08:30','12:00',1,1,'A001',0,30,360,'13:30','17:30',1,1,'A001',0,0,0,'',
    '',0,0,'',0,0,0,'','',0,0,'',0,0,0,'','',0,0,'',0);
  INSERT INTO KQ_ShiftDepart(ShiftID,DepartID) VALUES('001','0001');
GO

DATAEXISTS SELECT * FROM SY_Oprt
  INSERT INTO SY_Oprt(OprtNo,OprtName,OprtPWD,OprtDesc,OprtIsSys,OprtLastLoginTime) VALUES('ADMIN','Admin','','',1,now())
GO

DATAEXISTS SELECT * FROM DI_MacInfo
  INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD,MacDesc,ParamInfo)
    VALUES(1,4,'','USB','','','','','');
  INSERT INTO DI_MacInfo(MacSN,MacTypeID,MacTypeName,MacConnType,MacIP,MacPort,MacConnPWD,MacDesc,ParamInfo)
    VALUES(2,4,'','LAN','192.168.1.100','5005','','','');
GO
