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
using System.Net.NetworkInformation;
using System.Diagnostics.Eventing.Reader;
using EntityLayer;
using LogicLayer;


namespace Filmkoliks.comV1
{
    public partial class FrmBiletOlustur : Form
    {
        public FrmBiletOlustur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //connectionstring
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=FilmkoliksDB;Integrated Security=True");
        private void FrmBiletOlustur_Load(object sender, EventArgs e)
        {
            filmAdiGetir();
            biletNoOlustur();
        }

        //void filmAdiGetir()
        //{
        //    string sorgu = "select * from Tbl_Filmler ORDER BY ADI ASC";
        //    baglanti.Open();
        //    SqlCommand komut = new SqlCommand(sorgu, baglanti);
        //    SqlDataReader oku = komut.ExecuteReader();
        //    while (oku.Read())
        //    {
        //        string gelenTarih = oku["TARIH"].ToString();

        //        DateTime fTarih = Convert.ToDateTime(gelenTarih);
        //        DateTime bugun = DateTime.Today;

        //        TimeSpan timeSpan = fTarih - bugun;
        //        if (timeSpan.TotalDays >= 0)
        //        {
        //            cbFilmAdi.Items.Add(oku["ADI"].ToString());
        //        }

        //    }
        //    baglanti.Close();
        //}
        private void filmAdiGetir()
        {
            // Logic Layer'dan uygun film listesini alıyoruz
            List<EntityFilmler> filmListesi = BLFilmler.BLFilmListesiGetir();

            // ComboBox'ı temizliyoruz
            cbFilmAdi.Items.Clear();

            // Filmleri ComboBox'a ekliyoruz
            foreach (var film in filmListesi)
            {
                cbFilmAdi.Items.Add(film.Adi);
            }
        }

        void biletNoOlustur()
        {
            //kod oluşturma işlemi gerçekleştireceğiz.//RANDOM KOMUTU İLE.
            Random rastgele = new Random();
            string karakterler = "123456789012345678901234567890123456789012345678901234567890123456789";
            string kod = "";

            for ( int i=1; i<11; i++) // 11 tane yapmamız lazım ki 10 tane kod oluşsun.
            {
                kod += karakterler[rastgele.Next(karakterler.Length)];
            }
            txtBarkod.Text = kod.ToString();
        }

        //private void cbFilmAdi_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //distinct ---> Veritabanımızda kayıtlı olan aynı türlen veriler arasında sadece 1 tanesini getirir. (Diğer verilerin hiçbirini silmez, sadece 1 tane gösterir.)

        //    cbTarih.Items.Clear();
        //    string sorgu = "SELECT DISTINCT TARIH FROM Tbl_Kontrol WHERE FILMADI=@filmAdi";
        //    baglanti.Open();
        //    SqlCommand komut = new SqlCommand(sorgu, baglanti);
        //    komut.Parameters.AddWithValue("@filmAdi", cbFilmAdi.Text.ToString());
        //    SqlDataReader oku = komut.ExecuteReader();
        //    while (oku.Read())
        //    {
        //        cbTarih.Items.Add(oku["TARIH"].ToString());
        //    }
        //    baglanti.Close();
        //}
        private void cbFilmAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox'ı temizle
            cbTarih.Items.Clear();

            // Seçilen film adını al
            string selectedFilmAdi = cbFilmAdi.SelectedItem.ToString();

            // BL katmanını çağırarak tarihleri al
            List<string> tarihListesi = LogicLayer.BLFilmler.BLTarihListesiGetir(selectedFilmAdi);


            // Tarihleri ComboBox'a ekle
            foreach (var tarih in tarihListesi)
            {
                cbTarih.Items.Add(tarih);
            }
        }

        //void biletNoSorgula()
        //{
        //    string sorgu = "select * from Tbl_Biletler WHERE BKOD=@no";
        //    baglanti.Open();
        //    SqlCommand komut = new SqlCommand(sorgu, baglanti);
        //    komut.Parameters.AddWithValue("@no", txtBarkod.Text.ToString());
        //    SqlDataReader oku = komut.ExecuteReader();
        //    if (!oku.Read())
        //    {
        //        kaydetMETODU();
        //    }
        //    else
        //    {
        //        biletNoOlustur();
        //        baglanti.Close();
        //        biletNoSorgula();
        //    }

        //    baglanti.Close();
        //}
        void biletNoSorgula()
        {
            // Kullanıcıdan alınan barkod numarasını alıyoruz
            string barkodNo = txtBarkod.Text.ToString();

            // BL katmanından biletin var olup olmadığını sorguluyoruz
            EntityBiletler bilet = LogicLayer.BLBiletler.BLBiletGetir(barkodNo);

            if (bilet == null)
            {
                // Eğer bilet yoksa, kaydetmek için işlemi yapıyoruz
                kaydetMETODU();
            }
            else
            {
                // Eğer bilet varsa, işlem yapılacak (örneğin bilet numarası oluşturma vb.)
                biletNoOlustur();
            }
        }


