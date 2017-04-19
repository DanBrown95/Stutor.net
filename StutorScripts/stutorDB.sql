/* Check if database already exists and delete it if it does exist*/
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'stutorDB') 
BEGIN
	DROP DATABASE stutorDB
	print '' print '*** dropping database stutorDB'
END
GO

print '' print '*** creating database stutorDB'
GO
CREATE DATABASE stutorDB
GO

print '' print '*** using database stutorDB'
GO
USE [stutorDB]
GO

print '' print '*** creating User table ***'
GO
CREATE TABLE [dbo].[User](
	[UserID]	[int] IDENTITY(100000,1) NOT NULL,
	[Firstname]	[nvarchar](50)		 NOT NULL,
	[Lastname]	[nvarchar](100)		 NOT NULL,
	[Email]		[nvarchar](100)		 NOT NULL,
	[PasswordHash]	[nvarchar](100)		 NOT NULL DEFAULT '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',	
	[Active]	[bit]			 NOT NULL DEFAULT 1,
	[Role]		[nvarchar](100)		 NOT NULL DEFAULT 'Student'

	CONSTRAINT [pk_UserID] PRIMARY KEY([UserID] ASC),
	CONSTRAINT [ak_Email] UNIQUE ([Email] ASC)
)
GO

print '' print '*** Inserting student test record ***'
GO
INSERT INTO [dbo].[User]
			([Firstname], [Lastname], [Email], [Role])
			Values
			('Dan', 'Brown', 'daniel_brown4@student.kirkwood.edu', 'Tutor'),('Josh','Brown','jbrown@student.kirkwood.edu', 'Student'),('Evan','Male','emale@kirkwood.edu','Employee')
GO

print '' print '*** Creating Tutor Table ***'
GO
CREATE TABLE [dbo].[Tutor](
	[TutorID]	[int] IDENTITY(100000,1) NOT NULL,
	[UserID]	[int]			 NOT NULL

	CONSTRAINT [pk_TutorID] PRIMARY KEY ([TutorID] ASC)
)
GO

print '' print'*** Inserting Tutor Table Data ***'
GO
INSERT INTO [dbo].[Tutor]
		(
		UserID
		)
		VALUES
		(
		100000
		)
GO

print '' print '*** Create Role Table ***'
GO
CREATE TABLE [dbo].[Role](
	[Role]	[nvarchar](100)  NOT NULL	
	
	CONSTRAINT [pk_Role] PRIMARY KEY ([Role] ASC)
)
GO

print '' print '*** Creating TutorApplication table ***'
GO
CREATE TABLE [dbo].[TutorApplication](
	[TutorApplicationID]	[int] IDENTITY(100000,1)	NOT NULL,
	[UserID] 		[int]				NOT NULL,
	[SubjectName]		[nvarchar](100)			NOT NULL

	CONSTRAINT [pk_TutorApplicationID] PRIMARY KEY ([TutorApplicationID] ASC)
)
GO

print'' print '*** Inserting TutorApplication content ***'
GO
INSERT INTO [dbo].[TutorApplication]
	([UserID],[SubjectName])
	Values
	('100001', 'Intro to psychology')
GO


print'' print '*** Inserting Role content ***'
GO
INSERT INTO [dbo].[Role]
	([Role])
	Values
	('Employee'),('Tutor'),('Student')
GO


print '' print '*** Creating SubjectArea table ***'
GO
CREATE TABLE [dbo].[SubjectArea](
	[SubjectAreaID]	  [int]	IDENTITY(100000,1) NOT NULL,
	[SubjectAreaName] [nvarchar](100)	 NOT NULL,

	CONSTRAINT [pk_SubjectAreaID] PRIMARY KEY ([SubjectAreaID] ASC)
)
GO

