Drop table Languages

CREATE TABLE Languages (
	LanguageID int IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	UNIQUE(Name),
	CONSTRAINT PK_Language PRIMARY KEY(LanguageID)
)

Insert INTO Languages VALUES('Bulgarian');
Insert INTO Languages VALUES('English');
Insert INTO Languages VALUES('German');
Insert INTO Languages VALUES('French');
Insert INTO Languages VALUES('Spanish');

Select * from Languages

CREATE TABLE Countries (
	CountryID int IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	ContinentID int NOT NULL,
	Population int NULL CHECK(Population >=0),
	LanguageID int NULL,
	CONSTRAINT PK_Country PRIMARY KEY(CountryID),
	CONSTRAINT FK_Continents FOREIGN KEY (ContinentID)
    REFERENCES Continents(ContinentID) 
    ON DELETE CASCADE
    ON UPDATE CASCADE,
	CONSTRAINT FK_Language FOREIGN KEY (LanguageID)
    REFERENCES Languages(LanguageID) 
    ON DELETE CASCADE
    ON UPDATE CASCADE,
	UNIQUE(Name, ContinentID)
)
GO

drop table Towns

CREATE TABLE Towns (
	TownID int IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	Population int NULL CHECK(Population >=0),
	CountryID int NOT NULL,
	CONSTRAINT PK_Town PRIMARY KEY(TownID),
	CONSTRAINT FK_Countries FOREIGN KEY (CountryID)
    REFERENCES Countries(CountryID) 
    ON DELETE CASCADE
    ON UPDATE CASCADE,
	
	UNIQUE(Name, CountryID)
)
GO

INSERT [dbo].[Countries] ([Name], [ContinentId]) VALUES (2, N'Bulgaria', 5)
INSERT [dbo].[Countries] ([Name], [ContinentId]) VALUES (3, N'Austria', 5)
INSERT [dbo].[Countries] ([Name], [ContinentId]) VALUES (4, N'Germany', 5)

INSERT Countries VALUES (N'Algeria', 3, 37900000, 4);
INSERT Countries VALUES (N'Botswana', 3, 2029307, 2);
INSERT Countries VALUES (N'Mexico', 5, 118395054, 5);
INSERT Countries VALUES (N'Austria', 1, 33476688, 3);
INSERT Countries VALUES (N'Bulgaria', 1, 33476688, 1);

Algiers


Select * from Countries

Select * from Continents

Select * from Towns

INSERT Towns VALUES (N'Mexico City', 8851080, 3)
INSERT Towns VALUES (N'Sofia', 1241396, 6)
INSERT Towns VALUES (N'Pleven', 106954,6 )
INSERT Towns VALUES (N'Algiers', 3415811, 2 )
INSERT Towns VALUES (N'Vidin', 48071, 6 )
INSERT Towns VALUES (N'Vratsa', 62852, 6)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (6, N'Sofia', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (7, N'Pleven', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (8, N'Plovdiv', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (9, N'Vidin', 2)