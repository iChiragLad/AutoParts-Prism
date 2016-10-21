using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trial.AutoParts;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Trial.AutoParts.Modules.Ribbon;
using Trial.AutoParts.Modules.Statusbar;
using Trials.AutoParts.Modules.Overview;
using Trial.AutoParts.Modules.Detail;
using Trial.AutoParts.Modules.BlotterRegionDefault;

namespace Trial.AutoParts
{
    class BootStraper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return this.Container.Resolve<PrismAppShell>();
        }
        protected override void InitializeModules()
        {
            base.InitializeModules();
            App.Current.MainWindow = (PrismAppShell)this.Shell;
            App.Current.MainWindow.Show();
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(RibbonModule));
            moduleCatalog.AddModule(typeof(StatusbarModule));
            moduleCatalog.AddModule(typeof(OverviewModule));
            moduleCatalog.AddModule(typeof(BlotterRegionDefaultModule));
            moduleCatalog.AddModule(typeof(DetailModule));
        }

    }
}
