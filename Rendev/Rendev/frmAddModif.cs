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

        public frmAddModif(bool paramIsAdding)
        {
            InitializeComponent();
            _isAdding = paramIsAdding;
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
            if (!string.IsNullOrEmpty(tbx.Text) && !string.IsNullOrEmpty(tbxDescriptionEvent.Text) && !string.IsNullOrEmpty(tbxNomEvent.Text) && cmbCategoriEvent.SelectedItem.ToString() != null && dtpDateEvent.Value != null)
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
                cmbCategoriEvent.DataSource = new BindingSource(values, null);
                cmbCategoriEvent.DisplayMember = "Name";
                cmbCategoriEvent.ValueMember = "Id";
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
            return DataManager.GetInstance().GetCategoryByIdIfExist((int)cmbCategoriEvent.SelectedValue);
        }
        public DateTime GetDate()
        {
            return dtpDateEvent.Value;
        }
    }
}
