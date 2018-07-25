using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fray_2018.Model
{
    public class CameraControlModel : ObservableObject
    {
        private ViewModelBase _cameraControl;

        
        public ViewModelBase CameraControl
        {
            get { return _cameraControl; }
            set { Set<ViewModelBase>(() => this.CameraControl, ref _cameraControl, value); }
        }
    }
}
