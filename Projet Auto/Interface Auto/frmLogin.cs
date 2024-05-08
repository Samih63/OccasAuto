using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_Auto
{
    public partial class frmLogin : Form
    {
        private MySqlConnection cnx;
        public frmLogin()
        {
            InitializeComponent();



        }
        private void SeConnecter()
        {
            // Initialiser la connexion à la base de données avec la chaîne de connexion appropriée
            cnx = new MySqlConnection();
            cnx.ConnectionString = "SERVER=localhost;DATABASE=bdOccasion;UID=root;";
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Vérifier si l'utilisateur a cliqué sur le bouton "Oui" dans la boîte de dialogue
            if (result == DialogResult.Yes)
            {
                // Si l'utilisateur a confirmé, fermez l'application
                this.Close();
            }

        }
         
        private void btnSeco_Click(object sender, EventArgs e)
        {
            string nomUtilisateur = textUtil.Text;
            string motDePasse = textMDP.Text;
            SeConnecter();
            cnx.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Connexion WHERE binary nomUtilisateur = @nomUtilisateur AND binary mdp = @motDePasse", cnx);  //requete permettant de savoir si l'user existe
            cmd.Parameters.AddWithValue("@nomUtilisateur", nomUtilisateur);
            cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cnx.Close();

            if (count > 0)
            {
                // Les informations d'identification sont correctes, autorisez l'accès à l'application.
                MessageBox.Show("Connexion réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Par exemple, ouvrez le formulaire principal ou effectuez d'autres actions nécessaires.
                this.Hide();

                // Créer et afficher le formulaire frmConcess
                frmConcess formulaireConcess = new frmConcess();
                formulaireConcess.ShowDialog();

                // Fermer l'application lorsque le formulaire frmConcess est fermé (si nécessaire)
               
            }
            else
            {
                // Afficher un message d'erreur
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCompte_MouseEnter(object sender, EventArgs e)
        {
            lblCompte.ForeColor = Color.White; // Par exemple, changer la couleur du texte en rouge
            lblCompte.Font = new Font(lblCompte.Font, FontStyle.Bold);
        }

        private void lblCompte_MouseLeave(object sender, EventArgs e)
        {
            lblCompte.ForeColor = Color.Wheat; // Rétablir la couleur du texte par défaut
            lblCompte.Font = new Font(lblCompte.Font, FontStyle.Regular);
        }

        private void lblCompte_Click(object sender, EventArgs e)
        {lblCnx.Text = "Inscription";
         lblCompte.Visible = false;
         btnSeco.Visible = false;
         btnInscrire.Visible=true;
         txtConfirm.Visible = true;
         labelConfirm.Visible = true;
         textMDP.Visible = false;
         textUtil.Visible = false;
         txtInscriU.Visible = true;
         txtIncriMdp.Visible = true;
         labelRetour.Visible = true;

        }

        private void btnInscrire_Click(object sender, EventArgs e)
        {
           
            
            // Vérifiez d'abord si tous les champs sont remplis
            if (string.IsNullOrEmpty(txtInscriU.Text) || string.IsNullOrEmpty(txtIncriMdp.Text) || string.IsNullOrEmpty(txtConfirm.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérification du mot de passe
            if (txtIncriMdp.Text.Length < 12)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 12 caractères.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérification de la correspondance du mot de passe et de la confirmation
            if (txtIncriMdp.Text != txtConfirm.Text)
            {
                MessageBox.Show("La confirmation du mot de passe ne correspond pas au mot de passe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nomUtilisateur = txtInscriU.Text;

            // Vérification si le nom d'utilisateur existe déjà dans la base de données
            SeConnecter();
            cnx.Open();

            MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Connexion WHERE BINARY  nomUtilisateur = @nomUtilisateur", cnx);
            checkCmd.Parameters.AddWithValue("@nomUtilisateur", nomUtilisateur);

            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Ce nom d'utilisateur existe déjà. Veuillez en choisir un autre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cnx.Close();
                return;
            }

            // Insertion du compte dans la base de données
            MySqlCommand insertCmd = new MySqlCommand("INSERT INTO Connexion (nomUtilisateur, mdp) VALUES (@nomUtilisateur, @motDePasse)", cnx);
            insertCmd.Parameters.AddWithValue("@nomUtilisateur", nomUtilisateur);
            insertCmd.Parameters.AddWithValue("@motDePasse", txtIncriMdp.Text);

            try
            {
                insertCmd.ExecuteNonQuery(); //detection de l'erreur
                MessageBox.Show("Inscription réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblCnx.Text = "Connexion";
                lblCompte.Visible = true;
                btnSeco.Visible = true;
                btnInscrire.Visible = true;
                txtConfirm.Visible = false;
                labelConfirm.Visible = false;
                textMDP.Visible = true;
                textUtil.Visible = true;
                txtInscriU.Visible = false;
                txtIncriMdp.Visible = false;
                btnInscrire.Visible = false;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'inscription : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);  //message d'erreur
            }
            finally
            {
                cnx.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void mdp()
        {
            if (textMDP.PasswordChar == '\0' && txtIncriMdp.PasswordChar == '\0' && txtConfirm.PasswordChar == '\0')
            {

                Oeil.Visible = true;
                oeilBarre.Visible = false;
                // Tous les champs sont actuellement affichés, masquez-les tous
                textMDP.PasswordChar = '•';
                txtIncriMdp.PasswordChar = '•';
                txtConfirm.PasswordChar = '•';
            }
            else
            {

                Oeil.Visible = false;
                oeilBarre.Visible = true;
                // Au moins un des champs est actuellement masqué, affichez-les tous
                textMDP.PasswordChar = '\0';
                txtIncriMdp.PasswordChar = '\0';
                txtConfirm.PasswordChar = '\0';
            }



        }

        private void Oeil_Click(object sender, EventArgs e)
        {
            mdp();

        }

        private void oeilBarre_Click(object sender, EventArgs e)
        {
            mdp();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelRetour_Click(object sender, EventArgs e)
        {
            lblCnx.Text = "Connexion";
            lblCompte.Visible = true;
            btnSeco.Visible = true;
            btnInscrire.Visible = true;
            txtConfirm.Visible = false;
            labelConfirm.Visible = false;
            textMDP.Visible = true;
            textUtil.Visible = true;
            txtInscriU.Visible = false;
            txtIncriMdp.Visible = false;
            btnInscrire.Visible = false;
            labelRetour.Visible = false;

        }

        private void labelRetour_MouseEnter(object sender, EventArgs e)
        {
            labelRetour.ForeColor = Color.White; // Par exemple, changer la couleur du texte en rouge
            labelRetour.Font = new Font(labelRetour.Font, FontStyle.Bold);

        }

        private void labelRetour_MouseLeave(object sender, EventArgs e)
        {
            labelRetour.ForeColor = Color.Wheat; // Rétablir la couleur du texte par défaut
            labelRetour.Font = new Font(labelRetour.Font, FontStyle.Regular);
        }
    }
}

    




