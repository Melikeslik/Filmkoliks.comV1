using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BLKontrol
    {
        public static List<EntityKontrol> SaatleriGetir(string filmAdi, string tarih)
        {
            return DataAccessLayer.DALKontrol.SaatleriGetir(filmAdi, tarih);
        }
    }
}
