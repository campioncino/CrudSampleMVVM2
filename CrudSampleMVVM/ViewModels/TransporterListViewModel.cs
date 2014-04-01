using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

//per usare i messaggi a video
using Windows.UI.Popups;

using Caliburn.Micro;

using CrudSampleMVVM.Business;
using CrudSampleMVVM.Business.Dao;
using CrudSampleMVVM.Business.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;



namespace CrudSampleMVVM.ViewModels
{
    public class TransporterListViewModel : ViewModelBase
    {
        public string Title { get; set; }

        
        public TransporterListViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoadData();
        }

        public async void LoadData() {

            _transporters = await TransporterService.GetAll();
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

        public Transporter Transporter { get; set; }
        private Transporter _selectedItem;
        public Transporter SelectedItem
        {
            get 
            {
                
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(() => this.SelectedItem);
                //ShowMyMessage(_selectedItem);
                /*viva le porcate da una soluzione di StackOverFlow*/
                this.navigateWithParameter(_selectedItem);
                
                //navigationService.NavigateToViewModel<TransporterCrudPageViewModel>(Transporter);
            }
        }

        public async void navigateWithParameter(Transporter transporter) {
            navigationService.Navigated += NavigationServiceOnNavigated;
            navigationService.NavigateToViewModel<TransporterCrudPageViewModel>(transporter);
            navigationService.Navigated -= NavigationServiceOnNavigated;
        }

        private async static void NavigationServiceOnNavigated(object sender, NavigationEventArgs args)
        {
            FrameworkElement view;
            TransporterCrudPageViewModel transporterCrudPageViewModel;
            if ((view = args.Content as FrameworkElement) == null ||
                (transporterCrudPageViewModel = view.DataContext as TransporterCrudPageViewModel) == null) return;
            //view = args.Content as FrameworkElement;
            //transporterCrudPageViewModel = view.DataContext as TransporterCrudPageViewModel;
            Transporter tmp = new Transporter();
            tmp = args.Parameter as Transporter;
            if (tmp != null)
                Debug.WriteLine("Value in TransporterListViewModel = "+tmp.trName);
            transporterCrudPageViewModel.InitializeTransporterForm(tmp);
            
            
        }

       

        public async void ShowMyMessage(Transporter p)
        {
            
            var md = new MessageDialog("Pesona selezionata dalla lista",p.trName.ToString());
            await md.ShowAsync();
            navigationService.NavigateToViewModel<TransporterCrudPageViewModel>(p);

        }
    }
    
}
