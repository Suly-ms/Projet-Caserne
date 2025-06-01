using Pinpon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UC_ChoixVehicules;
using UserControlChoixPompier;
using UserControlChoixVehicules;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static UC_ChoixPompiers.UC_ChoixPompier;
using static UC_ChoixVehicules.UC_ChoixVehicule;

namespace SAE_A21_D21___Projet_Caserne
{
    public partial class FrmChoixVehiculesPompier : Form
    {
        private int m_natureSinistre;
        private int m_caserne;
        private List<DataRow> pompiers = new List<DataRow>();
        private DataRow[] pompiersTmp;
        private DataRow[] affectationPompiers;
        private DataRow[] habilitationPompiers;
        private List<DataRow> habilitationMission = new List<DataRow>();
        private int lastHabilitation;
        private DataSet pompierVehiculeEnregistre = new DataSet();
        private Dictionary<int, int> habilitationCompteurs = new Dictionary<int, int>();
        public FrmChoixVehiculesPompier()
        {
            InitializeComponent();
        }

        public FrmChoixVehiculesPompier(int natureSinitre, int caserne)
        {
            InitializeComponent();
            m_natureSinistre = natureSinitre;
            m_caserne = caserne;
        }

        private void frmChoixVehiculesPompier_Load(object sender, EventArgs e)
        {
            // Dictionnaire pour les images des véhicules
            Dictionary<string, Image> imagesVehicules = new Dictionary<string, Image>()
            {
                { "BRS", Image.FromFile("img/brs.jpg") },
                { "CCF", Image.FromFile("img/ccf.jpg") },
                { "EPA", Image.FromFile("img/epa.jpg") },
                { "FPT", Image.FromFile("img/fpt.jpg") },
                { "VCYN", Image.FromFile("img/vcyn.jpg") },
                { "VID", Image.FromFile("img/vid.jpg") },
                { "VPC", Image.FromFile("img/vpc.jpg") },
                { "VSAV", Image.FromFile("img/vsav.jpg") },
                { "VSS", Image.FromFile("img/vss.jpg") },
                { "VSR", Image.FromFile("img/vsr.jpg") }
            };

            // Table pour enregistrer les pompiers et véhicules choisis
            DataTable tableVehicule = new DataTable("Vehicules");
            tableVehicule.Columns.Add("Numero", typeof(int));
            tableVehicule.Columns.Add("Type", typeof(string));
            tableVehicule.Columns.Add("Caserne", typeof(int));
            pompierVehiculeEnregistre.Tables.Add(tableVehicule);

            DataTable tablePompier = new DataTable("Pompiers");
            tablePompier.Columns.Add("Nom", typeof(string));
            tablePompier.Columns.Add("Prenom", typeof(string));
            tablePompier.Columns.Add("Grade", typeof(string));
            tablePompier.Columns.Add("matricule", typeof(int));
            tablePompier.Columns.Add("habilitation", typeof(int));
            pompierVehiculeEnregistre.Tables.Add(tablePompier);

            int top = 10;
            int left = 20;

            try
            {
                int caserne = m_caserne;
                // Récupérer les Types de véhicules en fonction de l'ID du sinistre
                int natureSinistre = m_natureSinistre;
                DataRow[] typeVéhiculeDataRow = MesDatas.DsGlobal.Tables["Necessiter"].Select("idNatureSinistre = " + natureSinistre);
                List<string> listeTypes = new List<string>();
                foreach (DataRow r in typeVéhiculeDataRow)
                {
                    listeTypes.Add("'" + r["codeTypeEngin"].ToString() + "'");
                }

                // Récupérer les véhicules en fonction de la caserne choisit, des bon véhicules pour la mision et de savoir si ils sont en mission et si ils sont en panne
                List<DataRow> Vehicules = new List<DataRow>();
                foreach (string t in listeTypes)
                {
                    DataRow[] caserneTmp = MesDatas.DsGlobal.Tables["Caserne"].Select();
                    DataRow[] vehiculeTmp = MesDatas.DsGlobal.Tables["Engin"].Select($@"idCaserne = " + caserne + "AND codeTypeEngin = " + t + " AND enMission = 0 AND enPanne = 0");
                    if (vehiculeTmp.Length == 0)
                    {
                        for (int i = 0; i < caserneTmp.Count(); i++)
                        {
                            vehiculeTmp = MesDatas.DsGlobal.Tables["Engin"].Select($@"idCaserne = " + i + "AND codeTypeEngin = " + t + " AND enMission = 0 AND enPanne = 0");
                            if (vehiculeTmp.Length > 0)
                            {
                                Vehicules.AddRange(vehiculeTmp);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Vehicules.AddRange(vehiculeTmp);
                    }
                }
                // Ajouter dans le panel du choix des véhicules, les UC pour chosiir les véhicules
                for (int i = 0; i < Vehicules.Count; i++)
                {
                    var choixVehicule = new UC_ChoixVehicule
                    {
                        Top = top,
                        Left = left
                    };

                    String code = Vehicules[i]["codeTypeEngin"].ToString();


                    choixVehicule.VehiculeChoisi += UcVehicule_VehiculeChoisi;
                    choixVehicule.VehiculeNonChoisi += UcVehicule_VehiculeNonChoisi;
                    choixVehicule.ChargerDonnees(imagesVehicules[code], Convert.ToInt32(Vehicules[i]["numero"]), code, Convert.ToInt32(Vehicules[i]["idCaserne"]));

                    pnlChoixVehicule.Controls.Add(choixVehicule);
                    top += 110;
                }

                // Sélection des pompiers disponibles
                pompiersTmp = MesDatas.DsGlobal.Tables["Pompier"].Select("enMission = 0 AND enConge = 0");
                
                // Sélection des affectations des pompiers pour la caserne spécifiée
                affectationPompiers = MesDatas.DsGlobal.Tables["Affectation"].Select("idCaserne = " + caserne + " AND dateFin IS NULL");
                
                // Sélection des habilitations des pompiers
                habilitationPompiers = MesDatas.DsGlobal.Tables["Passer"].Select();

                // Sélection des habilitations nécessaires pour la mission
                foreach (string t in listeTypes)
                {
                    foreach(DataRow dr in MesDatas.DsGlobal.Tables["Embarquer"].Select("codeTypeEngin = " + t))
                    {
                        habilitationMission.Add(dr);
                    }
                }
                

                // Récupérer les pompiers de la caserne choisie
                foreach (DataRow r in pompiersTmp)
                {
                    int matricule = Convert.ToInt32(r["matricule"]);
                    foreach (DataRow r_affectation in affectationPompiers)
                    {
                        if (Convert.ToInt32(r_affectation["matriculePompier"]) == matricule)
                        {
                            pompiers.Add(r);
                            break; // Sortir de la boucle une fois le pompier trouvé
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex);
                return;
            }
        }

        private void AjouterOuMettreAJourBoutonHabilitation(int idHabilitation)
        {
            string nomHabilitation = MesDatas.DsGlobal.Tables["Habilitation"]
                .Select("id = " + idHabilitation)[0]["libelle"].ToString();

            int besoinTotal = 0;

            // Étape 1 : Calculer le besoin total pour tous les véhicules
            foreach (DataRow vehicule in pompierVehiculeEnregistre.Tables["Vehicules"].Rows)
            {
                string typeVehicule = vehicule["Type"].ToString();
                DataRow[] habilitations = MesDatas.DsGlobal.Tables["Embarquer"]
                    .Select($"codeTypeEngin = '{typeVehicule}' AND idHabilitation = {idHabilitation}");

                foreach (DataRow h in habilitations)
                {
                    besoinTotal += Convert.ToInt32(h["nombre"]);
                }
            }

            // Étape 2 : Calculer combien de pompiers déjà affectés ont cette habilitation
            int dejaAttribue = 0;
            if (pompierVehiculeEnregistre.Tables.Contains("Pompiers"))
            {
                foreach (DataRow pompier in pompierVehiculeEnregistre.Tables["Pompiers"].Rows)
                {
                    if (Convert.ToInt32(pompier["habilitation"]) == idHabilitation)
                    {
                        dejaAttribue++;
                    }
                }
            }

            // Étape 3 : Calcul du reste à affecter
            int restant = besoinTotal - dejaAttribue;

            // Mettre à jour le dictionnaire avec le nombre restant réel
            habilitationCompteurs[idHabilitation] = Math.Max(restant, 0);

            // Si plus de besoin, ne pas afficher le bouton
            if (restant <= 0)
                return;

            // Si le bouton existe déjà, on le met à jour
            foreach (Control ctrl in pnlChoixHabilitation.Controls)
            {
                if (ctrl is System.Windows.Forms.Button btn && (int)btn.Tag == idHabilitation)
                {
                    btn.Text = $"{nomHabilitation} x{restant}";
                    return;
                }
            }

            // Sinon, on le crée
            var bouton = new System.Windows.Forms.Button
            {
                Text = $"{nomHabilitation} x{restant}",
                Tag = idHabilitation,
                AutoSize = true,
                Top = pnlChoixHabilitation.Controls.Count * 50,
                Left = 20
            };

            bouton.Click += (s, e) => afficherPompier(s);
            pnlChoixHabilitation.Controls.Add(bouton);
        }


        private void afficherPompier(object sender)
        {
            var bouton = sender as System.Windows.Forms.Button;
            lastHabilitation = (int)bouton.Tag;

            pnlChoixPompier.Controls.Clear();
            int top = 10;
            int left = 20;

            int idHabilitationCliquee = (int)bouton.Tag;

            foreach (DataRow pompier in pompiers)
            {
                int matricule = Convert.ToInt32(pompier["matricule"]);

                // Vérifier si ce pompier a cette habilitation
                bool aHabilitation = habilitationPompiers.Any(h =>
                    Convert.ToInt32(h["matriculePompier"]) == matricule &&
                    Convert.ToInt32(h["idHabilitation"]) == idHabilitationCliquee
                );

                if (aHabilitation)
                {
                    var choixPompier = new UC_ChoixPompiers.UC_ChoixPompier
                    {
                        Top = top,
                        Left = left
                    };

                    choixPompier.PompierChoisi += UcPompier_PompierChoisi;
                    choixPompier.PompierNonChoisi += UcPompier_PompierNonChoisi;
                    String grade = pompier["codeGrade"].ToString();
                    String nom = pompier["nom"].ToString();
                    String prenom = pompier["prenom"].ToString();

                    bool present = false;
                    foreach (DataRow row in pompierVehiculeEnregistre.Tables["Pompiers"].Rows)
                    {
                        if (row["Nom"].ToString() == nom && row["Prenom"].ToString() == prenom)
                        {
                            present = true;
                        }
                    }

                    if (present)
                    {
                        choixPompier.ChargerDonnees(Image.FromFile("img/" + grade + ".png"), grade, nom, prenom, Color.Green);
                    }
                    else
                    {
                        choixPompier.ChargerDonnees(Image.FromFile("img/" + grade + ".png"), grade, nom, prenom, Color.Red);
                    }

                    pnlChoixPompier.Controls.Add(choixPompier);
                    top += 130;
                }
            }
        }

        private void UcVehicule_VehiculeChoisi(object sender, VehiculeChoisiEventArgs e)
        {
            // Ajouter une ligne au DataSet
            pompierVehiculeEnregistre.Tables["Vehicules"].Rows.Add(e.Numero, e.Type, e.Caserne);
            chargerDataSetPompierVehiculeEnregistre();
            // Recalculer tous les boutons d’habilitation (comme dans la suppression)
            pnlChoixHabilitation.Controls.Clear();

            var habilitations = MesDatas.DsGlobal.Tables["Habilitation"].Select();
            foreach (DataRow h in habilitations)
            {
                AjouterOuMettreAJourBoutonHabilitation(Convert.ToInt32(h["id"]));
            }
        }

        private void UcVehicule_VehiculeNonChoisi(object sender, VehiculeNonChoisiEventArgs e)
        {
            foreach (DataRow row in pompierVehiculeEnregistre.Tables["Vehicules"].Rows.Cast<DataRow>().ToList())
            {
                if ((int)row["Numero"] == e.Numero && row["Type"].ToString() == e.Type)
                {
                    row.Delete();
                }
            }
            pompierVehiculeEnregistre.Tables["Vehicules"].AcceptChanges();

            // Recalculer tous les boutons d’habilitation
            pnlChoixHabilitation.Controls.Clear();

            var habilitations = MesDatas.DsGlobal.Tables["Habilitation"].Select();
            foreach (DataRow h in habilitations)
            {
                AjouterOuMettreAJourBoutonHabilitation(Convert.ToInt32(h["id"]));
            }

            chargerDataSetPompierVehiculeEnregistre();

            if(pnlChoixHabilitation.Controls.Count == 0)
            {
                pnlChoixPompier.Controls.Clear();
                pompierVehiculeEnregistre.Tables["Pompiers"].Clear();
                chargerDataSetPompierVehiculeEnregistre();
            }
        }


        private void UcPompier_PompierChoisi(object sender, PompierChoisiEventArgs e)
        {
            DataRow[] Pompier = MesDatas.DsGlobal.Tables["Pompier"].Select(
                $"nom = '{e.Nom.Replace("'", "''")}' AND prenom = '{e.Prenom.Replace("'", "''")}'"
            );

            pompierVehiculeEnregistre.Tables["Pompiers"].Rows.Add(e.Nom, e.Prenom, e.Grade, Pompier[0]["matricule"], lastHabilitation);

            // Décrémenter le compteur
            if (habilitationCompteurs.ContainsKey(lastHabilitation))
            {
                habilitationCompteurs[lastHabilitation]--;

                // Mettre à jour le texte du bouton
                foreach (Control ctrl in pnlChoixHabilitation.Controls)
                {
                    if (ctrl is System.Windows.Forms.Button btn && (int)btn.Tag == lastHabilitation)
                    {
                        string nomHabilitation = btn.Text.Split('x')[0].Trim();
                        btn.Text = $"{nomHabilitation} x{habilitationCompteurs[lastHabilitation]}";
                        break;
                    }
                }
            }

            chargerDataSetPompierVehiculeEnregistre();
        }


        private void UcPompier_PompierNonChoisi(object sender, PompierNonChoisiEventArgs e)
        {
            foreach (DataRow row in pompierVehiculeEnregistre.Tables["Pompiers"].Rows.Cast<DataRow>().ToList())
            {
                if (row["Nom"].ToString() == e.Nom && row["Prenom"].ToString() == e.Prenom)
                {
                    int idHabilitation = (int)row["habilitation"];

                    row.Delete();

                    // Ré-incrémenter le compteur
                    if (habilitationCompteurs.ContainsKey(idHabilitation))
                    {
                        habilitationCompteurs[idHabilitation]++;

                        foreach (Control ctrl in pnlChoixHabilitation.Controls)
                        {
                            if (ctrl is System.Windows.Forms.Button btn && (int)btn.Tag == idHabilitation)
                            {
                                string nomHabilitation = btn.Text.Split('x')[0].Trim();
                                btn.Text = $"{nomHabilitation} x{habilitationCompteurs[idHabilitation]}";
                                break;
                            }
                        }
                    }
                }
            }

            pompierVehiculeEnregistre.Tables["Pompiers"].AcceptChanges();
            chargerDataSetPompierVehiculeEnregistre();
        }


        private void chargerDataSetPompierVehiculeEnregistre()
        {
            pnlPompierEnregistre.Controls.Clear();
            pnlVehiculeEnregistre.Controls.Clear();
            int top = 20;
            int left = 5;
            foreach(DataRow row in pompierVehiculeEnregistre.Tables["Vehicules"].Rows.Cast<DataRow>().ToList())
            {
                Label label = new Label();
                label.Text = row["Type"].ToString() + row["Numero"].ToString();
                label.Top = top;
                label.Left = left;
                label.Width = 55;
                label.AutoSize = false;
                pnlVehiculeEnregistre.Controls.Add(label);

                left += label.Width + 10;
            }

            left = 5;
            foreach (DataRow row in pompierVehiculeEnregistre.Tables["Pompiers"].Rows.Cast<DataRow>().ToList())
            {
                Label label = new Label();
                label.Text = row["Grade"].ToString() + " " + row["Nom"].ToString() + " " + row["Prenom"].ToString();
                label.Top = top;
                label.Left = left;
                label.AutoSize = true;
                pnlPompierEnregistre.Controls.Add(label);

                left += label.Width + 10;
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (habilitationCompteurs.Values.All(val => val == 0))
            {
                DataSet pompierVehiculeMission = pompierVehiculeEnregistre;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblPasAssezDePompier.Visible = true;
            }
        }

        public DataSet DataSetMission
        {
            get { return pompierVehiculeEnregistre; }
        }
    }
}
