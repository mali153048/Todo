
SELECT 
[todo].[ID],
[todo].[ParentID],
[todo].[Title],
[todo].[CreatedAt]
FROM
[tbl_Todo] [todo]
WHERE
[todo].[UserID]= @UserID
AND
[todo].[ParentID] IS NULL