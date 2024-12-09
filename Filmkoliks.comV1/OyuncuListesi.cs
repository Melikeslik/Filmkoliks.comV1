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
using EntityLayer;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class OyuncuListesi : UserControl
    {
        public OyuncuListesi()
        {
            InitializeComponent();
        }

        //connectionstring
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");


        private void OyuncuListesi_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from Tbl_Oyuncular WHERE ID=@P1";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@p1", lblId.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                lblCinsiyet.Text = oku["CINSIYET"].ToString();
            }
            baglanti.Close();

            if (lblCinsiyet.Text == "0")
            {
                //erkek
                pbCinsiyet.Image = (System.Drawing.Image)(Properties.Resources.erkek);
            }
            else
            {
                //kadın
                pbCinsiyet.Image = (System.Drawing.Image)(Properties.Resources.kadin);
            }
        }

        //private void OyuncuListesi_Load(object sender, EventArgs e)
        //{
        //    // Oyuncu ID'yi alıyoruz
        //    short oyuncuId = Convert.ToInt16(lblId.Text);

        //    // BL katmanından oyuncu bilgilerini alıyoruz
        //    EntityOyuncular oyuncu = BLOyuncular.OyuncuGetir(oyuncuId);

        //    // Eğer oyuncu bilgisi döndü ise, bilgileri UI'ye aktar
        //    if (oyuncu != null)
        //    {
        //        lblCinsiyet.Text = oyuncu.Cinsiyet;

        //        if (oyuncu.Cinsiyet == "0")
        //        {
        //            // Erkek
        //            pbCinsiyet.Image = (System.Drawing.Image)(Properties.Resources.erkek);
        //        }
        //        else
        //        {
        //            // Kadın
        //            pbCinsiyet.Image = (System.Drawing.Image)(Properties.Resources.kadin);
        //        }
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from Tbl_Oyuncular Where ID= @p1", baglanti);
            sil.Parameters.AddWithValue("@p1", lblId.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(lblAdSoyad.Text + " Kişisine Ait Kayıt Silinmiştir!");
            this.Hide(); // UserControl aracımızı gizledik.Tüm araçlar gizlenmeyecektir. Sadece silmiş olduğumuz satır ekrandan kaldırılır.
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    short oyuncuId = Convert.ToInt16(lblId.Text); // Oyuncunun ID'sini alıyoruz

        //    // BL katmanındaki OyuncuSil metodunu çağırıyoruz
        //    bool silindi = BLOyuncular.OyuncuSil(oyuncuId);

        //    if (silindi)
        //    {
        //        MessageBox.Show(lblAdSoyad.Text + " Kişisine Ait Kayıt Silinmiştir!");
        //        this.Hide(); // UserControl aracımızı gizledik. Tüm araçlar gizlenmeyecektir. Sadece silmiş olduğumuz satır ekrandan kaldırılır.
        //    }
        //    else
        //    {
        //        MessageBox.Show("Silme işlemi başarısız oldu.");
        //    }
        //}

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from Tbl_Oyuncular WHERE ID=@P1";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@p1", lblId.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("BİYOGRAFİ: " + oku["BIYOGRAFI"].ToString(), oku["ADSOYAD"].ToString());
            }
            baglanti.Close();
        }
        //private void btnResimYukle_Click(object sender, EventArgs e)
        //{
        //    short oyuncuId = Convert.ToInt16(lblId.Text); // Oyuncu ID'sini alıyoruz

        //    // BL katmanındaki GetOyuncuById metodunu çağırıyoruz
        //    EntityOyuncular oyuncu = BLOyuncular.GetOyuncuById(oyuncuId);

        //    if (oyuncu != null)
        //    {
        //        MessageBox.Show("BİYOGRAFİ: " + oyuncu.Biyografi, oyuncu.AdSoyad);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Oyuncu bulunamadı.");
        //    }
        //}

        private void lblAdSoyad_Click(object sender, EventArgs e)
        {

        }
    }
}
