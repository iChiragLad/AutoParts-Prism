using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace Trial.AutoParts.Modules.Ribbon
{
    public class RibbonModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public RibbonModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("RibbonRegion", typeof(View.AutoPartsRibbon));
        }
    }
}
