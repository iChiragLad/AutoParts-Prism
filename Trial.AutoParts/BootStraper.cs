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
        }

    }
}