print '' print'*** Inserting SubjectArea test data ***'
GO
INSERT INTO [dbo].[SubjectArea]
		([SubjectAreaName])
		VALUES
		('Agriculture'),('Biology'),('Chemistry'),('Computer Science'),('Economics'),('Engineering'),('English'),('Environmental Science'),('Horticulture'),('Mathematics'),('Natural Resources'),('Physics'),('Dentistry'),('Music'),('Nursing'),('Psychology')
GO


print '' print '*** Creating Subject Table ***'
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID]	[int] IDENTITY(100000,1) NOT NULL,
	[SubjectAreaID] [int] 			 NOT NULL,
	[SubjectName]	[nvarchar](100)		 NOT NULL

	CONSTRAINT [pk_SubjectID] PRIMARY KEY ([SubjectID] ASC)
)
GO

print'' print '*** Inserting Subject test data ***'
GO
INSERT INTO [dbo].[Subject]
		([SubjectAreaID],[SubjectName])
		VALUES
		('100003','Java I'),('100003','.Net Development'),('100003','ClientSide Scripting'),		('100001','Introductory Biology'), ('100015','Intro to psychology'),		('100015','Developmental Psychology')
GO

print '' print '*** Creating Assignment Table ***'
GO
CREATE TABLE [dbo].[Assignment](
	[AssignmentID]	[int] IDENTITY(100000,1) NOT NULL,
	[SubjectID]	[int]			 NOT NULL,
	[UserID]	[int]			 NOT NULL,
	[IsApproved]	[bit]			 NOT NULL DEFAULT 0

	CONSTRAINT [pk_AssignmentID] PRIMARY KEY ([AssignmentID] ASC)
)
GO

print'' print '*** Creating TutoringRequest Table ***'
GO
CREATE TABLE [dbo].[TutoringRequest](
	[TutoringRequestID]	[int] IDENTITY(100000,1) NOT NULL,		
	[UserID]	[int]			 NOT NULL,
	[TutorID]	[int]			 NOT NULL,
	[SubjectID]	[int]			 NOT NULL,
	[Day]		[date]			 NOT NULL,
	[Time]		[nvarchar](7)		 NOT NULL,
	[Status]	[nvarchar](8)		 NOT NULL DEFAULT "Pending"
	
	CONSTRAINT [pk_TutoringRequestID] PRIMARY KEY ([TutoringRequestID] ASC)
)
GO

print'' print '*** Inserting test data into TutoringRequest table***'
GO
INSERT INTO [dbo].[TutoringRequest] 
	([UserID], [TutorID], [SubjectID], [Day], [Time], [Status]) 
	VALUES 
	(100001, 100000, 100001, N'2016-12-20', N'9:27 PM', N'Pending')
GO

print'' print '*** creating sp_edit_tutoring_request ***'
GO
CREATE PROCEDURE [dbo].[sp_edit_tutoring_request]
	(
	@OldTutoringRequestID 	int,
	@OldDay			Date,
	@OldTime		nvarchar(7),
	@NewDay			Date,
	@NewTime		nvarchar(7)
	)
AS
	BEGIN
		UPDATE [dbo].[TutoringRequest]
		SET Day = @NewDay, Time = @NewTime
		WHERE TutoringRequestID = @OldTutoringRequestID AND Day = @OldDay AND Time = @OldTime
	END
GO



print '' print '*** Creating SubjectRequest Table ***'
GO
CREATE TABLE [dbo].[SubjectRequest](
	[SubjectRequestID] [int] IDENTITY(100000,1) NOT NULL,
	[SubjectAreaName]  [nvarchar](100)	    NOT NULL,
	[SubjectName]	   [nvarchar](100)	    NOT NULL

	CONSTRAINT [pk_SubjectRequestID] PRIMARY KEY ([SubjectRequestID] ASC)
)
GO


print '' print'*** Creating Subject table SubjectAreaID foreign key ***'
GO
ALTER TABLE [dbo].[Subject] WITH NOCHECK
	ADD CONSTRAINT [fk_SubjectAreaID] FOREIGN KEY ([SubjectAreaID])
	REFERENCES [dbo].[SubjectArea] ([SubjectAreaID])
