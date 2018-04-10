#include <iostream>
#include <fstream>
#include <afx.h> 
#include "tools.h"

using namespace std;


class Cap
{
public:
	Cap();
	~Cap();
	void LoadConfig();

private:
	string srcPath;
	string destPath;
	

};