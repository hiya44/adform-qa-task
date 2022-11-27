using adform_uzduotis.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adform_uzduotis.Application
{
    internal interface IService
    {
        SocialNumbers PopulateList(string fileName);
        string BuildBirthDateString(string item);
        string DateMaker(char firstNum, char secondNum);
        bool CheckBirthDate(string month, string day);
        string CreateReturnString(char gender, int length, string birthDate = null);
    }
}
