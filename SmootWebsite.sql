/****** Object:  Table [dbo].[Board]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[BoardID] [int] IDENTITY(700,1) NOT NULL,
	[GameID] [int] NOT NULL,
	[B1_Value] [nvarchar](10) NULL,
	[B1_Suit] [nvarchar](10) NULL,
	[B2_Value] [nvarchar](10) NULL,
	[B2_Suit] [nvarchar](10) NULL,
	[B3_Value] [nvarchar](10) NULL,
	[B3_Suit] [nvarchar](10) NULL,
	[B4_Value] [nvarchar](10) NULL,
	[B4_Suit] [nvarchar](10) NULL,
	[B5_Value] [nvarchar](10) NULL,
	[B5_Suit] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[BoardID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[GameID] [int] IDENTITY(100,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GameID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[PlayerID] [int] IDENTITY(200,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Venmo] [nvarchar](30) NOT NULL,
	[balance] [money] NOT NULL,
	[C1_Value] [nvarchar](50) NULL,
	[C1_Suit] [nvarchar](50) NULL,
	[C2_Value] [nvarchar](10) NULL,
	[C2_Suit] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerGame]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerGame](
	[PlayerID] [int] NOT NULL,
	[GameID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC,
	[GameID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Board]  WITH CHECK ADD FOREIGN KEY([GameID])
REFERENCES [dbo].[Game] ([GameID])
GO
ALTER TABLE [dbo].[PlayerGame]  WITH CHECK ADD FOREIGN KEY([GameID])
REFERENCES [dbo].[Game] ([GameID])
GO
ALTER TABLE [dbo].[PlayerGame]  WITH CHECK ADD FOREIGN KEY([PlayerID])
REFERENCES [dbo].[Player] ([PlayerID])
GO
/****** Object:  StoredProcedure [dbo].[spGetAllPlayerCards]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGetAllPlayerCards]
AS
BEGIN

	select PlayerID, Name, balance, Card1, Card2
	from Player


END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllPlayerGames]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[spGetAllPlayerGames]
AS
BEGIN

	select * from Game,Player as p

	inner join PlayerGame as pg
	on p.PlayerID = pg.PlayerID
	inner join Game as g
	on g.GameID = pg.GameID;


END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllPlayerInfo]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGetAllPlayerInfo]
(@pid int)
AS
BEGIN

	select * from Player
	where PlayerID = @pid

END
GO
/****** Object:  StoredProcedure [dbo].[spGetAllPlayers]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetAllPlayers]
AS
BEGIN

select * from Player

END
GO
/****** Object:  StoredProcedure [dbo].[spGetPlayerCardsByName]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGetPlayerCardsByName]
(@pname nvarchar(100))
AS
BEGIN

	select C1_Value,C1_Suit,C2_Value,C2_Suit from Player
	where Name = @pname

END
GO
/****** Object:  StoredProcedure [dbo].[spGetPlayerNameByID]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGetPlayerNameByID]
(@pid int)
AS
BEGIN

	select Name from Player
	where PlayerID = @pid

END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateBoard]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[spUpdateBoard]
  (@boardid int,
  @C1_value nvarchar(10),
  @C1_suit nvarchar(10),
  @C2_value nvarchar(10),
  @C2_suit nvarchar(10),
  @C3_value nvarchar(10),
  @C3_suit nvarchar(10),
  @C4_value nvarchar(10),
  @C4_suit nvarchar(10),
  @C5_value nvarchar(10),
  @C5_suit nvarchar(10))
  AS BEGIN 


	Update Board
	set B1_Value = @C1_value, 
	B1_Suit = @C1_suit, 
	B2_Value = @C2_value, 
	B2_Suit = @C2_suit, 
	B3_Value = @C3_value, 
	B3_Suit = @C3_suit, 
	B4_Value = @C4_value, 
	B4_Suit = @C4_suit, 
	B5_Value = @C5_value, 
	B5_Suit = @C5_suit
	select * from Board
	where BoardID = @boardid



  END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCard]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spUpdateCard]
(@card nvarchar(50))
AS
BEGIN

	Update Player
	set Card1 = @card 
	where PlayerID = 101;




END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateThenGetPlayerCardsByName]    Script Date: 12/11/2020 4:31:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spUpdateThenGetPlayerCardsByName]
(@pname nvarchar(100),
@c1_value nvarchar(10),
@c1_suit nvarchar(10),
@c2_value nvarchar(10),
@c2_suit nvarchar(10))
AS
BEGIN

	Update Player
	set C1_Value = @c1_value,
	C1_Suit = @c1_suit,
	C2_Value = @c2_value,
	C2_Suit = @c2_suit
	where Name = @pname


	select C1_Value,C1_Suit,C2_Value,C2_Suit
	from Player

END
GO
