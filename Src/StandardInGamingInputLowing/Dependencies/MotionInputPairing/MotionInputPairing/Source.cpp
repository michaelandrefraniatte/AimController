#include "pch.h"
#include <windows.h>
#include <bthsdpdef.h>
#include <bthdef.h>
#include <BluetoothAPIs.h>
#include <strsafe.h>
#include <iostream>
#pragma comment(lib, "Bthprops.lib")
BLUETOOTH_DEVICE_INFO btdil;
BLUETOOTH_DEVICE_INFO btdir;
BLUETOOTH_DEVICE_INFO btdiw;
BLUETOOTH_DEVICE_INFO btdiw1;
BLUETOOTH_DEVICE_INFO btdiw2;
BLUETOOTH_DEVICE_INFO btdip;
bool joyconlfound = false;
bool joyconrfound = false;
bool wiimotefound = false;
bool wiimote1found = false;
bool wiimote2found = false;
bool procontrollerfound = false;
#pragma warning(disable : 4995)
extern "C"
{
	__declspec(dllexport) bool joyconleftconnect()
	{
		joyconlfound = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdil.dwSize = sizeof(btdil);
		btdi.dwSize = sizeof(btdi);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if (!wcscmp(btdi.szName, L"Joy-Con (L)"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdil = btdi;
					joyconlfound = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (joyconlfound)
			return true;
		return false;
	}
	__declspec(dllexport) bool joyconrightconnect()
	{
		joyconrfound = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdir.dwSize = sizeof(btdir);
		btdi.dwSize = sizeof(btdi);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if (!wcscmp(btdi.szName, L"Joy-Con (R)"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdir = btdi;
					joyconrfound = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (joyconrfound)
			return true;
		return false;
	}
	__declspec(dllexport) bool wiimoteconnect()
	{
		wiimotefound = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdiw.dwSize = sizeof(btdiw);
		btdi.dwSize = sizeof(btdi);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if (!wcscmp(btdi.szName, L"Nintendo RVL-WBC-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01-TR"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdiw = btdi;
					wiimotefound = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (wiimotefound)
			return true;
		return false;
	}
	__declspec(dllexport) bool wiimotesconnect()
	{
		wiimote1found = false;
		wiimote2found = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdiw1.dwSize = sizeof(btdiw1);
		btdiw2.dwSize = sizeof(btdiw2);
		btdi.dwSize = sizeof(btdi);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if ((!wcscmp(btdi.szName, L"Nintendo RVL-WBC-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01-TR")) & wiimote1found)
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdiw2 = btdi;
					wiimote2found = true;
				}
				if ((!wcscmp(btdi.szName, L"Nintendo RVL-WBC-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01-TR")) & !wiimote1found)
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdiw1 = btdi;
					wiimote1found = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (wiimote1found & wiimote2found)
			return true;
		return false;
	}
	__declspec(dllexport) bool joyconsconnect()
	{
		joyconlfound = false;
		joyconrfound = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdil.dwSize = sizeof(btdil);
		btdir.dwSize = sizeof(btdir);
		btdi.dwSize = sizeof(btdi);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if (!wcscmp(btdi.szName, L"Joy-Con (L)"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdil = btdi;
					joyconlfound = true;
				}
				if (!wcscmp(btdi.szName, L"Joy-Con (R)"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdir = btdi;
					joyconrfound = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (joyconrfound & joyconlfound)
			return true;
		return false;
	}
	__declspec(dllexport) bool wiimotejoyconleftconnect()
	{
		joyconlfound = false;
		wiimotefound = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdil.dwSize = sizeof(btdil);
		btdiw.dwSize = sizeof(btdiw);
		btdi.dwSize = sizeof(btdi);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if (!wcscmp(btdi.szName, L"Nintendo RVL-WBC-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01-TR"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdiw = btdi;
					wiimotefound = true;
				}
				if (!wcscmp(btdi.szName, L"Joy-Con (L)"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdil = btdi;
					joyconlfound = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (wiimotefound & joyconlfound)
			return true;
		return false;
	}
	__declspec(dllexport) bool wiimotejoyconrightconnect()
	{
		joyconrfound = false;
		wiimotefound = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdi.dwSize = sizeof(btdi);
		btdir.dwSize = sizeof(btdir);
		btdiw.dwSize = sizeof(btdiw);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if (!wcscmp(btdi.szName, L"Nintendo RVL-WBC-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01-TR"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdiw = btdi;
					wiimotefound = true;
				}
				if (!wcscmp(btdi.szName, L"Joy-Con (R)"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdir = btdi;
					joyconrfound = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (joyconrfound & wiimotefound)
			return true;
		return false;
	}
	__declspec(dllexport) bool wiimotejoyconsconnect()
	{
		joyconlfound = false;
		joyconrfound = false;
		wiimotefound = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdi.dwSize = sizeof(btdi);
		btdil.dwSize = sizeof(btdil);
		btdir.dwSize = sizeof(btdir);
		btdiw.dwSize = sizeof(btdiw);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if (!wcscmp(btdi.szName, L"Nintendo RVL-WBC-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01") | !wcscmp(btdi.szName, L"Nintendo RVL-CNT-01-TR"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdiw = btdi;
					wiimotefound = true;
				}
				if (!wcscmp(btdi.szName, L"Joy-Con (R)"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdir = btdi;
					joyconrfound = true;
				}
				if (!wcscmp(btdi.szName, L"Joy-Con (L)"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdil = btdi;
					joyconlfound = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (joyconlfound & joyconrfound & wiimotefound)
			return true;
		return false;
	}
	__declspec(dllexport) bool procontrollerconnect()
	{
		procontrollerfound = false;
		HBLUETOOTH_DEVICE_FIND hFind = NULL;
		HANDLE hRadios[256];
		HBLUETOOTH_RADIO_FIND hFindRadio;
		BLUETOOTH_FIND_RADIO_PARAMS radioParam;
		BLUETOOTH_RADIO_INFO radioInfo;
		BLUETOOTH_DEVICE_SEARCH_PARAMS srch;
		BLUETOOTH_DEVICE_INFO btdi;
		int nRadios = 0;
		radioParam.dwSize = sizeof(BLUETOOTH_FIND_RADIO_PARAMS);
		radioInfo.dwSize = sizeof(BLUETOOTH_RADIO_INFO);
		btdip.dwSize = sizeof(btdip);
		btdi.dwSize = sizeof(btdi);
		srch.dwSize = sizeof(BLUETOOTH_DEVICE_SEARCH_PARAMS);
		hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
		while (BluetoothFindNextRadio(hFindRadio, &hRadios[nRadios++]))
		{
			hFindRadio = BluetoothFindFirstRadio(&radioParam, &hRadios[nRadios++]);
			BluetoothFindRadioClose(hFindRadio);
		}
		srch.fReturnAuthenticated = TRUE;
		srch.fReturnRemembered = TRUE;
		srch.fReturnConnected = TRUE;
		srch.fReturnUnknown = TRUE;
		srch.fIssueInquiry = TRUE;
		srch.cTimeoutMultiplier = 2;
		srch.hRadio = hRadios[1];
		BluetoothGetRadioInfo(hRadios[1], &radioInfo);
		WCHAR pass[6];
		DWORD pcServices = 16;
		GUID guids[16];
		pass[0] = radioInfo.address.rgBytes[0];
		pass[1] = radioInfo.address.rgBytes[1];
		pass[2] = radioInfo.address.rgBytes[2];
		pass[3] = radioInfo.address.rgBytes[3];
		pass[4] = radioInfo.address.rgBytes[4];
		pass[5] = radioInfo.address.rgBytes[5];
		hFind = BluetoothFindFirstDevice(&srch, &btdi);
		if (hFind != NULL)
		{
			do
			{
				if (!wcscmp(btdi.szName, L"Pro Controller"))
				{
					BluetoothAuthenticateDevice(NULL, hRadios[1], &btdi, pass, 6);
					BluetoothEnumerateInstalledServices(hRadios[1], &btdi, &pcServices, guids);
					BluetoothSetServiceState(hRadios[1], &btdi, &HumanInterfaceDeviceServiceClass_UUID, BLUETOOTH_SERVICE_ENABLE);
					BluetoothUpdateDeviceRecord(&btdi);
					btdip = btdi;
					procontrollerfound = true;
				}
			} while (BluetoothFindNextDevice(hFind, &btdi));
			BluetoothFindDeviceClose(hFind);
		}
		BluetoothFindRadioClose(hFindRadio);
		if (procontrollerfound)
			return true;
		return false;
	}
	__declspec(dllexport) bool joyconleftdisconnect()
	{
		if (joyconlfound)
			BluetoothRemoveDevice(&btdil.Address);
		return true;
	}
	__declspec(dllexport) bool joyconrightdisconnect()
	{
		if (joyconrfound)
			BluetoothRemoveDevice(&btdir.Address);
		return true;
	}
	__declspec(dllexport) bool wiimotedisconnect()
	{
		if (wiimotefound)
			BluetoothRemoveDevice(&btdiw.Address);
		return true;
	}
	__declspec(dllexport) bool wiimotesdisconnect()
	{
		if (wiimote1found)
			BluetoothRemoveDevice(&btdiw1.Address);
		if (wiimote2found)
			BluetoothRemoveDevice(&btdiw2.Address);
		return true;
	}
	__declspec(dllexport) bool procontrollerdisconnect()
	{
		if (procontrollerfound)
			BluetoothRemoveDevice(&btdip.Address);
		return true;
	}
}