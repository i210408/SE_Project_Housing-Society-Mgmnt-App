-- Use the database
USE master;
GO

-- Drop the database if it exists
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'df')
    DROP DATABASE df;
GO

-- Create the database
CREATE DATABASE df;
GO

-- Use the database
USE df;
GO

-- Drop foreign key constraints
IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL
    ALTER TABLE dbo.Bookings DROP CONSTRAINT FK_Bookings_Users;

IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL
    ALTER TABLE dbo.Bookings DROP CONSTRAINT FK_Bookings_Services;

IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL
    ALTER TABLE dbo.Bookings DROP CONSTRAINT FK_Bookings_Providers;

IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL
    ALTER TABLE dbo.Payments DROP CONSTRAINT FK_Payments_Users;

IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL
    ALTER TABLE dbo.Payments DROP CONSTRAINT FK_Payments_Bookings;

IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    ALTER TABLE dbo.Feedback DROP CONSTRAINT FK_Feedback_Users;

IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    ALTER TABLE dbo.Feedback DROP CONSTRAINT FK_Feedback_Providers;

IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    ALTER TABLE dbo.Feedback DROP CONSTRAINT FK_Feedback_Bookings;

IF OBJECT_ID('dbo.Notifications', 'U') IS NOT NULL
    ALTER TABLE dbo.Notifications DROP CONSTRAINT FK_Notifications_Users;

IF OBJECT_ID('dbo.PollOptions', 'U') IS NOT NULL
    ALTER TABLE dbo.PollOptions DROP CONSTRAINT FK_PollOptions_Polls;

IF OBJECT_ID('dbo.PollResponses', 'U') IS NOT NULL
    ALTER TABLE dbo.PollResponses DROP CONSTRAINT FK_PollResponses_Users;

IF OBJECT_ID('dbo.PollResponses', 'U') IS NOT NULL
    ALTER TABLE dbo.PollResponses DROP CONSTRAINT FK_PollResponses_Polls;

IF OBJECT_ID('dbo.PollResponses', 'U') IS NOT NULL
    ALTER TABLE dbo.PollResponses DROP CONSTRAINT FK_PollResponses_PollOptions;
GO

-- Drop tables if they exist (optional)
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
IF OBJECT_ID('dbo.Services', 'U') IS NOT NULL DROP TABLE dbo.Services;
IF OBJECT_ID('dbo.Providers', 'U') IS NOT NULL DROP TABLE dbo.Providers;
IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL DROP TABLE dbo.Bookings;
IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL DROP TABLE dbo.Payments;
IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL DROP TABLE dbo.Feedback;
IF OBJECT_ID('dbo.Notifications', 'U') IS NOT NULL DROP TABLE dbo.Notifications;
IF OBJECT_ID('dbo.Calendar', 'U') IS NOT NULL DROP TABLE dbo.Calendar;
IF OBJECT_ID('dbo.Polls', 'U') IS NOT NULL DROP TABLE dbo.Polls;
IF OBJECT_ID('dbo.PollOptions', 'U') IS NOT NULL DROP TABLE dbo.PollOptions;
IF OBJECT_ID('dbo.PollResponses', 'U') IS NOT NULL DROP TABLE dbo.PollResponses;
GO

-- Create the Users table
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    user_type VARCHAR(10) NOT NULL CHECK (user_type IN ('homeowner', 'admin'))
);

-- Create the Services table
CREATE TABLE Services (
    service_id INT IDENTITY(1,1) PRIMARY KEY,
    service_name VARCHAR(100) NOT NULL,
    service_description VARCHAR(MAX),
    service_cost DECIMAL(10, 2) NOT NULL
);

-- Create the Providers table
CREATE TABLE Providers (
    provider_id INT IDENTITY(1,1) PRIMARY KEY,
    provider_name VARCHAR(100) NOT NULL,
    provider_contact VARCHAR(20),
    provider_address VARCHAR(200)
);

-- Create the Bookings table
CREATE TABLE Bookings (
    booking_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    service_id INT NOT NULL,
    provider_id INT NOT NULL,
    booking_date DATE NOT NULL,
    booking_status VARCHAR(10) NOT NULL DEFAULT 'pending' CHECK (booking_status IN ('pending', 'confirmed', 'completed', 'canceled'))
);

