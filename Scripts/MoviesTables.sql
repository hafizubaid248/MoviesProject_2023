 use movies;

 Create Table Users (
    UserID Int Primary Key Identity(1,1),
    Username NvarChar(50) NOT NULL,
    PasswordHash NvarChar(MAX) NOT NULL, 
    Email NvarChar(100) NOT NULL
);



ALTER TABLE Users
ADD IsAdmin BIT;

Create Table Movies (
    MovieID Int Primary Key Identity(1,1),
    Title NvarChar(100) NOT NULL,
    Description NvarChar(MAX),
    ReleaseDate DATE
   
);

Create Table Genres (
    GenreID Int Primary Key Identity(1,1),
    Name NvarChar(50) NOT NULL
);

Create Table MovieGenres (
    MovieGenreID Int Primary Key Identity(1,1),
    MovieID Int,
    GenreID Int,
	
    Constraint FK_MovieGenres_Movie Foreign Key (MovieID) References Movies (MovieID),
    Constraint FK_MovieGenres_Genre Foreign Key (GenreID) References Genres (GenreID)
);


Create Table UserMovies (
    UserMovieID Int Primary Key Identity(1,1),
    UserID Int,
    MovieID Int,
    PurchaseDate DateTime,    
    Constraint FK_UserMovies_User Foreign Key (UserID) References Users (UserID),
    Constraint FK_UserMovies_Movie Foreign Key (MovieID) References Movies (MovieID)
);


Create Table Admins (
    AdminID Int Primary Key Identity(1,1),
    Username NvarChar(50) NOT NULL,
    PasswordHash NvarChar(MAX) NOT NULL,
    Email NvarChar(100) NOT NULL
    
);






Select * from Users
Select * from Movies
Select * from Genres
Select * from MovieGenres
Select * from UserMovies