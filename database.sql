CREATE DATABSE IF NOT EXISTS liv_in_paris;
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
cuisinier BOOLEAN,
client BOOLEAN,
metro_plus_proche VARCHAR(50),
id_plat_du_jour INT
);

CREATE TABLE IF NOT EXISTS Plats (
id_plat INT PRIMARY KEY NOT NULL,
nom_utilisateur_cuisinier VARCHAR(50),
FOREIGN KEY(nom_utilisateur_cuisinier) REFERENCES Utilisateurs(nom_utilisateur),
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
disponible BOOLEAN
);

ALTER TABLE Utilisateurs ADD (FOREIGN KEY(id_plat_du_jour) REFERENCES Plats(id_plat) ON DELETE SET NULL);

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

CREATE TABLE IF NOT EXISTS Livraisons (
id_livraison INT PRIMARY KEY NOT NULL,
date_livraison DATETIME NOT NULL,
terminee BOOLEAN,
retard BOOLEAN
);

CREATE TABLE IF NOT EXISTS Transactions (
id_transaction INT PRIMARY KEY NOT NULL,
nom_utilisateur_cuisinier VARCHAR(50) NOT NULL,
nom_utilisateur_client VARCHAR(50) NOT NULL,
id_plat INT NOT NULL,
date_transaction DATETIME NOT NULL,
note_client TINYINT CHECK (note_client BETWEEN 0 AND 5),
id_livraison INT,
FOREIGN KEY(nom_utilisateur_cuisinier) REFERENCES Utilisateurs(nom_utilisateur),
FOREIGN KEY(nom_utilisateur_client) REFERENCES Utilisateurs(nom_utilisateur),
FOREIGN KEY(id_plat) REFERENCES Plats(id_plat),
FOREIGN KEY(id_livraison) REFERENCES Livraisons(id_livraison)
);

