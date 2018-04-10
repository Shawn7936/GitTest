#define DLLIMPORT _declspec(dllexport)

extern "C"
{
	DLLIMPORT int getOne(int *buf);
	DLLIMPORT int getTwo(unsigned int *buf);
	DLLIMPORT int add(int a,int b);
	DLLIMPORT int TWinUpgradeLibInit(char* Img,unsigned long ImageLen);
	DLLIMPORT int Tupload_file(char *buf, unsigned int* len_of_transfer, char *abs_filename_in_target);
}



