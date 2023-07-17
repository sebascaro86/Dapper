## Dapper 

Script para la creacion de la db

```sql
CREATE TABLE [dbo].[Products]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(400) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIMEOFFSET NOT NULL
)
```
