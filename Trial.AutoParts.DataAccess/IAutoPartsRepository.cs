using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.AutoParts.DataAccess
{
    public interface IAutoPartsRepository
    {
        Parts GetPartByID(int id);
        List<Parts> GetAllParts();
        void DeletePart(Parts part);
        void UpdatePart(Parts part);
    }
}
