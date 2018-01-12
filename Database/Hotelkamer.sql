CREATE TABLE [dbo].[Hotelkamer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Groote] INT NOT NULL, 
    [Type] VARCHAR(255) NULL, 
    CONSTRAINT [FK_Hotelkamer_Hotelkamer_Type] FOREIGN KEY ([Type]) REFERENCES [Hotelkamer_type]([Type])
)
