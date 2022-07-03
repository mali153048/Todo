INSERT INTO [tbl_User]
(
[Username],
[PasswordHash],
[PasswordSalt],
[CreatedAt],
[ModifiedAt]
)
VALUES
(
@Username,
@PasswordHash,
@PasswordSalt,
@CreatedAt,
@ModifiedAt
)
