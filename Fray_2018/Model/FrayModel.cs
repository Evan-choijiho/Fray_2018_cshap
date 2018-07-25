using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fray_2018.Model
{
    public class FrayModel : ObservableObject
    {
        private ViewModelBase _subMenu;

        public ViewModelBase SubMenu
        {
            get { return _subMenu; }
            set { Set<ViewModelBase>(() => this.SubMenu, ref _subMenu, value); }
        }
        

    }
}
