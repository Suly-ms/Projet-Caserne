using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAE_A21_D21___Projet_Caserne
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CompteRenduBox;
    using Org.BouncyCastle.Asn1.IsisMtt.X509;
    using Pinpon;
    using System.Data.SQLite;

    public partial class UC_AffichageEngin : UserControl
    {
        private string m_nom;
        private int m_idCaserne;
        private string m_codeTypeEngin;
        private int m_numeroEngin;
        private int m_idMission;
        private string m_reparation;

        public UC_AffichageEngin(string nom, int idCaserne, string codeTypeEngin, int numeroEngin, int idMission, string reparation)
        {
            InitializeComponent();

            m_nom = nom;
            m_idCaserne = idCaserne;
            m_codeTypeEngin = codeTypeEngin;
            m_numeroEngin = numeroEngin;
            m_idMission = idMission;
            m_reparation = reparation;

            ckbEngin.Text = getAffichage();
        }

        private void UC_AffichageEngin_Load(object sender, EventArgs e)
        {
            ckbEngin.Checked = m_reparation == "" ? false : true;
        }

        public string getAffichage()
        {
            return $"{m_nom} {m_idCaserne}-{m_codeTypeEngin}-{m_numeroEngin}"; ;
        }

        public bool getChecked()
        {
            return ckbEngin.Checked;
        }

        public void changeChecked()
        {
            ckbEngin.Checked = getChecked() ? false : true;
        }


        private void ckbEngin_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEngin.Checked)
            {
                // Ouvre un forme avec un textBox qui attend les réparations
                // Le form va mettre à jour le DataGlobal et la base de donnée
                FrmDommageEngin frmDommage = new FrmDommageEngin(m_idCaserne, m_codeTypeEngin, m_numeroEngin, m_idMission);
                frmDommage.ShowDialog();
            }
            else
            {
                // C'est le cas où l'utilisateur a coché puis décoché
                // Il va mettre à jour le DataGlobal et la base de donnée
                SQLiteConnection connec = Connexion.Connec;
                try
                {
                    // Mettre à jour la base de donnée pour les lignes concernées
                    string requeteUpdateEngin = $"UPDATE Engin SET enPanne = 0 WHERE idCaserne = {m_idCaserne} AND codeTypeEngin = '{m_codeTypeEngin}' AND numero = {m_numeroEngin}";
                    string requetePartirAvec = $"UPDATE PartirAvec SET reparationsEventuelles = NULL WHERE idCaserne = {m_idCaserne} AND codeTypeEngin = '{m_codeTypeEngin}' AND numeroEngin = {m_numeroEngin} AND idMission = {m_idMission}";

                    SQLiteCommand cdUpdate = new SQLiteCommand();
                    cdUpdate.Connection = connec;
                    cdUpdate.CommandType = CommandType.Text;
                    cdUpdate.CommandText = requeteUpdateEngin;
                    cdUpdate.ExecuteNonQuery();

                    cdUpdate.CommandText = requetePartirAvec;
                    cdUpdate.ExecuteNonQuery();

                    // Mettre à jour le DataSet MesDatas.DsGlobal pour les lignes concernées
                    MesDatas.DsGlobal.Tables["Engin"].Select($"idCaserne = {m_idCaserne} AND codeTypeEngin = '{m_codeTypeEngin}' AND numero = {m_numeroEngin}")[0]["enPanne"] = false;
                    MesDatas.DsGlobal.Tables["PartirAvec"].Select($"idCaserne = {m_idCaserne} AND codeTypeEngin = '{m_codeTypeEngin}' AND numeroEngin = {m_numeroEngin} AND idMission = {m_idMission}")[0]["reparationsEventuelles"] = null;

                    MessageBox.Show($"Les réparations à faire ont été enlevées de la base de donnée");
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur lors de la mise à jour des engins dans la base de donnée");
                }

                finally
                {
                    Connexion.FermerConnexion();
                }
            }
        }

        private void ckbEngin_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}
