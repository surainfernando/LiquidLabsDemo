/*Create basic table to store Post data*/

/****
UserId,Id,Title,Body are retrieved from Api call and stroed in Db
InternalId was used as primary key for local storage.
A unique constraint was added to Id column, as in the api from which data is retireved , Posts are uniquely identified by Id  column.
**/

Create table dbo.Post(
InternalId int IDENTITY(1,1),
UserId int null,
Id int Unique null,
Title varchar(1000)  null,
Body varchar(1000)  null,
)

CREATE INDEX IX_Post_Id
ON dbo.Post (Id);