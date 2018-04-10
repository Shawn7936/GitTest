#include <iostream>
#include <fstream>
#include "tools.h"
#include <time.h>

#define YEAR_SET 1900
#define MON_SET 1

/**
 *
 *  @author  Ming
 *
 *  @date    2016/06/08
 *
 *  @fn      string Tools::ReadFileLineData( string path ,int lineNumber )
 *
 *  @brief   ( 讀取檔案中的指定行數 )
 *
 *  @param   ( path : 檔案的路徑+名稱 )
 *           ( lineNumber : 指定行數 )
 *           ( isFileEndLine : 是否為最後一行 ( True : 最後一行 ) )
 *
 *  @return  none
 *
 *  @note    ( 當行的資料 )
 *
 */
string Tools::ReadFileLineData( string path ,int lineNumber , bool &isFileEndLine )
{
    ifstream  filePointer;
    char fileLineData[512];
    string fileData = "";
    /* ( 開啟檔案並設定為讀取模式 ) */
    filePointer.open( path , ios::in );
    ifstream ifile(path);

    /* ( 判斷是否開啟成功 ) */
    if( filePointer.good() )
    {
        /* ( 讀取指定的行數 ) */
        for( int getFileLineIndex = 0 ; getFileLineIndex < lineNumber ; getFileLineIndex++ )
        {
            memset( fileLineData , 0 , sizeof( fileLineData ) );
            filePointer.getline( fileLineData , sizeof( fileLineData ) , '\n' );
            isFileEndLine = filePointer.eof();
        }
        /* ( 取得字串 ) */
        fileData = string( fileLineData );
    }

    /* ( 關閉檔案 ) */
    filePointer.close();

    return fileData;
}

/**
 *
 *  @author  Ming
 *
 *  @date    2016/06/08
 *
 *  @fn      void Tools::WriteDataToFileAtLast( string path , string addData )
 *
 *  @brief   ( 將資料寫入檔案之中最後開始加入資料 )
 *
 *  @param   ( path : 檔案的路徑+名稱 )
 *           ( addData : 要加入的資料 )
 *
 *  @return  none
 *
 *  @note    none
 *
 */
void Tools::WriteDataToFileAtLast( string path , string addData )
{
    WriteDataToFile( path , addData , ios::out | ios::app );
}

 /**
 *
 *  @author  Ming
 *
 *  @date    2016/06/08
 *
 *  @fn      void Tools::WriteDataToClearFileData( string path , string addData )
 *
 *  @brief   ( 將檔案資料清除並將資料寫入檔案之中 )
 *
 *  @param   ( path : 檔案的路徑+名稱 )
 *           ( addData : 要加入的資料 )
 *
 *  @return  none
 *
 *  @note    none
 *
 */
void Tools::WriteDataToClearFileData( string path , string addData )
{
    WriteDataToFile( path , addData , ios::out | ios::trunc );
}

 /**
 *
 *  @author  Ming
 *
 *  @date    2016/06/08
 *
 *  @fn      void Tools::WriteDataToFileAtLastNextLine( string path , string addData )
 *
 *  @brief   ( 將資料寫入檔案之中最後資料的下一行 )
 *
 *  @param   ( path : 檔案的路徑+名稱 )
 *           ( addData : 要加入的資料 )
 *
 *  @return  none
 *
 *  @note    none
 *
 */
void Tools::WriteDataToFileAtLastNextLine( string path , string addData )
{
    string data = "\n";
    data += addData;
    WriteDataToFileAtLast( path , data );
}

 /**
 *
 *  @author  Ming
 *
 *  @date    2016/06/08
 *
 *  @fn      void Tools::WriteDataToFile( string path , string addData , int openType )
 *
 *  @brief   ( 將資料寫入檔案之中 )
 *
 *  @param   ( path : 檔案的路徑+名稱 )
 *           ( addData : 要加入的資料 )
 *           ( openType : 開啟檔案的 Type 請參考 std::ios 的說明 )
 *
 *  @return  none
 *
 *  @note    none
 *
 */
