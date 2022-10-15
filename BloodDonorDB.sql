-- CREATE DATABASE BloodDonor
-- GO

-- USE BloodDonor
-- GO

-- ****** CREATE TABLE ***** --
CREATE TABLE [Organization](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Username] VARCHAR(20) NOT NULL,
	[Password] VARCHAR(16) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Discription] NTEXT NULL,
	[AddressDetails] NVARCHAR(100) NULL,
    [District] NVARCHAR(30) NOT NULL,
    [City] NVARCHAR(30) NOT NULL,
	[IsRedCross] BIT NOT NULL
);
GO

CREATE TABLE [Campaign](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Discription] NTEXT NULL,
	[AddressDetails] NVARCHAR(100) NULL,
    [District] NVARCHAR(30) NOT NULL,
    [City] NVARCHAR(30) NOT NULL,
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME NOT NULL,
	[OrganizationId] INT NOT NULL
);
GO

CREATE TABLE [Volunteer](
	[Phone] CHAR(10) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[IdentityNumber] CHAR(12) NOT NULL,
	[Password] VARCHAR(16) NOT NULL,
	[Email] VARCHAR(50) NULL,
	[AddressDetails] NVARCHAR(100) NULL,
    [District] NVARCHAR(30) NOT NULL,
    [City] NVARCHAR(30) NOT NULL,
    [BloodType] NVARCHAR(10) NOT NULL,
	[LastDonationDate] DATE NULL
);
GO

CREATE TABLE [DonatedBlood](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Type] NVARCHAR(10) NOT NULL,
    [Amount] INT NOT NULL
);
GO

CREATE TABLE [VolunteerHealth](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[DiseaseName] NVARCHAR(100) NOT NULL,
    [DiseaseDescription] NTEXT NULL,
);
GO

CREATE TABLE [VolunteerInCampaign](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[VolunteerId] CHAR(10) NOT NULL,
	[CampaignId] INT NOT NULL,
	[DonatedBloodId] INT NULL,
	[VolunteerHealthId] INT NOT NULL,
	[RegistrationDate] DATE NOT NULL,
    [DonatedDate] DATE NOT NULL
);
GO

CREATE TABLE [BloodRequest](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[VolunteerId] CHAR(10) NOT NULL,
	[OrganizationId] INT NOT NULL,
	[RequestDate] DATE NOT NULL,
    [Description] NTEXT NOT NULL,
    [ReceiverName] NVARCHAR(100) NOT NULL,
    [ReceiverIdentityNumber] CHAR(12) NOT NULL,
    [Status] NVARCHAR(20) NOT NULL
);
GO

-- ****** CREATE CONSTRAINT ***** --
-- *** Primary key *** --
ALTER TABLE [Organization] ADD CONSTRAINT [PK_Organization] PRIMARY KEY (Id);
GO

ALTER TABLE [Campaign] ADD CONSTRAINT [PK_Campaign] PRIMARY KEY (Id);
GO

ALTER TABLE [Volunteer] ADD CONSTRAINT [PK_Volunteer] PRIMARY KEY (Phone);
GO

ALTER TABLE [DonatedBlood] ADD CONSTRAINT [PK_DonatedBlood] PRIMARY KEY (Id);
GO

ALTER TABLE [VolunteerHealth] ADD CONSTRAINT [PK_VolunteerHealth] PRIMARY KEY (Id);
GO

ALTER TABLE [VolunteerInCampaign] ADD CONSTRAINT [PK_VolunteerInCampaign] PRIMARY KEY (Id);
GO

ALTER TABLE [BloodRequest] ADD CONSTRAINT [PK_BloodRequest] PRIMARY KEY (Id);
GO

-- *** Foreign key *** --
ALTER TABLE [Campaign]
ADD CONSTRAINT FK_Campaign_Organization
    FOREIGN KEY ([OrganizationId])
    REFERENCES [Organization]([Id]);
GO

ALTER TABLE [VolunteerInCampaign]
ADD CONSTRAINT FK_VolunteerInCampaign_Volunteer
    FOREIGN KEY ([VolunteerId])
    REFERENCES [Volunteer]([Phone]);
GO

ALTER TABLE [VolunteerInCampaign]
ADD CONSTRAINT FK_VolunteerInCampaign_Campaign
    FOREIGN KEY ([CampaignId])
    REFERENCES [Campaign]([Id]);
GO

ALTER TABLE [VolunteerInCampaign]
ADD CONSTRAINT FK_VolunteerInCampaign_DonatedBlood
    FOREIGN KEY ([DonatedBloodId])
    REFERENCES [DonatedBlood]([Id]);
GO

ALTER TABLE [VolunteerInCampaign]
ADD CONSTRAINT FK_VolunteerInCampaign_VolunteerHealth
    FOREIGN KEY ([VolunteerHealthId])
    REFERENCES [VolunteerHealth]([Id]);
GO

ALTER TABLE [BloodRequest]
ADD CONSTRAINT FK_BloodRequest_Volunteer
    FOREIGN KEY ([VolunteerId])
    REFERENCES [Volunteer]([Phone]);
GO

ALTER TABLE [BloodRequest]
ADD CONSTRAINT FK_BloodRequest_Organization
    FOREIGN KEY ([OrganizationId])
    REFERENCES [Organization]([Id]);
GO

-- ****** INSERT DATA ***** --