using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.AutoParts.Modules.BlotterRegionDefault
{
    public class BlotterRegionDefaultModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public BlotterRegionDefaultModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("BlotterRegion", typeof(BlotterRegionDefault));
        }
    }
}
