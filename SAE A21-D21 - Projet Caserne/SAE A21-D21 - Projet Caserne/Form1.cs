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
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;

// Utilise les fichiers Connexion.cs et mesDatas.cs
using Pinpon;
using UC_DoubleBoutonImage;
using UC_RecapMission;
using static System.Windows.Forms.LinkLabel;
using Org.BouncyCastle.Asn1.IsisMtt.X509;

namespace SAE_A21_D21___Projet_Caserne
{
    public partial class frmTableauDeBord : Form
    {
        public frmTableauDeBord()
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

        private string TrouverCaserne(int idMission)
        {
            DataTable tableCaserne = MesDatas.DsGlobal.Tables["Caserne"];
            DataRow[] casernes = tableCaserne.Select($"id = {TrouverIdCaserne(idMission)}");

            return casernes[0]["nom"].ToString();
        }

        private string TrouverIdCaserne(int idMission)
        {
            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMissions.Select($"id = {idMission}");

            return missions[0]["idCaserne"].ToString();
        }

        private int TrouverIdSinistre(int idMission)
        {
            DataTable tableMission = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMission.Select($"id = {idMission}");

            return Convert.ToInt16(missions[0]["idNatureSinistre"]);
        }

        private string TrouverSinistre(int idMission)
        {
            int idSinistre = TrouverIdSinistre(idMission);

            DataTable tableSinistre = MesDatas.DsGlobal.Tables["NatureSinistre"];
            DataRow[] sinistres = tableSinistre.Select($"id = {idSinistre}");

            return sinistres[0]["libelle"].ToString();
        }

        private DateTime TrouverDateDepart(int idMission)
        {
            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMissions.Select($"id = {idMission}");

            return Convert.ToDateTime(missions[0]["dateHeureDepart"]);
        }

