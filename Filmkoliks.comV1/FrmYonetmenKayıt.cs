using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using DataAccessLayer;
using EntityLayer;
using LogicLayer;

namespace Filmkoliks.comV1
{
    public partial class FrmYonetmenKayıt : Form
    {
        public FrmYonetmenKayıt()
        {
            InitializeComponent();
        }

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

            if (ofd.ShowDialog()==DialogResult.OK)
            {
                //resim alma işlemini bu alanda ya da bu kısımda gerçekleştireceğiz.

                pBResim.Image = new Bitmap(ofd.FileName);
               resimYolu = ofd.FileName.ToString();
            }
        }

        private void rBErkek_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "0";
            Console.WriteLine("cinsiyet = erkek0");
        }

        private void rBKadin_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "1";
            Console.WriteLine("cinsiyet = kadın1");
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
                
                EntityYonetmenler ent = new EntityYonetmenler();
                ent.AdSoyad = adSoyad;
                ent.Cinsiyet = cinsiyet;
                ent.Yas = bYas;
                ent.Biyografi = txtBiyografi.Text.ToString().ToUpper();
                ent.Resim = resimYolu;
                BLYonetmenler.BLAddYonetmen(ent);

                MessageBox.Show("YÖNETMEN KAYIT İŞLEMİ BAŞARILI BİR ŞEKİLDE GERÇEKLEŞTİRİLDİ.");
                //ARAÇ TEMİZLEME KOMUTU YAZMAMIZ GEREKECEK.
                aracTemizle();
            }
            else
            {
                MessageBox.Show(mesaj);
            }
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
            pBResim.Image = (System.Drawing.Image)(Properties.Resources.noGorsel); 
            txtAd.Focus();
        }

       //YAS HESAPLARKEN 100'DEN KUCUK OLMA KONTROLU EKLENEBILIR CUNKU VERITABANINA 2 HANELI OLACAK SEKILDE KAYIT YAPILIYOR.
        void yasHesaplama()
        {
            string dogum = nGun.Value.ToString() + "-" + nAy.Value.ToString() + "-" + nYil.Value.ToString();
            
            DateTime dogumTarihi = Convert.ToDateTime(dogum);
            DateTime bugun = DateTime.Today;
            int yas = bugun.Year - dogumTarihi.Year;
           // MessageBox.Show(yas.ToString());

            bYas = yas.ToString();
        }

        private void txtBiyografi_TextChanged(object sender, EventArgs e)
        {
            int karakterSayisi = txtBiyografi.Text.Length;
            int geri = 300 - karakterSayisi;
            lblKarakter.Text = geri.ToString();
           // MessageBox.Show(karakterSayisi.ToString());
        }
    }
}

