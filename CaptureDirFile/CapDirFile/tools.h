#pragma once
#include <vector>
#include <afx.h> //CString
using namespace std;

class Tools
{
public:
    // 讀取檔案中的指定行數
    static string ReadFileLineData( string path ,int lineNumber , bool &isFileEndLine );
    // 將資料寫入檔案之中最後開始加入資料
    static void WriteDataToFileAtLast( string path , string addData );
    // 將資料寫入檔案之中最後資料的下一行
    static void WriteDataToFileAtLastNextLine( string path , string addData );
    // 將檔案資料清除並將資料寫入檔案之中
    static void WriteDataToClearFileData( string path , string addData );
    // 切割字串 str = "A B"  , pattern = " " ->  return[0] = "A" , return[1] = "B"
    static vector<string> split(string str,string pattern);
    // 4 Byte數值轉換 10 進制的字串
    static string FourByteToDecString( const unsigned int data );
    // 字元轉換 4 Bytes 整數
    static unsigned int StringToFourByte( string numberStr );
    // 取得當前時間的字串
    static string GetNowTime();
    // 取得檔案名稱 : "C:\\123.test" -> return : "123.test"
    static string GetFileName( string path );
	//取得檔案路徑
	static CString Tools::GetAppPath();
	//給檔案名稱用的時間
	static string GetNowTimeForFile();
	//檢查目錄,如果不存在則創建目錄
	static bool FindOrCreateDirectory( const char* pszPath );
	static bool isExistFile(const char *pszFileName);
    static CString GetFilePath( CString filePath );
private:
    // 將資料寫入檔案之中
    static void WriteDataToFile( string path , string addData , int openType );
    // 取得 10 的 N 次方( 1 ~ 1000000000 )
    static unsigned int GetTenToThePowerN( unsigned char powerN );
    // 字元轉換整數
    static char CharToInt(const char str );
};