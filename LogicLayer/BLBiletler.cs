using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class BLBiletler
    {
        //public static List<EntityBiletler> BLBiletListesi()
        //{
        //    return DALBiletler.BiletListesi();

        //}

        public static EntityBiletler BLBiletGetir(string biletNo)
        {
            if (!string.IsNullOrEmpty(biletNo))
            {
                // BKOD boş değilse DAL katmanına iletilir
                return DALBiletler.BiletGetir(biletNo);
            }
            else
            {
                // Eğer bilet numarası boşsa null döndür
                return null;
            }
        }

        public static int BLBiletEkle(EntityBiletler bilet)
        {
            return DALBiletler.BiletEkle(bilet);
        }

        public static bool BLBiletGuncelle(EntityKontrol ent)
        {
            return true;
        }
    }
}