void Tools::WriteDataToFile( string path , string addData , int openType )
{
    fstream  filePointer;
    filePointer.open( path , openType );

    if( filePointer )
    {
        filePointer.write( addData.c_str() , addData.length() );
    }
}

 /**
 *
 *  @author  Ming
 *
 *  @date    2016/06/08
 *
 *  @fn      string Tools::GetFileName( string path )
 *
 *  @brief   ( 取得檔案名稱 : "C:\\123.test" -> return : "123.test" )
 *
 *  @param   ( path : 檔案的路徑+名稱 )
 *
 *  @return  ( 檔案名稱 )
 *
 *  @note    none
 *
 */
string Tools::GetFileName( string path )
{
    string fileName = "";
    int fileIndex = 0;

    /* ( 取得 \ or / 的位置 ) */
    for( fileIndex = ( path.length() - 1 ) ; fileIndex > 0 ; fileIndex-- )
    {
        if( ( path[fileIndex] == '\\' ) || ( path[fileIndex] == '/') )
        {
            /* ( 由於多減一次，所以確定會加回來 ) */
            fileIndex++;
            break;
        }
    }

    /* ( 依據取得的位置 取得指定字串 ) */
    int pathLength = path.length();
    for ( int getFineIndex = 0 ; getFineIndex < ( pathLength - fileIndex ) ; getFineIndex++ )
    {
        fileName += path[ fileIndex + getFineIndex ];
    }

    return fileName;
}

 /**
 *
 *  @author  Ming
 *
 *  @date    2016/06/08
 *
 *  @fn      vector<string> Tools::split(string str,string pattern)
 *
 *  @brief   ( 切割字串 str = "A B"  , pattern = " " ->  return[0] = "A" , return[1] = "B" )
 *
 *  @param   ( str : 要切割的字串 )
 *           ( pattern : 切割的字串辨別 )
 *
 *  @return  ( 切割完的字串 )
 *
 *  @note    none
 *
 */
 vector<string> Tools::split(string str,string pattern)
{
    string::size_type pos;
    vector<std::string> result;
    str+=pattern;
    int size=str.size();

    for(int i=0; i<size; i++)
    {
        /* ( 切割指定字串 ) */
        pos=str.find(pattern,i);
        if((int)pos<size)
        {
            std::string s=str.substr(i,pos-i);
            result.push_back(s);
            i=pos+pattern.size()-1;
        }
    }

    return result;
}

 /**
 *
 *  @author  Ming
 *
 *  @date    2016/06/08
 *
 *  @fn       string Tools::GetNowTime()
 *
 *  @brief   ( 取得當前時間的字串 )
 *
 *  @param   none
 *
 *  @return  ( 當前時間的字串 )
 *
 *  @note    none
 *
 */
string Tools::GetNowTime()
{
    /* ( 取得系統時間 ) */
    struct tm newtime;
    char am_pm[] = "AM";
    __time64_t long_time;
    errno_t err;

    // Get time as 64-bit integer.
    _time64( &long_time ); 
    // Convert to local time.
    err = _localtime64_s( &newtime, &long_time ); 
    /* ( 系統時間轉換為字串 ) */
    string dateTime = FourByteToDecString( newtime.tm_year + YEAR_SET );
    dateTime += "/";
    dateTime += FourByteToDecString( newtime.tm_mon + MON_SET );
    dateTime += "/";
    dateTime += FourByteToDecString( newtime.tm_mday );
    dateTime += " ";
    dateTime += FourByteToDecString( newtime.tm_hour );
    dateTime += ":";
    dateTime += FourByteToDecString( newtime.tm_min );
    dateTime += ":";
    dateTime += FourByteToDecString( newtime.tm_sec );

    return dateTime;
}

