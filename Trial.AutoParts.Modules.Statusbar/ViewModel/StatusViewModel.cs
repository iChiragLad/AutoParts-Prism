using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trials.AutoParts.Modules.Overview.ViewModel;

namespace Trial.AutoParts.Modules.Statusbar.ViewModel
{
    public class StatusViewModel : INotifyPropertyChanged
    {
        public IEventAggregator _aggregator;
        public StatusViewModel(IEventAggregator ev)
        {
            StatusString = "Status.........";
            _aggregator = ev;
            _aggregator.GetEvent<UpdateStatusEvent>().Subscribe(OnUpdatedStatusReceived);
            
        }
        private string _status;
        public string StatusString
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged("StatusString");
            }
        }

        private void OnUpdatedStatusReceived(string s)
        {
            StatusString = s;
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
