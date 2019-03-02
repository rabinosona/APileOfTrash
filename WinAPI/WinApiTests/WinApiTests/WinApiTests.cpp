// WinApiTests.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <windows.h>
#include <tlhelp32.h>
#include <tchar.h>
#include "psapi.h"

BOOL GetProcessesList();
void printError(const wchar_t* msg);
DWORD CharCount(const wchar_t* str);

int main()
{
	_tprintf(TEXT("Man, fuck this shit.\n"));
	GetProcessesList( );
	return 0;
}

BOOL GetProcessesList()
{
	HANDLE hProcessSnap;
	HANDLE hProcess;
	PROCESSENTRY32 pe32;
	DWORD dwPriorityClass;
	TCHAR fileName[530];

	// Take a snapshot of all processes in the system.
	hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (hProcessSnap == INVALID_HANDLE_VALUE)
	{
		printError(TEXT("CreateToolhelp32Snapshot (of processes)"));
		return FALSE;
	}

	pe32.dwSize = sizeof(PROCESSENTRY32);

	if (!Process32First(hProcessSnap, &pe32))
	{
		printError(TEXT("Could not find the first process"));
		CloseHandle(hProcessSnap);
		return FALSE;
	}

	do 
	{
		hProcess = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pe32.th32ProcessID);

		GetModuleFileNameEx(hProcess, NULL, fileName, MAX_PATH);

		// checking for an empty process path
		if (!(fileName[0] == 52428))
		{
			_tprintf(TEXT("The process name is: %s and its id is %d. Its parent id is: %d \n"), pe32.szExeFile, pe32.th32ProcessID, pe32.th32ParentProcessID);
		}
	} while (Process32Next(hProcessSnap, &pe32));

	CloseHandle(hProcessSnap);

	return TRUE;
}

void printError(const wchar_t* msg) 
{
	DWORD err_num;
	TCHAR error[256];
	TCHAR* error_ptr;

	err_num = GetLastError();
	FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, NULL, err_num
		, MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL), error, 256, NULL);

	error_ptr = error;
	while (*error_ptr > 31 || *error_ptr == 9)
		error_ptr++;
	do { *error_ptr-- = 0; } while (error_ptr > error &&
		(*error_ptr == '.') || (*error_ptr < 33));

	_tprintf(TEXT("\n  WARNING: %s failed with error %d (%s)"), msg, err_num, error);
}

DWORD CharCount(const wchar_t* str)
{
	int result = 0;
	while (*str != '\0')
	{
		result++;
		++str;
	}

	return result;
}