GO

print'' print'*** Creating Tutor table UserID foreign key ***'
GO
ALTER TABLE [dbo].[Tutor] WITH NOCHECK
	ADD FOREIGN KEY ([UserID])
	REFERENCES [dbo].[User] ([UserID])
GO

print '' print '*** Creating Assignment Table SubjectID foreign key ***'
GO
ALTER TABLE [dbo].[Assignment] WITH NOCHECK
	ADD CONSTRAINT [fk_SubjectID] FOREIGN KEY ([SubjectID])
	REFERENCES [dbo].[Subject] ([SubjectID])
GO


print '' print '*** Creating TutoringRequest Table UserID foreign key ***'
GO
ALTER TABLE [dbo].[TutoringRequest] WITH NOCHECK
	ADD FOREIGN KEY ([UserID])
	REFERENCES [dbo].[User] ([UserID])
GO

print '' print '*** Creating TutoringRequest Table TutorID foreign key ***'
GO
ALTER TABLE [dbo].[TutoringRequest] WITH NOCHECK
	ADD CONSTRAINT [fk_TutorID] FOREIGN KEY ([TutorID])
	REFERENCES [dbo].[Tutor] ([TutorID])
GO


print '' print '*** Creating TutoringRequest Table SubjectID foreign key ***'
GO
ALTER TABLE [dbo].[TutoringRequest] WITH NOCHECK
	ADD FOREIGN KEY ([SubjectID])
	REFERENCES [dbo].[Subject] ([SubjectID])
GO

print '' print '*** Creating TutorApplication UserID Foreign key ***'
GO
ALTER TABLE [dbo].[TutorApplication] WITH NOCHECK
	ADD FOREIGN KEY ([UserID])
	REFERENCES [dbo].[User] ([UserID])
GO

print'' print '*** Creating ClassTutors Table ***'
GO
CREATE TABLE [dbo].[ClassTutors](
	[UserID]	[int]	NOT NULL,
	[SubjectID]	[int]	NOT NULL

	CONSTRAINT [pk_UserID_SubjectAreaID] PRIMARY KEY([UserID],[SubjectID] ASC) 
)
GO

print'' print '*** Creating ClassTutors UserID foreign key ***'
GO
ALTER TABLE [dbo].[ClassTutors] WITH NOCHECK
	ADD FOREIGN KEY ([UserID])
	REFERENCES [dbo].[User] ([UserID])
GO

print'' print '*** Creating ClassTutors SubjectID foreign key ***'
GO
ALTER TABLE [dbo].[ClassTutors] WITH NOCHECK
	ADD FOREIGN KEY ([SubjectID])
	REFERENCES [dbo].[Subject] ([SubjectID])
GO

print'' print'*** Inserting test data for ClassTutors Table ***'
GO
INSERT INTO [dbo].[ClassTutors]
		([UserID],[SubjectID])
		VALUES
		('100000','100001')
GO


print '' print '*** Creating sp_add_student ***'
GO
CREATE PROCEDURE [dbo].[sp_add_student]
	(
		@Firstname	nvarchar(50),
		@Lastname	nvarchar(100),
		@Email		nvarchar(100),
		@PasswordHash	nvarchar(100),
		@Active		bit
	)
AS
	BEGIN
		INSERT INTO [dbo].[User]
			(
				Firstname, Lastname, Email, PasswordHash, Active, Role
			)
		VALUES
			(
				@Firstname, @Lastname, @Email, @PasswordHash, @Active, "Student"
			)
	END
GO

print '' print '*** Creating sp_add_Tutor ***'
GO
CREATE PROCEDURE [dbo].[sp_add_tutor]
	(
	@UserID	int
	)
