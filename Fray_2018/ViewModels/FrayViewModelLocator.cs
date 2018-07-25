using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fray_2018.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class FrayViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public FrayViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<FrayViewModel>();
            SimpleIoc.Default.Register<SubMenuShootViewModel>();
            SimpleIoc.Default.Register<CameraControlViewModel>();
            
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //SimpleIoc.Default.Register<FrayViewModel>();
        }
        /*
        public FrayViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FrayViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
        */
        public FrayViewModel FrayViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FrayViewModel>();
            }
        }

        public SubMenuShootViewModel SubMenuShootViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SubMenuShootViewModel>();
            }
        }

        public CameraControlViewModel CameraControlViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CameraControlViewModel>();
            }
        }


        private void NotifyUserMethod(NotificationMessage message)
        {
            MessageBox.Show(message.Notification);
        }

    }
}