-- Add foreign key constraints
ALTER TABLE dbo.Bookings ADD CONSTRAINT FK_Bookings_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);
ALTER TABLE dbo.Bookings ADD CONSTRAINT FK_Bookings_Services FOREIGN KEY (service_id) REFERENCES dbo.Services(service_id);
ALTER TABLE dbo.Bookings ADD CONSTRAINT FK_Bookings_Providers FOREIGN KEY (provider_id) REFERENCES dbo.Providers(provider_id);

-- Create the Payments table
CREATE TABLE Payments (
    payment_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    booking_id INT NOT NULL,
    payment_amount DECIMAL(10, 2) NOT NULL,
    payment_date DATE NOT NULL DEFAULT GETDATE()
);

-- Add foreign key constraints
ALTER TABLE dbo.Payments ADD CONSTRAINT FK_Payments_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);
ALTER TABLE dbo.Payments ADD CONSTRAINT FK_Payments_Bookings FOREIGN KEY (booking_id) REFERENCES dbo.Bookings(booking_id);

-- Create the Feedback table
CREATE TABLE Feedback (
    feedback_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    provider_id INT NOT NULL,
    booking_id INT NOT NULL,
    feedback_text VARCHAR(MAX),
    feedback_rating INT CHECK (feedback_rating >= 1 AND feedback_rating <= 5)
);

-- Add foreign key constraints
ALTER TABLE dbo.Feedback ADD CONSTRAINT FK_Feedback_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);
ALTER TABLE dbo.Feedback ADD CONSTRAINT FK_Feedback_Providers FOREIGN KEY (provider_id) REFERENCES dbo.Providers(provider_id);
ALTER TABLE dbo.Feedback ADD CONSTRAINT FK_Feedback_Bookings FOREIGN KEY (booking_id) REFERENCES dbo.Bookings(booking_id);

-- Create the Notifications table
CREATE TABLE Notifications (
    notification_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    notification_text VARCHAR(MAX) NOT NULL,
    notification_date DATETIME NOT NULL DEFAULT GETDATE()
);

-- Add foreign key constraints
ALTER TABLE dbo.Notifications ADD CONSTRAINT FK_Notifications_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);

-- Create the Calendar table
CREATE TABLE Calendar (
    event_id INT IDENTITY(1,1) PRIMARY KEY,
    event_title VARCHAR(100) NOT NULL,
    event_description VARCHAR(MAX),
    event_date DATE NOT NULL
);

-- Create the Polls table
CREATE TABLE Polls (
    poll_id INT IDENTITY(1,1) PRIMARY KEY,
    poll_question VARCHAR(MAX) NOT NULL,
    poll_start_date DATE NOT NULL,
    poll_end_date DATE NOT NULL
);

-- Create the PollOptions table
CREATE TABLE PollOptions (
    option_id INT IDENTITY(1,1) PRIMARY KEY,
    poll_id INT NOT NULL,
    option_text VARCHAR(200) NOT NULL
);

-- Add foreign key constraints
ALTER TABLE dbo.PollOptions ADD CONSTRAINT FK_PollOptions_Polls FOREIGN KEY (poll_id) REFERENCES dbo.Polls(poll_id);

-- Create the PollResponses table
CREATE TABLE PollResponses (
    response_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    poll_id INT NOT NULL,
    option_id INT NOT NULL
);

-- Add foreign key constraints
ALTER TABLE dbo.PollResponses ADD CONSTRAINT FK_PollResponses_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);
ALTER TABLE dbo.PollResponses ADD CONSTRAINT FK_PollResponses_Polls FOREIGN KEY (poll_id) REFERENCES dbo.Polls(poll_id);
ALTER TABLE dbo.PollResponses ADD CONSTRAINT FK_PollResponses_PollOptions FOREIGN KEY (option_id) REFERENCES dbo.PollOptions(option_id);
GO


-- Create the Bills table
CREATE TABLE Bills (
    bill_id INT IDENTITY(1,1) PRIMARY KEY,
    admin_id INT NOT NULL,
    homeowner_id INT NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    issue_date DATE NOT NULL,
    due_date DATE NOT NULL,
    payment_status VARCHAR(20) NOT NULL DEFAULT 'unpaid' CHECK (payment_status IN ('unpaid', 'paid')),
    FOREIGN KEY (admin_id) REFERENCES dbo.Users(user_id),
    FOREIGN KEY (homeowner_id) REFERENCES dbo.Users(user_id)
);

