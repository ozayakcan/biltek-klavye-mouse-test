using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OzayAkcan.BiltekKlavyeTest.Controls
{
    public partial class KeyControl : UserControl
    {
        public KeyControl()
        {
            InitializeComponent();
            this.Text = this.Name;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.ResizeRedraw, true);
        }
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => lblText.Text;
            set
            {
                lblText.Text = value;

                Refresh();
            }
        }
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color ForeColor { 
            get => lblText.ForeColor;
            set
            {
                lblText.ForeColor = value;

                Refresh();
            } 
        }

        private bool _cornersOnly = false;
        public bool CornersOnly
        {
            get => _cornersOnly;
            set
            {
                _cornersOnly = value;
                Refresh();
            }
        }

        private string _keyName = "Key";
        public string KeyName
        {
            get => _keyName;
            set => _keyName = value;
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (CornersOnly)
            {
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, ClientSize.Width, ClientSize.Height, 20, 20));
            }
            else
            {
                GraphicsPath grPath = new GraphicsPath();
                grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new System.Drawing.Region(grPath);
                using (Pen pen = new Pen(this.BackColor, 1.75f))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, grPath);
                }
            }
            base.OnPaint(e);
        }
    }
}
