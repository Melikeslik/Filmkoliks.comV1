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

namespace Filmkoliks.comV1
{
    public partial class FrmFilmDetay : Form
    {
        public FrmFilmDetay()
        {
            InitializeComponent();
        }

        //connectionstring
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");

        public string idNo = "";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFilmDetay_Load(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM Tbl_Filmler WHERE ID=@p1";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@p1", idNo);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                pBResim.ImageLocation = oku["AFIS"].ToString();
                lblFilmAdi.Text = oku["ADI"].ToString();
                lblOzellikler.Text = oku["OZELLIKLERI"].ToString();
                lblTur.Text = oku["TURU"].ToString();
                lblOyuncular.Text = oku["OYUNCU"].ToString();
                lblYonetmen.Text = oku["YONETMEN"].ToString();
                lblVizyonTarihi.Text = oku["TARIH"].ToString();
                lblDetay.Text = oku["DETAY"].ToString();
                lblPuan.Text = oku["PUAN"].ToString();
            }
            baglanti.Close();
            vizyonTarihiHesapla();
        }

        void vizyonTarihiHesapla()
        {
            DateTime dVTarih = Convert.ToDateTime(lblVizyonTarihi.Text);
            DateTime bugunTarihi = DateTime.Today;

            //timeSpan ---> Varolan iki tarih arasındaki gün,ay,yıl,saat vb gibi sayısal verileri belirlemeye yarar.

            TimeSpan tSpan = dVTarih - bugunTarihi;
            int gunSayisi = tSpan.Days;

            if (tSpan.TotalDays <= 0)
            {
                lblDurum.Text = " FİLM VİZYONDA!";
            }
            else
            {
                lblDurum.Text = "FİLM " + gunSayisi + " GÜN SONRA VİZYONA GİRECEK :)";
            }
        }
    }
}
