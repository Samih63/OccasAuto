namespace Interface_Auto
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelLog = new System.Windows.Forms.Label();
            this.lblCnx = new System.Windows.Forms.Label();
            this.textUtil = new System.Windows.Forms.TextBox();
            this.textMDP = new System.Windows.Forms.TextBox();
            this.btnSeco = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.lblCompte = new System.Windows.Forms.Label();
            this.btnInscrire = new System.Windows.Forms.Button();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.txtIncriMdp = new System.Windows.Forms.TextBox();
            this.txtInscriU = new System.Windows.Forms.TextBox();
            this.Oeil = new System.Windows.Forms.PictureBox();
            this.oeilBarre = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelRetour = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Oeil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oeilBarre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.BackColor = System.Drawing.Color.Transparent;
            this.labelLog.Font = new System.Drawing.Font("Pristina", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLog.ForeColor = System.Drawing.Color.Wheat;
            this.labelLog.Location = new System.Drawing.Point(223, 130);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(178, 128);
            this.labelLog.TabIndex = 0;
            this.labelLog.Text = "Nom d\'utilisateur :\r\n\r\n\r\n     Mot de passe    :";
            // 
            // lblCnx
            // 
            this.lblCnx.AutoSize = true;
            this.lblCnx.BackColor = System.Drawing.Color.Transparent;
            this.lblCnx.Font = new System.Drawing.Font("Pristina", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCnx.ForeColor = System.Drawing.Color.Wheat;
            this.lblCnx.Location = new System.Drawing.Point(329, 37);
            this.lblCnx.Name = "lblCnx";
            this.lblCnx.Size = new System.Drawing.Size(147, 49);
            this.lblCnx.TabIndex = 1;
            this.lblCnx.Text = "Connexion";
            // 
            // textUtil
            // 
            this.textUtil.BackColor = System.Drawing.Color.Wheat;
            this.textUtil.Location = new System.Drawing.Point(407, 137);
            this.textUtil.Name = "textUtil";
            this.textUtil.Size = new System.Drawing.Size(156, 20);
            this.textUtil.TabIndex = 2;
            // 
            // textMDP
            // 
            this.textMDP.BackColor = System.Drawing.Color.Wheat;
            this.textMDP.Location = new System.Drawing.Point(407, 234);
            this.textMDP.Name = "textMDP";
            this.textMDP.PasswordChar = '•';
            this.textMDP.Size = new System.Drawing.Size(156, 20);
            this.textMDP.TabIndex = 3;
            // 
            // btnSeco
            // 
            this.btnSeco.BackColor = System.Drawing.Color.Wheat;
            this.btnSeco.Font = new System.Drawing.Font("Pristina", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeco.Location = new System.Drawing.Point(337, 327);
            this.btnSeco.Name = "btnSeco";
            this.btnSeco.Size = new System.Drawing.Size(140, 31);
            this.btnSeco.TabIndex = 4;
            this.btnSeco.Text = "Se connecter";
            this.btnSeco.UseVisualStyleBackColor = false;
            this.btnSeco.Click += new System.EventHandler(this.btnSeco_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Wheat;
            this.btnQuitter.Font = new System.Drawing.Font("Pristina", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Location = new System.Drawing.Point(643, 389);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(145, 40);
            this.btnQuitter.TabIndex = 5;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // lblCompte
            // 
            this.lblCompte.AutoSize = true;
            this.lblCompte.BackColor = System.Drawing.Color.Transparent;
            this.lblCompte.Font = new System.Drawing.Font("Pristina", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompte.ForeColor = System.Drawing.Color.Wheat;
            this.lblCompte.Location = new System.Drawing.Point(354, 376);
            this.lblCompte.Name = "lblCompte";
            this.lblCompte.Size = new System.Drawing.Size(101, 21);
            this.lblCompte.TabIndex = 6;
            this.lblCompte.Text = "Créer un compte ?";
            this.lblCompte.Click += new System.EventHandler(this.lblCompte_Click);
            this.lblCompte.MouseEnter += new System.EventHandler(this.lblCompte_MouseEnter);
            this.lblCompte.MouseLeave += new System.EventHandler(this.lblCompte_MouseLeave);
            // 
            // btnInscrire
            // 
            this.btnInscrire.BackColor = System.Drawing.Color.Wheat;
            this.btnInscrire.Font = new System.Drawing.Font("Pristina", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscrire.Location = new System.Drawing.Point(337, 395);
            this.btnInscrire.Name = "btnInscrire";
            this.btnInscrire.Size = new System.Drawing.Size(140, 31);
            this.btnInscrire.TabIndex = 7;
            this.btnInscrire.Text = "S\'inscrire";
            this.btnInscrire.UseVisualStyleBackColor = false;
            this.btnInscrire.Visible = false;
            this.btnInscrire.Click += new System.EventHandler(this.btnInscrire_Click);
            // 
            // labelConfirm
            // 
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.BackColor = System.Drawing.Color.Transparent;
            this.labelConfirm.Font = new System.Drawing.Font("Pristina", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfirm.ForeColor = System.Drawing.Color.Wheat;
            this.labelConfirm.Location = new System.Drawing.Point(136, 307);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(265, 32);
            this.labelConfirm.TabIndex = 8;
            this.labelConfirm.Text = "Confirmer votre mot de passe :";
            this.labelConfirm.Visible = false;
            // 
            // txtConfirm
            // 
            this.txtConfirm.BackColor = System.Drawing.Color.Wheat;
            this.txtConfirm.Location = new System.Drawing.Point(407, 315);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '•';
            this.txtConfirm.Size = new System.Drawing.Size(156, 20);
            this.txtConfirm.TabIndex = 9;
            this.txtConfirm.Visible = false;
            // 
            // txtIncriMdp
            // 
            this.txtIncriMdp.BackColor = System.Drawing.Color.Wheat;
            this.txtIncriMdp.Location = new System.Drawing.Point(407, 233);
            this.txtIncriMdp.Name = "txtIncriMdp";
            this.txtIncriMdp.PasswordChar = '•';
            this.txtIncriMdp.Size = new System.Drawing.Size(156, 20);
            this.txtIncriMdp.TabIndex = 10;
            this.txtIncriMdp.Visible = false;
            // 
            // txtInscriU
            // 
            this.txtInscriU.BackColor = System.Drawing.Color.Wheat;
            this.txtInscriU.Location = new System.Drawing.Point(407, 137);
            this.txtInscriU.Name = "txtInscriU";
            this.txtInscriU.Size = new System.Drawing.Size(156, 20);
            this.txtInscriU.TabIndex = 11;
            this.txtInscriU.Visible = false;
            // 
            // Oeil
            // 
            this.Oeil.BackColor = System.Drawing.Color.Transparent;
            this.Oeil.Image = global::Interface_Auto.Properties.Resources.Oeil;
            this.Oeil.Location = new System.Drawing.Point(569, 226);
            this.Oeil.Name = "Oeil";
            this.Oeil.Size = new System.Drawing.Size(35, 35);
            this.Oeil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Oeil.TabIndex = 13;
            this.Oeil.TabStop = false;
            this.Oeil.Click += new System.EventHandler(this.Oeil_Click);
            // 
            // oeilBarre
            // 
            this.oeilBarre.BackColor = System.Drawing.Color.Transparent;
            this.oeilBarre.Image = global::Interface_Auto.Properties.Resources.OeilBarre;
            this.oeilBarre.Location = new System.Drawing.Point(562, 217);
            this.oeilBarre.Name = "oeilBarre";
            this.oeilBarre.Size = new System.Drawing.Size(50, 57);
            this.oeilBarre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oeilBarre.TabIndex = 14;
            this.oeilBarre.TabStop = false;
            this.oeilBarre.Visible = false;
            this.oeilBarre.Click += new System.EventHandler(this.oeilBarre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pristina", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Wheat;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 49);
            this.label1.TabIndex = 17;
            this.label1.Text = "OCCAS\'  AUTO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Wheat;
            this.pictureBox1.Image = global::Interface_Auto.Properties.Resources.Car_Logo_Free_PNG;
            this.pictureBox1.Location = new System.Drawing.Point(740, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // labelRetour
            // 
            this.labelRetour.AutoSize = true;
            this.labelRetour.BackColor = System.Drawing.Color.Transparent;
            this.labelRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRetour.ForeColor = System.Drawing.Color.Wheat;
            this.labelRetour.Location = new System.Drawing.Point(25, 395);
            this.labelRetour.Name = "labelRetour";
            this.labelRetour.Size = new System.Drawing.Size(33, 33);
            this.labelRetour.TabIndex = 19;
            this.labelRetour.Text = "<";
            this.labelRetour.Visible = false;
            this.labelRetour.Click += new System.EventHandler(this.labelRetour_Click);
            this.labelRetour.MouseEnter += new System.EventHandler(this.labelRetour_MouseEnter);
            this.labelRetour.MouseLeave += new System.EventHandler(this.labelRetour_MouseLeave);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = global::Interface_Auto.Properties.Resources.PAGE_BENNY_S;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelRetour);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Oeil);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.labelConfirm);
            this.Controls.Add(this.lblCompte);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnSeco);
            this.Controls.Add(this.textUtil);
            this.Controls.Add(this.lblCnx);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.btnInscrire);
            this.Controls.Add(this.txtInscriU);
            this.Controls.Add(this.textMDP);
            this.Controls.Add(this.txtIncriMdp);
            this.Controls.Add(this.oeilBarre);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmLogin";
            this.Text = "Connexion";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Oeil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oeilBarre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Label lblCnx;
        private System.Windows.Forms.TextBox textUtil;
        private System.Windows.Forms.TextBox textMDP;
        private System.Windows.Forms.Button btnSeco;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Label lblCompte;
        private System.Windows.Forms.Button btnInscrire;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.TextBox txtIncriMdp;
        private System.Windows.Forms.TextBox txtInscriU;
        private System.Windows.Forms.PictureBox Oeil;
        private System.Windows.Forms.PictureBox oeilBarre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelRetour;
    }
}