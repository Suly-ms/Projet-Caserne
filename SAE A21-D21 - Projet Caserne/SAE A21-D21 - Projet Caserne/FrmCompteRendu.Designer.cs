namespace CompteRenduBox
{
    partial class FrmCompteRenduBox
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
            this.txbRapport = new System.Windows.Forms.TextBox();
            this.lblCompteRendu = new System.Windows.Forms.Label();
            this.pnlEngin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbRapport
            // 
            this.txbRapport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txbRapport.Location = new System.Drawing.Point(18, 35);
            this.txbRapport.Multiline = true;
            this.txbRapport.Name = "txbRapport";
            this.txbRapport.Size = new System.Drawing.Size(359, 123);
            this.txbRapport.TabIndex = 0;
            this.txbRapport.TextChanged += new System.EventHandler(this.txbRapport_TextChanged);
            this.txbRapport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbRapport_KeyPress);
            // 
            // lblCompteRendu
            // 
            this.lblCompteRendu.AutoSize = true;
            this.lblCompteRendu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompteRendu.ForeColor = System.Drawing.Color.Black;
            this.lblCompteRendu.Location = new System.Drawing.Point(21, 10);
            this.lblCompteRendu.Name = "lblCompteRendu";
            this.lblCompteRendu.Size = new System.Drawing.Size(352, 20);
            this.lblCompteRendu.TabIndex = 3;
            this.lblCompteRendu.Text = "Veuillez écrire le compte-rendu de la mission n° 0";
            this.lblCompteRendu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlEngin
            // 
            this.pnlEngin.Location = new System.Drawing.Point(409, 42);
            this.pnlEngin.Name = "pnlEngin";
            this.pnlEngin.Size = new System.Drawing.Size(431, 200);
            this.pnlEngin.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(441, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Veuillez sélectionner les engins endomagés";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnValider
            // 
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnValider.Location = new System.Drawing.Point(735, 270);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(88, 28);
            this.btnValider.TabIndex = 6;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // FrmCompteRenduBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(852, 310);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlEngin);
            this.Controls.Add(this.lblCompteRendu);
            this.Controls.Add(this.txbRapport);
            this.Name = "FrmCompteRenduBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compte rendu";
            this.Load += new System.EventHandler(this.FrmCompteRenduBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbRapport;
        private System.Windows.Forms.Label lblCompteRendu;
        private System.Windows.Forms.Panel pnlEngin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValider;
    }
}

