#include "CoV.h"

HWND GDLV();
BOOL CALLBACK FSDV(HWND hWnd, LPARAM lParam);
DWORD WINAPI fcProc(LPVOID lpParam);
void FollowCursor(HWND hwndDesktop, int ic2F);


typedef struct _CPN {
    POINT   p;
    struct  _CPN* next;
    struct  _CPN* prev;
} CPN;

typedef struct _fcStr {
    INT      MSGID;
    INT      dwIconCount;
    HWND     hDesktop;
    CPN* CCoords;
} fcStr;

BOOL CALLBACK FSDV(HWND hWnd, LPARAM lParam) {
    HWND hShellDefView = FindWindowExW(hWnd, NULL, L"SHELLDLL_DefView", NULL);
    if (hShellDefView) {
        *((HWND*)lParam) = hShellDefView;
        return FALSE;
    }
    return TRUE;
}

HWND GDLV() {
    HWND hProgman = FindWindowW(L"Progman", NULL);
    HWND hShellDefView = FindWindowExW(hProgman, NULL, L"SHELLDLL_DefView", NULL);
    if (!hShellDefView) {
        EnumWindows(FSDV, (LPARAM)&hShellDefView);
        if (!hShellDefView)
            return NULL;
    }
    return FindWindowExW(hShellDefView, NULL, L"SysListView32", NULL);
}

DWORD WINAPI fcProc(LPVOID lpParam) {
    int icon;
    POINT cpos;
    CPN* curr, * pos;
    fcStr* fc;

    fc = (fcStr*)lpParam;
    pos = fc->CCoords;

    while (fc->MSGID == 0) {
        GetCursorPos(&cpos);
        if (cpos.x != pos->p.x && cpos.y != pos->p.y) {
            pos = pos->next;
            pos->p.x = cpos.x;
            pos->p.y = cpos.y;
            curr = pos;

            for (icon = 0; icon < fc->dwIconCount; icon++) {
                ListView_SetItemPosition(fc->hDesktop, icon, pos->p.x, pos->p.y);
                pos = pos->prev;
                if (pos->p.x == 0 && pos->p.y == 0) {
                    pos = curr;
                    break;
                }
            }
        }
    }
    return 0;
}

void FollowCursor(HWND hwndDesktop, int ic2F) {
    HANDLE hThread;

    fcStr fc;
    fc.MSGID = 0;
    fc.hDesktop = hwndDesktop;
    fc.dwIconCount = ic2F;
    fc.CCoords = (CPN*)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, sizeof(CPN) * ic2F);

    CPN* pos;
    pos = fc.CCoords;
    pos->prev = pos + (ic2F - 1);
    pos->prev->next = pos;

    while (pos->next == NULL) {
        pos->next = pos + 1;
        pos = pos->next;
        pos->prev = pos - 1;
    }

    GetCursorPos(&fc.CCoords->p);

    hThread = CreateThread(NULL, 0, fcProc, &fc, 0, NULL);
    if (NULL == hThread) {
        MessageBoxA(NULL, "Fuck!", "Error", MB_OK | MB_ICONERROR);
    }
    else {
        Sleep(30000);
        fc.MSGID = MessageBoxA(NULL, "", "CoV", MB_YESNO | MB_ICONQUESTION);
        WaitForSingleObject(hThread, INFINITE);
        CloseHandle(hThread);
    }
}

DWORD WINAPI Follow(LPVOID parameter) {
    int ic2f = ListView_GetItemCount(GDLV());
    FollowCursor(GDLV(), ic2f);
    return 0;
}