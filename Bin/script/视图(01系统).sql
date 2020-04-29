IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VSY_Oprt') DROP VIEW VSY_Oprt
GO
CREATE VIEW VSY_Oprt WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,OprtNo,OprtName,OprtDesc,CAST(OprtIsSys AS bit) AS OprtIsSys,OprtLastLoginTime
    FROM SY_Oprt
GO
IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VDI_Dynamic') DROP VIEW VDI_Dynamic
GO
CREATE VIEW VDI_Dynamic WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SelectCheck,a.*,b.EmpName,b.FingerNo,b.DepartID,b.DepartName,b.IsDimission
    FROM DI_Dynamic a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO