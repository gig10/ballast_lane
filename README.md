# Ballast Lane Technical Interview

This is a test application for Ballast Lane, details on the test can be found on the following [PDF File](https://github.com/gig10/ballast_lane/blob/main/Ballast%20Lane%20-%20Technical%20Interview%20Exercise%20V2.pdf). The application should follow certain rules and be based on a user story created by me on the next topic.

## Game Database

This is a basic application wich consists of platform where users can signup, create game entries and give their own reviews for the games. Users can also add existing games to their library and give rates for these games.

### Endpoints

1. **/auth** - This endpoint does not require authentication/authorization

   **/signup** - This is a **POST** request and required fields should be passed on body: email, password and a username to be displayed (this does is not required to be unique). Table must contain columns for hashed password as long as a salt for the hashing algorithm.

   | id     | email           | password     | salt         | username    |
   | ------ | --------------- | ------------ | ------------ | ----------- |
   | PK int | varchar(255)    | varchar(255) | varchar(255) | varchar(50) |
   |        | unique not null | not null     | not null     | not null    |

   **/login** - This is a **POST** request and expects as parameters email and password and returns an HTTP status code and an error message or jwt token.
