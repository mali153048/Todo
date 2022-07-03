
SELECT 
[todo].[ID],
[todo].[Title],
[todo].[CreatedAt]
FROM
[tbl_Todo] [todo]
WHERE
[todo].[ID]= @ID