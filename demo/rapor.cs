using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class rapor : Form
    {
        public rapor()
        {
            InitializeComponent();
        }

        private void yardim_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'veritabaniDataSet2.gunluk' table. You can move, or remove it, as needed.
            this.gunlukTableAdapter1.Fill(this.veritabaniDataSet2.gunluk);
            // TODO: This line of code loads data into the 'veritabaniDataSet2.gunluk' table. You can move, or remove it, as needed.
            //this.gunlukTableAdapter.Fill(this.veritabaniDataSet2.gunluk);
            // TODO: This line of code loads data into the 'veritabaniDataSet.gunluk' table. You can move, or remove it, as needed.
            //this.gunlukTableAdapter1.Fill(this.veritabaniDataSet.gunluk);
            // TODO: This line of code loads data into the 'veritabaniDataSet1.gunluk' table. You can move, or remove it, as needed.
            //this.gunlukTableAdapter.Fill(this.veritabaniDataSet1.gunluk);

            this.reportViewer1.RefreshReport();
        }
    }
}
