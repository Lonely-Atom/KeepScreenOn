using System.Runtime.InteropServices;

namespace KeepScreenOn.Utils
{
    public class KeysPressHelper
    {
        // 导入keybd_event函数用于模拟按键
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int extraInfo);

        // 定义按键常量
        private const byte VK_CONTROL = 0x11;
        private const int KEYEVENTF_KEYUP = 0x0002;

        public static void PressControlKey()
        {
            // 模拟按下和释放Ctrl键
            keybd_event(VK_CONTROL, 0, 0, 0);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
