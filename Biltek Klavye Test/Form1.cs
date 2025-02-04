using System;
using System.Windows.Forms;

namespace OzayAkcan.BiltekKlavyeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
			Icon = Properties.Resources.app_icon;
		}

        public void TusGonder(Keys key)
        {
            Console.WriteLine(key.ToString());
        }
    }
}
