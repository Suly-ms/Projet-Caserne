namespace SAE_A21_D21___Projet_Caserne
{
    partial class UC_AffichageEngin
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
            this.ckbEngin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ckbEngin
            // 
            this.ckbEngin.AutoSize = true;
            this.ckbEngin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.ckbEngin.Location = new System.Drawing.Point(2, 2);
            this.ckbEngin.Name = "ckbEngin";
            this.ckbEngin.Size = new System.Drawing.Size(101, 22);
            this.ckbEngin.TabIndex = 0;
            this.ckbEngin.Text = "checkBox1";
            this.ckbEngin.UseVisualStyleBackColor = true;
            this.ckbEngin.CheckedChanged += new System.EventHandler(this.ckbEngin_CheckedChanged);
            this.ckbEngin.CheckStateChanged += new System.EventHandler(this.ckbEngin_CheckStateChanged);
            // 
            // UC_AffichageEngin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ckbEngin);
            this.Name = "UC_AffichageEngin";
            this.Size = new System.Drawing.Size(491, 24);
            this.Load += new System.EventHandler(this.UC_AffichageEngin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbEngin;
    }
}
