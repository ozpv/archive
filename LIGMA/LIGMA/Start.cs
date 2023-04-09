using System;
using System.Threading;
using System.Windows.Forms;

namespace LIGMA {
    
    static class Start {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (MessageBox.Show("The Program You Just Considered Running Is Classified as Malware\n" + "Therefore Clicking Yes Will Infect Your System\n" + "Are You Sure You Want To Execute It, Infecting Your System?", "Disclaimer", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                StepTwo();
            }
            else {
                Application.Exit();
            }
        }

        static void StepTwo() {
        
            if (MessageBox.Show("ARE YOU SURE?\n" + "\n" + "THE CREATOR IS NOT RESPONSIBLE FOR ANY DAMAGE DONE USING THIS TROJAN\n" + "DO YOU STILL WANT TO EXECUTE THE TROJAN INFECTING YOUR SYSTEM?", "LAST CHANCE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                CheckOS();
            }
            else {
                Application.Exit();
            }

        }

        static void CheckOS() {
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;
            string operatingSystem = "";
            if (os.Platform == PlatformID.Win32NT) {
                switch (vs.Major) {
                    case 6:
                        if (vs.Minor == 2)
                            operatingSystem = "8";
                        else if (vs.Minor == 3)
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }
            if (operatingSystem == "10") {
                MessageBox.Show("This Trojan doesn't work on Windows 10" + "\n" + "Please use Windows 7 to test this Trojan", "LIGMA", 0, MessageBoxIcon.Error);
                Application.Exit();
            }
            else if (operatingSystem == "8") {
                MessageBox.Show("This Trojan doesn't work on Windows 8 or 8.x" + "\n" + "Please use Windows 7 to test this Trojan", "LIGMA", 0, MessageBoxIcon.Error);
                Application.Exit();
            }
            else if (operatingSystem == "8.1") {
                MessageBox.Show("This Trojan doesn't work on Windows 8 or 8.x" + "\n" + "Please use Windows 7 to test this Trojan", "LIGMA", 0, MessageBoxIcon.Error);
                Application.Exit();
            }

            StartThread();

        }

        static void StartThread() {
            new Thread(new ThreadStart(MainThread.Payloads)).Start();
        }
    }
}
