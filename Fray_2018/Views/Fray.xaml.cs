using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fray_2018.Views
{
    /// <summary>
    /// Fray.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Fray : UserControl
    {
        public Fray()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SubMenuShoot();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new SubMenuViewer();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {

            //Height = SystemParameters.MaximizedPrimaryScreenHeight;
            Height = SystemParameters.WorkArea.Height;
            Width = Height * 1.38;
        }


        private void StackPanel_Initialized(object sender, EventArgs e)
        {
            Console.WriteLine("inittttttttttttttttttttttttt");
            
            //this.DataContext = new SubMenuShoot();
        }

   
    }
}
