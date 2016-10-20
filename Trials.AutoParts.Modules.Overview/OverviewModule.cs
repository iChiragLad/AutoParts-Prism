using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace Trials.AutoParts.Modules.Overview
{
    public class OverviewModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public OverviewModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("TreeRegion", typeof(Overview));
        }
    }
}
