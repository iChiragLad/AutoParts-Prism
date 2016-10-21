using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trial.AutoParts.DataAccess;
using Trial.AutoParts.Modules.Detail.ViewModel;
using Trials.AutoParts.Modules.Overview.Utility;
using Trials.AutoParts.Modules.Overview.ViewModel;
using Trial.AutoParts.ApplicationService;

namespace Trial.AutoParts.Modules.Detail.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        IAutoPartsRepository _autoPartsRepository;
        public IEventAggregator _aggregator;
        public DetailViewModel(IAutoPartsRepository au, IEventAggregator ev)
        {
            _autoPartsRepository = au;
            LoadCommands();
            _aggregator = ev;
            _aggregator.GetEvent<ItemSelectedEvent>().Subscribe(OnPartReceived);
        }

        public DetailViewModel() : this(ApplicationService.DataService.Instance.AutoPartsRepository, ApplicationService.ApplicationService.Instance.EventAggregator)
        {
        }

        private void OnPartReceived(Parts part)
        {
            SelectedPart = part;
        }

        private void LoadCommands()
        {
            SaveCommand = new CustomCommand(SavePart, canSavePart);
            DeleteCommand = new CustomCommand(DeletePart, canDeletePart);
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

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

        private void DeletePart(object obj)
        {
            _autoPartsRepository.DeletePart(SelectedPart);
            _aggregator.GetEvent<UpdatePartsListEvent>().Publish(new Object());
            _aggregator.GetEvent<UpdateStatusEvent>().Publish("Part deleted successfully....");
        }
        private bool canDeletePart(object obj)
        {
            return true;
        }
        private bool canSavePart(object obj)
        {
            return true;
        }
        private void SavePart(object obj)
        {
            _autoPartsRepository.UpdatePart(SelectedPart);
            _aggregator.GetEvent<UpdatePartsListEvent>().Publish(new Object());
            _aggregator.GetEvent<UpdateStatusEvent>().Publish("Part Saved successfully....");
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

    
}
