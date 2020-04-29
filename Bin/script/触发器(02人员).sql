IF EXISTS (SELECT * FROM sysobjects WHERE NAME='TR_RS_Emp') DROP TRIGGER TR_RS_Emp
GO
CREATE TRIGGER TR_RS_Emp ON RS_Emp WITH ENCRYPTION
FOR UPDATE
AS
  DECLARE @EmpNoOld varchar(20),@EmpNoNew varchar(20),@FingerOld bigint,@FingerNew bigint
  SELECT @EmpNoOld=EmpNo,@FingerOld=FingerNo FROM Deleted
  SELECT @EmpNoNew=EmpNo,@FingerNew=FingerNo FROM Inserted
  IF @EmpNoOld<>@EmpNoNew
  BEGIN
    UPDATE KQ_EmpDayOff SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_EmpOtSure SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_EmpShift SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_KQData SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_KQDataFilter SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_KQReportDay SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_KQReportMonth SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_ReportRecords SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_KQReportWeek SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE DI_Power SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE GZ_GZReport SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE KQ_MJData SET FingerNo=@EmpNoNew WHERE FingerNo=@EmpNoOld
    UPDATE KQ_MJData SET FingerNo=@EmpNoNew WHERE FingerNo=@EmpNoOld
    UPDATE DI_SeaPower SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
    UPDATE DI_StarPower SET EmpNo=@EmpNoNew WHERE EmpNo=@EmpNoOld
  END
  IF @FingerOld<>@FingerNew
  BEGIN
    UPDATE RS_EmpFingerInfo SET FingerNo=@FingerNew WHERE FingerNo=@FingerOld
  END
GO


IF EXISTS (SELECT * FROM sysobjects WHERE NAME='TR_RS_EmpD') DROP TRIGGER TR_RS_EmpD
GO
CREATE TRIGGER TR_RS_EmpD ON RS_Emp WITH ENCRYPTION
FOR DELETE
AS
  DECLARE @EmpNoOld varchar(20),@FingerOld bigint
  SELECT @EmpNoOld=EmpNo,@FingerOld=FingerNo FROM Deleted
    DELETE FROM RS_EmpFingerInfo WITH (TABLOCKX) WHERE FingerNo=@FingerOld
    DELETE FROM RS_EmpDynamicInfo WITH (TABLOCKX) WHERE EmpNo=@EmpNoOld
    DELETE FROM DI_Power WITH (TABLOCKX) WHERE EmpNo=@EmpNoOld
    DELETE FROM DI_SeaPower WITH (TABLOCKX) WHERE EmpNo=@EmpNoOld
    DELETE FROM DI_StarPower WITH (TABLOCKX) WHERE EmpNo=@EmpNoOld
GO

IF EXISTS (SELECT * FROM sysobjects WHERE NAME='TR_DI_SeaSnapShots') DROP TRIGGER TR_DI_SeaSnapShots
GO
CREATE TRIGGER TR_DI_SeaSnapShots ON DI_SeaSnapShots WITH ENCRYPTION
FOR DELETE
AS
  DECLARE @GUID varchar(36)
  SELECT @GUID=[GUID] FROM deleted
	DELETE FROM DI_SeaSnapShotsPhoto where [GUID]=@GUID
GO