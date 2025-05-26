using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using Pinpon;
using SAE_A21_D21___Projet_Caserne;

namespace CompteRenduBox
{
    public partial class FrmCompteRenduBox : Form
    {
        int m_idMission;
        string[] m_enginsMission;
        public FrmCompteRenduBox(int idMission, string[] enginsMission)
        {
            InitializeComponent();
            m_idMission = idMission;
            m_enginsMission = enginsMission;
        }

        private void FrmCompteRenduBox_Load(object sender, EventArgs e)
        {

            lblCompteRendu.Text = $"Veuillez écrire le compte-rendu de la mission n° {m_idMission}";

            int hauteur = 0;
            foreach (DataRow engin in TrouverEnginsUtilises(m_idMission))
            {

                string nom = TrouverNomEngin(engin["codeTypeEngin"].ToString());
                int idCaserne = Convert.ToInt16(engin["idCaserne"]);
                string codeTypeEngin = engin["codeTypeEngin"].ToString();
                int numeroEngin = Convert.ToInt16(engin["numeroEngin"]);
                int idMission = Convert.ToInt16(engin["idMission"]);
                string reparation = engin["reparationsEventuelles"].ToString();

                UC_AffichageEngin afficheEngin = new UC_AffichageEngin(nom, idCaserne, codeTypeEngin, numeroEngin, idMission, reparation);
                afficheEngin.Location = new Point(0, hauteur);
                pnlEngin.Controls.Add(afficheEngin);
                hauteur += 25;
            }
        }

        private string TrouverNomEngin(string code)
        {
            DataTable tableTypeEngin = MesDatas.DsGlobal.Tables["TypeEngin"];
            DataRow[] type = tableTypeEngin.Select($"code = '{code}'");

            return type[0]["nom"].ToString();
        }

        private DataRow[] TrouverEnginsUtilises(int idMission)
        {
            DataTable tablePartir = MesDatas.DsGlobal.Tables["PartirAvec"];
            DataRow[] partir = tablePartir.Select($"idMission = {idMission}");

            return partir;
        }

        private void txbRapport_TextChanged(object sender, EventArgs e)
        {

        }

        private void remplirRapportMission(string rapport)
        {
            SQLiteConnection connec = Connexion.Connec;

            try
            {
                // Remplace les " en '' pour eviter les erreurs lors de la commande SQL
                rapport = rapport.Replace("\"", "''");

                string requeteSelect = $"UPDATE Mission SET compteRendu = \"{rapport}\" WHERE id = {m_idMission}";
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
                MessageBox.Show("Erreur lors de la mise à jour du compte rendu");
            }
            finally
            {
                Connexion.FermerConnexion();
                DialogResult = DialogResult.OK;
            }
        }

        private void txbRapport_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            remplirRapportMission(txbRapport.Text);
            DialogResult = DialogResult.OK;
        }
    }
}
