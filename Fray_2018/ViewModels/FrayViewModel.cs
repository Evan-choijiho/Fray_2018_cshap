using Fray_2018.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fray_2018.ViewModels
{
    public class FrayViewModel : ViewModelBase
    {
        private FrayModel _frayModel;
        private CameraControlModel _cameraControlModel;

        public ICommand LoadSubmenuShootCommand { get; private set; }
        public ICommand LoadSubmenuViewerCommand { get; private set; }
        public SubMenuShootViewModel _menuShoot;
        public SubMenuViewerViewModel _menuViewer;
        public CameraControlViewModel _cameraControl;


        public FrayViewModel()
        {
            _frayModel = new FrayModel();
            _cameraControlModel = new CameraControlModel();

            LoadSubmenuShootCommand = new RelayCommand(LoadSubmenuShoot);
            LoadSubmenuViewerCommand = new RelayCommand(LoadSubmenuViewer);

            _menuShoot = new SubMenuShootViewModel();
            _menuViewer = new SubMenuViewerViewModel();
            _cameraControl = new CameraControlViewModel();

            this.SetCameraControl.CameraControl = _cameraControl;
            LoadSubmenuViewer();
        }

        
        public FrayModel SelectSubMenu
        {
            get { return _frayModel; }
            set
            {
                Console.WriteLine("SelectSubMenu called");

                _frayModel = value;
                RaisePropertyChanged("SelectSubMenu");
            }
        }
        

        public CameraControlModel SetCameraControl
        {
            get { return _cameraControlModel; }
            set
            {
                Console.WriteLine("SetCameraControl called");

                _cameraControlModel = value;
                RaisePropertyChanged("SetCameraControl");
            }
        }

        public void LoadSubmenuShoot()
        {
            //_frayModel.SubMenu = _menuShoot;
            Console.WriteLine("LoadSubmenuShoot called");

            this.SelectSubMenu.SubMenu = _menuShoot; 
            //SelectSubMenu.setfi = _menuShoot;
            //CurrentViewModel = new SubMenuShoot();
        }
        public void LoadSubmenuViewer()
        {
            //_frayModel.SubMenu = _menuViewer;
            Console.WriteLine("LoadSubmenuViewer called");

            this.SelectSubMenu.SubMenu = _menuViewer;
            //CurrentViewModel = new SubMenuViewer();
        }

    }
}
