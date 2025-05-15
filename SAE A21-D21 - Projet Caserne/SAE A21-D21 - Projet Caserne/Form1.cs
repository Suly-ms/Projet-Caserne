using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Utilise les fichiers Connexion.cs et mesDatas.cs
using Pinpon;
using UC_DoubleBoutonImage;
using UC_RecapMission;

namespace SAE_A21_D21___Projet_Caserne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SQLiteConnection connec = Connexion.Connec;
            DataTable schemaTable = connec.GetSchema("Tables");

            //dataGridView1.DataSource = schemaTable;
            string requete;
            foreach (DataRow ligne in schemaTable.Rows)
            {
                requete = $"select * from {ligne[2].ToString()}";

                SQLiteDataAdapter da = new SQLiteDataAdapter(requete, connec);

                da.Fill(MesDatas.DsGlobal, ligne[2].ToString());
            }
            Connexion.FermerConnexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int hauteur = 101;
            for (int i = 0; i < 20; i++)
            {

                // Ajout du UC mission dans le panel 
                UC_AffichageMission mission = new UC_AffichageMission();
                mission.Location = new Point(83, hauteur);
                mission.BorderStyle = BorderStyle.FixedSingle;
                pnlMission.Controls.Add(mission);

                // Ajout UC double bouton dans le panel
                UC_DoubleBouton dblBtn = new UC_DoubleBouton();
                dblBtn.Location = new Point(750, hauteur);
                pnlMission.Controls.Add(dblBtn);

                hauteur += 120;
            }
        }

        private void uC_RecapMission1_Load(object sender, EventArgs e)
        {

        }

        private void uC_RecapMission1_Load_1(object sender, EventArgs e)
        {

        }

        private void pnlTableauBord_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
