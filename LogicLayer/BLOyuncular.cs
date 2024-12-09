using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class BLOyuncular
    {
        public static List<EntityOyuncular> BLOyuncuListesiGetir()
        {
            // DAL katmanından oyuncu listesini alıyoruz
            return DALOyuncular.OyuncuListesiGetir();
        }

        public static List<EntityOyuncular> BLOyuncuAra(string aranan)
        {
            // DAL katmanından oyuncu arama sonuçlarını alıyoruz
            return DALOyuncular.OyuncuAra(aranan);
        }

        // Oyuncu bilgilerini alıyoruz
        public static EntityOyuncular OyuncuGetir(short id)
        {
            return DALOyuncular.OyuncuGetir(id);
        }

        // Oyuncu silme işlemi
        public static bool OyuncuSil(short id)
        {
            return DALOyuncular.OyuncuSil(id);
        }

        // Oyuncu bilgilerini getiren metot
        public static EntityOyuncular GetOyuncuById(short id)
        {
            return DALOyuncular.GetOyuncuById(id);
        }

        // Oyuncu eklemek için metot
        public static void AddOyuncu(string adSoyad, string cinsiyet, string yas, string biyografi, string resimYolu)
        {
            // Entity'yi oluştur
            EntityOyuncular oyuncu = new EntityOyuncular
            {
                AdSoyad = adSoyad,
                Cinsiyet = cinsiyet,
                Yas = yas,
                Biyografi = biyografi,
                Resim = resimYolu
            };

            // DAL metodunu çağır
            DALOyuncular.AddOyuncu(oyuncu);
        }
    }
}
