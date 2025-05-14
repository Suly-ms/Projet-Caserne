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

        }

        private void uC_RecapMission1_Load(object sender, EventArgs e)
        {

        }

        private void uC_RecapMission1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
