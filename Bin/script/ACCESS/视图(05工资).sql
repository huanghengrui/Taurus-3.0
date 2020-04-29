CREATE VIEW VGZ_RuleItem
AS
  SELECT a.*,b.EmpGZ
    FROM KQ_KQReportMonth a
    LEFT OUTER JOIN RS_Emp b ON b.EmpNo=a.EmpNo
GO

CREATE VIEW VGZ_Rule
AS
  SELECT CBool(0) AS SelectCheck,*
    FROM GZ_Rule
GO

CREATE VIEW VGZ_Item1
AS
  SELECT a.*,
    (SELECT IIF(LEN(i0.RuleName)=0,'',i0.RuleName+',') FROM GZ_Rule i0 WHERE i0.RuleID=a.ItemIn0) AS InX0,
    (SELECT IIF(LEN(i1.RuleName)=0,'',i1.RuleName+',') FROM GZ_Rule i1 WHERE i1.RuleID=a.ItemIn1) AS InX1,
    (SELECT IIF(LEN(i2.RuleName)=0,'',i2.RuleName+',') FROM GZ_Rule i2 WHERE i2.RuleID=a.ItemIn2) AS InX2,
    (SELECT IIF(LEN(i3.RuleName)=0,'',i3.RuleName+',') FROM GZ_Rule i3 WHERE i3.RuleID=a.ItemIn3) AS InX3,
    (SELECT IIF(LEN(i4.RuleName)=0,'',i4.RuleName+',') FROM GZ_Rule i4 WHERE i4.RuleID=a.ItemIn4) AS InX4,
    (SELECT IIF(LEN(i5.RuleName)=0,'',i5.RuleName+',') FROM GZ_Rule i5 WHERE i5.RuleID=a.ItemIn5) AS InX5,
    (SELECT IIF(LEN(i6.RuleName)=0,'',i6.RuleName+',') FROM GZ_Rule i6 WHERE i6.RuleID=a.ItemIn6) AS InX6,
    (SELECT IIF(LEN(i7.RuleName)=0,'',i7.RuleName+',') FROM GZ_Rule i7 WHERE i7.RuleID=a.ItemIn7) AS InX7,
    (SELECT IIF(LEN(i8.RuleName)=0,'',i8.RuleName+',') FROM GZ_Rule i8 WHERE i8.RuleID=a.ItemIn8) AS InX8,
    (SELECT IIF(LEN(i9.RuleName)=0,'',i9.RuleName+',') FROM GZ_Rule i9 WHERE i9.RuleID=a.ItemIn9) AS InX9,
    (SELECT IIF(LEN(i10.RuleName)=0,'',i10.RuleName+',') FROM GZ_Rule i10 WHERE i10.RuleID=a.ItemIn10) AS InX10,
    (SELECT IIF(LEN(i11.RuleName)=0,'',i11.RuleName+',') FROM GZ_Rule i11 WHERE i11.RuleID=a.ItemIn11) AS InX11,
    (SELECT IIF(LEN(i12.RuleName)=0,'',i12.RuleName+',') FROM GZ_Rule i12 WHERE i12.RuleID=a.ItemIn12) AS InX12,
    (SELECT IIF(LEN(i13.RuleName)=0,'',i13.RuleName+',') FROM GZ_Rule i13 WHERE i13.RuleID=a.ItemIn13) AS InX13,
    (SELECT IIF(LEN(i14.RuleName)=0,'',i14.RuleName+',') FROM GZ_Rule i14 WHERE i14.RuleID=a.ItemIn14) AS InX14,
    (SELECT IIF(LEN(i15.RuleName)=0,'',i15.RuleName+',') FROM GZ_Rule i15 WHERE i15.RuleID=a.ItemIn15) AS InX15,
    (SELECT IIF(LEN(i16.RuleName)=0,'',i16.RuleName+',') FROM GZ_Rule i16 WHERE i16.RuleID=a.ItemIn16) AS InX16,
    (SELECT IIF(LEN(i17.RuleName)=0,'',i17.RuleName+',') FROM GZ_Rule i17 WHERE i17.RuleID=a.ItemIn17) AS InX17,
    (SELECT IIF(LEN(i18.RuleName)=0,'',i18.RuleName+',') FROM GZ_Rule i18 WHERE i18.RuleID=a.ItemIn18) AS InX18,
    (SELECT IIF(LEN(i19.RuleName)=0,'',i19.RuleName+',') FROM GZ_Rule i19 WHERE i19.RuleID=a.ItemIn19) AS InX19,
    (SELECT IIF(LEN(o0.RuleName)=0,'',o0.RuleName+',') FROM GZ_Rule o0 WHERE o0.RuleID=a.ItemOut0) AS OutX0,
    (SELECT IIF(LEN(o1.RuleName)=0,'',o1.RuleName+',') FROM GZ_Rule o1 WHERE o1.RuleID=a.ItemOut1) AS OutX1,
    (SELECT IIF(LEN(o2.RuleName)=0,'',o2.RuleName+',') FROM GZ_Rule o2 WHERE o2.RuleID=a.ItemOut2) AS OutX2,
    (SELECT IIF(LEN(o3.RuleName)=0,'',o3.RuleName+',') FROM GZ_Rule o3 WHERE o3.RuleID=a.ItemOut3) AS OutX3,
    (SELECT IIF(LEN(o4.RuleName)=0,'',o4.RuleName+',') FROM GZ_Rule o4 WHERE o4.RuleID=a.ItemOut4) AS OutX4,
    (SELECT IIF(LEN(o5.RuleName)=0,'',o5.RuleName+',') FROM GZ_Rule o5 WHERE o5.RuleID=a.ItemOut5) AS OutX5,
    (SELECT IIF(LEN(o6.RuleName)=0,'',o6.RuleName+',') FROM GZ_Rule o6 WHERE o6.RuleID=a.ItemOut6) AS OutX6,
    (SELECT IIF(LEN(o7.RuleName)=0,'',o7.RuleName+',') FROM GZ_Rule o7 WHERE o7.RuleID=a.ItemOut7) AS OutX7,
    (SELECT IIF(LEN(o8.RuleName)=0,'',o8.RuleName+',') FROM GZ_Rule o8 WHERE o8.RuleID=a.ItemOut8) AS OutX8,
    (SELECT IIF(LEN(o9.RuleName)=0,'',o9.RuleName+',') FROM GZ_Rule o9 WHERE o9.RuleID=a.ItemOut9) AS OutX9,
    (SELECT IIF(LEN(o10.RuleName)=0,'',o10.RuleName+',') FROM GZ_Rule o10 WHERE o10.RuleID=a.ItemOut10) AS OutX10,
    (SELECT IIF(LEN(o11.RuleName)=0,'',o11.RuleName+',') FROM GZ_Rule o11 WHERE o11.RuleID=a.ItemOut11) AS OutX11,
    (SELECT IIF(LEN(o12.RuleName)=0,'',o12.RuleName+',') FROM GZ_Rule o12 WHERE o12.RuleID=a.ItemOut12) AS OutX12,
    (SELECT IIF(LEN(o13.RuleName)=0,'',o13.RuleName+',') FROM GZ_Rule o13 WHERE o13.RuleID=a.ItemOut13) AS OutX13,
    (SELECT IIF(LEN(o14.RuleName)=0,'',o14.RuleName+',') FROM GZ_Rule o14 WHERE o14.RuleID=a.ItemOut14) AS OutX14,
    (SELECT IIF(LEN(o15.RuleName)=0,'',o15.RuleName+',') FROM GZ_Rule o15 WHERE o15.RuleID=a.ItemOut15) AS OutX15,
    (SELECT IIF(LEN(o16.RuleName)=0,'',o16.RuleName+',') FROM GZ_Rule o16 WHERE o16.RuleID=a.ItemOut16) AS OutX16,
    (SELECT IIF(LEN(o17.RuleName)=0,'',o17.RuleName+',') FROM GZ_Rule o17 WHERE o17.RuleID=a.ItemOut17) AS OutX17,
    (SELECT IIF(LEN(o18.RuleName)=0,'',o18.RuleName+',') FROM GZ_Rule o18 WHERE o18.RuleID=a.ItemOut18) AS OutX18,
    (SELECT IIF(LEN(o19.RuleName)=0,'',o19.RuleName+',') FROM GZ_Rule o19 WHERE o19.RuleID=a.ItemOut19) AS OutX19
  FROM GZ_Item a
