using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Caliburn.Micro;

namespace CrudSampleMVVM.Business.Model
{
    public class Truck : Entity
    {
        private int _truckId;
        public int truckId
        {
            get
            {
                return _truckId;
            }
            set
            {
                _truckId = value;
                NotifyOfPropertyChange(() => truckId);
            }
        }

        private string _code;
        public string code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                NotifyOfPropertyChange(() => code);
            }
        }

        private string _vin;
        public string vin
        {
            get
            {
                return _vin;
            }
            set
            {
                _vin = value;
                NotifyOfPropertyChange(() => vin);
            }
        }

        private string _url;
        public string url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                NotifyOfPropertyChange(() => url);
            }
        }

        private int _trId;
        public int trId
        {
            get
            {
                return _trId;
            }
            set
            {
                _trId = value;
                NotifyOfPropertyChange(() => trId);
            }
        }

        private string _trName;
        public string trName
        {
            get { return _trName; }
            set
            {
                _trName = value;
                NotifyOfPropertyChange(() => trName);
            }
        }

        private string _trCode;
        public string trCode
        {
            get { return _trCode; }
            set
            {
                _trCode = value;
                NotifyOfPropertyChange(() => trCode);
            }
        }

        private string _trUrl;
        public string trUrl
        {
            get { return _trUrl; }
            set
            {
                _trUrl = value;
                NotifyOfPropertyChange(() => trUrl);
            }
        }
    }
}
