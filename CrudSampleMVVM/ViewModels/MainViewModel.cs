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
    public class MainViewModel : ViewModelBase
    {
        // constructor
        public MainViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _title = "Welcome to Caliburn Micro";
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }



        private Visibility _textBlockVisibility;
        public Visibility TextBlockVisibility
        {
            get { return _textBlockVisibility; }
            set
            {
                if (value == _textBlockVisibility)
                    return;
                _textBlockVisibility = value;
                NotifyOfPropertyChange(() => TextBlockVisibility);
            }
        }

        private void UpdateText()
        {
            var isVisible = TextBlockVisibility == Visibility.Visible;

            TextBlockVisibility = isVisible ? Visibility.Collapsed : Visibility.Visible;
        }



        public async void GoToTransporterList()
        {
            var md = new MessageDialog("GoToSecondPage invoked", "SecondPageViewModel");
            await md.ShowAsync();


            navigationService.NavigateToViewModel<TransporterListPageViewModel>();
            //navigationService.UriFor<SecondPageViewModel>().WithParam(l => l.Title, "Navigated from MainViewModel").Navigate();

        }
    }

}
