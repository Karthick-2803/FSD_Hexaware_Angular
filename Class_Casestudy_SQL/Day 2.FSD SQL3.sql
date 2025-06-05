use EventDb
create table UserInfo (
   EmailId varchar(100) primary key,
   UserName varchar(50) not null check(len(UserName) between 1 AND 50),
   Role varchar(20) not null check(Role IN('Admin','Participant')),
   Password varchar(20) not null check(len(Password) between 6 AND 20)
   )

create table EventDetails(
   EventId int primary key,
   EventName varchar(50) not null check(len(EventName) between 1 AND 50),
   EventCategory varchar(50) not null check(len(EventCategory) between 1 AND 50),
   EventDate datetime not null,
   Description varchar(255) null,
   Status varchar(100) check(Status IN('Active','In-Active'))
   )

create table SpeakerDetials(
    SpeakerId int primary key,
	SpeakerName varchar(50) not null check(len(SpeakerName) between 1 AND 50)
	)

create table SessionInfo(
      SessionId int primary key,
	  EventId INT NOT NULL FOREIGN KEY REFERENCES EventDetails(EventId),
      SessionTitle VARCHAR(50) NOT NULL CHECK(LEN(SessionTitle) BETWEEN 1 AND 50),
      SpeakerId INT NOT NULL FOREIGN KEY REFERENCES SpeakerDetials(SpeakerId),
	  Description VARCHAR(255) NULL,
      SessionStart DATETIME NOT NULL,
      SessionEnd DATETIME NOT NULL,
      SessionUrl VARCHAR(255)
	  )

create table ParticipantEventDetails(
      Id int primary key,
	  ParticipantEmailId VARCHAR(100) NOT NULL FOREIGN KEY REFERENCES UserInfo(EmailId),
      EventId INT NOT NULL FOREIGN KEY REFERENCES EventDetails(EventId),
      SessionId INT NOT NULL FOREIGN KEY REFERENCES SessionInfo(SessionId),
      IsAttended BIT CHECK (IsAttended IN (0, 1))
	  )
--1.Create stored procedures for all the tables to insert data.
CREATE PROCEDURE Add_UserInfo
   @EmailId varchar(100),
   @UserName varchar(50),
   @Role varchar(20),
   @Password varchar(20)
AS
BEGIN 
   INSERT INTO UserInfo VALUES (@EmailId,@UserName,@Role,@Password)
END

Add_UserInfo 'alice@example.com', 'Alice', 'Participant', 'pass123'
Add_UserInfo 'krish@example.com', 'Krishna', 'Participant', 'pass456'
Add_UserInfo 'nithish@example.com', 'Nithish', 'Participant', 'pass789'
Add_UserInfo 'jeffin@example.com', 'Jeffin', 'Participant', 'pass012'
Add_UserInfo 'pori@example.com', 'Poreselvan', 'Participant', 'pass345'
Add_UserInfo 'kewin@example.com', 'Kewin', 'Participant', 'pass678'

select * from UserInfo

CREATE PROCEDURE Add_EventDetials
   @EventId int,
   @EventName varchar(50),
   @EventCategory varchar(50),
   @EventDate datetime,
   @Description varchar(255),
   @Status varchar(100)=null
AS
BEGIN 
   INSERT INTO EventDetails VALUES (@EventId,@EventName,@EventCategory,@EventDate,@Description,@Status)
END

Add_EventDetials 1,'Tech Conference', 'IT', '2025-06-10', 'Annual Tech Event', 'Active'
Add_EventDetials 2, 'Data Science Summit', 'Data Analytics', '2025-07-15', 'Summit on Data Science trends', 'Active'
Add_EventDetials 3, 'Web Dev Bootcamp', 'Web Development', '2025-08-01', 'Hands-on sessions for beginners', 'Active'
Add_EventDetials 4, 'Cybersecurity Workshop', 'Security', '2025-09-10', 'Protecting digital systems', 'Active'
Add_EventDetials 5, 'Cloud Expo', 'Cloud Computing', '2025-10-20', 'Exploring cloud technologies', 'In-Active'

select * from EventDetails

CREATE PROCEDURE Add_SpeakerDetials
   @SpeakerId int,
   @SpeakerName varchar(50)
AS
BEGIN 
   INSERT INTO SpeakerDetials VALUES (@SpeakerId,@SpeakerName)
END

Add_SpeakerDetials 1, 'Dr. Smith'
Add_SpeakerDetials 2, 'Dr. Rina Kapoor'
Add_SpeakerDetials 3, 'Mr. Ankit Sharma'
Add_SpeakerDetials 4, 'Ms. Nisha Rao'
Add_SpeakerDetials 5, 'Dr. Arvind Rao'

