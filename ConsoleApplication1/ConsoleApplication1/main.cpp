#include <iostream>
int main(int argc, char** argv) {
	try {
		//Main
		throw 10;
	}
	catch (...) {
		//Handle error
		std::cout << "Error" << std::endl;
		system("pause");
		return true;
	}
	system("pause");
	return false;
}