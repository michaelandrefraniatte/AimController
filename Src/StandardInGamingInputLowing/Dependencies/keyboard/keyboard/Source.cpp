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
	__declspec(dllexport) void SendKey(UINT bVk, UINT bScan)
	{
		keybd_event(bVk, bScan, 0, 0);
	}
	__declspec(dllexport) void SendKeyF(UINT bVk, UINT bScan)
	{
		keybd_event(bVk, bScan, 0x0002, 0);
	}
	__declspec(dllexport) void SendKeyArrows(UINT bVk, UINT bScan)
	{
		keybd_event(bVk, bScan, 0x0001 | 0x0008, 0);
		keybd_event(bVk, bScan, 0, 0);
	}
	__declspec(dllexport) void SendKeyArrowsF(UINT bVk, UINT bScan)
	{
		keybd_event(bVk, bScan, 0x0002 | 0x0001 | 0x0008, 0);
		keybd_event(bVk, bScan, 0x0002, 0);
	}
	__declspec(dllexport) void SendMouseEventButtonLeft()
	{
		mouse_event(0x0002, 0, 0, 0, 0);
	}
	__declspec(dllexport) void SendMouseEventButtonLeftF()
	{
		mouse_event(0x0004, 0, 0, 0, 0);
	}
	__declspec(dllexport) void SendMouseEventButtonRight()
	{
		mouse_event(0x0008, 0, 0, 0, 0);
	}
	__declspec(dllexport) void SendMouseEventButtonRightF()
	{
		mouse_event(0x0010, 0, 0, 0, 0);
	}
	__declspec(dllexport) void SendMouseEventButtonMiddle()
	{
		mouse_event(0x0020, 0, 0, 0, 0);
	}
	__declspec(dllexport) void SendMouseEventButtonMiddleF()
	{
		mouse_event(0x0040, 0, 0, 0, 0);
	}
	__declspec(dllexport) void SendMouseEventButtonWheelUp()
	{
		mouse_event(0x0800, 0, 0, 120, 0);
	}
	__declspec(dllexport) void SendMouseEventButtonWheelDown()
	{
		mouse_event(0x0800, 0, 0, -120, 0);
	}
	__declspec(dllexport) void SimulateKeyDown(UINT keyCode, UINT bScan)
	{
		if (!downb)
		{
			down[0].type = 1;
			down[0].ki.dwFlags = 0;
			downb = true;
		}
		down[0].ki.wVk = keyCode;
		down[0].ki.wScan = bScan;
		SendInput(1, down, size);
	}
	__declspec(dllexport) void SimulateKeyUp(UINT keyCode, UINT bScan)
	{
		if (!upb)
		{
			up[0].type = 1;
			up[0].ki.dwFlags = 0x0002;
			upb = true;
		}
		up[0].ki.wVk = keyCode;
		up[0].ki.wScan = bScan;
		SendInput(1, up, size);
	}
	__declspec(dllexport) void SimulateKeyDownArrows(UINT keyCode, UINT bScan)
	{
		if (!downab)
		{
			downa[0].type = 1;
			downab = true;
		}
		downa[0].ki.wVk = keyCode;
		downa[0].ki.wScan = bScan;
		downa[0].ki.dwFlags = 0x0001 | 0x0008;
		SendInput(1, downa, size);
		downa[0].ki.dwFlags = 0;
		SendInput(1, downa, size);
	}
	__declspec(dllexport) void SimulateKeyUpArrows(UINT keyCode, UINT bScan)
	{
		if (!upab)
		{
			upa[0].type = 1;
			upab = true;
		}
		upa[0].ki.wVk = keyCode;
		upa[0].ki.wScan = bScan;
		upa[0].ki.dwFlags = 0x0002 | 0x0001 | 0x0008;
		SendInput(1, upa, size);
		upa[0].ki.dwFlags = 0x0002;
		SendInput(1, upa, size);
	}
	__declspec(dllexport) void LeftClick()
	{
		if (!Micelb)
		{
			Micel[0].type = 0;
			Micel[0].mi.dwFlags = 0x0002;
			Micelb = true;
		}
		SendInput(1, Micel, size);
	}
	__declspec(dllexport) void LeftClickF()
	{
		if (!Micelfb)
		{
			Micelf[0].type = 0;
			Micelf[0].mi.dwFlags = 0x0004;
			Micelfb = true;
		}
		SendInput(1, Micelf, size);
	}
	__declspec(dllexport) void RightClick()
	{
		if (!Micercb)
		{
			Micerc[0].type = 0;
			Micerc[0].mi.dwFlags = 0x0008;
			Micercb = true;
		}
		SendInput(1, Micerc, size);
	}
	__declspec(dllexport) void RightClickF()
	{
		if (!Micercfb)
		{
			Micercf[0].type = 0;
			Micercf[0].mi.dwFlags = 0x0010;
			Micercfb = true;
		}
		SendInput(1, Micercf, size);
	}
	__declspec(dllexport) void MiddleClick()
	{
		if (!Micemcb)
		{
			Micemc[0].type = 0;
			Micemc[0].mi.dwFlags = 0x0020;
			Micemcb = true;
		}
		SendInput(1, Micemc, size);
	}
	__declspec(dllexport) void MiddleClickF()
	{
		if (!Micemcfb)
		{
			Micemcf[0].type = 0;
			Micemcf[0].mi.dwFlags = 0x0040;
			Micemcfb = true;
		}
		SendInput(1, Micemcf, size);
	}
	__declspec(dllexport) void WheelDownF()
	{
		if (!Micewdb)
		{
			Micewd[0].type = 0;
			Micewd[0].mi.mouseData = -120;
			Micewd[0].mi.dwFlags = 0x0800;
			Micewdb = true;
		}
		SendInput(1, Micewd, size);
	}
	__declspec(dllexport) void WheelUpF()
	{
		if (!Micewub)
		{
			Micewu[0].type = 0;
			Micewu[0].mi.mouseData = 120;
			Micewu[0].mi.dwFlags = 0x0800;
			Micewub = true;
		}
		SendInput(1, Micewu, size);
	}
}