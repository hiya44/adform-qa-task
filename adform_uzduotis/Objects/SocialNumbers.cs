using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adform_uzduotis.Objects
{
    public class SocialNumbers
    { 
        private List<string> numbers;
        public SocialNumbers()
        {
            this.numbers = new List<string>();
        }

        public void Add(string data)
        {
            numbers.Add(data);
        }
        public List<string> Get()
        {
            return numbers;
        }
    }
}