GO

CREATE VIEW VGZ_Item2
AS
  SELECT *,
    IIF(ISNULL(InX0) OR InX0='','',InX0)+IIF(ISNULL(InX1) OR InX1='','',InX1)+IIF(ISNULL(InX2) OR InX2='','',InX2)+
    IIF(ISNULL(InX3) OR InX3='','',InX3)+IIF(ISNULL(InX4) OR InX4='','',InX4)+IIF(ISNULL(InX5) OR InX5='','',InX5)+
    IIF(ISNULL(InX6) OR InX6='','',InX6)+IIF(ISNULL(InX7) OR InX7='','',InX7)+IIF(ISNULL(InX8) OR InX8='','',InX8)+
    IIF(ISNULL(InX9) OR InX9='','',InX9)+IIF(ISNULL(InX10) OR InX10='','',InX10)+IIF(ISNULL(InX11) OR InX11='','',InX11)+
    IIF(ISNULL(InX12) OR InX12='','',InX12)+IIF(ISNULL(InX13) OR InX13='','',InX13)+IIF(ISNULL(InX14) OR InX14='','',InX14)+
    IIF(ISNULL(InX15) OR InX15='','',InX15)+IIF(ISNULL(InX16) OR InX16='','',InX16)+IIF(ISNULL(InX17) OR InX17='','',InX17)+
    IIF(ISNULL(InX18) OR InX18='','',InX18)+IIF(ISNULL(InX19) OR InX19='','',InX19) AS InA,IIF(ISNULL(OutX0) OR OutX0='','',OutX0)+
    IIF(ISNULL(OutX1) OR OutX1='','',OutX1)+IIF(ISNULL(OutX2) OR OutX2='','',OutX2)+IIF(ISNULL(OutX3) OR OutX3='','',OutX3)+
    IIF(ISNULL(OutX4) OR OutX4='','',OutX4)+IIF(ISNULL(OutX5) OR OutX5='','',OutX5)+IIF(ISNULL(OutX6) OR OutX6='','',OutX6)+
    IIF(ISNULL(OutX7) OR OutX7='','',OutX7)+IIF(ISNULL(OutX8) OR OutX8='','',OutX8)+IIF(ISNULL(OutX9) OR OutX9='','',OutX9)+
    IIF(ISNULL(OutX10) OR OutX10='','',OutX10)+IIF(ISNULL(OutX11) OR OutX11='','',OutX11)+IIF(ISNULL(OutX12) OR OutX12='','',OutX12)+
    IIF(ISNULL(OutX13) OR OutX13='','',OutX13)+IIF(ISNULL(OutX14) OR OutX14='','',OutX14)+IIF(ISNULL(OutX15) OR OutX15='','',OutX15)+
    IIF(ISNULL(OutX16) OR OutX16='','',OutX16)+IIF(ISNULL(OutX17) OR OutX17='','',OutX17)+IIF(ISNULL(OutX18) OR OutX18='','',OutX18)+
    IIF(ISNULL(OutX19) OR OutX19='','',OutX19) AS OutA
    FROM VGZ_Item1
