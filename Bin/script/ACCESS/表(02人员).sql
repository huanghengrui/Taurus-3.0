CREATE TABLE RS_Depart
(
  DepartID varchar(20) NOT NULL,
  DepartName varchar(50) NOT NULL,
  DepartUpID varchar(20) NULL,
  DepartMemo text NULL,
  RuleID varchar(10) NULL,
  CONSTRAINT PK_RS_Depart PRIMARY KEY(DepartID)
)
GO

CREATE TABLE RS_Emp
(
  EmpNo varchar(20) NOT NULL,
  EmpName varchar(50) NULL,
  EmpSex varchar(10) NULL,
  DepartID varchar(20) NULL,
  EmpHireDate datetime NULL,
  EmpCertNo varchar(50) NULL,
  CardNo10 varchar(10) NULL,
  CardNo81 varchar(8) NULL,
  CardNo82 varchar(8) NULL,
  FingerNo long NULL,
  FingerPrivilege tinyint NULL,
  IsAttend bit NULL,
  RuleID varchar(10) NULL,
  EmpAddress varchar(255) NULL,
  EmpPhoneNo varchar(50) NULL,
  EmpMemo varchar(255) NULL,
  EmpPhotoImage image NULL,
  CONSTRAINT PK_RS_Emp PRIMARY KEY(EmpNo),
  CONSTRAINT AK_RS_Emp UNIQUE(FingerNo)
)
GO

CREATE TABLE RS_EmpFingerInfo
(
  FingerFlag tinyint NOT NULL,
  FingerNo long NOT NULL,
  FingerBkNo tinyint NOT NULL,
  FingerPWD int NULL,
  FingerData image NULL,
  CONSTRAINT PK_RS_EmpFingerInfo PRIMARY KEY(FingerFlag,FingerNo,FingerBkNo)
)
GO

CREATE TABLE RS_EmpDynamicInfo
(
	EmpNo varchar(30) NOT NULL,
	FingerNo long NOT NULL,
	Fb00 image NULL,
	Fb01 image NULL,
	Fb02 image NULL,
	Fb03 image NULL,
	Fb04 image NULL,
	Fb05 image NULL,
	Fb06 image NULL,
	Fb07 image NULL,
	Fb08 image NULL,
	Fb09 image NULL,
	Face00 image NULL, 
	Falm00 image NULL, 
	CONSTRAINT PK_RS_EmpDynamicInfo PRIMARY KEY(FingerNo)
)
GO
