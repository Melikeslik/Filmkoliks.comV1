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
    public partial class YonetmenListesi : UserControl
    {
        public YonetmenListesi()
        {
            InitializeComponent();
        }

        private void YonetmenListesi_Load(object sender, EventArgs e)
        {
            EntityYonetmenler ent = new EntityYonetmenler();
            ent.Id = short.Parse(lblId.Text);

            List<EntityYonetmenler> yonetmenler = BLYonetmenler.BLYonetmenListeleById(ent.Id);
            foreach (var yonetmen in yonetmenler)
            {
                lblCinsiyet.Text = yonetmen.Cinsiyet;
            }

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

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            EntityYonetmenler ent = new EntityYonetmenler();
            ent.Id = short.Parse(lblId.Text);
            List<EntityYonetmenler> yonetmenler = BLYonetmenler.BLYonetmenListeleById(ent.Id);
            foreach (var yonetmen in yonetmenler)
            {
                MessageBox.Show("BİYOGRAFİ: " + yonetmen.Biyografi, yonetmen.AdSoyad);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityYonetmenler ent = new EntityYonetmenler();
            ent.Id = short.Parse(lblId.Text);
            BLYonetmenler.BLYonetmenSil(ent.Id);

            MessageBox.Show(lblAdSoyad.Text + " Kişisine Ait Kayıt Silinmiştir!");
            this.Hide(); // UserControl aracımızı gizledik.Tüm araçlar gizlenmeyecektir. Sadece silmiş olduğumuz satır ekrandan kaldırılır.
        }
    }
}
