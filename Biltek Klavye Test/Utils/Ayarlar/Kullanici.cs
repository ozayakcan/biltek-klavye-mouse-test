using Newtonsoft.Json;

namespace OzayAkcan.Utils.Ayar
{
    public class Kullanici
    {
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }


        [JsonConstructor]
        public Kullanici()
        {
            kullaniciAdi = "";
            sifre = "";
        }
        public Kullanici(string kullaniciAdi, string sifre)
        {
            this.kullaniciAdi = kullaniciAdi;
            this.sifre = sifre;
        }
    }
}
