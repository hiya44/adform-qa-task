using Xunit;
using System;
using adform_uzduotis.Objects;
using adform_uzduotis.Application;
using System.Collections.Generic;
using System.Linq;
using Moq;
using adform_uzduotis.Infrastructure;

namespace AppLogicTests
{
    public class AppLogicTestMethods
    {
        private AppLogic appLogic;
        private readonly Mock<IFileReader> _fileReader;

        public AppLogicTestMethods()
        {
            _fileReader = new Mock<IFileReader>();
            this.appLogic = new AppLogic(_fileReader.Object);
        }
        [Fact]
        public void AddToList_AddingNonNumbers_AddsInvalidEntry()
        {
            string item = "aaaaaa";
            string expected = "invalid: can not start with an a ";
            string actual = appLogic.BuildBirthDateString(item);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AddToList_AddingStringShorterThan11_AddsInvalidEntry()
        {
            string item = "111111111";
            string expected = "invalid: must be 11 characters long ";
            string actual = appLogic.BuildBirthDateString(item);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AddToList_IfBirthDateIsWrong_AddsInvalidEntry()
        {
            string item = "10013441111";
            string expected = "invalid: birth date is wrong";
            string actual = appLogic.BuildBirthDateString(item);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CheckBirthDate_ReturnsFalse_IfBirthDateIsWrong()
        {
            string month = "13";
            string day = "32";
            bool expected = false;
            bool actual = appLogic.CheckBirthDate(month, day);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateReturnString_IfLengthIsShorterThan11_ReturnsInvalidEntry()
        {
            char gender = '1';
            int length = 2;
            string birthDate = "00-01-01";
            string expected = "invalid: must be 11 characters long ";
            string actual = appLogic.CreateReturnString(gender,length,birthDate);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CreateReturnString_LengthLessThan11ReturnsInvalidEntry()
        {
            char gender = '1';
            int length = 2;
            string expected = "invalid: must be 11 characters long ";
            string actual = appLogic.CreateReturnString(gender, length);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CreateReturnString_GenderLessThenOne_ReturnsInvalidEntry()
        {
            char gender = '0';
            int length = 11;
            string birthDate = "1";
            string expected = "invalid: can not start with an 0 ";
            string actual = appLogic.CreateReturnString(gender, length, birthDate);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CreateReturnString_NullBirthDate_ReturnsInvalidEntry()
        {
            char gender = '1';
            int length = 11;
            string expected = "invalid: birth date is wrong ";
            string actual = appLogic.CreateReturnString(gender, length);

            Assert.Equal(expected, actual);
        }
    }
}