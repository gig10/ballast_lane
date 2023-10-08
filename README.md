# Ballast Lane Technical Interview

This is a test application for Ballast Lane, details on the test can be found on the following [PDF File](https://github.com/gig10/ballast_lane/blob/main/Ballast%20Lane%20-%20Technical%20Interview%20Exercise%20V2.pdf). The application should follow certain rules and be based on a user story created by me on the next topic.

## Game Database

This is a basic application wich consists of platform where users can signup, create game entries and give their own reviews for the games. Users can also add existing games to their library and give rates for these games.

1. **Signup** - An endpoint should be provided for user subscription, this endpoint does not require authentication, required fields are email, password and a username to be displayed (this does is not required to be unique)


|id| email| password | salt|username|
|--|------|----------|-----|--------|
|PK int| varchar(255)| varchar(255)| varchar(255)|varchar(50)|
||unique not null|not null|not null| not null