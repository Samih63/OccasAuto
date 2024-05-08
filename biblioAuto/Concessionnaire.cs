using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioAuto
{
    public class Concessionnaire
    {
        private int id;
        private string nom;
        private string prenom;
        private string adresse;
        private string codePostal;
        private string ville;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string CodePostal { get => codePostal; set => codePostal = value; }
        public string Ville { get => ville; set => ville = value; }

        public Concessionnaire(int id, string nom, string prenom, string adresse, string codePostal, string ville)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
        }

        public static List<Concessionnaire> Rechercher(MySqlConnection cnx, string critere, string valeur)
        {
            // Créer une liste pour stocker les résultats
            List<Concessionnaire> result = new List<Concessionnaire>();

            try
            {
                // Ouvrir la connexion à la base de données
                cnx.Open();

                // Construire la requête SQL en fonction du critère de recherche
                string query = "SELECT * FROM Concessionnaire WHERE ";     //ne pas mettre * pour etre plus sur mais bon....c long 

                switch (critere.ToUpper())
                {
                    case "VILLE":
                        query += "Ville LIKE @valeur";
                        break;
                    case "NOM":
                        query += "Nom LIKE @valeur";
                        break;
                    case "CODE POSTAL":
                        query += "codePostal LIKE @valeur";
                        break;
                    default:
                        // Lever une exception en cas de critère invalide
                        throw new ArgumentException("Critère invalide.");
                }

                // Créer une commande SQL paramétrée
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@valeur", valeur + '%');

                // Exécuter la requête SQL et récupérer les résultats
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        // Lire les données de chaque ligne de résultat
                        int idConces = (int)rd["idConces"];
                        string nom = (string)rd["Nom"];
                        string prenom = (string)rd["Prenom"];
                        string adresse = (string)rd["adresse"];
                        string codePostal = (string)rd["codePostal"];
                        string ville = (string)rd["Ville"];

                        // Créer un objet Concessionnaire avec les données lues
                        Concessionnaire unConces = new Concessionnaire(idConces, nom, prenom, adresse, codePostal, ville);

                        // Ajouter l'objet à la liste des résultats
                        result.Add(unConces);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs : vous pouvez ajouter ici un code de gestion des erreurs, comme l'enregistrement des erreurs dans un journal.
                throw ex;
            }
            finally
            {
                // Fermer la connexion à la base de données dans tous les cas
                cnx.Close();
            }

            // Retourner la liste des résultats
            return result;
        }

        public static List<Concessionnaire> ChargerTout(MySqlConnection cnx)
        {
            // Créer une liste pour stocker les résultats
            List<Concessionnaire> result = new List<Concessionnaire>();

            try
            {
                // Construire la requête SQL pour charger tous les concessionnaires
                string query = "SELECT * FROM Concessionnaire";

                // Créer une commande SQL
                MySqlCommand cmd = new MySqlCommand(query, cnx);

                // Exécuter la requête SQL et récupérer les résultats
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        // Lire les données de chaque ligne de résultat
                        int idConces = (int)rd["idConces"];
                        string nom = (string)rd["Nom"];
                        string prenom = (string)rd["Prenom"];
                        string adresse = (string)rd["adresse"];
                        string codePostal = (string)rd["codePostal"];
                        string ville = (string)rd["Ville"];

                        // Créer un objet Concessionnaire avec les données lues
                        Concessionnaire unConces = new Concessionnaire(idConces, nom, prenom, adresse, codePostal, ville);

                        // Ajouter l'objet à la liste des résultats
                        result.Add(unConces);
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs : vous pouvez ajouter ici un code de gestion des erreurs, comme l'enregistrement des erreurs dans un journal.
                throw ex;
            }
            finally
            {
                // Fermer la connexion à la base de données dans tous les cas
                cnx.Close();
            }

            // Retourner la liste des résultats
            return result;
        }


    }


}
 