AS
	BEGIN

		UPDATE [User]
			SET Role = "Tutor"
			WHERE UserID = @UserID				
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating sp_delete_tutor_application ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_tutor_application]
	(
	@UserID	int,
	@SubjectName nvarchar(100)
	)
AS
	BEGIN
		DELETE FROM [TutorApplication]
		WHERE UserID = @UserID
		AND SubjectName = @SubjectName
	END
GO

print '' print '*** Create sp_add_Employee ***'
GO
CREATE PROCEDURE [dbo].[sp_add_employee]
	(
		@Firstname	nvarchar(50),
		@Lastname	nvarchar(100),
		@Email		nvarchar(100),
		@PasswordHash	nvarchar(100),
		@Active		bit
	)
AS
	BEGIN
		INSERT INTO [dbo].[User]
			(
				Firstname, Lastname, Email, PasswordHash, Active, Role
			)
		VALUES
			( 
				@Firstname, @Lastname, @Email, @PasswordHash, @Active, "Employee"
			)
	End
GO


print '' print '*** Creating sp_authenticate_user ***'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_user]
	(
	@Email		nvarchar(100),
	@PasswordHash	nvarchar(100)
	)
AS
	BEGIN
		SELECT COUNT(UserID)
		FROM [User]
		WHERE Email = @Email
		AND PasswordHash = @PasswordHash
	END
GO


print '' print '*** Creating sp_retrieve_user_with_email ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_user_with_email]
	(
	@Email nvarchar(100)
	)
AS
	Begin
		SELECT UserID, FirstName, LastName, Email, Active, Role
		FROM [User]
		WHERE Email = @Email
	END
GO

print '' print '*** Creating sp_retrieve_subjectArea ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_subjectArea]
AS
	BEGIN
		SELECT SubjectAreaID, SubjectAreaName
		FROM SubjectArea
	END
GO

print '' print '*** retrieve_subject_list_with_subjectAreaName ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_list_subject_with_subjectAreaName]
	(
	@SubjectAreaName nvarchar(100)
	)
AS
	BEGIN
		SELECT Subject.SubjectID, Subject.SubjectAreaID, Subject.SubjectName
		From Subject
		INNER JOIN SubjectArea
		ON Subject.SubjectAreaID = SubjectArea.SubjectAreaID
		WHERE SubjectAreaName = @SubjectAreaName
	END
GO

print'' print'*** Creating sp_retrieve_tutors_for_subject_with_subjectName ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_tutors_for_subject_with_subjectName]
	(
	@SubjectName	nvarchar(100),
	@CurrentUser	int
	)
AS
	BEGIN
		SELECT ClassTutors.UserID, ClassTutors.SubjectID, [User].Firstname, [User].Lastname, [User].Email
		FROM ClassTutors
		INNER JOIN [User]
		ON ClassTutors.UserID = [User].UserID 
		INNER JOIN Subject
		ON ClassTutors.SubjectID = Subject.SubjectID
		WHERE Subject.SubjectName = @SubjectName
		AND [User].UserID != @CurrentUser
	END
GO

print'' print'*** Creating sp_submit_tutor_application ***'
GO
CREATE PROCEDURE [dbo].[sp_submit_tutor_application]
	(
	@UserID		int,
	@SubjectName	nvarchar(100)
	)
AS
	BEGIN
		INSERT INTO [dbo].[TutorApplication]
			(
			UserID, SubjectName
			)
			VALUES
			(
			@UserID, @SubjectName
			)
		RETURN @@ROWCOUNT
	END
GO

print'' print '*** Creating sp_retrieve_tutor_applications ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_tutor_applications]
AS
	BEGIN
		SELECT [TutorApplication].SubjectName, [TutorApplication].UserID, [User].Firstname, [User].Lastname, [User].Email
		FROM [TutorApplication], [User]
		WHERE TutorApplication.UserID = [User].UserID
	END
GO

