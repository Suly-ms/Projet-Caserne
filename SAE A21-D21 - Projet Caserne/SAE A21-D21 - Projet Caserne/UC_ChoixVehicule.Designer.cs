namespace UC_ChoixVehicules
{
    partial class UC_ChoixVehicule
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
            this.pbVehicule.Location = new System.Drawing.Point(14, 33);
            this.pbVehicule.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbVehicule.Name = "pbVehicule";
            this.pbVehicule.Size = new System.Drawing.Size(74, 65);
            this.pbVehicule.TabIndex = 0;
            this.pbVehicule.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(12, 11);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "label1";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.BackColor = System.Drawing.Color.Transparent;
            this.lblNumero.ForeColor = System.Drawing.Color.White;
            this.lblNumero.Location = new System.Drawing.Point(50, 11);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(35, 13);
            this.lblNumero.TabIndex = 3;
            this.lblNumero.Text = "label2";
            // 
            // btnChoisi
            // 
            this.btnChoisi.BackColor = System.Drawing.Color.Red;
            this.btnChoisi.Location = new System.Drawing.Point(103, 33);
            this.btnChoisi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoisi.Name = "btnChoisi";
            this.btnChoisi.Size = new System.Drawing.Size(52, 57);
            this.btnChoisi.TabIndex = 4;
            this.btnChoisi.UseVisualStyleBackColor = false;
            this.btnChoisi.Click += new System.EventHandler(this.btnChoisi_Click);
            // 
            // UCChoixVehicule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnChoisi);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.pbVehicule);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UCChoixVehicule";
            this.Size = new System.Drawing.Size(170, 115);
            this.Load += new System.EventHandler(this.UC_ChoixVehicule_Load);
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
