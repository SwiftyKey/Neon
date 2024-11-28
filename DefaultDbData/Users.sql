-- This script only contains the table creation statements and does not fully represent the table in the database. It's still missing: sequences, indices, triggers. Do not use it as a backup.

CREATE TABLE [dbo].[Users] (
    [Id] int,
    [Name] nvarchar(450),
    [HashPassword] nvarchar(450),
    [IsAdmin] bit,
    [CreatedAt] datetimeoffset,
    [UpdatedAt] datetimeoffset,
    PRIMARY KEY ([Id])
);


INSERT INTO [dbo].[Users] ([Id],[Name],[HashPassword],[IsAdmin],[CreatedAt],[UpdatedAt]) VALUES (3,'Admin1','A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3','1','2024-11-28 11:33:19.3391654','0001-01-01 00:00:00.0000000');
INSERT INTO [dbo].[Users] ([Id],[Name],[HashPassword],[IsAdmin],[CreatedAt],[UpdatedAt]) VALUES (4,'Admin2','03AC674216F3E15C761EE1A5E255F067953623C8B388B4459E13F978D7C846F4','1','2024-11-28 11:33:29.7311492','0001-01-01 00:00:00.0000000');