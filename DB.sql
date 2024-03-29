USE [i3ms]
GO
/****** Object:  UserDefinedTableType [dbo].[OpponentTableType1]    Script Date: 24-02-2024 20:58:08 ******/
CREATE TYPE [dbo].[OpponentTableType1] AS TABLE(
	[DeptId] [varchar](6000) NULL,
	[GovtPaty] [int] NULL,
	[Name] [varchar](1) NULL
)
GO
/****** Object:  Table [dbo].[Demo_T_LMS]    Script Date: 24-02-2024 20:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demo_T_LMS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DeptId] [int] NULL,
	[GovtPaty] [int] NULL,
	[Name] [nchar](10) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Demo_T_LMS] ON 

INSERT [dbo].[Demo_T_LMS] ([ID], [DeptId], [GovtPaty], [Name]) VALUES (1, 11, 44, N'A         ')
INSERT [dbo].[Demo_T_LMS] ([ID], [DeptId], [GovtPaty], [Name]) VALUES (2, 33, 22, N'B         ')
INSERT [dbo].[Demo_T_LMS] ([ID], [DeptId], [GovtPaty], [Name]) VALUES (3, 33, 22, N'C         ')
SET IDENTITY_INSERT [dbo].[Demo_T_LMS] OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_Demo_T_LMS_Copy_1]    Script Date: 24-02-2024 20:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--ActionCode=@P_Action :I=Insert,U=Update,D=Delete,V=View,E=Edit,S=Search
CREATE PROCEDURE [dbo].[USP_Demo_T_LMS_Copy_1]
 @P_Action  CHAR(30),
@P_ID  int=NULL,
@P_DeptId  int=NULL,
@P_GovtPaty  int=NULL,
@P_Name varchar(30)=null
AS BEGIN
SET NOCOUNT ON;
IF (@P_Action = 'I') BEGIN
Insert into Demo_T_LMS(DeptId,GovtPaty,Name) values(@P_DeptId,@P_GovtPaty,@P_Name)
END
-------------------------------------------------------------------------
Else
IF (@P_Action = 'U') BEGIN
Update Demo_T_LMS set DeptId=@P_DeptId,GovtPaty=@P_GovtPaty,Name=@P_Name where ID=@P_ID
END
-------------------------------------------------------------------------
Else
IF (@P_Action = 'D') BEGIN
Delete from Demo_T_LMS where ID=@P_ID
END
-------------------------------------------------------------------------
Else
IF (@P_Action = 'V') BEGIN
select ID,DeptId,GovtPaty,Name from Demo_T_LMS
END
Else
IF (@P_Action = 'S') BEGIN
select ID,DeptId,GovtPaty,Name from Demo_T_LMS where 

    CASE
        WHEN
            (
          
(ISNULL(@P_ID, '0') = '0' OR Demo_T_LMS.ID = ISNULL(@P_ID, '0'))

AND
				

(ISNULL(@P_DeptId, '0') = '0' OR Demo_T_LMS.DeptId = ISNULL(@P_DeptId, '0'))

AND
				

(ISNULL(@P_GovtPaty, '0') = '0' OR Demo_T_LMS.GovtPaty = ISNULL(@P_GovtPaty, '0'))

      
            )
        THEN 1
        ELSE 0
    END = 1;
	END
-------------------------------------------------------------------------
Else
IF (@P_Action = 'E') BEGIN
select ID,DeptId,GovtPaty from Demo_T_LMS where ID=@P_ID
END
-------------------------------------------------------------------------
END
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertOpponentData]    Script Date: 24-02-2024 20:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertOpponentData]
    @OpponentTableTypeParameter OpponentTableType1 READONLY
AS
BEGIN
--    DECLARE @RegistrationID INT, @OpponentId INT;
--SET @RegistrationID = (SELECT TOP 1 intRegistrationID FROM @OpponentTableTypeParameter);

-- Create the temporary table
CREATE TABLE #tmpTable (slNo INT PRIMARY KEY IDENTITY(1,1), DeptId int, GovtPaty INT, Name varchar(30));

-- Populate the temporary table
INSERT INTO #tmpTable (DeptId, GovtPaty, Name)
SELECT DeptId, GovtPaty, Name
FROM @OpponentTableTypeParameter;
MERGE INTO Demo_T_LMS AS target
USING #tmpTable AS source
ON ( target.Id = source.slNo)

WHEN MATCHED THEN
    UPDATE SET target.DeptId = source.DeptId,
	target.GovtPaty = source.GovtPaty,
	target.Name = source.Name
WHEN NOT MATCHED BY TARGET THEN
INSERT (
DeptId, 
GovtPaty, 
Name
   )
VALUES (
source.DeptId, 
source.GovtPaty, 
source.Name
);

-- Update bitStatus in T_LMS_Opponent
--UPDATE T_LMS_Opponent 
--SET bitStatus = 1
--WHERE intRegistrationID = @RegistrationID
--AND intOpponentTypeID NOT IN (SELECT OppId FROM #tmpTable WHERE regid = @RegistrationID);

-- Drop the temporary table when done
DROP TABLE #tmpTable;
END;
GO
