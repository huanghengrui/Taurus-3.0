IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PGZ_CalcRule') DROP PROCEDURE PGZ_CalcRule
GO
CREATE PROCEDURE PGZ_CalcRule(@EmpNo varchar(20),@Rule varchar(255),@YM varchar(6),@Ret decimal(16,2) output) WITH ENCRYPTION AS
  DECLARE @sql nvarchar(4000)
  DECLARE @sum numeric

  IF ISNUMERIC(@Rule)<>1
  BEGIN
    SET @sql='SELECT @sum='+@Rule+' FROM VGZ_RuleItem WHERE EmpNo=@EmpNo AND KQYM=@YM'
    EXEC sp_EXECutesql @sql,N'@sum numeric out,@Rule varchar(255),@EmpNo varchar(20),@YM varchar(6)',@sum out,@Rule,@EmpNo,@YM
    SET @Ret=CAST(@sum as decimal(16,2))
  END
  ELSE
    SET @Ret=CAST(@Rule as decimal(16,2))
  IF @Ret IS NULL SET @Ret=0
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PGZ_Calc') DROP PROCEDURE PGZ_Calc
GO
CREATE PROCEDURE PGZ_Calc(@EmpNo varchar(20),@YM varchar(6)) WITH ENCRYPTION AS
  DECLARE @GZItemID varchar(10)
  DECLARE @EmpGZ decimal(16,2)
  DECLARE @DepartName varchar(50)
  DECLARE @EmpName varchar(50)
  DECLARE @DepartID varchar(20)
  DECLARE @ItemIn0 varchar(255)
  DECLARE @ItemIn1 varchar(255)
  DECLARE @ItemIn2 varchar(255)
  DECLARE @ItemIn3 varchar(255)
  DECLARE @ItemIn4 varchar(255)
  DECLARE @ItemIn5 varchar(255)
  DECLARE @ItemIn6 varchar(255)
  DECLARE @ItemIn7 varchar(255)
  DECLARE @ItemIn8 varchar(255)
  DECLARE @ItemIn9 varchar(255)
  DECLARE @ItemIn10 varchar(255)
  DECLARE @ItemIn11 varchar(255)
  DECLARE @ItemIn12 varchar(255)
  DECLARE @ItemIn13 varchar(255)
  DECLARE @ItemIn14 varchar(255)
  DECLARE @ItemIn15 varchar(255)
  DECLARE @ItemIn16 varchar(255)
  DECLARE @ItemIn17 varchar(255)
  DECLARE @ItemIn18 varchar(255)
  DECLARE @ItemIn19 varchar(255)
  DECLARE @ItemOut0 varchar(255)
  DECLARE @ItemOut1 varchar(255)
  DECLARE @ItemOut2 varchar(255)
  DECLARE @ItemOut3 varchar(255)
  DECLARE @ItemOut4 varchar(255)
  DECLARE @ItemOut5 varchar(255)
  DECLARE @ItemOut6 varchar(255)
  DECLARE @ItemOut7 varchar(255)
  DECLARE @ItemOut8 varchar(255)
  DECLARE @ItemOut9 varchar(255)
  DECLARE @ItemOut10 varchar(255)
  DECLARE @ItemOut11 varchar(255)
  DECLARE @ItemOut12 varchar(255)
  DECLARE @ItemOut13 varchar(255)
  DECLARE @ItemOut14 varchar(255)
  DECLARE @ItemOut15 varchar(255)
  DECLARE @ItemOut16 varchar(255)
  DECLARE @ItemOut17 varchar(255)
  DECLARE @ItemOut18 varchar(255)
  DECLARE @ItemOut19 varchar(255)
  DECLARE @in0 decimal(16,2)
  DECLARE @in1 decimal(16,2)
  DECLARE @in2 decimal(16,2)
  DECLARE @in3 decimal(16,2)
  DECLARE @in4 decimal(16,2)
  DECLARE @in5 decimal(16,2)
  DECLARE @in6 decimal(16,2)
  DECLARE @in7 decimal(16,2)
  DECLARE @in8 decimal(16,2)
  DECLARE @in9 decimal(16,2)
  DECLARE @in10 decimal(16,2)
  DECLARE @in11 decimal(16,2)
  DECLARE @in12 decimal(16,2)
  DECLARE @in13 decimal(16,2)
  DECLARE @in14 decimal(16,2)
  DECLARE @in15 decimal(16,2)
  DECLARE @in16 decimal(16,2)
  DECLARE @in17 decimal(16,2)
  DECLARE @in18 decimal(16,2)
  DECLARE @in19 decimal(16,2)
  DECLARE @Out0 decimal(16,2)
  DECLARE @Out1 decimal(16,2)
  DECLARE @Out2 decimal(16,2)
  DECLARE @Out3 decimal(16,2)
  DECLARE @Out4 decimal(16,2)
  DECLARE @Out5 decimal(16,2)
  DECLARE @Out6 decimal(16,2)
  DECLARE @Out7 decimal(16,2)
  DECLARE @Out8 decimal(16,2)
  DECLARE @Out9 decimal(16,2)
  DECLARE @Out10 decimal(16,2)
  DECLARE @Out11 decimal(16,2)
  DECLARE @Out12 decimal(16,2)
  DECLARE @Out13 decimal(16,2)
  DECLARE @Out14 decimal(16,2)
  DECLARE @Out15 decimal(16,2)
  DECLARE @Out16 decimal(16,2)
  DECLARE @Out17 decimal(16,2)
  DECLARE @Out18 decimal(16,2)
  DECLARE @Out19 decimal(16,2)
  DECLARE @Sum decimal(16,2)
 
  IF EXISTS(SELECT * FROM GZ_GZReport WHERE EmpNo=@EmpNo AND KQYM=@YM AND IsFreeze=1) RETURN
  DELETE FROM GZ_GZReport WHERE EmpNo=@EmpNo AND KQYM=@YM
  SELECT @DepartID=DepartID FROM VRS_Emp WHERE EmpNo=@EmpNo
  SELECT @GZItemID=GZRuleID,@EmpGZ=EmpGZ FROM RS_Emp WHERE EmpNo=@EmpNo
  IF @GZItemID IS NULL SET @GZItemID=''
  IF @EmpGZ IS NULL SET @EmpGZ=0
  IF @GZItemID='' SELECT @GZItemID=GZRuleID FROM RS_Depart WHERE DepartID=@DepartID
  IF @GZItemID IS NULL SET @GZItemID=''
  SELECT @Sum=@EmpGZ
  SELECT @ItemIn0=ISNULL((CASE i0.IsFunction WHEN 0 THEN CAST(i0.RuleCash as varchar(24)) WHEN 1 THEN i0.RuleFunction end),NULL),
         @ItemIn1=ISNULL((CASE i1.IsFunction WHEN 0 THEN CAST(i1.RuleCash as varchar(24)) WHEN 1 THEN i1.RuleFunction end),NULL),
         @ItemIn2=ISNULL((CASE i2.IsFunction WHEN 0 THEN CAST(i2.RuleCash as varchar(24)) WHEN 1 THEN i2.RuleFunction end),NULL),
         @ItemIn3=ISNULL((CASE i3.IsFunction WHEN 0 THEN CAST(i3.RuleCash as varchar(24)) WHEN 1 THEN i3.RuleFunction end),NULL),
         @ItemIn4=ISNULL((CASE i4.IsFunction WHEN 0 THEN CAST(i4.RuleCash as varchar(24)) WHEN 1 THEN i4.RuleFunction end),NULL),
         @ItemIn5=ISNULL((CASE i5.IsFunction WHEN 0 THEN CAST(i5.RuleCash as varchar(24)) WHEN 1 THEN i5.RuleFunction end),NULL),
         @ItemIn6=ISNULL((CASE i6.IsFunction WHEN 0 THEN CAST(i6.RuleCash as varchar(24)) WHEN 1 THEN i6.RuleFunction end),NULL),
         @ItemIn7=ISNULL((CASE i7.IsFunction WHEN 0 THEN CAST(i7.RuleCash as varchar(24)) WHEN 1 THEN i7.RuleFunction end),NULL),
         @ItemIn8=ISNULL((CASE i8.IsFunction WHEN 0 THEN CAST(i8.RuleCash as varchar(24)) WHEN 1 THEN i8.RuleFunction end),NULL),
         @ItemIn9=ISNULL((CASE i9.IsFunction WHEN 0 THEN CAST(i9.RuleCash as varchar(24)) WHEN 1 THEN i9.RuleFunction end),NULL),
         @ItemIn10=ISNULL((CASE i10.IsFunction WHEN 0 THEN CAST(i10.RuleCash as varchar(24)) WHEN 1 THEN i10.RuleFunction end),NULL),
         @ItemIn11=ISNULL((CASE i11.IsFunction WHEN 0 THEN CAST(i11.RuleCash as varchar(24)) WHEN 1 THEN i11.RuleFunction end),NULL),
         @ItemIn12=ISNULL((CASE i12.IsFunction WHEN 0 THEN CAST(i12.RuleCash as varchar(24)) WHEN 1 THEN i12.RuleFunction end),NULL),
         @ItemIn13=ISNULL((CASE i13.IsFunction WHEN 0 THEN CAST(i13.RuleCash as varchar(24)) WHEN 1 THEN i13.RuleFunction end),NULL),
         @ItemIn14=ISNULL((CASE i14.IsFunction WHEN 0 THEN CAST(i14.RuleCash as varchar(24)) WHEN 1 THEN i14.RuleFunction end),NULL),
         @ItemIn15=ISNULL((CASE i15.IsFunction WHEN 0 THEN CAST(i15.RuleCash as varchar(24)) WHEN 1 THEN i15.RuleFunction end),NULL),
         @ItemIn16=ISNULL((CASE i16.IsFunction WHEN 0 THEN CAST(i16.RuleCash as varchar(24)) WHEN 1 THEN i16.RuleFunction end),NULL),
         @ItemIn17=ISNULL((CASE i17.IsFunction WHEN 0 THEN CAST(i17.RuleCash as varchar(24)) WHEN 1 THEN i17.RuleFunction end),NULL),
         @ItemIn18=ISNULL((CASE i18.IsFunction WHEN 0 THEN CAST(i18.RuleCash as varchar(24)) WHEN 1 THEN i18.RuleFunction end),NULL),
         @ItemIn19=ISNULL((CASE i19.IsFunction WHEN 0 THEN CAST(i19.RuleCash as varchar(24)) WHEN 1 THEN i19.RuleFunction end),NULL),
         @ItemOut0=ISNULL((CASE o0.IsFunction WHEN 0 THEN CAST(o0.RuleCash as varchar(24)) WHEN 1 THEN o0.RuleFunction end),NULL),
         @ItemOut1=ISNULL((CASE o1.IsFunction WHEN 0 THEN CAST(o1.RuleCash as varchar(24)) WHEN 1 THEN o1.RuleFunction end),NULL),
         @ItemOut2=ISNULL((CASE o2.IsFunction WHEN 0 THEN CAST(o2.RuleCash as varchar(24)) WHEN 1 THEN o2.RuleFunction end),NULL),
         @ItemOut3=ISNULL((CASE o3.IsFunction WHEN 0 THEN CAST(o3.RuleCash as varchar(24)) WHEN 1 THEN o3.RuleFunction end),NULL),
         @ItemOut4=ISNULL((CASE o4.IsFunction WHEN 0 THEN CAST(o4.RuleCash as varchar(24)) WHEN 1 THEN o4.RuleFunction end),NULL),
         @ItemOut5=ISNULL((CASE o5.IsFunction WHEN 0 THEN CAST(o5.RuleCash as varchar(24)) WHEN 1 THEN o5.RuleFunction end),NULL),
         @ItemOut6=ISNULL((CASE o6.IsFunction WHEN 0 THEN CAST(o6.RuleCash as varchar(24)) WHEN 1 THEN o6.RuleFunction end),NULL),
         @ItemOut7=ISNULL((CASE o7.IsFunction WHEN 0 THEN CAST(o7.RuleCash as varchar(24)) WHEN 1 THEN o7.RuleFunction end),NULL),
         @ItemOut8=ISNULL((CASE o8.IsFunction WHEN 0 THEN CAST(o8.RuleCash as varchar(24)) WHEN 1 THEN o8.RuleFunction end),NULL),
         @ItemOut9=ISNULL((CASE o9.IsFunction WHEN 0 THEN CAST(o9.RuleCash as varchar(24)) WHEN 1 THEN o9.RuleFunction end),NULL),
         @ItemOut10=ISNULL((CASE o10.IsFunction WHEN 0 THEN CAST(o10.RuleCash as varchar(24)) WHEN 1 THEN o10.RuleFunction end),NULL),
         @ItemOut11=ISNULL((CASE o11.IsFunction WHEN 0 THEN CAST(o11.RuleCash as varchar(24)) WHEN 1 THEN o11.RuleFunction end),NULL),
         @ItemOut12=ISNULL((CASE o12.IsFunction WHEN 0 THEN CAST(o12.RuleCash as varchar(24)) WHEN 1 THEN o12.RuleFunction end),NULL),
         @ItemOut13=ISNULL((CASE o13.IsFunction WHEN 0 THEN CAST(o13.RuleCash as varchar(24)) WHEN 1 THEN o13.RuleFunction end),NULL),
         @ItemOut14=ISNULL((CASE o14.IsFunction WHEN 0 THEN CAST(o14.RuleCash as varchar(24)) WHEN 1 THEN o14.RuleFunction end),NULL),
         @ItemOut15=ISNULL((CASE o15.IsFunction WHEN 0 THEN CAST(o15.RuleCash as varchar(24)) WHEN 1 THEN o15.RuleFunction end),NULL),
         @ItemOut16=ISNULL((CASE o16.IsFunction WHEN 0 THEN CAST(o16.RuleCash as varchar(24)) WHEN 1 THEN o16.RuleFunction end),NULL),
         @ItemOut17=ISNULL((CASE o17.IsFunction WHEN 0 THEN CAST(o17.RuleCash as varchar(24)) WHEN 1 THEN o17.RuleFunction end),NULL),
         @ItemOut18=ISNULL((CASE o18.IsFunction WHEN 0 THEN CAST(o18.RuleCash as varchar(24)) WHEN 1 THEN o18.RuleFunction end),NULL),
         @ItemOut19=ISNULL((CASE o19.IsFunction WHEN 0 THEN CAST(o19.RuleCash as varchar(24)) WHEN 1 THEN o19.RuleFunction end),NULL)
    FROM GZ_Item a
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
    WHERE ItemId=@GZItemID
  IF @ItemIn0 IS NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn0,@YM,@in0 output
  SET @Sum=@Sum+@in0
  IF @ItemIn1 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn1,@YM,@in1 output
  SET @Sum=@Sum+@in1
  IF(@ItemIn2 is NULL) GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn2,@YM,@in2 output
  SET @Sum=@Sum+@in2
  IF @ItemIn3 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn3,@YM,@in3 output
  SET @Sum=@Sum+@in3
  IF @ItemIn4 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn4,@YM,@in4 output
  SET @Sum=@Sum+@in4
  IF @ItemIn5 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn5,@YM,@in5 output
  SET @Sum=@Sum+@in5
  IF @ItemIn6 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn6,@YM,@in6 output
  SET @Sum=@Sum+@in6
  IF @ItemIn7 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn7,@YM,@in7 output
  SET @Sum=@Sum+@in7
  IF @ItemIn8 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn8,@YM,@in8 output
  SET @Sum=@Sum+@in8
  IF @ItemIn9 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn9,@YM,@in9 output
  SET @Sum=@Sum+@in9
  IF @ItemIn10 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn10,@YM,@in10 output
  SET @Sum=@Sum+@in10
  IF @ItemIn11 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn11,@YM,@in11 output
  SET @Sum=@Sum+@in11
  IF @ItemIn12 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn12,@YM,@in12 output
  SET @Sum=@Sum+@in12
  IF @ItemIn13 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn13,@YM,@in13 output
  SET @Sum=@Sum+@in13
  IF @ItemIn14 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn14,@YM,@in14 output
  SET @Sum=@Sum+@in14
  IF @ItemIn15 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn15,@YM,@in15 output
  SET @Sum=@Sum+@in15
  IF @ItemIn16 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn16,@YM,@in16 output
  SET @Sum=@Sum+@in16
  IF @ItemIn17 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn17,@YM,@in17 output
  SET @Sum=@Sum+@in17
  IF @ItemIn18 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn18,@YM,@in18 output
  SET @Sum=@Sum+@in18
  IF @ItemIn19 is NULL GOTO TheOut
  EXEC PGZ_CalcRule @EmpNo,@ItemIn19,@YM,@in19 output
  SET @Sum=@Sum+@in19