-- Create the Visitors table
CREATE TABLE Visitors (
    visitor_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    homeowner_id INT NOT NULL,
    FOREIGN KEY (homeowner_id) REFERENCES dbo.Users(user_id)
);

-- Create the Workers table
CREATE TABLE Workers (
    worker_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    homeowner_id INT NOT NULL,
    admin_id INT NOT NULL,
    FOREIGN KEY (homeowner_id) REFERENCES dbo.Users(user_id),
    FOREIGN KEY (admin_id) REFERENCES dbo.Users(user_id)
);



-- Select from Users
SELECT * FROM Users;



-- Drop foreign key constraints referencing Bookings
IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    ALTER TABLE dbo.Feedback DROP CONSTRAINT FK_Feedback_Bookings;

IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL
    ALTER TABLE dbo.Payments DROP CONSTRAINT FK_Payments_Bookings;

-- Drop the Bookings table
IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL DROP TABLE dbo.Bookings;

-- Add foreign key constraints referencing Services
ALTER TABLE dbo.Feedback ADD CONSTRAINT FK_Feedback_Services FOREIGN KEY (service_id) REFERENCES dbo.Services(service_id);

ALTER TABLE dbo.Payments ADD CONSTRAINT FK_Payments_Services FOREIGN KEY (service_id) REFERENCES dbo.Services(service_id);

-- Select from Users using Services instead of Bookings
SELECT * from Services


-- Use the database
USE master;
GO

-- Drop the database if it exists
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'df')
    DROP DATABASE df;
GO

-- Create the database
CREATE DATABASE df;
GO

-- Use the database
USE df;
GO

-- Drop foreign key constraints
IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL
    ALTER TABLE dbo.Bookings DROP CONSTRAINT FK_Bookings_Users;

IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL
    ALTER TABLE dbo.Bookings DROP CONSTRAINT FK_Bookings_Services;

IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL
    ALTER TABLE dbo.Bookings DROP CONSTRAINT FK_Bookings_Providers;

IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL
    ALTER TABLE dbo.Payments DROP CONSTRAINT FK_Payments_Users;

IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL
    ALTER TABLE dbo.Payments DROP CONSTRAINT FK_Payments_Bookings;

IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    ALTER TABLE dbo.Feedback DROP CONSTRAINT FK_Feedback_Users;

IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    ALTER TABLE dbo.Feedback DROP CONSTRAINT FK_Feedback_Providers;

IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    ALTER TABLE dbo.Feedback DROP CONSTRAINT FK_Feedback_Bookings;

IF OBJECT_ID('dbo.Notifications', 'U') IS NOT NULL
    ALTER TABLE dbo.Notifications DROP CONSTRAINT FK_Notifications_Users;

IF OBJECT_ID('dbo.PollOptions', 'U') IS NOT NULL
    ALTER TABLE dbo.PollOptions DROP CONSTRAINT FK_PollOptions_Polls;

IF OBJECT_ID('dbo.PollResponses', 'U') IS NOT NULL
    ALTER TABLE dbo.PollResponses DROP CONSTRAINT FK_PollResponses_Users;

IF OBJECT_ID('dbo.PollResponses', 'U') IS NOT NULL
    ALTER TABLE dbo.PollResponses DROP CONSTRAINT FK_PollResponses_Polls;

IF OBJECT_ID('dbo.PollResponses', 'U') IS NOT NULL
    ALTER TABLE dbo.PollResponses DROP CONSTRAINT FK_PollResponses_PollOptions;
GO

