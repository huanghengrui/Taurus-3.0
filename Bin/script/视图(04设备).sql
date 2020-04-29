IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VDI_MacInfo') DROP VIEW VDI_MacInfo
GO
CREATE VIEW VDI_MacInfo WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,'' AS MacStatus,a.*
    FROM DI_MacInfo a
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VDI_Power') DROP VIEW VDI_Power
GO
CREATE VIEW VDI_Power WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,a.*,b.EmpName,b.FingerNo,b.DepartID,b.DepartName,c.MacDesc,
    '['+CAST(a.SunID AS varchar)+']'+ISNULL((SELECT T1.PassTimeName FROM DI_PsssTime T1 WHERE T1.PassTimeID=a.SunID),'') AS SunName,
    '['+CAST(a.MonID AS varchar)+']'+ISNULL((SELECT T2.PassTimeName FROM DI_PsssTime T2 WHERE T2.PassTimeID=a.MonID),'') AS MonName,
    '['+CAST(a.TueID AS varchar)+']'+ISNULL((SELECT T3.PassTimeName FROM DI_PsssTime T3 WHERE T3.PassTimeID=a.TueID),'') AS TueName,
    '['+CAST(a.WedID AS varchar)+']'+ISNULL((SELECT T4.PassTimeName FROM DI_PsssTime T4 WHERE T4.PassTimeID=a.WedID),'') AS WedName,
    '['+CAST(a.ThuID AS varchar)+']'+ISNULL((SELECT T5.PassTimeName FROM DI_PsssTime T5 WHERE T5.PassTimeID=a.ThuID),'') AS ThuName,
    '['+CAST(a.FriID AS varchar)+']'+ISNULL((SELECT T6.PassTimeName FROM DI_PsssTime T6 WHERE T6.PassTimeID=a.FriID),'') AS FriName,
    '['+CAST(a.SatID AS varchar)+']'+ISNULL((SELECT T7.PassTimeName FROM DI_PsssTime T7 WHERE T7.PassTimeID=a.SatID),'') AS SatName
    FROM DI_Power a
    Left OUTER  Join DI_MacInfo c ON c.MacSN=a.MacSN
     INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
    
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VSY_MacParam') DROP VIEW VSY_MacParam
GO
CREATE VIEW VSY_MacParam WITH ENCRYPTION
AS
  SELECT *
    FROM SY_MacParam
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VDI_SeaPower') DROP VIEW VDI_SeaPower
GO
CREATE VIEW VDI_SeaPower WITH ENCRYPTION
AS
    SELECT CAST(0 AS bit) AS SelectCheck,a.*,b.EmpName,b.EmpSex,b.DepartID,b.DepartName,b.EmpHireDate,b.EmpCertNo,b.CardNo10,
    b.FingerNo,b.FingerPrivilege,b.IsAttend,b.EmpAddress,b.EmpPhoneNo,b.IsDimission,c.MacDesc  
    FROM DI_SeaPower a
    Left OUTER  Join DI_MacInfo c ON c.MacSN=a.MacSN
     INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
    
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VDI_SeaPowerDownload') DROP VIEW VDI_SeaPowerDownload
GO
CREATE VIEW VDI_SeaPowerDownload WITH ENCRYPTION
AS
    SELECT CAST(0 AS bit) AS SelectCheck,a.*,b.EmpName,b.EmpSex,b.DepartID,b.DepartName,b.EmpHireDate,b.EmpCertNo,b.CardNo10,
    b.FingerNo,b.FingerPrivilege,b.IsAttend,b.EmpAddress,b.EmpPhoneNo,b.IsDimission, b.EmpPhoto, b.EmpPhotoCount,b.EmpMemo,b.EmpPhotoImage   
    FROM DI_SeaPower a
    INNER JOIN VRS_EmpDownload b ON b.EmpNo=a.EmpNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VDI_SeaSnapShots') DROP VIEW VDI_SeaSnapShots
GO
CREATE VIEW VDI_SeaSnapShots WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck, a.*,b.MacDesc 
    FROM DI_SeaSnapShots a
      Left JOIN  DI_MacInfo b ON b.MacSN=a.MacSN
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VDI_StarPower') DROP VIEW VDI_StarPower
GO
CREATE VIEW VDI_StarPower WITH ENCRYPTION
AS
    SELECT CAST(0 AS bit) AS SelectCheck,a.*,b.EmpName,b.EmpSex,b.DepartID,b.DepartName,b.EmpHireDate,b.EmpCertNo,b.CardNo10,b.pwd,
    b.FingerNo,b.FingerPrivilege,b.IsAttend,b.EmpAddress,b.EmpPhoneNo,b.IsDimission ,c.MacDesc     
    FROM DI_StarPower a
     Left OUTER  Join DI_MacInfo c ON c.MacSN=a.MacSN
     INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
    
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VDI_StarPowerDownload') DROP VIEW VDI_StarPowerDownload
GO
CREATE VIEW VDI_StarPowerDownload WITH ENCRYPTION
AS
    SELECT CAST(0 AS bit) AS SelectCheck,a.*,b.EmpName,b.EmpSex,b.DepartID,b.DepartName,b.EmpHireDate,b.EmpCertNo,b.CardNo10,b.pwd,
    b.FingerNo,b.FingerPrivilege,b.IsAttend,b.EmpAddress,b.EmpPhoneNo,b.IsDimission,b.EmpPhoto, b.EmpPhotoCount,b.EmpMemo,b.EmpPhotoImage    
    FROM DI_StarPower a
    INNER JOIN VRS_EmpDownload b ON b.EmpNo=a.EmpNo
GO