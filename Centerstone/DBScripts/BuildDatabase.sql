Create Database CenterStone
GO

USE CenterStone
GO


CREATE TABLE HiffApplication
(
	ApplicationID bigint identity(1, 1) PRIMARY KEY NOT NULL,
	LiveStreetAddress nvarchar(max) NOT NULL,
	LiveCity nvarchar(30) NOT NULL,
	LiveState nvarchar(30) NOT NULL,
	LiveZipCode nvarchar(30) NOT NULL,
	MailingAddress nvarchar(max),
	MailingCity nvarchar(30),
	MailingState nvarchar(30),
	MailingZipCode nvarchar(30),
	PhoneNumber nvarchar(20),
	MessagePhone nvarchar(20),
	DurationYears int,
	DurationMonth int,
	HousingStatus nvarchar(30),
	CostMontly decimal (18, 2),
	HousingType nvarchar(30),
	NumberBedrooms int,
	TotalPeople int NOT NULL,
	HouseholdIncome decimal(18,2) NOT NULL,
	TargetGroup1 nchar,
	TargetGrouop2 nchar,
	HeatSource nvarchar(30) NOT NULL,
	AnnualHeatCost decimal(18,2) NOT NULL,
	BakupHeatCost binary,
	UsedSurrogate binary,
	TotalEnergyCost decimal (18, 2),
	TotalAnnualEletricCosts decimal (18, 2) NOT NULL
)
GO

CREATE TABLE HouseholdMembers
(
	PersonID bigint identity(1,1) PRIMARY KEY NOT NULL,
	ApplicationID bigint NOT NULL,
	LastName nvarchar(max) NOT NULL,
	FirstName nvarchar(max) NOT NULL,
	MiddleInitial nchar,
	SSN nvarchar(11) NOT NULL,
	DateOfBirth date NOT NULL,
	RelationToPrimary nvarchar(30) NOT NULL,
	Gender nvarchar(20) NOT NULL,
	Ethnicity nvarchar(50),
	Race nvarchar(max),
	Education nvarchar(max),
	Disability nchar,
	MilitaryVeteran nchar, 
	HealthInsurance nchar,
	IsPrimary nchar,
	PaidAdult nchar
)
GO

ALTER TABLE HouseholdMembers  WITH NOCHECK ADD CONSTRAINT [FK_Hiff_Household_AppId] FOREIGN KEY([ApplicationID])
REFERENCES HiffApplication ([ApplicationID])
GO

ALTER TABLE HouseHoldMembers CHECK CONSTRAINT [FK_Hiff_Household_AppID]
GO

CREATE TABLE IncomeTypes
(
	RowID bigint identity(1,1) PRIMARY KEY NOT NULL,
	ApplicationID bigint NOT NULL,
	PersonID bigint NOT NULL,
	SSI binary,
	TANF binary,
	GA binary,
	VA binary,
	SocialSecurity binary,
	Military binary,
	EarnedIncome binary,
	Pension binary,
	SelfEmployed binary,
	ChildSupport binary,
	Unemployment binary,
	Other binary
)
GO

ALTER TABLE [dbo].IncomeTypes  WITH NOCHECK ADD CONSTRAINT FK_Income_Hiff_AppID FOREIGN KEY([ApplicationID])
REFERENCES HiffApplication ([ApplicationID])
GO

ALTER TABLE [IncomeTypes] CHECK CONSTRAINT FK_Income_Hiff_AppID
GO

ALTER TABLE [dbo].IncomeTypes  WITH NOCHECK ADD CONSTRAINT FK_INCOME_Household_Person FOREIGN KEY(PersonID)
REFERENCES HouseholdMembers (PersonID)
GO

ALTER TABLE IncomeTypes CHECK CONSTRAINT FK_Income_Household_Person


CREATE TABLE Images
(
	ImageID bigint identity(1,1) PRIMARY KEY NOT NULL,
	ApplicationID bigint NOT NULL,
	FileName nvarchar(50) NOT NULL,
	ImageName nvarchar(50) NOT NULL,
	ImageType nvarchar(50) NOT NULL,
	--create foreign key to applicaiton
)

ALTER TABLE Images  WITH NOCHECK ADD CONSTRAINT FK_Hiff_Images_AppID FOREIGN KEY([ApplicationID]) REFERENCES HiffApplication ([ApplicationID])
GO

ALTER TABLE Images CHECK CONSTRAINT FK_Hiff_Images_AppId
GO

CREATE TABLE StoredImages
(
	RowId bigint identity(1,1) PRIMARY KEY NOT NULL,
	ImageID bigint NOT NULL,
	ImageData VARBINARY NOT NULL,
)

ALTER TABLE StoredImages  WITH NOCHECK ADD CONSTRAINT FK_Images_StoredImages_ImageID FOREIGN KEY(ImageId) REFERENCES Images (ImageId)
GO

ALTER TABLE StoredImages CHECK CONSTRAINT FK_Images_StoredImages_ImageID
