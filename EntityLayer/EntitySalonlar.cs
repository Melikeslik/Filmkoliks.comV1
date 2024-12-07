using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntitySalonlar
    {
        private short id;
        private string salonAdi;
        private string koltukSayisi;

        public short Id { get => id; set => id = value; }
        public string SalonAdi { get => salonAdi; set => salonAdi = value; }
        public string KoltukSayisi { get => koltukSayisi; set => koltukSayisi = value; }
    }
}
