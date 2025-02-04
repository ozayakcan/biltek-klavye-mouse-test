using System.IO;
using Newtonsoft.Json;

namespace OzayAkcan.Utils
{
    public class JsonFile
    {
        public static string SavePath = "";
        public static string FullPath(string name)
        {
            return Path.Combine(SavePath, name + ".dat"); ;
        }
        public static string FullPathNormal(string name)
        {
            return Path.Combine(SavePath, name + ".json"); ;
        }

        public static void Write(string path, object obj, bool encrypt = true)
        {
            string str = JsonConvert.SerializeObject(obj, encrypt ? Formatting.None : Formatting.Indented);
            KlasorOlustur(encrypt ? FullPath(path) : FullPathNormal(path));
            if (encrypt)
               str = Encryption.Encrypt(str);
            File.WriteAllText(encrypt ? FullPath(path) : FullPathNormal(path), str);
        }
        public static T Read<T>(string path, bool encrypt = true)
        {
            string str = null;
            if (!string.IsNullOrEmpty(encrypt ? FullPath(path) : FullPathNormal(path)) && File.Exists(encrypt ? FullPath(path) : FullPathNormal(path)))
            {
                KlasorOlustur(encrypt ? FullPath(path) : FullPathNormal(path));
                str = File.ReadAllText(encrypt ? FullPath(path) : FullPathNormal(path));
                if (encrypt)
                    str = Encryption.Decrypt(str);
            }
            if (str == null)
                str = "{}";

            return JsonConvert.DeserializeObject<T>(str);
        }

        public static void KlasorOlustur(string path)
        {
            string dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
    }
}
