using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace LogicLayer
{
    public class BLSalonlar
    {
        public static EntitySalonlar SalonBilgisiGetir(string salonAdi)
        {
            if (!string.IsNullOrEmpty(salonAdi))
            {
                return DALSalonlar.SalonBilgisiGetir(salonAdi);
            }
            else
            {
                return null; // Geçersiz salon adı
            }
        }
    }
}
