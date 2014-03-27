using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;

namespace CrudSampleMVVM.Business.Model
{
    public class Transporter : Entity
    {

        public Transporter() 
        {
            trId = -1;
            trName = null;
            trCode = null;
            trUrl = null;
        }
        public Transporter(int id, string name, string url, string code) 
        {
            trId = id;
            trName = name;
            trCode = code;
            trUrl = url;
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
                NotifyOfPropertyChange(()=> trName );
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
