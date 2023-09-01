
Create Procedure AddUser
    @Username NVarChar(50),
    @PasswordHash NVarChar(MAX),
    @Email NVarChar(100)
As
Begin
    Insert Into Users (Username, PasswordHash, Email)
    Values (@Username, @PasswordHash, @Email);
End;

Create Procedure AddMovie
    @Title NVarChar(100),
    @Description NVarChar(MAX),
    @ReleaseDate DATE
As
Begin
    Insert Into Movies (Title, Description, ReleaseDate)
    Values (@Title, @Description, @ReleaseDate);
End;

Create Procedure AddGenre
    @Name NVarChar(50)
As
Begin
    Insert Into Genres (Name)
    Values (@Name);
End;



Create Procedure AddMovieGenre
    @MovieID Int,
    @GenreID Int
As
Begin
    Insert Into MovieGenres (MovieID, GenreID)
    Values (@MovieID, @GenreID);
End;



Create Procedure AddUserMovieInteraction
    @UserID Int,
    @MovieID Int,
    @PurchaseDate DATETIME
As
Begin
    Insert Into UserMovies (UserID, MovieID, PurchaseDate)
    Values (@UserID, @MovieID, @PurchaseDate);
End;


Create Procedure AddMovieByAdmin
    @AdminID Int,
    @Title NVarChar(100),
    @Description NVarChar(MAX),
    @ReleaseDate DATE
AS
BEGIN
  
    IF EXISTS (SELECT 1 FROM Users WHERE UserID = @AdminID AND IsAdmin = 1)
    BEGIN
        INSERT INTO Movies (Title, Description, ReleaseDate)
        VALUES (@Title, @Description, @ReleaseDate);
    END
    ELSE
    BEGIN
     
        THROW 50000, 'User does not have admin privileges.', 1
    END;
END;