
INSERT INTO [tbl_Todo]
(
	Title,
	ParentID,
	UserID,
	CreatedAt,
	ModifiedAt
)

VALUES
(
	@Title,
	@ParentID,
	@UserID,
	@CreatedAt,
	@ModifiedAt 
)