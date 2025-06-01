using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC_ChoixPompiers
{
    public partial class UC_ChoixPompier: UserControl
    {
        public event EventHandler<PompierChoisiEventArgs> PompierChoisi;
        public event EventHandler<PompierNonChoisiEventArgs> PompierNonChoisi;
        private string m_nom, m_prenom;
        public UC_ChoixPompier()
        {
            InitializeComponent();
        }

        public void ChargerDonnees(Image image, string grade, string nom, string prenom, Color couleurBouton)
        {
            m_nom = nom;
            m_prenom = prenom;
            pbGrade.Image = image;
            pbGrade.SizeMode = PictureBoxSizeMode.StretchImage;
            lblGrade.Text = grade;
            lblNom.Text = $"{nom} {prenom}";
            btnChoisi.BackColor = couleurBouton;
        }

        private void btnChoisi_Click(object sender, EventArgs e)
        {
            if (btnChoisi.BackColor == Color.Red)
            {
                PompierChoisi?.Invoke(this, new PompierChoisiEventArgs
                {
                    Nom = m_nom,
                    Prenom = m_prenom,
                    Grade = lblGrade.Text
                });
                btnChoisi.BackColor = Color.Green;
            }
            else
            {
                PompierNonChoisi?.Invoke(this, new PompierNonChoisiEventArgs
                {
                    Nom = m_nom,
                    Prenom = m_prenom
                });
                btnChoisi.BackColor = Color.Red;
            }
        }

        public class PompierChoisiEventArgs : EventArgs
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Grade { get; set; }
        }

        private void UC_ChoixPompier_Load(object sender, EventArgs e)
        {

        }

        public class PompierNonChoisiEventArgs : EventArgs
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
        }
    }
}