-- Drop tables if they exist (optional)
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
IF OBJECT_ID('dbo.Services', 'U') IS NOT NULL DROP TABLE dbo.Services;
IF OBJECT_ID('dbo.Providers', 'U') IS NOT NULL DROP TABLE dbo.Providers;
IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL DROP TABLE dbo.Bookings;
IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL DROP TABLE dbo.Payments;
IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL DROP TABLE dbo.Feedback;
IF OBJECT_ID('dbo.Notifications', 'U') IS NOT NULL DROP TABLE dbo.Notifications;
IF OBJECT_ID('dbo.Calendar', 'U') IS NOT NULL DROP TABLE dbo.Calendar;
IF OBJECT_ID('dbo.Polls', 'U') IS NOT NULL DROP TABLE dbo.Polls;
IF OBJECT_ID('dbo.PollOptions', 'U') IS NOT NULL DROP TABLE dbo.PollOptions;
IF OBJECT_ID('dbo.PollResponses', 'U') IS NOT NULL DROP TABLE dbo.PollResponses;
GO

-- Create the Users table
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    user_type VARCHAR(10) NOT NULL CHECK (user_type IN ('homeowner', 'admin'))
);

-- Create the Services table
CREATE TABLE Services (
    service_id INT IDENTITY(1,1) PRIMARY KEY,
    service_name VARCHAR(100) NOT NULL,
    service_description VARCHAR(MAX),
    service_cost DECIMAL(10, 2) NOT NULL
);

-- Create the Providers table
CREATE TABLE Providers (
    provider_id INT IDENTITY(1,1) PRIMARY KEY,
    provider_name VARCHAR(100) NOT NULL,
    provider_contact VARCHAR(20),
    provider_address VARCHAR(200)
);

-- Create the Bookings table
CREATE TABLE Bookings (
    booking_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    service_id INT NOT NULL,
    provider_id INT NOT NULL,
    booking_date DATE NOT NULL,
    booking_status VARCHAR(10) NOT NULL DEFAULT 'pending' CHECK (booking_status IN ('pending', 'confirmed', 'completed', 'canceled'))
);

-- Add foreign key constraints
ALTER TABLE dbo.Bookings ADD CONSTRAINT FK_Bookings_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);
ALTER TABLE dbo.Bookings ADD CONSTRAINT FK_Bookings_Services FOREIGN KEY (service_id) REFERENCES dbo.Services(service_id);
ALTER TABLE dbo.Bookings ADD CONSTRAINT FK_Bookings_Providers FOREIGN KEY (provider_id) REFERENCES dbo.Providers(provider_id);

-- Create the Payments table
CREATE TABLE Payments (
    payment_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    booking_id INT NOT NULL,
    payment_amount DECIMAL(10, 2) NOT NULL,
    payment_date DATE NOT NULL DEFAULT GETDATE()
);

-- Add foreign key constraints
ALTER TABLE dbo.Payments ADD CONSTRAINT FK_Payments_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);
ALTER TABLE dbo.Payments ADD CONSTRAINT FK_Payments_Bookings FOREIGN KEY (booking_id) REFERENCES dbo.Bookings(booking_id);

-- Create the Feedback table
CREATE TABLE Feedback (
    feedback_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    provider_id INT NOT NULL,
    booking_id INT NOT NULL,
    feedback_text VARCHAR(MAX),
    feedback_rating INT CHECK (feedback_rating >= 1 AND feedback_rating <= 5)
);

-- Add foreign key constraints
ALTER TABLE dbo.Feedback ADD CONSTRAINT FK_Feedback_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);
ALTER TABLE dbo.Feedback ADD CONSTRAINT FK_Feedback_Providers FOREIGN KEY (provider_id) REFERENCES dbo.Providers(provider_id);
ALTER TABLE dbo.Feedback ADD CONSTRAINT FK_Feedback_Bookings FOREIGN KEY (booking_id) REFERENCES dbo.Bookings(booking_id);

-- Create the Notifications table
CREATE TABLE Notifications (
    notification_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    notification_text VARCHAR(MAX) NOT NULL,
    notification_date DATETIME NOT NULL DEFAULT GETDATE()
);

-- Add foreign key constraints
ALTER TABLE dbo.Notifications ADD CONSTRAINT FK_Notifications_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);

-- Create the Calendar table
CREATE TABLE Calendar (
    event_id INT IDENTITY(1,1) PRIMARY KEY,
    event_title VARCHAR(100) NOT NULL,
    event_description VARCHAR(MAX),
    event_date DATE NOT NULL
);

