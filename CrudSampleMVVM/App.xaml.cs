using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Reflection;

using Caliburn.Micro;

using CrudSampleMVVM.Views;
using CrudSampleMVVM.ViewModels;

using CrudSampleMVVM.Business.Dao;

namespace CrudSampleMVVM
{
    sealed partial class App : CaliburnApplication
    {
        // add our IOC container for registering services etc
        private WinRTContainer container;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            try
            {
                //non capisco perchè non posso scrivere
                // DatabaseConnection.Instance;
                // facciamo una zezzaria per scirvere 
                DatabaseConnection.Singleton();
                //DatabaseConnection c = DatabaseConnection.Instance;

            }
            catch (Exception)
            {
                var msgDlg = new Windows.UI.Popups.MessageDialog("Impossibile creare Database");
                msgDlg.DefaultCommandIndex = 1;
                msgDlg.ShowAsync();
            }
        }

        /* starting database */


        protected override void Configure()
        {
            container = new WinRTContainer();
            container.RegisterWinRTServices();
            //container.PerRequest<MainPageViewModel>();

        }

        /*
         * AUTOMATIC REGISTRATIOn
         * 
         */
        private static bool IsConcrete(Type service)
        {
            var serviceInfo = service.GetTypeInfo();
            return !serviceInfo.IsAbstract && !serviceInfo.IsInterface;
        }

        protected override object GetInstance(Type service, string key)
        {
            var obj = container.GetInstance(service, key);

            // mimic previous behaviour of WinRT SimpleContainer
            if (obj == null && IsConcrete(service))
            {
                container.RegisterPerRequest(service, key, service);
                obj = container.GetInstance(service, key);
            }

            return obj;
        }


        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            DisplayRootView<MainView>();
        }



        //protected override object GetInstance(Type service, string key)
        //{
        //    return container.GetInstance(service, key);
        //}

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            container.RegisterNavigationService(rootFrame);
        }


    }
}