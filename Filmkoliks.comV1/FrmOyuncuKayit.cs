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

namespace Filmkoliks.comV1
{
    public partial class FrmOyuncuKayit : Form
    {
        public FrmOyuncuKayit()
        {
            InitializeComponent();
        }

        //connectionstring
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");

        public string resimYolu = " ";
        public string cinsiyet = "0";
        public string bYas = "00";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "RESİM SEÇME EKRANI";
            ofd.Filter = "PNG | *.png  | JPG -JPEG  | *.jpg; *.jpeg | All Files  | *.* ";
            ofd.FilterIndex = 3;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //resim alma işlemini bu alanda ya da bu kısımda gerçekleştireceğiz.

                pBResim.Image = new Bitmap(ofd.FileName);
                resimYolu = ofd.FileName.ToString();
            }
        }

        private void rBErkek_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "0";
        }

        private void rBKadin_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "1";
        }

        void yasHesaplama()
        {
            string dogum = nGun.Value.ToString() + "-" + nAy.Value.ToString() + "-" + nYil.Value.ToString();

            DateTime dogumTarihi = Convert.ToDateTime(dogum);
            DateTime bugun = DateTime.Today;
            int yas = bugun.Year - dogumTarihi.Year;
            // MessageBox.Show(yas.ToString());

            bYas = yas.ToString();
        }

        void aracTemizle()
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtBiyografi.Text = "";
            nGun.Value = 1;
            nAy.Value = 1;
            nYil.Value = 2024;
            rBErkek.Checked = true;
            rBKadin.Checked = false;
            lblKarakter.Text = "300";
            cinsiyet = "0";
            bYas = "00";
            pBResim.ImageLocation = @"C:\Users\mnurk\Desktop\NOGÖRSEL.png";
            txtAd.Focus();
        }

        private void txtBiyografi_TextChanged(object sender, EventArgs e)
        {
            int karakterSayisi = txtBiyografi.Text.Length;
            int geri = 300 - karakterSayisi;
            lblKarakter.Text = geri.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            yasHesaplama();
            string mesaj = "";

            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                mesaj += "Ad alanı boş!\n";
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                mesaj += "Soyad alanı boş!\n";
            }

            if (string.IsNullOrWhiteSpace(txtBiyografi.Text))
            {
                mesaj += "Biyografi alanı boş!\n";
            }

            if (string.IsNullOrWhiteSpace(resimYolu))
            {
                mesaj += "Resim yüklenmemiş!\n";
            }

            if (string.IsNullOrEmpty(mesaj))
            {
                string adSoyad = txtAd.Text.ToString().ToUpper() + " " + txtSoyad.Text.ToString().ToUpper();
                //ToUpper() komudumuz var olan karakterlerin tümünü büyük harfe çevirir.
                baglanti.Open();
                SqlCommand kayit = new SqlCommand("insert into Tbl_Oyuncular (ADSOYAD, CINSIYET,YAS,BIYOGRAFI,RESIM) VALUES (@p1,@p2,@p3,@p4,@p5)", baglanti);
                kayit.Parameters.AddWithValue("@p1", adSoyad);
                kayit.Parameters.AddWithValue("@p2", cinsiyet);
                kayit.Parameters.AddWithValue("@p3", bYas);
                kayit.Parameters.AddWithValue("@p4", txtBiyografi.Text.ToString().ToUpper());
                kayit.Parameters.AddWithValue("@p5", resimYolu);
                kayit.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("OYUNCU KAYIT İŞLEMİ BAŞARILI BİR ŞEKİLDE GERÇEKLEŞTİRİLDİ.");
                //ARAÇ TEMİZLEME KOMUTU YAZMAMIZ GEREKECEK.
                aracTemizle();
            }
            else
            {
                MessageBox.Show(mesaj);
            }
        }

        private void FrmOyuncuKayit_Load(object sender, EventArgs e)
        {

        }
    }
}
