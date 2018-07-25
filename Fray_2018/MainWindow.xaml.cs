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
using System.Runtime.InteropServices;
using EDSDKLib;


namespace Fray_2018
{


    delegate uint SDKObjectEventHandler(uint inEvent, IntPtr inRef, IntPtr inContext);

    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        event SDKObjectEventHandler SDKObjectEvent;

        IntPtr camera;
        uint EdsError = EDSDK.EDS_ERR_OK;

        protected event EDSDK.EdsObjectEventHandler SDKObjectEvnet;

        public void DelegateMethod(string tmp)
        {
            MessageBox.Show("delegate method");
            
        }

        public MainWindow()
        {
            InitializeComponent();
        }
      
 
        private void btn_connect_click(object sender, RoutedEventArgs e)
        {

            

            IntPtr cameraList = new IntPtr(0);
            camera = new IntPtr(0);
            
            Int32 cameraCount = 0;
            EDSDK sdk = new EDSDK();

            EDSDK.EdsInitializeSDK();
            EdsError = EDSDK.EdsGetCameraList(out cameraList);

            //EdsError = EdsGetCameraList(out cameraList);
            EDSDK.EdsGetChildCount(cameraList, out cameraCount);
            label.Content = "Connected camera count : " + cameraCount.ToString();


            if (cameraCount != 0)
            {
                EdsError = EDSDK.EdsGetChildAtIndex(cameraList, 0, out camera);
                //MessageBox.Show("EdsGetChildAtIndex err code : " + EdsError.ToString());
            }

            

                EdsError = EDSDK.EdsOpenSession(camera);
            if (EdsError == EDSDK.EDS_ERR_OK)
            {
                label.Content = "Camera connected";

                EDSDK.EdsSetPropertyEventHandler(camera, EDSDK.PropertyEvent_All, propertyEventHandler, IntPtr.Zero);


                SDKObjectEvnet += new EDSDK.EdsObjectEventHandler(objectEventHandler);
                //SDKObjectEvent += new SDKObjectEventHandler(objectEventHandler);

                EdsError = EDSDK.EdsSetObjectEventHandler(camera, EDSDK.ObjectEvent_All, SDKObjectEvnet, IntPtr.Zero);
                if(EdsError == EDSDK.EDS_ERR_OK)
                {
                    label.Content = "NO ERROR";
                }else
                {
                    label.Content = "ERROR : "+EdsError;
                }
                EDSDK.EdsSetCameraStateEventHandler(camera, EDSDK.StateEvent_All, cameraStateEventHandler, IntPtr.Zero);  
                              
            }
            else
            {
                label.Content = "Camera not connected";
            }
        }

        
        // Event handler
        public uint propertyEventHandler(uint inEvent, uint inPropertyID, uint inParam, IntPtr inContext)
        {
            label.Content = "propertyEventHandler evnet : " + inEvent.ToString();
            
            return 0;
        }
        public uint objectEventHandler(uint inEvent, IntPtr inRef, IntPtr inContext)
        {
            //label.Content = "objectEventHandler evnet : " + inEvent.ToString();
            label.Content = "objectEventHandler evnet : ";
            MessageBox.Show("OBject event");
            return 0;
        }
        public uint cameraStateEventHandler(uint inEvent, uint inParameter, IntPtr inContext)
        {
            label.Content = "cameraStateEventHandler evnet : " + inEvent.ToString();
            return 0;
        }

        private void btn_shoot_click(object sender, RoutedEventArgs e)
        {
            //EdsError = EDSDK.EdsSendCommand(camera, EDSDK.CameraCommand_TakePicture, 0);
            EdsError = EDSDK.EdsSendCommand(camera, EDSDK.CameraCommand_PressShutterButton, (int)EDSDK.EdsShutterButton.CameraCommand_ShutterButton_Completely);
            EdsError = EDSDK.EdsSendCommand(camera, EDSDK.CameraCommand_PressShutterButton, (int)EDSDK.EdsShutterButton.CameraCommand_ShutterButton_OFF);
        }

        private void btn_liveview_click(object sender, RoutedEventArgs e)
        {
            //IntPtr device = new IntPtr(0);
            //Int32 device = 0;
            //Int32 device ;

            //device |= EDSDK.EvfOutputDevice_PC;
            //object device;
            /*
            if(camera == null)
            {
                label.Content = "camera is null";
            }else
            {
                label.Content = "camera is not null";
            }
            */
            int size = Marshal.SizeOf(typeof(Size));
            IntPtr device = Marshal.AllocHGlobal(size);
            
            //EdsError = EDSDK.EdsGetPropertySize(camera, EDSDK.PropID_Evf_OutputDevice, 0, out device, IntPtr.Size);
            EdsError = EDSDK.EdsGetPropertyData(camera, EDSDK.PropID_Evf_OutputDevice, 0, size, device);
            //EdsGetPropertyData(IntPtr inRef, uint inPropertyID, int inParam, out uint outPropertyData)


            //EDSDK.EvfOutputDevice_PC



            if (EdsError == EDSDK.EDS_ERR_OK)
            {
                label.Content = "OK";
                IntPtr stream;
                IntPtr outImg = new IntPtr(0); ;
                EdsError = EDSDK.EdsCreateMemoryStream(0, out stream);
                if(EdsError == EDSDK.EDS_ERR_OK)
                {
                    EdsError = EDSDK.EdsCreateEvfImageRef(stream, out outImg);
                }
                if (EdsError == EDSDK.EDS_ERR_OK)
                {
                    EdsError = EDSDK.EdsDownloadEvfImage(camera, outImg);
                }

                //image.set

                if(stream != null)
                {
                    EDSDK.EdsRelease(stream);
                }
                if(outImg != null)
                {
                    EDSDK.EdsRelease(outImg);
                }

                //EdsError = EDSDK.EdsCreateEvfImageRef(
            }
            else if(EdsError == EDSDK.EDS_ERR_INVALID_POINTER) 
            {
                label.Content = EdsError;
            }
            

        }
    }



    /*
    public void SetSetting(PropertyID propID, object value, int inParam = 0)
    {
        //CheckState();

        int propsize;
        DataType proptype;
        ErrorHandler.CheckError(this, CanonSDK.EdsGetPropertySize(CamRef, propID, inParam, out proptype, out propsize));
        ErrorHandler.CheckError(this, CanonSDK.EdsSetPropertyData(CamRef, propID, inParam, propsize, value));
        
    }
    */
    
}
