namespace OzayAkcan.Utils.Extensions
{
    public static class Turkce
    {
        public static string TurkceyeCevir(this string text)
        {
            return text
                    .Replace("\u00dd", "İ")
                    .Replace("\u00fd", "ı")
                    .Replace("\u00d0", "Ğ")
                    .Replace("\u00f0", "ğ")
                    .Replace("\u00de", "Ş")
                    .Replace("\u00fe", "ş")
                    .Replace("\u00dc", "Ü")
                    .Replace("\u00fc", "ü")
                    .Replace("\u00d6", "Ö")
                    .Replace("\u00f6", "Ö")
                    .Replace("\u00c7", "Ç")
                    .Replace("\u00e7", "ç");
        }
    }
}
