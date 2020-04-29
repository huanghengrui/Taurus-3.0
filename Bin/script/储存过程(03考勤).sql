IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_KQDataSave') DROP PROCEDURE PKQ_KQDataSave
GO
CREATE PROCEDURE PKQ_KQDataSave(@CardType tinyint,@CardNo varchar(10),@KQDate datetime,@KQTime int,@MacSN varchar(50),@OprtNo varchar(10),
  @Remark varchar(255),@VerifyModeID int,@VerifyModeName varchar(50),@InOutModeID int,@InOutModeName varchar(50),
  @Temperature varchar(20),@TemperatureAlarm bit) WITH ENCRYPTION AS
  DECLARE @EmpNo varchar(20),@GUID varchar(36)
  IF @Temperature='0' SET @Temperature=''
  IF @CardType=1
    SELECT @EmpNo=EmpNo FROM RS_Emp WHERE CardNo10=@CardNo
  ELSE IF @CardType=2
    SELECT @EmpNo=EmpNo FROM RS_Emp WHERE CardNo81=@CardNo
  ELSE IF @CardType=3
    SELECT @EmpNo=EmpNo FROM RS_Emp WHERE CardNo82=@CardNo
  ELSE IF @CardType=4
    SELECT @EmpNo=EmpNo FROM RS_Emp WHERE FingerNo=@CardNo
  IF @EmpNo IS NOT NULL AND NOT EXISTS(SELECT * FROM KQ_KQData WHERE EmpNo=@EmpNo AND
    KQDate=@KQDate AND KQTime=@KQTime)
  BEGIN
    SELECT @GUID=newid()
    INSERT INTO KQ_KQData(GUID,EmpNo,KQDate,KQTime,MacSN,IsSignIn,IsInvalid,OprtNo,OprtDate,Remark,VerifyModeID,VerifyModeName,
      InOutModeID,InOutModeName,Temperature,TemperatureAlarm) VALUES(@GUID,@EmpNo,@KQDate,@KQTime,@MacSN,0,1,@OprtNo,getdate(),@Remark,@VerifyModeID,
      @VerifyModeName,@InOutModeID,@InOutModeName,@Temperature,@TemperatureAlarm)
  END
  SELECT @GUID AS GUID
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_KQDataSaveEx') DROP PROCEDURE PKQ_KQDataSaveEx
GO
CREATE PROCEDURE PKQ_KQDataSaveEx(@EmpNo varchar(20),@KQDate datetime,@KQTime int,@Remark varchar(8000),@OprtNo varchar(10)) WITH ENCRYPTION AS
  IF NOT EXISTS(SELECT * FROM KQ_KQData WHERE EmpNo=@EmpNo AND KQDate=@KQDate AND KQTime=@KQTime)
  BEGIN
    INSERT INTO KQ_KQData(GUID,EmpNo,KQDate,KQTime,MacSN,IsSignIn,IsInvalid,OprtNo,OprtDate,Remark)
      VALUES(newid(),@EmpNo,@KQDate,@KQTime,0,1,1,@OprtNo,getdate(),@Remark)
  END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_MJDataSave') DROP PROCEDURE PKQ_MJDataSave
GO
CREATE PROCEDURE PKQ_MJDataSave(@KQDate datetime,@KQTime int,@MacSN varchar(50),@OprtNo varchar(10),@Remark varchar(255),@VerifyModeID int,
  @VerifyModeName varchar(50),@InOutModeID int,@InOutModeName varchar(50), @FingerNo bigint,@DoorStauts varchar(20),@IsAlarm bit,
  @Temperature varchar(20),@TemperatureAlarm bit) WITH ENCRYPTION AS
  DECLARE @GUID varchar(36)

  IF NOT EXISTS(SELECT * FROM KQ_MJData WHERE MacSN=@MacSN AND VerifyModeID=@VerifyModeID AND KQDate=@KQDate AND KQTime=@KQTime)
  BEGIN
    SELECT @GUID=newid()
    INSERT INTO KQ_MJData(GUID,KQDate,KQTime,MacSN,OprtNo,OprtDate,Remark,VerifyModeID,VerifyModeName,InOutModeID,InOutModeName,
    FingerNo,DoorStauts,IsAlarm,Temperature,TemperatureAlarm)
      VALUES(@GUID,@KQDate,@KQTime,@MacSN,@OprtNo,getdate(),@Remark,@VerifyModeID,@VerifyModeName,@InOutModeID,@InOutModeName,
      @FingerNo,@DoorStauts,@IsAlarm,@Temperature,@TemperatureAlarm)
  END
  SELECT @GUID AS GUID
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcDataFilter') DROP PROCEDURE PKQ_CalcDataFilter
GO
CREATE PROCEDURE PKQ_CalcDataFilter(@EmpNo varchar(20),@StartDate datetime,@EndDate datetime,@DupLimit int) WITH ENCRYPTION AS
  DECLARE @MarkIndex int
  DECLARE @GUID varchar(36)
  DECLARE @KQDate datetime
  DECLARE @KQTime int
  DECLARE @MacSN varchar(50)
  DECLARE @OprtNo varchar(10)
  DECLARE @OprtDate datetime  
  DECLARE @KQDate1 datetime
  DECLARE @KQTime1 int
  DECLARE @IsInvalid bit
  
  IF @DupLimit IS NULL SET @DupLimit=0
  SET @DupLimit=@DupLimit*60
  SELECT @StartDate=DATEADD(dd,-1,@StartDate),@EndDate=DATEADD(dd,1,@EndDate)
  SELECT @IsInvalid=0,@MarkIndex=1
  DELETE FROM KQ_KQDataFilter WHERE EmpNo=@EmpNo AND KQDate>=@StartDate AND KQDate<=@EndDate
  INSERT INTO Temp_KQ_KQData(GUID,EmpNo,KQDate,KQTime,MacSN,IsSignIn,IsInvalid,OprtNo,OprtDate,Remark)
    SELECT GUID,EmpNo,KQDate,KQTime,MacSN,IsSignIn,0,OprtNo,OprtDate,Remark FROM KQ_KQData
    WHERE EmpNo=@EmpNo AND KQDate>=@StartDate AND KQDate<=@EndDate
  DECLARE RecDataFilter CURSOR SCROLL FOR SELECT KQDate,KQTime,MacSN,OprtNo,OprtDate FROM Temp_KQ_KQData ORDER BY KQDate,KQTime
  OPEN RecDataFilter
  FETCH FIRST FROM RecDataFilter INTO @KQDate,@KQTime,@MacSN,@OprtNo,@OprtDate
  WHILE @@FETCH_STATUS=0
  BEGIN
    IF @KQDate1 IS NULL
    BEGIN
      INSERT INTO Temp_KQ_KQDataFilter(GUID,EmpNo,KQDate,KQTime,MarkIndex,MacSN,IsInvalid,OprtNo,OprtDate)
        VALUES(newid(),@EmpNo,@KQDate,@KQTime,@MarkIndex,@MacSN,@IsInvalid,@OprtNo,@OprtDate)
      SELECT @KQDate1=@KQDate,@KQTime1=@KQTime,@MarkIndex=@MarkIndex+1
    END
    ELSE IF @KQDate1=@KQDate AND ABS(@KQTime1-@KQTime)>=@DupLimit
    BEGIN
      INSERT INTO Temp_KQ_KQDataFilter(GUID,EmpNo,KQDate,KQTime,MarkIndex,MacSN,IsInvalid,OprtNo,OprtDate)
        VALUES(newid(),@EmpNo,@KQDate,@KQTime,@MarkIndex,@MacSN,@IsInvalid,@OprtNo,@OprtDate)
      SELECT @KQDate1=@KQDate,@KQTime1=@KQTime,@MarkIndex=@MarkIndex+1
    END
    ELSE IF @KQDate>@KQDate1 AND ABS(@KQTime1+86399-@KQTime)>=@DupLimit
    BEGIN
      SET @MarkIndex=1
      INSERT INTO Temp_KQ_KQDataFilter(GUID,EmpNo,KQDate,KQTime,MarkIndex,MacSN,IsInvalid,OprtNo,OprtDate)
        VALUES(newid(),@EmpNo,@KQDate,@KQTime,@MarkIndex,@MacSN,@IsInvalid,@OprtNo,@OprtDate)
      SELECT @KQDate1=@KQDate,@KQTime1=@KQTime,@MarkIndex=@MarkIndex+1
    END
    FETCH NEXT FROM RecDataFilter INTO @KQDate,@KQTime,@MacSN,@OprtNo,@OprtDate
  END
  CLOSE RecDataFilter
  DEALLOCATE RecDataFilter
  INSERT INTO KQ_KQDataFilter(GUID,EmpNo,KQDate,KQTime,MarkIndex,MacSN,IsInvalid,OprtNo,OprtDate)
    SELECT GUID,EmpNo,KQDate,KQTime,MarkIndex,MacSN,IsInvalid,OprtNo,OprtDate FROM Temp_KQ_KQDataFilter
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcFindInTime') DROP PROCEDURE PKQ_CalcFindInTime
GO
CREATE PROCEDURE PKQ_CalcFindInTime(@EmpNo varchar(20),@IsChangeMark bit,@BeginDate datetime,@BeginTimeInt int,@EndDate datetime,
  @EndTimeInt int,@KQDate datetime output,@KQTime int output) WITH ENCRYPTION AS
  DECLARE @BeginInt int,@EndInt int

  SELECT @KQDate=NULL,@KQTime=NULL
  SELECT @BeginInt=CASE WHEN @BeginTimeInt>86399 THEN @BeginTimeInt-86399
                        WHEN @BeginTimeInt<0 THEN 0-@BeginTimeInt ELSE @BeginTimeInt END
  SELECT @EndInt=CASE WHEN @EndTimeInt>86399 THEN @EndTimeInt-86399
                      WHEN @EndTimeInt<0 THEN 0-@EndTimeInt ELSE @EndTimeInt END
  IF @BeginDate<>@EndDate
    SELECT TOP 1 @KQDate=KQDate,@KQTime=KQTime FROM Temp_KQ_KQDataFilter WHERE IsInvalid=0 AND EmpNo=@EmpNo AND
      ((KQDate>=@BeginDate AND KQTime>=@BeginInt AND KQDate<=@BeginDate AND KQTime<=86399) OR
      (KQDate>=@EndDate AND KQTime>=0 AND KQDate<=@EndDate AND KQTime<=@EndInt)) ORDER BY KQDate,KQTime
  ELSE
    SELECT TOP 1 @KQDate=KQDate,@KQTime=KQTime FROM Temp_KQ_KQDataFilter WHERE IsInvalid=0 AND EmpNo=@EmpNo AND
      (KQDate>=@BeginDate AND KQTime>=@BeginInt AND KQDate<=@EndDate AND KQTime<=@EndInt)  ORDER BY KQDate,KQTime
  IF @KQDate IS NOT NULL AND @IsChangeMark=1
    UPDATE Temp_KQ_KQDataFilter SET IsInvalid=1 WHERE EmpNo=@EmpNo AND KQDate=@KQDate AND KQTime=@KQTime
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcFindOutTime') DROP PROCEDURE PKQ_CalcFindOutTime
GO
CREATE PROCEDURE PKQ_CalcFindOutTime(@EmpNo varchar(20),@IsChangeMark bit,@BeginDate datetime,@BeginTimeInt int,@EndDate datetime,
  @EndTimeInt int,@KQDate datetime output,@KQTime int output) WITH ENCRYPTION AS
  DECLARE @BeginInt int,@EndInt int

  SELECT @KQDate=NULL,@KQTime=NULL
  SELECT @BeginInt=CASE WHEN @BeginTimeInt>86399 THEN @BeginTimeInt-86399
                        WHEN @BeginTimeInt<0 THEN 0-@BeginTimeInt ELSE @BeginTimeInt END
  SELECT @EndInt=CASE WHEN @EndTimeInt>86399 THEN @EndTimeInt-86399
                      WHEN @EndTimeInt<0 THEN 0-@EndTimeInt ELSE @EndTimeInt END
  IF @BeginDate<>@EndDate
    SELECT TOP 1 @KQDate=KQDate,@KQTime=KQTime FROM Temp_KQ_KQDataFilter WHERE IsInvalid=0 AND EmpNo=@EmpNo AND
      ((KQDate>=@BeginDate AND KQTime>=@BeginInt AND KQDate<=@BeginDate AND KQTime<=86399) OR
      (KQDate>=@EndDate AND KQTime>=0 AND KQDate<=@EndDate AND KQTime<=@EndInt)) ORDER BY KQDate DESC,KQTime DESC
  ELSE
    SELECT TOP 1 @KQDate=KQDate,@KQTime=KQTime FROM Temp_KQ_KQDataFilter WHERE IsInvalid=0 AND EmpNo=@EmpNo AND
      (KQDate>=@BeginDate AND KQTime>=@BeginInt AND KQDate<=@EndDate AND KQTime<=@EndInt) ORDER BY KQDate DESC,KQTime DESC
  IF @KQDate IS NOT NULL AND @IsChangeMark=1
    UPDATE Temp_KQ_KQDataFilter SET IsInvalid=1 WHERE EmpNo=@EmpNo AND KQDate=@KQDate AND KQTime=@KQTime
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcFindTime') DROP PROCEDURE PKQ_CalcFindTime
GO
CREATE PROCEDURE PKQ_CalcFindTime(@EmpNo varchar(20),@IsChangeMark bit,@BeginDateTime datetime,@EndDateTime datetime,@IsIn bit,
  @KQDate datetime output,@KQTime int output) WITH ENCRYPTION AS
  DECLARE @BeginDate datetime,@EndDate datetime,@BeginInt int,@EndInt int

  SELECT @KQDate=NULL,@KQTime=NULL
  SELECT @BeginDate=CONVERT(varchar(10),@BeginDateTime,120),@EndDate=CONVERT(varchar(10),@EndDateTime,120)
  SET @BeginInt=DATEPART(hh,@BeginDateTime)*60*60+DATEPART(mi,@BeginDateTime)*60+DATEPART(ss,@BeginDateTime)
  SET @EndInt=DATEPART(hh,@EndDateTime)*60*60+DATEPART(mi,@EndDateTime)*60+DATEPART(ss,@EndDateTime)
  IF @IsIn=1
    EXEC PKQ_CalcFindInTime @EmpNo,@IsChangeMark,@BeginDate,@BeginInt,@EndDate,@EndInt,@KQDate output,@KQTime output
  ELSE
    EXEC PKQ_CalcFindOutTime @EmpNo,@IsChangeMark,@BeginDate,@BeginInt,@EndDate,@EndInt,@KQDate output,@KQTime output
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcOutHrs') DROP PROCEDURE PKQ_CalcOutHrs
GO
CREATE PROCEDURE PKQ_CalcOutHrs(@EmpNo varchar(20),@BeginTime datetime,@EndTime datetime,@OutHrs decimal(16,5) output) WITH ENCRYPTION AS
  DECLARE @IsChangeMark bit
  DECLARE @InDateTime datetime,@OutDateTime datetime
  DECLARE @T1Date datetime,@T1Time int
  DECLARE @T2Date datetime,@T2Time int
  DECLARE @T1DateTime datetime,@T2DateTime datetime

  SELECT @IsChangeMark=0,@InDateTime=DATEADD(ss,1,@BeginTime),@OutDateTime=DATEADD(ss,-1,@EndTime),@OutHrs=0
  WHILE @InDateTime IS NOT NULL AND @OutDateTime IS NOT NULL
  BEGIN
    SELECT @T1Date=NULL,@T1Time=NULL,@T2Date=NULL,@T2Time=NULL
    EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@InDateTime,@OutDateTime,1,@T1Date output,@T1Time output
    IF @T1Date IS NOT NULL
    BEGIN
      SET @InDateTime=DATEADD(ss,@T1Time+1,@T1Date)
      EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@InDateTime,@OutDateTime,1,@T2Date output,@T2Time output
      IF @T2Date IS NOT NULL SET @InDateTime=DATEADD(ss,@T2Time+1,@T2Date)
    END
    IF @T1Date IS NULL OR @T2Date IS NULL
    BEGIN
      SELECT @InDateTime=NULL,@OutDateTime=NULL
      BREAK
    END
    SELECT @T1DateTime=DATEADD(ss,@T1Time,@T1Date),@T2DateTime=DATEADD(ss,@T2Time,@T2Date)
    SET @OutHrs=@OutHrs+dbo.TimeToMinutes(@T1DateTime,@T2DateTime)
  END
  SET @OutHrs=@OutHrs/60.00
  IF NOT EXISTS (SELECT [Key] FROM SY_Config WHERE [Key]='OutHrs' AND [Value] like '1') SET @OutHrs=0
  IF @OutHrs<0 OR @OutHrs>24 SET @OutHrs=0
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcOtHrs') DROP PROCEDURE PKQ_CalcOtHrs
GO
CREATE PROCEDURE PKQ_CalcOtHrs(@EmpNo varchar(20),@BeginTime datetime,@EndTime datetime,@AheadHrs bit,@AheadMins int,
  @DeferHrs bit,@DeferMins int,@ReadLate bit,@ReadLeave bit,@OtHrs decimal(16,5) output,@OutHrs decimal(16,5) output) WITH ENCRYPTION AS
  DECLARE @IsChangeMark bit
  DECLARE @InDateTime datetime,@OutDateTime datetime
  DECLARE @KQInDate datetime,@KQInTime int
  DECLARE @KQOutDate datetime,@KQOutTime int
  DECLARE @T1Date datetime,@T1Time int
  DECLARE @T2Date datetime,@T2Time int

  SELECT @IsChangeMark=0,@OtHrs=0,@OutHrs=0
  SET @InDateTime=DATEADD(mi,CASE @AheadHrs WHEN 1 THEN -@AheadMins ELSE 0 END,@BeginTime)
  SET @OutDateTime=DATEADD(mi,CASE @DeferHrs WHEN 1 THEN @DeferMins ELSE 0 END,@EndTime)
  IF @AheadHrs=1
  BEGIN
    EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@InDateTime,@EndTime,1,@KQInDate output,@KQInTime output
    IF @KQInDate IS NOT NULL
      SET @InDateTime=DATEADD(ss,@KQInTime,@KQInDate)
    ELSE
      SET @InDateTime=NULL
  END
  IF @DeferHrs=1
  BEGIN
    EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@BeginTime,@OutDateTime,0,@KQOutDate output,@KQOutTime output
    IF @KQOutDate IS NOT NULL
      SET @OutDateTime=DATEADD(ss,@KQOutTime,@KQOutDate)
    ELSE
      SET @OutDateTime=NULL
  END
  IF @InDateTime IS NOT NULL AND @OutDateTime IS NOT NULL
  BEGIN
    SELECT @OtHrs=dbo.TimeToMinutes(@BeginTime,@EndTime)
    IF @ReadLate=1
    BEGIN
       IF @InDateTime>@BeginTime SET @OtHrs=@OtHrs-dbo.TimeToMinutes(@BeginTime,@InDateTime)
       IF @BeginTime>@InDateTime SET @OtHrs=@OtHrs+dbo.TimeToMinutes(@InDateTime,@BeginTime)
    END
    IF @ReadLeave=1
    BEGIN
      IF @EndTime>@OutDateTime SET @OtHrs=@OtHrs-dbo.TimeToMinutes(@OutDateTime,@EndTime)
      IF @OutDateTime>@EndTime SET @OtHrs=@OtHrs+dbo.TimeToMinutes(@EndTime,@OutDateTime)
    END
    SET @OtHrs=@OtHrs/60.00
  END
  IF @OtHrs<0 OR @OtHrs>24 SET @OtHrs=0
  EXEC PKQ_CalcOutHrs @EmpNo,@InDateTime,@OutDateTime,@OutHrs output
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcRegHrs') DROP PROCEDURE PKQ_CalcRegHrs
GO
CREATE PROCEDURE PKQ_CalcRegHrs(@EmpNo varchar(20),@DayOffIDList varchar(100),@BeginTime datetime,@EndTime datetime,
  @IsLeaveOvertime bit,@SortIDOld varchar(10),
  @RegHrs decimal(16,5) output,@Hrs0 decimal(16,5) output,@Hrs1 decimal(16,5) output,@Hrs2 decimal(16,5) output,
  @Hrs3 decimal(16,5) output,@Hrs4 decimal(16,5) output,@Hrs5 decimal(16,5) output,@Hrs6 decimal(16,5) output,
  @Hrs7 decimal(16,5) output,@Hrs8 decimal(16,5) output,@Hrs9 decimal(16,5) output) WITH ENCRYPTION AS
  DECLARE @SortID varchar(10)
  DECLARE @T1 datetime,@T2 datetime,@Count decimal(16,5)
  DECLARE @Start int,@Tune int,@Integer int

  SELECT @Hrs0=0,@Hrs1=0,@Hrs2=0,@Hrs3=0,@Hrs4=0,@Hrs5=0,@Hrs6=0,@Hrs7=0,@Hrs8=0,@Hrs9=0,@RegHrs=0
  DECLARE RecRegHrs SCROLL CURSOR FOR SELECT a.BeginTime,a.EndTime,a.SortID,b.Start,b.Tune,b.[Integer] FROM KQ_EmpDayOff a
      INNER JOIN KQ_RuleCalc b ON b.SortID=a.SortID
      WHERE a.EmpNo=@EmpNo AND ((a.BeginTime>=@BeginTime AND a.EndTime<=@EndTime) OR
                                (a.BeginTime>=@BeginTime AND a.BeginTime<@EndTime AND a.EndTime>@EndTime) OR
                                (a.BeginTime<@BeginTime AND a.EndTime>=@EndTime) OR
                                (a.BeginTime<@BeginTime AND a.EndTime<=@EndTime AND a.EndTime>@BeginTime))
  OPEN RecRegHrs
  FETCH FIRST FROM RecRegHrs INTO @T1,@T2,@SortID,@Start,@Tune,@Integer
  WHILE @@FETCH_STATUS=0
  BEGIN
    IF @T1>=@BeginTime
    BEGIN
      IF @T2>@EndTime
        SET @Count=dbo.TimeToMinutes(@T1,@EndTime)
      ELSE
        SET @Count=dbo.TimeToMinutes(@T1,@T2)
    END
    ELSE IF @T2>@EndTime
      SET @Count=dbo.TimeToMinutes(@BeginTime,@EndTime)
    ELSE
      SET @Count=dbo.TimeToMinutes(@BeginTime,@T2)
    SET @Count=@Count/60.00
    IF @Count<0 OR @Count>24 SET @Count=0
    --请假计算加班时间
    IF @IsLeaveOvertime=1 AND CAST(SUBSTRING(@SortIDOld,3,4) as int)>10 AND CAST(SUBSTRING(@SortIDOld,3,4) as int)<21 SET @Count=0
    
    SET @RegHrs=@RegHrs+@Count
    SET @RegHrs=dbo.CalcAdjust(@RegHrs,@Start,@Tune,@Integer)
    WHILE LEN(@SortID)<10 SET @SortID='0'+@SortID
    IF CHARINDEX(@SortID,@DayOffIDList)=1 SET @Hrs0=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=11 SET @Hrs1=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=21 SET @Hrs2=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=31 SET @Hrs3=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=41 SET @Hrs4=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=51 SET @Hrs5=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=61 SET @Hrs6=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=71 SET @Hrs7=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=81 SET @Hrs8=@RegHrs
    IF CHARINDEX(@SortID,@DayOffIDList)=91 SET @Hrs9=@RegHrs
    FETCH NEXT FROM RecRegHrs INTO @T1,@T2,@SortID,@Start,@Tune,@Integer
  END
  CLOSE RecRegHrs
  DEALLOCATE RecRegHrs
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcRest') DROP PROCEDURE PKQ_CalcRest
GO
CREATE PROCEDURE PKQ_CalcRest(@EmpNo varchar(20),@Date datetime,@RuleID varchar(10),@DayOffIDList varchar(100),
  @ReadLate bit,@ReadLeave bit,@IsLeaveOvertime bit,@OtHrs decimal(16,5) output,@OutHrs decimal(16,5) output,@RegHrs decimal(16,5) output,
  @Hrs0 decimal(16,5) output,@Hrs1 decimal(16,5) output,@Hrs2 decimal(16,5) output,@Hrs3 decimal(16,5) output,
  @Hrs4 decimal(16,5) output,@Hrs5 decimal(16,5) output,@Hrs6 decimal(16,5) output,@Hrs7 decimal(16,5) output,
  @Hrs8 decimal(16,5) output,@Hrs9 decimal(16,5) output) WITH ENCRYPTION AS
  DECLARE @RestTime datetime
  DECLARE @BeginTime datetime
  DECLARE @EndTime datetime
  DECLARE @AheadHrs bit
  DECLARE @AheadMins int
  DECLARE @DeferHrs bit
  DECLARE @DeferMins int
  DECLARE @Rate decimal(16,5)
  DECLARE @OtHrs1 decimal(16,5)
  DECLARE @OutHrs1 decimal(16,5)
  DECLARE @RegHrs1 decimal(16,5)
  DECLARE @Hrs0X decimal(16,5),@Hrs1X decimal(16,5),@Hrs2X decimal(16,5),@Hrs3X decimal(16,5),@Hrs4X decimal(16,5)
  DECLARE @Hrs5X decimal(16,5),@Hrs6X decimal(16,5),@Hrs7X decimal(16,5),@Hrs8X decimal(16,5),@Hrs9X decimal(16,5)
  DECLARE @Start int,@Tune int,@Integer int,@SortIDOld varchar(10)

  SELECT @OtHrs=0,@OutHrs=0,@RegHrs=0,@Hrs0=0,@Hrs1=0,@Hrs2=0,@Hrs3=0,@Hrs4=0,@Hrs5=0,@Hrs6=0,@Hrs7=0,@Hrs8=0,@Hrs9=0
  SET @RestTime=DATEADD(ss,86399,@Date)
  DECLARE RecRest SCROLL CURSOR FOR SELECT a.BeginTime,a.EndTime,a.AheadHrs,a.AheadMins,a.DeferHrs,a.DeferMins,
    b.OvertimeRate,b.Start,b.Tune,b.[Integer],a.SortID FROM KQ_EmpOtSure a INNER JOIN KQ_RuleCalc b ON b.SortID=a.SortID
    WHERE EmpNo=@EmpNo AND BeginTime>=@Date AND EndTime<=@RestTime
  OPEN RecRest
  FETCH FIRST FROM RecRest INTO @BeginTime,@EndTime,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@Rate,@Start,@Tune,@Integer,@SortIDOld
  WHILE @@FETCH_STATUS=0
  BEGIN
    SELECT @OtHrs1=0,@OutHrs1=0
    EXEC PKQ_CalcOtHrs @EmpNo,@BeginTime,@EndTime,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@ReadLate,@ReadLeave,@OtHrs1 output,@OutHrs1 output
    SET @OtHrs1=@OtHrs1*@Rate
    SET @OtHrs1=dbo.CalcAdjust(@OtHrs1,@Start,@Tune,@Integer)
    SET @OtHrs=@OtHrs+@OtHrs1
    SET @OutHrs=@OutHrs+@OutHrs1
    EXEC PKQ_CalcRegHrs @EmpNo,@DayOffIDList,@BeginTime,@EndTime,@IsLeaveOvertime,@SortIDOld,@RegHrs1 output,@Hrs0X output,@Hrs1X output,
      @Hrs2X output,@Hrs3X output,@Hrs4X output,@Hrs5X output,@Hrs6X output,@Hrs7X output,@Hrs8X output,@Hrs9X output
    SELECT @RegHrs=@RegHrs+@RegHrs1,@Hrs0=@Hrs0+@Hrs0X,@Hrs1=@Hrs1+@Hrs1X,@Hrs2=@Hrs2+@Hrs2X,@Hrs3=@Hrs3+@Hrs3X,
      @Hrs4=@Hrs4+@Hrs4X,@Hrs5=@Hrs5+@Hrs5X,@Hrs6=@Hrs6+@Hrs6X,@Hrs7=@Hrs7+@Hrs7X,@Hrs8=@Hrs8+@Hrs8X,@Hrs9=@Hrs9+@Hrs9X
    FETCH NEXT FROM RecRest INTO @BeginTime,@EndTime,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@Rate,@Start,@Tune,@Integer,@SortIDOld
  END
  CLOSE RecRest
  DEALLOCATE RecRest
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcFindShiftA') DROP PROCEDURE PKQ_CalcFindShiftA
GO
CREATE PROCEDURE PKQ_CalcFindShiftA(@EmpNo varchar(20),@Date datetime,@SAhead int,@SDefer int,@SIn varchar(5),@SOut varchar(5),
  @NeedIn bit,@NeedOut bit,@Exists bit output,@LateHrs int,@LeaveHrs int,@LateMins int output,@LeaveMins int output) WITH ENCRYPTION AS
  DECLARE @SHrs decimal(16,5),@InMi int,@OutMi int,@BeginTime datetime,@EndTime datetime
  DECLARE @T0 datetime,@T datetime,@IsChangeMark bit,@T1Date datetime
  DECLARE @T1Time int,@T2Date datetime,@T2Time int,@InTime varchar(5),@OutTime varchar(5)
  DECLARE @SInMi int,@SOutMi int

  SELECT @SHrs=dbo.GetTimeSecond(@SIn,@SOut)/60.00/60.00
  SET @InMi=CAST(SUBSTRING(@SIn,1,2) AS int)*60+CAST(SUBSTRING(@SIn,4,2) AS int)
  SET @OutMi=CAST(SUBSTRING(@SOut,1,2) AS int)*60+CAST(SUBSTRING(@SOut,4,2) AS int)
  SELECT @BeginTime=DATEADD(mi,@InMi,@Date),@EndTime=DATEADD(mi,@OutMi,@Date)
  SELECT @T=DATEADD(mi,-@SAhead,@BeginTime),@Exists=0,@InTime='',@OutTime='',@IsChangeMark=0
  SET @T0=DATEADD(mi,@LateHrs,@BeginTime)
  EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@T,@T0,1,@T1Date output,@T1Time output
  IF @T1Date IS NOT NULL
    SET @InTime=dbo.GetTimeStr(@T1Time+CASE WHEN @InMi>=1440 THEN DATEDIFF(dd,@Date,@T1Date) ELSE DATEDIFF(dd,@T1Date,@Date) END*86400)
  IF @NeedOut=0
    SET @OutTime=@SOut
  ELSE
  BEGIN
    SET @T=DATEADD(mi,@SDefer,@EndTime)
    SET @T0=DATEADD(mi,-@LeaveHrs,@EndTime)
    EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@T0,@T,0,@T2Date output,@T2Time output
    IF @T2Date IS NOT NULL SET @OutTime=dbo.GetTimeStr(@T2Time+DATEDIFF(dd,@Date,@T2Date)*86400)
  END
  IF @InTime<>'' AND @OutTime<>''
  BEGIN
    SET @Exists=1
    SET @SInMi=CAST(SUBSTRING(@InTime,1,2) AS int)*60+CAST(SUBSTRING(@InTime,4,2) AS int)
    SET @SOutMi=CAST(SUBSTRING(@OutTime,1,2) AS int)*60+CAST(SUBSTRING(@OutTime,4,2) AS int)
    IF @SInMi>=@InMi SET @LateMins=@LateMins+(@SInMi-@InMi)
    IF @OutMi>=@SOutMi SET @LeaveMins=@LeaveMins+(@OutMi-@SOutMi)
  END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcFindShift') DROP PROCEDURE PKQ_CalcFindShift
