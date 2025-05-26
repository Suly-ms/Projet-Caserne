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
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbRapport
            // 
            this.txbRapport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txbRapport.Location = new System.Drawing.Point(17, 36);
            this.txbRapport.Name = "txbRapport";
            this.txbRapport.Size = new System.Drawing.Size(387, 24);
            this.txbRapport.TabIndex = 0;
            this.txbRapport.TextChanged += new System.EventHandler(this.txbRapport_TextChanged);
            this.txbRapport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbRapport_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(80, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Veuillez écrire le rapport de la mission";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCompteRenduBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(420, 74);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbRapport);
            this.Name = "FrmCompteRenduBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compte rendu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbRapport;
        private System.Windows.Forms.Label label2;
    }
}

