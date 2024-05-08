Drop database if  exists bdOcasion ;
CREATE database if not exists bdOccasion;
use  bdOccasion;

drop table if  exists concessionnaire;

CREATE TABLE if not exists Concessionnaire (
	idConces INT(2) auto_increment primary key ,
    nom VARCHAR(15),
    prenom VARCHAR(15),
    adresse VARCHAR(50),
    codePostal VARCHAR(5),
    ville VARCHAR(20)
);

CREATE TABLE IF NOT EXISTS Connexion (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nomUtilisateur VARCHAR(50) NOT NULL,
    mdp VARCHAR(100) NOT NULL
); 

INSERT INTO Concessionnaire (nom,prenom,adresse,codePostal,ville) VALUES
('Davolio', 'Jeanne', '5 rue de la poste', '63000', 'CLERMONT-FERRAND'),
('Fuller', 'Philippe', '254 avenue Berthelot', '63000', 'CLERMONT-FERRAND'),
('Daverling', 'Laura', '1 place de Jaude', '63000', 'CLERMONT-FERRAND'),
('Peacock', 'Emilie', '23, Impasse des Fleurs', '63000', 'CLERMONT-FERRAND'),
('Buchanan', 'Pierre', '32 place de l''Hôtel de Ville', '63200', 'RIOM'),
('Bucyama', 'Michel', '15 rue des pinsons', '63200', 'RIOM'),
('King', 'Louis', '57 rue de la gare', '63500', 'ISSOIRE'),
('Callahan', 'Jean', '23 boulevard Central', '63500', 'ISSOIRE'),
('Bucsworth', 'Pierre', '7 rue de la paix', '63500', 'ISSOIRE');


INSERT INTO Connexion (nomUtilisateur, mdp) VALUES ('admin', 'admin');

select * from connexion;
select * from Concessionnaire;