        void kaydetMETODU()
        {
            //ekleme
            EntityBiletler bilet = new EntityBiletler();
            bilet.BKod = txtBarkod.Text.ToString();
            bilet.AdSoyad = txtAdSoyad.Text.ToUpper().ToString();
            bilet.TelNo = txtTelNo.Text.ToString();
            bilet.KoltukNo = txtKoltuklar.Text.ToString();
            bilet.FilmAdi = cbFilmAdi.Text.ToString();
            bilet.Tarih = cbTarih.Text.ToString();
            bilet.Saat = lblSeansSec.Text.ToString();
            bilet.Salon = cbSalon.Text.ToString();
            bilet.Tur = cbBiletTuru.Text.ToString();
            bilet.IslemSaati = DateTime.Now.ToString();
            BLBiletler.BLBiletEkle(bilet);


            // UPDATE KOMUTU
            string sorgu2 = "UPDATE Tbl_Kontrol SET KOLTUKLAR=@numara WHERE FILMADI=@filmadi AND TARIH=@tarih AND SAAT=@saat AND SALONADI=@salonadi";
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand(sorgu2, baglanti);

            if (lblGelenKoltuk.Text.ToString() == "")
            {
                guncelle.Parameters.AddWithValue("@numara", txtKoltuklar.Text.ToString());
            }
            else
            {
                guncelle.Parameters.AddWithValue("@numara", lblGelenKoltuk.Text.ToString() + "," + txtKoltuklar.Text.ToString());
            }

            guncelle.Parameters.AddWithValue("@filmadi", cbFilmAdi.Text.ToString());
            guncelle.Parameters.AddWithValue("@tarih", cbTarih.Text.ToString());
            guncelle.Parameters.AddWithValue("@saat", lblSeansSec.Text.ToString());
            guncelle.Parameters.AddWithValue("@salonadi", cbSalon.Text.ToString());
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            //EntityKontrol ent = new EntityKontrol();
            //ent.FilmAdi = cbFilmAdi.Text.ToString();
            //ent.Tarih = cbTarih.Text.ToString();
            //ent.Saat = lblSeansSec.Text.ToString();
            //ent.SalonAdi = cbSalon.Text.ToString();
            //BLBiletler.BLBiletGuncelle(ent);



            MessageBox.Show("BİLETİNİZ OLUŞTURULMUŞTUR.");
            salonDurumGeldi();

            lblGelenKoltuk.Text = "";
            listeGelenKoltuk.Items.Clear();
            lbBelirlenen.Items.Clear();
            txtKoltuklar.Text = "";
        }
        private void btnOlustur_Click(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text != "" && txtBarkod.Text != "" && txtKoltuklar.Text != "" && txtTelNo.Text != "" && cbBiletTuru.Text != "" && cbFilmAdi.Text != "" && cbSalon.Text != "" && cbTarih.Text != "" && lblSeansSec.Text != "")
            {
                //kayıt işlemlerimiz bu alanda gerçekleştirilecektir.
                biletNoSorgula(); //ve sorgulama sonucunda varolan numara veritabanında kayıtlı değil ise kayıt ekleme işi gerçekleştirilecektir. bu metodun içinde işlemler yapılacaktır.
                
            }
            else
            {
                MessageBox.Show("LÜTFEN TÜM ALANLARI EKSİKSİZ DOLDURUNUZ!");
            }
        }
        void secTiklerimiz()
        {
            txtKoltuklar.Text = "";
            foreach (string item in lbBelirlenen.Items)
            {
                txtKoltuklar.Text += "," + item;
            }
            if( txtKoltuklar.Text.Length > 1)
            {
                txtKoltuklar.Text = txtKoltuklar.Text.Substring(1);
            }
        }
        private void BtnKoltuk_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if( btn.ForeColor == Color.Black) //arkaplan kırmızı // dolu
            {
                MessageBox.Show("DOLU");
            }
            else
            {
                //boş
                if (btn.ForeColor == Color.Yellow)
                {
                    btn.Image = (System.Drawing.Image)(Properties.Resources.sari);
                    btn.ForeColor = Color.Blue;
                    lbBelirlenen.Items.Add(btn.Text);
                    secTiklerimiz();
                }
                else
                {
                    btn.Image = (System.Drawing.Image)(Properties.Resources.mavi);
                    btn.ForeColor = Color.Yellow;
                    lbBelirlenen.Items.Remove(btn.Text);
                    secTiklerimiz();

                }
            }
        }

        //private void cbTarih_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    panelSEANS.Controls.Clear();
        //    string saatler = "";

        //    string sorgu = "SELECT DISTINCT SAAT FROM Tbl_Kontrol WHERE FILMADI=@filmAdi AND TARIH=@tarih";
        //    baglanti.Open();
        //    SqlCommand komut = new SqlCommand(sorgu, baglanti);
        //    komut.Parameters.AddWithValue("@filmAdi", cbFilmAdi.Text.ToString());
        //    komut.Parameters.AddWithValue("@tarih", cbTarih.Text.ToString());
        //    SqlDataReader oku = komut.ExecuteReader();
        //    while (oku.Read())
        //    {
        //        saatler = oku["SAAT"].ToString();
        //        RadioButton rnd = new RadioButton();
        //        rnd.Text = saatler;
        //        rnd.ForeColor = Color.Red;
        //        rnd.FlatStyle = FlatStyle.Flat;
        //        rnd.Width = 70;
        //        rnd.Font = new System.Drawing.Font("Segoe UI Semibold", 12);
        //        rnd.CheckedChanged += new EventHandler(SeansSaatler);
        //        panelSEANS.Controls.Add(rnd);
        //    }
        //    baglanti.Close();
        //}
        private void cbTarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelSEANS.Controls.Clear();
            string filmAdi = cbFilmAdi.Text.ToString();
            string tarih = cbTarih.Text.ToString();

            // Business Logic Layer'dan saatleri al
            List<EntityKontrol> saatlerListesi = LogicLayer.BLKontrol.SaatleriGetir(filmAdi, tarih);

            // Gelen saatleri UI'ya ekle
            foreach (var kontrol in saatlerListesi)
            {
                string saatler = kontrol.Saat; // Saat bilgisi Entity'den alınıyor
                RadioButton rnd = new RadioButton
                {
                    Text = saatler,
                    ForeColor = Color.Red,
                    FlatStyle = FlatStyle.Flat,
                    Width = 70,
                    Font = new System.Drawing.Font("Segoe UI Semibold", 12)
                };
                rnd.CheckedChanged += new EventHandler(SeansSaatler);
                panelSEANS.Controls.Add(rnd);
            }
        }

        private void SeansSaatler( object sender, EventArgs e)
        {
            //foreach dngümüzü kullanacağız.
            foreach ( RadioButton item in panelSEANS.Controls)
            {
                if(item.Checked) //bu format seçili
                {
                    lblSeansSec.Text = item.Text;
                    cbSalon.Items.Clear();
                    string sorgu = "SELECT DISTINCT SALONADI FROM Tbl_Kontrol WHERE FILMADI=@filmAdi AND TARIH=@tarih AND SAAT=@saat";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@filmAdi", cbFilmAdi.Text.ToString());
                    komut.Parameters.AddWithValue("@tarih", cbTarih.Text.ToString());
                    komut.Parameters.AddWithValue("saat", lblSeansSec.Text.ToString());
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        cbSalon.Items.Add(oku["SALONADI"].ToString());
                    }
                    baglanti.Close();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panelSEANS_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            salonDurumGeldi();
        }
        void salonDurumGeldi()
        {
            string sorgu = "SELECT * FROM Tbl_Salonlar WHERE SALONADI=@salonAdi";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@salonAdi", cbSalon.Text.ToString());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblKoltukSayisi.Text = oku["KOLTUKSAYISI"].ToString();
            }
            baglanti.Close();
            // Seçili olan koltukları veritabanından çekmiş oluyoruz.
            koltukGetir();
            doldur();
        }
        void doldur()
        {
            koltukPaneli.Controls.Clear();

            int sayi = Convert.ToInt32(lblKoltukSayisi.Text);
            for (int i = 1; i <= sayi; i++)
            {
                Button btn = new Button();
                //.........
                if (i <= 10)
                {
                    btn.Text = "A" + i.ToString();
                    btn.Name = "A" + i.ToString();
                }
                else if (i <= 20)
                {
                    btn.Text = "B" + (i-10).ToString();
                    btn.Name = "B" + (i-10).ToString();
                }
                else if (i <= 30)
                {
                    btn.Text = "C" + (i-20).ToString();
                    btn.Name = "C" + (i-20).ToString();
                }
                else if (i <= 40)
                {
                    btn.Text = "D" + (i-30).ToString();
                    btn.Name = "D" + (i-30).ToString();
                }
                else if (i <= 50)
                {
                    btn.Text = "E" + (i-40).ToString();
                    btn.Name = "E" + (i-40).ToString();
                }
                else if (i <= 60)
                {
                    btn.Text = "F" + (i-50).ToString();
                    btn.Name = "F" + (i-50).ToString();
                }
                else if (i <= 70)
                {
                    btn.Text = "G" + (i-60).ToString();
                    btn.Name = "G" + (i-60).ToString();
                }
                else if (i <= 80)
                {
                    btn.Text = "H" + (i-70).ToString();
                    btn.Name = "H" + (i-70).ToString();
                }
                else if (i <= 90)
                {
                    btn.Text = "I" + (i-80).ToString();
                    btn.Name = "I" + (i-80).ToString();
                }
                else if (i <= 100)
                {
                    btn.Text = "J" + (i-90).ToString();
                    btn.Name = "J" + (i-90).ToString();
                }
                //..........
                btn.Width = 60;
                btn.Height = 60;
                btn.FlatStyle = FlatStyle.Flat;
                //btn.FlatAppearance.BorderSize = 0;   // Bence butonların etrafında çerçeve olması güzel durduğu için bu satırı yoruma aldım.
                btn.Font = new System.Drawing.Font("Segue UI Semibold", 12);
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Green;
                btn.Click += BtnKoltuk_Click;

                if (listeGelenKoltuk.Items.Contains(btn.Text))
                {
                    // Buraya  512lik görseller çok büyük geldiği için arkaplan rengi değişmiş gibi oluyor sadece. 16lık ve 32lik ile denedim o da küçük geldi burayı daha sonra ayarlarız.
                    btn.Image = (System.Drawing.Image)(Properties.Resources.kirmizi);
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.ForeColor = Color.Black;
                    //btn.TextAlign = ContentAlignment.MiddleRight;  // burada text aligment'ı sağa yaslıyor hoca buna gerek yok
                    //btn.BackColor = Color.Red; // Koltuk seçili ise
                }
                else
                {
                    btn.Image = (System.Drawing.Image)(Properties.Resources.mavi); 
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.ForeColor = Color.Yellow;
                    //btn.BackColor= Color.SkyBlue; // Koltuk seçili değil ise
                }

                koltukPaneli.Controls.Add(btn);
            }
        }

        void koltukGetir()
        {
            lblGelenKoltuk.Text = "";
            string sorgu = "SELECT * FROM Tbl_Kontrol WHERE FILMADI=@filmAdi AND TARIH=@tarih AND SAAT=@saat AND SALONADI=@salonAdi";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@filmAdi", cbFilmAdi.Text.ToString());
            komut.Parameters.AddWithValue("@tarih", cbTarih.Text.ToString());
            komut.Parameters.AddWithValue("@saat", lblSeansSec.Text.ToString());
            komut.Parameters.AddWithValue("@salonAdi", cbSalon.Text.ToString());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblGelenKoltuk.Text += " ," + oku["KOLTUKLAR"].ToString();
                if (lblGelenKoltuk.Text.Length > 2 )
                {
                    lblGelenKoltuk.Text = lblGelenKoltuk.Text.Substring(2);
                }
                else
                {
                    lblGelenKoltuk.Text = "";
                }
            }
            baglanti.Close();

            // Koltuk numaralarını ayırma...
            koltukAyirma();
        }

        void koltukAyirma()
        {
            listeGelenKoltuk.Items.Clear();
            string no = "";
            string[] sec;
            no = lblGelenKoltuk.Text.ToString();
            sec = no.Split(',');
           // Split --> Hangi karakteri belittiysek o karakterde ayırma işlemi yapmaya yarayan komut. Tek tırnak içerisinde karakter verilir.
           foreach (string bulunan in sec)
            {
                listeGelenKoltuk.Items.Add(bulunan);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            lblGelenKoltuk.Text = "";
            lblKoltukSayisi.Text = "";
            lblSeansSec.Text = "";
            txtAdSoyad.Text = "";
            txtTelNo.Text = "";
            txtKoltuklar.Text = "";
            cbBiletTuru.Text = "";
            cbSalon.Text = "";
            cbTarih.Text = "";
            txtBarkod.Text = "";
            cbSalon.Items.Clear();
            cbTarih.Items.Clear();
            cbBiletTuru.Items.Clear();
            cbBiletTuru.Items.Add("YETİŞKİN");
            cbBiletTuru.Items.Add("ÖĞRENCİ");
            biletNoOlustur();
            panelSEANS.Controls.Clear();
            koltukPaneli.Controls.Clear();
            lbBelirlenen.Items.Clear();
            cbFilmAdi.Items.Clear();
            listeGelenKoltuk.Items.Clear();
            filmAdiGetir();
            txtAdSoyad.Focus();
           

        }
    }
}

 