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

        private void OyuncuListesi_Load(object sender, EventArgs e)
        {
            EntityOyuncular ent = new EntityOyuncular();
            ent.Id = short.Parse(lblId.Text);

            List<EntityOyuncular> oyuncular = BLOyuncular.BLGetOyuncuById(ent.Id);
            foreach (var oyuncu in oyuncular)
            {
                lblCinsiyet.Text = oyuncu.Cinsiyet;
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

        private void button1_Click(object sender, EventArgs e)
        {
            EntityOyuncular ent = new EntityOyuncular();
            ent.Id = short.Parse(lblId.Text);
            BLOyuncular.BLOyuncuSil(ent.Id);

            MessageBox.Show(lblAdSoyad.Text + " Kişisine Ait Kayıt Silinmiştir!");
            this.Hide(); // UserControl aracımızı gizledik.Tüm araçlar gizlenmeyecektir. Sadece silmiş olduğumuz satır ekrandan kaldırılır.
        }

        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            EntityOyuncular ent = new EntityOyuncular();
            ent.Id = short.Parse(lblId.Text);
            List<EntityOyuncular> oyuncular = BLOyuncular.BLGetOyuncuById(ent.Id);
            foreach (var oyuncu in oyuncular)
            {
                MessageBox.Show("BİYOGRAFİ: " + oyuncu.Biyografi, oyuncu.AdSoyad);
            }
        }
    }
}
