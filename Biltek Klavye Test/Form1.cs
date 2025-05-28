using OzayAkcan.BiltekKlavyeTest.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace OzayAkcan.BiltekKlavyeTest
{
    public partial class Form1 : Form
    {

        List<Panel> panels = new List<Panel>();
        public Form1()
        {
            InitializeComponent();
            panels.Add(pnlKeys1);
            panels.Add(pnlKeys2);
            panels.Add(pnlKeys3);
            panels.Add(pnlKeys3_4_Parent);
            panels.Add(pnlKeys4);
            panels.Add(pnlKeys5_6_Parent);
            panels.Add(pnlKeys5);
            panels.Add(pnlKeys6);
            panels.Add(pnlKeys7);
            Application.AddMessageFilter(new MouseFilter(this));
            Icon = Properties.Resources.app_icon;
            kcQuote.Text = karakterGetir("é", "\"", "<");
            kcStar.Text = karakterGetir("?", "*", "\\");
            kcUnderline.Text = karakterGetir("-", "_", "|");
            kcNoktaliVirgul.Text = karakterGetir(";", ",", "  `");
            kcSolOk.Text = karakterGetir("<", ">", "|");
            kcVirgul.Text = ",\nDel";
        }

        private string karakterGetir(string karakter1, string karakter2, string karakter3)
        {
            return karakter1 + "    \n" + karakter2 + "   " + karakter3;
        }
        public void TusGonder(Keys key, bool down)
        {
            string ky = key.ToString();
            Console.WriteLine(ky);
            TusGonder(ky, down);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        public void TusGonder(string key, bool down)
        {
            List<KeyControl> keyControls = new List<KeyControl>();
            foreach (var panel in panels)
            {
                foreach (var control in panel.Controls)
                {
                    if (control is KeyControl)
                    {
                        KeyControl keyControlTemp = (KeyControl)control;
                        if (keyControlTemp.KeyName.ToLower() == key.ToLower())
                        {
                            keyControls.Add(keyControlTemp);
                            break;
                        }
                    }
                }
                if (keyControls.FindIndex(kc => kc.KeyName == "return") >= 0)
                    continue;
                else if (keyControls.Count > 0)
                    break;
            }
            foreach (var keyControl in keyControls)
            {
                KeyControlHallet(keyControl, down);
            }
        }
        public void KeyControlHallet(KeyControl keyControl, bool down)
        {
            keyControl.BackColor = down ? Color.LightSeaGreen : Color.White;
            keyControl.ForeColor = down ? Color.Black : Color.Black;
        }

        internal void MouseGonder(Program.MouseMessages mouseMessages)
        {
            switch (mouseMessages)
            {
                case Program.MouseMessages.WM_LBUTTONDOWN:
                    KeyControlHallet(kcMouseLeft, true);
                    break;
                case Program.MouseMessages.WM_LBUTTONUP:
                    KeyControlHallet(kcMouseLeft, false);
                    break;
                case Program.MouseMessages.WM_MBUTTONDOWN:
                    KeyControlHallet(kcMouseMiddle, true);
                    break;
                case Program.MouseMessages.WM_MBUTTONUP:
                    KeyControlHallet(kcMouseMiddle, false);
                    break;
                case Program.MouseMessages.WM_RBUTTONDOWN:
                    KeyControlHallet(kcMouseRight, true);
                    break;
                case Program.MouseMessages.WM_RBUTTONUP:
                    KeyControlHallet(kcMouseRight, false);
                    break;
            }
        }
    }
}
