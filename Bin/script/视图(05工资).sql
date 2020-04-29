IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VGZ_RuleItem') DROP VIEW VGZ_RuleItem
GO
CREATE VIEW VGZ_RuleItem WITH ENCRYPTION
AS
  SELECT a.*,b.EmpGZ
    FROM KQ_KQReportMonth a
    LEFT OUTER JOIN RS_Emp b ON b.EmpNo=a.EmpNo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VGZ_Rule') DROP VIEW VGZ_Rule
GO
CREATE VIEW VGZ_Rule WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SELECTCheck,*
    FROM GZ_Rule
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VGZ_Item1') DROP VIEW VGZ_Item1
GO
CREATE VIEW VGZ_Item1 WITH ENCRYPTION
AS
  SELECT a.*,ISNULL(o0.RuleName+',','')+ISNULL(o1.RuleName+',','')+ISNULL(o2.RuleName+',','')+
    ISNULL(o3.RuleName+',','')+ISNULL(o4.RuleName+',','')+ISNULL(o5.RuleName+',','')+
    ISNULL(o6.RuleName+',','')+ISNULL(o7.RuleName+',','')+ISNULL(o8.RuleName+',','')+
    ISNULL(o9.RuleName+',','')+ISNULL(o10.RuleName+',','')+ISNULL(o11.RuleName+',','')+
    ISNULL(o12.RuleName+',','')+ISNULL(o13.RuleName+',','')+ISNULL(o14.RuleName+',','')+
    ISNULL(o15.RuleName+',','')+ISNULL(o16.RuleName+',','')+ISNULL(o17.RuleName+',','')+
    ISNULL(o18.RuleName+',','')+ISNULL(o19.RuleName+',','') AS [Out],
    ISNULL(i0.RuleName+',','')+ISNULL(i1.RuleName+',','')+ISNULL(i2.RuleName+',','')+
    ISNULL(i3.RuleName+',','')+ISNULL(i4.RuleName+',','')+ISNULL(i5.RuleName+',','')+
    ISNULL(i6.RuleName+',','')+ISNULL(i7.RuleName+',','')+ISNULL(i8.RuleName+',','')+
    ISNULL(i9.RuleName+',','')+ISNULL(i10.RuleName+',','')+ISNULL(i11.RuleName+',','')+
    ISNULL(i12.RuleName+',','')+ISNULL(i13.RuleName+',','')+ISNULL(i14.RuleName+',','')+
    ISNULL(i15.RuleName+',','')+ISNULL(i16.RuleName+',','')+ISNULL(i17.RuleName+',','')+
    ISNULL(i18.RuleName+',','')+ISNULL(i19.RuleName+',','') AS [In]
    FROM GZ_Item a
    LEFT OUTER JOIN GZ_Rule o0 ON o0.RuleID=a.ItemOut0
    LEFT OUTER JOIN GZ_Rule o1 ON o1.RuleID=a.ItemOut1
    LEFT OUTER JOIN GZ_Rule o2 ON o2.RuleID=a.ItemOut2
    LEFT OUTER JOIN GZ_Rule o3 ON o3.RuleID=a.ItemOut3
    LEFT OUTER JOIN GZ_Rule o4 ON o4.RuleID=a.ItemOut4
    LEFT OUTER JOIN GZ_Rule o5 ON o5.RuleID=a.ItemOut5
    LEFT OUTER JOIN GZ_Rule o6 ON o6.RuleID=a.ItemOut6
    LEFT OUTER JOIN GZ_Rule o7 ON o7.RuleID=a.ItemOut7
    LEFT OUTER JOIN GZ_Rule o8 ON o8.RuleID=a.ItemOut8
    LEFT OUTER JOIN GZ_Rule o9 ON o9.RuleID=a.ItemOut9
    LEFT OUTER JOIN GZ_Rule o10 ON o10.RuleID=a.ItemOut10
    LEFT OUTER JOIN GZ_Rule o11 ON o11.RuleID=a.ItemOut11
    LEFT OUTER JOIN GZ_Rule o12 ON o12.RuleID=a.ItemOut12
    LEFT OUTER JOIN GZ_Rule o13 ON o13.RuleID=a.ItemOut13
    LEFT OUTER JOIN GZ_Rule o14 ON o14.RuleID=a.ItemOut14
    LEFT OUTER JOIN GZ_Rule o15 ON o15.RuleID=a.ItemOut15
    LEFT OUTER JOIN GZ_Rule o16 ON o16.RuleID=a.ItemOut16
    LEFT OUTER JOIN GZ_Rule o17 ON o17.RuleID=a.ItemOut17
    LEFT OUTER JOIN GZ_Rule o18 ON o18.RuleID=a.ItemOut18
    LEFT OUTER JOIN GZ_Rule o19 ON o19.RuleID=a.ItemOut19
    LEFT OUTER JOIN GZ_Rule i0 ON i0.RuleID=a.ItemIn0
    LEFT OUTER JOIN GZ_Rule i1 ON i1.RuleID=a.ItemIn1
    LEFT OUTER JOIN GZ_Rule i2 ON i2.RuleID=a.ItemIn2
    LEFT OUTER JOIN GZ_Rule i3 ON i3.RuleID=a.ItemIn3
    LEFT OUTER JOIN GZ_Rule i4 ON i4.RuleID=a.ItemIn4
    LEFT OUTER JOIN GZ_Rule i5 ON i5.RuleID=a.ItemIn5
    LEFT OUTER JOIN GZ_Rule i6 ON i6.RuleID=a.ItemIn6
    LEFT OUTER JOIN GZ_Rule i7 ON i7.RuleID=a.ItemIn7
    LEFT OUTER JOIN GZ_Rule i8 ON i8.RuleID=a.ItemIn8
    LEFT OUTER JOIN GZ_Rule i9 ON i9.RuleID=a.ItemIn9
    LEFT OUTER JOIN GZ_Rule i10 ON i10.RuleID=a.ItemIn10
    LEFT OUTER JOIN GZ_Rule i11 ON i11.RuleID=a.ItemIn11
    LEFT OUTER JOIN GZ_Rule i12 ON i12.RuleID=a.ItemIn12
    LEFT OUTER JOIN GZ_Rule i13 ON i13.RuleID=a.ItemIn13
    LEFT OUTER JOIN GZ_Rule i14 ON i14.RuleID=a.ItemIn14
    LEFT OUTER JOIN GZ_Rule i15 ON i15.RuleID=a.ItemIn15
    LEFT OUTER JOIN GZ_Rule i16 ON i16.RuleID=a.ItemIn16
    LEFT OUTER JOIN GZ_Rule i17 ON i17.RuleID=a.ItemIn17
    LEFT OUTER JOIN GZ_Rule i18 ON i18.RuleID=a.ItemIn18
    LEFT OUTER JOIN GZ_Rule i19 ON i19.RuleID=a.ItemIn19
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VGZ_Item') DROP VIEW VGZ_Item
GO
CREATE VIEW VGZ_Item WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SELECTCheck,ItemID,ItemName,ISNULL(SUBSTRING([Out],0,LEN([Out])),'') AS [Out],
    ISNULL(SUBSTRING([In],0,len([In])),'') AS [In]
    FROM VGZ_Item1
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VGZ_ItemEmpA') DROP VIEW VGZ_ItemEmpA
GO
CREATE VIEW VGZ_ItemEmpA WITH ENCRYPTION
AS
    SELECT CAST(0 AS bit) AS SELECTCheck,a.EmpNo,a.EmpName,a.EmpSex,a.DepartID,b.DepartName,
    a.EmpHireDate,a.EmpCertNo,a.CardNo10,a.CardNo81,a.CardNo82,a.FingerNo,a.FingerPrivilege,
    a.IsAttend,a.GZRuleID AS EmpGZRuleID,a.EmpAddress,a.EmpPhoneNo,a.EmpMemo,a.GZRuleID
    FROM RS_Emp a
    INNER JOIN RS_Depart b ON b.DepartID=a.DepartID
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VGZ_ItemEmp') DROP VIEW VGZ_ItemEmp
GO
CREATE VIEW VGZ_ItemEmp WITH ENCRYPTION
AS
	SELECT a.*,'['+convert(varchar,a.EmpGZRuleID)+']'+c.ItemName AS RuleIDName,c.ItemName AS EmpRuleName
    FROM VGZ_ItemEmpA a
    INNER JOIN GZ_Item c ON c.ItemID=a.EmpGZRuleID
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VGZ_ItemDepart') DROP VIEW VGZ_ItemDepart
GO
CREATE VIEW VGZ_ItemDepart WITH ENCRYPTION
AS
  SELECT CAST(0 AS bit) AS SELECTCheck,a.DepartID,a.DepartName,a.GZRuleID,
    '['+convert(varchar,a.GZRuleID)+']'+b.ItemName AS RuleIDName
    FROM RS_Depart a
    INNER JOIN GZ_Item b ON b.ItemID=a.GZRuleID
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='VGZ_Report') DROP VIEW VGZ_Report
GO
CREATE VIEW VGZ_Report WITH ENCRYPTION
AS
  SELECT a.*,b.EmpName,b.DepartName,b.DepartID,ISNULL(b.GZRuleID,b.DepGZRuleID) AS GZRuleID
    FROM GZ_GZReport a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO