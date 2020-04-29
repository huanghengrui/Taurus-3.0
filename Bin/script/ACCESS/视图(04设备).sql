CREATE VIEW VDI_MacInfo
AS
  SELECT CBool(0) AS SelectCheck,*
    FROM DI_MacInfo
GO

CREATE VIEW VDI_PowerA
AS
  SELECT CBool(0) AS SelectCheck,a.*,b.EmpName,b.FingerNo,b.DepartID,b.DepartName,
    (SELECT T1.PassTimeName FROM DI_PsssTime T1 WHERE T1.PassTimeID=a.SunID) AS SunNa,
    (SELECT T2.PassTimeName FROM DI_PsssTime T2 WHERE T2.PassTimeID=a.MonID) AS MonNa,
    (SELECT T3.PassTimeName FROM DI_PsssTime T3 WHERE T3.PassTimeID=a.TueID) AS TueNa,
    (SELECT T4.PassTimeName FROM DI_PsssTime T4 WHERE T4.PassTimeID=a.WedID) AS WedNa,
    (SELECT T5.PassTimeName FROM DI_PsssTime T5 WHERE T5.PassTimeID=a.ThuID) AS ThuNa,
    (SELECT T6.PassTimeName FROM DI_PsssTime T6 WHERE T6.PassTimeID=a.FriID) AS FriNa,
    (SELECT T7.PassTimeName FROM DI_PsssTime T7 WHERE T7.PassTimeID=a.SatID) AS SatNa
    FROM DI_Power a
     INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
     
GO
CREATE VIEW VDI_PowerB
AS
  SELECT a.*,b.MacDesc 
   FROM VDI_PowerA a
    Left OUTER  Join DI_MacInfo b ON b.MacSN=a.MacSN 
GO

CREATE VIEW VDI_Power
AS
  SELECT *,
    '['+CStr(SunID)+']'+IIF(ISNULL(SunNa),'',SunNa) AS SunName,
    '['+CStr(MonID)+']'+IIF(ISNULL(MonNa),'',MonNa) AS MonName,
    '['+CStr(TueID)+']'+IIF(ISNULL(TueNa),'',TueNa) AS TueName,
    '['+CStr(WedID)+']'+IIF(ISNULL(WedNa),'',WedNa) AS WedName,
    '['+CStr(ThuID)+']'+IIF(ISNULL(ThuNa),'',ThuNa) AS ThuName,
    '['+CStr(FriID)+']'+IIF(ISNULL(FriNa),'',FriNa) AS FriName,
    '['+CStr(SatID)+']'+IIF(ISNULL(SatNa),'',SatNa) AS SatName
    FROM VDI_PowerB
GO

CREATE VIEW VSY_MacParam
AS
  SELECT *
    FROM SY_MacParam
GO

CREATE VIEW VDI_SeaPowerA
AS
    SELECT CBool(0) AS SelectCheck,a.*,b.EmpName,b.EmpSex,b.DepartID,b.DepartName,b.EmpHireDate,b.EmpCertNo,b.CardNo10,
    b.FingerNo,b.FingerPrivilege,b.IsAttend,b.EmpAddress,b.EmpPhoneNo,b.IsDimission    
    FROM DI_SeaPower a
     INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo  
GO

CREATE VIEW VDI_SeaPower
AS
    SELECT a.*,b.MacDesc    
    FROM VDI_SeaPowerA a
    Left OUTER  Join DI_MacInfo b ON b.MacSN=a.MacSN
GO

CREATE VIEW VDI_SeaPowerDownload
AS
    SELECT CBool(0) AS SelectCheck,a.*,b.EmpName,b.EmpSex,b.DepartID,b.DepartName,b.EmpHireDate,b.EmpCertNo,b.CardNo10,
    b.FingerNo,b.FingerPrivilege,b.IsAttend,b.EmpAddress,b.EmpPhoneNo,b.IsDimission,b.EmpPhoto, b.EmpPhotoCount,b.EmpMemo,b.EmpPhotoImage    
    FROM DI_SeaPower a
    INNER JOIN VRS_EmpDownload b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VDI_SeaSnapShots
AS
  SELECT CBool(0) AS SelectCheck, a.*,b.MacDesc 
    FROM DI_SeaSnapShots a
      LEFT JOIN  DI_MacInfo b ON b.MacSN=a.MacSN
GO

CREATE VIEW VDI_StarPowerA
AS
    SELECT CBool(0) AS SelectCheck,a.*,b.EmpName,b.EmpSex,b.DepartID,b.DepartName,b.EmpHireDate,b.EmpCertNo,b.CardNo10,b.pwd,
    b.FingerNo,b.FingerPrivilege,b.IsAttend,b.EmpAddress,b.EmpPhoneNo,b.IsDimission 
    FROM DI_StarPower a
     INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
     
GO

CREATE VIEW VDI_StarPower
AS
    SELECT a.*, b.MacDesc 
    FROM VDI_StarPowerA a
    Left OUTER  Join DI_MacInfo b ON b.MacSN=a.MacSN
GO

CREATE VIEW VDI_StarPowerDownload
AS
    SELECT CBool(0) AS SelectCheck,a.*,b.EmpName,b.EmpSex,b.DepartID,b.DepartName,b.EmpHireDate,b.EmpCertNo,b.CardNo10,b.pwd,
    b.FingerNo,b.FingerPrivilege,b.IsAttend,b.EmpAddress,b.EmpPhoneNo,b.IsDimission,b.EmpPhoto, b.EmpPhotoCount,b.EmpMemo,b.EmpPhotoImage    
    FROM DI_StarPower a
    INNER JOIN VRS_EmpDownload b ON b.EmpNo=a.EmpNo
GO