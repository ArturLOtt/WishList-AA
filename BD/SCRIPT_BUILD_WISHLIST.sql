CREATE DATABASE senai_wishlist_AA

USE senai_wishlist_AA

CREATE TABLE users(
	userId INT IDENTITY PRIMARY KEY,
	userEmail VARCHAR(255) NOT NULL UNIQUE,
	userSenha VARCHAR(255) NOT NULL
);


CREATE TABLE wish(
	wishId INT IDENTITY PRIMARY KEY,
	wishDescription VARCHAR(MAX),
	wishCreation DATETIME NOT NULL,
	wishOwnerId INT FOREIGN KEY REFERENCES users (userId)
);

