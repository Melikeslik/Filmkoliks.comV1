using DataAccessLayer;
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

        public static bool KontrolGuncelle(EntityKontrol kontrol, string gelenKoltuk)
        {
            if (kontrol.FilmAdi != "" && kontrol.Tarih != "" && kontrol.Saat != "" && kontrol.SalonAdi != "")
            {
                // Veritabanı güncelleme işlemi
                int sonuc = DALKontrol.KontrolGuncelle(kontrol, gelenKoltuk);
                return sonuc > 0; // Eğer işlem başarılıysa true döner
            }
            else
            {
                return false; // Gerekli alanlar boşsa işlem başarısız
            }
        }

        // Salonları getiren metot
        public static List<string> GetSalonlar(EntityKontrol kontrol)
        {
            if (kontrol.FilmAdi != "" && kontrol.Tarih != "" && kontrol.Saat != "")
            {
                return DALKontrol.GetSalonlar(kontrol);
            }
            else
            {
                return null;
            }
        }

        public static List<EntityKontrol> KoltukBilgisiGetir(string filmAdi, string tarih, string saat, string salonAdi)
        {
            return DALKontrol.KoltukBilgisiGetir(filmAdi, tarih, saat, salonAdi);
        }
    }
}
