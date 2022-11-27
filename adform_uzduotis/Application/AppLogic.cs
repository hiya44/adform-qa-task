using adform_uzduotis.Infrastructure;
using adform_uzduotis.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adform_uzduotis.Application
{
    public class AppLogic : IService
    {
        private readonly IFileReader _fileReader;
        public AppLogic(IFileReader fileReader)
        {
            this._fileReader = fileReader;
        }

        public SocialNumbers PopulateList(string fileName)//filename?
        {
            var itemsFromFile = _fileReader.ReadData(fileName);
            var list = new SocialNumbers();
            foreach (string item in itemsFromFile)
            {
                list.Add(BuildBirthDateString(item));
            }
            return list;
        }
        public string BuildBirthDateString(string item)
        {
            char[] socialNumChars = item.ToCharArray();
            var gender = socialNumChars[0];
            if (!Char.IsNumber(gender))
            {
                return String.Format("invalid: can not start with an {0} ",
                                        gender); ;
            }
            try
            {
                ValidateLength(socialNumChars.Length);
            }
            catch (Exception ex)
            {
                return "invalid:" + ex.Message;
            }
            
            var birthYear = DateMaker(socialNumChars[1], socialNumChars[2]);
            var birthMonth = DateMaker(socialNumChars[3], socialNumChars[4]);
            var birthDay = DateMaker(socialNumChars[5], socialNumChars[6]);

            if (CheckBirthDate(birthMonth, birthDay))
            {
                var birthDate = birthYear + "-" + birthMonth + "-" + birthDay;
                string socialNum = CreateReturnString(gender, socialNumChars.Length, birthDate);
                return socialNum;
            }
            else return new string("invalid: birth date is wrong");
        }
        public string DateMaker(char firstNum, char secondNum)
        {
            return new string(firstNum.ToString() + secondNum);
        }

        public bool CheckBirthDate(string month, string day)
        {
            if (Enumerable.Range(1, 12).Contains(Convert.ToInt32(month)) && Enumerable.Range(1, 31).Contains(Convert.ToInt32(day)))
            {
                return true;
            }
            return false;
        }
        public string CreateReturnString(char gender, int length, string birthDate = null)
        {

            string returnString = "invalid:";
            try
            {
                ValidateLength(length);
                ValidateBirthDate(birthDate);
                ValidateGender(gender);
            }
            catch (Exception ex)
            {
                returnString += ex.Message;
                return returnString;
            }
            returnString = gender switch
            {
                '1' => String.Format("male, 18{0}",
                                            birthDate),
                '2' => String.Format("female, 18{0}",
                                            birthDate),
                '3' => String.Format("male, 19{0}",
                                            birthDate),
                '4' => String.Format("female, 19{0}",
                                            birthDate),
                '5' => String.Format("male, 20{0}",
                                            birthDate),
                '6' => String.Format("female, 20{0}",
                                            birthDate),
            };
            return returnString;
        }
        private bool ValidateLength(int length)
        {
            if (length != 11)
            {
                throw new Exception(" must be 11 characters long ");
            }
            return true;
        }
        private bool ValidateBirthDate(string birthDate)
        {
            if (birthDate == null)
            {
                throw new Exception(" birth date is wrong ");
            }
            return true;
        }
        private bool ValidateGender(char gender)
        {
            if (!Enumerable.Range(1, 6).Contains((int)char.GetNumericValue(gender)))
            {
                throw new Exception(String.Format(" can not start with an {0} ",
                           gender));
            }
            return true;
        }
    }
}
