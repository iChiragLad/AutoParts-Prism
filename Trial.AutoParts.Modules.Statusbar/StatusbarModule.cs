using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace Trial.AutoParts.Modules.Statusbar
{
    public class StatusbarModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public StatusbarModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("StatusRegion", typeof(Statusbar));
        }
    }
}
