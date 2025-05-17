using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC_RecapMission
{
    public partial class UC_AffichageMission: UserControl
    {
        private int m_id;
        private DateTime m_date;
        private string m_caserne;
        private string m_motif;
        private string m_rendu;

        public UC_AffichageMission(int id, DateTime date, string caserne, string motif, string rendu)
        {
            InitializeComponent();

            m_id = id;
            m_date = date;
            m_caserne = caserne;
            m_motif = motif;
            m_rendu = rendu;

            lblId.Text = $"Mission n° {id}";
            lblDateDepart.Text = $"Début le {date.Day}/{date.Month}/{date.Year}";
            lblCaserne.Text = $"Caserne : {caserne}";
            lblMotif.Text = motif;
            lblCompteRendu.Text = $"--> {(rendu == "" ? "Aucun compte rendu" : rendu)}";

        }

        public int getId()
        {
            return m_id;
        }

        public DateTime getDate()
        {
            return m_date;
        }

        private void UC_AffichageMission_Load(object sender, EventArgs e)
        {

        }
    }
}
