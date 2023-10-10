# Ballast Lane Technical Interview

This is a test application for Ballast Lane, details on the test can be found on the following [PDF File](https://github.com/gig10/ballast_lane/blob/main/Ballast%20Lane%20-%20Technical%20Interview%20Exercise%20V2.pdf). The application should follow certain rules and be based on a user story created by me on the next topic.

## Game Database

This is a basic application wich consists of platform where users can signup, create game entries and give their own reviews for the games. Users can also add existing games to their library and give rates for these games.

## Endpoints

#### /auth</b> - Endpoint reponsible for user signup and signin

<details>
 <summary><code>POST</code> <code><b>/signup</b></code> <code>(creates a new user account)</code></summary>

##### Responses

> | http code | content-type       | response                                 |
> | --------- | ------------------ | ---------------------------------------- |
> | `204`     | `application/json` | no content                               |
> | `400`     | `application/json` | `{"code":"400","message":"Bad Request"}` |

</details>
<details>
 <summary><code>POST</code> <code><b>/signin</b></code> <code>(Authorization endpoint)</code></summary>
##### Body Payload json

> | name     | type     | data type     | description               |
> | -------- | -------- | ------------- | ------------------------- |
> | email    | required | string (100)  | email to be used as login |
> | password | required | string (8-30) | user password             |

##### Responses

> | http code | content-type       | response                                 |
> | --------- | ------------------ | ---------------------------------------- |
> | `200`     | `application/json` | jwt token                                |
> | `400`     | `application/json` | `{"code":"400","message":"Bad Request"}` |

</details>

---

#### /games</b> - Endpoint reponsible for games management

<details>
 <summary><code>GET</code> <code><b>/</b></code> <code>(request that list the last 30 games. )</code></summary>

##### Body Payload json

> | name     | type     | data type     | description               |
> | -------- | -------- | ------------- | ------------------------- |
> | email    | required | string (100)  | email to be used as login |
> | password | required | string (8-30) | user password             |

##### Responses

> | http code | content-type       | response                                 |
> | --------- | ------------------ | ---------------------------------------- |
> | `200`     | `application/json` | jwt token                                |
> | `400`     | `application/json` | `{"code":"400","message":"Bad Request"}` |

</details>

<details>
 <summary><code>POST</code> <code><b>/</b></code> <code>(Creates a new Game)</code></summary>

##### Body Payload json

> | name     | type     | data type     | description               |
> | -------- | -------- | ------------- | ------------------------- |
> | email    | required | string (100)  | email to be used as login |
> | password | required | string (8-30) | user password             |

##### Responses

> | http code | content-type       | response                                 |
> | --------- | ------------------ | ---------------------------------------- |
> | `200`     | `application/json` | jwt token                                |
> | `400`     | `application/json` | `{"code":"400","message":"Bad Request"}` |

</details>

<details>
 <summary><code>GET</code> <code><b>/{id}</b></code> <code>(Get a game by its id)</code></summary>

##### Body Payload json

> | name     | type     | data type     | description               |
> | -------- | -------- | ------------- | ------------------------- |
> | email    | required | string (100)  | email to be used as login |
> | password | required | string (8-30) | user password             |

##### Responses

> | http code | content-type       | response                                 |
> | --------- | ------------------ | ---------------------------------------- |
> | `200`     | `application/json` | jwt token                                |
> | `400`     | `application/json` | `{"code":"400","message":"Bad Request"}` |

</details>

<details>
 <summary><code>DELETE</code> <code><b>/{id}</b></code> <code>(Delete a game by its id)</code></summary>

##### Body Payload json

> | name     | type     | data type     | description               |
> | -------- | -------- | ------------- | ------------------------- |
> | email    | required | string (100)  | email to be used as login |
> | password | required | string (8-30) | user password             |

##### Responses

> | http code | content-type       | response                                 |
> | --------- | ------------------ | ---------------------------------------- |
> | `200`     | `application/json` | jwt token                                |
> | `400`     | `application/json` | `{"code":"400","message":"Bad Request"}` |

</details>

---

#### /gamescollection</b> - Endpoint reponsible for games collection management

 <details>
 <summary><code>GET</code> <code><b>/{id}</b></code> <code></code></summary>

##### Body Payload json

> | name     | type     | data type     | description               |
> | -------- | -------- | ------------- | ------------------------- |
> | email    | required | string (100)  | email to be used as login |
> | password | required | string (8-30) | user password             |

##### Responses

> | http code | content-type       | response                                 |
> | --------- | ------------------ | ---------------------------------------- |
> | `200`     | `application/json` | jwt token                                |
> | `400`     | `application/json` | `{"code":"400","message":"Bad Request"}` |

</details>

---

## Database Tables

#### Users Table

| id     | email           | password_hash | username    |
| ------ | --------------- | ------------- | ----------- |
| PK int | varchar(100)    | varchar(100)  | varchar(30) |
|        | unique not null | not null      | not null    |

#### Games Table

| Id     | UserID       | Title        | Description | ImageUrl     |
| ------ | ------------ | ------------ | ----------- | ------------ |
| PK int | int          | varchar(120) | Text        | varchar(255) |
|        | FK(Users.ID) | not null     | nullable    | not null     |
