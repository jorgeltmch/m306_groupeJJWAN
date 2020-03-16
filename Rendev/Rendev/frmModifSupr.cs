using System.Windows.Forms;

namespace Rendev
{
    public partial class frmModifSupr : Form
    {
        Event _selectedEvent;

        public frmModifSupr(Event paramEvent)
        {
            InitializeComponent();
            if (paramEvent != null)
            {
                _selectedEvent = paramEvent;
                tbxAdresse.Text = _selectedEvent.Adress;
                tbxLieu.Text = _selectedEvent.Name;
            }
        }


        public bool RadioButtonDelete()
        {
            return rdbSuppr.Checked;
        }
    }
}