GO

CREATE VIEW VGZ_Item
AS
  SELECT CBool(0) AS SelectCheck,ItemID,ItemName,
    IIF(ISNULL(OutA) OR OutA='','',MID(OutA,1,LEN(OutA)-1)) AS [Out],IIF(ISNULL(InA) OR InA='','',MID(InA,1,LEN(InA)-1)) AS [In]
    FROM VGZ_Item2
GO

CREATE VIEW VGZ_ItemEmpA
AS
  SELECT CBool(0) AS SelectCheck,a.EmpNo,a.EmpName,a.EmpSex,a.DepartID,b.DepartName,
    a.EmpHireDate,a.EmpCertNo,a.CardNo10,a.CardNo81,a.CardNo82,a.FingerNo,a.FingerPrivilege,
    a.IsAttend,a.GZRuleID AS EmpGZRuleID,a.EmpAddress,a.EmpPhoneNo,a.EmpMemo,a.GZRuleID
    FROM RS_Emp a
    INNER JOIN RS_Depart b ON b.DepartID=a.DepartID
GO

CREATE VIEW VGZ_ItemEmp
AS
  SELECT a.*,'['+CStr(a.EmpGZRuleID)+']'+c.ItemName AS RuleIDName,c.ItemName AS EmpRuleName
    FROM VGZ_ItemEmpA a
    INNER JOIN GZ_Item c ON c.ItemID=a.EmpGZRuleID
GO

