CREATE TABLE [dbo].[Hotelkamer_effect]
(
    [Naam] VARCHAR(MAX) NOT NULL, 
	[Type] VARCHAR(MAX) NOT NULL , 
	[Eigenschap] VARCHAR(MAX) NOT NULL, 
    [Operator] VARCHAR(10) NOT NULL, 
    [Value] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Hotelkamer_effect] PRIMARY KEY ([Naam], [Type]), 
    CONSTRAINT [FK_Hotelkamer_effect_Hotelkamer_type] FOREIGN KEY ([Type]) REFERENCES [Hotelkamer_type]([Type]) 
)
