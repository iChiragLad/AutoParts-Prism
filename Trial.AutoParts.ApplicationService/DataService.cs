using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.AutoParts.DataAccess;

namespace Trial.AutoParts.ApplicationService
{
    public class DataService
    {
        public DataService() { }
        public static readonly DataService _instance = new DataService();
        public static DataService Instance { get { return _instance; } }
        public IAutoPartsRepository _autoPartsRepository;
        public IAutoPartsRepository AutoPartsRepository
        {
            get
            {
                if (_autoPartsRepository == null)
                    _autoPartsRepository = new AutoPartsRepository();
                return _autoPartsRepository;
            }
        }
    }
}
