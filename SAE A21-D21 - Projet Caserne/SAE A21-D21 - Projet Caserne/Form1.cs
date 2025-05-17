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

            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataTable tableCaserne = MesDatas.DsGlobal.Tables["Caserne"];


            foreach (DataRow ligne in tableMissions.Rows)
            {
                int id = Convert.ToInt16(ligne["id"]);
                DateTime date = Convert.ToDateTime(ligne["dateHeureDepart"]);
                string motif = ligne["motifAppel"].ToString();
                string rendu = ligne["compteRendu"].ToString();


                int idCaserne = Convert.ToInt16(ligne["idCaserne"]);

                // Chercher le nom de la caserne manuellement
                string nomCaserne = "";
                int i = 0;

                while (nomCaserne == "")
                {
                    DataRow caserne = tableCaserne.Rows[i];
                    int idCaserneCourante = Convert.ToInt16(caserne["id"]);
                    if (idCaserneCourante == idCaserne)
                    {
                        nomCaserne = caserne["nom"].ToString();
                    }

                    i++;
                }

                // Ajout du UC mission dans le panel 
                UC_AffichageMission mission = new UC_AffichageMission(id, date, nomCaserne, motif, rendu);
                mission.Location = new Point(55, hauteur);
                mission.BorderStyle = BorderStyle.FixedSingle;
                pnlMission.Controls.Add(mission);

                // Ajout UC double bouton dans le panel
                UC_DoubleBouton dblBtn = new UC_DoubleBouton();
                dblBtn.Location = new Point(795, hauteur);
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
