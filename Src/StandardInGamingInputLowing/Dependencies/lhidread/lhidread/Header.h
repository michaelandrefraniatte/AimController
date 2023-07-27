#include <wchar.h>
#include <windows.h>
#include <setupapi.h>
#include <winioctl.h>
#include <stdio.h>
#include <stdlib.h>
#pragma warning(disable:4996)
struct hid_device_ {
	HANDLE device_handle;
	BOOL blocking;
	USHORT output_report_length;
	size_t input_report_length;
	void* last_error_str;
	DWORD last_error_num;
	BOOL read_pending;
	char* read_buf;
	OVERLAPPED ol;
};
typedef struct hid_device_ hid_device;
typedef struct _HIDD_ATTRIBUTES {
	ULONG Size;
	USHORT VendorID;
	USHORT ProductID;
	USHORT VersionNumber;
} HIDD_ATTRIBUTES, * PHIDD_ATTRIBUTES;
typedef USHORT USAGE;
typedef struct _HIDP_CAPS {
	USAGE Usage;
	USAGE UsagePage;
	USHORT InputReportByteLength;
	USHORT OutputReportByteLength;
	USHORT FeatureReportByteLength;
	USHORT Reserved[17];
	USHORT fields_not_used_by_hidapi[10];
} HIDP_CAPS, * PHIDP_CAPS;
typedef void* PHIDP_PREPARSED_DATA;
typedef LONG NTSTATUS;
typedef NTSTATUS(__stdcall* HidP_GetCaps_)(PHIDP_PREPARSED_DATA preparsed_data, HIDP_CAPS* caps);
static HMODULE lib_handle = NULL;
typedef BOOLEAN(__stdcall* HidD_GetAttributes_)(HANDLE device, PHIDD_ATTRIBUTES attrib);
typedef BOOLEAN(__stdcall* HidD_GetSerialNumberString_)(HANDLE device, PVOID buffer, ULONG buffer_len);
typedef BOOLEAN(__stdcall* HidD_GetManufacturerString_)(HANDLE handle, PVOID buffer, ULONG buffer_len);
typedef BOOLEAN(__stdcall* HidD_GetProductString_)(HANDLE handle, PVOID buffer, ULONG buffer_len);
typedef BOOLEAN(__stdcall* HidD_SetFeature_)(HANDLE handle, PVOID data, ULONG length);
typedef BOOLEAN(__stdcall* HidD_GetFeature_)(HANDLE handle, PVOID data, ULONG length);
typedef BOOLEAN(__stdcall* HidD_GetIndexedString_)(HANDLE handle, ULONG string_index, PVOID buffer, ULONG buffer_len);
typedef BOOLEAN(__stdcall* HidD_GetPreparsedData_)(HANDLE handle, PHIDP_PREPARSED_DATA* preparsed_data);
typedef BOOLEAN(__stdcall* HidD_FreePreparsedData_)(PHIDP_PREPARSED_DATA preparsed_data);
typedef NTSTATUS(__stdcall* HidP_GetCaps_)(PHIDP_PREPARSED_DATA preparsed_data, HIDP_CAPS* caps);
typedef BOOLEAN(__stdcall* HidD_SetNumInputBuffers_)(HANDLE handle, ULONG number_buffers);
static HidD_GetAttributes_ HidD_GetAttributes;
static HidD_GetSerialNumberString_ HidD_GetSerialNumberString;
static HidD_GetManufacturerString_ HidD_GetManufacturerString;
static HidD_GetProductString_ HidD_GetProductString;
static HidD_SetFeature_ HidD_SetFeature;
static HidD_GetFeature_ HidD_GetFeature;
static HidD_GetIndexedString_ HidD_GetIndexedString;
static HidD_GetPreparsedData_ HidD_GetPreparsedData;
static HidD_FreePreparsedData_ HidD_FreePreparsedData;
static HidP_GetCaps_ HidP_GetCaps;
static HidD_SetNumInputBuffers_ HidD_SetNumInputBuffers;
int hid_exit(void)
{
	FreeLibrary(lib_handle);
	return 0;
}
static hid_device* new_hid_device()
{
	hid_device* dev = (hid_device*)calloc(1, sizeof(hid_device));
	dev->device_handle = INVALID_HANDLE_VALUE;
	dev->blocking = FALSE;
	dev->output_report_length = 0;
	dev->input_report_length = 0;
	dev->last_error_str = NULL;
	dev->last_error_num = 0;
	dev->read_pending = FALSE;
	dev->read_buf = NULL;
	dev->ol.hEvent = NULL;
	return dev;
}
static int lookup_functions()
{
	lib_handle = LoadLibraryA("hid.dll");
	if (lib_handle) {
#define RESOLVE(x) x = (x##_)GetProcAddress(lib_handle, #x); if (!x) return -1;
		RESOLVE(HidD_GetAttributes);
		RESOLVE(HidD_GetSerialNumberString);
		RESOLVE(HidD_GetManufacturerString);
		RESOLVE(HidD_GetProductString);
		RESOLVE(HidD_SetFeature);
		RESOLVE(HidD_GetFeature);
		RESOLVE(HidD_GetIndexedString);
		RESOLVE(HidD_GetPreparsedData);
		RESOLVE(HidD_FreePreparsedData);
		RESOLVE(HidP_GetCaps);
		RESOLVE(HidD_SetNumInputBuffers);
#undef RESOLVE
	}
	else
		return -1;
	return 0;
}
static void free_hid_device(hid_device* dev)
{
	CloseHandle(dev->ol.hEvent);
	CloseHandle(dev->device_handle);
	LocalFree(dev->last_error_str);
	free(dev->read_buf);
	free(dev);
}
