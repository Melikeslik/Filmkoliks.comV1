using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityKullanicilar
    {
        private short id;
        private string kAdi;
        private string kSifre;
        private string adSoyad;

        public short Id { get => id; set => id = value; }
        public string KAdi { get => kAdi; set => kAdi = value; }
        public string KSifre { get => kSifre; set => kSifre = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
    }
}
