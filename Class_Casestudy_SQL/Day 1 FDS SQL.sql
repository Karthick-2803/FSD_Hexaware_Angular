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
