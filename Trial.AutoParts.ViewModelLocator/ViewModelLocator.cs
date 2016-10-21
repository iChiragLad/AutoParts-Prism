using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.AutoParts.DataAccess;
using Trial.AutoParts.Modules.Detail;
using Trial.AutoParts.Modules.Detail.ViewModel;
using Trials.AutoParts.Modules.Overview;
using Trials.AutoParts.Modules.Overview.Service;
using Trials.AutoParts.Modules.Overview.ViewModel;
using Prism.Events;

namespace Trial.AutoParts.ViewModelLocator
{
    public class ViewModelLocator
    {
        static IEventAggregator ev = new EventAggregator();
        private static OverviewViewModel _overviewViewModel = new OverviewViewModel(new DataAccessService(new AutoPartsRepository()), new OpenNextWindowService(), ev);
        private static DetailViewModel _detailViewModel = new DetailViewModel(ev);

        public static OverviewViewModel OverviewViewModelObject
        {
            get { return _overviewViewModel; }
        }

        public static DetailViewModel DetailViewModelObject
        {
            get { return _detailViewModel; }
        }
    }
}
