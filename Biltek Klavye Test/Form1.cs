using OzayAkcan.BiltekKlavyeTest.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OzayAkcan.BiltekKlavyeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
			Icon = Properties.Resources.app_icon;
            kcQuote.Text = karakterGetir("é", "\"", "<");
            kcStar.Text = karakterGetir("?", "*", "\\");
            kcUnderline.Text = karakterGetir("-", "_", "|");
        }

        private string karakterGetir(string karakter1, string karakter2, string karakter3)
        {
            return karakter1 + "    \n" + karakter2 + "   " + karakter3;
        }
        public void TusGonder(Keys key, bool down)
        {
            string ky = key.ToString();
            Console.WriteLine(ky);
            KeyControl keyControl = null;
            switch (ky.ToLower())
            {
                // Satır 1
                case "escape":
                    keyControl = kcEsc;
                    break;
                case "f1":
                    keyControl = kcF1;
                    break;
                case "f2":
                    keyControl = kcF2;
                    break;
                case "f3":
                    keyControl = kcF3;
                    break;
                case "f4":
                    keyControl = kcF4;
                    break;
                case "f5":
                    keyControl = kcF5;
                    break;
                case "f6":
                    keyControl = kcF6;
                    break;
                case "f7":
                    keyControl = kcF7;
                    break;
                case "f8":
                    keyControl = kcF8;
                    break;
                case "f9":
                    keyControl = kcF9;
                    break;
                case "f10":
                    keyControl = kcF10;
                    break;
                case "f11":
                    keyControl = kcF11;
                    break;
                case "f12":
                    keyControl = kcF12;
                    break;
                case "printscreen":
                    keyControl = kcPrintScreen;
                    break;
                case "scroll":
                    keyControl = kcScrollLock;
                    break;
                case "pause":
                    keyControl = kcPauseBreak;
                    break;
                case "home":
                    keyControl = kcHome;
                    break;
                case "end":
                    keyControl = kcEnd;
                    break;

            }
            if(keyControl != null)
                KeyControlHallet(keyControl, down);
        }
        public void KeyControlHallet(KeyControl keyControl, bool down)
        {
            keyControl.BackColor = down ? Color.LightSeaGreen : Color.White;
            keyControl.ForeColor = down ? Color.Black : Color.Black;
        }
    }
}
