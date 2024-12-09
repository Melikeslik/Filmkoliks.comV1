using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BLKullanicilar
    {
        public static bool GirisYap(EntityKullanicilar kullanici)
        {
            if (!string.IsNullOrEmpty(kullanici.KAdi) && !string.IsNullOrEmpty(kullanici.KSifre))
            {
                return DALKullanicilar.KullaniciGiris(kullanici);
            }
            else
            {
                return false; // Giriş bilgileri boş ise false döndür
            }
        }
    }
}
