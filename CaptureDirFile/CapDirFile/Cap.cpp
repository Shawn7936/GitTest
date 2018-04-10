#include "Cap.h"


Cap::Cap()
{
}

Cap::~Cap()
{
}

void Cap::LoadConfig()
{
   string path= Tools::GetAppPath() + "\\config.ini";
   bool isFileEndLine;

   if(Tools::isExistFile(path.c_str()))
   {
	   string tmp = Tools::ReadFileLineData(path,1,isFileEndLine);
	   vector<string> srcList;
	   srcList = Tools::split(tmp,"=");
	   srcPath = srcList[1];

	   tmp = Tools::ReadFileLineData(path,2,isFileEndLine);
	   vector<string> destList;
	   destList = Tools::split(tmp,"=");
	   destPath = destList[1];
   }
   else
   {
	   printf("No conifg");
   }
}


