
SELECT 
[user].[ID],
[user].[Username],
[user].[PasswordHash],
[user].[PasswordSalt],
[user].[CreatedAt],
[user].[ModifiedAt]
FROM
[tbl_User] [user]
WHERE
[Username]= @Username