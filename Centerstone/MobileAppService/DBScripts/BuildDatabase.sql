--Create Database CenterStone
--GO

--USE CenterStone
--GO

CREATE TABLE HifApplication
(
    ApplicationID bigint identity(1, 1) PRIMARY KEY NOT NULL,
    UniqueAppId nvarchar(max), 
    LiveStreetAddress nvarchar(max),
    LiveCity nvarchar(30),
    LiveState nvarchar(30),
    LiveZipCode nvarchar(30),
    MailingAddress nvarchar(max),
    MailingCity nvarchar(30),
    MailingState nvarchar(30),
    MailingZipCode nvarchar(30),
    PhoneNumber nvarchar(20),
    MessagePhone nvarchar(20),
    DurationYears int,
    DurationMonth int,
    HousingStatus nvarchar(30),
    CostMonthly decimal (18, 2),
    HousingType nvarchar(30),
    NumberBedrooms int,
    TotalPeople int,
    HouseholdIncome decimal(18,2),
    TargetGroup1 bit,
    TargetGroup2 bit,
    HeatSource nvarchar(30),
    AnnualHeatCost decimal(18,2),
    BackupHeatCost bit,
    UsedSurrogate bit,
    TotalEnergyCost decimal (18, 2),
    TotalAnnualElectricCosts decimal (18, 2), 
    HifJsonData nvarchar(max),
    Email nvarchar(max)
)
GO

CREATE TABLE HouseholdMembers
(
    PersonID bigint identity(1,1) PRIMARY KEY NOT NULL,
    ApplicationID bigint,
    FullName nvarchar(max),
    SSN nvarchar(11),
    DateOfBirth date,
    RelationToPrimary nvarchar(30),
    Gender nvarchar(20),
    Ethnicity nvarchar(50),
    Race nvarchar(max),
    Education nvarchar(max),
    Disability bit,
    MilitaryVeteran bit, 
    HealthInsurance bit,
    IsPrimary  bit,
    PaidAdult bit
)
GO

ALTER TABLE HouseholdMembers  WITH NOCHECK ADD CONSTRAINT [FK_Hif_Household_AppId] FOREIGN KEY([ApplicationID])
REFERENCES HifApplication ([ApplicationID])
GO

ALTER TABLE HouseHoldMembers CHECK CONSTRAINT [FK_Hif_Household_AppID]
GO

CREATE TABLE IncomeTypes
(
    RowID bigint identity(1,1) PRIMARY KEY NOT NULL,
    ApplicationID bigint,
    PersonID bigint,
    SSI bit,
    TANF bit,
    GA bit,
    VA bit,
    SocialSecurity bit,
    Military bit,
    EarnedIncome bit,
    Pension bit,
    SelfEmployed bit,
    ChildSupport bit,
    Unemployment bit,
    Other bit
)
GO

ALTER TABLE [dbo].IncomeTypes  WITH NOCHECK ADD CONSTRAINT FK_Income_Hif_AppID FOREIGN KEY([ApplicationID])
REFERENCES HifApplication ([ApplicationID])
GO

ALTER TABLE [IncomeTypes] CHECK CONSTRAINT FK_Income_Hif_AppID
GO

ALTER TABLE [dbo].IncomeTypes  WITH NOCHECK ADD CONSTRAINT FK_INCOME_Household_Person FOREIGN KEY(PersonID)
REFERENCES HouseholdMembers (PersonID)
GO

ALTER TABLE IncomeTypes CHECK CONSTRAINT FK_Income_Household_Person


CREATE TABLE Images
(
    ImageID bigint identity(1,1) PRIMARY KEY NOT NULL,
    UniqueImageId nvarchar(max) ,
    ApplicantGUID nvarchar(max), 
    ApplicationID bigint ,
    FileName nvarchar(50) ,
    ImageName nvarchar(50),
    ImageType nvarchar(50),
    --create foreign key to applicaiton
)

ALTER TABLE Images  WITH NOCHECK ADD CONSTRAINT FK_Hif_Images_AppID FOREIGN KEY([ApplicationID]) REFERENCES HifApplication ([ApplicationID])
GO

ALTER TABLE Images CHECK CONSTRAINT FK_Hif_Images_AppId
GO

CREATE TABLE StoredImages
(
    RowId bigint identity(1,1) PRIMARY KEY NOT NULL,
    ImageID bigint,
    ImageData VARBINARY,
)

ALTER TABLE StoredImages  WITH NOCHECK ADD CONSTRAINT FK_Images_StoredImages_ImageID FOREIGN KEY(ImageId) REFERENCES Images (ImageId)
GO

ALTER TABLE StoredImages CHECK CONSTRAINT FK_Images_StoredImages_ImageID

CREATE TABLE IncomeRules
(
    RowID bigint PRIMARY KEY NOT NULL,
    HouseholdSize int NOT NULL,
    MaxIncome decimal(18,2) NOT NULL,
    HouseholdAdjust decimal(4,2) NOT NULL
)

--DROP TABLE HifApplication, HouseholdMembers, Images, IncomeRules, IncomeTypes, StoredImages