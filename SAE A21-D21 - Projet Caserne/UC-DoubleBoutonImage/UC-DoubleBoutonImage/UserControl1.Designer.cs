namespace UC_DoubleBoutonImage
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.pctbClotureMission = new System.Windows.Forms.PictureBox();
            this.pctbEditionPdf = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctbClotureMission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbEditionPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // pctbClotureMission
            // 
            this.pctbClotureMission.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbClotureMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctbClotureMission.Image = ((System.Drawing.Image)(resources.GetObject("pctbClotureMission.Image")));
            this.pctbClotureMission.Location = new System.Drawing.Point(0, 2);
            this.pctbClotureMission.Name = "pctbClotureMission";
            this.pctbClotureMission.Size = new System.Drawing.Size(42, 42);
            this.pctbClotureMission.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbClotureMission.TabIndex = 21;
            this.pctbClotureMission.TabStop = false;
            this.pctbClotureMission.Click += new System.EventHandler(this.pctbClotureMission_Click);
            // 
            // pctbEditionPdf
            // 
            this.pctbEditionPdf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctbEditionPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctbEditionPdf.Image = ((System.Drawing.Image)(resources.GetObject("pctbEditionPdf.Image")));
            this.pctbEditionPdf.Location = new System.Drawing.Point(0, 47);
            this.pctbEditionPdf.Name = "pctbEditionPdf";
            this.pctbEditionPdf.Size = new System.Drawing.Size(42, 42);
            this.pctbEditionPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbEditionPdf.TabIndex = 22;
            this.pctbEditionPdf.TabStop = false;
            this.pctbEditionPdf.Click += new System.EventHandler(this.pctbEditionPdf_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pctbEditionPdf);
            this.Controls.Add(this.pctbClotureMission);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(43, 92);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctbClotureMission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbEditionPdf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pctbClotureMission;
        private System.Windows.Forms.PictureBox pctbEditionPdf;
    }
}
