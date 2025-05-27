namespace SAE_A21_D21___Projet_Caserne
{
    partial class FrmTableauDeBord
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableauDeBord));
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.pnlTableauBord = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txbEnCours = new System.Windows.Forms.TextBox();
            this.btnNouvelleMission = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckbEnCours = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStatistiques = new System.Windows.Forms.Button();
            this.btnGestionPersonnel = new System.Windows.Forms.Button();
            this.btnGestionEngins = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnTableauBord = new System.Windows.Forms.Button();
            this.pnlMission = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTableauBord.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // pnlTableauBord
            // 
            this.pnlTableauBord.BackColor = System.Drawing.Color.PapayaWhip;
            this.pnlTableauBord.Controls.Add(this.label2);
            this.pnlTableauBord.Controls.Add(this.txbEnCours);
            this.pnlTableauBord.Controls.Add(this.btnNouvelleMission);
            this.pnlTableauBord.Controls.Add(this.panel3);
            this.pnlTableauBord.Controls.Add(this.ckbEnCours);
            this.pnlTableauBord.Controls.Add(this.label1);
            this.pnlTableauBord.Location = new System.Drawing.Point(331, 26);
            this.pnlTableauBord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTableauBord.Name = "pnlTableauBord";
            this.pnlTableauBord.Size = new System.Drawing.Size(1167, 101);
            this.pnlTableauBord.TabIndex = 2;
            this.pnlTableauBord.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTableauBord_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.label2.Location = new System.Drawing.Point(0, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enlever terminée";
            // 
            // txbEnCours
            // 
            this.txbEnCours.Location = new System.Drawing.Point(23, 55);
            this.txbEnCours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbEnCours.Name = "txbEnCours";
            this.txbEnCours.Size = new System.Drawing.Size(36, 22);
            this.txbEnCours.TabIndex = 10;
            this.txbEnCours.TextChanged += new System.EventHandler(this.txbEnCours_TextChanged);
            this.txbEnCours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbEnCours_KeyPress);
            // 
            // btnNouvelleMission
            // 
            this.btnNouvelleMission.BackColor = System.Drawing.Color.Transparent;
            this.btnNouvelleMission.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNouvelleMission.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouvelleMission.Location = new System.Drawing.Point(883, 16);
            this.btnNouvelleMission.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNouvelleMission.Name = "btnNouvelleMission";
            this.btnNouvelleMission.Size = new System.Drawing.Size(212, 49);
            this.btnNouvelleMission.TabIndex = 9;
            this.btnNouvelleMission.Text = "Nouvelle mission";
            this.btnNouvelleMission.UseVisualStyleBackColor = false;
            this.btnNouvelleMission.Click += new System.EventHandler(this.btnNouvelleMission_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Firebrick;
            this.panel3.Location = new System.Drawing.Point(107, 75);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(959, 5);
            this.panel3.TabIndex = 4;
            // 
            // ckbEnCours
            // 
            this.ckbEnCours.AutoSize = true;
            this.ckbEnCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbEnCours.ForeColor = System.Drawing.Color.Firebrick;
            this.ckbEnCours.Location = new System.Drawing.Point(155, 30);
            this.ckbEnCours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckbEnCours.Name = "ckbEnCours";
            this.ckbEnCours.Size = new System.Drawing.Size(116, 28);
            this.ckbEnCours.TabIndex = 3;
            this.ckbEnCours.Text = "En cours";
            this.ckbEnCours.UseVisualStyleBackColor = true;
            this.ckbEnCours.CheckedChanged += new System.EventHandler(this.ckbEnCours_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(435, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tableau de bord";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Firebrick;
            this.panel2.Controls.Add(this.btnStatistiques);
            this.panel2.Controls.Add(this.btnGestionPersonnel);
            this.panel2.Controls.Add(this.btnGestionEngins);
            this.panel2.Controls.Add(this.btnQuitter);
            this.panel2.Controls.Add(this.btnTableauBord);
            this.panel2.Location = new System.Drawing.Point(16, 26);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 774);
            this.panel2.TabIndex = 3;
            // 
            // btnStatistiques
            // 
            this.btnStatistiques.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnStatistiques.Location = new System.Drawing.Point(23, 277);
            this.btnStatistiques.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStatistiques.Name = "btnStatistiques";
            this.btnStatistiques.Size = new System.Drawing.Size(252, 49);
            this.btnStatistiques.TabIndex = 12;
            this.btnStatistiques.Text = "Statistiques";
            this.btnStatistiques.UseVisualStyleBackColor = true;
            // 
            // btnGestionPersonnel
            // 
            this.btnGestionPersonnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnGestionPersonnel.Location = new System.Drawing.Point(20, 191);
            this.btnGestionPersonnel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGestionPersonnel.Name = "btnGestionPersonnel";
            this.btnGestionPersonnel.Size = new System.Drawing.Size(252, 49);
            this.btnGestionPersonnel.TabIndex = 11;
            this.btnGestionPersonnel.Text = "Gestion du personnel";
            this.btnGestionPersonnel.UseVisualStyleBackColor = true;
            // 
            // btnGestionEngins
            // 
            this.btnGestionEngins.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnGestionEngins.Location = new System.Drawing.Point(20, 105);
            this.btnGestionEngins.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGestionEngins.Name = "btnGestionEngins";
            this.btnGestionEngins.Size = new System.Drawing.Size(252, 49);
            this.btnGestionEngins.TabIndex = 10;
            this.btnGestionEngins.Text = "Gestion des engins";
            this.btnGestionEngins.UseVisualStyleBackColor = true;
            // 
            // btnQuitter
            // 
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnQuitter.Location = new System.Drawing.Point(20, 705);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(252, 49);
            this.btnQuitter.TabIndex = 9;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnTableauBord
            // 
            this.btnTableauBord.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btnTableauBord.Location = new System.Drawing.Point(20, 18);
            this.btnTableauBord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTableauBord.Name = "btnTableauBord";
            this.btnTableauBord.Size = new System.Drawing.Size(252, 49);
            this.btnTableauBord.TabIndex = 8;
            this.btnTableauBord.Text = "Tableau de bord";
            this.btnTableauBord.UseVisualStyleBackColor = true;
            // 
            // pnlMission
            // 
            this.pnlMission.AutoScroll = true;
            this.pnlMission.BackColor = System.Drawing.Color.PapayaWhip;
            this.pnlMission.Location = new System.Drawing.Point(327, 26);
            this.pnlMission.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMission.Name = "pnlMission";
            this.pnlMission.Size = new System.Drawing.Size(1211, 774);
            this.pnlMission.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1553, 815);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FrmTableauDeBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1553, 815);
            this.Controls.Add(this.pnlTableauBord);
            this.Controls.Add(this.pnlMission);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmTableauDeBord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tableau de bord";
            this.Load += new System.EventHandler(this.FrmTableauDeBord_Load);
            this.pnlTableauBord.ResumeLayout(false);
            this.pnlTableauBord.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private System.Windows.Forms.Panel pnlTableauBord;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ckbEnCours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMission;
        private System.Windows.Forms.Button btnNouvelleMission;
        private System.Windows.Forms.Button btnTableauBord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.TextBox txbEnCours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGestionPersonnel;
        private System.Windows.Forms.Button btnGestionEngins;
        private System.Windows.Forms.Button btnStatistiques;
    }
}

