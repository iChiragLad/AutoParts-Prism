using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.AutoParts.Modules.Detail.ViewModel;
using Trial.AutoParts.ApplicationService;
namespace Trial.AutoParts.Modules.Detail
{
    class ViewModelLocator
    {

        private static DetailViewModel _detailViewModel = new DetailViewModel(ApplicationService.DataService.Instance.AutoPartsRepository, ApplicationService.ApplicationService.Instance.EventAggregator);

        public static DetailViewModel DetailViewModelObject
        {
            get { return _detailViewModel; }
        }
    }
}
