using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityBiletler
    {
        private short id;
        private string bKod;
        private string adSoyad;
        private string telNo;
        private string koltukNo;
        private string filmAdi;
        private string tarih;
        private string saat;
        private string salon;
        private string tur;
        private string islemSaati;

        public short Id { get => id; set => id = value; }
        public string BKod { get => bKod; set => bKod = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public string TelNo { get => telNo; set => telNo = value; }
        public string KoltukNo { get => koltukNo; set => koltukNo = value; }
        public string FilmAdi { get => filmAdi; set => filmAdi = value; }
        public string Tarih { get => tarih; set => tarih = value; }
        public string Saat { get => saat; set => saat = value; }
        public string Salon { get => salon; set => salon = value; }
        public string Tur { get => tur; set => tur = value; }
        public string IslemSaati { get => islemSaati; set => islemSaati = value; }
    }
}
