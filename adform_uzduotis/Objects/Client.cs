using adform_uzduotis.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adform_uzduotis.Objects
{
    internal class Client
    {
        private IService _service;

        public Client(IService service)
        {
            this._service = service;
        }
        public SocialNumbers PopulateListMethod(string fileName)
        {
            return this._service.PopulateList(fileName);
        }
    }
}
