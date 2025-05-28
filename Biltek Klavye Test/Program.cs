using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OzayAkcan.BiltekKlavyeTest
{
    internal static class Program
    {

        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_KEYUP = 0x0101;
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE_LL = 14;
        private static MouseKeyboardProc _proc = HookCallback;
        private static int _hookID = 0;
        private static int _hookIDMouse = 0;
        private static MouseKeyboardProc mouseHookCallback = null;


        //public static Form activeForm = null;

        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string isim = Assembly.GetExecutingAssembly().GetName().Name;
            var currentProcess = System.Diagnostics.Process.GetCurrentProcess();

            // search for another process with the same name
            var anotherProcess = System.Diagnostics.Process.GetProcesses().FirstOrDefault(p => p.ProcessName == currentProcess.ProcessName && p.Id != currentProcess.Id);

            if (anotherProcess != null)
            {
                IntPtr h = anotherProcess.MainWindowHandle;
                SetForegroundWindow(h);
                return; 
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _hookID = SetHook(_proc);
            _hookIDMouse = SetHookMouse();

            Application.Run(new Form1());
            
            UnhookWindowsHookEx(_hookID);
            UnhookWindowsHookEx(_hookIDMouse);
        }
        private static int SetHook(MouseKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private static int SetHookMouse()
        {
            mouseHookCallback = new MouseKeyboardProc(HookCallbackMouse);

            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, mouseHookCallback, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate int MouseKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        public enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,


        }

        private static int HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Form1 form1 = Application.OpenForms["Form1"] as Form1;
                MouseMessages mouseMessages = (MouseMessages)wParam;
                if (form1 != null)
                {
                    Keys key = (Keys)vkCode;
                    if(key == Keys.RMenu)
                        form1.TusGonder(Keys.RMenu, wParam == (IntPtr)WM_KEYDOWN);
                    else
                        form1.TusGonder((Keys)vkCode, wParam == (IntPtr)WM_KEYDOWN);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        private static int HookCallbackMouse(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                Form1 form1 = Application.OpenForms["Form1"] as Form1;
                MouseMessages mouseMessages = (MouseMessages)wParam;
                if (form1 != null)
                    form1.MouseGonder(mouseMessages);
            }
            return CallNextHookEx(_hookIDMouse, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetWindowsHookEx(int idHook,
            MouseKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(int hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int CallNextHookEx(int hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int GetCurrentThreadId();

    }
}
