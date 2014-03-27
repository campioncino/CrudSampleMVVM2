using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//per usare i messaggi a video
using Windows.UI.Popups;

using Caliburn.Micro;

using CrudSampleMVVM.Business;
using CrudSampleMVVM.Business.Dao;
using CrudSampleMVVM.Business.Model;
namespace CrudSampleMVVM.ViewModels
{
    public class TransporterFormViewModel :ViewModelBase
    {

        
        public string Title { get; set; }

        public Transporter Transporter { get; set; }

        public TransporterFormViewModel(INavigationService navigationService, Transporter trans)
            : base(navigationService)
        {
            Transporter = trans;
        }
        //public TransporterFormViewModel(INavigationService navigationService)
        //    : base(navigationService)
        //{

        //}

        

        private string _trName;
        public string trName 
        {
            get
            {
                return _trName;
            }
            set
            {
                _trName = value;
                NotifyOfPropertyChange(() => trName);
            }
        }

        
        public string trCode { get; set; }
        public string trUrl { get; set; }

        public int trId { get; set; }


        public async void SaveTransporter()
        {

            Transporter p = new Transporter(trId, trName, trUrl, trCode);


            await TransporterService.SaveTransporter(p);
        }

        
        
    }
}
