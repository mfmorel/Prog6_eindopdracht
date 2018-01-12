CREATE TABLE [dbo].[Boekingen]
(
	[Hotelkamer_Id] INT NOT NULL , 
    [Tamagotchi_Id] INT NOT NULL, 
    CONSTRAINT [PK_Boekingen] PRIMARY KEY ([Hotelkamer_Id], [Tamagotchi_Id]), 
    CONSTRAINT [FK_Boekingen_Hotelkamer] FOREIGN KEY ([Hotelkamer_Id]) REFERENCES [Hotelkamer]([Id]), 
    CONSTRAINT [FK_Boekingen_Tamagotchi] FOREIGN KEY ([Tamagotchi_Id]) REFERENCES [Tamagotchi]([Id]), 
)