TheOut:
  IF @ItemOut0 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut0,@YM,@Out0 output
  SET @Sum=@Sum-@Out0
  IF(@ItemOut1 is NULL) GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut1,@YM,@Out1 output
  SET @Sum=@Sum-@Out1
  IF @ItemOut2 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut2,@YM,@Out2 output
  SET @Sum=@Sum-@Out2
  IF @ItemOut3 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut3,@YM,@Out3 output
  SET @Sum=@Sum-@Out3
  IF @ItemOut4 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut4,@YM,@Out4 output
  SET @Sum=@Sum-@Out4
  IF @ItemOut5 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut5,@YM,@Out5 output
  SET @Sum=@Sum-@Out5
  IF @ItemOut6 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut6,@YM,@Out6 output
  SET @Sum=@Sum-@Out6
  IF @ItemOut7 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut7,@YM,@Out7 output
  SET @Sum=@Sum-@Out7
  IF @ItemOut8 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut8,@YM,@Out8 output
  SET @Sum=@Sum-@Out8
  IF @ItemOut9 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut9,@YM,@Out9 output
  SET @Sum=@Sum-@Out9
  IF @ItemOut10 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut10,@YM,@Out10 output
  SET @Sum=@Sum-@Out10
  IF @ItemOut11 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut11,@YM,@Out11 output
  SET @Sum=@Sum-@Out11
  IF @ItemOut12 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut12,@YM,@Out12 output
  SET @Sum=@Sum-@Out12
  IF @ItemOut13 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut13,@YM,@Out13 output
  SET @Sum=@Sum-@Out13
  IF @ItemOut14 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut14,@YM,@Out14 output
  SET @Sum=@Sum-@Out14
  IF @ItemOut15 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut15,@YM,@Out15 output
  SET @Sum=@Sum-@Out15
  IF @ItemOut16 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut16,@YM,@Out16 output
  SET @Sum=@Sum-@Out16
  IF @ItemOut17 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut17,@YM,@Out17 output
  SET @Sum=@Sum-@Out17
  IF @ItemOut18 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut18,@YM,@Out18 output
  SET @Sum=@Sum-@Out18
  IF @ItemOut19 is NULL GOTO TheSave
  EXEC PGZ_CalcRule @EmpNo,@ItemOut19,@YM,@Out19 output
  SET @Sum=@Sum-@Out19
TheSave:
  INSERT INTO GZ_GZReport(KQYM,EmpNo,UpdateDate,EmpGZ,In1,In2,In3,In4,In5,In6,In7,In8,In9,In10,In11,In12,In13,In14,In15,In16,In17,In18,In19,
    In20,Out1,Out2,Out3,Out4,Out5,Out6,Out7,Out8,Out9,Out10,Out11,Out12,Out13,Out14,Out15,Out16,Out17,Out18,Out19,Out20,[SUM],IsFreeze)
    VALUES(@YM,@EmpNo,GETDATE(),@EmpGZ,@in0,@in1,@in2,@in3,@in4,@in5,@in6,@in7,@in8,@in9,@in10,@in11,@in12,@in13,@in14,@in15,@in16,@in17,
    @in18,@in19,@Out0,@Out1,@Out2,@Out3,@Out4,@Out5,@Out6,@Out7,@Out8,@Out9,@Out10,@Out11,@Out12,@Out13,@Out14,@Out15,@Out16,@Out17,@Out18,
    @Out19,@Sum,0)
GO
