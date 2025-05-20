using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Utilise les fichiers Connexion.cs et mesDatas.cs
using Pinpon;
using UC_DoubleBoutonImage;
using UC_RecapMission;
using static System.Windows.Forms.LinkLabel;

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
            RemplireToutTableauBord();
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
            string nomCaserne = TrouverCaserne(Convert.ToInt16(ligne["idCaserne"]));

            // Ajout du UC mission dans le panel 
            UC_AffichageMission mission = new UC_AffichageMission(id, date, nomCaserne, motif, rendu, status);
            mission.Location = new Point(55, hauteur);
            mission.BorderStyle = BorderStyle.FixedSingle;
            pnlMission.Controls.Add(mission);

            // Ajout UC double bouton dans le panel
            UC_DoubleBouton dblBtn = new UC_DoubleBouton(id);
            dblBtn.Location = new Point(795, hauteur + 8);
            pnlMission.Controls.Add(dblBtn);
            dblBtn.BoutonClique += DblBtn_BoutonClique;
        }

        private string TrouverCaserne(int id)
        {
            DataTable tableCaserne = MesDatas.DsGlobal.Tables["Caserne"];
            DataRow[] casernes = tableCaserne.Select($"id = {id}");

            return casernes[0]["nom"].ToString();
        }

        private void RemplireToutTableauBord()
        {
            pnlMission.Controls.Clear();

            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];

            int hauteur = 101;

            DataRow[] resultats = ckbEnCours.Checked ? tableMissions.Select("terminee = 0") : tableMissions.Select("0 = 0");

            foreach (DataRow ligne in resultats)
            {
                RemplireTableauBord(ligne, hauteur);

                hauteur += 125;
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

        private void ckbEnCours_CheckedChanged(object sender, EventArgs e)
        {
            RemplireToutTableauBord();
        }

        private void DblBtn_BoutonClique(object sender, string bouton)
        {
            var uc = sender as UC_DoubleBouton;
            if (uc != null)
            {
                if (bouton == "ClotureMission")
                {
                    int idMission = uc.getId();

                    SQLiteConnection connec = Connexion.Connec;

                    try
                    {
                        string requeteSelect = $"SELECT terminee FROM Mission WHERE id = {idMission}";
                        SQLiteCommand cdSelect = new SQLiteCommand();
                        cdSelect.Connection = connec;
                        cdSelect.CommandType = CommandType.Text;
                        cdSelect.CommandText = requeteSelect;

                        bool termine = Convert.ToBoolean(cdSelect.ExecuteScalar());


                        if (Convert.ToBoolean(termine))
                        {
                            MessageBox.Show($"La mission n°{idMission} est déjà terminée");
                        }
                        else
                        {
                            string requeteMajStatus = $"UPDATE Mission SET terminee = 1 WHERE id = {idMission}";

                            string dateRetour = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                            string requeteMajDateRetour = $"UPDATE Mission SET dateHeureRetour = '{dateRetour}' WHERE id = {idMission}";
                            SQLiteCommand cdMaj = new SQLiteCommand();

                            cdMaj.Connection = connec;
                            cdMaj.CommandType = CommandType.Text;
                            cdMaj.CommandText = requeteMajStatus;
                            cdMaj.ExecuteNonQuery();

                            cdMaj.CommandText = requeteMajDateRetour;
                            cdMaj.ExecuteNonQuery();

                            // Mettre à jour le DataSet MesDatas.DsGlobal pour la ligne concernée
                            MesDatas.DsGlobal.Tables["Mission"].Select($"id = {idMission}")[0]["terminee"] = true;
                            MesDatas.DsGlobal.Tables["Mission"].Select($"id = {idMission}")[0]["dateHeureRetour"] = dateRetour;

                            // Actualisation de l'interface
                            pnlMission.Controls.Clear();
                            RemplireToutTableauBord();

                            MessageBox.Show($"La mission n°{idMission} est achevée");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la mise à jour");
                    }
                    finally
                    {
                        Connexion.FermerConnexion();
                    }
                }

                else
                {
                    int idMission = uc.getId();

                    DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
                    DataRow[] missions = tableMissions.Select($"id = {idMission}");

                    DateTime dateDepartMission = Convert.ToDateTime(missions[0]["dateHeureDepart"]);
                    DateTime dateRetourMission = Convert.ToDateTime(missions[0]["dateHeureRetour"]);
                    string caserneMission = TrouverCaserne(Convert.ToInt16(missions[0]["idCaserne"]));
                    string motifMission = Convert.ToString(missions[0]["motifAppel"]);
                    string renduMission = Convert.ToString(missions[0]["compteRendu"]);
                    string statusMission = Convert.ToBoolean(missions[0]["terminee"]) ? "Terminée" : "En cours";
                    string adresseMission = Convert.ToString(missions[0]["adresse"]);

                    // Declaration du chemin du fichier PDF
                    string chemin = $"Mission_{idMission}.pdf";

                    // Declaration et initialisation du FileStram et du StreamWriter
                    FileStream fs = new FileStream(chemin, FileMode.Create, FileAccess.Write);
                    StreamWriter pdf = new StreamWriter(fs);
                    
                    // Initialisation du fichier PDF
                    pdf.Write(
                                $@"Rapport de mission


                                Déclenchée le {dateDepartMission.Day}-{dateDepartMission.Month}-{dateDepartMission.Year} à {dateDepartMission.Hour}h{dateDepartMission.Minute}
                                Retour le {dateRetourMission.Day}-{dateRetourMission.Month}-{dateRetourMission.Year} à {dateRetourMission.Hour}h{dateRetourMission.Minute}
                                ----------------------------------------------------------------------


                                Type de sinistre : {chemin}

                                Motif : {motifMission}
                                Adresse : {adresseMission}


                                Compte-rendu : {renduMission}
                                ----------------------------------------------------------------------

                                
                                Caserne : {caserneMission}

                                
                                Pompiers affectés :
                                {chemin}


                                Engins utilisés :
                                {chemin}");

                    pdf.Close();
                    MessageBox.Show($"Le PDF de la mission n°{idMission} à été créé");
                }
            }
        }


        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbEnCours_TextChanged(object sender, EventArgs e)
        {
        }

        private void txbEnCours_KeyPress(object sender, KeyPressEventArgs e)
        {

            SQLiteConnection connec = Connexion.Connec;

            if (e.KeyChar == (char)Keys.Enter)
                try
                {
                    string requeteSelect = $"SELECT terminee FROM Mission WHERE id = {txbEnCours.Text}";
                    SQLiteCommand cdSelect = new SQLiteCommand();
                    cdSelect.Connection = connec;
                    cdSelect.CommandType = CommandType.Text;
                    cdSelect.CommandText = requeteSelect;

                    bool termine = Convert.ToBoolean(cdSelect.ExecuteScalar());


                    if (Convert.ToBoolean(!termine))
                    {
                        MessageBox.Show($"La mission n°{txbEnCours.Text} est déjà pas terminée");
                    }
                    else
                    {
                        string requeteMaj = $"UPDATE Mission SET terminee = 0 WHERE id = {txbEnCours.Text}";
                        SQLiteCommand cdMaj = new SQLiteCommand();

                        cdMaj.Connection = connec;
                        cdMaj.CommandType = CommandType.Text;
                        cdMaj.CommandText = requeteMaj;
                        cdMaj.ExecuteNonQuery();

                        // Mettre à jour le DataSet MesDatas.DsGlobal pour la ligne concernée
                        MesDatas.DsGlobal.Tables["Mission"].Select($"id = {txbEnCours.Text}")[0]["terminee"] = false;

                        // Actualisation de l'interface
                        pnlMission.Controls.Clear();
                        RemplireToutTableauBord();

                        MessageBox.Show($"La mission n°{txbEnCours.Text} est pas finie");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la mise à jour");
                }
                finally
                {
                    Connexion.FermerConnexion();
                }
        }
    }
}
