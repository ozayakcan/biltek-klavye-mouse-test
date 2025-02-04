using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzayAkcan.BiltekKlavyeTest
{
    public class MouseFilter : IMessageFilter
    {
        protected static bool inEffect = false;
        public static bool ActiveFiltering { set { inEffect = value; } }
        const int LButtonDown = 0x201;
        const int LButtonUp = 0x202;
        const int LButtonDoubleClick = 0x203;

        Form1 form1;
        public MouseFilter(Form1 form1)
        {
            this.form1 = form1;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool PreFilterMessage(ref Message m)
        {
            if (!inEffect)
                return false;
            bool result = false;
            switch (m.Msg)
            {
                case LButtonDown:
                case LButtonUp:
                case LButtonDoubleClick:
                    result = true;
                    break;
            }
            return result;
        }
    }
}
