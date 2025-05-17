namespace UC_RecapMission
{
    partial class UC_AffichageMission
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

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AffichageMission));
            this.lblCompteRendu = new System.Windows.Forms.Label();
            this.lblMotif = new System.Windows.Forms.Label();
            this.lblCaserne = new System.Windows.Forms.Label();
            this.lblDateDepart = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCompteRendu
            // 
            this.lblCompteRendu.AutoSize = true;
            this.lblCompteRendu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCompteRendu.ForeColor = System.Drawing.Color.Brown;
            this.lblCompteRendu.Location = new System.Drawing.Point(104, 84);
            this.lblCompteRendu.Name = "lblCompteRendu";
            this.lblCompteRendu.Size = new System.Drawing.Size(306, 18);
            this.lblCompteRendu.TabIndex = 13;
            this.lblCompteRendu.Text = "--> Ne connait plus l\'alphabet ddhedhe heueh ";
            // 
            // lblMotif
            // 
            this.lblMotif.AutoSize = true;
            this.lblMotif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblMotif.ForeColor = System.Drawing.Color.Brown;
            this.lblMotif.Location = new System.Drawing.Point(99, 46);
            this.lblMotif.Name = "lblMotif";
            this.lblMotif.Size = new System.Drawing.Size(186, 20);
            this.lblMotif.TabIndex = 12;
            this.lblMotif.Text = "Foulure d\'un neurone";
            // 
            // lblCaserne
            // 
            this.lblCaserne.AutoSize = true;
            this.lblCaserne.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCaserne.ForeColor = System.Drawing.Color.Brown;
            this.lblCaserne.Location = new System.Drawing.Point(409, 5);
            this.lblCaserne.Name = "lblCaserne";
            this.lblCaserne.Size = new System.Drawing.Size(224, 18);
            this.lblCaserne.TabIndex = 11;
            this.lblCaserne.Text = "Caserne : Caserne de King Kong";
            // 
            // lblDateDepart
            // 
            this.lblDateDepart.AutoSize = true;
            this.lblDateDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDateDepart.ForeColor = System.Drawing.Color.Brown;
            this.lblDateDepart.Location = new System.Drawing.Point(228, 5);
            this.lblDateDepart.Name = "lblDateDepart";
            this.lblDateDepart.Size = new System.Drawing.Size(138, 18);
            this.lblDateDepart.TabIndex = 10;
            this.lblDateDepart.Text = "Début le 07/07/2024";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(12, 24);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(70, 70);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblId.ForeColor = System.Drawing.Color.Brown;
            this.lblId.Location = new System.Drawing.Point(94, 5);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(78, 18);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "Mission n°";
            // 
            // UC_AffichageMission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblCompteRendu);
            this.Controls.Add(this.lblMotif);
            this.Controls.Add(this.lblCaserne);
            this.Controls.Add(this.lblDateDepart);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblId);
            this.Name = "UC_AffichageMission";
            this.Size = new System.Drawing.Size(722, 117);
            this.Load += new System.EventHandler(this.UC_AffichageMission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompteRendu;
        private System.Windows.Forms.Label lblMotif;
        private System.Windows.Forms.Label lblCaserne;
        private System.Windows.Forms.Label lblDateDepart;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblId;
    }
}