CREATE VIEW VGZ_ItemDepart
AS
  SELECT CBool(0) AS SelectCheck,a.DepartID,a.DepartName,a.GZRuleID,
    '['+CStr(a.GZRuleID)+']'+b.ItemName AS RuleIDName
    FROM RS_Depart a
    INNER JOIN GZ_Item b ON b.ItemID=a.GZRuleID
GO

CREATE VIEW VGZ_ItemCalc
AS
  SELECT ItemId,
    (SELECT IIF(i0.IsFunction,i0.RuleFunction,i0.RuleCash) FROM GZ_Rule i0 WHERE i0.RuleID=a.ItemIn0) AS i0Item,
    (SELECT IIF(i1.IsFunction,i1.RuleFunction,i1.RuleCash) FROM GZ_Rule i1 WHERE i1.RuleID=a.ItemIn1) AS i1Item,
    (SELECT IIF(i2.IsFunction,i2.RuleFunction,i2.RuleCash) FROM GZ_Rule i2 WHERE i2.RuleID=a.ItemIn2) AS i2Item,
    (SELECT IIF(i3.IsFunction,i3.RuleFunction,i3.RuleCash) FROM GZ_Rule i3 WHERE i3.RuleID=a.ItemIn3) AS i3Item,
    (SELECT IIF(i4.IsFunction,i4.RuleFunction,i4.RuleCash) FROM GZ_Rule i4 WHERE i4.RuleID=a.ItemIn4) AS i4Item,
    (SELECT IIF(i5.IsFunction,i5.RuleFunction,i5.RuleCash) FROM GZ_Rule i5 WHERE i5.RuleID=a.ItemIn5) AS i5Item,
    (SELECT IIF(i6.IsFunction,i6.RuleFunction,i6.RuleCash) FROM GZ_Rule i6 WHERE i6.RuleID=a.ItemIn6) AS i6Item,
    (SELECT IIF(i7.IsFunction,i7.RuleFunction,i7.RuleCash) FROM GZ_Rule i7 WHERE i7.RuleID=a.ItemIn7) AS i7Item,
    (SELECT IIF(i8.IsFunction,i8.RuleFunction,i8.RuleCash) FROM GZ_Rule i8 WHERE i8.RuleID=a.ItemIn8) AS i8Item,
    (SELECT IIF(i9.IsFunction,i9.RuleFunction,i9.RuleCash) FROM GZ_Rule i9 WHERE i9.RuleID=a.ItemIn9) AS i9Item,
    (SELECT IIF(i10.IsFunction,i10.RuleFunction,i10.RuleCash) FROM GZ_Rule i10 WHERE i10.RuleID=a.ItemIn10) AS i10Item,
    (SELECT IIF(i11.IsFunction,i11.RuleFunction,i11.RuleCash) FROM GZ_Rule i11 WHERE i11.RuleID=a.ItemIn11) AS i11Item,
    (SELECT IIF(i12.IsFunction,i12.RuleFunction,i12.RuleCash) FROM GZ_Rule i12 WHERE i12.RuleID=a.ItemIn12) AS i12Item,
    (SELECT IIF(i13.IsFunction,i13.RuleFunction,i13.RuleCash) FROM GZ_Rule i13 WHERE i13.RuleID=a.ItemIn13) AS i13Item,
    (SELECT IIF(i14.IsFunction,i14.RuleFunction,i14.RuleCash) FROM GZ_Rule i14 WHERE i14.RuleID=a.ItemIn14) AS i14Item,
    (SELECT IIF(i15.IsFunction,i15.RuleFunction,i15.RuleCash) FROM GZ_Rule i15 WHERE i15.RuleID=a.ItemIn15) AS i15Item,
    (SELECT IIF(i16.IsFunction,i16.RuleFunction,i16.RuleCash) FROM GZ_Rule i16 WHERE i16.RuleID=a.ItemIn16) AS i16Item,
    (SELECT IIF(i17.IsFunction,i17.RuleFunction,i17.RuleCash) FROM GZ_Rule i17 WHERE i17.RuleID=a.ItemIn17) AS i17Item,
    (SELECT IIF(i18.IsFunction,i18.RuleFunction,i18.RuleCash) FROM GZ_Rule i18 WHERE i18.RuleID=a.ItemIn18) AS i18Item,
    (SELECT IIF(i19.IsFunction,i19.RuleFunction,i19.RuleCash) FROM GZ_Rule i19 WHERE i19.RuleID=a.ItemIn19) AS i19Item,
    (SELECT IIF(o0.IsFunction,o0.RuleFunction,o0.RuleCash) FROM GZ_Rule o0 WHERE o0.RuleID=a.ItemOut0) AS o0Item,
    (SELECT IIF(o1.IsFunction,o1.RuleFunction,o1.RuleCash) FROM GZ_Rule o1 WHERE o1.RuleID=a.ItemOut1) AS o1Item,
    (SELECT IIF(o2.IsFunction,o2.RuleFunction,o2.RuleCash) FROM GZ_Rule o2 WHERE o2.RuleID=a.ItemOut2) AS o2Item,
    (SELECT IIF(o3.IsFunction,o3.RuleFunction,o3.RuleCash) FROM GZ_Rule o3 WHERE o3.RuleID=a.ItemOut3) AS o3Item,
    (SELECT IIF(o4.IsFunction,o4.RuleFunction,o4.RuleCash) FROM GZ_Rule o4 WHERE o4.RuleID=a.ItemOut4) AS o4Item,
    (SELECT IIF(o5.IsFunction,o5.RuleFunction,o5.RuleCash) FROM GZ_Rule o5 WHERE o5.RuleID=a.ItemOut5) AS o5Item,
    (SELECT IIF(o6.IsFunction,o6.RuleFunction,o6.RuleCash) FROM GZ_Rule o6 WHERE o6.RuleID=a.ItemOut6) AS o6Item,
    (SELECT IIF(o7.IsFunction,o7.RuleFunction,o7.RuleCash) FROM GZ_Rule o7 WHERE o7.RuleID=a.ItemOut7) AS o7Item,
    (SELECT IIF(o8.IsFunction,o8.RuleFunction,o8.RuleCash) FROM GZ_Rule o8 WHERE o8.RuleID=a.ItemOut8) AS o8Item,
    (SELECT IIF(o9.IsFunction,o9.RuleFunction,o9.RuleCash) FROM GZ_Rule o9 WHERE o9.RuleID=a.ItemOut9) AS o9Item,
    (SELECT IIF(o10.IsFunction,o10.RuleFunction,o10.RuleCash) FROM GZ_Rule o10 WHERE o10.RuleID=a.ItemOut10) AS o10Item,
    (SELECT IIF(o11.IsFunction,o11.RuleFunction,o11.RuleCash) FROM GZ_Rule o11 WHERE o11.RuleID=a.ItemOut11) AS o11Item,
    (SELECT IIF(o12.IsFunction,o12.RuleFunction,o12.RuleCash) FROM GZ_Rule o12 WHERE o12.RuleID=a.ItemOut12) AS o12Item,
    (SELECT IIF(o13.IsFunction,o13.RuleFunction,o13.RuleCash) FROM GZ_Rule o13 WHERE o13.RuleID=a.ItemOut13) AS o13Item,
    (SELECT IIF(o14.IsFunction,o14.RuleFunction,o14.RuleCash) FROM GZ_Rule o14 WHERE o14.RuleID=a.ItemOut14) AS o14Item,
    (SELECT IIF(o15.IsFunction,o15.RuleFunction,o15.RuleCash) FROM GZ_Rule o15 WHERE o15.RuleID=a.ItemOut15) AS o15Item,
    (SELECT IIF(o16.IsFunction,o16.RuleFunction,o16.RuleCash) FROM GZ_Rule o16 WHERE o16.RuleID=a.ItemOut16) AS o16Item,
    (SELECT IIF(o17.IsFunction,o17.RuleFunction,o17.RuleCash) FROM GZ_Rule o17 WHERE o17.RuleID=a.ItemOut17) AS o17Item,
    (SELECT IIF(o18.IsFunction,o18.RuleFunction,o18.RuleCash) FROM GZ_Rule o18 WHERE o18.RuleID=a.ItemOut18) AS o18Item,
    (SELECT IIF(o19.IsFunction,o19.RuleFunction,o19.RuleCash) FROM GZ_Rule o19 WHERE o19.RuleID=a.ItemOut19) AS o19Item
  FROM GZ_Item a
GO

CREATE VIEW VGZ_Report
AS
  SELECT a.*,b.EmpName,b.DepartName,b.DepartID,IIF(ISNULL(b.GZRuleID),b.DepGZRuleID,b.GZRuleID) AS GZRuleID
    FROM GZ_GZReport a
    INNER JOIN VRS_Emp b ON b.EmpNo=a.EmpNo
GO