CREATE TABLE [dbo].[DriversInCars]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [CarId] INT NOT NULL, 
    [DriverId] INT NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [Location] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_DriversInCars_ToCars] FOREIGN KEY ([CarId]) REFERENCES [Cars]([Id]), 
    CONSTRAINT [FK_DriversInCars_ToDrivers] FOREIGN KEY ([DriverId]) REFERENCES [Drivers]([Id]) 

)
