using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC_DoubleBoutonImage
{
    public partial class UC_DoubleBouton: UserControl
    {
        private int m_idMission;

        public event EventHandler<string> BoutonClique;

        public UC_DoubleBouton(int idMission)
        {
            InitializeComponent();

            m_idMission = idMission;
        }

        public int getId()
        {
            return m_idMission;
        }

        private void pctbClotureMission_Click(object sender, EventArgs e)
        {
            BoutonClique.Invoke(this, "ClotureMission");
        }

        private void pctbEditionPdf_Click(object sender, EventArgs e)
        {
            BoutonClique.Invoke(this, "EditionPdf");
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void pctbClotureMission_MouseEnter(object sender, EventArgs e)
        {
            pctbClotureMission.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pctbEditionPdf_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pctbClotureMission_MouseLeave(object sender, EventArgs e)
        {
            pctbClotureMission.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pctbEditionPdf_MouseLeave(object sender, EventArgs e)
        {
            pctbEditionPdf.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pctbEditionPdf_MouseEnter(object sender, EventArgs e)
        {
            pctbEditionPdf.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pctbClotureMission_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pctbClotureMission_MouseMove(object sender, MouseEventArgs e)
        {
            

        }
    }
}
