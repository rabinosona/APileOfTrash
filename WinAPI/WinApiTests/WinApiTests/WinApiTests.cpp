// WinApiTests.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <windows.h>
#include <tlhelp32.h>
#include <tchar.h>

int main()
{
	_tprintf(TEXT("Man, fuck this shit.\n"));
	GetProcessesList( );
	return 0;
}

BOOL GetProcessesList() {
	HANDLE hProcessSnap;
	HANDLE hProcess;
	PROCESSENTRY32 pe32;
	DWORD dwPriorityClass;

	// Take a snapshot of all processes in the system.
	hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	hProcessSnap = INVALID_HANDLE_VALUE;
	if (hProcessSnap == INVALID_HANDLE_VALUE)
	{
		printError(TEXT("CreateToolhelp32Snapshot (of processes)"));
		return FALSE;
	}

	return true;
}

void printError(const wchar_t* msg) {
	DWORD err_num;
	TCHAR error[256];
	TCHAR* error_ptr;

	err_num = GetLastError();
	FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, NULL, err_num
		, MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL), error, 256, NULL);

	_tprintf(TEXT("\n  WARNING: %s failed with error %d (%s)"), msg, err_num, error);
}