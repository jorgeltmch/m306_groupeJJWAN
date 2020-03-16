/* 
 * Programme Rendev
 * Description:
 * Permet d'ajouter des evenements sur une carte et des les envoyer dans une base de donnée et de traiter ces données
 * Version 1.0
 */

using GMap.NET;
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
    public partial class frmAddModif : Form
    {
        private Map _map;
        private bool _isAdding;
        internal Map Map { get => _map; set => _map = value; }

        public frmAddModif(Event paramEventModifying = null)
        {
            InitializeComponent();
            if (paramEventModifying == null)
            {
                _isAdding = true;
            }
            else
            {
                _isAdding = false;
                tbxNomEvent.Text = paramEventModifying.Name;
                tbxDescriptionEvent.Text = paramEventModifying.Description;
                dtpDateEvent.Value = paramEventModifying.Date;
                cmbCategoriEvent.SelectedValue = paramEventModifying.Category.Id;
            }
            Map = new Map(ModifMap);
            Map.MapControl.MouseClick += MapControl_MouseClick;
        }

        private void MapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateAddress();
            }
        }

        private void btnConfirmEvent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx.Text) && !string.IsNullOrEmpty(tbxDescriptionEvent.Text) && !string.IsNullOrEmpty(tbxNomEvent.Text) && cmbCategoriEvent.SelectedItem != null && dtpDateEvent.Value != null)
            {
                if (_isAdding)
                {
                    int id = Convert.ToInt32(DataManager.GetInstance().AddDataPosition(Map.MouseClickMarker.Position.Lat, Map.MouseClickMarker.Position.Lng));
                    DataManager.GetInstance().AddDataEvent(tbxNomEvent.Text, tbxDescriptionEvent.Text, dtpDateEvent.Value, id, (int) cmbCategoriEvent.SelectedValue);
                }
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis pour pouvoir créer/modifier l'évenement");
            }
        }

        private void frmAddModif_Load(object sender, EventArgs e)
        {
            UpdateAddress();
            UpdateCategorie();
        }

        private void UpdateAddress()
        {
            if (Map.MouseClickMarker.Position != null)
            {
                try
                {
                    tbx.Text = Map.GetAddressFromLatLon(Map.MouseClickMarker.Position);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Can't find the given address");
                }
            }
        }

        private void UpdateCategorie()
        {
            List<Category> values = DataManager.GetInstance().Categories;
            if (values != null)
            {
                BindingList<Category> source = new BindingList<Category>(values);
                cmbCategoriEvent.DataSource = source;
                cmbCategoriEvent.DisplayMember = "Name";
                cmbCategoriEvent.ValueMember = "Id";
                Category other = new Category(999, "Other", Constants.EVENT_MARKER_TYPE);
                source.Add(other);
                source = new BindingList<Category>(source.GroupBy(c => c.Name).Select(g => g.First()).ToList());
                cmbCategoriEvent.DataSource = source;
            }
        }

        public string GetName()
        {
            return tbxNomEvent.Text;
        }

        public string GetDecription()
        {
            return tbxDescriptionEvent.Text;
        }

        public PointLatLng GetPosition()
        {
            return Map.MouseClickMarker.Position;
        }

        public Category GetCategory()
        {
            return DataManager.GetInstance().GetCategoryByIdIfExist((int) cmbCategoriEvent.SelectedValue);
        }

        public DateTime GetDate()
        {
            return dtpDateEvent.Value;
        }

        /// <summary>
        /// Changement d'item dans le combobox ouvre la forme pour ajouter une catégorie
        /// </summary>
        private void cmbCategoriEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoriEvent.SelectedItem != null)
            {
                // Verifie si dans le comboBox on selectionne Other
                if (cmbCategoriEvent.GetItemText(cmbCategoriEvent.SelectedItem) == "Other")
                {
                    frmCategory frmCategory = new frmCategory();

                    // Ouvre la forme pour ajouter une catégorie
                    if (frmCategory.ShowDialog() == DialogResult.OK)
                    {
                        UpdateCategorie(); //On met à jour les catégories
                    }
                }
            }
        }
    }
}
