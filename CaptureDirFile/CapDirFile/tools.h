#pragma once
#include <vector>
#include <afx.h> //CString
using namespace std;

class Tools
{
public:
    // Ū���ɮפ������w���
    static string ReadFileLineData( string path ,int lineNumber , bool &isFileEndLine );
    // �N��Ƽg�J�ɮפ����̫�}�l�[�J���
    static void WriteDataToFileAtLast( string path , string addData );
    // �N��Ƽg�J�ɮפ����̫��ƪ��U�@��
    static void WriteDataToFileAtLastNextLine( string path , string addData );
    // �N�ɮ׸�ƲM���ñN��Ƽg�J�ɮפ���
    static void WriteDataToClearFileData( string path , string addData );
    // ���Φr�� str = "A B"  , pattern = " " ->  return[0] = "A" , return[1] = "B"
    static vector<string> split(string str,string pattern);
    // 4 Byte�ƭ��ഫ 10 �i��r��
    static string FourByteToDecString( const unsigned int data );
    // �r���ഫ 4 Bytes ���
    static unsigned int StringToFourByte( string numberStr );
    // ���o��e�ɶ����r��
    static string GetNowTime();
    // ���o�ɮצW�� : "C:\\123.test" -> return : "123.test"
    static string GetFileName( string path );
	//���o�ɮ׸��|
	static CString Tools::GetAppPath();
	//���ɮצW�٥Ϊ��ɶ�
	static string GetNowTimeForFile();
	//�ˬd�ؿ�,�p�G���s�b�h�Ыإؿ�
	static bool FindOrCreateDirectory( const char* pszPath );
	static bool isExistFile(const char *pszFileName);
    static CString GetFilePath( CString filePath );
private:
    // �N��Ƽg�J�ɮפ���
    static void WriteDataToFile( string path , string addData , int openType );
    // ���o 10 �� N ����( 1 ~ 1000000000 )
    static unsigned int GetTenToThePowerN( unsigned char powerN );
    // �r���ഫ���
    static char CharToInt(const char str );
};