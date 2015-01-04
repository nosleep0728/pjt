using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingHelper.Util
{
    class WinUtil
    {

        // 싱글톤 패턴. 
        private WinUtil()
        {

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static public extern bool SetForegroundWindow(IntPtr hWnd);

        public void SendPasteMessage(IntPtr hWnd)
        {
            SetForegroundWindow(hWnd);
            SendKeys.SendWait("^v");
        }

        private static WinUtil _winUtil = new WinUtil();
        public static WinUtil Inst
        {
            get { return _winUtil; }
        }
    }
}
