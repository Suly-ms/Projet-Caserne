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
            // La checkBox sera de toute facon décoché au debut donc fera le remplissage initial
            ckbEnCours_CheckedChanged(sender, e);
        }

        private void RemplireTableauBord(DataRow ligne, int hauteur)
        {
            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataTable tableCaserne = MesDatas.DsGlobal.Tables["Caserne"];

            int id = Convert.ToInt16(ligne["id"]);
            DateTime date = Convert.ToDateTime(ligne["dateHeureDepart"]);
            string motif = ligne["motifAppel"].ToString();
            string rendu = ligne["compteRendu"].ToString();
            bool status = Convert.ToBoolean(ligne["terminee"]);

            // Chercher le nom de la caserne manuellement
            int idCaserne = Convert.ToInt16(ligne["idCaserne"]);
            DataRow[] casernes = tableCaserne.Select($"id = {idCaserne}");
            string nomCaserne = casernes[0]["nom"].ToString();

            // Ajout du UC mission dans le panel 
            UC_AffichageMission mission = new UC_AffichageMission(id, date, nomCaserne, motif, rendu, status);
            mission.Location = new Point(55, hauteur);
            mission.BorderStyle = BorderStyle.FixedSingle;
            pnlMission.Controls.Add(mission);

            // Ajout UC double bouton dans le panel
            UC_DoubleBouton dblBtn = new UC_DoubleBouton(id);
            dblBtn.Location = new Point(795, hauteur + 8);
            pnlMission.Controls.Add(dblBtn);
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

        private void ckbEnCours_CheckedChanged(object sender, EventArgs e)
        {
            pnlMission.Controls.Clear();

            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] resultats = ckbEnCours.Checked ? tableMissions.Select("terminee = 0") : tableMissions.Select(" 0 = 0");

            int hauteur = 101;
            foreach (DataRow ligne in resultats)
            {
                RemplireTableauBord(ligne, hauteur);

                hauteur += 125;
            }
        }
    }
}
