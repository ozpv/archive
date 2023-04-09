#include <windows.h>
#include <Tlhelp32.h>

BOOLEAN InfectionCheck() {
	HKEY ckey;
	long result = RegOpenKeyExW(HKEY_LOCAL_MACHINE, L"Software\\Microsoft\\Windows\\CurrentVersion\\COV", 0, KEY_ENUMERATE_SUB_KEYS | KEY_QUERY_VALUE | KEY_SET_VALUE, &ckey);
	if (result != 0L) {
		MessageBoxA(0, "CoV Never Infected Your System!", "CoV Remover", MB_ICONINFORMATION | MB_OK | MB_TOPMOST);
		return FALSE;
	}
	else
		return TRUE;
}

int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrev, LPSTR lpCmdLine, int nShowCmd) {
	HKEY ckey;
	DWORD dwTrue = 1, dwFalse = 0, dw;

	if (InfectionCheck() == TRUE) {
		DeleteFile(L"C:\\Windows\\System32\\CoV.exe");

		RegDeleteKeyW(HKEY_LOCAL_MACHINE, L"Software\\Microsoft\\Windows\\CurrentVersion\\COV");

		RegCreateKeyW(HKEY_LOCAL_MACHINE, L"Software\\Microsoft\\Windows\\CurrentVersion\\Run", &ckey);
		RegDeleteValueW(ckey, L"CoV");
		RegCloseKey(ckey);

		RegCreateKeyW(HKEY_CURRENT_USER, L"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", &ckey);
		RegDeleteValueW(ckey, L"DisableRegistryTools");
		RegCloseKey(ckey);

		RegCreateKeyW(HKEY_LOCAL_MACHINE, L"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", &ckey);
		RegDeleteValueW(ckey, L"EnableLUA");
		RegCloseKey(ckey);

		SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, 0, L"Environment", SMTO_ABORTIFHUNG, 5000, &dw);

		MessageBoxA(0, "Sucessfully Removed CoV!", "CoV Remover", MB_ICONINFORMATION | MB_OK | MB_TOPMOST);
		return 0;
	}
	else
		exit(1);
}