string Tools::GetNowTimeForFile()
{
    /* ( 取得系統時間 ) */
    struct tm newtime;
    char am_pm[] = "AM";
    __time64_t long_time;
    errno_t err;

    // Get time as 64-bit integer.
    _time64( &long_time ); 
    // Convert to local time.
    err = _localtime64_s( &newtime, &long_time ); 
    /* ( 系統時間轉換為字串 ) */
	int zz=newtime.tm_mon;
    string dateTime = FourByteToDecString( newtime.tm_year + YEAR_SET );
	//補0
	if((newtime.tm_mon + MON_SET) < 10)
	{
		dateTime += "0";
		dateTime +=FourByteToDecString( newtime.tm_mon + MON_SET );
	}
	else
	{
		 dateTime += FourByteToDecString( newtime.tm_mon + MON_SET );
	}

    if(newtime.tm_mday < 10)
    {
		dateTime += "0";
		dateTime += FourByteToDecString( newtime.tm_mday );
    }
	else
	{
		dateTime += FourByteToDecString( newtime.tm_mday );
	}

	dateTime += "_";
	
	if(newtime.tm_hour < 10)
	{
		if(0 == newtime.tm_hour )
		{
			dateTime += "00";
		}
		else
		{
			dateTime += "0";
			dateTime += FourByteToDecString( newtime.tm_hour );
		}
	}
	else
	{
		dateTime += FourByteToDecString( newtime.tm_hour );
	}
    

	if(newtime.tm_min < 10)
	{
		if (0 ==newtime.tm_min)
		{
			dateTime += "00";
		}
		else
		{
			dateTime += "0";
			dateTime += FourByteToDecString( newtime.tm_min );
		}
	}
	else
	{
		dateTime += FourByteToDecString( newtime.tm_min );
	}

	if(newtime.tm_sec < 10)
	{
		if(0 == newtime.tm_sec )
		{
			dateTime += "00";
		}
		else
		{
			dateTime += "0";
			dateTime += FourByteToDecString( newtime.tm_sec );
		}
	}
	else
	{
		dateTime += FourByteToDecString( newtime.tm_sec );
	}

    return dateTime;
}

 /**
 *
 *  @author  Ming
 *
 *  @date    2016/05/09
 *
 *  @fn      unsigned int Tools::GetTenToThePowerN( unsigned char powerN )
 *
 *  @brief   ( 取得 10 的 N 次方( 1 ~ 1000000000 ) )
 *
 *  @param   ( powerN : 10 的 N 次方 )
 *
 *  @return  ( 10 的 N 次方值 )
 *
 *  @note    none
 *
 */
unsigned int Tools::GetTenToThePowerN( unsigned char powerN )
{
    unsigned char index = 0;
    unsigned int tenPowerN = 1;
    /* ( 保護範圍 ) */
    if( powerN > 10 )
    {
        powerN = 10;
    }

    for( index = 0 ; ( index < powerN ) && ( index <= 10 ) ; index++ )
    {
        tenPowerN = tenPowerN * 10;
    }

    return tenPowerN;
}


/**
 *
 *  @author  Ming
 *
 *  @date    2016/05/09
 *
 *  @fn      string Tools::FourByteToDecString( const unsigned int data )
 *
 *  @brief   ( 4 Byte數值轉換 10 進制的字串 )
 *
 *  @param   ( data : 4 Byte數值 )
 *           ( decStr : 10 進制的字串儲存位置 )
 *           ( decLength : 10 進制要取得的位數 -> 2 : 取得 XX / 3 : 取得 XXX )
 *
 *  @return  ( 10進制複製的字串長度 )
 *
 *  @note    none
 *
 */
