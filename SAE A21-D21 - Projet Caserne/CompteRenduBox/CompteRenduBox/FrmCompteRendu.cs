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

using Pinpon;

namespace CompteRenduBox
{
    public partial class FrmCompteRenduBox : Form
    {
        int m_idMission;
        public FrmCompteRenduBox(int idMission)
        {
            InitializeComponent();
            m_idMission = idMission;
        }

        private void txbRapport_TextChanged(object sender, EventArgs e)
        {

        }

        private void remplirRapportMission(string rapport)
        {
            SQLiteConnection connec = Connexion.Connec;

            try
            {
                string requeteSelect = $"UPDATE Mission SET compteRendu = '{rapport}' WHERE id = {m_idMission}";
                SQLiteCommand cdUpdate = new SQLiteCommand();
                cdUpdate.Connection = connec;
                cdUpdate.CommandType = CommandType.Text;
                cdUpdate.CommandText = requeteSelect;
                cdUpdate.ExecuteNonQuery();

                // Mettre à jour le DataSet MesDatas.DsGlobal pour la ligne concernée
                MesDatas.DsGlobal.Tables["Mission"].Select($"id = {m_idMission}")[0]["compteRendu"] = rapport;

            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de la mise à jour du rapport");
            }
            finally
            {
                Connexion.FermerConnexion();
                DialogResult = DialogResult.OK;
            }
        }

        private void txbRapport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                remplirRapportMission(txbRapport.Text);
            }
        }
    }
}