print '' print '*** creating sp_add_subject_request ***'
GO
CREATE PROCEDURE [dbo].[sp_add_subject_request]
	(
	@SubjectAreaName	nvarchar(100),
	@SubjectName		nvarchar(100)
	)
AS
	BEGIN
		INSERT INTO [dbo].[SubjectRequest]
		(
		SubjectAreaName, SubjectName
		)
		VALUES
		(
		@SubjectAreaName, @SubjectName
		)
	END
GO

print '' print '*** Creating sp_retrieve_all_subject_requests ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_subject_requests]
AS
	BEGIN
		SELECT SubjectAreaName, SubjectName, SubjectRequestID
		FROM SubjectRequest
	END
GO

print'' print '*** Creating sp_add_tutor_to_class_tutors ***'
GO
CREATE PROCEDURE [dbo].[sp_add_tutor_to_class_tutors]
	(
	@UserID		int,
	@SubjectID	int
	)
AS
	BEGIN
		INSERT INTO [dbo].[ClassTutors]
		(
		UserID, SubjectID
		)
		VALUES
		(
		@UserID, @SubjectID
		)
	END
GO


print '' print '***Creating sp_retrieve_subjectID_with_subjectName ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_subjectID_with_subjectName]
	(
	@SubjectName		nvarchar(100)
	)
AS
	BEGIN
		SELECT SubjectID
		FROM Subject
		WHERE SubjectName = @SubjectName
	END
GO

print '' print '***Creating sp_retrieve_subjectID_with_subjectName ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_subjectAreaID_with_subjectAreaName]
	(
	@SubjectAreaName		nvarchar(100)
	)
AS
	BEGIN
		SELECT SubjectAreaID
		FROM SubjectArea
		WHERE SubjectAreaName = @SubjectAreaName
	END
GO

print'' print '*** Creating sp_add_tutor_to_tutor_table ***'
GO
CREATE PROCEDURE [dbo].[sp_add_tutor_to_tutor_table]
	(
	@UserID		int
	)
AS
	IF NOT EXISTS( SELECT UserID FROM [dbo].[Tutor] WHERE UserID = @UserID )
	BEGIN
     		INSERT INTO [dbo].[Tutor]
		(
		UserID
		)
		VALUES
		(
		@UserID
		)
	END
GO

print '' print '***Creating sp_retrieve_subjectName_with_subjectID ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_subjectName_with_subjectID]
	(
	@SubjectID		int
	)
AS
	BEGIN
		SELECT SubjectName
		FROM Subject
		WHERE SubjectID = @SubjectID
	END
GO		

print '' print '*** Creating sp_add_tutoring_request ***'
GO
CREATE PROCEDURE [dbo].[sp_add_tutoring_request]
	(
	@UserID		int,
	@TutorID	int,
	@SubjectID	int,
	@Day		Date,
	@Time		nvarchar(7)
	)
AS
	BEGIN
		INSERT INTO [dbo].[TutoringRequest]
		(
		UserID, TutorID, SubjectID, Day, Time
		)
		VALUES
		(
		@UserID, @TutorID, @SubjectID, @Day, @Time
		)
	END
GO

print'' print '*** Creating sp_add_new_subject ***'
GO
CREATE PROCEDURE [dbo].[sp_add_new_subject]
	(
	@SubjectAreaID 	int,
	@SubjectName	nvarchar(100)
	)
AS
	BEGIN
		INSERT INTO [dbo].[Subject]
		(
		SubjectAreaID, SubjectName
		)
		VALUES
		(
		@SubjectAreaID, @SubjectName
		)
	END
GO

print'' print '*** Creating sp_retrieve_tutorID_from_userID ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_tutorID_from_userID]
	(
	@UserID		int
	)
AS
	BEGIN
		SELECT TutorID
		From Tutor
		WHERE UserID = @UserID
	END
GO


print'' print '*** Creating sp_retrieve_student_appointments ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_student_appointments]
	(
	@TutorID	int
	)
