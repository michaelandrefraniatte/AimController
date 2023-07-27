#include "pch.h"
#include <windows.h>
#include <setupapi.h>
#include <winioctl.h>
#include <stdio.h>
#include <stdlib.h>
#include <cstdlib>
#include "Header.h"
DWORD Probytes_read = 0;
#pragma warning(disable:4996)
#pragma comment(lib, "setupapi.lib")
extern "C"
{
	__declspec(dllexport) void Prohid_read_timeout(hid_device* dev, unsigned char* data, size_t length)
	{
		ReadFile(dev->device_handle, dev->read_buf, dev->input_report_length, &Probytes_read, NULL);
		memcpy(data, dev->read_buf, length);
	}
	__declspec(dllexport) void Prohid_write(hid_device* dev, const unsigned char* data, size_t length)
	{
		unsigned char* buf = (unsigned char*)malloc(dev->output_report_length);
		memcpy(buf, data, length);
		WriteFile(dev->device_handle, buf, dev->output_report_length, NULL, NULL);
	}
	__declspec(dllexport) hid_device* Prohid_open_path(HANDLE handle)
	{
		hid_device* dev;
		HIDP_CAPS caps;
		PHIDP_PREPARSED_DATA pp_data = NULL;
		lookup_functions();
		dev = new_hid_device();
		dev->device_handle = handle;
		HidD_GetPreparsedData(dev->device_handle, &pp_data);
		HidP_GetCaps(pp_data, &caps);
		dev->output_report_length = caps.OutputReportByteLength;
		dev->input_report_length = caps.InputReportByteLength;
		dev->read_buf = (char*)malloc(dev->input_report_length);
		hid_exit();
		return dev;
	}
	__declspec(dllexport) void Prohid_close(hid_device* dev)
	{
		CancelIoEx(dev->device_handle, NULL);
		free_hid_device(dev);
	}
}