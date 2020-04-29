CREATE VIEW VRS_EmpB
AS
  SELECT a.EmpNo,a.EmpName,a.EmpSex,a.DepartID,b.DepartName,a.EmpHireDate,a.EmpCertNo,a.CardNo10,a.CardNo81,a.CardNo82,a.FingerNo,
    a.FingerPrivilege,a.IsAttend,a.RuleID AS EmpRuleID,a.GZRuleID AS EmpGZRuleID,a.IsDimission,a.DimissionDate,a.DimissionReason,
    a.DimissionOprt,a.OprtNo,a.OprtDate,a.EmpAddress,a.EmpPhoneNo,a.EmpMemo,a.EmpGZ,a.GZRuleID,b.GZRuleID as DepGZRuleID,a.[PassWord] as pwd,
    a.EmpFingerCount,a.EmpFaceCount,a.EmpPWCount,a.EmpCardCount,a.EmpPalmVeinCount,a.EmpPhoto,a.EmpPhotoCount,a.EmpPhotoImage,
    a.EmpFingerCount_Star,a.EmpFaceCount_Star,a.EmpPalmVeinCount_Star,a.StartDate,a.EndDate 
    FROM RS_Emp a
    INNER JOIN RS_Depart b ON b.DepartID=a.DepartID
GO


CREATE VIEW VRS_EmpC
AS
  SELECT a.EmpNo,a.EmpName,a.EmpSex,a.DepartID,b.DepartName,a.EmpHireDate,a.EmpCertNo,a.CardNo10,a.CardNo81,a.CardNo82,a.FingerNo,
    a.FingerPrivilege,a.IsAttend,a.RuleID AS EmpRuleID,a.GZRuleID AS EmpGZRuleID,a.IsDimission,a.DimissionDate,a.DimissionReason,
    a.DimissionOprt,a.OprtNo,a.OprtDate,a.EmpAddress,a.EmpPhoneNo,a.EmpMemo,a.EmpGZ,a.GZRuleID,b.GZRuleID as DepGZRuleID,a.[PassWord] as pwd,
    a.EmpFingerCount,a.EmpFaceCount,a.EmpPWCount,a.EmpCardCount,a.EmpPalmVeinCount,a.EmpPhotoCount,
    a.EmpFingerCount_Star,a.EmpFaceCount_Star,a.EmpPalmVeinCount_Star,a.StartDate,a.EndDate 
    FROM RS_Emp a
    INNER JOIN RS_Depart b ON b.DepartID=a.DepartID
GO

CREATE VIEW VRS_EmpA
AS
  SELECT a.*,c.RuleName AS EmpRuleName
    FROM VRS_EmpC a
    LEFT OUTER JOIN KQ_Rule c ON c.RuleID=a.EmpRuleID
GO

CREATE VIEW VRS_EmpDownload
AS
  SELECT *
    FROM VRS_EmpB
GO


CREATE VIEW VRS_Emp
AS
  SELECT *
    FROM VRS_EmpA
GO

CREATE VIEW VRS_EmpFingerInfo
AS
  SELECT a.FingerFlag,a.FingerNo,a.FingerBkNo,a.FingerPWD,a.FingerData,b.FingerPrivilege,b.EmpNo,b.EmpName,b.DepartID,b.DepartName
    FROM RS_EmpFingerInfo a
    INNER JOIN VRS_Emp b ON b.FingerNo=a.FingerNo
GO

CREATE VIEW VRS_EmpDimission
AS
  SELECT *
    FROM VRS_EmpA
    WHERE IsDimission
GO
