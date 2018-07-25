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
    
    public class SubMenuShootViewModel : ViewModelBase
    {
        public ICommand FrayMenuCommand { get; private set; }
        public ICommand PortraitMenuCommand { get; private set; }
        public ICommand UVMenuCommand { get; private set; }

        public SubMenuShootViewModel()
        {
            FrayMenuCommand = new RelayCommand(FrayMenuSelected);
            PortraitMenuCommand = new RelayCommand(PortraitMenuSelected);
            UVMenuCommand = new RelayCommand(UVMenuSelected);

        }

        public void FrayMenuSelected()
        {
            Console.WriteLine("FrayMenuSelected");
        }
        public void PortraitMenuSelected()
        {
            Console.WriteLine("PortraitMenuSelected");
        }
        public void UVMenuSelected()
        {
            Console.WriteLine("UVMenuSelected");
        }
    }
}
