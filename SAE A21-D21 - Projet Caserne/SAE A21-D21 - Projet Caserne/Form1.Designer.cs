namespace SAE_A21_D21___Projet_Caserne
{
    partial class frmTableauDeBord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableauDeBord));
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.pnlTableauBord = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txbEnCours = new System.Windows.Forms.TextBox();
            this.btnNouvelleMission = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckbEnCours = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.pnlTableauBord.Location = new System.Drawing.Point(248, 21);
            this.pnlTableauBord.Name = "pnlTableauBord";
            this.pnlTableauBord.Size = new System.Drawing.Size(875, 82);
            this.pnlTableauBord.TabIndex = 2;
            this.pnlTableauBord.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTableauBord_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.label2.Location = new System.Drawing.Point(0, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enlever terminée";
            // 
            // txbEnCours
            // 
            this.txbEnCours.Location = new System.Drawing.Point(17, 45);
            this.txbEnCours.Name = "txbEnCours";
            this.txbEnCours.Size = new System.Drawing.Size(28, 20);
            this.txbEnCours.TabIndex = 10;
            this.txbEnCours.TextChanged += new System.EventHandler(this.txbEnCours_TextChanged);
            this.txbEnCours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbEnCours_KeyPress);
            // 
            // btnNouvelleMission
            // 
            this.btnNouvelleMission.BackColor = System.Drawing.Color.Transparent;
            this.btnNouvelleMission.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNouvelleMission.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouvelleMission.Location = new System.Drawing.Point(668, 14);
            this.btnNouvelleMission.Name = "btnNouvelleMission";
            this.btnNouvelleMission.Size = new System.Drawing.Size(159, 40);
            this.btnNouvelleMission.TabIndex = 9;
            this.btnNouvelleMission.Text = "Nouvelle mission";
            this.btnNouvelleMission.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Firebrick;
            this.panel3.Location = new System.Drawing.Point(80, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(719, 4);
            this.panel3.TabIndex = 4;
            // 
            // ckbEnCours
            // 
            this.ckbEnCours.AutoSize = true;
            this.ckbEnCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbEnCours.ForeColor = System.Drawing.Color.Firebrick;
            this.ckbEnCours.Location = new System.Drawing.Point(116, 24);
            this.ckbEnCours.Name = "ckbEnCours";
            this.ckbEnCours.Size = new System.Drawing.Size(95, 22);
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
            this.label1.Location = new System.Drawing.Point(326, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tableau de bord";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Firebrick;
            this.panel2.Controls.Add(this.btnQuitter);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 629);
            this.panel2.TabIndex = 3;
            // 
            // btnQuitter
            // 
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnQuitter.Location = new System.Drawing.Point(15, 573);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(189, 40);
            this.btnQuitter.TabIndex = 9;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlMission
            // 
            this.pnlMission.AutoScroll = true;
            this.pnlMission.BackColor = System.Drawing.Color.PapayaWhip;
            this.pnlMission.Location = new System.Drawing.Point(245, 21);
            this.pnlMission.Name = "pnlMission";
            this.pnlMission.Size = new System.Drawing.Size(908, 629);
            this.pnlMission.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1165, 662);
            this.panel1.TabIndex = 8;
            // 
            // frmTableauDeBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1165, 662);
            this.Controls.Add(this.pnlTableauBord);
            this.Controls.Add(this.pnlMission);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmTableauDeBord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tableau de bord";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.TextBox txbEnCours;
        private System.Windows.Forms.Label label2;
    }
}

