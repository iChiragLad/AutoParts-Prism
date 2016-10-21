using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trial.AutoParts.DataAccess;
using Trials.AutoParts.Modules.Overview.Extensions;
using Trials.AutoParts.Modules.Overview.Service;
using Trials.AutoParts.Modules.Overview.Utility;
using Prism;
using Prism.Events;
using Trial.AutoParts.ApplicationService;

namespace Trials.AutoParts.Modules.Overview.ViewModel
{
    public class OverviewViewModel : INotifyPropertyChanged
    {
        public IDataAccessService _dataAccessService;
        public IOpenNextWindowService _openNextWindowService;
        public IEventAggregator _aggregator;

        public OverviewViewModel(IDataAccessService dataService, IOpenNextWindowService WindowService, IEventAggregator ev)
        {
            _dataAccessService = dataService;
            _openNextWindowService = WindowService;
            _aggregator = ev;
            _aggregator.GetEvent<UpdatePartsListEvent>().Subscribe(OnUpdatePartsListReceived);
            LoadData();
            LoadCommands();
        }

        public OverviewViewModel() : this(new DataAccessService(DataService.Instance.AutoPartsRepository), new OpenNextWindowService(), ApplicationService.Instance.EventAggregator)
        {

        }

        private void LoadData()
        {
            PartsCollection = _dataAccessService.GetAllParts().ToObservableCollection();
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditPart, canEditPart);
        }

        public ICommand EditCommand { get; set; }

        private Parts _selectedPart;
        public Parts SelectedPart
        {
            get
            {
                return _selectedPart;
            }
            set
            {
                _selectedPart = value;
                RaisePropertyChanged("SelectedPart");
            }
        }

        private ObservableCollection<Parts> _partCollection;
        public ObservableCollection<Parts> PartsCollection
        {
            get
            {
                return _partCollection;
            }
            set
            {
                _partCollection = value;
                RaisePropertyChanged("PartsCollection");
            }
        }


        private void EditPart(object obj)
        {
            //Messenger.Default.Send<Parts>(SelectedPart);
            _aggregator.GetEvent<ItemSelectedEvent>().Publish(SelectedPart);
            _openNextWindowService.LoadModule();
        }

        private bool canEditPart(object obj)
        {
            if (SelectedPart != null)
            {
                return true;
            }
            return false;
        }

        private void OnUpdatePartsListReceived(Object obj)
        {
            _openNextWindowService.UnLoadModule();
            //_openNextWindowService.CloseWindow();
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    public class ItemSelectedEvent : PubSubEvent<Parts>
    {
    }
    public class UpdatePartsListEvent : PubSubEvent<Object>
    {
    }
    public class UpdateStatusEvent : PubSubEvent<string>
    {
    }

}
