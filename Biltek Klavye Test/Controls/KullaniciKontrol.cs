using System.Windows.Forms;

namespace OzayAkcan.BiltekKlavyeTest.Controls
{
    public partial class KullaniciKontrol : UserControl
    {
        public delegate void myDataChangedDelegate(object sender, string kullaniciAdi);

        public event myDataChangedDelegate Duzenlendi;
        public event myDataChangedDelegate Silindi;
        public KullaniciKontrol(string kullaniciAdi)
        {
            InitializeComponent();
            lblKullaniciAdi.Text = kullaniciAdi;
        }

        private void btnDuzenle_Click(object sender, System.EventArgs e)
        {
            var eventSubscribers = Duzenlendi;
            if (eventSubscribers != null)
            {
                eventSubscribers(this, lblKullaniciAdi.Text);
            }
        }

        private void btnSil_Click(object sender, System.EventArgs e)
        {
            var eventSubscribers = Silindi;
            if (eventSubscribers != null)
            {
                eventSubscribers(this, lblKullaniciAdi.Text);
            }
        }
    }
}
