using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace PayloadTest
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hWnd);

        [STAThread]
        static void Main()
        {
            Random r = new Random();
            IntPtr dc = GetDC(IntPtr.Zero);
            
        }
        static void FallingBlocks() {
            Random r = new Random();
            IntPtr dc = GetDC(IntPtr.Zero);
            using (Graphics graphics11 = Graphics.FromHdc(dc))
            {
                for (int num7 = 0; num7 < 20; num7++)
                {
                    int num8 = r.Next(0, Screen.PrimaryScreen.Bounds.Width);
                    int num9 = r.Next(0, Screen.PrimaryScreen.Bounds.Height);
                    int x = r.Next(0, Screen.PrimaryScreen.Bounds.Width);
                    int y = r.Next(0, Screen.PrimaryScreen.Bounds.Height);
                    int num10 = r.Next(0, Screen.PrimaryScreen.Bounds.Width);
                    int num11 = r.Next(0, Screen.PrimaryScreen.Bounds.Height);
                    if (num8 + num10 >= Screen.PrimaryScreen.Bounds.Width)
                    {
                        num10 = Screen.PrimaryScreen.Bounds.Width - num8 - 1;
                    }
                    if (num9 + num11 >= num9)
                    {
                        num11 = Screen.PrimaryScreen.Bounds.Height - num9 - 1;
                    }
                    Bitmap bitmap5 = new Bitmap(num10, num11);
                    Graphics graphics12 = Graphics.FromImage(bitmap5);
                    graphics12.CopyFromScreen(new Point(num8, num9), new Point(0, 0), new Size(num10, num11));
                    graphics12.Dispose();
                    graphics11.ScaleTransform(-1f, 1f);
                    graphics11.DrawImage(bitmap5, new Rectangle(x, y, bitmap5.Width, bitmap5.Height), 0, 0, bitmap5.Width, bitmap5.Height, GraphicsUnit.Pixel);
                }
            }
        }
        static void Invert() {
            while (true)
            {
                float[][] array = new float[5][];
                int num3 = 0;
                float[] array2 = new float[5];
                array2[0] = -1f;
                array[num3] = array2;
                int num4 = 1;
                float[] array3 = new float[5];
                array3[1] = -1f;
                array[num4] = array3;
                int num5 = 2;
                float[] array4 = new float[5];
                array4[2] = -1f;
                array[num5] = array4;
                int num6 = 3;
                float[] array5 = new float[5];
                array5[3] = 1f;
                array[num6] = array5;
                array[4] = new float[]
                {
                    1f,
                    1f,
                    1f,
                    0f,
                    1f
                };
                ColorMatrix colorMatrix = new ColorMatrix(array);
                IntPtr dc = GetDC(IntPtr.Zero);
                using (Graphics graphics9 = Graphics.FromHdc(dc))
                {
                    Bitmap bitmap4 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Graphics graphics10 = Graphics.FromImage(bitmap4);
                    graphics10.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                    graphics10.Dispose();
                    ImageAttributes imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorMatrix(colorMatrix);
                    graphics9.DrawImage(bitmap4, new Rectangle(0, 0, bitmap4.Width, bitmap4.Height), 0, 0, bitmap4.Width, bitmap4.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }
        }
        static void ZoomPaint() {
            while (true)
            {
                Random r = new Random();
                IntPtr dc = GetDC(IntPtr.Zero);
                using (Graphics graphics3 = Graphics.FromHdc(dc))
                {
                    Bitmap bitmap2 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Graphics graphics4 = Graphics.FromImage(bitmap2);
                    graphics4.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                    graphics4.Dispose();
                    graphics3.ScaleTransform((float)(r.NextDouble() * 6.0 - 3.0), (float)(r.NextDouble() * 6.0 - 3.0));
                    graphics3.DrawImage(bitmap2, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), 0, 0, bitmap2.Width, bitmap2.Height, GraphicsUnit.Pixel);
                }
            }
        }
        static void ShiftUp() {
            int x5 = 0;
            IntPtr dc = GetDC(IntPtr.Zero);
            while (true)
            {
                using (Graphics graphics3 = Graphics.FromHdc(dc))
                {
                    Bitmap bitmap2 = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Graphics graphics4 = Graphics.FromImage(bitmap2);
                    graphics4.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                    graphics4.Dispose();
                    graphics3.DrawImage(bitmap2, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height - 1), 0, 1, bitmap2.Width, bitmap2.Height - 1, GraphicsUnit.Pixel);
                }
                int num = x5;
                x5 = num + 1;
                if (num == 200)
                {
                    x5 = 0;
                }
            }
        }

        static void SmallDesktop() {
            Double a1 = 0;
            Double a2 = 0;
            int x0 = 0;
            IntPtr dc = GetDC(IntPtr.Zero);
            using (Graphics graphics = Graphics.FromHdc(dc))
            {
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics2 = Graphics.FromImage(bitmap);
                graphics2.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                graphics2.Dispose();
                float num2 = (float)(Math.Sin(a1) * 1.5 + 0.5);
                graphics.ScaleTransform(num2, num2);
                graphics.RotateTransform((float)a2);
                graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            }
            a1 += 2.0;
            a2 += 3.0;
            int num = x0;
            x0 = num + 1;
            if (num == 200)
            {
                x0 = 0;
            }
        }
        static void transformRotate() {
            Random r = new Random();
            IntPtr dc = GetDC(IntPtr.Zero);
            using (Graphics graphics = Graphics.FromHdc(dc))
            {
                Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics2 = Graphics.FromImage(bitmap);
                graphics2.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                graphics2.Dispose();
                graphics.RotateTransform((float)(r.NextDouble() * 150.0));
                graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            }
        }
    }
}
