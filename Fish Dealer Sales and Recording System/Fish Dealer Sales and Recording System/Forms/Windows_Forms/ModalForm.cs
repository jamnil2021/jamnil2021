using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public partial class ModalForm : Form
    {
        private List<PrintDataPropertiesModel> _summaryData = new List<PrintDataPropertiesModel>();
        private DataGridView form;
        public ModalForm(List<PrintDataPropertiesModel> _summaryData, DataGridView form)
        {
            InitializeComponent();
            this._summaryData = _summaryData;
            this.form = form;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModalForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(form.Location.X + form.Width, form.Location.Y);
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            using (ShowData data = new ShowData(_summaryData, true))
            {
                data.ShowDialog();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            using (PrintReport report = new PrintReport(_summaryData, true))
            {
                report.ShowDialog();
            }
        }
    }
}
