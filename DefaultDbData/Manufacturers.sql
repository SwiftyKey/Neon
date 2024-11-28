-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Manufacturers] (
    [Id] int,
    [Name] nvarchar(450),
    [CreatedAt] datetimeoffset,
    [UpdatedAt] datetimeoffset,
    PRIMARY KEY ([Id])
);


INSERT INTO [dbo].[Manufacturers] ([Id],[Name],[CreatedAt],[UpdatedAt]) VALUES (1,'Apple','2024-11-28 12:09:07.3098254','0001-01-01 00:00:00.0000000');
INSERT INTO [dbo].[Manufacturers] ([Id],[Name],[CreatedAt],[UpdatedAt]) VALUES (2,'Raspberry Pi Foundation','2024-11-28 12:10:20.7050933','0001-01-01 00:00:00.0000000');
INSERT INTO [dbo].[Manufacturers] ([Id],[Name],[CreatedAt],[UpdatedAt]) VALUES (3,'ASUS','2024-11-28 12:10:51.3601619','0001-01-01 00:00:00.0000000'),(4,'MSI','2024-11-28 12:10:54.9414546','0001-01-01 00:00:00.0000000'),(5,'Acer','2024-11-28 12:11:03.5850570','0001-01-01 00:00:00.0000000'),(6,'HP','2024-11-28 12:11:33.4022795','0001-01-01 00:00:00.0000000'),(7,'Canon','2024-11-28 12:12:06.5780428','0001-01-01 00:00:00.0000000'),(8,'Xerox','2024-11-28 12:12:34.4005407','0001-01-01 00:00:00.0000000');