string Tools::FourByteToDecString( const unsigned int data )
{
    unsigned int getIndex = 0;
    string getData = "";
    int numberData = 0;

    for( getIndex = 10 ; 0 < getIndex ; getIndex-- )
    {
        /* ( 取得十進制的數值 ) */
        numberData = ( ( data / ( GetTenToThePowerN( getIndex - 1 )  ) ) % 10 ) ;

        /* ( 前面數值為 0 時不儲存 0 的字串 INT 0x0000000A -> "10" ) */
        if( ( numberData > 0 ) || ( getData.length() > 0 ))
        {
            getData += (char)( numberData + '0' );
        }
        
    }

    return getData;
}

/**
 *
 *  @author  Ming
 *
 *  @date    2016/05/09
 *
 *  @fn      unsigned int Tools::StringToFourByte( string numberStr )
 *
 *  @brief   (字元轉換 4 Bytes 整數)
 *
 *  @param   ( str : 要轉的字元 )
 *
 *  @return  ( 轉換後的整數 )
 *
 *  @note    none  
 *
 */
unsigned int Tools::StringToFourByte( string numberStr )
{
    unsigned int byteData = 0;
    int getStrIndex = 0;
    int tenPowerOfN = 0; /* ( 10 次方 ) */
    int strLength = numberStr.length();

    /* ( 4 個 Byte 最多只有 10 個數值 ) */
    if( strLength > 10 )
    {
        strLength = 10;
    }

    /* ( 字串的轉換 ) */
    for( getStrIndex = strLength ; ( 0 < getStrIndex ) && ( numberStr[ getStrIndex - 1 ] != 0x00 ) ; getStrIndex-- , tenPowerOfN++ )
    {
        byteData += ( (unsigned int)CharToInt( numberStr[ getStrIndex - 1 ] ) ) * ( GetTenToThePowerN( tenPowerOfN ) );
    }

    return byteData ;
}


/**
 *
 *  @author  Ming
 *
 *  @date    2016/05/09
 *
 *  @fn      char Tools::CharToInt(const char str )
 *
 *  @brief   (字元轉換整數)
 *
 *  @param   ( str : 要轉的字元 )
 *
 *  @return  ( 轉換後的整數 )
 *
 *  @note    none  
 *
 */
char Tools::CharToInt(const char str )
{
    if( ( str >= '0' ) && ( str <= '9' ) )
    {
        return ( str - '0' );
    }
    else if( ( str >= 'a' ) && ( str <= 'f' ) )
    {
        return ( ( str - 'a' ) + 10 );
    }
    else if( ( str >= 'A' ) && ( str <= 'F' ) )
    {
        return ( ( str - 'A' ) + 10 );
    }

    return 0x00;
}
//取得目前執行檔的路徑
CString Tools::GetAppPath() 
{
   wchar_t cpath[1024] = {0};
   HMODULE hModule = ::GetModuleHandle(NULL);
   int Length = ::GetModuleFileNameW(hModule,cpath,1024);
   CString strAppPath(cpath);
   int index = strAppPath.ReverseFind('\\');
   strAppPath = strAppPath.Left(index);
   return strAppPath;

}

// 檢查目錄,如果不存在則創建目錄
bool Tools::FindOrCreateDirectory( const char* pszPath )
{
    WIN32_FIND_DATA fd;
    HANDLE hFind = ::FindFirstFile( pszPath, &fd );
    while( hFind != INVALID_HANDLE_VALUE )
    {
        if ( fd.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY )
            return true;
    }

    if ( !::CreateDirectory( pszPath, NULL ) )
    {
        char szDir[MAX_PATH];
        sprintf_s( szDir, sizeof(szDir), "創建目錄[%s]失敗,請檢查權限", pszPath );
        //::MessageBox( NULL, szDir, "創建目錄失敗", MB_OK|MB_ICONERROR );
        return false;
    }

    return true;
}

bool Tools::isExistFile(const char *pszFileName)
{
        fstream file;
        file.open(pszFileName,ios::in);
        if(!file)
        {
            return false;
        }

        return true;
}
