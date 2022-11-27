using adform_uzduotis.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adform_uzduotis.Infrastructure
{
    public interface IFileReader
    {
        List<string> ReadData(string fileName);
        void OutputData(SocialNumbers list, string fileName);
    }
}
