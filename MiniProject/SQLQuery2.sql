Create database MiniProject
--------------DROP DATABASE MiniProject
use MiniProject

--------Drop Table Trains


CREATE TABLE Trains (
    TrainID INT PRIMARY KEY ,
    TrainName VARCHAR(50),
    Class VARCHAR(20),
    TotalBerths INT,
    AvailableBerths INT,
    Source VARCHAR(50),
    Destination VARCHAR(50),
    Status VARCHAR(20)  
);
 
 
   ----Drop Table Bookings
 
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY ,
   TrainID INT FOREIGN KEY REFERENCES Trains(TrainID),
    UserName VARCHAR(50) NOT NULL,
	Gender VARCHAR (10),
	Age INT,
	class VARCHAR(10),
	Berths INT,
	source VARCHAR (30),
	Destination VARCHAR (30),
	BookingDate DATE,
    Status VARCHAR(20) 
	);
 
-------------------------------------------------------------Add Train---------------------------------------------------------------------------
 
CREATE OR ALTER PROCEDURE AddTrain
 
    @TrainID INT ,
    @TrainName VARCHAR(50),
    @Class VARCHAR(20),
    @TotalBerths INT,
	@AvailableBerths INT,
    @Source VARCHAR(50),
    @Destination VARCHAR(50),
	@Status VARCHAR(20)
AS
BEGIN
    INSERT INTO Trains ( TrainID,TrainName, Class, TotalBerths, AvailableBerths, Source, Destination, Status)
    VALUES (@TrainID,@TrainName, @Class, @TotalBerths, @AvailableBerths, @Source, @Destination, @Status);
END;
---------------------------------------------------------------Modify Train------------------------------------------------------------
 
CREATE or ALTER PROCEDURE ModifyTrain
    @TrainID INT ,
    @TrainName VARCHAR(50),
    @Class VARCHAR(20),
    @TotalBerths INT,
	@AvailableBerths INT,
    @Source VARCHAR(50),
    @Destination VARCHAR(50),
	@Status VARCHAR(20)
AS
BEGIN
    UPDATE Trains
    SET TrainName = @TrainName, Class = @Class, TotalBerths = @TotalBerths,AvailableBerths=@AvailableBerths,Source=@Source,Destination=@Destination,Status=@status
    WHERE TrainID = @TrainID 
END;
 
------------------------Delete Train--------------------------------
CREATE OR ALTER PROCEDURE DeleteTrain
    @TrainID INT
AS
BEGIN
    UPDATE Trains
    SET Status = 'In Active'
    WHERE TrainID = @TrainID;
END;


----------------------Show TrainClasses---------------------------------------------------------------------


CREATE OR ALTER PROCEDURE ShowTrainClasses
    @TrainID INT
AS
BEGIN
    SELECT Class, TotalBerths, AvailableBerths
    FROM Trains
    WHERE TrainID = @TrainID;
END;
 
 --------------------CheckBerthAvailability-------------------------------
    
 CREATE OR ALTER PROCEDURE CheckBerthAvailability
    @TrainID INT,
    @Class VARCHAR(20),
    @RequiredBerths INT,
    @IsAvailable INT OUTPUT
AS
BEGIN
    DECLARE @AvailableBerths INT;
    SELECT @AvailableBerths = AvailableBerths
    FROM Trains
    WHERE TrainID = @TrainID AND Class = @Class;
 
    IF @AvailableBerths >= @RequiredBerths
        SET @IsAvailable = 1;
    ELSE
        SET @IsAvailable = 0;
END;


--------------------------------------Book Ticket--------------------------------
 

CREATE OR ALTER PROCEDURE BookTicket
    @BookingID INT,
    @TrainID INT,
    @UserName VARCHAR(50),
    @Gender VARCHAR(10),
    @Age INT,
    @Class VARCHAR(20),
    @Berths INT,
    @Source VARCHAR(50),
    @Destination VARCHAR(50),
    @BookingDate DATE,
    @Status VARCHAR(30) OUTPUT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
 
        -- Check if the train exists
        IF NOT EXISTS (SELECT 1 FROM Trains WHERE TrainID = @TrainID)
        BEGIN
            SET @Status = 'Train not available.';
            ROLLBACK TRANSACTION;
            RETURN;
        END
 
        -- Check if the train is active, and if the class and berths are available
        DECLARE @AvailableBerths INT;
        SELECT @AvailableBerths = AvailableBerths
        FROM Trains
        WHERE TrainID = @TrainID AND Class = @Class AND Status = 'Active';
 
        IF @AvailableBerths IS NULL
        BEGIN
            SET @Status = 'Class does not exist or is inactive.';
            ROLLBACK TRANSACTION;
            RETURN;
        END
 
        IF @AvailableBerths < @Berths
        BEGIN
            SET @Status = 'Not enough berths available.';
            ROLLBACK TRANSACTION;
            RETURN;
        END
 
        -- Insert booking details
        INSERT INTO Bookings (BookingID, TrainID, UserName, Gender, Age, Class, Berths, Source, Destination, BookingDate, Status)
        VALUES (@BookingID, @TrainID, @UserName, @Gender, @Age, @Class, @Berths, @Source, @Destination, @BookingDate, 'Booked');
 
        -- Update available berths
        UPDATE Trains
        SET AvailableBerths = AvailableBerths - @Berths
        WHERE TrainID = @TrainID AND Class = @Class;
 
        SET @Status = 'Booked';
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Status = 'An error occurred: ' + ERROR_MESSAGE();
    END CATCH
END;

----------------------------------------------------Cancel Ticket-------------------------------------
 
 
Create or ALTER  procedure CancelTicket
    @BookingID INT
AS
BEGIN
    DECLARE @TrainID INT;
    SELECT @TrainID = TrainID FROM Bookings WHERE BookingID = @BookingID AND Status = 'Booked';
    IF @TrainID IS NOT NULL
    BEGIN
        UPDATE Bookings SET Status = 'Cancelled' WHERE BookingID = @BookingID;
        UPDATE Trains SET AvailableBerths = AvailableBerths + 1 WHERE TrainID = @TrainID;
    END
    ELSE
        PRINT 'Invalid booking or already cancelled';
END;


---------------------ShowBookings-----------------------------------------------------------
 
 
CREATE OR ALTER PROCEDURE ShowBookings
AS
BEGIN
    SELECT b.BookingID, b.UserName, t.TrainName,t.Class,t.Source,t.Destination,b.Status
    FROM Bookings b
    JOIN Trains t ON b.TrainID = t.TrainID;
END

select * from Trains

select * from Bookings