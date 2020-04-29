IF EXISTS(SELECT * FROM sysobjects WHERE name='GetTimeStr') DROP FUNCTION GetTimeStr
GO
CREATE FUNCTION GetTimeStr(@IntTime int)
  RETURNS varchar(5) WITH ENCRYPTION AS
BEGIN
  DECLARE @Sec int,@Min int,@Hour int,@S varchar(10),@S1 varchar(2),@S2 varchar(2)
  SET @Sec=ABS(@IntTime)
  SET @Hour=@Sec / 3600
  SET @Sec=@Sec % 3600
  SET @Min=@Sec / 60
  SET @Sec=@Sec % 60
  SET @S1=CAST(@Hour AS varchar(2))
  SET @S2=CAST(@Min AS varchar(2))
  WHILE LEN(@S1)<2 SET @S1='0'+@S1
  WHILE LEN(@S2)<2 SET @S2='0'+@S2
  SET @S=@S1+':'+@S2
  RETURN @S
END
GO

IF EXISTS(SELECT * FROM sysobjects WHERE name='GetTimeStrEx') DROP FUNCTION GetTimeStrEx
GO
CREATE FUNCTION GetTimeStrEx(@IntTime int)
  RETURNS varchar(8) WITH ENCRYPTION AS
BEGIN
  DECLARE @Sec int,@Min int,@Hour int,@S varchar(10),@S1 varchar(2),@S2 varchar(2),@S3 varchar(2)
  SET @Sec=ABS(@IntTime)
  SET @Hour=@Sec / 3600
  SET @Sec=@Sec % 3600
  SET @Min=@Sec / 60
  SET @Sec=@Sec % 60
  SET @S1=CAST(@Hour AS varchar(2))
  SET @S2=CAST(@Min AS varchar(2))
  SET @S3=CAST(@Sec AS varchar(2))
  WHILE LEN(@S1)<2 SET @S1='0'+@S1
  WHILE LEN(@S2)<2 SET @S2='0'+@S2
  WHILE LEN(@S3)<2 SET @S3='0'+@S3
  SET @S=@S1+':'+@S2+':'+@S3
  RETURN @S
END
GO

IF EXISTS(SELECT * FROM sysobjects WHERE name='GetTimeSecond') DROP FUNCTION GetTimeSecond
GO
CREATE FUNCTION GetTimeSecond(@In varchar(5),@Out varchar(5))
  RETURNS int WITH ENCRYPTION AS
BEGIN
  DECLARE @T1 int,@T2 int,@T int
  SET @T1=CAST(SUBSTRING(@In,1,2) AS int)*60*60+CAST(SUBSTRING(@In,4,2) AS int)*60
  SET @T2=CAST(SUBSTRING(@Out,1,2) AS int)*60*60+CAST(SUBSTRING(@Out,4,2) AS int)*60
  SET @T=@T2-@T1
  RETURN @T
END
GO

IF EXISTS(SELECT * FROM sysobjects WHERE name='TimeToMinutes') DROP FUNCTION TimeToMinutes
GO
CREATE FUNCTION TimeToMinutes(@Start datetime,@End datetime)
  RETURNS int WITH ENCRYPTION AS
BEGIN
  DECLARE @T int
  SET @T=DATEDIFF(mi,@Start,@End)
  RETURN @T
END
GO

IF EXISTS(SELECT * FROM sysobjects WHERE name='CalcAdjust') DROP FUNCTION CalcAdjust
GO
CREATE FUNCTION CalcAdjust(@Src decimal(8,2),@Start int,@Tune int,@Integer int)
  RETURNS decimal(8,2) WITH ENCRYPTION AS
BEGIN
  DECLARE @Ret decimal(8,2),@Allow bit,@ICount decimal(8,2),@JCount decimal(8,2)
  IF @Src IS NULL SET @Src=0
  IF @Start IS NULL SET @Start=0
  IF @Tune IS NULL SET @Tune=0
  IF @Integer IS NULL SET @Integer=0
  SET @Ret=@Src
  SET @Allow=0
  IF EXISTS(SELECT * FROM SY_Config WHERE [ID]='KQ' AND [Key]='AllowAdjust') SET @Allow=1
  IF @Allow=1 AND @Start>0 AND @Tune>0 AND @Integer>0
  BEGIN
    IF @Ret*60.00>@Start
    BEGIN
      SET @ICount=@Ret*60.00
      SET @Ret=FLOOR(@ICount/@Integer)*@Integer
      --SET @JCount=@ICount-@Ret+@Tune
      SET @JCount=@ICount-@Ret
      IF @JCount>=@Tune SET @Ret=@Ret+@Integer
      SET @Ret=@Ret/60.00
    END
    ELSE
      SET @Ret=0
  END
  RETURN @Ret
END
GO
