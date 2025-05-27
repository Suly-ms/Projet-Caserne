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
using UserControlChoixVehicules;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SAE_A21_D21___Projet_Caserne
{
    public partial class frmGestionNouvelleMission : Form
    {
        private DataSet pompierVehiculeMission;
        private int numeroMission;
        public frmGestionNouvelleMission()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Récupérer date aujourd'hui et l'attribuer à lblDateDelenchement
            DateTime dateAujourdhui = DateTime.Now;
            lblDateDelenchement.Text = lblDateDelenchement.Text + dateAujourdhui.ToString();

            // Récupérer les natures du sinitre et remplir la combobox attribuée

            cbxNatureSinistre.DataSource = MesDatas.DsGlobal.Tables["NatureSinistre"];
            cbxNatureSinistre.DisplayMember = "libelle";
            cbxNatureSinistre.ValueMember = "id";

            // Récupérer les natures du sinitre et remplir la combobox attribuée

            cbxCaserne.DataSource = MesDatas.DsGlobal.Tables["Caserne"];
            cbxCaserne.DisplayMember = "nom";
            cbxCaserne.ValueMember = "id";

            // Récupérer le numéro de mission
            using (SQLiteCommand getMaxId = new SQLiteCommand("SELECT IFNULL(MAX(id), 0) + 1 FROM Mission", Connexion.Connec))
            {
                numeroMission = Convert.ToInt32(getMaxId.ExecuteScalar());
                lblNouvelleMission.Text = lblNouvelleMission.Text + numeroMission.ToString();
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConstituer_Click(object sender, EventArgs e)
        {
            frmChoixVehiculesPompier monUC = new frmChoixVehiculesPompier(
                Convert.ToInt32(cbxNatureSinistre.SelectedValue),
                Convert.ToInt32(cbxCaserne.SelectedValue)
            );

            if (monUC.ShowDialog() == DialogResult.OK)
            {
                // Ici, on utilise bien l'instance monUC pour accéder à la propriété
                pompierVehiculeMission = monUC.DataSetMission;
                btnConstituer.BackColor = Color.White;
            }
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            txbMotif.Text = "";
            txbCodePostal.Text = "";
            txbRue.Text = "";
            txbVille.Text = "";
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if(!(txbVille.Text=="" || txbRue.Text == "" || txbCodePostal.Text == "" || pompierVehiculeMission == null))
            {
                SQLiteCommand insertIntoMission = new SQLiteCommand();
                insertIntoMission.Connection = Connexion.Connec;
                insertIntoMission.CommandText = $@"INSERT INTO Mission(id, dateHeureDepart, motifAppel, adresse, cp, ville, terminee, idNatureSinistre, idCaserne)
                                               VALUES('{numeroMission}', '{DateTime.Now}', '{txbMotif.Text}', '{txbRue.Text}', '{txbCodePostal.Text}', '{txbVille.Text}', 0, '{cbxNatureSinistre.SelectedValue}', '{cbxCaserne.SelectedValue}');";
                insertIntoMission.ExecuteNonQuery();

                DataRow[] Vehicules = pompierVehiculeMission.Tables["Vehicules"].Select();
                foreach (DataRow row in Vehicules)
                {
                    insertIntoMission.CommandText = $@"INSERT INTO PartirAvec
                                               VALUES({row["Caserne"]}, '{row["Type"]}', '{row["Numero"]}', {numeroMission}, NULL);";
                    insertIntoMission.ExecuteNonQuery();
                }

                DataRow[] Pompiers = pompierVehiculeMission.Tables["Pompiers"].Select();
                foreach (DataRow row in Pompiers)
                {
                    insertIntoMission.CommandText = $@"INSERT INTO Mobiliser
                                                VALUES({row["matricule"]}, {numeroMission}, {row["habilitation"]});";
                    insertIntoMission.ExecuteNonQuery();
                }

                Connexion.FermerConnexion();

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                txbVille.BackColor = txbVille.Text == "" ? ColorTranslator.FromHtml("#ff9c9c") : Color.White;
                txbRue.BackColor = txbRue.Text == "" ? ColorTranslator.FromHtml("#ff9c9c") : Color.White;
                txbCodePostal.BackColor = txbCodePostal.Text == "" ? ColorTranslator.FromHtml("#ff9c9c") : Color.White;
                txbMotif.BackColor = txbMotif.Text == "" ? ColorTranslator.FromHtml("#ff9c9c") : Color.White;
                btnConstituer.BackColor = pompierVehiculeMission == null ? ColorTranslator.FromHtml("#ff9c9c") : Color.White;
                lblChampsIncomplets.BackColor = ColorTranslator.FromHtml("#ff9c9c");
                lblChampsIncomplets.Visible = true;
            }
        }

        private void txbCodePostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Bloque la saisie si ce n’est pas un chiffre ou une touche de contrôle
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            else
            {
                txbCodePostal.BackColor = Color.White;
            }

            // Empêche d'écrire plus de 5 chiffres
            if (!char.IsControl(e.KeyChar) && txbCodePostal.Text.Length >= 5)
            {
                e.Handled = true;
            }

            // Empêche le collage via Ctrl+V
            if ((ModifierKeys == Keys.Control) && (e.KeyChar == 22)) // 22 = Ctrl+V
            {
                e.Handled = true;
            }
        }

        private void txbMotif_TextChanged(object sender, EventArgs e)
        {
            txbMotif.BackColor = Color.White;
        }

        private void txbRue_TextChanged(object sender, EventArgs e)
        {
            txbRue.BackColor = Color.White;
        }

        private void txbVille_TextChanged(object sender, EventArgs e)
        {
            txbVille.BackColor = Color.White;
        }
    }
}
