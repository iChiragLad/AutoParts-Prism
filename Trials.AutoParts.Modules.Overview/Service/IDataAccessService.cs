using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.AutoParts.DataAccess;

namespace Trials.AutoParts.Modules.Overview.Service
{
    public interface IDataAccessService
    {
        void DeletePartEntry(Parts part);
        void SavePart(Parts part);
        Parts GetPartByID(int id);
        List<Parts> GetAllParts();
    }
}
