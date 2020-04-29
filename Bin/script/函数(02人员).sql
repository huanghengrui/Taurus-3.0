IF EXISTS(SELECT * FROM sysobjects WHERE name='GetNextDeptList') DROP FUNCTION GetNextDeptList
GO
CREATE FUNCTION dbo.GetNextDeptList(@ID varchar(20))
  RETURNS varchar(8000) WITH ENCRYPTION AS
BEGIN
  DECLARE @name varchar(8000),@NID varchar(20),@tmp varchar(8000)
  SELECT @name='',@NID=''
  DECLARE RecNo CURSOR SCROLL FOR SELECT DepartID FROM RS_Depart WHERE DepartUpID=@ID
  OPEN RecNo
  FETCH FIRST FROM RecNo INTO @NID
  WHILE @@FETCH_STATUS=0
  BEGIN
    SELECT @tmp=dbo.GetNextDeptList(@NID)
    IF @tmp<>'' SELECT @tmp=@tmp+','
    SELECT @name=@name+''''+@NID+''','+LTRIM(RTRIM(@tmp))
    FETCH NEXT FROM RecNo INTO @NID
  END
  CLOSE RecNo
  DEALLOCATE RecNo
  IF @name<>'' SELECT @name=SUBSTRING(@name,1,LEN(@name)-1)
  RETURN @name
END
GO