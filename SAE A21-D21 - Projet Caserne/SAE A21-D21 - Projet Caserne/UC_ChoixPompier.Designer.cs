namespace UC_ChoixPompiers
{
    partial class UC_ChoixPompier
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
            this.btnChoisi = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.pbGrade = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChoisi
            // 
            this.btnChoisi.BackColor = System.Drawing.Color.Red;
            this.btnChoisi.Location = new System.Drawing.Point(86, 34);
            this.btnChoisi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoisi.Name = "btnChoisi";
            this.btnChoisi.Size = new System.Drawing.Size(52, 57);
            this.btnChoisi.TabIndex = 8;
            this.btnChoisi.UseVisualStyleBackColor = false;
            this.btnChoisi.Click += new System.EventHandler(this.btnChoisi_Click);
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.BackColor = System.Drawing.Color.Transparent;
            this.lblNom.ForeColor = System.Drawing.Color.White;
            this.lblNom.Location = new System.Drawing.Point(26, 111);
            this.lblNom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 13);
            this.lblNom.TabIndex = 7;
            this.lblNom.Text = "label2";
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.ForeColor = System.Drawing.Color.White;
            this.lblGrade.Location = new System.Drawing.Point(26, 10);
            this.lblGrade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(35, 13);
            this.lblGrade.TabIndex = 6;
            this.lblGrade.Text = "label1";
            // 
            // pbGrade
            // 
            this.pbGrade.Location = new System.Drawing.Point(11, 34);
            this.pbGrade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbGrade.Name = "pbGrade";
            this.pbGrade.Size = new System.Drawing.Size(60, 65);
            this.pbGrade.TabIndex = 5;
            this.pbGrade.TabStop = false;
            // 
            // UCChoixPompier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnChoisi);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.pbGrade);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UCChoixPompier";
            this.Size = new System.Drawing.Size(151, 134);
            this.Load += new System.EventHandler(this.UC_ChoixPompier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChoisi;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.PictureBox pbGrade;
    }
}
