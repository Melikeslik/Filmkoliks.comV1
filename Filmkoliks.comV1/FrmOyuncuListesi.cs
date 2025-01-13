using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using EntityLayer;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmOyuncuListesi : Form
    {
        public FrmOyuncuListesi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOyuncuListesi_Load(object sender, EventArgs e)
        {
            ListePaneli.Controls.Clear();
            List<EntityOyuncular> oyuncular = BLOyuncular.BLOyuncuListesiGetir();

            foreach (var oyuncu in oyuncular)
            {
                OyuncuListesi arac = new OyuncuListesi();
                arac.lblId.Text = oyuncu.Id.ToString();
                arac.lblAdSoyad.Text = oyuncu.AdSoyad.ToString();
                arac.pBResimDetay.ImageLocation = oyuncu.Resim.ToString();
                ListePaneli.Controls.Add(arac);
            }
        }

        private void txtAramaYap_TextChanged(object sender, EventArgs e)
        {
            ListePaneli.Controls.Clear();
            List<EntityOyuncular> oyuncular = BLOyuncular.BLOyuncuAra(txtAramaYap.Text);
            foreach (var oyuncu in oyuncular)
            {
                OyuncuListesi arac = new OyuncuListesi();
                arac.lblId.Text = oyuncu.Id.ToString();
                arac.lblAdSoyad.Text = oyuncu.AdSoyad;
                arac.pBResimDetay.ImageLocation = oyuncu.Resim.ToString();
                ListePaneli.Controls.Add(arac);
            }
        }
    }
}
