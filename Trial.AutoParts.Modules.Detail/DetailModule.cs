using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Modularity;
using Prism.Regions;

namespace Trial.AutoParts.Modules.Detail
{
    public class DetailModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        public DetailModule(IRegionViewRegistry registry)
        {
            this.regionViewRegistry = registry;
        }

        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("BlotterRegion", typeof(Detail));
        }
    }
}
