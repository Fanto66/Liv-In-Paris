CREATE DATABASE IF NOT EXISTS liv_in_paris;
USE liv_in_paris;

CREATE TABLE IF NOT EXISTS Utilisateurs (
nom_utilisateur VARCHAR(50) PRIMARY KEY NOT NULL,
mot_de_passe VARCHAR(255) NOT NULL,
nom VARCHAR(50),
prenom VARCHAR(50),
rue VARCHAR(50),
numero INT,
code_postal INT,
ville VARCHAR(50),
latitude DECIMAL(10,8),
longitude DECIMAL(11,8),
telephone VARCHAR(50),
email VARCHAR(50) NOT NULL,
metro_plus_proche VARCHAR(50),
pdp_url TEXT
);

CREATE TABLE IF NOT EXISTS Clients (
nom_utilisateur_client VARCHAR(50) PRIMARY KEY,
nom_utilisateur VARCHAR(50),
FOREIGN KEY (nom_utilisateur) REFERENCES Utilisateurs(nom_utilisateur) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Cuisiniers (
nom_utilisateur_cuisinier VARCHAR(50) PRIMARY KEY,
nom_utilisateur VARCHAR(50),
FOREIGN KEY (nom_utilisateur) REFERENCES Utilisateurs(nom_utilisateur) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Livraisons (
id_livraison INT PRIMARY KEY NOT NULL,
date_livraison DATETIME NOT NULL,
terminee BOOLEAN,
retard BOOLEAN,
station_metro: VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS Transactions (
id_transaction INT PRIMARY KEY NOT NULL,
date_transaction DATETIME NOT NULL,
note_client INT CHECK (note_client BETWEEN 0 AND 5),
nom_utilisateur_client VARCHAR(50),
FOREIGN KEY (nom_utilisateur_client) REFERENCES Clients(nom_utilisateur_client)
);

CREATE TABLE IF NOT EXISTS Plats (
id_plat INT PRIMARY KEY NOT NULL,
nom VARCHAR(50) NOT NULL,
prix DECIMAL(10,2) NOT NULL,
quantite INT NOT NULL,
type_plat VARCHAR(50) NOT NULL,
date_fabrication DATETIME NOT NULL,
date_peremption DATETIME NOT NULL,
CHECK(date_peremption > date_fabrication),
regime VARCHAR(50) NOT NULL,
nationalite VARCHAR(50) NOT NULL,
photo_url VARCHAR(255),
disponible BOOLEAN,
plat_du_jour BOOLEAN,
nom_utilisateur_cuisinier VARCHAR(50),
FOREIGN KEY(nom_utilisateur_cuisinier) REFERENCES Cuisiniers(nom_utilisateur_cuisinier),
id_transaction INT,
FOREIGN KEY (id_transaction) REFERENCES Transactions(id_transaction),
id_livraison INT,
FOREIGN KEY (id_livraison) REFERENCES Livraisons(id_livraison),
nom_utilisteur_client_avis VARCHAR(50),
FOREIGN KEY (nom_utilisateur_client_avis) REFERENCES Clients(nom_utilisateur_client)
titre_avis VARCHAR(50),
note_avis INT CHECK (note_avis BETWEEN 0 AND 5),
description_avis TEXT
);

CREATE TABLE IF NOT EXISTS Ingredients (
id_ingredient INT PRIMARY KEY NOT NULL,
libelle VARCHAR(50) NOT NULL
);

CREATE TABLE IF NOT EXISTS Composition_Plats (
id_plat INT NOT NULL,
id_ingredient INT NOT NULL,
quantite INT NOT NULL,
PRIMARY KEY(id_plat, id_ingredient),
FOREIGN KEY(id_plat) REFERENCES Plats(id_plat),
FOREIGN KEY(id_ingredient) REFERENCES Ingredients(id_ingredient) 
);

CREATE TABLE IF NOT EXISTS Transac_Engendre_Livraison (
id_transaction INT NOT NULL,
id_livraison INT NOT NULL,
PRIMARY KEY (id_transaction, id_plat),
FOREIGN KEY (id_transaction) REFERENCES Transactions(id_transaction),
FOREIGN KEY (id_livraison) REFERENCES Livraisons(id_livraison)
);


-- Requetes d'insertion

--Clients
INSERT INTO Utilisateurs (nom_utilisateur, mot_de_passe, nom, prenom, rue, numero, code_postal, ville, telephone, email, metro_plus_proche)
VALUES ("durand_mehdy17", "akJF&@-a98", "Durand", "Mehdi", "Rue Cardinet", 15, 75017, "Paris", "1234567890", "Mdurand@gmail.com", "Cardinet");
INSERT INTO Clients(nom_utilisateur_client, nom_utilisateur)
VALUES ("durant_mehdy17", "durant_mehdy17");

INSERT INTO Utilisateurs (nom_utilisateur, mot_de_passe, nom, prenom, rue, numero, code_postal, ville, telephone, email, metro_plus_proche)
VALUES ("leclerc_marine89", "p@ssW0rd#12", "Leclerc", "Marine", "Avenue de la République", 42, 75011, "Paris", "0678123456", "marine.leclerc@gmail.com", "Republique");
INSERT INTO Clients(nom_utilisateur_client, nom_utilisateur)
VALUES ("leclerc_marine89", "leclerc_marine89");

INSERT INTO Utilisateurs (nom_utilisateur, mot_de_passe, nom, prenom, rue, numero, code_postal, ville, telephone, email, metro_plus_proche)
VALUES ("dupont_sophie76", "Qwerty123!", "Dupont", "Sophie", "Rue de Rennes", 23, 75006, "Paris", "0612345678", "sophie.dupont@outlook.com", "Saint-Sulpice");
INSERT INTO Clients(nom_utilisateur_client, nom_utilisateur)
VALUES ("dupont_sophie76", "dupont_sophie76");

INSERT INTO Utilisateurs (nom_utilisateur, mot_de_passe, nom, prenom, rue, numero, code_postal, ville, telephone, email, metro_plus_proche)
VALUES ("martin_thomas30", "Pass*1234", "Martin", "Thomas", "Rue Lafayette", 78, 75009, "Paris", "0789456123", "thomas.martin@hotmail.fr", "Cadet");
INSERT INTO Clients(nom_utilisateur_client, nom_utilisateur)
VALUES ("martin_thomas30", "martin_thomas30");

--Cuisiniers
INSERT INTO Utilisateurs (nom_utilisateur, mot_de_passe, nom, prenom, rue, numero, code_postal, ville, telephone, email, metro_plus_proche)
VALUES ("marie.dupond", "aslkgjaop", "Dupond", "Marie", "Rue de la Republique", 30, 75011, "Paris", "1234567890", "Mdupond@gmail.com", "Republique");
INSERT INTO Cuisiniers(nom_utilisateur_cuisinier, nom_utilisateur)
VALUES ("marie.dupond", "marie.dupond");

INSERT INTO Utilisateurs (nom_utilisateur, mot_de_passe, nom, prenom, rue, numero, code_postal, ville, telephone, email, metro_plus_proche)  
VALUES ("jean.lemaitre", "pass1234!", "Lemaitre", "Jean", "Avenue des Champs-Elysees", 12, 75008, "Paris", "0612345678", "jean.lemaitre@gmail.com", "Franklin D. Roosevelt");  
INSERT INTO Cuisiniers(nom_utilisateur_cuisinier, nom_utilisateur)  
VALUES ("jean.lemaitre", "jean.lemaitre");

INSERT INTO Utilisateurs (nom_utilisateur, mot_de_passe, nom, prenom, rue, numero, code_postal, ville, telephone, email, metro_plus_proche)  
VALUES ("pablo.laxago", "motdepassechokbar", "Pablo", "Laxago", "Avenue Léonard de Vinci", 12, 92400, "Courbevoie", "0612344678", "pablo.laxago@gmail.com", "La Defense Grande Arche");  
INSERT INTO Cuisiniers(nom_utilisateur_cuisinier, nom_utilisateur)  
VALUES ("pablo.laxago", "pablo.laxago");

--Ingredients
INSERT INTO Ingredients
VALUES (1, "Tomate")
INSERT INTO Ingredients
VALUES (2, "Champignon");
INSERT INTO Ingredients
VALUES (3, "Fromage");
INSERT INTO Ingredients
VALUES (4, "Viande hachee");
INSERT INTO Ingredients
VALUES (5, "Oignons");
INSERT INTO Ingredients
VALUES (6, "Bechamel");
INSERT INTO Ingredients
VALUES (7, "Riz");
INSERT INTO Ingredients
VALUES (8, "Poivron rouge");
INSERT INTO Ingredients
VALUES (9, "Poivron vert");
INSERT INTO Ingredients
VALUES (10, "Ail");
INSERT INTO Ingredients
VALUES (11, "Gambas");
INSERT INTO Ingredients
VALUES (12, "Poulet");

--Plats
INSERT INTO Plats (id_plat, nom, prix, quantite, type_plat, date_fabrication, date_peremption, regime, nationalite, disponible, nom_utilisateur_cuisinier)
VALUES (1, "Pizza", 15.50, 4, "Plat congelé", "20250224", "20250315", "Omnivore", "Italienne", TRUE, "marie.dupond");
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (1, 1, 200);
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (1, 2, 50);
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (1, 3, 150);

INSERT INTO Plats (id_plat, nom, prix, quantite, type_plat, date_fabrication, date_peremption, regime, nationalite, disponible, nom_utilisateur_cuisinier, plat_du_jour)
VALUES (2, "Lasagnes", 14.00, 2, "Plat chaud", "20250226", "20250228", "Omnivore", "Italienne", TRUE, "jean.lemaitre", TRUE);
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (2, 1, 200);
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (2, 3, 75);
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (2, 4, 200);
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (2, 5, 25);
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (2, 6, 50);

INSERT INTO Plats (id_plat, nom, prix, quantite, type_plat, date_fabrication, date_peremption, regime, nationalite, disponible, nom_utilisateur_cuisinier)
VALUES (3, "Sauce Bolognaise", 8.99, 1, "Ingredient", "20250223", "20250320", "Omnivore", "Italienne", TRUE, "jean.lemaitre");
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 1, 75);
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 4, 175);

INSERT INTO Plats (id_plat, nom, prix, quantite, type_plat, date_fabrication, date_peremption, regime, nationalite, disponible, nom_utilisateur_cuisinier)
VALUES (4, "Paella", 28.75, 3, "Plat chaud", "20250227", "20250228", "Omnivore", "Espagnol", TRUE, "pablo.laxago")
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 7, 225); -- riz
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 8, 80); -- rouge
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 9, 80); -- vert
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 10, 10); -- ail
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 11, 300); -- gambas
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 1, 150); -- tomate
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 1, 50); -- oignon
INSERT INTO Composition_Plats (id_plat, id_ingredient, quantite)
VALUES (3, 12, 450); -- poulet

