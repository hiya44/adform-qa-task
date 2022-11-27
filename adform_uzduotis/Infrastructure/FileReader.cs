using adform_uzduotis.Application;
using adform_uzduotis.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adform_uzduotis.Infrastructure
{
    internal class FileReader : IFileReader
    {
        public List<string> ReadData(string fileName)
        {
            List<string> readData = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    readData.Add(line);
                }
                reader.Close();
                Console.WriteLine("All lines read");
            }
            return readData;
        }
        public void OutputData(SocialNumbers list, string fileName)
        {      
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    foreach (string item in list.Get())
                    {
                        Console.WriteLine(item);
                        sw.WriteLine(item);
                    }
                }
            }
            catch (NullReferenceException ex) { Console.WriteLine(ex); }
        }
    }
}
