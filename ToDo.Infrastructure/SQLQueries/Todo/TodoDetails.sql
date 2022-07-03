
SELECT 
[todo].[ID],
[todo].[UserID],
[todo].[ParentID],
[todo].[Title],
[todo].[CreatedAt]
FROM
[tbl_Todo] [todo]
WHERE
[todo].[ID]= @TodoID
OR
[todo].[ParentID] = @TodoID