        private DateTime TrouverDateRetour(int idMission)
        {
            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMissions.Select($"id = {idMission}");

            try
            {
                return Convert.ToDateTime(missions[0]["dateHeureRetour"]);
            }

            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        private string TrouverMotif(int idMission)
        {
            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMissions.Select($"id = {idMission}");

            return missions[0]["motifAppel"].ToString();
        }

        private string TrouverRendu(int idMission)
        {
            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMissions.Select($"id = {idMission}");

            return missions[0]["compteRendu"].ToString();
        }

        private bool EstTerminee(int idMission)
        {
            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMissions.Select($"id = {idMission}");

            return Convert.ToBoolean(missions[0]["terminee"]);
        }

        private string TrouverAdresse(int idMission)
        {
            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMissions.Select($"id = {idMission}");

            string adresse = Convert.ToString(missions[0]["adresse"]);
            string ville = Convert.ToString(missions[0]["ville"]);
            string codePostal = Convert.ToString(missions[0]["cp"]);

            string res = "";

            if (adresse != "")
            {
                res += adresse;
            }

            if (ville != "")
            {
                res += $"{(res == "" ? "" : ", ") + ville} ";
            }

            if (codePostal != "")
            {
                res += $"({codePostal})";
            }

            return res;
        }

        private int[] TrouverMatriculesPompier(int idMission)
        {
            DataTable tableMobilisers = MesDatas.DsGlobal.Tables["Mobiliser"];
            DataRow[] mobilisations = tableMobilisers.Select($"idMission = {idMission}");

            int[] matriculues = new int[mobilisations.Length];

            for (int i = 0; i < mobilisations.Length; i++)
            {
                matriculues[i] = Convert.ToInt16(mobilisations[i]["matriculePompier"]);
            }

            return matriculues;
        }

        private int TrouverIdHabilitation(int matricule)
        {
            DataTable tableMobilisers = MesDatas.DsGlobal.Tables["Mobiliser"];
            DataRow[] mobilisations = tableMobilisers.Select($"matriculePompier = {matricule}");

            return Convert.ToInt16(mobilisations[0]["idHabilitation"]);
        }

        private string TrouverHabilitation(int matricule)
        {
            int idHabilitation = TrouverIdHabilitation(matricule);

            DataTable tableHabilitations = MesDatas.DsGlobal.Tables["Habilitation"];
            DataRow[] habilitations = tableHabilitations.Select($"id = {idHabilitation}");

            return Convert.ToString(habilitations[0]["libelle"]);
        }

        private string TrouverGrade(string codeGrade)
        {
            DataTable tableGrades = MesDatas.DsGlobal.Tables["Grade"];
            DataRow[] grades = tableGrades.Select($"code = '{codeGrade}'");

            return Convert.ToString(grades[0]["libelle"]);
        }

        private string[] TrouverPompiersAffectes(int idMission)
        {
            int[] matricules = TrouverMatriculesPompier(idMission);
            DataTable tablePompiers = MesDatas.DsGlobal.Tables["Pompier"];
            string[] pompiers = new string[matricules.Length];

            for (int i = 0; i < matricules.Length; i++)
            {
                DataRow[] tmp = tablePompiers.Select($"matricule = {matricules[i]}");

                DataRow row = tmp[0];
                pompiers[i] = $"{TrouverGrade(row["codeGrade"].ToString())} {row["nom"].ToString().ToUpper()} {row["prenom"].ToString()} ({TrouverHabilitation(Convert.ToInt16(row["matricule"]))})";
            }

            return pompiers;
        }

        private string TrouverNomEngin(string code)
        {
            DataTable tableTypeEngin = MesDatas.DsGlobal.Tables["TypeEngin"];
            DataRow[] type = tableTypeEngin.Select($"code = '{code}'");

            return type[0]["nom"].ToString();
        }

        private string[] TrouverEnginsUtilises(int idMission)
        {
            DataTable tablePartir = MesDatas.DsGlobal.Tables["PartirAvec"];
            DataRow[] partir = tablePartir.Select($"idMission = {idMission}");

            string[] engins = new string[partir.Length];

            for (int i = 0; i < partir.Length; i++)
            {
                string reparation = partir[i]["reparationsEventuelles"].ToString() == "" ? "Pas de réparations prévues" : partir[i]["reparationsEventuelles"].ToString();
                string codeEngin = partir[i]["codeTypeEngin"].ToString();

                engins[i] = $"{TrouverNomEngin(codeEngin)} {partir[i]["idCaserne"]}-{codeEngin}-{partir[i]["numeroEngin"]} ({reparation})";
            }

            return engins;
        }

        private void ckbEnCours_CheckedChanged(object sender, EventArgs e)
        {
            RemplireToutTableauBord();
        }

        private void GenererPdf(UC_DoubleBouton uc)
        {
            int idMission = uc.getId();

            DataTable tableMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataRow[] missions = tableMissions.Select($"id = {idMission}");

            DateTime dateDepartMission = TrouverDateDepart(idMission);
            DateTime dateRetourMission = TrouverDateRetour(idMission);
            string caserneMission = TrouverCaserne(idMission);
            string motifMission = TrouverMotif(idMission) == "" ? "Aucun motif renseigné" : TrouverMotif(idMission);
            string renduMission = TrouverRendu(idMission) == "" ? "Aucun compte rendu" : TrouverRendu(idMission);
            string statusMission = EstTerminee(idMission) ? "Terminée" : "En cours";
            string adresseMission = TrouverAdresse(idMission) == "" ? "Aucune adresse renseignée" : TrouverAdresse(idMission);
            string sinistreMission = TrouverSinistre(idMission);

            // Declaration du chemin du fichier PDF
            string chemin = $"Mission_{idMission}.pdf";

            // Declaration et initialisation du Document, du FileStream et du PdfWriter
            Document pdf = new Document();
            FileStream fs = new FileStream(chemin, FileMode.Create);
            PdfWriter.GetInstance(pdf, fs);

            pdf.Open();

            Font titreFont = FontFactory.GetFont("Arial" /*Police*/ , 23 /*Taille*/ , 1 /*Gras*/);
            Font partieFont = FontFactory.GetFont("Arial" /*Police*/ , 17 /*Taille*/ , 1 /*Gras*/);
            Font importantFont = FontFactory.GetFont("Arial" /*Police*/ , 14 /*Taille*/ , 1 /*Gras*/);
            Font normalFont = FontFactory.GetFont("Arial" /*Police*/ , 14 /*Taille*/ , 0 /*Normal*/);

            // Ecriture du fichier PDF
            Paragraph paragraphTitre = new Paragraph($"Rapport de mission", titreFont);
            Paragraph paragraphStatus = new Paragraph($"{statusMission}\n\n", normalFont);

            // Centrer le titre et le status
            paragraphTitre.Alignment = Element.ALIGN_CENTER;
            paragraphStatus.Alignment = Element.ALIGN_CENTER;

            // Ajouter le titre au PDF
            pdf.Add(paragraphTitre);

            // Ajouter el status au PDF
            pdf.Add(paragraphStatus);

            pdf.Add(new Paragraph($"Déclenchée le {dateDepartMission.Day.ToString("00")}-{dateDepartMission.Month.ToString("00")}-{dateDepartMission.Year.ToString("00")} à {dateDepartMission.Hour.ToString("00")}h{dateDepartMission.Minute.ToString("00")}", importantFont));

            // Verification de si il y a une date de retour
            if (dateRetourMission != DateTime.MinValue)
            {
                pdf.Add(new Paragraph($"Retour le {dateRetourMission.Day.ToString("00")}-{dateRetourMission.Month.ToString("00")}-{dateRetourMission.Year.ToString("00")} à {dateRetourMission.Hour.ToString("00")}h{dateRetourMission.Minute.ToString("00")}", importantFont));
            }
            else
            {
                pdf.Add(new Paragraph($"Pas encore de date de retour car la mission est en cours", importantFont));
            }
            
            pdf.Add(new Paragraph($"----------------------------------------------------------------------------------------------------------------\n\n", importantFont));
            pdf.Add(new Paragraph($"Type de sinistre : {sinistreMission}\n\n", partieFont));
            pdf.Add(new Paragraph($"Motif : {motifMission}", importantFont));
            pdf.Add(new Paragraph($"Adresse : {adresseMission}\n\n", importantFont));
            pdf.Add(new Paragraph($"Compte-rendu : {renduMission}", importantFont));
            pdf.Add(new Paragraph($"----------------------------------------------------------------------------------------------------------------\n\n", importantFont));
            pdf.Add(new Paragraph($"Caserne : {caserneMission}\n\n", partieFont));


            // Remplir les pompiers affectés dans le PDF
            pdf.Add(new Paragraph($"Pompiers affectés :", partieFont));
            string[] pompiers = TrouverPompiersAffectes(idMission);
            foreach(string pompier in pompiers)
            {
                pdf.Add(new Paragraph($"--> {pompier}", normalFont));
            }

            // Remplir les engins utilisés dans le PDF
            pdf.Add(new Paragraph($"\nEngins utilisés :", partieFont));
            string[] engins = TrouverEnginsUtilises(idMission);
            foreach (string engin in engins)
            {
                pdf.Add(new Paragraph($"--> {engin}", normalFont));
            } 

            pdf.Close();
        }

        private void DblBtn_BoutonClique(object sender, string bouton)
        {
            var uc = sender as UC_DoubleBouton;
            if (uc != null)
            {
                int idMission = uc.getId();
                if (bouton == "ClotureMission")
                {
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

                            GenererPdf(uc);

                            MessageBox.Show($"La mission n°{idMission} est achevée et son PDF à été généré");
                        }
                    }
                    catch (Exception)
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
                    GenererPdf(uc);
                    MessageBox.Show($"Le PDF de la mission n°{idMission} à été généré");
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
                catch (Exception)
                {
                    MessageBox.Show("Erreur lors de la mise à jour");
                }
                finally
                {
                    Connexion.FermerConnexion();
                }
        }
        private void pnlTableauBord_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