AS
	BEGIN
		SELECT Day, Time, SubjectID, Firstname, Lastname, Status, TutoringRequestID
		FROM TutoringRequest, [User]
		WHERE TutoringRequest.UserID = [User].UserID
		AND TutorID = @TutorID
	END
GO

print'' print '*** Creating sp_retrieve_tutors_appointments ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_tutors_appointments]
	(
	@UserID		int
	)
AS
	BEGIN
		SELECT Day, Time, SubjectID, Status, TutoringRequestID, TutorID
		FROM TutoringRequest
		WHERE UserID = @UserID
	END
GO


print'' print '*** Creating sp_accept_student_appointment ***'
GO
CREATE PROCEDURE [dbo].[sp_accept_student_appointment]
	(
	@TutoringRequestID	int
	)
AS
	BEGIN
		UPDATE [TutoringRequest]
			SET Status = "Accepted"
			WHERE TutoringRequestID = @TutoringRequestID				
		RETURN @@ROWCOUNT
	END
GO

print'' print '*** Creating sp_delete_student_appointment_request ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_student_appointment_request]
	(
	@TutoringRequestID	int
	)
AS
	BEGIN
		DELETE FROM [dbo].[TutoringRequest]
		WHERE TutoringRequestID = @TutoringRequestID
	END
GO

print '' print '*** Creating sp_delete_subject_request ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_subject_request]
	(
	@SubjectRequestID	int
	)
AS
	BEGIN
		DELETE FROM [dbo].[SubjectRequest]
		WHERE SubjectRequestID = @SubjectRequestID
		RETURN @@ROWCOUNT
	END
GO


print '' print '*** Creating sp_tutor_details_for_appointment***'
GO
CREATE PROCEDURE [dbo].[sp_tutor_details_for_appointment]
	(
	@TutorID	int
	)
AS
	BEGIN
		SELECT Firstname, Lastname, Email
		FROM [User], Tutor
		WHERE [User].UserID = Tutor.UserID
		AND TutorID = @TutorID
	END
GO

print'' print '*** creating sp_retrieve_all_tutors ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_tutors]
AS
	BEGIN
		SELECT [tutor].UserID, TutorID, Firstname, Lastname, Email
		FROM [User], Tutor
		WHERE [User].UserID = Tutor.UserID
	END
GO

print '' print '*** Creating sp_update_passswordHash'
GO
CREATE PROCEDURE [dbo].[sp_update_passwordHash]
	(
		@UserID			int,
		@CurrentPasswordHash	varchar(100),
		@NewPasswordHash	varchar(100)
	)
AS
	BEGIN
		UPDATE [User]
		SET PasswordHash = @NewPasswordHash
		WHERE UserID = @UserID
		AND PasswordHash = @CurrentPasswordHash
		RETURN @@ROWCOUNT
	END
GO

print'' print '*** Creating sp_search_preexisting_appointments ***'
GO
CREATE PROCEDURE [dbo].[sp_search_preexisting_appointments]
	(
	@UserID		int,
	@SubjectID	int,
	@Day		date,
	@Time		nvarchar(7)
	)
AS
	BEGIN
		SELECT COUNT(TutoringRequestID) AS MatchingAppointmentsDay
		FROM TutoringRequest
		WHERE UserID = @UserID AND SubjectID = @SubjectID AND Day = @Day AND Time = @Time
	END
GO

print'' print '*** Creating sp_retrieve_classes_tutored_by_userID ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_classes_tutored_by_userID]
	(
	@UserID		int
	)
AS
	BEGIN
		SELECT SubjectName
		FROM Subject
		INNER JOIN [ClassTutors]
		ON Subject.SubjectID = ClassTutors.SubjectID
		INNER JOIN [User]
		ON ClassTutors.UserID = [User].UserID 
		WHERE [User].UserID = @UserID
	END
GO





