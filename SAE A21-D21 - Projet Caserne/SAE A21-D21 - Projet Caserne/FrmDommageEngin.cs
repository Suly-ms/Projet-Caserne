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
using CompteRenduBox;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using Pinpon;

namespace SAE_A21_D21___Projet_Caserne
{
    public partial class FrmDommageEngin : Form
    {
        private int m_idCaserne;
        private string m_codeTypeEngin;
        private int m_numeroEngin;
        private int m_idMission;

        public FrmDommageEngin(int idCaserne, string codeTypeEngin, int numeroEngin, int idMission)
        {
            InitializeComponent();

            m_idCaserne = idCaserne;
            m_codeTypeEngin = codeTypeEngin;
            m_numeroEngin = numeroEngin;
            m_idMission = idMission;
        }

        private void FrmDommageEngin_Load(object sender, EventArgs e)
        {
            lblReparation.Text = $"Veuillez specifier les dégâts subis sur l'engin {m_idCaserne}-{m_codeTypeEngin}-{m_numeroEngin}";
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txbReparation.Text.Length <= 5)
            {
                MessageBox.Show("Veuillez saisir les réparations à effectuer sur ce vehicule");
            }

            else
            {
                string reparation = txbReparation.Text.Replace("\"", "''");
                SQLiteConnection connec = Connexion.Connec;

                try
                {
                    string requeteUpdateEngin = $"UPDATE Engin SET enPanne = 1 WHERE idCaserne = {m_idCaserne} AND codeTypeEngin = '{m_codeTypeEngin}' AND numero = {m_numeroEngin}";
                    string requetePartirAvec = $"UPDATE PartirAvec SET reparationsEventuelles = \"{reparation}\" WHERE idCaserne = {m_idCaserne} AND codeTypeEngin = '{m_codeTypeEngin}' AND numeroEngin = {m_numeroEngin} AND idMission = {m_idMission}";

                    SQLiteCommand cdUpdate = new SQLiteCommand();
                    cdUpdate.Connection = connec;
                    cdUpdate.CommandType = CommandType.Text;
                    cdUpdate.CommandText = requeteUpdateEngin;
                    cdUpdate.ExecuteNonQuery();

                    cdUpdate.CommandText = requetePartirAvec;
                    cdUpdate.ExecuteNonQuery();

                    // Mettre à jour le DataSet MesDatas.DsGlobal pour la ligne concernée
                    MesDatas.DsGlobal.Tables["Engin"].Select($"idCaserne = {m_idCaserne} AND codeTypeEngin = '{m_codeTypeEngin}' AND numero = {m_numeroEngin}")[0]["enPanne"] = true;
                    MesDatas.DsGlobal.Tables["PartirAvec"].Select($"idCaserne = { m_idCaserne} AND codeTypeEngin = '{m_codeTypeEngin}' AND numeroEngin = { m_numeroEngin } AND idMission = {m_idMission}")[0]["reparationsEventuelles"] = reparation;

                    MessageBox.Show($"Les réparations à faire ont été renseignées dans la base de donnée");
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur lors de la mise à jour des engins dans la base de donnée");
                }

                finally
                {
                    Connexion.FermerConnexion();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
