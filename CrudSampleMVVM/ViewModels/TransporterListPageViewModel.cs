using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


using Windows.UI.Popups;

using Caliburn.Micro;

using SQLite;

using CrudSampleMVVM.Business;
using CrudSampleMVVM.Business.Dao;
using CrudSampleMVVM.Business.Model;

namespace CrudSampleMVVM.ViewModels
{
    public class TransporterListPageViewModel : ViewModelBase
    {
        public string Title { get; set; }

        public TransporterListViewModel TransporterListVM { get; set; }
        public TransporterListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "TransporterList Page";
            LoadData();
            this.TransporterListVM = new TransporterListViewModel(navigationService);
            
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

        //private Transporter p_SelectedItem;
        //public Transporter SelectedItem
        //{
        //    get
        //    {

        //        return p_SelectedItem;
        //    }

        //    set
        //    {
        //        p_SelectedItem = value;
        //        NotifyOfPropertyChange(() => this.SelectedItem);
        //        ShowMyMessage(p_SelectedItem);
        //        Transporter p = p_SelectedItem;
        //        navigationService.NavigateToViewModel<TransporterCrudPageViewModel>(p);
        //    }
        //}

        public async void ShowMyMessage(Transporter p)
        {
            
            var md = new MessageDialog("Pesona selezionata dalla lista",p.trName.ToString());
            await md.ShowAsync();
        }

        public async void GoToTransporterCrud()
        {
            //var md = new MessageDialog("GoToSecondPage invoked", "SecondPageViewModel");
            //await md.ShowAsync();


            navigationService.NavigateToViewModel<TransporterCrudPageViewModel>();
            //navigationService.UriFor<SecondPageViewModel>().WithParam(l => l.Title, "Navigated from MainViewModel").Navigate();

        }
    }
    
}
