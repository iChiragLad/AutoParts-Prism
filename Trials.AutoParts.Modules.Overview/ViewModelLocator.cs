using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trials.AutoParts.Modules.Overview.ViewModel;

namespace Trials.AutoParts.Modules.Overview
{
    class ViewModelLocator
    {
        private static OverviewViewModel _overviewViewModel = new OverviewViewModel();

        public static OverviewViewModel OverviewViewModelObject
        {
            get { return _overviewViewModel; }
        }
    }
}
