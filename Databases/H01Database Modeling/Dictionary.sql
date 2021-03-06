USE [master]
GO
/****** Object:  Database [MultilingualDictionary]    Script Date: 14.7.2013 г. 22:27:29 ч. ******/
CREATE DATABASE [MultilingualDictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MultilingualDictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultilingualDictionary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MultilingualDictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MultilingualDictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MultilingualDictionary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MultilingualDictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MultilingualDictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MultilingualDictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MultilingualDictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [MultilingualDictionary] SET  MULTI_USER 
GO
ALTER DATABASE [MultilingualDictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MultilingualDictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MultilingualDictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MultilingualDictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MultilingualDictionary', N'ON'
GO
USE [MultilingualDictionary]
GO
/****** Object:  Table [dbo].[DictionaryData]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DictionaryData](
	[WordID] [int] NOT NULL,
	[SynonymID] [int] NULL,
	[ExplenationID] [int] NULL,
	[TranslationWordID] [int] NOT NULL,
	[TranslationExplenationID] [int] NULL,
	[LanguageOfTheWordID] [int] NOT NULL,
	[LanguageOfTranslationID] [int] NOT NULL,
	[PartOfSpeechID] [int] NULL,
	[AntonymID] [int] NULL,
	[HypernymID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LaguageToLanguage]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LaguageToLanguage](
	[LanguageWord] [int] NOT NULL,
	[LanguageTranslation] [int] NOT NULL,
 CONSTRAINT [PK_LaguageToLanguage] PRIMARY KEY CLUSTERED 
(
	[LanguageTranslation] ASC,
	[LanguageWord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeech]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeech](
	[PartOfSpeechID] [int] IDENTITY(1,1) NOT NULL,
	[PartOfSpeechInfo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HypoChain] PRIMARY KEY CLUSTERED 
(
	[PartOfSpeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordExplenations]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordExplenations](
	[WordExplenationID] [int] IDENTITY(1,1) NOT NULL,
	[ExplenationText] [text] NULL,
	[LanguageID] [int] NOT NULL,
 CONSTRAINT [PK_WordExplenations] PRIMARY KEY CLUSTERED 
(
	[WordExplenationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[LanguageID] [int] NOT NULL,
 CONSTRAINT [PK_words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[DictionaryData] ([WordID], [SynonymID], [ExplenationID], [TranslationWordID], [TranslationExplenationID], [LanguageOfTheWordID], [LanguageOfTranslationID], [PartOfSpeechID], [AntonymID], [HypernymID]) VALUES (4, NULL, 1, 5, 2, 1, 2, 2, NULL, 7)
INSERT [dbo].[DictionaryData] ([WordID], [SynonymID], [ExplenationID], [TranslationWordID], [TranslationExplenationID], [LanguageOfTheWordID], [LanguageOfTranslationID], [PartOfSpeechID], [AntonymID], [HypernymID]) VALUES (7, NULL, NULL, 9, NULL, 1, 3, 2, 10, NULL)
INSERT [dbo].[LaguageToLanguage] ([LanguageWord], [LanguageTranslation]) VALUES (2, 1)
INSERT [dbo].[LaguageToLanguage] ([LanguageWord], [LanguageTranslation]) VALUES (3, 1)
INSERT [dbo].[LaguageToLanguage] ([LanguageWord], [LanguageTranslation]) VALUES (1, 2)
INSERT [dbo].[LaguageToLanguage] ([LanguageWord], [LanguageTranslation]) VALUES (1, 3)
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([LanguageID], [Name]) VALUES (1, N'Bulgarian')
INSERT [dbo].[Languages] ([LanguageID], [Name]) VALUES (2, N'English')
INSERT [dbo].[Languages] ([LanguageID], [Name]) VALUES (3, N'Italian')
SET IDENTITY_INSERT [dbo].[Languages] OFF
SET IDENTITY_INSERT [dbo].[PartsOfSpeech] ON 

INSERT [dbo].[PartsOfSpeech] ([PartOfSpeechID], [PartOfSpeechInfo]) VALUES (1, N'verb')
INSERT [dbo].[PartsOfSpeech] ([PartOfSpeechID], [PartOfSpeechInfo]) VALUES (2, N'noun')
INSERT [dbo].[PartsOfSpeech] ([PartOfSpeechID], [PartOfSpeechInfo]) VALUES (3, N'adjective')
SET IDENTITY_INSERT [dbo].[PartsOfSpeech] OFF
SET IDENTITY_INSERT [dbo].[WordExplenations] ON 

INSERT [dbo].[WordExplenations] ([WordExplenationID], [ExplenationText], [LanguageID]) VALUES (1, N'млада неомъжена жена', 1)
INSERT [dbo].[WordExplenations] ([WordExplenationID], [ExplenationText], [LanguageID]) VALUES (2, N'young unmarried woman', 2)
INSERT [dbo].[WordExplenations] ([WordExplenationID], [ExplenationText], [LanguageID]) VALUES (3, N'una giovane donna non sposata', 3)
SET IDENTITY_INSERT [dbo].[WordExplenations] OFF
SET IDENTITY_INSERT [dbo].[Words] ON 

INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (1, N'Български', 1)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (2, N'Bulgarian', 2)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (3, N'Bulgaro', 3)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (4, N'госпожица', 1)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (5, N'miss', 2)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (6, N'signorina', 3)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (7, N'жена', 1)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (8, N'woman', 2)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (9, N'donna', 3)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (10, N'мъж', 1)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (11, N'man', 2)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (12, N'uomo', 3)
INSERT [dbo].[Words] ([WordID], [Word], [LanguageID]) VALUES (13, N'male', 2)
SET IDENTITY_INSERT [dbo].[Words] OFF
/****** Object:  Index [UQ_codes_WordsSynonyms]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
ALTER TABLE [dbo].[DictionaryData] ADD  CONSTRAINT [UQ_codes_WordsSynonyms] UNIQUE NONCLUSTERED 
(
	[WordID] ASC,
	[LanguageOfTheWordID] ASC,
	[LanguageOfTranslationID] ASC,
	[PartOfSpeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_codesLanguages]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
ALTER TABLE [dbo].[Languages] ADD  CONSTRAINT [UQ_codesLanguages] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ_codes]    Script Date: 14.7.2013 г. 22:27:30 ч. ******/
ALTER TABLE [dbo].[Words] ADD  CONSTRAINT [UQ_codes] UNIQUE NONCLUSTERED 
(
	[Word] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryData_HypoChain] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[PartsOfSpeech] ([PartOfSpeechID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_DictionaryData_HypoChain]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryData_LaguageToLanguage] FOREIGN KEY([LanguageOfTranslationID], [LanguageOfTheWordID])
REFERENCES [dbo].[LaguageToLanguage] ([LanguageTranslation], [LanguageWord])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_DictionaryData_LaguageToLanguage]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryData_WordExplenations] FOREIGN KEY([TranslationExplenationID])
REFERENCES [dbo].[WordExplenations] ([WordExplenationID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_DictionaryData_WordExplenations]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryData_Words] FOREIGN KEY([TranslationWordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_DictionaryData_Words]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryData_Words1] FOREIGN KEY([HypernymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_DictionaryData_Words1]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryData_Words2] FOREIGN KEY([HypernymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_DictionaryData_Words2]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryData_Words3] FOREIGN KEY([AntonymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_DictionaryData_Words3]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_synonym] FOREIGN KEY([SynonymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_synonym]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_word] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_word]
GO
ALTER TABLE [dbo].[DictionaryData]  WITH CHECK ADD  CONSTRAINT [FK_WordsSynonymsLanguage_WordExplenations] FOREIGN KEY([ExplenationID])
REFERENCES [dbo].[WordExplenations] ([WordExplenationID])
GO
ALTER TABLE [dbo].[DictionaryData] CHECK CONSTRAINT [FK_WordsSynonymsLanguage_WordExplenations]
GO
ALTER TABLE [dbo].[WordExplenations]  WITH CHECK ADD  CONSTRAINT [FK_WordExplenations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[WordExplenations] CHECK CONSTRAINT [FK_WordExplenations_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
USE [master]
GO
ALTER DATABASE [MultilingualDictionary] SET  READ_WRITE 
GO
