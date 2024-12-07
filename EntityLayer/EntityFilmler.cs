using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityFilmler
    {
        private short id;
        private string adi;
        private string turu;
        private string ozellikleri;
        private string yonetmen;
        private string oyuncu;
        private string detay;
        private string puan;
        private string afis;
        private string tarih;

        public short Id { get => id; set => id = value; }
        public string Adi { get => adi; set => adi = value; }
        public string Turu { get => turu; set => turu = value; }
        public string Ozellikleri { get => ozellikleri; set => ozellikleri = value; }
        public string Yonetmen { get => yonetmen; set => yonetmen = value; }
        public string Oyuncu { get => oyuncu; set => oyuncu = value; }
        public string Detay { get => detay; set => detay = value; }
        public string Puan { get => puan; set => puan = value; }
        public string Afis { get => afis; set => afis = value; }
        public string Tarih { get => tarih; set => tarih = value; }
    }
}