GO
CREATE PROCEDURE PKQ_CalcFindShift(@EmpNo varchar(20),@Date datetime,@FindShiftID varchar(50),@ShiftID varchar(50) output,
  @LateHrs int,@LeaveHrs int) WITH ENCRYPTION AS
  DECLARE @ShiftHrs decimal(16,5),@Exists1 bit,@Exists2 bit,@Exists3 bit,@Exists4 bit,@Exists5 bit
  DECLARE @SAhead1 int,@SDefer1 int,@SIn1 varchar(5),@SOut1 varchar(5),@NeedIn1 bit,@NeedOut1 bit
  DECLARE @SAhead2 int,@SDefer2 int,@SIn2 varchar(5),@SOut2 varchar(5),@NeedIn2 bit,@NeedOut2 bit
  DECLARE @SAhead3 int,@SDefer3 int,@SIn3 varchar(5),@SOut3 varchar(5),@NeedIn3 bit,@NeedOut3 bit
  DECLARE @SAhead4 int,@SDefer4 int,@SIn4 varchar(5),@SOut4 varchar(5),@NeedIn4 bit,@NeedOut4 bit
  DECLARE @SAhead5 int,@SDefer5 int,@SIn5 varchar(5),@SOut5 varchar(5),@NeedIn5 bit,@NeedOut5 bit
  DECLARE @LateMins int,@LeaveMins int

  SELECT @SAhead1=ShiftAhead1,@SDefer1=ShiftDefer1,@SIn1=SigninTime1,@SOut1=SignoutTime1,@NeedIn1=Signin1,@NeedOut1=Signout1,
    @SAhead2=ShiftAhead2,@SDefer2=ShiftDefer2,@SIn2=SigninTime2,@SOut2=SignoutTime2,@NeedIn2=Signin2,@NeedOut2=Signout2,
    @SAhead3=ShiftAhead3,@SDefer3=ShiftDefer3,@SIn3=SigninTime3,@SOut3=SignoutTime3,@NeedIn3=Signin3,@NeedOut3=Signout3,
    @SAhead4=ShiftAhead4,@SDefer4=ShiftDefer4,@SIn4=SigninTime4,@SOut4=SignoutTime4,@NeedIn4=Signin4,@NeedOut4=Signout4,
    @SAhead5=ShiftAhead5,@SDefer5=ShiftDefer5,@SIn5=SigninTime5,@SOut5=SignoutTime5,@NeedIn5=Signin5,@NeedOut5=Signout5
    FROM KQ_Shift WHERE ShiftID=@FindShiftID
  SELECT @LateMins=0,@LeaveMins=0
  IF @SIn1<>'' AND @SOut1<>''
    EXEC PKQ_CalcFindShiftA @EmpNo,@Date,@SAhead1,@SDefer1,@SIn1,@SOut1,@NeedIn1,@NeedOut1,@Exists1 output,@LateHrs,@LeaveHrs,@LateMins output,@LeaveMins output
  ELSE
    RETURN
  IF @SIn2<>'' AND @SOut2<>''
    EXEC PKQ_CalcFindShiftA @EmpNo,@Date,@SAhead2,@SDefer2,@SIn2,@SOut2,@NeedIn2,@NeedOut2,@Exists2 output,@LateHrs,@LeaveHrs,@LateMins output,@LeaveMins output
  ELSE
    SET @Exists2=1
  IF @SIn3<>'' AND @SOut3<>''
    EXEC PKQ_CalcFindShiftA @EmpNo,@Date,@SAhead3,@SDefer3,@SIn3,@SOut3,@NeedIn3,@NeedOut3,@Exists3 output,@LateHrs,@LeaveHrs,@LateMins output,@LeaveMins output
  ELSE
    SET @Exists3=1
  IF @SIn4<>'' AND @SOut4<>''
    EXEC PKQ_CalcFindShiftA @EmpNo,@Date,@SAhead4,@SDefer4,@SIn4,@SOut4,@NeedIn4,@NeedOut4,@Exists4 output,@LateHrs,@LeaveHrs,@LateMins output,@LeaveMins output
  ELSE
    SET @Exists4=1
  IF @SIn5<>'' AND @SOut5<>''
    EXEC PKQ_CalcFindShiftA @EmpNo,@Date,@SAhead5,@SDefer5,@SIn5,@SOut5,@NeedIn5,@NeedOut5,@Exists5 output,@LateHrs,@LeaveHrs,@LateMins output,@LeaveMins output
  ELSE
    SET @Exists5=1
  IF @Exists1=1 AND @Exists2=1 AND @Exists3=1 AND @Exists4=1 AND @Exists5=1
  BEGIN
    SET @ShiftID=@FindShiftID
    IF EXISTS(SELECT * FROM KQ_ShiftFind WHERE ShiftID=@ShiftID)
      UPDATE KQ_ShiftFind SET LateMins=LateMins+@LateMins,LeaveMins=LeaveMins+@LeaveMins WHERE ShiftID=@ShiftID
    ELSE
      INSERT INTO KQ_ShiftFind(ShiftID,LateMins,LeaveMins) VALUES(@ShiftID,@LateMins,@LeaveMins)
  END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcLateLeaveMins') DROP PROCEDURE PKQ_CalcLateLeaveMins
