using System.Runtime.InteropServices;

namespace CustomWindow
{
    internal class Win32API
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // 常用的 ShowWindow 参数
        public const int SW_RESTORE = 9;  // 恢复窗口至正常状态
        public const int SW_MAXIMIZE = 3; // 最大化窗口
        public const int SW_MINIMIZE = 6; // 最小化窗口
        public const int SW_NORMAL = 1;   // 普通窗口（即默认大小）


        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(
           IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // 这个常量表示不改变窗口的 z-order，仅仅修改窗口的大小
        public const uint SWP_NOZORDER = 0x0004;
    }
}
