using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityYonetmenler
    {
        private short id;
        private string adSoyad;
        private string cinsiyet;
        private string yas;
        private string biyografi;
        private string resim;

        public short Id { get => id; set => id = value; }
        public string AdSoyad { get => adSoyad; set => adSoyad = value; }
        public string Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        public string Yas { get => yas; set => yas = value; }
        public string Biyografi { get => biyografi; set => biyografi = value; }
        public string Resim { get => resim; set => resim = value; }
    }
}
