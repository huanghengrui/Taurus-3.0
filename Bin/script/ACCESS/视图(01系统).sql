CREATE VIEW VSY_Oprt
AS
  SELECT CBool(0) AS SelectCheck,OprtNo,OprtName,OprtDesc,OprtIsSys,OprtLastLoginTime
    FROM SY_Oprt
GO
CREATE VIEW [VDI_Dynamic]
AS
  SELECT CBool(0) AS SelectCheck, a.*, b.EmpName, b.FingerNo, b.DepartID, b.DepartName, b.IsDimission
	FROM DI_Dynamic AS a INNER JOIN VRS_Emp AS b ON a.EmpNo = b.EmpNo;
GO
