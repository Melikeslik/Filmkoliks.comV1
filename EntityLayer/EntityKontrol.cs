using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKontrol
    {
        private string filmAdi;
        private string tarih;
        private string saat;
        private string salonAdi;
        private string koltuklar;

        public string FilmAdi { get => filmAdi; set => filmAdi = value; }
        public string Tarih { get => tarih; set => tarih = value; }
        public string Saat { get => saat; set => saat = value; }
        public string SalonAdi { get => salonAdi; set => salonAdi = value; }
        public string Koltuklar { get => koltuklar; set => koltuklar = value; }
    }
}
