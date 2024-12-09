using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using DataAccessLayer;
using EntityLayer;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmBiletSorgula : Form
    {
        public FrmBiletSorgula()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (txtBiletNo.Text != "")
            {
                // Bilet kodunu alıyoruz
                string biletKod = txtBiletNo.Text.ToString();

                // BL katmanından bilet verisini alıyoruz
                EntityBiletler bilet = BLBiletler.BiletSorgula(biletKod);

                // Bilet bulunduysa detayları gösteriyoruz
                if (bilet != null)
                {
                    FrmBiletDetay frm = new FrmBiletDetay();
                    frm.biletNo = bilet.BKod; // Detay formunda bilet numarasını göstermek
                    txtBiletNo.Text = "";
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("KAYITLI BİLET BULUNAMADI!");
                }
            }
            else
            {
                MessageBox.Show("LÜTFEN BİLET NUMARASI GİRİNİZ!");
            }
        }
    }
}
