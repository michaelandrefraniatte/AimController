#include "pch.h"
#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <windows.h>
#include <mmsystem.h>
#include <winioctl.h>
#pragma comment(lib, "winmm.lib")
#pragma comment(lib, "ntdll.lib")
INPUT down[1], up[1], downa[1], upa[1], MiceW3[1], Micek[1], Micel[1], Micelf[1], Micerc[1], Micercf[1], Micemc[1], Micemcf[1], Micewd[1], Micewu[1];
bool downb, upb, downab, upab, MiceW3b, Micekb, Micelb, Micelfb, Micercb, Micercfb, Micemcb, Micemcfb, Micewdb, Micewub;
int size = sizeof(INPUT);
extern "C"
{
	__declspec(dllexport) void MoveMouseTo(int x, int y)
	{
		mouse_event(0x8001, x, y, 0, 0);
	}
	__declspec(dllexport) void MoveMouseBy(int x, int y)
	{
		mouse_event(0x0001, x, y, 0, 0);
	}
	__declspec(dllexport) void MouseMW3(int x, int y)
	{
		if (!MiceW3b)
		{
			MiceW3[0].type = 0;
			MiceW3[0].mi.dwFlags = 0x8001;
			MiceW3b = true;
		}
		MiceW3[0].mi.dx = x;
		MiceW3[0].mi.dy = y;
		SendInput(1, MiceW3, size);
	}
	__declspec(dllexport) void MouseBrink(int x, int y)
	{
		if (!Micekb)
		{
			Micek[0].type = 0;
			Micek[0].mi.dwFlags = 0x0001;
			Micekb = true;
		}
		Micek[0].mi.dx = x;
		Micek[0].mi.dy = y;
		SendInput(1, Micek, size);
	}
}