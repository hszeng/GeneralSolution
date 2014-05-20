// HelloWord.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "../std_lib_facilities.h"

int _tmain(int argc, _TCHAR* argv[])
{
	//cout<<"Hello,World!\n";
	//keep_window_open();
	//
	/*cout<<"Please enter your name(followed by 'enter':\n";
	string first_name;
	cin>>first_name;
	cout<<"Hello,"<<first_name<<"!\n";
	keep_window_open();*/
	//3.3
	/*cout<<"Please enter your first name and age\n";
	string firstname="???";
	int age=-1;
	cin>>firstname>>age;
	cout<<"Hello,"<<firstname<<"(age"<<age<<")\n";
	keep_window_open();*/
	//3.4
	/*cout<<"Please enter a floating point value\n";
	double n;
	cin>>n;	
	cout<<"n="<<n
		<<"\nn+1="<<n+1
		<<"\nthree times n="<<3*n
		<<"\ntwice n="<<n+n
		<<"\nn squared="<<n*n
		<<"\nhalf of n="<<n/2
		<<"\nsquare root of n="<<sqrt(n)
		<<endl;		
	keep_window_open();*/
	//3.5
	/*string previous=" ";
	string current;
	while(cin>>current)
	{
	if(previous==current)
		cout<<"repeat word:"<<current<<"\n";
	previous=current;
	}*/
	//3.6
	int number_of_words=0;
	string previous=" ";
	string current;
	while(cin>>current)
	{
		++number_of_words;
	if(previous==current)
		cout<<"word number"<<number_of_words<<" repeated:"<<current<<"\n";
	previous=current;
	}
	return 0;
}

