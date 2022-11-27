using adform_uzduotis.Objects;
using adform_uzduotis.Infrastructure;
using adform_uzduotis.Application;

string readFile = @"..\..\..\input.txt";
string writeFile = @"..\..\..\output.txt";


IFileReader fileReader = new FileReader();
IService service = new AppLogic(fileReader);
Client client = new Client(service);

SocialNumbers data = client.PopulateListMethod(readFile);

fileReader.OutputData(data, writeFile);