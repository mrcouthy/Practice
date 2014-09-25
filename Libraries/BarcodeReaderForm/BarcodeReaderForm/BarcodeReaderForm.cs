using System;
using System.Diagnostics;
using System.Windows.Forms;
using RawInput_dll;

namespace BarcodeReader
{
    public partial class BarcodeReaderForm : Form
    {
        public delegate void BarCodeReadHandler(string message);

        private readonly RawInput _rawinput;
        private string _barcode = string.Empty;

        public BarcodeReaderForm()
        {
            InitializeComponent();
            KeyPreview = true;
            BarcodeReadEvent += BarcodeRead_Event;
            FormClosing += Keyboard_FormClosing;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _rawinput = new RawInput(Handle);
            _rawinput.CaptureOnlyIfTopMostWindow = true; // Otherwise default behavior is to capture always
            _rawinput.AddMessageFilter(); // Adding a message filter will cause keypresses to be handled
            _rawinput.KeyPressed += OnKeyPressed;

            Win32.DeviceAudit();
        }

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
                    _barcode = _barcode + (char) e.KeyPressEvent.VKey;
                    if (e.KeyPressEvent.VKeyName == "ENTER")
                    {
                        BarcodeReadEvent(_barcode);
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

        private void BarcodeReaderForm_Load(object sender, EventArgs e)
        {

        }
    }
}