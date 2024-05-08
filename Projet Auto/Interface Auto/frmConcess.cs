using biblioAuto;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface_Auto
{
    public partial class frmConcess : Form
    {
        private MySqlConnection cnx;
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public frmConcess()
        {
            InitializeComponent();

            // Ajouter des éléments à la ComboBox pour le critère de recherche
            comboBox1.Items.Add("Ville");
            comboBox1.Items.Add("Nom");
            comboBox1.Items.Add("Code Postal");
            comboBox1.SelectedItem = "Ville";
            listView1.Items.Clear();

            // Initialiser la connexion à la base de données
            SeConnecter();
            cnx.Open();

            // Charger tous les concessionnaires au chargement du formulaire
            ChargerConcessionnaires();
            cnx.Close();
        }

        private void SeConnecter()
        {
            // Initialiser la connexion à la base de données avec la chaîne de connexion appropriée
            cnx = new MySqlConnection();
            cnx.ConnectionString = "SERVER=localhost;DATABASE=bdOccasion;UID=root;";
        }

        private void ChargerConcessionnaires()
        {
            // Effacer la ListView
            listView1.Items.Clear();

            // Charger tous les concessionnaires depuis la base de données
            List<Concessionnaire> lesConcessionnaires = Concessionnaire.ChargerTout(cnx);

            // Afficher les concessionnaires dans la ListView
            foreach (var concessionnaire in lesConcessionnaires)
            {
                ListViewItem item = new ListViewItem(concessionnaire.Id.ToString());
                item.SubItems.AddRange(new string[] { concessionnaire.Nom, concessionnaire.Prenom, concessionnaire.Adresse, concessionnaire.CodePostal, concessionnaire.Ville });
                listView1.Items.Add(item);
            }
        }

        // Gestionnaire d'événement pour le bouton "Rechercher"
        private void btnEnvoyer_Click_1(object sender, EventArgs e)
        {
            string critere = comboBox1.SelectedItem.ToString();
            string valeur = textBox1.Text.Trim();

            // Utilisez la méthode de la classe Concessionnaire pour effectuer la recherche
            List<Concessionnaire> resultatRecherche = Concessionnaire.Rechercher(cnx, critere, valeur);

            // Effacez la ListView
            listView1.Items.Clear();

            // Ajoutez les éléments à la ListView ici
            foreach (var concessionnaire in resultatRecherche)
            {
                ListViewItem item = new ListViewItem(concessionnaire.Id.ToString());
                item.SubItems.AddRange(new string[] { concessionnaire.Nom, concessionnaire.Prenom, concessionnaire.Adresse, concessionnaire.CodePostal, concessionnaire.Ville });
                listView1.Items.Add(item);
            }
        }

        private void btnSuppr_Click_1(object sender, EventArgs e)
        {
            // Vérifier si l'ID est spécifié
            if (!string.IsNullOrEmpty(textBoxID.Text))
            {
                int idConces;

                // Essayer de convertir l'ID en entier
                if (int.TryParse(textBoxID.Text, out idConces))
                {
                    // Afficher une boîte de dialogue de confirmation
                    DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce concessionnaire ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Vérifier si l'utilisateur a cliqué sur le bouton "Oui" dans la boîte de dialogue
                    if (result == DialogResult.Yes)
                    {
                        // Créer une commande SQL pour supprimer le concessionnaire avec l'ID spécifié
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM Concessionnaire WHERE idConces = @idConces", cnx);
                        cmd.Parameters.AddWithValue("@idConces", idConces);

                        try
                        {
                            cnx.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Afficher un message de succès si la suppression a réussi
                                MessageBox.Show("Concessionnaire supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBoxID.Clear();

                                // Mettre à jour la ListView après la suppression
                                ChargerConcessionnaires();
                            }
                            else
                            {
                                MessageBox.Show("Aucun concessionnaire trouvé avec cet ID.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Une erreur est survenue lors de la suppression du concessionnaire : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            cnx.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("L'ID doit être un nombre entier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir l'ID du concessionnaire à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gestionnaire d'événement pour le bouton "Ajouter"
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Vérifier si les champs obligatoires sont remplis
            if (string.IsNullOrWhiteSpace(textBoxNom.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrenom.Text) ||
                string.IsNullOrWhiteSpace(textBoxAdresse.Text) ||
                string.IsNullOrWhiteSpace(textBoxVille.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Arrêtez l'exécution si un champ obligatoire est vide
            }

            // Vérifier si le code postal est numérique et a une longueur de 5 caractères
            if (!IsNumeric(textBoxCP.Text) || textBoxCP.Text.Length != 5)
            {
                MessageBox.Show("Le code postal doit être un nombre de 5 chiffres !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Arrêtez l'exécution si le code postal n'est pas valide
            }

            try
            {
                // Construire la requête SQL pour ajouter un concessionnaire
                string query = "INSERT INTO Concessionnaire (nom, prenom, adresse, codePostal, ville) VALUES (@nom, @prenom, @adresse, @codePostal, @ville)";
                MySqlCommand command = new MySqlCommand(query, cnx);

                // Paramètres pour la requête SQL
                command.Parameters.AddWithValue("@nom", textBoxNom.Text);
                command.Parameters.AddWithValue("@prenom", textBoxPrenom.Text);
                command.Parameters.AddWithValue("@adresse", textBoxAdresse.Text);
                command.Parameters.AddWithValue("@codePostal", textBoxCP.Text);
                command.Parameters.AddWithValue("@ville", textBoxVille.Text);

                // Ouvrir la connexion et exécuter la commande
                cnx.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Concessionnaire ajouté avec succès !","Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxCP.Clear();
                textBoxNom.Clear();
                textBoxAdresse.Clear();
                textBoxVille.Clear();
                textBoxPrenom.Clear();

                // Mettre à jour la ListView après l'ajout
                ChargerConcessionnaires();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }

        // Méthode pour vérifier si une chaîne est numérique
        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            // Vérifier si l'ID de concessionnaire à modifier est spécifié
            if (!string.IsNullOrEmpty(txtIdModif.Text))
            {
                int idConces;

                // Essayer de convertir l'ID en entier
                if (int.TryParse(txtIdModif.Text, out idConces))
                {
                    // Obtenir le critère de modification sélectionné dans la ComboBox
                    string critere = comboBoxModif.SelectedItem?.ToString();

                    // Obtenir la nouvelle valeur à appliquer
                    string nouvelleValeur = txtBoxModif.Text;
                    if (critere == "Code Postal")
                    {
                        if (!IsNumeric(nouvelleValeur) || nouvelleValeur.Length != 5)
                        {
                            MessageBox.Show("Le code postal doit être un nombre de 5 chiffres !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Arrêtez l'exécution si le code postal n'est pas valide
                        }
                    }
                    // Vérifier si le critère et la nouvelle valeur sont spécifiés
                    if (!string.IsNullOrEmpty(critere) && !string.IsNullOrEmpty(nouvelleValeur))
                    {
                        // Ouvrir la connexion à la base de données
                        cnx.Open();

                        // Créer une commande SQL pour mettre à jour le concessionnaire en fonction de l'ID, du critère et de la nouvelle valeur
                        string query = "";

                        switch (critere)
                        {
                            case "Ville":
                                query = "UPDATE Concessionnaire SET ville = @nouvelleValeur WHERE idConces = @idConces";
                                break;
                            case "Nom":
                                query = "UPDATE Concessionnaire SET nom = @nouvelleValeur WHERE idConces = @idConces";
                                break;
                            case "Code Postal":
                                query = "UPDATE Concessionnaire SET codePostal = @nouvelleValeur WHERE idConces = @idConces";
                                break;
                            case "Prénom":
                                query = "UPDATE Concessionnaire SET prenom = @nouvelleValeur WHERE idConces = @idConces";
                                break;
                            case "Adresse":
                                query = "UPDATE Concessionnaire SET adresse = @nouvelleValeur WHERE idConces = @idConces";
                                break;
                            default:
                                MessageBox.Show("Critère invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                        }

                        // Configurer la commande SQL
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = cnx;
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@nouvelleValeur", nouvelleValeur);
                        cmd.Parameters.AddWithValue("@idConces", idConces);

                        try
                        {
                            // Exécuter la commande SQL et obtenir le nombre de lignes affectées
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Afficher un message de succès si la modification a réussi
                                MessageBox.Show("Concessionnaire modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Mettre à jour la ListView après la modification
                                ChargerConcessionnaires();

                                // Effacer les zones de texte pour l'ID et la nouvelle valeur
                                txtBoxModif.Clear();
                                txtIdModif.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Aucun concessionnaire trouvé avec cet ID.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Une erreur est survenue lors de la modification du concessionnaire : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            // Fermer la connexion à la base de données
                            cnx.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez sélectionner un critère et saisir une nouvelle valeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("L'ID doit être un nombre entier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir l'ID du concessionnaire à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxPluss_Click(object sender, EventArgs e)
        {
            groupBoxAdd.Visible = true;
            groupBoxModif.Visible = false;
            groupBoxSuppr.Visible = false;

        }

        private void pictureBoxMoinss_Click(object sender, EventArgs e)
        {
            groupBoxAdd.Visible = false;
            groupBoxModif.Visible = false;
            groupBoxSuppr.Visible = true;
        }

        private void pictureBoxModif_Click(object sender, EventArgs e)
        {
            groupBoxAdd.Visible = false;
            groupBoxModif.Visible = true;
            groupBoxSuppr.Visible = false;
        }

        private void frmConcess_Load(object sender, EventArgs e)
        {

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Vérifier si l'utilisateur a cliqué sur le bouton "Oui" dans la boîte de dialogue
            if (result == DialogResult.Yes)
            {
                // Si l'utilisateur a confirmé, fermez l'application
                Application.Exit();
            }

        }

        private void groupBoxAdd_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin formulaireLogin = new frmLogin();
            formulaireLogin.ShowDialog();


        }

        private void labelReturn_MouseEnter_1(object sender, EventArgs e)
        {
            labelReturn.ForeColor = Color.Red; // Par exemple, changer la couleur du texte en rouge
            labelReturn.Font = new Font(labelReturn.Font, FontStyle.Bold);

        }

        private void labelReturn_MouseLeave_1(object sender, EventArgs e)
        {
            labelReturn.ForeColor = Color.White; // Rétablir la couleur du texte par défaut
            labelReturn.Font = new Font(labelReturn.Font, FontStyle.Regular);
        }
    }
}
    
