#include "dep.h"

int main() {
	int sellvalue = 0;
	unsigned int offsets[] = { 0x00 };
	DWORD pid = GetPIDByName(L"");
	HANDLE proc = OpenProcess(PROCESS_ALL_ACCESS, NULL, pid);
	uintptr_t baseaddress = GetModuleBaseAddress(L"", pid);
	uintptr_t writeaddress = GetFinalAddress(proc, baseaddress + 0x00, offsets);
	WriteProcessMemory(proc, (BYTE*)writeaddress, &sellvalue, sizeof(sellvalue), NULL);

}