using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using EntityLayer;
using LogicLayer;


namespace Filmkoliks.comV1
{
    public partial class FrmFilmKayit : Form
    {
        public FrmFilmKayit()
        {
            InitializeComponent();
        }

        //connectionstring
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            verileriSil();

        }
        void verileriSil()
        {
            DALSecilenler.SecilenleriSil();
            Console.WriteLine("Seçilenler tablosu içeriği silindi!");
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "6";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "10";
        }

        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "1";
        }

        private void rB2_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "2";
        }

        private void rB3_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "3";
        }

        private void rB4_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "4";
        }

        private void rB5_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "5";
        }

        private void rB7_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "7";
        }

        private void rB8_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "8";
        }

        private void rB9_CheckedChanged(object sender, EventArgs e)
        {
            lblRating.Text = "9";
        }

        string resimYolu = "";
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

        private void lblRating_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int karakterSayisi = txtFilmDetay.Text.Length;
            int geri = 300 - karakterSayisi;
            lblKarakter.Text = geri.ToString();
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmFilmKayit_Load(object sender, EventArgs e)
        {
            txtFilmAdi.Focus(); //imlecimiz
            yListesiGetir();
            oListesiGetir();
            lblYonetmenAra.Visible = false;
            lblOyuncuAra.Visible = false;
            bugununTarihi();
        }
        void bugununTarihi()
        {
            nGun.Value = DateTime.Today.Day;
            nAy.Value = DateTime.Today.Month;
            nYil.Value = DateTime.Today.Year;
        }
        void yListesiGetir()
        {
            string sorgu = "select * from Tbl_Yonetmenler ORDER BY ADSOYAD ASC";
            fYonPanel.Controls.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                yListeAraci arac = new yListeAraci();
                arac.lblAdi.Text = oku["ADSOYAD"].ToString();
                fYonPanel.Controls.Add(arac);
            }
            baglanti.Close();
        }
        //private void yListesiGetir()
        //{
        //    // Paneli temizliyoruz
        //    fYonPanel.Controls.Clear();

        //    // Yönetmenler listesini BL katmanından alıyoruz
        //    List<EntityYonetmenler> yonetmenListesi = BLYonetmenler.BLYonetmenListesiGetir();

        //    foreach (var yonetmen in yonetmenListesi)
        //    {
        //        yListeAraci arac = new yListeAraci();
        //        arac.lblAdi.Text = yonetmen.AdSoyad; // Yönetmenin adı soyadı
        //        fYonPanel.Controls.Add(arac); // Panel'e ekleme
        //    }
        //}

        //oyuncu listesi
        void oListesiGetir()
        {
            string sorgu = "select * from Tbl_Oyuncular ORDER BY ADSOYAD ASC";
            fOyuncuPaneli.Controls.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                oListeAraci arac = new oListeAraci();
                arac.lblAdi.Text = oku["ADSOYAD"].ToString();
                fOyuncuPaneli.Controls.Add(arac);
            }
            baglanti.Close();
        }
        //private void oListesiGetir()
        //{
        //    // Paneli temizliyoruz
        //    fOyuncuPaneli.Controls.Clear();

        //    // Oyuncular listesini BL katmanından alıyoruz
        //    List<EntityOyuncular> oyuncuListesi = BLOyuncular.BLOyuncuListesiGetir();

        //    foreach (var oyuncu in oyuncuListesi)
        //    {
        //        oListeAraci arac = new oListeAraci();
        //        arac.lblAdi.Text = oyuncu.AdSoyad;  // Oyuncu adı soyadı
        //        fOyuncuPaneli.Controls.Add(arac);  // Panel'e ekleme
        //    }
        //}

        private void lblOyuncuAra_Click(object sender, EventArgs e)
        {

        }

        private void txtOyuncuAra_MouseMove(object sender, MouseEventArgs e)
        {
            lblOyuncuAra.Visible = true;
        }

        private void txtOyuncuAra_MouseLeave(object sender, EventArgs e)
        {
            lblOyuncuAra.Visible = false;
        }

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {
            lblYonetmenAra.Visible = true;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            lblYonetmenAra.Visible = false;
        }

        private void txtOyuncuAra_TextChanged(object sender, EventArgs e)
        {
            oyuncuAra();
            lblOyuncuAra.Visible = false;
        }
        void oyuncuAra()
        {
            string sorgu = "select * from Tbl_Oyuncular Where ADSOYAD LIKE '%" + txtOyuncuAra.Text + "%' ORDER BY ADSOYAD ASC";
            fOyuncuPaneli.Controls.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                oListeAraci arac = new oListeAraci();
                arac.lblAdi.Text = oku["ADSOYAD"].ToString();
                fOyuncuPaneli.Controls.Add(arac);
            }
            baglanti.Close();
        }
        //private void oyuncuAra()
        //{
        //    // Paneli temizliyoruz
        //    fOyuncuPaneli.Controls.Clear();

        //    // Oyuncular listesini BL katmanından alıyoruz
        //    string aranan = txtOyuncuAra.Text;
        //    List<EntityOyuncular> oyuncuListesi = BLOyuncular.BLOyuncuAra(aranan);

        //    foreach (var oyuncu in oyuncuListesi)
        //    {
        //        oListeAraci arac = new oListeAraci();
        //        arac.lblAdi.Text = oyuncu.AdSoyad;  // Oyuncu adı soyadı
        //        fOyuncuPaneli.Controls.Add(arac);  // Panel'e ekleme
        //    }
        //}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            yonetmenAra();
            lblYonetmenAra.Visible = false;
        }

        void yonetmenAra()
        {
            string sorgu = "select * from Tbl_Yonetmenler Where ADSOYAD LIKE '%" + txtYonetmenAra.Text + "%' COLLATE TURKISH_CI_AS ORDER BY ADSOYAD ASC";
            fYonPanel.Controls.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                yListeAraci arac = new yListeAraci();
                arac.lblAdi.Text = oku["ADSOYAD"].ToString();
                fYonPanel.Controls.Add(arac);
            }
            baglanti.Close();
        }
        //private void yonetmenAra()
        //{
        //    // Paneli temizliyoruz
        //    fYonPanel.Controls.Clear();

        //    // BL katmanındaki arama fonksiyonunu kullanıyoruz
        //    string aranan = txtYonetmenAra.Text;
        //    List<EntityYonetmenler> yonetmenListesi = BLYonetmenler.BLYonetmenAra(aranan);

        //    // Gelen listeyi UI'da göstermek için kontrol ekliyoruz
        //    foreach (var yonetmen in yonetmenListesi)
        //    {
        //        yListeAraci arac = new yListeAraci();
        //        arac.lblAdi.Text = yonetmen.AdSoyad;  // Yönetmenin adı
        //        fYonPanel.Controls.Add(arac);  // Panel'e ekleme
        //    }
        //}

        #region  FILM OZELLIKLERI
        private void lblTurkce_Click(object sender, EventArgs e)
        {
            if (lblTurkce.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblTurkce.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblTurkce.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void lblIngilizce_Click(object sender, EventArgs e)
        {
            if (lblIngilizce.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblIngilizce.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblIngilizce.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void lblAltyazı_Click(object sender, EventArgs e)
        {
            if (lblAltyazı.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblAltyazı.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblAltyazı.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void lblKorkuSiddet_Click(object sender, EventArgs e)
        {
            if (lblKorkuSiddet.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblKorkuSiddet.ForeColor = Color.FromArgb(249, 164, 26);
                pBKorkuSiddet.Image = (System.Drawing.Image)(Properties.Resources.unlocked);
            }
            else
            {
                lblKorkuSiddet.ForeColor = Color.FromArgb(70, 130, 180);
                pBKorkuSiddet.Image = (System.Drawing.Image)(Properties.Resources._lock);
            }
        }

        private void lblOlumsuzIcerik_Click(object sender, EventArgs e)
        {
            if (lblOlumsuzIcerik.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblOlumsuzIcerik.ForeColor = Color.FromArgb(249, 164, 26);
                pBOlumsuzIcerik.Image = (System.Drawing.Image)(Properties.Resources.unlocked);
            }
            else
            {
                lblOlumsuzIcerik.ForeColor = Color.FromArgb(70, 130, 180);
                pBOlumsuzIcerik.Image = (System.Drawing.Image)(Properties.Resources._lock);
            }
        }

        private void lblCinsellik_Click(object sender, EventArgs e)
        {
            if (lblCinsellik.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblCinsellik.ForeColor = Color.FromArgb(249, 164, 26);
                pBCinsellik.Image = (System.Drawing.Image)(Properties.Resources.unlocked);
            }
            else
            {
                lblCinsellik.ForeColor = Color.FromArgb(70, 130, 180);
                pBCinsellik.Image = (System.Drawing.Image)(Properties.Resources._lock);
            }
        }

        private void lblGenelIzleyici_Click(object sender, EventArgs e)
        {
            if (lblGenelIzleyici.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblGenelIzleyici.ForeColor = Color.FromArgb(249, 164, 26);
                pBGenelIzleyici.Image = (System.Drawing.Image)(Properties.Resources.unlocked);
            }
            else
            {
                lblGenelIzleyici.ForeColor = Color.FromArgb(70, 130, 180);
                pBGenelIzleyici.Image = (System.Drawing.Image)(Properties.Resources._lock);
            }
        }

        private void lblArtiYedi_Click(object sender, EventArgs e)
        {
            if (lblArtiYedi.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblArtiYedi.ForeColor = Color.FromArgb(249, 164, 26);
                pBArtiYedi.Image = (System.Drawing.Image)(Properties.Resources.unlocked);
            }
            else
            {
                lblArtiYedi.ForeColor = Color.FromArgb(70, 130, 180);
                pBArtiYedi.Image = (System.Drawing.Image)(Properties.Resources._lock);
            }
        }

        private void lblArtiOnUc_Click(object sender, EventArgs e)
        {
            if (lblArtiOnUc.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblArtiOnUc.ForeColor = Color.FromArgb(249, 164, 26);
                pBArtiOnUc.Image = (System.Drawing.Image)(Properties.Resources.unlocked);
            }
            else
            {
                lblArtiOnUc.ForeColor = Color.FromArgb(70, 130, 180);
                pBArtiOnUc.Image = (System.Drawing.Image)(Properties.Resources._lock);
            }
        }
        #endregion


        #region FILM TURLERI
        private void lblAksiyon_Click(object sender, EventArgs e)
        {
            if (lblAksiyon.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblAksiyon.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblAksiyon.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void lblKorku_Click(object sender, EventArgs e)
        {

            if (lblKorku.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblKorku.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblKorku.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void lblGerilim_Click(object sender, EventArgs e)
        {
            if (lblGerilim.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblGerilim.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblGerilim.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void lblBilimKurgu_Click(object sender, EventArgs e)
        {
            if (lblBilimKurgu.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblBilimKurgu.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblBilimKurgu.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void lblFantastik_Click(object sender, EventArgs e)
        {
            if (lblFantastik.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblFantastik.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblFantastik.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

        private void lblRomantik_Click(object sender, EventArgs e)
        {
            if (lblRomantik.ForeColor == Color.FromArgb(70, 130, 180))
            {
                lblRomantik.ForeColor = Color.FromArgb(249, 164, 26);
            }
            else
            {
                lblRomantik.ForeColor = Color.FromArgb(70, 130, 180);
            }
        }

       
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            vizyonTarihiHesapla();
        }
        string vTarih = "";
        void vizyonTarihiHesapla()
        {
            vTarih = nGun.Value + "-" + nAy.Value + "-" + nYil.Value;
            DateTime dVTarih = Convert.ToDateTime(vTarih);
            DateTime bugunTarihi = DateTime.Today;

            //timeSpan ---> Varolan iki tarih arasındaki gün,ay,yıl,saat vb gibi sayısal verileri belirlemeye yarar.

            TimeSpan tSpan = dVTarih - bugunTarihi;

            if (tSpan.TotalDays < 0)
            {
                //iki tarih arasında bulunan fark negatif ise ne olacak.
                MessageBox.Show("SADECE GÜNCEL FİLMLER EKLENEBİLİR!");
                bugununTarihi();

            }

            else if (tSpan.TotalDays == 0)
            {
                MessageBox.Show(txtFilmAdi.Text.ToUpper() + " FİLMİ BUGÜN VİZYONDA!");

            }
            else
            {
                MessageBox.Show(txtFilmAdi.Text.ToUpper() + " " + tSpan.TotalDays.ToString() + " GÜN SONRA VİZYONA GİRECEKTİR :)");

            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToShortDateString();
        }
        string yonetmen = "";
        string oyuncu = "";

        void secilenYonetmen()

        {
            yonetmen = "";
            string sorgu = "select * from Tbl_Secilenler WHERE TUR='YÖNETMEN'";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                yonetmen += " , " + oku["KISI"].ToString();
            }
            baglanti.Close();
        }
        //private void secilenYonetmen()
        //{
        //    yonetmen = "";
        //    // BL katmanından seçilen yönetmenleri alıyoruz
        //    yonetmen = BLSecilenler.SecilenYonetmenleriAl();

        //    // Alınan yönetmenleri kullanarak UI'da işlem yapabiliriz (örneğin, bir label'a yazdırmak)
        //    //lblSecilenYonetmen.Text = yonetmen;
        //}

        void secilenOyuncu()
        {
            oyuncu = "";
            string sorgu = "select * from Tbl_Secilenler WHERE TUR='OYUNCU'";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                oyuncu += " , " + oku["KISI"].ToString();
            }
            baglanti.Close();
        }
        //private void secilenOyuncu()
        //{
        //    oyuncu = "";
        //    // BL katmanından seçilen oyuncuları alıyoruz
        //    oyuncu = BLSecilenler.SecilenOyunculariAl();

        //    // Alınan oyuncuları UI'da gösterebiliriz (örneğin, bir label'a yazdırmak)
        //    //lblSecilenOyuncu.Text = oyuncu;
        //}

        void temizlemeMetodu()
        {
            //this.Controls.Clear();
            //this.InitializeComponent();

            // TextBox'ları ve Label'ları temizle
            txtFilmAdi.Clear();
            txtFilmDetay.Clear();
            lblRating.Text = "0";  // Rating label'ını sıfırla
            secilenTur = "";
            secilenOzellik = "";
            //radio buton başlangıç değere getirme
            rB1.Checked = true;
            rB2.Checked = false;
            rB3.Checked = false;
            rB4.Checked = false;
            rB5.Checked = false;
            rB6.Checked = false;
            rB7.Checked = false;
            rB8.Checked = false;
            rB9.Checked = false;
            rB10.Checked = false;
            // secilen resmi kaldir
            resimYolu = "";
            pBResim.Image = (System.Drawing.Image)(Properties.Resources.noGorsel);

            foreach (var gr in new[] { grBTur, grBOzellikler })
            {
                foreach (Control arac in gr.Controls)
                {
                    if (arac is Label)
                    {
                        arac.ForeColor = Color.FromArgb(70, 130, 180);
                    }
                }
            }

            pBArtiOnUc.Image = (System.Drawing.Image)( Properties.Resources._lock);
            pBArtiYedi.Image = (System.Drawing.Image)(Properties.Resources._lock);
            pBCinsellik.Image = (System.Drawing.Image)(Properties.Resources._lock);
            pBGenelIzleyici.Image = (System.Drawing.Image)(Properties.Resources._lock);
            pBKorkuSiddet.Image = (System.Drawing.Image)(Properties.Resources._lock);
            pBOlumsuzIcerik.Image = (System.Drawing.Image)(Properties.Resources._lock);

            //foreach (Control arac in grBOzellikler.Controls)
            //{
            //    if (arac is PictureBox pictureBox)
            //    {
            //        // Resmin yolunu kontrol et
            //        if (pictureBox.ImageLocation != null && pictureBox.ImageLocation.EndsWith(@"unlocked.png"))
            //        {
            //            // Eğer resim "unlocked.png" ise, "locked.png" ile değiştir
            //            pictureBox.Image = Image.FromFile(@"C:\Users\mnurk\Desktop\locked.png");
            //        }
            //    }
            //}

            txtFilmAdi.Focus();
            verileriSil();
            yListesiGetir();
            oListesiGetir();
            bugununTarihi();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            secilenYonetmen();
            secilenOyuncu();

            tur();
            ozellik();


            //insert into deyimini kullanarak verileri veritabanına kaydetme işlemi gerçekleştireceğiz.
            //input kontrolü sağlayacağız.

            if (txtFilmAdi.Text != "" && txtFilmDetay.Text != "" && yonetmen != "" && oyuncu != "" && resimYolu != "" && vTarih != "" && secilenOzellik != "" && secilenTur != "")
            {
                //alanlarımız DOLU ise
                string sorgu = " insert into Tbl_Filmler (ADI, TURU, OZELLIKLERI, YONETMEN, OYUNCU, DETAY, PUAN, AFIS, TARIH) VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8, @P9)";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", txtFilmAdi.Text.ToUpper());
                if (secilenTur.Length > 2)
                {
                    komut.Parameters.AddWithValue("@p2", secilenTur.Substring(2));
                }
                else
                {
                    komut.Parameters.AddWithValue("@p2", secilenTur);
                }
                if (secilenOzellik.Length > 2)
                {
                    komut.Parameters.AddWithValue("@p3", secilenOzellik.Substring(2));
                }
                else
                {
                    komut.Parameters.AddWithValue("@p3", secilenOzellik);
                }
                if (yonetmen.Length > 2)
                {
                    komut.Parameters.AddWithValue("@p4", yonetmen.Substring(2));
                }
                else
                {
                    komut.Parameters.AddWithValue("@p4", yonetmen);
                }
                if (oyuncu.Length > 2)
                {
                    komut.Parameters.AddWithValue("@p5", oyuncu.Substring(2));
                }
                else
                {
                    komut.Parameters.AddWithValue("@p5", oyuncu);
                }


                komut.Parameters.AddWithValue("@p6", txtFilmDetay.Text.ToUpper());
                komut.Parameters.AddWithValue("@p7", lblRating.Text);
                komut.Parameters.AddWithValue("@p8", resimYolu);
                komut.Parameters.AddWithValue("@p9", vTarih);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("FİLM KAYDEDİLMİŞTİR");
                temizlemeMetodu();

            }
            else
            {
                //alanlarımız boş ise
                MessageBox.Show("LÜTFEN İLGİLİ ALANLARI DOLDURUNUZ!");
            }

            //GEÇİCİ ALANLARIMIZ -daha sonradan değiştireceğiz.
        }
        //private void btnKaydet_Click(object sender, EventArgs e)
        //{
        //    secilenYonetmen();
        //    secilenOyuncu();

        //    tur();
        //    ozellik();

        //    //UI'den girilen verileri Entity class'a atıyoruz
        //    EntityFilmler yeniFilm = new EntityFilmler();

        //    yeniFilm.Adi = txtFilmAdi.Text.ToUpper();
        //    yeniFilm.Turu = secilenTur.Length > 2 ? secilenTur.Substring(2) : secilenTur;
        //    yeniFilm.Ozellikleri = secilenOzellik.Length > 2 ? secilenOzellik.Substring(2) : secilenOzellik;
        //    yeniFilm.Yonetmen = yonetmen.Length > 2 ? yonetmen.Substring(2) : yonetmen;
        //    yeniFilm.Oyuncu = oyuncu.Length > 2 ? oyuncu.Substring(2) : oyuncu;
        //    yeniFilm.Detay = txtFilmDetay.Text.ToUpper();
        //    yeniFilm.Puan = lblRating.Text;
        //    yeniFilm.Afis = resimYolu;
        //    yeniFilm.Tarih = vTarih;


        //    // BL katmanındaki film ekleme işlemini çağırıyoruz
        //    string sonucMesaji = BLFilmler.FilmEkle(yeniFilm);

        //    // Sonucu kullanıcıya gösteriyoruz
        //    MessageBox.Show(sonucMesaji);

        //    if (sonucMesaji == "Film başarıyla kaydedildi!")
        //    {
        //        temizlemeMetodu();  // Formu temizleme metodu
        //    }
        //}

        string secilenTur = "";
        string secilenOzellik = "";
        void tur()
        {
            foreach (Control arac in grBTur.Controls)
            {
                if (arac is Label)
                {
                    if (arac.ForeColor == Color.FromArgb(249, 164, 26))
                    {
                        //seçilmiş ise
                        secilenTur += ", " + arac.Text.ToString();
                    }
                    else
                    {
                        // secilmemis
                    }
                }
            }
        }

        void ozellik()
        {
            foreach (Control arac in grBOzellikler.Controls)
            {
                if (arac is Label)
                {
                    if (arac.ForeColor == Color.FromArgb(249, 164, 26))
                    {
                        //seçilmiş ise
                        secilenOzellik += ", " + arac.Text.ToString();
                    }
                    else
                    {
                        // secilmemis
                    }
                }
            }
        }

        private void fYonPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}










