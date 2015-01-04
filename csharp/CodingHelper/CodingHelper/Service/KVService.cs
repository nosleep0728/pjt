using CodingHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingHelper.Service
{
    class KVService
    {

        private KVService()
        {

        }

        public List<KVVO> getKVVOList()
        {
            var list = new List<KVVO>();


            return list;
        }

        private static KVService _inst = new KVService();
        private static KVService Inst{
            get{ return _inst;}
        }
    }
}