select * from SpeakerDetials

CREATE PROCEDURE Add_SessionInfo
   @SessionId int,
   @EventId int,
   @SessionTitle varchar(50),
   @SpeakerId int,
   @Description varchar(255),
   @SessionStart datetime,
   @SessionEnd datetime,
   @SessionUrl varchar(255)
AS
BEGIN 
   INSERT INTO SessionInfo VALUES (@SessionId,@EventId,@SessionTitle,@SpeakerId,@Description,@SessionStart,@SessionEnd,@SessionUrl)
END

Add_SessionInfo 1,1, 'AI and Future', 1, 'Overview of AI', '2025-06-10 10:00', '2025-06-10 11:00', 'http://sessionurl'
Add_SessionInfo 2, 2, 'Machine Learning Applications', 2, 'Real-world ML case studies', '2025-07-15 10:30', '2025-07-15 11:30', 'http://datascience/session1'
Add_SessionInfo 3, 3, 'React Basics', 3, 'Introduction to ReactJS', '2025-08-01 09:00', '2025-08-01 10:00', 'http://webdev/session1'
Add_SessionInfo 4, 4, 'Ethical Hacking 101', 4, 'Basics of ethical hacking', '2025-09-10 13:00', '2025-09-10 14:30', 'http://cyber/session1'
Add_SessionInfo 5, 5, 'Azure vs AWS', 5, 'Comparing cloud platforms', '2025-10-20 11:00', '2025-10-20 12:30', 'http://cloud/session1'

select * from SessionInfo

CREATE PROCEDURE Add_ParticipantEventDetials
      @Id int,
	  @ParticipantEmailId VARCHAR(100),
      @EventId INT,
      @SessionId INT,
      @IsAttended BIT
AS
BEGIN 
   INSERT INTO ParticipantEventDetails VALUES (@Id,@ParticipantEmailId,@EventId,@SessionId,@IsAttended)
END

Add_ParticipantEventDetials 1, 'alice@example.com', 1, 1, 1
Add_ParticipantEventDetials 2, 'krish@example.com', 2, 2, 1
Add_ParticipantEventDetials 3, 'nithish@example.com', 3, 3, 0
Add_ParticipantEventDetials 4, 'jeffin@example.com', 4, 4, 1
Add_ParticipantEventDetials 5, 'pori@example.com', 5, 5, 0

select * from ParticipantEventDetails

--2.Create stored procedures for all the tables to delete data by using appropriate column in where clause. 
CREATE PROCEDURE Delete_ParticipantEventDetails
    @Id INT
AS
BEGIN
    DELETE FROM ParticipantEventDetails WHERE Id = @Id
END
Delete_ParticipantEventDetails 5


CREATE PROCEDURE Delete_EventDetials
    @EventId INT
AS
BEGIN
    DELETE FROM ParticipantEventDetails WHERE EventId = @EventId
	DELETE FROM SessionInfo WHERE EventId = @EventId
	DELETE FROM EventDetails WHERE EventId = @EventId
	SELECT * FROM EventDetails
END
Delete_EventDetials 5


CREATE PROCEDURE Delete_SpeakerDetials
    @SpeakerId INT
AS
BEGIN
	DELETE FROM SessionInfo WHERE SpeakerId = @SpeakerId
	DELETE FROM SpeakerDetials WHERE SpeakerId = @SpeakerId
	SELECT * FROM SpeakerDetials
END
Delete_SpeakerDetials 5

CREATE PROCEDURE Delete_SessionInfo
    @SessionId INT
AS
BEGIN
	DELETE FROM ParticipantEventDetails WHERE SessionId = @SessionId
	DELETE FROM SessionInfo WHERE SessionId = @SessionId
	SELECT * FROM SessionInfo
END
Delete_SessionInfo 4

CREATE PROCEDURE Delete_UserInfo
    @Password varchar(20)
AS
BEGIN
	DELETE FROM UserInfo WHERE Password = @Password
	SELECT * FROM UserInfo
END
Delete_UserInfo 'pass345'

--3.Create stored procedures for all the tables to update existing data by using appropriate column in where clause. 
CREATE PROCEDURE Update_UserInfo
    @EmailId VARCHAR(100),
    @UserName VARCHAR(50),
    @Role VARCHAR(20),
    @Password VARCHAR(20)
