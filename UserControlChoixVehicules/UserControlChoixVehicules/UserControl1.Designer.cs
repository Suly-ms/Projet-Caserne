namespace UserControlChoixVehicules
{
    partial class UCChoixVehicule
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
            this.pbVehicule = new System.Windows.Forms.PictureBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.btnChoisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbVehicule)).BeginInit();
            this.SuspendLayout();
            // 
            // pbVehicule
            // 
            this.pbVehicule.Location = new System.Drawing.Point(19, 41);
            this.pbVehicule.Name = "pbVehicule";
            this.pbVehicule.Size = new System.Drawing.Size(99, 80);
            this.pbVehicule.TabIndex = 0;
            this.pbVehicule.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(16, 13);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 16);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "label1";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.BackColor = System.Drawing.Color.Transparent;
            this.lblNumero.ForeColor = System.Drawing.Color.White;
            this.lblNumero.Location = new System.Drawing.Point(66, 13);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 16);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "label2";
            // 
            // btnChoisi
            // 
            this.btnChoisi.BackColor = System.Drawing.Color.Red;
            this.btnChoisi.Location = new System.Drawing.Point(137, 41);
            this.btnChoisi.Name = "btnChoisi";
            this.btnChoisi.Size = new System.Drawing.Size(70, 70);
            this.btnChoisi.TabIndex = 4;
            this.btnChoisi.UseVisualStyleBackColor = false;
            this.btnChoisi.Click += new System.EventHandler(this.btnChoisi_Click);
            // 
            // UCChoixVehicule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnChoisi);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.pbVehicule);
            this.Name = "UCChoixVehicule";
            this.Size = new System.Drawing.Size(226, 141);
            ((System.ComponentModel.ISupportInitialize)(this.pbVehicule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbVehicule;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Button btnChoisi;
    }
}
