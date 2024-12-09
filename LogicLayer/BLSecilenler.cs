using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BLSecilenler
    {
        public static string SecilenYonetmenleriAl()
        {
            // DAL katmanından seçilen yönetmenleri alıyoruz
            List<EntitySecilenler> secilenYonetmenler = DALSecilenler.SecilenYonetmenleriGetir();

            // StringBuilder kullanarak yönetmen isimlerini topluyoruz
            StringBuilder yonetmenString = new StringBuilder();

            foreach (var secilen in secilenYonetmenler)
            {
                yonetmenString.Append(" , ").Append(secilen.Kisi);
            }

            return yonetmenString.ToString();
        }

        // Oyuncuları alıp StringBuilder ile birleştiren metod
        public static string SecilenOyunculariAl()
        {
            List<EntitySecilenler> secilenOyuncular = DALSecilenler.SecilenOyunculariGetir();
            StringBuilder oyuncuString = new StringBuilder();

            foreach (var secilen in secilenOyuncular)
            {
                oyuncuString.Append(" , ").Append(secilen.Kisi);
            }

            return oyuncuString.ToString();
        }

        // Oyuncunun seçili olup olmadığını kontrol eden metod
        public static bool SecilenOyuncuVarMi(string kisi)
        {
            return DALSecilenler.SecilenOyuncuVarMi(kisi);
        }

        // Yönetmenin seçili olup olmadığını kontrol eden metod
        public static bool SecilenYonetmenVarMi(string kisi)
        {
            return DALSecilenler.SecilenYonetmenVarMi(kisi);
        }

        // Oyuncu ve yönetmen ekleme metodlarını çağırıyoruz
        public static void SecilenOyuncuEkle(string kisi)
        {
            DALSecilenler.SecilenOyuncuEkle(kisi);
        }

        public static void SecilenYonetmenEkle(string kisi)
        {
            DALSecilenler.SecilenYonetmenEkle(kisi);
        }

        // Oyuncu ve yönetmen silme metodlarını çağırıyoruz
        public static void SecilenOyuncuSil(string kisi)
        {
            DALSecilenler.SecilenOyuncuSil(kisi);
        }

        public static void SecilenYonetmenSil(string kisi)
        {
            DALSecilenler.SecilenYonetmenSil(kisi);
        }
    }
}