GO
CREATE PROCEDURE PKQ_CalcLateLeaveMins(@EmpNo varchar(20),@Date datetime,@LateIgnore int,@LeaveIgnore int,@LateLeaveCalHrs int,
  @AheadHrs bit,@AheadMins int,@DeferHrs bit,@DeferMins int,@SIn varchar(5),@SOut varchar(5),@InTime varchar(5),@OutTime varchar(5),
  @ShiftHrs decimal(16,5),@LateHrs int,@LeaveHrs int,@LateMins int output,@LeaveMins int output,@AbsentDays decimal(16,5) output,
  @LateCount int output,@LeaveCount int output,@OtHrs decimal(16,5) output) WITH ENCRYPTION AS
  DECLARE @SInMi int,@SOutMi int,@SInDate datetime,@SOutDate datetime
  DECLARE @InMi int,@OutMi int,@LEndMins int
  DECLARE @LBegin datetime,@LEnd datetime
  DECLARE @AheadOtHrs decimal(16,5),@DeferOtHrs decimal(16,5)
  DECLARE @Hrs decimal(16,5)

  SELECT @LateMins=0,@LeaveMins=0,@AbsentDays=0,@LateCount=0,@LeaveCount=0,@OtHrs=0,@AheadOtHrs=0
  SET @DeferOtHrs=0
  SET @SInMi=CAST(SUBSTRING(@SIn,1,2) AS int)*60+CAST(SUBSTRING(@SIn,4,2) AS int)
  SET @SOutMi=CAST(SUBSTRING(@SOut,1,2) AS int)*60+CAST(SUBSTRING(@SOut,4,2) AS int)
  SET @InMi=CAST(SUBSTRING(@InTime,1,2) AS int)*60+CAST(SUBSTRING(@InTime,4,2) AS int)
  SET @OutMi=CAST(SUBSTRING(@OutTime,1,2) AS int)*60+CAST(SUBSTRING(@OutTime,4,2) AS int)
  SET @Hrs=(@SOutMi-@SInMi)/60.00
  SELECT @SInDate=DATEADD(mi,@SInMi,@Date),@SOutDate=DATEADD(mi,@SOutMi,@Date)
  SELECT @LBegin=a.BeginTime,@LEnd=a.EndTime FROM KQ_EmpDayOff a INNER JOIN KQ_RuleCalc b ON b.SortID=a.SortID
    WHERE a.EmpNo=@EmpNo AND a.BeginTime<=@SInDate AND a.EndTime>=@SInDate
  SET @LateMins=@InMi-@SInMi
  IF @LateMins>0 AND @LBegin IS NOT NULL
  BEGIN
    SET @LEndMins=DATEPART(hh,@LEnd)*60+DATEPART(mi,@LEnd)
    IF DATEPART(DD,@LEnd)>DATEPART(DD,@Date)
    BEGIN
		SET @LEndMins=@LEndMins+(DATEPART(DD,@LEnd)-DATEPART(DD,@Date))*24*60
    END
    SET @LateMins=@InMi-@LEndMins
    IF @LateMins<0 SET @LateMins=0
  END
  IF (@LateMins>=@LateHrs AND @LateHrs>0) OR (@LateMins>0 AND @LateHrs=0)
  BEGIN
    IF @ShiftHrs>0 
    BEGIN
    SET @AbsentDays=@Hrs/@ShiftHrs
    SET @LateMins=0
    SET @LateCount=0
    END
    ELSE
    BEGIN
    SET @LateCount=1
    END
  END
  ELSE IF @LateMins>=0
  BEGIN
    IF (@LateMins>=@LateIgnore AND @LateIgnore>0) OR (@LateMins>0 AND @LateIgnore=0)
    BEGIN
      IF @LateMins>=@LateLeaveCalHrs AND @LateLeaveCalHrs>0
      BEGIN
        IF @ShiftHrs>0 SET @AbsentDays=@LateMins/60.00/@ShiftHrs
      END
      SET @LateCount=1
    END
    ELSE
      SET @LateMins=0
  END
  ELSE
  BEGIN
    SET @LateMins=0
    IF @AheadHrs=1
    BEGIN
      SET @AheadOtHrs=@SInMi-@InMi
      IF @AheadOtHrs>=@AheadMins AND @AheadMins>=0
        SET @AheadOtHrs=@AheadOtHrs/60.00
      ELSE
        SET @AheadOtHrs=0
    END
  END
  SELECT @LBegin=a.BeginTime,@LEnd=a.EndTime FROM KQ_EmpDayOff a INNER JOIN KQ_RuleCalc b ON b.SortID=a.SortID
    WHERE a.EmpNo=@EmpNo AND a.BeginTime<=@SOutDate AND a.EndTime>=@SOutDate
  SET @LeaveMins=@SOutMi-@OutMi
  IF @LeaveMins>0 AND @LBegin IS NOT NULL
  BEGIN
    SET @LEndMins=DATEPART(hh,@LEnd)*60+DATEPART(mi,@LEnd)
    IF DATEPART(DD,@LEnd)>DATEPART(DD,@Date)
    BEGIN
		SET @LEndMins=@LEndMins+(DATEPART(DD,@LEnd)-DATEPART(DD,@Date))*24*60
    END
    SET @LeaveMins=@SOutMi-@LEndMins
    --IF @LeaveMins<0 SET @LeaveMins=@LeaveMins+24*60
    IF @LeaveMins<0 SET @LeaveMins=0
  END
  IF (@LeaveMins>=@LeaveHrs AND @LeaveHrs>0) OR (@LeaveMins>0 AND @LeaveHrs=0)
  BEGIN
    IF @ShiftHrs>0 
    BEGIN
    SET @AbsentDays=@Hrs/@ShiftHrs
      SET @LeaveCount=0
      SET @LeaveMins=0
    END
    ELSE
    BEGIN
     SET @LeaveCount=1
    END
  END
  ELSE IF @LeaveMins>=0
  BEGIN
    IF (@LeaveMins>=@LeaveIgnore AND @LeaveIgnore>0) OR (@LeaveMins>0 AND @LeaveIgnore=0)
    BEGIN
      IF @LeaveMins>=@LateLeaveCalHrs AND @LateLeaveCalHrs>0
      BEGIN
        IF @ShiftHrs>0 SET @AbsentDays=@AbsentDays+@LeaveMins/60.00/@ShiftHrs
      END
      SET @LeaveCount=1
    END
    ELSE
      SET @LeaveMins=0
  END
  ELSE
  BEGIN
    SET @LeaveMins=0
    IF @DeferHrs=1
    BEGIN
      SET @DeferOtHrs=@OutMi-@SOutMi
      IF @DeferOtHrs>=@DeferMins AND @DeferMins>=0
        SET @DeferOtHrs=@DeferOtHrs/60.00
      ELSE
        SET @DeferOtHrs=0
    END
  END
  SET @Othrs=@AheadOtHrs+@DeferOtHrs
  IF @Othrs<0 OR @Othrs>24 SET @Othrs=0
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcNormalTime') DROP PROCEDURE PKQ_CalcNormalTime
GO
CREATE PROCEDURE PKQ_CalcNormalTime(@EmpNo varchar(20),@Date datetime,@DayOffIDList varchar(100),@ShiftHrs decimal(16,5),
  @SAhead int,@SDefer int,@SIn varchar(5),@SOut varchar(5),@NeedIn bit,@NeedOut bit,@SortID varchar(10),@Drift bit,
  @TypeID tinyint,@OTType tinyint,@Rate decimal(16,5),@ShiftIndex int,@InTime varchar(5) output,@OutTime varchar(5) output,
  @RegHrsT decimal(16,5) output,@AbsentDays decimal(16,5) output,@LateMins int output,@LateCount int output,@LeaveMins int output,
  @LeaveCount int output,@OtHrs decimal(16,5) output,@OtHrsM decimal(16,5) output,@SunHrsM decimal(16,5) output,@HdHrsM decimal(16,5) output,
  @OutHrs decimal(16,5) output,@RegHrs decimal(16,5) output,@Hrs0 decimal(16,5) output,@Hrs1 decimal(16,5) output,@Hrs2 decimal(16,5) output,
  @Hrs3 decimal(16,5) output,@Hrs4 decimal(16,5) output,@Hrs5 decimal(16,5) output,@Hrs6 decimal(16,5) output,@Hrs7 decimal(16,5) output,
  @Hrs8 decimal(16,5) output,@Hrs9 decimal(16,5) output,@DriftTime datetime,@LateIgnore int,@LeaveIgnore int,@LateLeaveCalHrs int,
  @AheadHrs bit,@AheadMins int,@DeferHrs bit,@DeferMins int,@ReadLate bit,@ReadLeave bit,@LateHrs int,@LeaveHrs int,
  @Start int,@Tune int,@Integer int,@IsLeaveOvertime bit) WITH ENCRYPTION AS
  DECLARE @SHrs decimal(16,5),@IsChangeMark bit,@InMi int,@OutMi int
  DECLARE @BeginTime datetime,@EndTime datetime,@T datetime,@T1Date datetime,@T1Time int
  DECLARE @T2Date datetime,@T2Time int
  DECLARE @RegHrs1 decimal(16,5),@Hrs0X decimal(16,5),@Hrs1X decimal(16,5),@Hrs2X decimal(16,5),@Hrs3X decimal(16,5),@Hrs4X decimal(16,5)
  DECLARE @Hrs5X decimal(16,5),@Hrs6X decimal(16,5),@Hrs7X decimal(16,5),@Hrs8X decimal(16,5),@Hrs9X decimal(16,5)
  DECLARE @OutHrs1 decimal(16,5),@LateMins1 int,@LateCount1 int,@LeaveMins1 int,@LeaveCount1 int
  DECLARE @AbsentDays1 decimal(16,5),@OtHrs1 decimal(16,5)
  DECLARE @ShiftOtHrs decimal(16,5)

  SELECT @SHrs=dbo.GetTimeSecond(@SIn,@SOut)/60.00/60.00,@IsChangeMark=1
  SET @InMi=CAST(SUBSTRING(@SIn,1,2) AS int)*60+CAST(SUBSTRING(@SIn,4,2) AS int)
  SET @OutMi=CAST(SUBSTRING(@SOut,1,2) AS int)*60+CAST(SUBSTRING(@SOut,4,2) AS int)
  SELECT @BeginTime=DATEADD(mi,@InMi,@Date),@EndTime=DATEADD(mi,@OutMi,@Date)
  SELECT @InTime='',@OutTime=''
  
  EXEC PKQ_CalcRegHrs @EmpNo,@DayOffIDList,@BeginTime,@EndTime,@IsLeaveOvertime,@SortID,@RegHrs1 output,@Hrs0X output,@Hrs1X output,@Hrs2X output,@Hrs3X output,
		@Hrs4X output,@Hrs5X output,@Hrs6X output,@Hrs7X output,@Hrs8X output,@Hrs9X output
		
  SELECT @RegHrs=@RegHrs+@RegHrs1,@Hrs0=@Hrs0+@Hrs0X,@Hrs1=@Hrs1+@Hrs1X,@Hrs2=@Hrs2+@Hrs2X,@Hrs3=@Hrs3+@Hrs3X,@Hrs4=@Hrs4+@Hrs4X,
    @Hrs5=@Hrs5+@Hrs5X,@Hrs6=@Hrs6+@Hrs6X,@Hrs7=@Hrs7+@Hrs7X,@Hrs8=@Hrs8+@Hrs8X,@Hrs9=@Hrs9+@Hrs9X
  IF @NeedIn=0
    SET @InTime=@SIn
  ELSE
  BEGIN
    SET @T=DATEADD(mi,-@SAhead,@BeginTime)
    EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@T,@EndTime,1,@T1Date output,@T1Time output
    IF @T1Date IS NOT NULL
      SET @InTime=dbo.GetTimeStr(@T1Time+CASE WHEN @InMi>=1440 THEN DATEDIFF(dd,@Date,@T1Date) ELSE DATEDIFF(dd,@T1Date,@Date) END*86400)
  END
  IF @NeedOut=0
    SET @OutTime=@SOut
  ELSE IF @Drift=0
  BEGIN
    SET @T=DATEADD(mi,@SDefer,@EndTime)
    EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@BeginTime,@T,0,@T2Date output,@T2Time output
    IF @T2Date IS NOT NULL SET @OutTime=dbo.GetTimeStr(@T2Time+DATEDIFF(dd,@Date,@T2Date)*86400)
  END
  ELSE
  BEGIN
    EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@EndTime,@DriftTime,1,@T2Date output,@T2Time output
    IF @T2Date IS NOT NULL
    BEGIN
      SET @T=DATEADD(mi,@SDefer,@EndTime)
      EXEC PKQ_CalcFindTime @EmpNo,@IsChangeMark,@BeginTime,@T,0,@T2Date output,@T2Time output
    END
    IF @T2Date IS NOT NULL SET @OutTime=dbo.GetTimeStr(@T2Time+DATEDIFF(dd,@Date,@T2Date)*86400)
  END
  IF @TypeID=0--正常班段
  BEGIN
    SET @RegHrsT=@RegHrsT+@RegHrs1
    IF @InTime='' OR @OutTime=''
    BEGIN
      SET @AbsentDays=@AbsentDays+@SHrs/@ShiftHrs-@RegHrs1/@ShiftHrs
    END
    ELSE
    BEGIN
      EXEC PKQ_CalcOutHrs @EmpNo,@BeginTime,@EndTime,@OutHrs1 output
      SET @OutHrs=@OutHrs+@OutHrs1
      IF @Drift=0
      BEGIN
        EXEC PKQ_CalcLateLeaveMins @EmpNo,@Date,@LateIgnore,@LeaveIgnore,@LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,
          @SIn,@SOut,@InTime,@OutTime,@ShiftHrs,@LateHrs,@LeaveHrs,@LateMins1 output,@LeaveMins1 output,@AbsentDays1 output,
          @LateCount1 output,@LeaveCount1 output,@OtHrs1 output
        SELECT @LateMins=@LateMins+@LateMins1,@LateCount=@LateCount+@LateCount1
        SELECT @LeaveMins=@LeaveMins+@LeaveMins1,@LeaveCount=@LeaveCount+@LeaveCount1
        SET @AbsentDays1=@AbsentDays1-@RegHrs1/@ShiftHrs
        IF @AbsentDays1<0 SET @AbsentDays1=0
        SET @AbsentDays=@AbsentDays+@AbsentDays1
select @OtHrs1,@Start,@Tune,@Integer
        SET @OtHrs1=dbo.CalcAdjust(@OtHrs1,@Start,@Tune,@Integer)
select @OtHrs1
        SET @OtHrs=@OtHrs+@OtHrs1
        SET @OtHrsM=@OtHrsM+@OtHrs1
      END
    END
  END
  ELSE--加班班段
  BEGIN
    SELECT @ShiftOtHrs=0,@LateMins1=0,@LeaveMins1=0
    IF @InTime<>'' AND @OutTime<>''
    BEGIN
      EXEC PKQ_CalcOutHrs @EmpNo,@BeginTime,@EndTime,@OutHrs1 output
      SET @OutHrs=@OutHrs+@OutHrs1
      IF @Drift=0
      BEGIN
        EXEC PKQ_CalcLateLeaveMins @EmpNo,@Date,@LateIgnore,@LeaveIgnore,@LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,
          @SIn,@SOut,@InTime,@OutTime,@ShiftHrs,@LateHrs,@LeaveHrs,@LateMins1 output,@LeaveMins1 output,@AbsentDays1 output,
          @LateCount1 output,@LeaveCount1 output,@OtHrs1 output
        SET @OtHrs1=dbo.CalcAdjust(@OtHrs1,@Start,@Tune,@Integer)
        SET @ShiftOtHrs=@Rate*(@SHrs-@OutHrs1-@RegHrs1-@LateMins1/60.00-@LeaveMins1/60.00)+@OtHrs1
      END
      ELSE
      BEGIN
        SET @ShiftOtHrs=(CAST(SUBSTRING(@OutTime,1,2) AS int)*60+CAST(SUBSTRING(@OutTime,4,2) AS int))-
          (CAST(SUBSTRING(@InTime,1,2) AS int)*60+CAST(SUBSTRING(@InTime,4,2) AS int))
        SET @ShiftOtHrs=(@ShiftOtHrs*@Rate)/60.00
        SET @ShiftOtHrs=dbo.CalcAdjust(@ShiftOtHrs,@Start,@Tune,@Integer)
      END
    END
    IF @OTType=1 SET @OtHrsM=@OtHrsM+@ShiftOtHrs
    IF @OTType=2 SET @SunHrsM=@SunHrsM+@ShiftOtHrs
    IF @OTType=3 SET @HdHrsM=@HdHrsM+@ShiftOtHrs
    IF @ReadLate=1 SET @LateMins=@LateMins+@LateMins1
    IF @ReadLeave=1 SET @LeaveMins=@LeaveMins+@LeaveMins1
    SET @OtHrs=@OtHrs+@ShiftOtHrs
  END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_CalcNormal') DROP PROCEDURE PKQ_CalcNormal
