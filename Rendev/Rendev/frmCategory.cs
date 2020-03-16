/* 
 * Programme Rendev
 * Description:
 * Permet d'ajouter des evenements sur une carte et des les envoyer dans une base de donnée et de traiter ces données
 * Version 1.0
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rendev
{
    public partial class frmCategory : Form
    {

        public frmCategory()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbxCategory.Text != null)
            {
                // Ajout d'une categorie
                DataManager addCategory = DataManager.GetInstance();
                addCategory.AddDataCategory(tbxCategory.Text);
            }
        }

        private void tbxCategory_TextChanged(object sender, EventArgs e)
        {
            // Active ou desactive le button Ok
            if (tbxCategory.Text != string.Empty)
            {
                btnOk.Enabled = true;
            }
            else
            {
                btnOk.Enabled = false;
            }
        }
    }
}