AS
BEGIN
    UPDATE UserInfo
    SET UserName = @UserName,
        Role = @Role,
        Password = @Password
    WHERE EmailId = @EmailId
END

CREATE PROCEDURE Update_EventDetails
    @EventId INT,
    @EventName VARCHAR(50),
    @EventCategory VARCHAR(50),
    @EventDate DATETIME,
    @Description VARCHAR(255),
    @Status VARCHAR(100)
AS
BEGIN
    UPDATE EventDetails
    SET EventName = @EventName,
        EventCategory = @EventCategory,
        EventDate = @EventDate,
        Description = @Description,
        Status = @Status
    WHERE EventId = @EventId
END

CREATE PROCEDURE Update_SpeakerDetials
    @SpeakerId INT,
    @SpeakerName VARCHAR(50)
AS
BEGIN
    UPDATE SpeakerDetials
    SET SpeakerName = @SpeakerName
    WHERE SpeakerId = @SpeakerId
END

CREATE PROCEDURE Update_SessionInfo
    @SessionId INT,
    @EventId INT,
    @SessionTitle VARCHAR(50),
    @SpeakerId INT,
    @Description VARCHAR(255),
    @SessionStart DATETIME,
    @SessionEnd DATETIME,
    @SessionUrl VARCHAR(255)
AS
BEGIN
    UPDATE SessionInfo
    SET EventId = @EventId,
        SessionTitle = @SessionTitle,
        SpeakerId = @SpeakerId,
        Description = @Description,
        SessionStart = @SessionStart,
        SessionEnd = @SessionEnd,
        SessionUrl = @SessionUrl
    WHERE SessionId = @SessionId
END

CREATE PROCEDURE Update_ParticipantEventDetails
    @Id INT,
    @ParticipantEmailId VARCHAR(100),
    @EventId INT,
    @SessionId INT,
    @IsAttended BIT
AS
BEGIN
    UPDATE ParticipantEventDetails
    SET ParticipantEmailId = @ParticipantEmailId,
        EventId = @EventId,
        SessionId = @SessionId,
        IsAttended = @IsAttended
    WHERE Id = @Id
END

--4.Create a view to show speaker detail of particular session. 
ALTER VIEW View_SessionDetailsEvent AS
SELECT
    s.SessionId,
    s.EventId,
    e.EventName,
    s.SessionTitle,
    s.SpeakerId,
    sp.SpeakerName,
    s.Description,
    s.SessionStart,
    s.SessionEnd,
    s.SessionUrl
FROM SessionInfo s
inner join EventDetails e on s.EventId = e.EventId
inner join SpeakerDetials sp on s.SpeakerId = sp.SpeakerId

DROP VIEW View_SessionDetailsEvent

SELECT * FROM View_SessionDetailsEvent
WHERE EventId = 1

--5.Create a view to show speaker detail of particular session. 
CREATE VIEW View_SpeakerDetailsBySession AS
SELECT
    s.SessionId,
    s.SessionTitle,
    s.EventId,
    e.EventName,
    sp.SpeakerId,
    sp.SpeakerName
FROM SessionInfo s
INNER JOIN SpeakerDetials sp ON s.SpeakerId = sp.SpeakerId
INNER JOIN EventDetails e ON s.EventId = e.EventId

SELECT * FROM View_SpeakerDetailsBySession
WHERE SessionId = 1

--6.Create a view to show all details of an event like sessions, speaker details, participant details. 
CREATE VIEW View_EventFullDetails AS
SELECT
    e.EventId,
    e.EventName,
    e.EventCategory,
    e.EventDate,
    e.Description AS EventDescription,
    e.Status AS EventStatus,

    s.SessionId,
    s.SessionTitle,
    s.Description AS SessionDescription,
    s.SessionStart,
    s.SessionEnd,
    s.SessionUrl,

    sp.SpeakerId,
    sp.SpeakerName,

    pd.Id AS ParticipantId,
    pd.ParticipantEmailId,
    pd.IsAttended

FROM EventDetails e
LEFT JOIN SessionInfo s ON e.EventId = s.EventId
LEFT JOIN SpeakerDetials sp ON s.SpeakerId = sp.SpeakerId
LEFT JOIN ParticipantEventDetails pd ON s.SessionId = pd.SessionId

SELECT * FROM View_EventFullDetails
WHERE EventId = 1

--7.Apply non-clustered indexes to tables by choosing appropriate columns. 
CREATE NONCLUSTERED INDEX IDX_EventCategory ON EventDetails(EventCategory)
CREATE NONCLUSTERED INDEX IDX_Status ON EventDetails(Status)