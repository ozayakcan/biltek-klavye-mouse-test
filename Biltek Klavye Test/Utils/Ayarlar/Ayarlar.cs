using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using OzayAkcan.Utils.Ayar;

namespace OzayAkcan.Utils
{
    public class Ayarlar
    {
        public static string Isim;
        public static Icon Icon;

        public readonly static string Name = "Ayarlar";
        public static void Init(string Isim, Icon Icon)
        {
#if DEBUG
            Getir = JsonFile.Read<Ayarlar>(Name, encrypt: false);
#else
            Getir = JsonFile.Read<Ayarlar>(Name, encrypt: true);
#endif
            Ayarlar.Isim = Isim;
            Ayarlar.Icon = Icon;
            Kaydet();
        }

        public static Ayarlar Getir;
        public bool ilkAcilis { get; set; }
        public SQLAyarlari sql { get; set; }
        public List<Kullanici> kullanicilar { get; set; }

        [JsonConstructor]
        public Ayarlar()
        {
            ilkAcilis = true;
            sql = new SQLAyarlari();
            kullanicilar = new List<Kullanici>();
        }

        public (Kullanici kullanici, int index) Kullanici(string kullaniciAdi)
        {
            int index = kullanicilar.FindIndex(k => k.kullaniciAdi == kullaniciAdi);
            if(index >= 0)
                return (kullanicilar[index], index);
            return (null, -1);
        }
        public static void Kaydet()
        {
#if DEBUG
            JsonFile.Write(Name, Getir, encrypt: false);
#else
            JsonFile.Write(Name, Getir, encrypt: true);
#endif
        }
    }
}
