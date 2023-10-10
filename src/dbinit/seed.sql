USE GameDatabase;
go

INSERT INTO USERS (Email, [UserName], [Password_Hash])
			VALUES ('test@test.com', 'Test USer', '$2a$11$2pSiv.icM2E6t3muegohoup6U6eqDYdoHviYrew7/9qtbzCqG5DL6')

GO


INSERT INTO Games ([Title], [Description], [ImageUrl])
			VALUES ('Grand Theft Auto V', 'Grand Theft Auto V is a 2013 action-adventure game developed by Rockstar North and published by Rockstar Games. It is the seventh main entry in the Grand Theft Auto series, following 2008 Grand Theft Auto IV, and the fifteenth instalment overall. Set within the fictional state of San Andreas, based on Southern California, the single-player story follows three protagonists—retired bank robber Michael De Santa, street gangster Franklin Clinton, and drug dealer and gunrunner Trevor Philips—and their attempts to commit heists while under pressure from a corrupt government agency and powerful criminals. The open world design lets players freely roam San Andreas open countryside and the fictional city of Los Santos, based on Los Angeles.', 'https://media.rockstargames.com/rockstargames/img/global/news/upload/actual_1364906194.jpg');

GO

INSERT INTO Games ([Title], [Description], [ImageUrl])
			VALUES ('Grand Theft Auto V', 'Elden Ring is an action role-playing game, set in third-person perspective, with a focus on combat and exploration. It includes elements that are similar to those in other FromSoftware-developed games such as the Dark Souls series, Bloodborne, and Sekiro: Shadows Die Twice.', 'https://m.media-amazon.com/images/I/6110RSDn3PL.jpg');

GO