-- Create the Polls table
CREATE TABLE Polls (
    poll_id INT IDENTITY(1,1) PRIMARY KEY,
    poll_question VARCHAR(MAX) NOT NULL,
    poll_start_date DATE NOT NULL,
    poll_end_date DATE NOT NULL
);

-- Create the PollOptions table
CREATE TABLE PollOptions (
    option_id INT IDENTITY(1,1) PRIMARY KEY,
    poll_id INT NOT NULL,
    option_text VARCHAR(200) NOT NULL
);

-- Add foreign key constraints
ALTER TABLE dbo.PollOptions ADD CONSTRAINT FK_PollOptions_Polls FOREIGN KEY (poll_id) REFERENCES dbo.Polls(poll_id);

-- Create the PollResponses table
CREATE TABLE PollResponses (
    response_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    poll_id INT NOT NULL,
    option_id INT NOT NULL
);

-- Add foreign key constraints
ALTER TABLE dbo.PollResponses ADD CONSTRAINT FK_PollResponses_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);
ALTER TABLE dbo.PollResponses ADD CONSTRAINT FK_PollResponses_Polls FOREIGN KEY (poll_id) REFERENCES dbo.Polls(poll_id);
ALTER TABLE dbo.PollResponses ADD CONSTRAINT FK_PollResponses_PollOptions FOREIGN KEY (option_id) REFERENCES dbo.PollOptions(option_id);
GO


-- Create the Bills table
-- Drop the existing Bills table if it exists
IF OBJECT_ID('dbo.Bills', 'U') IS NOT NULL
    DROP TABLE dbo.Bills;

-- Create the Bills table with predefined bill types
CREATE TABLE Bills (
    bill_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    issue_date DATE NOT NULL,
    due_date DATE NOT NULL,
    payment_status VARCHAR(20) NOT NULL DEFAULT 'unpaid' CHECK (payment_status IN ('unpaid', 'paid')),
    bill_type VARCHAR(50) NOT NULL CHECK (bill_type IN ('electricity', 'internet', 'gas')),
    FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id)
);










-- Create the Visitors table
CREATE TABLE Visitors (
    visitor_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    homeowner_id INT NOT NULL,
    FOREIGN KEY (homeowner_id) REFERENCES dbo.Users(user_id)
);

-- Create the Workers table
CREATE TABLE Workers (
    worker_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    homeowner_id INT NOT NULL,
    admin_id INT NOT NULL,
    FOREIGN KEY (homeowner_id) REFERENCES dbo.Users(user_id),
    FOREIGN KEY (admin_id) REFERENCES dbo.Users(user_id)
);



-- Select from Users
SELECT * FROM Users;



-- Drop foreign key constraints referencing Bookings
IF OBJECT_ID('dbo.Feedback', 'U') IS NOT NULL
    ALTER TABLE dbo.Feedback DROP CONSTRAINT FK_Feedback_Bookings;

IF OBJECT_ID('dbo.Payments', 'U') IS NOT NULL
    ALTER TABLE dbo.Payments DROP CONSTRAINT FK_Payments_Bookings;

-- Drop the Bookings table
IF OBJECT_ID('dbo.Bookings', 'U') IS NOT NULL DROP TABLE dbo.Bookings;

-- Add foreign key constraints referencing Services
ALTER TABLE dbo.Feedback ADD CONSTRAINT FK_Feedback_Services FOREIGN KEY (service_id) REFERENCES dbo.Services(service_id);

ALTER TABLE dbo.Payments ADD CONSTRAINT FK_Payments_Services FOREIGN KEY (service_id) REFERENCES dbo.Services(service_id);

-- Select from Users using Services instead of Bookings
SELECT * from Services


-- Create the Suggestions table without date column
CREATE TABLE Suggestions (
    suggestion_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    suggestion_text VARCHAR(MAX) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id)
);

select * from users
insert into Users values('Youser', 'Passw','E@Email.com','homeowner');


-- Create the Advertisements table
CREATE TABLE Advertisements (
    advertisement_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    advertisement_text VARCHAR(MAX) NOT NULL,
    advertisement_date DATETIME NOT NULL DEFAULT GETDATE()
);

-- Add foreign key constraints
ALTER TABLE dbo.Advertisements ADD CONSTRAINT FK_Advertisements_Users FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id);


select * from Advertisements