using Fray_2018.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fray_2018
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string screen_height = SystemParameters.VirtualScreenHeight.ToString();
            string screen_width = SystemParameters.VirtualScreenWidth.ToString();
            //MessageBox.Show("height : " + screen_height + ", width : " + screen_width);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            moveCenter();
            DataContext = new IntroModel();
            startScreenChangeTimer();
        }

        private void moveCenter()
        {
            Left = (SystemParameters.VirtualScreenWidth - Width) / 2;
            Top = (SystemParameters.VirtualScreenHeight - Height) / 2;
        }

        private void startScreenChangeTimer()
        {
            //
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunworkerCompleted);
            worker.DoWork += new DoWorkEventHandler(woker_Dowork);
            worker.RunWorkerAsync();
        }

        private void woker_Dowork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
        }

        private void worker_RunworkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 1.38       
            Height = 524;
            Width = 724;
            //Height = SystemParameters.MaximizedPrimaryScreenHeight;
            Height = SystemParameters.WorkArea.Height;
            Width = Height * 1.38;
            
            DataContext = new FrayViewModel();
            //DataContext = new SaveLocationModel();
            moveCenter();
            Top = 0;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        
        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private bool clicado = false;
        private Point lm = new Point();

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Rectangle_MouseDown");
            clicado = true;
            this.lm = e.GetPosition(this);
        }

        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Rectangle_MouseUp");
            clicado = false;
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Rectangle_MouseMove");
            if (clicado)
            {
                this.Left += (e.GetPosition(this).X - this.lm.X);
                this.Top += (e.GetPosition(this).Y - this.lm.Y);
                this.lm = e.GetPosition(this);
            }
        }
    }
}
