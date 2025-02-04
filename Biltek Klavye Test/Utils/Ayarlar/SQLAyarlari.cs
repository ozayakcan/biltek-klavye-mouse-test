using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System;
using System.Data.SqlTypes;
using System.Collections.Generic;
using OzayAkcan.Utils.Extensions;

namespace OzayAkcan.Utils.Ayar
{
    public class SQLAyarlari
    {

        [JsonConstructor]
        public SQLAyarlari()
        {
            server = "localhost\\SQLEXPRESS";
            kullaniciAdi = "sa";
            sifre = "";
            veritabani = "";
        }

        public string server { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public string veritabani { get; set; }

        public string ConnectionString()
        {
            SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
            {
                DataSource = server,
                InitialCatalog = veritabani,
                UserID = kullaniciAdi,
                IntegratedSecurity = false,
            };
            if (!string.IsNullOrEmpty(sifre))
            {
                sConnB.Password = sifre;
            }
            return sConnB.ConnectionString;
        }
        public bool Baglan()
        {
            using (SqlConnection _con = new SqlConnection(ConnectionString()))
            {
                try
                {
                    _con.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
        public class STSABIT
        {
            public string STOK_ADI { get; set; }
            public string SATIS_FIAT1 { get; set; }
            public string SATIS_FIAT2 { get; set; }
            public string SATIS_FIAT3 { get; set; }
            public string SATIS_FIAT4 { get; set; }
            public string BARKOD1 { get; set; }
        }
        public string Stoklar(string barkod)
        {
            string jsonString = "{}";
            using (SqlConnection con = new SqlConnection(ConnectionString()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TBLSTSABIT WHERE BARKOD1='" + barkod + "' ORDER BY STOK_KODU COLLATE Turkish_CI_AS", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            STSABIT stSabit = new STSABIT();
                            stSabit.STOK_ADI = reader["STOK_ADI"].ToString().TurkceyeCevir();
                            stSabit.SATIS_FIAT1 = reader["SATIS_FIAT1"].ToString();
                            stSabit.SATIS_FIAT2 = reader["SATIS_FIAT2"].ToString();
                            stSabit.SATIS_FIAT3 = reader["SATIS_FIAT3"].ToString();
                            stSabit.SATIS_FIAT4 = reader["SATIS_FIAT4"].ToString();
                            stSabit.BARKOD1 = reader["BARKOD1"].ToString();

                            ///if (reader["store"] != DBNull.Value)

                            jsonString = JsonConvert.SerializeObject(stSabit, Formatting.Indented);
                            break;
                        }
                    }
                }
            }
        
            return jsonString;   
        }

    }
}
