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

using CrudSampleMVVM.Views;
using System.Diagnostics;


namespace CrudSampleMVVM.ViewModels
{
    public class TransporterCrudPageViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public static Transporter Parameter { get; set; }

        Transporter t { get; set; }
        public TransporterFormViewModel TransporterFormVM { get; set; }

        public async void InitializeTransporterForm(Transporter enumerable)
        {
            TransporterFormVM = new TransporterFormViewModel(navigationService, enumerable);
            Parameter = enumerable; //setting the Parameter property..
            try
            {
                await SetUpForm(Parameter);
                Debug.WriteLine("SetupForm Executed");
            }
            catch (Exception e) { Debug.WriteLine("SetupForm Exception");  }
        }

 
        public async Task SetUpForm(Transporter t){
            Debug.WriteLine("Value in CrudPage = " + Parameter.trName);
            TransporterFormVM.trName = Parameter.trName;
            TransporterFormVM.trUrl = Parameter.trUrl;
            
        }
        public TransporterCrudPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "TransporterCrud Page";
            this.navigationService = navigationService;   
           
            //TransporterFormVM = new TransporterFormViewModel(navigationService);
            this.InitializeTransporterForm(Parameter);

        }



        private BindableCollection<Transporter> _transporters;

        public BindableCollection<Transporter> Transporters
        {
            get
            {
                return this._transporters;
            }
            set
            {
                this._transporters = value;
                NotifyOfPropertyChange(() => this.Transporters);
            }
        }

        
        public async void ShowMyMessage()
        {
            
            var md = new MessageDialog("Pesona selezionata dalla lista");
            await md.ShowAsync();
        }

        public async void Discard()
        {
            var md = new MessageDialog("GoToSecondPage invoked", "SecondPageViewModel");
            await md.ShowAsync();

            this.GoBack();
            
        }

        public async void Save()
        {
            var md = new MessageDialog("Saving Transporter");
            await md.ShowAsync();

            TransporterFormVM.SaveTransporter();
            navigationService.NavigateToViewModel<TransporterListPageViewModel>();
        }



       
    }
}
    

