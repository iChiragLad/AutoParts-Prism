using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Trials.AutoParts.Modules.Overview.Service
{
    public class OpenNextWindowService : IOpenNextWindowService
    {
        IRegionManager rm;
        IRegion rgn;
        Uri vu;
        public OpenNextWindowService()
        {
            rm = ServiceLocator.Current.GetInstance<IRegionManager>();
            rgn = rm.Regions["BlotterRegion"];
        }


        public void LoadModule()
        {
            vu = new Uri("Detail", UriKind.Relative);
            rgn.RequestNavigate(vu, CheckForError);
        }

        public void UnLoadModule()
        {
            vu = new Uri("BlotterRegionDefault", UriKind.Relative);
            rgn.RequestNavigate(vu, CheckForError);
        }

        void CheckForError(NavigationResult nr)
        {
            if (nr.Result == false)
            {
                throw new Exception(nr.Error.Message);
            }
        }

    }
}
