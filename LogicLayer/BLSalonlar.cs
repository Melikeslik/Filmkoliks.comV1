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

        public static List<EntitySalonlar> BLSalonAdiGetir()
        {
            return DALSalonlar.SalonAdiGetir();
        }

        public static void SalonKaydet(EntitySalonlar entitySalon)
        {
            if (!string.IsNullOrEmpty(entitySalon.SalonAdi) && !string.IsNullOrEmpty(entitySalon.KoltukSayisi))
            {
                DALSalonlar.SalonKaydet(entitySalon);
            }
            else
            {
                throw new Exception("Salon adı veya koltuk sayısı boş olamaz.");
            }
        }
    }
}
