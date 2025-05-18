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

        public UC_DoubleBouton(int idMission)
        {
            InitializeComponent();

            m_idMission = idMission;
        }

        private void pctbClotureMission_Click(object sender, EventArgs e)
        {

        }

        private void pctbEditionPdf_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void pctbClotureMission_MouseEnter(object sender, EventArgs e)
        {
        }

        private void pctbEditionPdf_MouseMove(object sender, MouseEventArgs e)
        {
            pctbEditionPdf.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pctbClotureMission_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pctbEditionPdf_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pctbEditionPdf_MouseEnter(object sender, EventArgs e)
        {
        }

        private void pctbClotureMission_MouseHover(object sender, EventArgs e)
        {

        }

        private void pctbClotureMission_MouseMove(object sender, MouseEventArgs e)
        {
            pctbClotureMission.BorderStyle = BorderStyle.Fixed3D;

        }
    }
}
