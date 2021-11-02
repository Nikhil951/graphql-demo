--SQL Create Script
CREATE TABLE dbo.TechEventInfo(    
    EventId int IDENTITY(1,1) NOT NULL,    
    EventName varchar(100) NOT NULL,    
    Speaker varchar(100) NOT NULL,    
    EventDate Date NULL  
 CONSTRAINT [PK_TechEventInfo] PRIMARY KEY CLUSTERED     
(    
    EventId ASC    
)  
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]    
) ON [PRIMARY]

CREATE TABLE dbo.Participant(    
    ParticipantId int IDENTITY(1,1) NOT NULL,    
    ParticipantName varchar(100) NOT NULL,    
    Email varchar(100) NOT NULL,    
    Phone varchar(20) NULL,  
 CONSTRAINT [PK_Participant] PRIMARY KEY CLUSTERED     
(    
    ParticipantId ASC    
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]    
) ON [PRIMARY] 

CREATE TABLE [dbo].EventParticipants  
(  
    EventParticipantId INT NOT NULL IDENTITY(1,1) ,  
        EventId INT NOT NULL,  
    ParticipantId INT NULL,  
    CONSTRAINT [PK_EventParticipants] PRIMARY KEY CLUSTERED  
    (  
        EventParticipantId ASC  
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)   
    ON [PRIMARY]  
,CONSTRAINT [FK_EventParticipants_TechEventInfo_EventId] FOREIGN KEY (EventId) REFERENCES [TechEventInfo] (EventId)   
,CONSTRAINT [FK_EventParticipants_Participant_ParticipantId] FOREIGN KEY ([ParticipantId]) REFERENCES [Participant] ([ParticipantId])   
) ON [PRIMARY]