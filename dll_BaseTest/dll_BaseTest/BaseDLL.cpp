#include "BaseDLL.h"
#include <windows.h>

typedef int (*__WinUpgradeLibInit)(char *Image_buffer_pointer, unsigned long ImageLen);
typedef int (*__upload_file)(char *buf, unsigned int* len_of_transfer, char *abs_filename_in_target);
__WinUpgradeLibInit WinUpgradeLibInit;
__upload_file upload_file;
HMODULE myDll = LoadLibrary("D:\\Documents\\Visual Studio 2012\\Projects\\dll_BaseTest\\Debug\\libupgrade.dll"); 


int TWinUpgradeLibInit(char* Img,unsigned long ImageLen)
{
	WinUpgradeLibInit = (__WinUpgradeLibInit)GetProcAddress(myDll,"WinUpgradeLibInit");
	WinUpgradeLibInit(Img,ImageLen);
	return 0;
}

int Tupload_file(char *buf, unsigned int* len_of_transfer, char *abs_filename_in_target)
{
	upload_file = (__upload_file)GetProcAddress(myDll,"upload_file");
	unsigned int len = 0;
	upload_file(buf,&len,abs_filename_in_target);

	return len;
}


int getOne(int *buf)
{
	*buf = 1;

	return 0;
}

int getTwo(unsigned int *buf)
{
	*buf = 2;

	return 0;
}

int add(int a,int b)
{
	return (a+b);
}