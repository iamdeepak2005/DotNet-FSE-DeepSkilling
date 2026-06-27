-- create database structure for the training task
-- author: deepa nair

-- users table
CREATE TABLE Users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    city VARCHAR(50),
    registration_date DATE NOT NULL
);

-- events table
CREATE TABLE Events (
    event_id INT PRIMARY KEY AUTO_INCREMENT,
    title VARCHAR(150) NOT NULL,
    category VARCHAR(50) NOT NULL,
    description TEXT,
    event_date DATE NOT NULL,
    seats_available INT DEFAULT 50
);

-- registrations table
CREATE TABLE Registrations (
    registration_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    event_id INT,
    booking_date DATE NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);

-- feedback table
CREATE TABLE Feedback (
    feedback_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    event_id INT,
    rating INT CHECK (rating BETWEEN 1 AND 5),
    comments TEXT,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (event_id) REFERENCES Events(event_id)
);

-- insert test rows
INSERT INTO Users (full_name, email, city, registration_date) VALUES
('Amit Sharma', 'amit@test.com', 'Mumbai', '2026-01-10'),
('Deepa Nair', 'deepa@test.com', 'Bangalore', '2026-02-15'),
('John Doe', 'john@test.com', 'Chennai', '2026-03-01');

INSERT INTO Events (title, category, description, event_date, seats_available) VALUES
('Summer Music Show', 'music', 'Musical festival event.', '2026-07-15', 100),
('Food Carnival', 'food', 'Food carnival event.', '2026-07-22', 0);

INSERT INTO Registrations (user_id, event_id, booking_date) VALUES
(1, 1, '2026-06-01'),
(2, 1, '2026-06-05'),
(2, 2, '2026-06-10');

INSERT INTO Feedback (user_id, event_id, rating, comments) VALUES
(1, 1, 5, 'Super fun!'),
(2, 1, 4, 'Enjoyed it.');

-- queries checking
-- 1. query by city
SELECT * FROM Users WHERE city = 'Mumbai';

-- 2. inner join mapping
SELECT r.registration_id, u.full_name, e.title
FROM Registrations r
INNER JOIN Users u ON r.user_id = u.user_id
INNER JOIN Events e ON r.event_id = e.event_id;

-- 3. group by and aggregates
SELECT e.title, AVG(f.rating) AS avg_rating, COUNT(f.feedback_id) AS total_feedback
FROM Feedback f
INNER JOIN Events e ON f.event_id = e.event_id
GROUP BY e.title
HAVING COUNT(f.feedback_id) > 0;