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
using LogicLayer;
using EntityLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmFilmDetay : Form
    {
        public FrmFilmDetay()
        {
            InitializeComponent();
        }

        public string idNo = "";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void FrmFilmDetay_Load(object sender, EventArgs e)
        //{
        //    string sorgu = "SELECT * FROM Tbl_Filmler WHERE ID=@p1";
        //    baglanti.Open();
        //    SqlCommand komut = new SqlCommand(sorgu, baglanti);
        //    komut.Parameters.AddWithValue("@p1", idNo);
        //    SqlDataReader oku = komut.ExecuteReader();
        //    if (oku.Read())
        //    {
        //        pBResim.ImageLocation = oku["AFIS"].ToString();
        //        lblFilmAdi.Text = oku["ADI"].ToString();
        //        lblOzellikler.Text = oku["OZELLIKLERI"].ToString();
        //        lblTur.Text = oku["TURU"].ToString();
        //        lblOyuncular.Text = oku["OYUNCU"].ToString();
        //        lblYonetmen.Text = oku["YONETMEN"].ToString();
        //        lblVizyonTarihi.Text = oku["TARIH"].ToString();
        //        lblDetay.Text = oku["DETAY"].ToString();
        //        lblPuan.Text = oku["PUAN"].ToString();
        //    }
        //    baglanti.Close();
        //    vizyonTarihiHesapla();
        //}
        private void FrmFilmDetay_Load(object sender, EventArgs e)
        {
            // ID numarasını short tipine çeviriyoruz
            short filmId = Convert.ToInt16(idNo);

            // BL katmanından film detaylarını getiriyoruz
            EntityFilmler film = BLFilmler.BLFilmDetayGetir(filmId);

            if (film != null)
            {
                // Film bilgilerini UI öğelerine aktarıyoruz
                pBResim.ImageLocation = film.Afis;
                lblFilmAdi.Text = film.Adi;
                lblOzellikler.Text = film.Ozellikleri;
                lblTur.Text = film.Turu;
                lblOyuncular.Text = film.Oyuncu;
                lblYonetmen.Text = film.Yonetmen;
                lblVizyonTarihi.Text = film.Tarih;
                lblDetay.Text = film.Detay;
                lblPuan.Text = film.Puan;
            }

            vizyonTarihiHesapla(); // Vizyon tarihini hesapla ve durumu göster
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

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
