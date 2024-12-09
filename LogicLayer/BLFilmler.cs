using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class BLFilmler
    {
        public static List<EntityFilmler> BLFilmListesiGetir()
        {
            // Veritabanından film listesini alıyoruz
            List<EntityFilmler> filmListesi = DALFilmler.FilmListesiGetir();

            // Tarih kontrolü yaparak bugünden önceki filmleri seçiyoruz
            List<EntityFilmler> uygunFilmler = new List<EntityFilmler>();
            DateTime bugun = DateTime.Today;

            foreach (var film in filmListesi)
            {
                // Burada film.Tarih ile bugünü karşılaştırıyoruz
                if (Convert.ToDateTime(film.Tarih) <= bugun)
                {
                    uygunFilmler.Add(film);
                }
            }

            return uygunFilmler;
        }

        // Film adı seçildiğinde tarihler listesini döndüren metod
        public static List<string> BLTarihListesiGetir(string filmAdi)
        {
            // Veritabanından film adına göre tarihler listesini alıyoruz
            List<string> tarihListesi = DALFilmler.TarihListesiGetir(filmAdi);

            // Bugünden önceki tarihleri filtreliyoruz
            List<string> uygunTarihler = new List<string>();
            DateTime bugun = DateTime.Today;

            foreach (var tarih in tarihListesi)
            {
                DateTime filmTarihi = Convert.ToDateTime(tarih);
                if (filmTarihi >= bugun)
                {
                    uygunTarihler.Add(tarih); // Bugünden sonraki tarihleri ekliyoruz
                }
            }

            return uygunTarihler;
        }


        // Film detaylarını getiren metod
        public static EntityFilmler BLFilmDetayGetir(short id)
        {
            return DALFilmler.FilmDetayGetir(id);
        }

        // Filmin tüm alanlarını kontrol eden metod
        public static string FilmEkle(EntityFilmler film)
        {
            if (string.IsNullOrEmpty(film.Adi) || string.IsNullOrEmpty(film.Turu) || string.IsNullOrEmpty(film.Ozellikleri) ||
                string.IsNullOrEmpty(film.Yonetmen) || string.IsNullOrEmpty(film.Oyuncu) || string.IsNullOrEmpty(film.Detay) ||
                string.IsNullOrEmpty(film.Puan) || string.IsNullOrEmpty(film.Afis) || string.IsNullOrEmpty(film.Tarih))
            {
                return "Lütfen tüm alanları doldurunuz!";
            }

            // Eğer tüm alanlar doluysa veritabanına kaydetme işlemi başlatılıyor
            int sonuc = DALFilmler.FilmEkle(film);

            return sonuc > 0 ? "Film başarıyla kaydedildi!" : "Film kaydedilirken bir hata oluştu!";
        }

        // Filmler listesini döndüren metot
        public static List<EntityFilmler> GetAllFilmler()
        {
            return DALFilmler.GetAllFilmler();
        }

        // Arama yapılacak metni alır ve ilgili filmleri döndürür
        public static List<EntityFilmler> GetFilmlerBySearch(string searchText)
        {
            return DALFilmler.GetFilmlerBySearch(searchText);
        }
    }
}