GO
CREATE PROCEDURE PKQ_CalcNormal(@EmpNo varchar(20),@Date datetime,@DayOffIDList varchar(100),@ShiftID varchar(50),@In1 varchar(5) output,
  @Out1 varchar(5) output,@In2 varchar(5) output,@Out2 varchar(5) output,@In3 varchar(5) output,@Out3 varchar(5) output,
  @In4 varchar(5) output,@Out4 varchar(5) output,@In5 varchar(5) output,@Out5 varchar(5) output,@AbsentDays decimal(16,5) output,
  @LateMins int output,@LateCount int output,@LeaveMins int output,@LeaveCount int output,@OtHrs decimal(16,5) output,@OtHrsM decimal(16,5) output,
  @SunHrsM decimal(16,5) output,@HdHrsM decimal(16,5) output,@OutHrs decimal(16,5) output,@RegHrs decimal(16,5) output,@Hrs0 decimal(16,5) output,
  @Hrs1 decimal(16,5) output,@Hrs2 decimal(16,5) output,@Hrs3 decimal(16,5) output,@Hrs4 decimal(16,5) output,@Hrs5 decimal(16,5) output,
  @Hrs6 decimal(16,5) output,@Hrs7 decimal(16,5) output,@Hrs8 decimal(16,5) output,@Hrs9 decimal(16,5) output,@WorkHrs decimal(16,5) output,
  @WorkDays decimal(16,5) output,@NSCount int output,@MidCount int output,@Remark varchar(255) output,@RestDays decimal(16,5) output,
  @RestDaysDB decimal(16,5) output,@IsNormal bit,@ReadLate bit,@ReadLeave bit,@LateIgnore int,@LeaveIgnore int,@LateLeaveCalHrs int,@AheadHrs bit,
  @AheadMins int,@DeferHrs bit,@DeferMins int,@Small varchar(5),@Big varchar(5),@LateHrs int,@LeaveHrs int,@IsLeaveOvertime bit) WITH ENCRYPTION AS
  DECLARE @RegHrsT decimal(16,5),@ShiftHrs decimal(16,5),@DriftTime datetime
  DECLARE @SAhead1 int,@SDefer1 int,@SIn1 varchar(5),@SOut1 varchar(5),@NeedIn1 bit,@NeedOut1 bit,@SortID1 varchar(10),@Drift1 bit
  DECLARE @SAhead2 int,@SDefer2 int,@SIn2 varchar(5),@SOut2 varchar(5),@NeedIn2 bit,@NeedOut2 bit,@SortID2 varchar(10),@Drift2 bit
  DECLARE @SAhead3 int,@SDefer3 int,@SIn3 varchar(5),@SOut3 varchar(5),@NeedIn3 bit,@NeedOut3 bit,@SortID3 varchar(10),@Drift3 bit
  DECLARE @SAhead4 int,@SDefer4 int,@SIn4 varchar(5),@SOut4 varchar(5),@NeedIn4 bit,@NeedOut4 bit,@SortID4 varchar(10),@Drift4 bit
  DECLARE @SAhead5 int,@SDefer5 int,@SIn5 varchar(5),@SOut5 varchar(5),@NeedIn5 bit,@NeedOut5 bit,@SortID5 varchar(10),@Drift5 bit
  DECLARE @TypeID tinyint,@OTType tinyint,@Rate decimal(16,5)
  DECLARE @ShiftOtHrs decimal(16,5),@OtBeginTime datetime,@OtEndTime datetime,@OtNeedIn bit,@OtNeedOut bit,@OtAhead int,@OtDelay int
  DECLARE @RestTime datetime,@OtHrs1 decimal(16,5),@OutHrs1 decimal(16,5),@RegHrs1 decimal(16,5)
  DECLARE @Hrs0X decimal(16,5),@Hrs1X decimal(16,5),@Hrs2X decimal(16,5),@Hrs3X decimal(16,5),@Hrs4X decimal(16,5),@Hrs5X decimal(16,5)
  DECLARE @Hrs6X decimal(16,5),@Hrs7X decimal(16,5),@Hrs8X decimal(16,5),@Hrs9X decimal(16,5)
  DECLARE @SmallMi int,@BigMi int,@InMi int,@OutMi int,@TempWorkHrs decimal(16,5),@TempAbsentDays decimal(16,5),@TempOtHrs decimal(16,5)
  DECLARE @InMi1 int,@OutMi1 int,@InMi2 int,@OutMi2 int,@InMi3 int,@OutMi3 int,@InMi4 int,@OutMi4 int,@InMi5 int,@OutMi5 int
  DECLARE @TempRestDay decimal(16,5),@Start int,@Tune int,@Integer int,@NormalStart int,@NormalTune int,@NormalInteger int,@SortIDOld varchar(10)

  SELECT @RegHrsT=0,@ShiftHrs=WorkHours,@SAhead1=ShiftAhead1,@SDefer1=ShiftDefer1,@SIn1=SigninTime1,@SOut1=SignoutTime1,@NeedIn1=Signin1,
    @NeedOut1=Signout1,@SortID1=SortID1,@Drift1=Drift1,@SAhead2=ShiftAhead2,@SDefer2=ShiftDefer2,@SIn2=SigninTime2,@SOut2=SignoutTime2,
    @NeedIn2=Signin2,@NeedOut2=Signout2,@SortID2=SortID2,@Drift2=Drift2,@SAhead3=ShiftAhead3,@SDefer3=ShiftDefer3,@SIn3=SigninTime3,
    @SOut3=SignoutTime3,@NeedIn3=Signin3,@NeedOut3=Signout3,@SortID3=SortID3,@Drift3=Drift3,@SAhead4=ShiftAhead4,@SDefer4=ShiftDefer4,
    @SIn4=SigninTime4,@SOut4=SignoutTime4,@NeedIn4=Signin4,@NeedOut4=Signout4,@SortID4=SortID4,@Drift4=Drift4,@SAhead5=ShiftAhead5,
    @SDefer5=ShiftDefer5,@SIn5=SigninTime5,@SOut5=SignoutTime5,@NeedIn5=Signin5,@NeedOut5=Signout5,@SortID5=SortID5,@Drift5=Drift5
    FROM KQ_Shift WHERE ShiftID=@ShiftID
  SELECT @InMi1=0,@OutMi1=0,@InMi2=0,@OutMi2=0,@InMi3=0,@OutMi3=0,@InMi4=0,@OutMi4=0,@InMi5=0,@OutMi5=0,@TempRestDay=0,@NormalStart=0,@NormalTune=0,@NormalInteger=0
  IF @SIn1<>'' AND @SOut1<>''
  BEGIN
    SET @InMi1=CAST(SUBSTRING(@SIn1,1,2) AS int)*60+CAST(SUBSTRING(@SIn1,4,2) AS int)
    SET @OutMi1=CAST(SUBSTRING(@SOut1,1,2) AS int)*60+CAST(SUBSTRING(@SOut1,4,2) AS int)
  END
  IF @SIn2<>'' AND @SOut2<>''
  BEGIN
    SET @InMi2=CAST(SUBSTRING(@SIn2,1,2) AS int)*60+CAST(SUBSTRING(@SIn2,4,2) AS int)
    SET @OutMi2=CAST(SUBSTRING(@SOut2,1,2) AS int)*60+CAST(SUBSTRING(@SOut2,4,2) AS int)
  END
  IF @SIn3<>'' AND @SOut3<>''
  BEGIN
    SET @InMi3=CAST(SUBSTRING(@SIn3,1,2) AS int)*60+CAST(SUBSTRING(@SIn3,4,2) AS int)
    SET @OutMi3=CAST(SUBSTRING(@SOut3,1,2) AS int)*60+CAST(SUBSTRING(@SOut3,4,2) AS int)
  END
  IF @SIn4<>'' AND @SOut4<>''
  BEGIN
    SET @InMi4=CAST(SUBSTRING(@SIn4,1,2) AS int)*60+CAST(SUBSTRING(@SIn4,4,2) AS int)
    SET @OutMi4=CAST(SUBSTRING(@SOut4,1,2) AS int)*60+CAST(SUBSTRING(@SOut4,4,2) AS int)
  END
  IF @SIn5<>'' AND @SOut5<>''
  BEGIN
    SET @InMi5=CAST(SUBSTRING(@SIn5,1,2) AS int)*60+CAST(SUBSTRING(@SIn5,4,2) AS int)
    SET @OutMi5=CAST(SUBSTRING(@SOut5,1,2) AS int)*60+CAST(SUBSTRING(@SOut5,4,2) AS int)
  END
  --班段1
  IF @SIn1<>'' AND @SOut1<>''
  BEGIN
    SELECT @TypeID=CalcTypeID,@OTType=OvertimeTypeID,@Rate=OvertimeRate,@Start=Start,@Tune=Tune,@Integer=[Integer] FROM KQ_RuleCalc WHERE SortID=@SortID1
    IF @TypeID=0 SELECT @NormalStart=@Start,@NormalTune=@Tune,@NormalInteger=@Integer
    IF @SIn2<>'' AND @SOut2<>''
      SET @DriftTime=DATEADD(mi,@InMi2,@Date)
    ELSE
      SET @DriftTime=DATEADD(mi,24*60+@InMi1-@SAhead1,@Date)
    EXEC PKQ_CalcNormalTime @EmpNo,@Date,@DayOffIDList,@ShiftHrs,@SAhead1,@SDefer1,@SIn1,@SOut1,@NeedIn1,@NeedOut1,@SortID1,@Drift1,
      @TypeID,@OTType,@Rate,1,@In1 output,@Out1 output,@RegHrsT output,@AbsentDays output,@LateMins output,@LateCount output,
      @LeaveMins output,@LeaveCount output,@OtHrs output,@OtHrsM output,@SunHrsM output,@HdHrsM output,@OutHrs output,@RegHrs output,
      @Hrs0 output,@Hrs1 output,@Hrs2 output,@Hrs3 output,@Hrs4 output,@Hrs5 output,@Hrs6 output,@Hrs7 output,@Hrs8 output,@Hrs9 output,
      @DriftTime,@LateIgnore,@LeaveIgnore,@LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@ReadLate,@ReadLeave,@LateHrs,
      @LeaveHrs,@Start,@Tune,@Integer,@IsLeaveOvertime
  END
  --班段2
  IF @SIn2<>'' AND @SOut2<>''
  BEGIN
    SELECT @TypeID=CalcTypeID,@OTType=OvertimeTypeID,@Rate=OvertimeRate,@Start=Start,@Tune=Tune,@Integer=[Integer] FROM KQ_RuleCalc WHERE SortID=@SortID2
    IF @TypeID=0 SELECT @NormalStart=@Start,@NormalTune=@Tune,@NormalInteger=@Integer
    IF @SIn3<>'' AND @SOut3<>''
      SET @DriftTime=DATEADD(mi,@InMi3,@Date)
    ELSE
      SET @DriftTime=DATEADD(mi,24*60+@InMi1-@SAhead1,@Date)
    EXEC PKQ_CalcNormalTime @EmpNo,@Date,@DayOffIDList,@ShiftHrs,@SAhead2,@SDefer2,@SIn2,@SOut2,@NeedIn2,@NeedOut2,@SortID2,@Drift2,
      @TypeID,@OTType,@Rate,2,@In2 output,@Out2 output,@RegHrsT output,@AbsentDays output,@LateMins output,@LateCount output,
      @LeaveMins output,@LeaveCount output,@OtHrs output,@OtHrsM output,@SunHrsM output,@HdHrsM output,@OutHrs output,@RegHrs output,
      @Hrs0 output,@Hrs1 output,@Hrs2 output,@Hrs3 output,@Hrs4 output,@Hrs5 output,@Hrs6 output,@Hrs7 output,@Hrs8 output,@Hrs9 output,
      @DriftTime,@LateIgnore,@LeaveIgnore,@LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@ReadLate,@ReadLeave,@LateHrs,
      @LeaveHrs,@Start,@Tune,@Integer,@IsLeaveOvertime
  END
  --班段3
  IF @SIn3<>'' AND @SOut3<>''
  BEGIN
    SELECT @TypeID=CalcTypeID,@OTType=OvertimeTypeID,@Rate=OvertimeRate,@Start=Start,@Tune=Tune,@Integer=[Integer] FROM KQ_RuleCalc WHERE SortID=@SortID3
    IF @TypeID=0 SELECT @NormalStart=@Start,@NormalTune=@Tune,@NormalInteger=@Integer
    IF @SIn4<>'' AND @SOut4<>''
      SET @DriftTime=DATEADD(mi,@InMi4,@Date)
    ELSE
      SET @DriftTime=DATEADD(mi,24*60+@InMi1-@SAhead1,@Date)
    EXEC PKQ_CalcNormalTime @EmpNo,@Date,@DayOffIDList,@ShiftHrs,@SAhead3,@SDefer3,@SIn3,@SOut3,@NeedIn3,@NeedOut3,@SortID3,@Drift3,
      @TypeID,@OTType,@Rate,3,@In3 output,@Out3 output,@RegHrsT output,@AbsentDays output,@LateMins output,@LateCount output,
      @LeaveMins output,@LeaveCount output,@OtHrs output,@OtHrsM output,@SunHrsM output,@HdHrsM output,@OutHrs output,@RegHrs output,
      @Hrs0 output,@Hrs1 output,@Hrs2 output,@Hrs3 output,@Hrs4 output,@Hrs5 output,@Hrs6 output,@Hrs7 output,@Hrs8 output,@Hrs9 output,
      @DriftTime,@LateIgnore,@LeaveIgnore,@LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@ReadLate,@ReadLeave,@LateHrs,
      @LeaveHrs,@Start,@Tune,@Integer,@IsLeaveOvertime
  END
  --班段4
  IF @SIn4<>'' AND @SOut4<>''
  BEGIN
    SELECT @TypeID=CalcTypeID,@OTType=OvertimeTypeID,@Rate=OvertimeRate,@Start=Start,@Tune=Tune,@Integer=[Integer] FROM KQ_RuleCalc WHERE SortID=@SortID4
    IF @TypeID=0 SELECT @NormalStart=@Start,@NormalTune=@Tune,@NormalInteger=@Integer
    IF @SIn5<>'' AND @SOut5<>''
      SET @DriftTime=DATEADD(mi,@InMi5,@Date)
    ELSE
      SET @DriftTime=DATEADD(mi,24*60+@InMi1-@SAhead1,@Date)
    EXEC PKQ_CalcNormalTime @EmpNo,@Date,@DayOffIDList,@ShiftHrs,@SAhead4,@SDefer4,@SIn4,@SOut4,@NeedIn4,@NeedOut4,@SortID4,@Drift4,
      @TypeID,@OTType,@Rate,4,@In4 output,@Out4 output,@RegHrsT output,@AbsentDays output,@LateMins output,@LateCount output,
      @LeaveMins output,@LeaveCount output,@OtHrs output,@OtHrsM output,@SunHrsM output,@HdHrsM output,@OutHrs output,@RegHrs output,
      @Hrs0 output,@Hrs1 output,@Hrs2 output,@Hrs3 output,@Hrs4 output,@Hrs5 output,@Hrs6 output,@Hrs7 output,@Hrs8 output,@Hrs9 output,
      @DriftTime,@LateIgnore,@LeaveIgnore,@LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@ReadLate,@ReadLeave,@LateHrs,
      @LeaveHrs,@Start,@Tune,@Integer,@IsLeaveOvertime
  END
  --班段5
  IF @SIn5<>'' AND @SOut5<>''
  BEGIN
    SELECT @TypeID=CalcTypeID,@OTType=OvertimeTypeID,@Rate=OvertimeRate,@Start=Start,@Tune=Tune,@Integer=[Integer] FROM KQ_RuleCalc WHERE SortID=@SortID5
    IF @TypeID=0 SELECT @NormalStart=@Start,@NormalTune=@Tune,@NormalInteger=@Integer
    SET @DriftTime=DATEADD(mi,24*60+@InMi1-@SAhead1,@Date)
    EXEC PKQ_CalcNormalTime @EmpNo,@Date,@DayOffIDList,@ShiftHrs,@SAhead5,@SDefer5,@SIn5,@SOut5,@NeedIn5,@NeedOut5,@SortID5,@Drift5,
      @TypeID,@OTType,@Rate,5,@In5 output,@Out5 output,@RegHrsT output,@AbsentDays output,@LateMins output,@LateCount output,
      @LeaveMins output,@LeaveCount output,@OtHrs output,@OtHrsM output,@SunHrsM output,@HdHrsM output,@OutHrs output,@RegHrs output,
      @Hrs0 output,@Hrs1 output,@Hrs2 output,@Hrs3 output,@Hrs4 output,@Hrs5 output,@Hrs6 output,@Hrs7 output,@Hrs8 output,@Hrs9 output,
      @DriftTime,@LateIgnore,@LeaveIgnore,@LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@ReadLate,@ReadLeave,@LateHrs,
      @LeaveHrs,@Start,@Tune,@Integer,@IsLeaveOvertime
  END
  IF @AbsentDays<0 SET @AbsentDays=0
  IF @AbsentDays>0
  BEGIN
    IF @RestDaysDB>0--减无规则的休息天数
    BEGIN
      IF @RestDaysDB>@AbsentDays
      BEGIN
        SET @TempRestDay=@AbsentDays
        SET @RestDays=@RestDays+@AbsentDays
        SET @RestDaysDB=@RestDaysDB-@AbsentDays
        SET @AbsentDays=0
      END
      ELSE
      BEGIN
        SET @TempRestDay=@RestDaysDB
        SET @RestDays=@RestDays+@RestDaysDB
        SET @AbsentDays=@AbsentDays-@RestDaysDB
        SET @RestDaysDB=0
      END
    END
  END
  IF @AbsentDays<0 SET @AbsentDays=0
  SET @ShiftOtHrs=0
  SET @RestTime=DATEADD(ss,86399,@Date)
  DECLARE RecOver SCROLL CURSOR FOR SELECT a.BeginTime,a.EndTime,a.AheadHrs,a.AheadMins,a.DeferHrs,a.DeferMins,b.OvertimeTypeID,b.OvertimeRate,
    b.Start,b.Tune,b.[Integer],a.SortID 
    FROM KQ_EmpOtSure a INNER JOIN KQ_RuleCalc b ON b.SortID=a.SortID
    WHERE a.EmpNo=@EmpNo AND BeginTime>=@Date AND EndTime<=@RestTime
  OPEN RecOver
  FETCH FIRST FROM RecOver INTO @OtBeginTime,@OtEndTime,@OtNeedIn,@OtAhead,@OtNeedOut,@OtDelay,@OtType,@Rate,@Start,@Tune,@Integer,@SortIDOld
  WHILE @@FETCH_STATUS=0
  BEGIN
    EXEC PKQ_CalcOtHrs @EmpNo,@OtBeginTime,@OtEndTime,@OtNeedIn,@OtAhead,@OtNeedOut,@OtDelay,@ReadLate,@ReadLeave,@OtHrs1 output,@OutHrs1 output
    SET @OtHrs1=@OtHrs1*@Rate
    SET @OtHrs1=dbo.CalcAdjust(@OtHrs1,@Start,@Tune,@Integer)
    EXEC PKQ_CalcRegHrs @EmpNo,@DayOffIDList,@OtBeginTime,@otEndTime,@IsLeaveOvertime,@SortIDOld,@RegHrs1 output,@Hrs0X output,@Hrs1X output,@Hrs2X output,
      @Hrs3X output,@Hrs4X output,@Hrs5X output,@Hrs6X output,@Hrs7X output,@Hrs8X output,@Hrs9X output
    SELECT @ShiftOtHrs=@OtHrs1-@OutHrs1-@RegHrs1,@Hrs0=@Hrs0+@Hrs0X,@Hrs1=@Hrs1+@Hrs1X,@Hrs2=@Hrs2+@Hrs2X,@Hrs3=@Hrs3+@Hrs3X,
      @Hrs4=@Hrs4+@Hrs4X,@Hrs5=@Hrs5+@Hrs5X,@Hrs6=@Hrs6+@Hrs6X,@Hrs7=@Hrs7+@Hrs7X,@Hrs8=@Hrs8+@Hrs8X,@Hrs9=@Hrs9+@Hrs9X
    IF @ShiftOtHrs<0 SET @ShiftOtHrs=0
    IF @OtType=1 SET @OtHrsM=@OtHrsM+@ShiftOtHrs
    IF @OtType=2 SET @SunHrsM=@SunHrsM+@ShiftOtHrs
    IF @OtType=3 SET @HdHrsM=@HdHrsM+@ShiftOtHrs
    FETCH NEXT FROM RecOver INTO @OtBeginTime,@OtEndTime,@OtNeedIn,@OtAhead,@OtNeedOut,@OtDelay,@OtType,@Rate,@Start,@Tune,@Integer,@SortIDOld
  END
  CLOSE RecOver
  DEALLOCATE RecOver
  SET @OtHrs=@OtHrs+@ShiftOtHrs
   SET @TempOtHrs=dbo.CalcAdjust(@OtHrs,@Start,@Tune,@Integer)
   IF @TempOtHrs<>@OtHrs
  BEGIN  
    SET @OtHrs=@TempOtHrs
  END
  IF @ShiftHrs<>0
  BEGIN
    SET @WorkDays=1-@AbsentDays-@RegHrsT/@ShiftHrs-@TempRestDay
    IF @WorkDays<0 SET @WorkDays=0
  END
  SET @WorkHrs=@WorkDays*@ShiftHrs
  SET @TempWorkHrs=dbo.CalcAdjust(@WorkHrs,@NormalStart,@NormalTune,@NormalInteger)
  IF @TempWorkHrs<>@WorkHrs AND @ShiftHrs<>0
  BEGIN
    SET @TempAbsentDays=ABS((@WorkHrs-@TempWorkHrs)/@ShiftHrs)
    SET @AbsentDays=@AbsentDays-@TempAbsentDays
    SET @WorkHrs=@TempWorkHrs
    IF @WorkHrs>@ShiftHrs SET @WorkHrs=@ShiftHrs
    SET @WorkDays=@WorkHrs/@ShiftHrs
  END
  IF @Small<>'' AND @Small<>':'
  BEGIN
    SET @SmallMi=CAST(SUBSTRING(@Small,1,2) AS int)*60+CAST(SUBSTRING(@Small,4,2) AS int)
    IF @Big<>'' AND @Big<>':' SET @BigMi=CAST(SUBSTRING(@Big,1,2) AS int)*60+CAST(SUBSTRING(@Big,4,2) AS int)
    IF @In1<>'' AND @Out1<>''
    BEGIN
      SET @InMi=CAST(SUBSTRING(@In1,1,2) AS int)*60+CAST(SUBSTRING(@In1,4,2) AS int)
      SET @OutMi=CAST(SUBSTRING(@Out1,1,2) AS int)*60+CAST(SUBSTRING(@Out1,4,2) AS int)
      IF @BigMi IS NOT NULL
      BEGIN
        IF @OutMi>@BigMi SET @NSCount=@NSCount+1
      END
      ELSE IF @OutMi>@SmallMi
        SET @MidCount=@MidCount+1
    END
    IF @In2<>'' AND @Out2<>''
    BEGIN
      SET @InMi=CAST(SUBSTRING(@In2,1,2) AS int)*60+CAST(SUBSTRING(@In2,4,2) AS int)
      SET @OutMi=CAST(SUBSTRING(@Out2,1,2) AS int)*60+CAST(SUBSTRING(@Out2,4,2) AS int)
      IF @BigMi IS NOT NULL
      BEGIN
        IF @OutMi>@BigMi SET @NSCount=@NSCount+1
      END
      ELSE IF @OutMi>@SmallMi
        SET @MidCount=@MidCount+1
    END
    IF @In3<>'' AND @Out3<>''
    BEGIN
      SET @InMi=CAST(SUBSTRING(@In3,1,2) AS int)*60+CAST(SUBSTRING(@In3,4,2) AS int)
      SET @OutMi=CAST(SUBSTRING(@Out3,1,2) AS int)*60+CAST(SUBSTRING(@Out3,4,2) AS int)
      IF @BigMi IS NOT NULL
      BEGIN
        IF @OutMi>@BigMi SET @NSCount=@NSCount+1
      END
      ELSE IF @OutMi>@SmallMi
        SET @MidCount=@MidCount+1
    END
    IF @In4<>'' AND @Out4<>''
    BEGIN
      SET @InMi=CAST(SUBSTRING(@In4,1,2) AS int)*60+CAST(SUBSTRING(@In4,4,2) AS int)
      SET @OutMi=CAST(SUBSTRING(@Out4,1,2) AS int)*60+CAST(SUBSTRING(@Out4,4,2) AS int)
      IF @BigMi IS NOT NULL
      BEGIN
        IF @OutMi>@BigMi SET @NSCount=@NSCount+1
      END
      ELSE IF @OutMi>@SmallMi
        SET @MidCount=@MidCount+1
    END
    IF @In5<>'' AND @Out5<>''
    BEGIN
      SET @InMi=CAST(SUBSTRING(@In5,1,2) AS int)*60+CAST(SUBSTRING(@In5,4,2) AS int)
      SET @OutMi=CAST(SUBSTRING(@Out5,1,2) AS int)*60+CAST(SUBSTRING(@Out5,4,2) AS int)
      IF @BigMi IS NOT NULL
      BEGIN
        IF @OutMi>@BigMi SET @NSCount=@NSCount+1
      END
      ELSE IF @OutMi>@SmallMi
        SET @MidCount=@MidCount+1
    END
  END
   IF @RegHrs<0 OR @RegHrs>24 SET @RegHrs=0
  IF @RegHrs<>0
  BEGIN
    SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@RegHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='RegHrs'
    SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
  END
  IF @OtHrs<0 OR @OtHrs>24 SET @OtHrs=0
  IF @OtHrs<>0
  BEGIN
    SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@OtHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'
    SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
  END
  IF @AbsentDays<0 OR @AbsentDays>1 SET @AbsentDays=0
  IF @AbsentDays<>0
  BEGIN
    SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@AbsentDays AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='AbsentDays'
    SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Days'
  END
  IF @OutHrs<0 OR @OutHrs>24 SET @OutHrs=0
  IF @OutHrs<>0
  BEGIN
    SELECT @Remark=@Remark+','+[Name]+ CAST((CAST(@OutHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='OutHrs'
    SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
  END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_KQCalculateWeek') DROP PROCEDURE PKQ_KQCalculateWeek
GO
CREATE PROCEDURE PKQ_KQCalculateWeek(@Day varchar(30) output,@LoopDate dateTime) WITH ENCRYPTION AS
       IF @Day IS NULL 
       BEGIN
		SET @Day=RIGHT('0'+CAST(DAY(@LoopDate) AS VARCHAR(2)),2)
		IF DATEPART(w,@LoopDate)=1 SET @Day=@Day+' '+(SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Sunday')
		IF DATEPART(w,@LoopDate)=2 SET @Day=@Day+' '+(SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Monday')
		IF DATEPART(w,@LoopDate)=3 SET @Day=@Day+' '+(SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Tuesday')
		IF DATEPART(w,@LoopDate)=4 SET @Day=@Day+' '+(SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Wednesday')
		IF DATEPART(w,@LoopDate)=5 SET @Day=@Day+' '+(SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Thursday')
		IF DATEPART(w,@LoopDate)=6 SET @Day=@Day+' '+(SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Friday')
		IF DATEPART(w,@LoopDate)=7 SET @Day=@Day+' '+(SELECT [Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Saturday')
       END   
GO


IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_KQDetail') DROP PROCEDURE PKQ_KQDetail
GO
CREATE PROCEDURE PKQ_KQDetail(@Day varchar(30) output,@Time varchar(50) output,@MustDays decimal(16,5),@AbsentDays decimal(16,5),@WorkDays decimal(16,5), 
        @LoopDate dateTime, @Remark varchar(255),@TimeIn1 varchar(5),@TimeOut1 varchar(5),@TimeIn2 varchar(5),@TimeOut2 varchar(5),
        @TimeIn3 varchar(5),@TimeOut3 varchar(5),@TimeIn4 varchar(5),@TimeOut4 varchar(5),@TimeIn5 varchar(5),@TimeOut5 varchar(5),@NoRule bit,@WorkHrs decimal(16,5),
     @WeekIsWork bit,@ReadWorkHrs bit) WITH ENCRYPTION AS
        
       EXEC PKQ_KQCalculateWeek @Day output,@LoopDate
 
  --     IF @MustDays=1 AND @AbsentDays=1 AND @WorkDays=0 
  --     BEGIN
		--SET @Time=@Remark
  --     END 
  --     ELSE IF @NoRule=0 AND @WorkHrs=0 AND @WeekIsWork=1 AND @ReadWorkHrs=1
  --     BEGIN
		--SET @Time=@Remark
  --     END
       --ELSE
       --BEGIN 
        IF @TimeIn1!='' SET @Time=@TimeIn1
        
        IF @TimeOut1!=''
        BEGIN
         IF @TimeIn1!='' SET @Time=@Time+'-'+@TimeOut1
         ELSE SET @Time=Left('      '+@TimeOut1,11)
        END
        
        IF @TimeIn2!='' SET @Time=@Time+char(13)+@TimeIn2
        ELSE SET @Time=@Time+left(char(13)+'       ',7)
        
        IF @TimeOut2!=''
        BEGIN
         IF @TimeIn2!='' SET @Time=@Time+'-'+@TimeOut2
         ELSE SET @Time=@Time+@TimeOut2
        END
        
        IF @TimeIn3!='' SET @Time=@Time+char(13)+@TimeIn3
         ELSE SET @Time=@Time+left(char(13)+'       ',7)
         
        IF @TimeOut3!=''
        BEGIN
         IF @TimeIn3!='' SET @Time=@Time+'-'+@TimeOut3
         ELSE SET @Time=@Time+@TimeOut3
        END
        
        IF @TimeIn4!='' SET @Time=@Time+char(13)+@TimeIn4
         ELSE SET @Time=@Time+left(char(13)+'       ',7)
         
        IF @TimeOut4!=''
        BEGIN
         IF @TimeIn4!='' SET @Time=@Time+'-'+@TimeOut4
         ELSE SET @Time=@Time+@TimeOut4
        END
        
        IF @TimeIn5!='' SET @Time=@Time+char(13)+@TimeIn5
         ELSE SET @Time=@Time+left(char(13)+'       ',7)
         
        IF @TimeOut5!=''
        BEGIN
         IF @TimeIn5!='' SET @Time=@Time+'-'+@TimeOut5
         ELSE SET @Time=@Time+@TimeOut5
        END
       --END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_KQCalcDetail') DROP PROCEDURE PKQ_KQCalcDetail
GO
CREATE PROCEDURE PKQ_KQCalcDetail(@DayCount int,@Day01 varchar(30) output,@Day02 varchar(30) output,@Day03 varchar(30) output,@Day04 varchar(30) output,@Day05 varchar(30) output,@Day06 varchar(30) output,
     @Day07 varchar(30) output,@Day08 varchar(30) output,@Day09 varchar(30) output,@Day10 varchar(30) output,
     @Day11 varchar(30) output,@Day12 varchar(30) output,@Day13 varchar(30) output,@Day14 varchar(30) output,@Day15 varchar(30) output,@Day16 varchar(30) output,@Day17 varchar(30) output,
     @Day18 varchar(30) output,@Day19 varchar(30) output,@Day20 varchar(30) output,@Day21 varchar(30) output,
     @Day22 varchar(30) output,@Day23 varchar(30) output,@Day24 varchar(30) output,@Day25 varchar(30) output,@Day26 varchar(30) output,@Day27 varchar(30) output,@Day28 varchar(30) output,
     @Day29 varchar(30) output,@Day30 varchar(30) output,@Day31 varchar(30) output,
     @Time01 varchar(50) output,@Time02 varchar(50) output,@Time03 varchar(50) output,@Time04 varchar(50) output,@Time05 varchar(50) output,@Time06 varchar(50) output,
     @Time07 varchar(50) output,@Time08 varchar(50) output,@Time09 varchar(50) output,@Time10 varchar(50) output,
     @Time11 varchar(50) output,@Time12 varchar(50) output,@Time13 varchar(50) output,@Time14 varchar(50) output,@Time15 varchar(50) output,@Time16 varchar(50) output,
     @Time17 varchar(50) output,@Time18 varchar(50) output,@Time19 varchar(50) output,@Time20 varchar(50) output,
     @Time21 varchar(50) output,@Time22 varchar(50) output,@Time23 varchar(50) output,@Time24 varchar(50) output,@Time25 varchar(50) output,@Time26 varchar(50) output,
     @Time27 varchar(50) output,@Time28 varchar(50) output,@Time29 varchar(50) output,@Time30 varchar(50) output,
     @Time31 varchar(50) output,@MustDays decimal(16,5),@AbsentDays decimal(16,5),@WorkDays decimal(16,5), 
     @LoopDate dateTime, @Remark varchar(255),@TimeIn1 varchar(5),@TimeOut1 varchar(5),@TimeIn2 varchar(5),@TimeOut2 varchar(5),
     @TimeIn3 varchar(5),@TimeOut3 varchar(5),@TimeIn4 varchar(5),@TimeOut4 varchar(5),@TimeIn5 varchar(5),@TimeOut5 varchar(5),@NoRule bit,@WorkHrs decimal(16,5),
     @WeekIsWork bit,@ReadWorkHrs bit) WITH ENCRYPTION AS
     IF @Time01 IS NULL SET @Time01=''
     IF @Time02 IS NULL SET @Time02=''
     IF @Time03 IS NULL SET @Time03=''
     IF @Time04 IS NULL SET @Time04=''
     IF @Time05 IS NULL SET @Time05=''
     IF @Time06 IS NULL SET @Time06=''
     IF @Time07 IS NULL SET @Time07=''
     IF @Time08 IS NULL SET @Time08=''
     IF @Time09 IS NULL SET @Time09=''
     IF @Time10 IS NULL SET @Time10=''
     IF @Time11 IS NULL SET @Time11=''
     IF @Time12 IS NULL SET @Time12=''
     IF @Time13 IS NULL SET @Time13=''
     IF @Time14 IS NULL SET @Time14=''
     IF @Time15 IS NULL SET @Time15=''
     IF @Time16 IS NULL SET @Time16=''
     IF @Time17 IS NULL SET @Time17=''
     IF @Time18 IS NULL SET @Time18=''
     IF @Time19 IS NULL SET @Time19=''
     IF @Time20 IS NULL SET @Time20=''
     IF @Time21 IS NULL SET @Time21=''
     IF @Time22 IS NULL SET @Time22=''
     IF @Time23 IS NULL SET @Time23=''
     IF @Time24 IS NULL SET @Time24=''
     IF @Time25 IS NULL SET @Time25=''
     IF @Time26 IS NULL SET @Time26=''
     IF @Time27 IS NULL SET @Time27=''
     IF @Time28 IS NULL SET @Time28=''
     IF @Time29 IS NULL SET @Time29=''
     IF @Time30 IS NULL SET @Time30=''
     IF @Time31 IS NULL SET @Time31=''
     
      --第1天
      IF @DayCount=1 
      BEGIN
      EXEC PKQ_KQDetail @Day01 output,@Time01 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs
      END
       --第2天
      IF @DayCount=2 
      BEGIN
      EXEC PKQ_KQDetail @Day02 output,@Time02 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs
      END
       --第3天
      IF @DayCount=3 
      BEGIN
      EXEC PKQ_KQDetail @Day03 output,@Time03 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs
      END
       --第4天
      IF @DayCount=4 
      BEGIN
      EXEC PKQ_KQDetail @Day04 output,@Time04 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs
      END
       --第5天
      IF @DayCount=5 
      BEGIN
      EXEC PKQ_KQDetail @Day05 output,@Time05 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第6天
      IF @DayCount=6 
      BEGIN
      EXEC PKQ_KQDetail @Day06 output,@Time06 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第7天
      IF @DayCount=7 
      BEGIN
      EXEC PKQ_KQDetail @Day07 output,@Time07 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第8天
      IF @DayCount=8 
      BEGIN
      EXEC PKQ_KQDetail @Day08 output,@Time08 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第9天
      IF @DayCount=1 
      BEGIN
      EXEC PKQ_KQDetail @Day09 output,@Time09 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第10天
      IF @DayCount=10 
      BEGIN
      EXEC PKQ_KQDetail @Day10 output,@Time10 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第11天
      IF @DayCount=11
      BEGIN
      EXEC PKQ_KQDetail @Day11 output,@Time11 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第12天
      IF @DayCount=12 
      BEGIN
      EXEC PKQ_KQDetail @Day12 output,@Time12 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第13天
      IF @DayCount=13
      BEGIN
      EXEC PKQ_KQDetail @Day13 output,@Time13 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第14天
      IF @DayCount=14 
      BEGIN
      EXEC PKQ_KQDetail @Day14 output,@Time14 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第15天
      IF @DayCount=15 
      BEGIN
      EXEC PKQ_KQDetail @Day15 output,@Time15 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第16天
      IF @DayCount=16 
      BEGIN
      EXEC PKQ_KQDetail @Day16 output,@Time16 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第17天
      IF @DayCount=17 
      BEGIN
      EXEC PKQ_KQDetail @Day17 output,@Time17 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第18天
      IF @DayCount=18 
      BEGIN
      EXEC PKQ_KQDetail @Day18 output,@Time18 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第19天
      IF @DayCount=19 
      BEGIN
      EXEC PKQ_KQDetail @Day19 output,@Time19 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第20天
      IF @DayCount=20
      BEGIN
      EXEC PKQ_KQDetail @Day20 output,@Time20 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第21天
      IF @DayCount=21 
      BEGIN
      EXEC PKQ_KQDetail @Day21 output,@Time21 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第22天
      IF @DayCount=22 
      BEGIN
      EXEC PKQ_KQDetail @Day22 output,@Time22 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第23天
      IF @DayCount=23 
      BEGIN
      EXEC PKQ_KQDetail @Day23 output,@Time23 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第24天
      IF @DayCount=24 
      BEGIN
      EXEC PKQ_KQDetail @Day24 output,@Time24 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第25天
      IF @DayCount=25 
      BEGIN
      EXEC PKQ_KQDetail @Day25 output,@Time25 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第26天
      IF @DayCount=26 
      BEGIN
      EXEC PKQ_KQDetail @Day26 output,@Time26 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第27天
      IF @DayCount=27 
      BEGIN
      EXEC PKQ_KQDetail @Day27 output,@Time27 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第28天
      IF @DayCount=28 
      BEGIN
      EXEC PKQ_KQDetail @Day28 output,@Time28 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第29天
      IF @DayCount=29 
      BEGIN
      EXEC PKQ_KQDetail @Day29 output,@Time29 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第30天
      IF @DayCount=30 
      BEGIN
      EXEC PKQ_KQDetail @Day30 output,@Time30 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs 
      END
       --第一天
      IF @DayCount=31 
      BEGIN
      EXEC PKQ_KQDetail @Day31 output,@Time31 output,@MustDays,@AbsentDays,@WorkDays, 
        @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,
        @TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs
      END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_KQCalcDetailSave') DROP PROCEDURE PKQ_KQCalcDetailSave
GO
CREATE PROCEDURE PKQ_KQCalcDetailSave(@Day01 varchar(30),@Day02 varchar(30) ,@Day03 varchar(30),@Day04 varchar(30),@Day05 varchar(30),@Day06 varchar(30),
     @Day07 varchar(30),@Day08 varchar(30),@Day09 varchar(30),@Day10 varchar(30),
     @Day11 varchar(30),@Day12 varchar(30),@Day13 varchar(30),@Day14 varchar(30),@Day15 varchar(30),@Day16 varchar(30),@Day17 varchar(30),
     @Day18 varchar(30),@Day19 varchar(30),@Day20 varchar(30),@Day21 varchar(30),
     @Day22 varchar(30),@Day23 varchar(30),@Day24 varchar(30),@Day25 varchar(30),@Day26 varchar(30),@Day27 varchar(30),@Day28 varchar(30),
     @Day29 varchar(30),@Day30 varchar(30),@Day31 varchar(30),
     @Time01 varchar(50),@Time02 varchar(50),@Time03 varchar(50),@Time04 varchar(50),@Time05 varchar(50),@Time06 varchar(50),
     @Time07 varchar(50),@Time08 varchar(50),@Time09 varchar(50),@Time10 varchar(50),
     @Time11 varchar(50),@Time12 varchar(50),@Time13 varchar(50),@Time14 varchar(50),@Time15 varchar(50),@Time16 varchar(50),
     @Time17 varchar(50),@Time18 varchar(50),@Time19 varchar(50),@Time20 varchar(50),
     @Time21 varchar(50),@Time22 varchar(50),@Time23 varchar(50),@Time24 varchar(50),@Time25 varchar(50),@Time26 varchar(50),
     @Time27 varchar(50),@Time28 varchar(50),@Time29 varchar(50),@Time30 varchar(50),
     @Time31 varchar(50),@StartDate datetime,@EndDate datetime,@KQYM varchar(6),@EmpNo varchar(20)) WITH ENCRYPTION AS
     DECLARE @WeekDate datetime
     DECLARE @KQDate varchar(50)
		 SET @WeekDate=@StartDate+1
		EXEC PKQ_KQCalculateWeek @Day02 output,@WeekDate
		 SET @WeekDate=@StartDate+2
		EXEC PKQ_KQCalculateWeek @Day03 output,@WeekDate
	     SET @WeekDate=@StartDate+3
		EXEC PKQ_KQCalculateWeek @Day04 output,@WeekDate
	     SET @WeekDate=@StartDate+4
		EXEC PKQ_KQCalculateWeek @Day05 output,@WeekDate
	     SET @WeekDate=@StartDate+5
		EXEC PKQ_KQCalculateWeek @Day06 output,@WeekDate
	     SET @WeekDate=@StartDate+6
		EXEC PKQ_KQCalculateWeek @Day07 output,@WeekDate
	     SET @WeekDate=@StartDate+7
		EXEC PKQ_KQCalculateWeek @Day08 output,@WeekDate
	     SET @WeekDate=@StartDate+8
		EXEC PKQ_KQCalculateWeek @Day09 output,@WeekDate
	     SET @WeekDate=@StartDate+9
		EXEC PKQ_KQCalculateWeek @Day10 output,@WeekDate
	     SET @WeekDate=@StartDate+10
		EXEC PKQ_KQCalculateWeek @Day11 output,@WeekDate
	     SET @WeekDate=@StartDate+11
		EXEC PKQ_KQCalculateWeek @Day12 output,@WeekDate
	     SET @WeekDate=@StartDate+12
		EXEC PKQ_KQCalculateWeek @Day13 output,@WeekDate
	     SET @WeekDate=@StartDate+13
		EXEC PKQ_KQCalculateWeek @Day14 output,@WeekDate
	     SET @WeekDate=@StartDate+14
		EXEC PKQ_KQCalculateWeek @Day15 output,@WeekDate
	     SET @WeekDate=@StartDate+15
		EXEC PKQ_KQCalculateWeek @Day16 output,@WeekDate
		 SET @WeekDate=@StartDate+16
		EXEC PKQ_KQCalculateWeek @Day17 output,@WeekDate
		 SET @WeekDate=@StartDate+17
		EXEC PKQ_KQCalculateWeek @Day18 output,@WeekDate
		 SET @WeekDate=@StartDate+18
		EXEC PKQ_KQCalculateWeek @Day19 output,@WeekDate
		 SET @WeekDate=@StartDate+19
		EXEC PKQ_KQCalculateWeek @Day20 output,@WeekDate
		 SET @WeekDate=@StartDate+20
		EXEC PKQ_KQCalculateWeek @Day21 output,@WeekDate
		 SET @WeekDate=@StartDate+21
		EXEC PKQ_KQCalculateWeek @Day22 output,@WeekDate
		 SET @WeekDate=@StartDate+22
		EXEC PKQ_KQCalculateWeek @Day23 output,@WeekDate
		 SET @WeekDate=@StartDate+23
		EXEC PKQ_KQCalculateWeek @Day24 output,@WeekDate
		 SET @WeekDate=@StartDate+24
		EXEC PKQ_KQCalculateWeek @Day25 output,@WeekDate
		 SET @WeekDate=@StartDate+25
		EXEC PKQ_KQCalculateWeek @Day26 output,@WeekDate
		 SET @WeekDate=@StartDate+26
		EXEC PKQ_KQCalculateWeek @Day27 output,@WeekDate
		 SET @WeekDate=@StartDate+27
		EXEC PKQ_KQCalculateWeek @Day28 output,@WeekDate
		 SET @WeekDate=@StartDate+28
		EXEC PKQ_KQCalculateWeek @Day29 output,@WeekDate
		 SET @WeekDate=@StartDate+29
		EXEC PKQ_KQCalculateWeek @Day30 output,@WeekDate
		 SET @WeekDate=@StartDate+30
		EXEC PKQ_KQCalculateWeek @Day31 output,@WeekDate

		SET @KQDate=RIGHT('0'+CAST(YEAR(@StartDate) AS VARCHAR(4)),4)+'-'+RIGHT('0'+CAST(MONTH(@StartDate) AS VARCHAR(2)),2)
		IF datepart(month,@StartDate)!=datepart(month,@EndDate)
		SET @KQDate= @KQDate +'--'+RIGHT('0'+CAST(YEAR(@EndDate) AS VARCHAR(4)),4)+'-'+RIGHT('0'+CAST(MONTH(@EndDate) AS VARCHAR(2)),2)
   
		INSERT INTO KQ_KQReportMonthDetail(KQYM,KQDate,EmpNo,UpdateDate,Day01,Day02,Day03,Day04,Day05,Day06,Day07,Day08,Day09,Day10,Day11,Day12,Day13,Day14,Day15,
                        Day16,Day17,Day18,Day19,Day20,Day21,Day22,Day23,Day24,Day25,Day26,Day27,Day28,Day29,Day30,Day31,Time01,Time02,Time03,Time04,Time05,Time06,Time07,Time08,
                        Time09,Time10,Time11,Time12,Time13,Time14,Time15,Time16,Time17,Time18,Time19,Time20,Time21,Time22,Time23,Time24,Time25,Time26,Time27,Time28,Time29,
                        Time30,Time31) VALUES(@KQYM,@KQDate,@EmpNo,getdate(),@Day01,@Day02,@Day03,@Day04,@Day05,@Day06,@Day07,@Day08,@Day09,@Day10,@Day11,@Day12,@Day13,@Day14,@Day15,
                        @Day16,@Day17,@Day18,@Day19,@Day20,@Day21,@Day22,@Day23,@Day24,@Day25,@Day26,@Day27,@Day28,@Day29,@Day30,@Day31,@Time01,@Time02,@Time03,@Time04,@Time05,
                        @Time06,@Time07,@Time08,@Time09,@Time10,@Time11,@Time12,@Time13,@Time14,@Time15,@Time16,@Time17,@Time18,@Time19,@Time20,@Time21,@Time22,@Time23,@Time24,
                        @Time25,@Time26,@Time27,@Time28,@Time29,@Time30,@Time31)
     
     
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_Calc') DROP PROCEDURE PKQ_Calc
GO
CREATE PROCEDURE PKQ_Calc(@EmpNo varchar(20),@StartDate datetime,@EndDate datetime,@KQYM varchar(6)) WITH ENCRYPTION AS
  DECLARE @EmpHireDate datetime
  DECLARE @DimissionDate datetime
  DECLARE @DepartID varchar(20)
  DECLARE @IsAttend bit
  DECLARE @LoopDate datetime
  DECLARE @RuleID varchar(10)
  DECLARE @ShiftID varchar(50),@ShiftCount int
  DECLARE @HasShift bit
  DECLARE @ShiftIDFind varchar(50)
  DECLARE @TimeIn1 varchar(5)
  DECLARE @TimeOut1 varchar(5)
  DECLARE @TimeIn2 varchar(5)
  DECLARE @TimeOut2 varchar(5)
  DECLARE @TimeIn3 varchar(5)
  DECLARE @TimeOut3 varchar(5)
  DECLARE @TimeIn4 varchar(5)
  DECLARE @TimeOut4 varchar(5)
  DECLARE @TimeIn5 varchar(5)
  DECLARE @TimeOut5 varchar(5)
  DECLARE @WorkDays decimal(16,5)
  DECLARE @AbsentDays decimal(16,5)
  DECLARE @OutHrs decimal(16,5)
  DECLARE @RegHrs decimal(16,5)
  DECLARE @WorkHrs decimal(16,5)
  DECLARE @OtHrs decimal(16,5)
  DECLARE @LateMins int
  DECLARE @LeaveMins int
  DECLARE @Remark varchar(255)
  DECLARE @MonthDaysM decimal(16,5)
  DECLARE @SunDaysM decimal(16,5)
  DECLARE @HdDaysM decimal(16,5)
  DECLARE @WorkDaysM decimal(16,5)
  DECLARE @AbsentDaysM decimal(16,5)
  DECLARE @WorkHrsM decimal(16,5)
  DECLARE @OtHrsM decimal(16,5)
  DECLARE @SunHrsM decimal(16,5)
  DECLARE @HdHrsM decimal(16,5)
  DECLARE @LateMinsM int
  DECLARE @LateCountM int
  DECLARE @LeaveMinsM int
  DECLARE @LeaveCountM int
  DECLARE @NSCountM int
  DECLARE @MidCountM int
  DECLARE @Hrs9 decimal(16,5)
  DECLARE @Hrs10 decimal(16,5)
  DECLARE @Hrs11 decimal(16,5)
  DECLARE @Hrs12 decimal(16,5)
  DECLARE @Hrs13 decimal(16,5)
  DECLARE @Hrs14 decimal(16,5)
  DECLARE @Hrs15 decimal(16,5)
  DECLARE @Hrs16 decimal(16,5)
  DECLARE @Hrs17 decimal(16,5)
  DECLARE @Hrs18 decimal(16,5)
  DECLARE @Hrs19 decimal(16,5)
  DECLARE @Hrs10X decimal(16,5)
  DECLARE @Hrs11X decimal(16,5)
  DECLARE @Hrs12X decimal(16,5)
  DECLARE @Hrs13X decimal(16,5)
  DECLARE @Hrs14X decimal(16,5)
  DECLARE @Hrs15X decimal(16,5)
  DECLARE @Hrs16X decimal(16,5)
  DECLARE @Hrs17X decimal(16,5)
  DECLARE @Hrs18X decimal(16,5)
  DECLARE @Hrs19X decimal(16,5)
  DECLARE @IsHD bit
  DECLARE @NoRule bit
  DECLARE @RestDays decimal(16,5),@RestDaysDB decimal(16,5)
  DECLARE @ReadWorkHrs bit
  DECLARE @WeekIsWork bit
  DECLARE @T1 decimal(16,5)
  DECLARE @T2 decimal(16,5)
  DECLARE @T3 decimal(16,5)
  DECLARE @T4 decimal(16,5)
  DECLARE @T5 decimal(16,5)
  DECLARE @T6 decimal(16,5)
  DECLARE @T7 decimal(16,5)
  DECLARE @T8 decimal(16,5)
  DECLARE @T9 decimal(16,5)
  DECLARE @T10 decimal(16,5)
  DECLARE @DayOffID varchar(10)
  DECLARE @DayOffIDList varchar(100)
  DECLARE @RuleExists bit
  DECLARE @DefShiftID varchar(50),@DefCount int
  DECLARE @DupLimit int,@ReadLate bit,@ReadLeave bit,@Small varchar(5),@Big varchar(5)
  DECLARE @LateIgnore int,@LeaveIgnore int,@LateLeaveCalHrs int,@AheadHrs bit,@AheadMins int
  DECLARE @DeferHrs bit,@DeferMins int
  DECLARE @LateHrs int,@LeaveHrs int
  DECLARE @MustDays decimal(16,5)
  DECLARE @MustDaysM decimal(16,5)
  DECLARE @Day01 varchar(30),@Day02 varchar(30),@Day03 varchar(30),@Day04 varchar(30),@Day05 varchar(30),@Day06 varchar(30),@Day07 varchar(30),@Day08 varchar(30),@Day09 varchar(30)
  DECLARE @Day10 varchar(30),@Day11 varchar(30),@Day12 varchar(30),@Day13 varchar(30),@Day14 varchar(30),@Day15 varchar(30),@Day16 varchar(30),@Day17 varchar(30),@Day18 varchar(30),@Day19 varchar(30)
  DECLARE @Day20 varchar(30),@Day21 varchar(30),@Day22 varchar(30),@Day23 varchar(30),@Day24 varchar(30),@Day25 varchar(30),@Day26 varchar(30),@Day27 varchar(30),@Day28 varchar(30),@Day29 varchar(30)
  DECLARE @Day30 varchar(30),@Day31 varchar(30)
  DECLARE @Time01 varchar(50),@Time02 varchar(50),@Time03 varchar(50),@Time04 varchar(50),@Time05 varchar(50),@Time06 varchar(50),@Time07 varchar(50),@Time08 varchar(50)
  DECLARE @Time09 varchar(50),@Time10 varchar(50),@Time11 varchar(50),@Time12 varchar(50),@Time13 varchar(50),@Time14 varchar(50),@Time15 varchar(50),@Time16 varchar(50),@Time17 varchar(50)
  DECLARE @Time18 varchar(50),@Time19 varchar(50),@Time20 varchar(50),@Time21 varchar(50),@Time22 varchar(50),@Time23 varchar(50),@Time24 varchar(50),@Time25 varchar(50),@Time26 varchar(50)
  DECLARE @Time27 varchar(50),@Time28 varchar(50),@Time29 varchar(50),@Time30 varchar(50),@Time31 varchar(50)
  DECLARE @DayCount int
  DECLARE @MarkIndex int
  DECLARE @IsHeadAndTail bit
  DECLARE @IsLeaveOvertime bit
  
  SET @DayCount=1
  SET @IsLeaveOvertime=1
  
  IF EXISTS(SELECT name FROM sysobjects WHERE name='Temp_KQ_KQDataFilter')
    TRUNCATE TABLE Temp_KQ_KQDataFilter
  ELSE
  BEGIN
    SELECT TOP 0 * INTO Temp_KQ_KQDataFilter FROM KQ_KQDataFilter
    ALTER TABLE Temp_KQ_KQDataFilter ADD PRIMARY KEY(GUID)
    ALTER TABLE Temp_KQ_KQDataFilter ADD CONSTRAINT AK_Temp_KQ_KQDataFilter UNIQUE(EmpNo,KQDate,KQTime)
  END
  IF EXISTS(SELECT name FROM sysobjects WHERE name='Temp_KQ_KQData')
    TRUNCATE TABLE Temp_KQ_KQData
  ELSE
  BEGIN
    SELECT TOP 0 * INTO Temp_KQ_KQData FROM KQ_KQData
    ALTER TABLE Temp_KQ_KQData ADD PRIMARY KEY(GUID)
    ALTER TABLE Temp_KQ_KQData ADD CONSTRAINT AK_Temp_KQ_KQData UNIQUE(EmpNo,KQDate,KQTime)
  END
  IF NOT EXISTS(SELECT EmpNo FROM RS_Emp WHERE EmpNo=@EmpNo) RETURN
  SELECT @DimissionDate=CASE WHEN IsDimission=1 THEN DimissionDate ELSE NULL END,@EmpHireDate=EmpHireDate,@DepartID=DepartID,
    @IsAttend=ISNULL(IsAttend,0) FROM RS_Emp WHERE EmpNo=@EmpNo
  DELETE FROM KQ_KQReportDay WHERE EmpNo=@EmpNo AND KQDate>=@StartDate AND KQDate<=@EndDate
  
  DELETE FROM KQ_KQReportMonth WHERE EmpNo=@EmpNo AND KQYM=@KQYM
  DELETE FROM KQ_KQReportMonthDetail WHERE EmpNo=@EmpNo AND KQYM=@KQYM

  SELECT @LoopDate=@StartDate
  --离职
  IF @DimissionDate IS NOT NULL AND @LoopDate>=@DimissionDate RETURN
  SELECT @MonthDaysM=0,@SunDaysM=0,@HdDaysM=0,@WorkDaysM=0,@AbsentDaysM=0,@WorkHrsM=0,@OtHrsM=0,@SunHrsM=0,@HdHrsM=0,@LateMinsM=0,
    @LateCountM=0,@LeaveMinsM=0,@LeaveCountM=0,@NSCountM=0,@MidCountM=0,@Hrs10=0,@Hrs11=0,@Hrs12=0,@Hrs13=0,@Hrs14=0,@Hrs15=0,
    @Hrs16=0,@Hrs17=0,@Hrs18=0,@Hrs19=0,@DayOffIDList='',@MustDaysM=0
  DECLARE RecDayOff SCROLL CURSOR FOR SELECT SortID FROM KQ_RuleCalc WHERE CalcTypeID=2 ORDER BY SortID
  OPEN RecDayOff
  FETCH FIRST FROM RecDayOff INTO @DayOffID
  WHILE @@FETCH_STATUS=0
  BEGIN
    WHILE LEN(@DayOffID)<10 SET @DayOffID='0'+@DayOffID
    SET @DayOffIDList=@DayOffIDList+@DayOffID
    FETCH NEXT FROM RecDayOff INTO @DayOffID
  END
  CLOSE RecDayOff
  DEALLOCATE RecDayOff
  SELECT @RuleID=EmpRuleID FROM VKQ_RuleEmp WHERE EmpNo=@EmpNo
  IF @RuleID IS NULL OR @RuleID='' SELECT @RuleID=RuleID FROM VKQ_RuleDepart WHERE DepartID=@DepartID
  IF @RuleID IS NULL OR @RuleID='' SET @RuleID='R0001'
  SELECT @RuleExists=0,@RestDays=0,@RestDaysDB=0
  IF EXISTS(SELECT RuleID FROM KQ_Rule WHERE RuleID=@RuleID)
  BEGIN
    SELECT @RuleExists=1,@NoRule=RuleNoRule,@RestDaysDB=RuleRestDays,@ReadWorkHrs=RuleReadWorkHrs,@DupLimit=RuleDupLimit,
      @ReadLate=ISNULL(RuleReadLate,0),@ReadLeave=ISNULL(RuleReadLeave,0),@LateIgnore=RuleLateIgnore,@LeaveIgnore=RuleLeaveIgnore,
      @LateLeaveCalHrs=RuleLateLeaveCalHrs,@AheadHrs=RuleAheadHrs,@AheadMins=RuleAheadMins,@DeferHrs=RuleDeferHrs,@DeferMins=RuleDeferMins,
      @Small=RuleNSAllowTimeS,@Big=RuleNSAllowTimeL,@LateHrs=RuleLateHrs,@LeaveHrs=RuleLeaveHrs,@IsHeadAndTail=RuleHeadAndTail,
      @IsLeaveOvertime=RuleLeaveOvertime FROM KQ_Rule WHERE RuleID=@RuleID
    IF @NoRule=0 SET @RestDaysDB=0
  END
  SELECT @DefCount=COUNT(1) FROM KQ_Shift a INNER JOIN KQ_ShiftDepart b ON b.ShiftID=a.ShiftID AND b.DepartID=@DepartID
  IF @DefCount=1 SELECT @DefShiftID=a.ShiftID FROM KQ_Shift a INNER JOIN KQ_ShiftDepart b ON b.ShiftID=a.ShiftID AND b.DepartID=@DepartID
  IF @DefShiftID IS NULL SET @DefShiftID=''
  IF @DefShiftID='' SET @DefShiftID='001'
  IF @IsAttend=1 EXEC PKQ_CalcDataFilter @EmpNo,@StartDate,@EndDate,@DupLimit
  WHILE @LoopDate<=@EndDate
  BEGIN
    SELECT @ShiftID='',@ShiftIDFind='',@TimeIn1='',@TimeOut1='',@TimeIn2='',@TimeOut2='',@TimeIn3='',@TimeOut3='',@TimeIn4='',
      @TimeOut4='',@TimeIn5='',@TimeOut5='',@WorkDays=0,@AbsentDays=0,@OutHrs=0,@RegHrs=0,@WorkHrs=0,@OtHrs=0,@LateMins=0,@LeaveMins=0,
      @Remark='',@IsHD=0,@T1=NULL,@T2=NULL,@T3=NULL,@T4=NULL,@T5=NULL,@T6=NULL,@T7=NULL,@T8=NULL,@T9=NULL,@T10=NULL,@Hrs10X=0,@Hrs11X=0,
      @Hrs12X=0,@Hrs13X=0,@Hrs14X=0,@Hrs15X=0,@Hrs16X=0,@Hrs17X=0,@Hrs18X=0,@Hrs19X=0,@HasShift=0,@MustDays=0
    IF @DimissionDate IS NOT NULL AND @LoopDate>=@DimissionDate--离职
    BEGIN
      SET @MonthDaysM=DATEDIFF(dd,@StartDate,@LoopDate)+1
      GOTO DimissionDate
    END
    ELSE IF @LoopDate<@EmpHireDate--未入职
    BEGIN
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoOffice'
      GOTO NoOffice
    END
    ELSE
    BEGIN
      IF EXISTS(SELECT ShiftNo FROM KQ_EmpShift WHERE EmpNo=@EmpNo AND EmpShiftDate=@LoopDate)
      BEGIN
        SELECT @HasShift=1,@ShiftID=ShiftNo FROM KQ_EmpShift WHERE EmpNo=@EmpNo AND EmpShiftDate=@LoopDate
        IF @ShiftID IS NULL SET @ShiftID=''
      END
      IF @ShiftID='' AND EXISTS(SELECT ShiftNo FROM KQ_DepShift WHERE DepartID=@DepartID AND DepShiftDate=@LoopDate)
      BEGIN
        SELECT @HasShift=1,@ShiftID=ShiftNo FROM KQ_DepShift WHERE DepartID=@DepartID AND DepShiftDate=@LoopDate
        IF @ShiftID IS NULL SET @ShiftID=''
      END
      IF @ShiftID IS NULL SET @ShiftID=''
    END
    IF EXISTS(SELECT * FROM KQ_Holiday WHERE HolidayBeginTime<=@LoopDate AND HolidayEndTime>=@LoopDate) SET @IsHD=1
    IF @IsAttend=0--免卡
    BEGIN
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoCard'
      SELECT @WorkDays=1
    END
    ELSE IF @RuleExists=0
    BEGIN
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoRule'
    END
    ELSE IF @IsHD=1--假日
    BEGIN
      EXEC PKQ_CalcRest @EmpNo,@LoopDate,@RuleID,@DayOffIDList,@ReadLate,@ReadLeave,@IsLeaveOvertime,@OtHrs output,@OutHrs output,@RegHrs output,
        @Hrs10X output,@Hrs11X output,@Hrs12X output,@Hrs13X output,@Hrs14X output,@Hrs15X output,@Hrs16X output,@Hrs17X output,
        @Hrs18X output,@Hrs19X output
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='PubRest'
      SELECT @HdDaysM=@HdDaysM+1,@Hrs10=@Hrs10+@Hrs10X,@Hrs11=@Hrs11+@Hrs11X,@Hrs12=@Hrs12+@Hrs12X,@Hrs13=@Hrs13+@Hrs13X,
        @Hrs14=@Hrs14+@Hrs14X,@Hrs15=@Hrs15+@Hrs15X,@Hrs16=@Hrs16+@Hrs16X,@Hrs17=@Hrs17+@Hrs17X,@Hrs18=@Hrs18+@Hrs18X,@Hrs19=@Hrs19+@Hrs19X
      IF @OtHrs>0
      BEGIN
        SET @OtHrs=@OtHrs-@RegHrs-@OutHrs--加班小时减请假小时和外出小时
        IF @OtHrs>0
        BEGIN
          SET @HdHrsM=@HdHrsM+@OtHrs
          SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@OtHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'
          SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
        END
      END
    END
    ELSE IF @HasShift=0--未排班
    BEGIN
      SELECT @WeekIsWork=CASE DATEPART(w,@LoopDate) WHEN 1 THEN RuleSunday WHEN 2 THEN RuleMonday
        WHEN 3 THEN RuleTuesday WHEN 4 THEN RuleWednesday WHEN 5 THEN RuleThursday
        WHEN 6 THEN RuleFriday WHEN 7 THEN RuleSaturday END
        FROM KQ_Rule WHERE RuleID=@RuleID
      IF @NoRule=0--不启用无规则休息
      BEGIN
        IF @WeekIsWork=0
        BEGIN
          SELECT @AbsentDays=0
          EXEC PKQ_CalcRest @EmpNo,@LoopDate,@RuleID,@DayOffIDList,@ReadLate,@ReadLeave,@IsLeaveOvertime,@OtHrs output,@OutHrs output,@RegHrs output,
            @Hrs10X output,@Hrs11X output,@Hrs12X output,@Hrs13X output,@Hrs14X output,@Hrs15X output,@Hrs16X output,@Hrs17X output,
            @Hrs18X output,@Hrs19X output
          SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='WeekLast'
          SELECT @SunDaysM=@SunDaysM+1,@Hrs10=@Hrs10+@Hrs10X,@Hrs11=@Hrs11+@Hrs11X,@Hrs12=@Hrs12+@Hrs12X,@Hrs13=@Hrs13+@Hrs13X,
            @Hrs14=@Hrs14+@Hrs14X,@Hrs15=@Hrs15+@Hrs15X,@Hrs16=@Hrs16+@Hrs16X,@Hrs17=@Hrs17+@Hrs17X,@Hrs18=@Hrs18+@Hrs18X,@Hrs19=@Hrs19+@Hrs19X
          IF @OtHrs>0
          BEGIN
            SET @OtHrs=@OtHrs-@RegHrs-@OutHrs--加班小时减请假小时和外出小时
            IF @OtHrs>0
            BEGIN
              SET @SunHrsM=@SunHrsM+@OtHrs
              SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@OtHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'
              SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
            END
          END
        END
        ELSE IF @ReadWorkHrs=1--计算工时
        BEGIN
          IF @IsHeadAndTail=1 --只取首尾记录
          BEGIN
            SELECT @T1=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=1
            IF @T1 IS NOT NULL
            BEGIN
				SELECT TOP 1 @MarkIndex=MarkIndex FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate ORDER BY MarkIndex DESC
				IF @MarkIndex>1
				BEGIN
				 SELECT @T2=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=@MarkIndex
				  IF @T2 IS NOT NULL
				  BEGIN
					SELECT @TimeIn1=dbo.GetTimeStr(@T1),@TimeOut1=dbo.GetTimeStr(@T2)
					SET @WorkHrs=@WorkHrs+(@T2-@T1)/60.00/60.00
				  END
				END
            END
          END
          ELSE
          BEGIN
           SELECT @T1=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=1
          SELECT @T2=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=2
          SELECT @T3=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=3
          SELECT @T4=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=4
          SELECT @T5=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=5
          SELECT @T6=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=6
          SELECT @T7=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=7
          SELECT @T8=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=8
          SELECT @T9=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=9
          SELECT @T10=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=10
          IF @T1 IS NOT NULL AND @T2 IS NOT NULL
          BEGIN
            SELECT @TimeIn1=dbo.GetTimeStr(@T1),@TimeOut1=dbo.GetTimeStr(@T2)
            SET @WorkHrs=@WorkHrs+(@T2-@T1)/60.00/60.00
          END
          IF @T3 IS NOT NULL AND @T4 IS NOT NULL
          BEGIN
            SELECT @TimeIn2=dbo.GetTimeStr(@T3),@TimeOut2=dbo.GetTimeStr(@T4)
            SET @WorkHrs=@WorkHrs+(@T4-@T3)/60.00/60.00
          END
          IF @T5 IS NOT NULL AND @T6 IS NOT NULL
          BEGIN
            SELECT @TimeIn3=dbo.GetTimeStr(@T5),@TimeOut3=dbo.GetTimeStr(@T6)
            SET @WorkHrs=@WorkHrs+(@T6-@T5)/60.00/60.00
          END
          IF @T7 IS NOT NULL AND @T8 IS NOT NULL
          BEGIN
            SELECT @TimeIn4=dbo.GetTimeStr(@T7),@TimeOut4=dbo.GetTimeStr(@T8)
            SET @WorkHrs=@WorkHrs+(@T8-@T7)/60.00/60.00
          END
          IF @T9 IS NOT NULL AND @T10 IS NOT NULL
          BEGIN
            SELECT @TimeIn5=dbo.GetTimeStr(@T9),@TimeOut5=dbo.GetTimeStr(@T10)
            SET @WorkHrs=@WorkHrs+(@T10-@T9)/60.00/60.00
          END
          END
          IF @WorkHrs<0 OR @WorkHrs>24 SET @WorkHrs=0
          IF @WorkHrs=0 SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoPuchCard'
          SELECT @ShiftID=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='CalcHour'
        END
      END
      IF @NoRule=1 OR (@NoRule=0 AND @ReadWorkHrs=0 AND @WeekIsWork=1)
      BEGIN
        IF EXISTS(SELECT a.ShiftID FROM KQ_Shift a INNER JOIN KQ_ShiftDepart b ON b.ShiftID=a.ShiftID AND b.DepartID=@DepartID WHERE a.IsAuto=1)
        BEGIN
          TRUNCATE TABLE KQ_ShiftFind
          DECLARE RecShift CURSOR SCROLL FOR SELECT DISTINCT a.ShiftID,a.ShiftCount FROM KQ_Shift a INNER JOIN KQ_ShiftDepart b ON
            b.ShiftID=a.ShiftID AND b.DepartID=@DepartID WHERE a.IsAuto=1 ORDER BY ShiftCount DESC
          OPEN RecShift
          FETCH FIRST FROM RecShift INTO @ShiftIDFind,@ShiftCount
          WHILE @@FETCH_STATUS=0
          BEGIN
            EXEC PKQ_CalcFindShift @EmpNo,@LoopDate,@ShiftIDFind,@ShiftID output,@LateHrs,@LeaveHrs
            FETCH NEXT FROM RecShift INTO @ShiftIDFind,@ShiftCount
          END
          CLOSE RecShift
          DEALLOCATE RecShift
          IF EXISTS(SELECT * FROM KQ_ShiftFind) SELECT TOP 1 @ShiftID=ShiftID FROM KQ_ShiftFind ORDER BY LateMins,LeaveMins
          IF @ShiftID=''
            SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoShift'
          ELSE
          BEGIN
            EXEC PKQ_CalcNormal @EmpNo,@LoopDate,@DayOffIDList,@ShiftID,@TimeIn1 output,@TimeOut1 output,@TimeIn2 output,@TimeOut2 output,
              @TimeIn3 output,@TimeOut3 output,@TimeIn4 output,@TimeOut4 output,@TimeIn5 output,@TimeOut5 output,@AbsentDays output,
              @LateMins output,@LateCountM output,@LeaveMins output,@LeaveCountM output,@OtHrs output,@OtHrsM output,@SunHrsM output,
              @HdHrsM output,@OutHrs output,@RegHrs output,@Hrs10 output,@Hrs11 output,@Hrs12 output,@Hrs13 output,@Hrs14 output,
              @Hrs15 output,@Hrs16 output,@Hrs17 output,@Hrs18 output,@Hrs19 output,@WorkHrs output,@WorkDays output,@NSCountM output,
              @MidCountM output,@Remark output,@RestDays output,@RestDaysDB output,0,@ReadLate,@ReadLeave,@LateIgnore,@LeaveIgnore,
              @LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@Small,@Big,@LateHrs,@LeaveHrs,@IsLeaveOvertime
            SET @MustDays=1
          END
        END
        ELSE IF @DefShiftID<>''--未排班使用默认排班次
        BEGIN
          SET @ShiftID=@DefShiftID
          EXEC PKQ_CalcNormal @EmpNo,@LoopDate,@DayOffIDList,@ShiftID,@TimeIn1 output,@TimeOut1 output,@TimeIn2 output,@TimeOut2 output,
            @TimeIn3 output,@TimeOut3 output,@TimeIn4 output,@TimeOut4 output,@TimeIn5 output,@TimeOut5 output,@AbsentDays output,
            @LateMins output,@LateCountM output,@LeaveMins output,@LeaveCountM output,@OtHrs output,@OtHrsM output,@SunHrsM output,
            @HdHrsM output,@OutHrs output,@RegHrs output,@Hrs10 output,@Hrs11 output,@Hrs12 output,@Hrs13 output,@Hrs14 output,
            @Hrs15 output,@Hrs16 output,@Hrs17 output,@Hrs18 output,@Hrs19 output,@WorkHrs output,@WorkDays output,@NSCountM output,
            @MidCountM output,@Remark output,@RestDays output,@RestDaysDB output,0,@ReadLate,@ReadLeave,@LateIgnore,@LeaveIgnore,
            @LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@Small,@Big,@LateHrs,@LeaveHrs,@IsLeaveOvertime
          SET @MustDays=1
        END
        ELSE
        BEGIN
          SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoShift'
        END
      END
    END
    ELSE IF @ShiftID=''--班次为空，休息
    BEGIN
      EXEC PKQ_CalcRest @EmpNo,@LoopDate,@RuleID,@DayOffIDList,@ReadLate,@ReadLeave,@IsLeaveOvertime,@OtHrs output,@OutHrs output,@RegHrs output,
        @Hrs10X output,@Hrs11X output,@Hrs12X output,@Hrs13X output,@Hrs14X output,@Hrs15X output,@Hrs16X output,@Hrs17X output,
        @Hrs18X output,@Hrs19X output
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Rest'
      SELECT @SunDaysM=@SunDaysM+1,@Hrs10=@Hrs10+@Hrs10X,@Hrs11=@Hrs11+@Hrs11X,@Hrs12=@Hrs12+@Hrs12X,@Hrs13=@Hrs13+@Hrs13X,
        @Hrs14=@Hrs14+@Hrs14X,@Hrs15=@Hrs15+@Hrs15X,@Hrs16=@Hrs16+@Hrs16X,@Hrs17=@Hrs17+@Hrs17X,@Hrs18=@Hrs18+@Hrs18X,@Hrs19=@Hrs19+@Hrs19X
      IF @OtHrs>0
      BEGIN
        SET @OtHrs=@OtHrs-@RegHrs-@OutHrs--加班小时减请假小时和外出小时
        IF @OtHrs>0
        BEGIN
          SET @SunHrsM=@SunHrsM+@OtHrs
          SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@OtHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'
          SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
        END
      END
    END
    ELSE IF NOT EXISTS(SELECT ShiftID FROM KQ_Shift WHERE ShiftID=@ShiftID)--班次不存在
    BEGIN
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='ShiftNotE'
    END
    ELSE--有排班
    BEGIN
      EXEC PKQ_CalcNormal @EmpNo,@LoopDate,@DayOffIDList,@ShiftID,@TimeIn1 output,@TimeOut1 output,@TimeIn2 output,@TimeOut2 output,
        @TimeIn3 output,@TimeOut3 output,@TimeIn4 output,@TimeOut4 output,@TimeIn5 output,@TimeOut5 output,@AbsentDays output,
        @LateMins output,@LateCountM output,@LeaveMins output,@LeaveCountM output,@OtHrs output,@OtHrsM output,@SunHrsM output,
        @HdHrsM output,@OutHrs output,@RegHrs output,@Hrs10 output,@Hrs11 output,@Hrs12 output,@Hrs13 output,@Hrs14 output,
        @Hrs15 output,@Hrs16 output,@Hrs17 output,@Hrs18 output,@Hrs19 output,@WorkHrs output,@WorkDays output,@NSCountM output,
        @MidCountM output,@Remark output,@RestDays output,@RestDaysDB output,1,@ReadLate,@ReadLeave,@LateIgnore,@LeaveIgnore,
        @LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@Small,@Big,@LateHrs,@LeaveHrs,@IsLeaveOvertime
      SET @MustDays=1    
    END
NoOffice:
    SELECT @AbsentDaysM=@AbsentDaysM+@AbsentDays,@WorkHrsM=@WorkHrsM+@WorkHrs,@WorkDaysM=@WorkDaysM+@WorkDays,@LateMinsM=@LateMinsM+@LateMins,
      @LeaveMinsM=@LeaveMinsM+@LeaveMins,@MustDaysM=@MustDaysM+@MustDays
   
    IF LEFT(@Remark,1)=',' SET @Remark=SUBSTRING(@Remark,2,LEN(@Remark)-1)
    
    INSERT INTO KQ_KQReportDay(EmpNo,KQDate,ShiftID,TimeIn1,TimeOut1,TimeIn2,TimeOut2,TimeIn3,TimeOut3,TimeIn4,TimeOut4,TimeIn5,TimeOut5,
      WorkDays,AbsentDays,OutHrs,LeaveDays,WorkHrs,OtHrs,LateMins,LeaveMins,Remark,MustDays) VALUES(@EmpNo,@LoopDate,@ShiftID,@TimeIn1,
      @TimeOut1,@TimeIn2,@TimeOut2,@TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@WorkDays,@AbsentDays,@OutHrs,@RegHrs,
      @WorkHrs,@OtHrs,@LateMins,@LeaveMins,@Remark,@MustDays)

     EXEC PKQ_KQCalcDetail @DayCount,@Day01 output,@Day02 output,@Day03 output,@Day04 output,@Day05 output,@Day06 output,@Day07 output,@Day08 output,@Day09 output,@Day10 output,
     @Day11 output,@Day12 output,@Day13 output,@Day14 output,@Day15 output,@Day16 output,@Day17 output,@Day18 output,@Day19 output,@Day20 output,@Day21 output,
     @Day22 output,@Day23 output,@Day24 output,@Day25 output,@Day26 output,@Day27 output,@Day28 output,@Day29 output,@Day30 output,@Day31 output,
     @Time01 output,@Time02 output,@Time03 output,@Time04 output,@Time05 output,@Time06 output,@Time07 output,@Time08 output,@Time09 output,@Time10 output,
     @Time11 output,@Time12 output,@Time13 output,@Time14 output,@Time15 output,@Time16 output,@Time17 output,@Time18 output,@Time19 output,@Time20 output,
     @Time21 output,@Time22 output,@Time23 output,@Time24 output,@Time25 output,@Time26 output,@Time27 output,@Time28 output,@Time29 output,@Time30 output,
     @Time31 output,@MustDays,@AbsentDays,@WorkDays, @LoopDate, @Remark,@TimeIn1,@TimeOut1,@TimeIn2,@TimeOut2,@TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5, 
     @NoRule,@WorkHrs,@WeekIsWork,@ReadWorkHrs
        
    SET @DayCount=@DayCount+1
    SET @LoopDate=@LoopDate+1
  END
  SET @MonthDaysM=DATEDIFF(dd,@StartDate,@EndDate)+1
DimissionDate:

   INSERT INTO KQ_KQReportMonth(KQYM,EmpNo,UpdateDate,MonthDays,SunDays,HdDays,WorkDays,AbsentDays,WorkHrs,OtHrs,SunHrs,HdHrs,LateMins,LateCount,
    LeaveMins,LeaveCount,NSCount,MidCount,Hrs10,Hrs11,Hrs12,Hrs13,Hrs14,Hrs15,Hrs16,Hrs17,Hrs18,Hrs19,StartDate,EndDate,MustDaysM) VALUES(@KQYM,
    @EmpNo,getdate(),@MonthDaysM,@SunDaysM,@HdDaysM,@WorkDaysM,@AbsentDaysM,@WorkHrsM,@OtHrsM,@SunHrsM,@HdHrsM,@LateMinsM,@LateCountM,@LeaveMinsM,  
   @LeaveCountM,@NSCountM,@MidCountM,@Hrs10,@Hrs11,@Hrs12,@Hrs13,@Hrs14,@Hrs15,@Hrs16,@Hrs17,@Hrs18,@Hrs19,@StartDate,@EndDate,@MustDaysM)
   

    EXEC PKQ_KQCalcDetailSave @Day01,@Day02,@Day03,@Day04,@Day05,@Day06,@Day07,@Day08,@Day09,@Day10,@Day11,@Day12,@Day13,@Day14,@Day15,
    @Day16,@Day17,@Day18,@Day19,@Day20,@Day21,@Day22,@Day23,@Day24,@Day25,@Day26,@Day27,@Day28,@Day29,@Day30,@Day31,@Time01,@Time02,@Time03,@Time04,@Time05,
    @Time06,@Time07,@Time08,@Time09,@Time10,@Time11,@Time12,@Time13,@Time14,@Time15,@Time16,@Time17,@Time18,@Time19,@Time20,@Time21,@Time22,@Time23,@Time24,
    @Time25,@Time26,@Time27,@Time28,@Time29,@Time30,@Time31,@StartDate,@EndDate,@KQYM,@EmpNo
 
GO


IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PKQ_WeekCalc') DROP PROCEDURE PKQ_WeekCalc
GO
CREATE PROCEDURE PKQ_WeekCalc(@EmpNo varchar(20),@StartDate datetime,@EndDate datetime,@KQYM varchar(8)) WITH ENCRYPTION AS
  DECLARE @EmpHireDate datetime
  DECLARE @DimissionDate datetime
  DECLARE @DepartID varchar(20)
  DECLARE @IsAttend bit
  DECLARE @LoopDate datetime
  DECLARE @RuleID varchar(10)
  DECLARE @ShiftID varchar(50),@ShiftCount int
  DECLARE @HasShift bit
  DECLARE @ShiftIDFind varchar(50)
  DECLARE @TimeIn1 varchar(5)
  DECLARE @TimeOut1 varchar(5)
  DECLARE @TimeIn2 varchar(5)
  DECLARE @TimeOut2 varchar(5)
  DECLARE @TimeIn3 varchar(5)
  DECLARE @TimeOut3 varchar(5)
  DECLARE @TimeIn4 varchar(5)
  DECLARE @TimeOut4 varchar(5)
  DECLARE @TimeIn5 varchar(5)
  DECLARE @TimeOut5 varchar(5)
  DECLARE @WorkDays decimal(16,5)
  DECLARE @AbsentDays decimal(16,5)
  DECLARE @OutHrs decimal(16,5)
  DECLARE @RegHrs decimal(16,5)
  DECLARE @WorkHrs decimal(16,5)
  DECLARE @OtHrs decimal(16,5)
  DECLARE @LateMins int
  DECLARE @LeaveMins int
  DECLARE @Remark varchar(255)
  DECLARE @MonthDaysM decimal(16,5)
  DECLARE @SunDaysM decimal(16,5)
  DECLARE @HdDaysM decimal(16,5)
  DECLARE @WorkDaysM decimal(16,5)
  DECLARE @AbsentDaysM decimal(16,5)
  DECLARE @WorkHrsM decimal(16,5)
  DECLARE @OtHrsM decimal(16,5)
  DECLARE @SunHrsM decimal(16,5)
  DECLARE @HdHrsM decimal(16,5)
  DECLARE @LateMinsM int
  DECLARE @LateCountM int
  DECLARE @LeaveMinsM int
  DECLARE @LeaveCountM int
  DECLARE @NSCountM int
  DECLARE @MidCountM int
  DECLARE @Hrs9 decimal(16,5)
  DECLARE @Hrs10 decimal(16,5)
  DECLARE @Hrs11 decimal(16,5)
  DECLARE @Hrs12 decimal(16,5)
  DECLARE @Hrs13 decimal(16,5)
  DECLARE @Hrs14 decimal(16,5)
  DECLARE @Hrs15 decimal(16,5)
  DECLARE @Hrs16 decimal(16,5)
  DECLARE @Hrs17 decimal(16,5)
  DECLARE @Hrs18 decimal(16,5)
  DECLARE @Hrs19 decimal(16,5)
  DECLARE @Hrs10X decimal(16,5)
  DECLARE @Hrs11X decimal(16,5)
  DECLARE @Hrs12X decimal(16,5)
  DECLARE @Hrs13X decimal(16,5)
  DECLARE @Hrs14X decimal(16,5)
  DECLARE @Hrs15X decimal(16,5)
  DECLARE @Hrs16X decimal(16,5)
  DECLARE @Hrs17X decimal(16,5)
  DECLARE @Hrs18X decimal(16,5)
  DECLARE @Hrs19X decimal(16,5)
  DECLARE @IsHD bit
  DECLARE @NoRule bit
  DECLARE @RestDays decimal(16,5),@RestDaysDB decimal(16,5)
  DECLARE @ReadWorkHrs bit
  DECLARE @WeekIsWork bit
  DECLARE @T1 decimal(16,5)
  DECLARE @T2 decimal(16,5)
  DECLARE @T3 decimal(16,5)
  DECLARE @T4 decimal(16,5)
  DECLARE @T5 decimal(16,5)
  DECLARE @T6 decimal(16,5)
  DECLARE @T7 decimal(16,5)
  DECLARE @T8 decimal(16,5)
  DECLARE @T9 decimal(16,5)
  DECLARE @T10 decimal(16,5)
  DECLARE @DayOffID varchar(10)
  DECLARE @DayOffIDList varchar(100)
  DECLARE @RuleExists bit
  DECLARE @DefShiftID varchar(50),@DefCount int
  DECLARE @DupLimit int,@ReadLate bit,@ReadLeave bit,@Small varchar(5),@Big varchar(5)
  DECLARE @LateIgnore int,@LeaveIgnore int,@LateLeaveCalHrs int,@AheadHrs bit,@AheadMins int
  DECLARE @DeferHrs bit,@DeferMins int
  DECLARE @LateHrs int,@LeaveHrs int
  DECLARE @MustDays decimal(16,5)
  DECLARE @MustDaysM decimal(16,5)
  DECLARE @MarkIndex int
  DECLARE @IsHeadAndTail bit
  DECLARE @IsLeaveOvertime bit

  SET @IsLeaveOvertime=1

  IF EXISTS(SELECT name FROM sysobjects WHERE name='Temp_KQ_KQDataFilter')
    TRUNCATE TABLE Temp_KQ_KQDataFilter
  ELSE
  BEGIN
    SELECT TOP 0 * INTO Temp_KQ_KQDataFilter FROM KQ_KQDataFilter
    ALTER TABLE Temp_KQ_KQDataFilter ADD PRIMARY KEY(GUID)
    ALTER TABLE Temp_KQ_KQDataFilter ADD CONSTRAINT AK_Temp_KQ_KQDataFilter UNIQUE(EmpNo,KQDate,KQTime)
  END
  IF EXISTS(SELECT name FROM sysobjects WHERE name='Temp_KQ_KQData')
    TRUNCATE TABLE Temp_KQ_KQData
  ELSE
  BEGIN
    SELECT TOP 0 * INTO Temp_KQ_KQData FROM KQ_KQData
    ALTER TABLE Temp_KQ_KQData ADD PRIMARY KEY(GUID)
    ALTER TABLE Temp_KQ_KQData ADD CONSTRAINT AK_Temp_KQ_KQData UNIQUE(EmpNo,KQDate,KQTime)
  END
  IF NOT EXISTS(SELECT EmpNo FROM RS_Emp WHERE EmpNo=@EmpNo) RETURN
  SELECT @DimissionDate=CASE WHEN IsDimission=1 THEN DimissionDate ELSE NULL END,@EmpHireDate=EmpHireDate,@DepartID=DepartID,
    @IsAttend=ISNULL(IsAttend,0) FROM RS_Emp WHERE EmpNo=@EmpNo
  DELETE FROM KQ_KQReportDay WHERE EmpNo=@EmpNo AND KQDate>=@StartDate AND KQDate<=@EndDate
  
  DELETE FROM KQ_KQReportWeek WHERE EmpNo=@EmpNo AND KQYM=@KQYM

  SELECT @LoopDate=@StartDate
  --离职
  IF @DimissionDate IS NOT NULL AND @LoopDate>=@DimissionDate RETURN
  SELECT @MonthDaysM=0,@SunDaysM=0,@HdDaysM=0,@WorkDaysM=0,@AbsentDaysM=0,@WorkHrsM=0,@OtHrsM=0,@SunHrsM=0,@HdHrsM=0,@LateMinsM=0,
    @LateCountM=0,@LeaveMinsM=0,@LeaveCountM=0,@NSCountM=0,@MidCountM=0,@Hrs10=0,@Hrs11=0,@Hrs12=0,@Hrs13=0,@Hrs14=0,@Hrs15=0,
    @Hrs16=0,@Hrs17=0,@Hrs18=0,@Hrs19=0,@DayOffIDList='',@MustDaysM=0
  DECLARE RecDayOff SCROLL CURSOR FOR SELECT SortID FROM KQ_RuleCalc WHERE CalcTypeID=2 ORDER BY SortID
  OPEN RecDayOff
  FETCH FIRST FROM RecDayOff INTO @DayOffID
  WHILE @@FETCH_STATUS=0
  BEGIN
    WHILE LEN(@DayOffID)<10 SET @DayOffID='0'+@DayOffID
    SET @DayOffIDList=@DayOffIDList+@DayOffID
    FETCH NEXT FROM RecDayOff INTO @DayOffID
  END
  CLOSE RecDayOff
  DEALLOCATE RecDayOff
  SELECT @RuleID=EmpRuleID FROM VKQ_RuleEmp WHERE EmpNo=@EmpNo
  IF @RuleID IS NULL OR @RuleID='' SELECT @RuleID=RuleID FROM VKQ_RuleDepart WHERE DepartID=@DepartID
  IF @RuleID IS NULL OR @RuleID='' SET @RuleID='R0001'
  SELECT @RuleExists=0,@RestDays=0,@RestDaysDB=0
  IF EXISTS(SELECT RuleID FROM KQ_Rule WHERE RuleID=@RuleID)
  BEGIN
    SELECT @RuleExists=1,@NoRule=RuleNoRule,@RestDaysDB=RuleRestDays,@ReadWorkHrs=RuleReadWorkHrs,@DupLimit=RuleDupLimit,
      @ReadLate=ISNULL(RuleReadLate,0),@ReadLeave=ISNULL(RuleReadLeave,0),@LateIgnore=RuleLateIgnore,@LeaveIgnore=RuleLeaveIgnore,
      @LateLeaveCalHrs=RuleLateLeaveCalHrs,@AheadHrs=RuleAheadHrs,@AheadMins=RuleAheadMins,@DeferHrs=RuleDeferHrs,@DeferMins=RuleDeferMins,
      @Small=RuleNSAllowTimeS,@Big=RuleNSAllowTimeL,@LateHrs=RuleLateHrs,@LeaveHrs=RuleLeaveHrs,@IsHeadAndTail=RuleHeadAndTail FROM KQ_Rule WHERE RuleID=@RuleID
    IF @NoRule=0 SET @RestDaysDB=0
  END
  SELECT @DefCount=COUNT(1) FROM KQ_Shift a INNER JOIN KQ_ShiftDepart b ON b.ShiftID=a.ShiftID AND b.DepartID=@DepartID
  IF @DefCount=1 SELECT @DefShiftID=a.ShiftID FROM KQ_Shift a INNER JOIN KQ_ShiftDepart b ON b.ShiftID=a.ShiftID AND b.DepartID=@DepartID
  IF @DefShiftID IS NULL SET @DefShiftID=''
  IF @DefShiftID='' SET @DefShiftID='001'
  IF @IsAttend=1 EXEC PKQ_CalcDataFilter @EmpNo,@StartDate,@EndDate,@DupLimit
  WHILE @LoopDate<=@EndDate
  BEGIN
    SELECT @ShiftID='',@ShiftIDFind='',@TimeIn1='',@TimeOut1='',@TimeIn2='',@TimeOut2='',@TimeIn3='',@TimeOut3='',@TimeIn4='',
      @TimeOut4='',@TimeIn5='',@TimeOut5='',@WorkDays=0,@AbsentDays=0,@OutHrs=0,@RegHrs=0,@WorkHrs=0,@OtHrs=0,@LateMins=0,@LeaveMins=0,
      @Remark='',@IsHD=0,@T1=NULL,@T2=NULL,@T3=NULL,@T4=NULL,@T5=NULL,@T6=NULL,@T7=NULL,@T8=NULL,@T9=NULL,@T10=NULL,@Hrs10X=0,@Hrs11X=0,
      @Hrs12X=0,@Hrs13X=0,@Hrs14X=0,@Hrs15X=0,@Hrs16X=0,@Hrs17X=0,@Hrs18X=0,@Hrs19X=0,@HasShift=0,@MustDays=0
    IF @DimissionDate IS NOT NULL AND @LoopDate>=@DimissionDate--离职
    BEGIN
      SET @MonthDaysM=DATEDIFF(dd,@StartDate,@LoopDate)+1
      GOTO DimissionDate
    END
    ELSE IF @LoopDate<@EmpHireDate--未入职
    BEGIN
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoOffice'
      GOTO NoOffice
    END
    ELSE
    BEGIN
      IF EXISTS(SELECT ShiftNo FROM KQ_EmpShift WHERE EmpNo=@EmpNo AND EmpShiftDate=@LoopDate)
      BEGIN
        SELECT @HasShift=1,@ShiftID=ShiftNo FROM KQ_EmpShift WHERE EmpNo=@EmpNo AND EmpShiftDate=@LoopDate
        IF @ShiftID IS NULL SET @ShiftID=''
      END
      IF @ShiftID='' AND EXISTS(SELECT ShiftNo FROM KQ_DepShift WHERE DepartID=@DepartID AND DepShiftDate=@LoopDate)
      BEGIN
        SELECT @HasShift=1,@ShiftID=ShiftNo FROM KQ_DepShift WHERE DepartID=@DepartID AND DepShiftDate=@LoopDate
        IF @ShiftID IS NULL SET @ShiftID=''
      END
      IF @ShiftID IS NULL SET @ShiftID=''
    END
    IF EXISTS(SELECT * FROM KQ_Holiday WHERE HolidayBeginTime<=@LoopDate AND HolidayEndTime>=@LoopDate) SET @IsHD=1
    IF @IsAttend=0--免卡
    BEGIN
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoCard'
      SELECT @WorkDays=1
    END
    ELSE IF @RuleExists=0
    BEGIN
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoRule'
    END
    ELSE IF @IsHD=1--假日
    BEGIN
      EXEC PKQ_CalcRest @EmpNo,@LoopDate,@RuleID,@DayOffIDList,@ReadLate,@ReadLeave,@IsLeaveOvertime,@OtHrs output,@OutHrs output,@RegHrs output,
        @Hrs10X output,@Hrs11X output,@Hrs12X output,@Hrs13X output,@Hrs14X output,@Hrs15X output,@Hrs16X output,@Hrs17X output,
        @Hrs18X output,@Hrs19X output
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='PubRest'
      SELECT @HdDaysM=@HdDaysM+1,@Hrs10=@Hrs10+@Hrs10X,@Hrs11=@Hrs11+@Hrs11X,@Hrs12=@Hrs12+@Hrs12X,@Hrs13=@Hrs13+@Hrs13X,
        @Hrs14=@Hrs14+@Hrs14X,@Hrs15=@Hrs15+@Hrs15X,@Hrs16=@Hrs16+@Hrs16X,@Hrs17=@Hrs17+@Hrs17X,@Hrs18=@Hrs18+@Hrs18X,@Hrs19=@Hrs19+@Hrs19X
      IF @OtHrs>0
      BEGIN
        SET @OtHrs=@OtHrs-@RegHrs-@OutHrs--加班小时减请假小时和外出小时
        IF @OtHrs>0
        BEGIN
          SET @HdHrsM=@HdHrsM+@OtHrs
          SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@OtHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'
          SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
        END
      END
    END
    ELSE IF @HasShift=0--未排班
    BEGIN
      SELECT @WeekIsWork=CASE DATEPART(w,@LoopDate) WHEN 1 THEN RuleSunday WHEN 2 THEN RuleMonday
        WHEN 3 THEN RuleTuesday WHEN 4 THEN RuleWednesday WHEN 5 THEN RuleThursday
        WHEN 6 THEN RuleFriday WHEN 7 THEN RuleSaturday END
        FROM KQ_Rule WHERE RuleID=@RuleID
      IF @NoRule=0--不启用无规则休息
      BEGIN
        IF @WeekIsWork=0
        BEGIN
          SELECT @AbsentDays=0
          EXEC PKQ_CalcRest @EmpNo,@LoopDate,@RuleID,@DayOffIDList,@ReadLate,@ReadLeave,@IsLeaveOvertime,@OtHrs output,@OutHrs output,@RegHrs output,
            @Hrs10X output,@Hrs11X output,@Hrs12X output,@Hrs13X output,@Hrs14X output,@Hrs15X output,@Hrs16X output,@Hrs17X output,
            @Hrs18X output,@Hrs19X output
          SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='WeekLast'
          SELECT @SunDaysM=@SunDaysM+1,@Hrs10=@Hrs10+@Hrs10X,@Hrs11=@Hrs11+@Hrs11X,@Hrs12=@Hrs12+@Hrs12X,@Hrs13=@Hrs13+@Hrs13X,
            @Hrs14=@Hrs14+@Hrs14X,@Hrs15=@Hrs15+@Hrs15X,@Hrs16=@Hrs16+@Hrs16X,@Hrs17=@Hrs17+@Hrs17X,@Hrs18=@Hrs18+@Hrs18X,@Hrs19=@Hrs19+@Hrs19X
          IF @OtHrs>0
          BEGIN
            SET @OtHrs=@OtHrs-@RegHrs-@OutHrs--加班小时减请假小时和外出小时
            IF @OtHrs>0
            BEGIN
              SET @SunHrsM=@SunHrsM+@OtHrs
              SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@OtHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'
              SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
            END
          END
        END
        ELSE IF @ReadWorkHrs=1--计算工时
        BEGIN
          IF @IsHeadAndTail=1 --只取首尾记录
          BEGIN
            SELECT @T1=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=1
            IF @T1 IS NOT NULL
            BEGIN
				SELECT TOP 1 @MarkIndex=MarkIndex FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate ORDER BY MarkIndex DESC
				IF @MarkIndex>1
				BEGIN
				 SELECT @T2=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=@MarkIndex
				  IF @T2 IS NOT NULL
				  BEGIN
					SELECT @TimeIn1=dbo.GetTimeStr(@T1),@TimeOut1=dbo.GetTimeStr(@T2)
					SET @WorkHrs=@WorkHrs+(@T2-@T1)/60.00/60.00
				  END
				END
            END
          END
          ELSE
          BEGIN
           SELECT @T1=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=1
          SELECT @T2=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=2
          SELECT @T3=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=3
          SELECT @T4=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=4
          SELECT @T5=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=5
          SELECT @T6=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=6
          SELECT @T7=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=7
          SELECT @T8=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=8
          SELECT @T9=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=9
          SELECT @T10=KQTime FROM Temp_KQ_KQDataFilter WHERE KQDate=@LoopDate AND MarkIndex=10
          IF @T1 IS NOT NULL AND @T2 IS NOT NULL
          BEGIN
            SELECT @TimeIn1=dbo.GetTimeStr(@T1),@TimeOut1=dbo.GetTimeStr(@T2)
            SET @WorkHrs=@WorkHrs+(@T2-@T1)/60.00/60.00
          END
          IF @T3 IS NOT NULL AND @T4 IS NOT NULL
          BEGIN
            SELECT @TimeIn2=dbo.GetTimeStr(@T3),@TimeOut2=dbo.GetTimeStr(@T4)
            SET @WorkHrs=@WorkHrs+(@T4-@T3)/60.00/60.00
          END
          IF @T5 IS NOT NULL AND @T6 IS NOT NULL
          BEGIN
            SELECT @TimeIn3=dbo.GetTimeStr(@T5),@TimeOut3=dbo.GetTimeStr(@T6)
            SET @WorkHrs=@WorkHrs+(@T6-@T5)/60.00/60.00
          END
          IF @T7 IS NOT NULL AND @T8 IS NOT NULL
          BEGIN
            SELECT @TimeIn4=dbo.GetTimeStr(@T7),@TimeOut4=dbo.GetTimeStr(@T8)
            SET @WorkHrs=@WorkHrs+(@T8-@T7)/60.00/60.00
          END
          IF @T9 IS NOT NULL AND @T10 IS NOT NULL
          BEGIN
            SELECT @TimeIn5=dbo.GetTimeStr(@T9),@TimeOut5=dbo.GetTimeStr(@T10)
            SET @WorkHrs=@WorkHrs+(@T10-@T9)/60.00/60.00
          END
          END
          IF @WorkHrs<0 OR @WorkHrs>24 SET @WorkHrs=0
          IF @WorkHrs=0 SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoPuchCard'
          SELECT @ShiftID=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='CalcHour'
        END
      END
      IF @NoRule=1 OR (@NoRule=0 AND @ReadWorkHrs=0 AND @WeekIsWork=1)
      BEGIN
        IF EXISTS(SELECT a.ShiftID FROM KQ_Shift a INNER JOIN KQ_ShiftDepart b ON b.ShiftID=a.ShiftID AND b.DepartID=@DepartID WHERE a.IsAuto=1)
        BEGIN
          TRUNCATE TABLE KQ_ShiftFind
          DECLARE RecShift CURSOR SCROLL FOR SELECT DISTINCT a.ShiftID,a.ShiftCount FROM KQ_Shift a INNER JOIN KQ_ShiftDepart b ON
            b.ShiftID=a.ShiftID AND b.DepartID=@DepartID WHERE a.IsAuto=1 ORDER BY ShiftCount DESC
          OPEN RecShift
          FETCH FIRST FROM RecShift INTO @ShiftIDFind,@ShiftCount
          WHILE @@FETCH_STATUS=0
          BEGIN
            EXEC PKQ_CalcFindShift @EmpNo,@LoopDate,@ShiftIDFind,@ShiftID output,@LateHrs,@LeaveHrs
            FETCH NEXT FROM RecShift INTO @ShiftIDFind,@ShiftCount
          END
          CLOSE RecShift
          DEALLOCATE RecShift
          IF EXISTS(SELECT * FROM KQ_ShiftFind) SELECT TOP 1 @ShiftID=ShiftID FROM KQ_ShiftFind ORDER BY LateMins,LeaveMins
          IF @ShiftID=''
            SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoShift'
          ELSE
          BEGIN
            EXEC PKQ_CalcNormal @EmpNo,@LoopDate,@DayOffIDList,@ShiftID,@TimeIn1 output,@TimeOut1 output,@TimeIn2 output,@TimeOut2 output,
              @TimeIn3 output,@TimeOut3 output,@TimeIn4 output,@TimeOut4 output,@TimeIn5 output,@TimeOut5 output,@AbsentDays output,
              @LateMins output,@LateCountM output,@LeaveMins output,@LeaveCountM output,@OtHrs output,@OtHrsM output,@SunHrsM output,
              @HdHrsM output,@OutHrs output,@RegHrs output,@Hrs10 output,@Hrs11 output,@Hrs12 output,@Hrs13 output,@Hrs14 output,
              @Hrs15 output,@Hrs16 output,@Hrs17 output,@Hrs18 output,@Hrs19 output,@WorkHrs output,@WorkDays output,@NSCountM output,
              @MidCountM output,@Remark output,@RestDays output,@RestDaysDB output,0,@ReadLate,@ReadLeave,@LateIgnore,@LeaveIgnore,
              @LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@Small,@Big,@LateHrs,@LeaveHrs,@IsLeaveOvertime
            SET @MustDays=1
          END
        END
        ELSE IF @DefShiftID<>''--未排班使用默认排班次
        BEGIN
          SET @ShiftID=@DefShiftID
          EXEC PKQ_CalcNormal @EmpNo,@LoopDate,@DayOffIDList,@ShiftID,@TimeIn1 output,@TimeOut1 output,@TimeIn2 output,@TimeOut2 output,
            @TimeIn3 output,@TimeOut3 output,@TimeIn4 output,@TimeOut4 output,@TimeIn5 output,@TimeOut5 output,@AbsentDays output,
            @LateMins output,@LateCountM output,@LeaveMins output,@LeaveCountM output,@OtHrs output,@OtHrsM output,@SunHrsM output,
            @HdHrsM output,@OutHrs output,@RegHrs output,@Hrs10 output,@Hrs11 output,@Hrs12 output,@Hrs13 output,@Hrs14 output,
            @Hrs15 output,@Hrs16 output,@Hrs17 output,@Hrs18 output,@Hrs19 output,@WorkHrs output,@WorkDays output,@NSCountM output,
            @MidCountM output,@Remark output,@RestDays output,@RestDaysDB output,0,@ReadLate,@ReadLeave,@LateIgnore,@LeaveIgnore,
            @LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@Small,@Big,@LateHrs,@LeaveHrs,@IsLeaveOvertime
          SET @MustDays=1
        END
        ELSE
        BEGIN
          SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='NoShift'
        END
      END
    END
    ELSE IF @ShiftID=''--班次为空，休息
    BEGIN
      EXEC PKQ_CalcRest @EmpNo,@LoopDate,@RuleID,@DayOffIDList,@ReadLate,@ReadLeave,@IsLeaveOvertime,@OtHrs output,@OutHrs output,@RegHrs output,
        @Hrs10X output,@Hrs11X output,@Hrs12X output,@Hrs13X output,@Hrs14X output,@Hrs15X output,@Hrs16X output,@Hrs17X output,
        @Hrs18X output,@Hrs19X output
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Rest'
      SELECT @SunDaysM=@SunDaysM+1,@Hrs10=@Hrs10+@Hrs10X,@Hrs11=@Hrs11+@Hrs11X,@Hrs12=@Hrs12+@Hrs12X,@Hrs13=@Hrs13+@Hrs13X,
        @Hrs14=@Hrs14+@Hrs14X,@Hrs15=@Hrs15+@Hrs15X,@Hrs16=@Hrs16+@Hrs16X,@Hrs17=@Hrs17+@Hrs17X,@Hrs18=@Hrs18+@Hrs18X,@Hrs19=@Hrs19+@Hrs19X
      IF @OtHrs>0
      BEGIN
        SET @OtHrs=@OtHrs-@RegHrs-@OutHrs--加班小时减请假小时和外出小时
        IF @OtHrs>0
        BEGIN
          SET @SunHrsM=@SunHrsM+@OtHrs
          SELECT @Remark=@Remark+','+[Name]+CAST((CAST(@OtHrs AS decimal(8,2))) AS varchar) FROM SY_IDName WHERE Class='KQ' AND [ID]='OtHrs'
          SELECT @Remark=@Remark+[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='Hour'
        END
      END
    END
    ELSE IF NOT EXISTS(SELECT ShiftID FROM KQ_Shift WHERE ShiftID=@ShiftID)--班次不存在
    BEGIN
      SELECT @Remark=[Name] FROM SY_IDName WHERE Class='KQ' AND [ID]='ShiftNotE'
    END
    ELSE--有排班
    BEGIN
      EXEC PKQ_CalcNormal @EmpNo,@LoopDate,@DayOffIDList,@ShiftID,@TimeIn1 output,@TimeOut1 output,@TimeIn2 output,@TimeOut2 output,
        @TimeIn3 output,@TimeOut3 output,@TimeIn4 output,@TimeOut4 output,@TimeIn5 output,@TimeOut5 output,@AbsentDays output,
        @LateMins output,@LateCountM output,@LeaveMins output,@LeaveCountM output,@OtHrs output,@OtHrsM output,@SunHrsM output,
        @HdHrsM output,@OutHrs output,@RegHrs output,@Hrs10 output,@Hrs11 output,@Hrs12 output,@Hrs13 output,@Hrs14 output,
        @Hrs15 output,@Hrs16 output,@Hrs17 output,@Hrs18 output,@Hrs19 output,@WorkHrs output,@WorkDays output,@NSCountM output,
        @MidCountM output,@Remark output,@RestDays output,@RestDaysDB output,1,@ReadLate,@ReadLeave,@LateIgnore,@LeaveIgnore,
        @LateLeaveCalHrs,@AheadHrs,@AheadMins,@DeferHrs,@DeferMins,@Small,@Big,@LateHrs,@LeaveHrs,@IsLeaveOvertime
      SET @MustDays=1  
      
    END
NoOffice:
    SELECT @AbsentDaysM=@AbsentDaysM+@AbsentDays,@WorkHrsM=@WorkHrsM+@WorkHrs,@WorkDaysM=@WorkDaysM+@WorkDays,@LateMinsM=@LateMinsM+@LateMins,
      @LeaveMinsM=@LeaveMinsM+@LeaveMins,@MustDaysM=@MustDaysM+@MustDays
   
    IF LEFT(@Remark,1)=',' SET @Remark=SUBSTRING(@Remark,2,LEN(@Remark)-1)
    
    INSERT INTO KQ_KQReportDay(EmpNo,KQDate,ShiftID,TimeIn1,TimeOut1,TimeIn2,TimeOut2,TimeIn3,TimeOut3,TimeIn4,TimeOut4,TimeIn5,TimeOut5,
      WorkDays,AbsentDays,OutHrs,LeaveDays,WorkHrs,OtHrs,LateMins,LeaveMins,Remark,MustDays) VALUES(@EmpNo,@LoopDate,@ShiftID,@TimeIn1,
      @TimeOut1,@TimeIn2,@TimeOut2,@TimeIn3,@TimeOut3,@TimeIn4,@TimeOut4,@TimeIn5,@TimeOut5,@WorkDays,@AbsentDays,@OutHrs,@RegHrs,
      @WorkHrs,@OtHrs,@LateMins,@LeaveMins,@Remark,@MustDays)
      
   
    SET @LoopDate=@LoopDate+1
  END
  SET @MonthDaysM=DATEDIFF(dd,@StartDate,@EndDate)+1
DimissionDate:
   INSERT INTO KQ_KQReportWeek(KQYM,EmpNo,UpdateDate,MonthDays,SunDays,HdDays,WorkDays,AbsentDays,WorkHrs,OtHrs,SunHrs,HdHrs,LateMins,LateCount,
    LeaveMins,LeaveCount,NSCount,MidCount,Hrs10,Hrs11,Hrs12,Hrs13,Hrs14,Hrs15,Hrs16,Hrs17,Hrs18,Hrs19,StartDate,EndDate,MustDaysM) VALUES(@KQYM,
    @EmpNo,getdate(),@MonthDaysM,@SunDaysM,@HdDaysM,@WorkDaysM,@AbsentDaysM,@WorkHrsM,@OtHrsM,@SunHrsM,@HdHrsM,@LateMinsM,@LateCountM,@LeaveMinsM,  
   @LeaveCountM,@NSCountM,@MidCountM,@Hrs10,@Hrs11,@Hrs12,@Hrs13,@Hrs14,@Hrs15,@Hrs16,@Hrs17,@Hrs18,@Hrs19,@StartDate,@EndDate,@MustDaysM)

GO