--Transactions & livraisons
--Commande de 1 Lasagne
INSERT INTO Transactions (id_transaction, date_transaction, nom_utilisateur_client)
VALUES (1, "20250226 7:14:07 PM", "durand_mehdy17");

UPDATE Plats SET (id_transaction = 1, disponible = FALSE) WHERE id_plat = 2;

INSERT INTO Livraisons (id_livraison, date_livraison, terminee, station_metro)
VALUES (1, "20250226 7:15:55", FALSE, "Cardinet");
INSERT INTO Engendre (id_transaction, id_livraison)
VALUES (1, 1);

UPDATE Plats SET id_livraison = 1 WHERE id_plat = 2;

--Commande de 1 Pizza et 1 Bolognaise à une autre adresse
INSERT INTO Transactions (id_transaction, date_transaction, nom_utilisateur_client)
VALUES (2, "20250227 5:38:43 PM", "leclerc_marine89");

UPDATE Plats SET (id_transaction = 2, disponible = FALSE) WHERE id_plat = 1;
UPDATE Plats SET (id_transaction = 2, disponible = FALSE) WHERE id_plat = 3;

INSERT INTO Livraisons (id_livraison, date_livraison, terminee, station_metro)
VALUES (2, "20250227 5:45:03 PM", FALSE, "Republique")
INSERT INTO Engendre (id_transaction, id_livraison)
VALUES (2, 2);

UPDATE Plats SET id_livraison = 2 WHERE id_plat = 1;

INSERT INTO Livraisons (id_livraison, date_livraison, terminee, station_metro)
VALUES (3, "20250227 5:48:15 PM", FALSE, "Franklin D. Roosevelt")
INSERT INTO Engendre (id_transaction, id_livraison)
VALUES (2, 3);

UPDATE Plats SET id_livraison = 3 WHERE id_plat = 3;

-- Requetes de select

--Selectionner les livraisons en retard
SELECT * FROM Livraisons WHERE retard = TRUE;

--Selectionner les plats encore disponible
SELECT * FROM Plats WHERE disponible = TRUE;

--Selectionner l'adresse d'un utilisateur en particulier
SELECT rue, numero, code_postal, ville
FROM Utilisateurs
WHERE nom_utilisateur = "martin_thomas30";

--Selectionner l'image du plat du jour d'un cuisinier
SELECT photo_url FROM Plats
WHERE plat_du_jour = TRUE AND nom_utilisateur_cuisinier = "jean.lemaitre";