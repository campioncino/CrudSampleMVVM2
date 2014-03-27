using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * In our application though, we're going to create a base class 
 * for our ViewModels called ViewModelBase, which will inherit from 
 * the Screen class, but will also contain an instance of the 
 * INavigationService (injected), as well as a property indicating 
 * whether we can navigate backwards, and a method that performs 
 * the navigation. 

 * With this base class in place, any of our ViewModels that derive
 * from it, will have access to the INavigationService and as such, 
 * they'll be able to navigate to another View or ViewModel. 
 * The GoBack() method will also be bound by convention to the back 
 * button, and will only be displayed when we can actually go back. 
 * 
 */

using Caliburn.Micro;
using System.Diagnostics;


namespace CrudSampleMVVM.ViewModels
{
    public abstract class ViewModelBase : Screen
    {
        public INavigationService navigationService;

        public ViewModelBase(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void GoBack()
        {
            navigationService.GoBack();
        }

        public bool CanGoBack
        {
            get
            {
                return navigationService.CanGoBack;
            }
        }

        
        protected override void OnActivate()
        {
            base.OnActivate();
            Debug.WriteLine("OnActivate:");
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            Debug.WriteLine("OnViewLoaded");
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            Debug.WriteLine("OnDeactivate");
        }

    }
}
