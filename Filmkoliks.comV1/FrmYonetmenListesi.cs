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
using DataAccessLayer;
using EntityLayer;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmYonetmenListesi : Form
    {
        public FrmYonetmenListesi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void FrmYonetmenListesi_Load(object sender, EventArgs e)
        {
            ListePaneli.Controls.Clear();
            List<EntityYonetmenler> yonetmenler = BLYonetmenler.BLYonetmenListele();
            foreach (var yonetmen in yonetmenler)
            {
                YonetmenListesi arac = new YonetmenListesi();
                arac.lblId.Text = yonetmen.Id.ToString();
                arac.lblAdSoyad.Text = yonetmen.AdSoyad;
                arac.pBResimDetay.ImageLocation = yonetmen.Resim;
                ListePaneli.Controls.Add(arac);
            }
        }

        private void txtAramaYap_TextChanged(object sender, EventArgs e)
        {
            ListePaneli.Controls.Clear();
            List<EntityYonetmenler> yonetmenler = BLYonetmenler.BLYonetmenAra(txtAramaYap.Text);
            foreach (var yonetmen in yonetmenler)
            {
                YonetmenListesi arac = new YonetmenListesi();
                arac.lblId.Text = yonetmen.Id.ToString();
                arac.lblAdSoyad.Text = yonetmen.AdSoyad;
                arac.pBResimDetay.ImageLocation = yonetmen.Resim;
                ListePaneli.Controls.Add(arac);
            }
        }
    }
}
