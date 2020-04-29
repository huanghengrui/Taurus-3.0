IF EXISTS(SELECT * FROM sysobjects WHERE name='PGetMaxIDFromTable') DROP PROCEDURE PGetMaxIDFromTable
GO
CREATE PROCEDURE PGetMaxIDFromTable(@FieldName varchar(50),@TableName varchar(50)) WITH ENCRYPTION AS
  DECLARE @S varchar(8000)
 
  SELECT @S='(SELECT IDENTITY (int,1,1) rn,'+@FieldName+'
         INTO #w
         FROM '+@TableName+' WHERE ISNUMERIC('+@FieldName+')=1)  (SELECT ISNULL(MIN(b.'+@FieldName+'),0)+1 AS MaxID FROM 
         (SELECT CAST(a.'+@FieldName+' AS bigint) AS '+@FieldName+' FROM #w
     AS a WHERE ISNUMERIC(a.'+@FieldName+')=1 AND NOT EXISTS(SELECT 1 FROM #w WHERE ISNUMERIC('+@FieldName+')=1 AND 
    CAST('+@FieldName+' AS bigint)=CAST(a.'+@FieldName+' AS bigint)+1) UNION SELECT 0 FROM #w WHERE NOT EXISTS(SELECT 1 FROM 
    #w WHERE CAST(ISNUMERIC('+@FieldName+') AS bigint)=1)) b)  drop table #w'
  EXEC(@S)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='PSY_CursorDelete') DROP PROCEDURE PSY_CursorDelete
GO
CREATE PROCEDURE PSY_CursorDelete(@name varchar(255)) WITH ENCRYPTION AS
  IF CURSOR_STATUS('local',@name)<>-3 OR CURSOR_STATUS('global',@name)<>-3 OR CURSOR_STATUS('variable',@name)<>-3
  BEGIN
    DECLARE @tmp varchar(1000)
    SELECT @tmp='DEALLOCATE '+@name
    EXEC(@tmp)
  END
GO