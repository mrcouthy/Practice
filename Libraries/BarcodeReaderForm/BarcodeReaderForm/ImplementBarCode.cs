using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawInput_dll;

namespace BarcodeReader
{
    public class ImplementBarCode
    {
        public ImplementBarCode(Form form)
        {
            form.KeyPreview = true;
            BarcodeReadEvent += BarcodeRead_Event;
            form.FormClosing += Keyboard_FormClosing;
          //  AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _rawinput = new RawInput(form.Handle);
            _rawinput.CaptureOnlyIfTopMostWindow = true; // Otherwise default behavior is to capture always
            _rawinput.AddMessageFilter(); // Adding a message filter will cause keypresses to be handled
            _rawinput.KeyPressed += OnKeyPressed;

          //  Win32.DeviceAudit(); 
        }
        public delegate void BarCodeReadHandler(string barcode);

        private RawInput _rawinput;
        private string _barcode = string.Empty;

       
        public event BarCodeReadHandler BarcodeReadEvent;

        private void BarcodeRead_Event(string barCode)
        {
            Debug.WriteLine("Barcode is :" + barCode);
        }

        private void OnKeyPressed(object sender, InputEventArg e)
        {
            if (e.KeyPressEvent.Name == "HID Keyboard Device")
            {
                if (e.KeyPressEvent.Message == Win32.WM_KEYDOWN)
                {
                    // Debug.WriteLine((char)e.KeyPressEvent.VKey +"  "+ e.KeyPressEvent.VKeyName);
                    _barcode = _barcode + (char)e.KeyPressEvent.VKey;
                    if (e.KeyPressEvent.VKeyName == "ENTER")
                    {
                        BarcodeReadEvent(_barcode.Trim());
                        _barcode = string.Empty;
                    }
                }
            }
        }

        private void Keyboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _rawinput.KeyPressed -= OnKeyPressed;
        }

        private static void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;

            if (null == ex) return;

            // Log this error. Logging the exception doesn't correct the problem but at least now
            // you may have more insight as to why the exception is being thrown.
            Debug.WriteLine("Unhandled Exception: " + ex.Message);
            Debug.WriteLine("Unhandled Exception: " + ex);
            MessageBox.Show(ex.Message);
        }

    }
}
