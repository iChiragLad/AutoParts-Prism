using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.AutoParts.ApplicationService;
using Trial.AutoParts.Modules.Statusbar.ViewModel;

namespace Trial.AutoParts.Modules.Statusbar
{
    class ViewModelLocator
    {
        private static StatusViewModel _statusViewModel = new StatusViewModel(ApplicationService.ApplicationService.Instance.EventAggregator);

        public static StatusViewModel StatusViewModelObject
        {
            get { return _statusViewModel; }
        }
    }
}
