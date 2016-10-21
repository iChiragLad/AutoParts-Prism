using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.AutoParts.ApplicationService
{
    public class ApplicationService
    {
        public ApplicationService() { }
        public static readonly ApplicationService _instance = new ApplicationService();
        public static ApplicationService Instance { get { return _instance; } }
        public IEventAggregator _eventAggregator;
        public IEventAggregator EventAggregator
        {
            get
            {
                if (_eventAggregator == null)
                    _eventAggregator = new EventAggregator();
                return _eventAggregator;
            }
        }
    }
}
