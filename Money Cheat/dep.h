#include <windows.h>
#include <TlHelp32.h>

DWORD GetPIDByName(LPCWSTR processname) {
	DWORD pid;
	HANDLE snap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, NULL);
	PROCESSENTRY32W processentry;
	processentry.dwSize = sizeof(PROCESSENTRY32W);
	while (1) {
		if (!Process32NextW(snap, &processentry))
			return 0;
		else if (!lstrcmpW(processname, processentry.szExeFile)) {
			pid = processentry.th32ProcessID;
			break;
		}
		else continue;
	}
	CloseHandle(snap);
	return pid;
}

uintptr_t GetModuleBaseAddress(LPCWSTR modulename, DWORD pid) {
    uintptr_t baseaddress;
    HANDLE snap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE, pid);
    MODULEENTRY32W moduleentry;
	moduleentry.dwSize = sizeof(MODULEENTRY32W);
	while (1) {
		if (!Module32NextW(snap, &moduleentry))
			return 0;
		else if (!lstrcmpW(moduleentry.szModule, modulename)) {
			baseaddress = (uintptr_t)moduleentry.modBaseAddr;
			break;
		}
		else continue;
	}
    CloseHandle(snap);
    return baseaddress;
}

uintptr_t GetFinalAddress(HANDLE proc, uintptr_t baseaddress, unsigned int* offsets) {
	uintptr_t address = baseaddress;
	for (unsigned int i = 0; i < sizeof(offsets); i++){
		ReadProcessMemory(proc, (BYTE*)address, &address, sizeof(address), NULL);
		address += offsets[i];
	}
	return address;
}