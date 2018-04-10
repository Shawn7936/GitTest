#include <iostream>
#include <fstream>       
#include <time.h>
#include <string> 
#include <thread>
#include <windows.h>
#include <stdio.h>
#include <tchar.h>

//#include "..\..\dll_BaseTest\dll_BaseTest\BaseDLL.h"
//#include"..\..\dll_BaseTest\Debug\UpgradeLib.h"
//#pragma comment(lib , "..\..\dll_BaseTest\Debug\dll_BaseTest.lib")

using namespace std;

typedef int (*__WinUpgradeLibInit)(char *Image_buffer_pointer, unsigned long ImageLen);
__WinUpgradeLibInit WinUpgradeLibInit;

typedef int (*__burnImage)();
__burnImage burnImage;

typedef int (*__progress_reply_status_get) (char *index, unsigned char *percent, unsigned short *status );
__progress_reply_status_get progress_reply_status_get;

typedef int (*__burnpartition)(int parts_selected);
__burnpartition burnpartition;


HMODULE myDll = LoadLibrary("D:\\Documents\\Visual Studio 2012\\Projects\\dll_BaseTest\\Debug\\libupgrade.dll"); 


unsigned int size = 0;
char retval;
char* A           = "/userdata/LogSave22.sh";
char  B[]         = "1A2B3C4D5E6F7G";
char  C[1024];
char* D ;

void test_func()
{
	progress_reply_status_get = (__progress_reply_status_get)GetProcAddress(myDll,"progress_reply_status_get");

	char index = 0;
	unsigned char percent = 0;
	unsigned short sta = 0;

	while (1)
	{
		retval = progress_reply_status_get(&index,&percent,&sta);

		printf("################\nstatus = 0x%08X; percent = %d; retval = 0x%08X; partition_index = 0x%08X; \n",   sta, percent, retval, index);

		Sleep(500);
	}
	

}
int main()
{
	thread mThread( test_func );

	WSADATA wsaData;
    retval      = WSAStartup(MAKEWORD(1, 1), &wsaData);

	WinUpgradeLibInit = (__WinUpgradeLibInit)GetProcAddress(myDll,"WinUpgradeLibInit");
	
	burnImage = (__burnImage)GetProcAddress(myDll,"burnImage");


	FILE *NandImg  = fopen("D:\\Desktop\\UniUpgradeTools_v01p08\\Gx_Image_MFG_V1.00-T08.bin", "rb");
	if (NULL  == NandImg)
	{
		printf("file open error\n");
		return -1;
	}
	fseek(NandImg, 0L, SEEK_END);
	unsigned long  ImageLen = ftell(NandImg);
	fseek(NandImg, 0L, SEEK_SET);
	char          *Img      = (char *) malloc( ImageLen );
	unsigned       num      = fread(Img, 1, ImageLen, NandImg);
	fclose(NandImg);
	int r=WinUpgradeLibInit( Img,ImageLen );


	char buf[10240];
	unsigned int aaaa = 0;
	unsigned int len = 0;
	//len = upload_file(buf,&aaaa,A);
	int rr=burnImage();
	
	printf("Success");
	




	int a= 1,b= 2;
	//int c = add(a,b);
	//cout <<c;
	mThread.join();
    int d;
	cin>>d;	
}

